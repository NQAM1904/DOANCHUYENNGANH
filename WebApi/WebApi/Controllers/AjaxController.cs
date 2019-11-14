using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;


namespace WebApi.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
       public JsonResult GetService(int id)
        {
            if (Session["TaiKhoan"] is null) return null;
            
            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var serviceDB = db.SERVICES.Where(x => x.IDSERVICES == id).FirstOrDefault();
                if (serviceDB is null) return null;
                return new JsonResult()
                {
                    Data = new { NAME = serviceDB.NAMESERVICES, DESCRIPTION = serviceDB.SUMARYSERVICES, giakd = serviceDB.BEGIN_PRICE, giamax = serviceDB.MAX_PRICE },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
        [HttpPost]
        public string PostService(ServiceModel service)
        {
            if (Session["TaiKhoan"] is null) return "";
            var user = (USER)Session["TaiKhoan"];

            if (String.IsNullOrEmpty(service.NAMESERVICES) || String.IsNullOrEmpty(service.SUMARYSERVICES) && service.BEGIN_PRICE == 0 && service.MAX_PRICE == 0)
            {
                return "Vui lòng không bỏ trống thông tin";
            }

            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var agency = db.AGENCies.Where(x => x.IDUSER == user.IDUSER).FirstOrDefault();
                SERVICE s = new SERVICE();
                if (service.IDSERVICES > 0) s = db.SERVICES.Where(x => x.IDSERVICES == service.IDSERVICES).FirstOrDefault();
                if (s is null) return "Dữ liệu bất thường vui lòng thử lại sau";
                s.IDAGENCY = agency.IDAGENCY;
                s.NAMESERVICES = service.NAMESERVICES;
                s.SUMARYSERVICES = service.SUMARYSERVICES;
                s.BEGIN_PRICE = service.BEGIN_PRICE;
                s.MAX_PRICE = service.MAX_PRICE;
                if (service.IDSERVICES == 0) db.SERVICES.Add(s);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
            return "ok";
        }
        [HttpDelete]
        public string DeleteService(int id)
        {
            if (Session["TaiKhoan"] is null) return null;
          
            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var service = db.SERVICES.Where(x => x.IDSERVICES == id).FirstOrDefault();
                if (service is null) return "Không tìm thấy đối tượng này";
                db.SERVICES.Remove(service);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }

    }
}
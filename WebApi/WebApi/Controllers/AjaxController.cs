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
                    Data = new { Name = serviceDB.NAMESERVICES, DESCRIPTION = serviceDB.SUMARYSERVICES },
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet
                };
            }
        }
        [HttpPost]
        public string PostService(SERVICE service)
        {
            if (Session["TaiKhoan"] is null) return null;

            if (String.IsNullOrEmpty(service.NAMESERVICES) || String.IsNullOrEmpty(service.SUMARYSERVICES))
            {
                return "Vui lòng không bỏ trống thông tin";
            }
            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {

                SERVICE s = new SERVICE();
                if (service.IDSERVICES > 0) s = db.SERVICES.Where(x => x.IDSERVICES == service.IDSERVICES).FirstOrDefault();
                if (s is null) return "Dữ liệu bất thường vui lòng thử lại sau";
                s.NAMESERVICES = service.NAMESERVICES;
                s.SUMARYSERVICES = service.SUMARYSERVICES;
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
        }
    }
}
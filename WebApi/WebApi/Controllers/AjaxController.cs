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
        // category của agency
        public JsonResult GetCategory(int id)
        {
            if (Session["login"] is null) return null;
            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var category = db.CATEGORies.Where(x => x.IDCATE == id).FirstOrDefault();
                if (category is null) return null;
                return new JsonResult()
                {
                    Data = new { NAME = category.NAMECATE },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }

        [HttpPost]
        public string PostCategory(CATEGORY cate)
        {
            if (Session["login"] is null) return "";
            var user = (USER)Session["login"];

            if (String.IsNullOrEmpty(cate.NAMECATE))
            {
                return "Vui lòng không bỏ trống thông tin";
            }

            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {

                CATEGORY c = new CATEGORY();
                if (cate.IDCATE > 0) c = db.CATEGORies.Where(x => x.IDCATE == cate.IDCATE).FirstOrDefault();
                if (c is null) return "Dữ liệu bất thường vui lòng thử lại sau";
                c.IDCATE = cate.IDCATE;
                c.NAMECATE = cate.NAMECATE;
                if (cate.IDCATE == 0) db.CATEGORies.Add(c);
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
        public string DeleteCategory(int id)
        {
            if (Session["TaiKhoan"] is null) return null;

            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var cate = db.CATEGORies.Where(x => x.IDCATE == id).FirstOrDefault();
                if (cate is null) return "Không tìm thấy đối tượng này";
                db.CATEGORies.Remove(cate);
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
        // dịch vụ của agency
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


        // position của admin
        
        public JsonResult GetPosition(int id)
        {
            if (Session["login"] is null) return null;

            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var position = db.POSITIONs.Where(x => x.IDPOSITION == id).FirstOrDefault();
                if (position is null) return null;
                return new JsonResult()
                {
                    Data = new { NAME = position.NAME_POSITION },
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet
                };
            }
        }
        [HttpPost]
        public string EditPosition(POSITION position)
        {
            if (Session["login"] is null) return "";
            var user = (USER)Session["login"];

            if (String.IsNullOrEmpty(position.NAME_POSITION))
            {
                return "Vui lòng không bỏ trống thông tin";
            }

            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
               
                POSITION p = new POSITION();
                if (position.IDPOSITION > 0) p = db.POSITIONs.Where(x => x.IDPOSITION == position.IDPOSITION).FirstOrDefault();
                if (p is null) return "Dữ liệu bất thường vui lòng thử lại sau";
                p.IDPOSITION = position.IDPOSITION;
                p.NAME_POSITION = position.NAME_POSITION;
                if (position.IDPOSITION == 0) db.POSITIONs.Add(p);
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
        public string DeletePosition(int id)
        {
            if (Session["login"] is null) return null;

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
        // user của admin 
        public JsonResult User(int id)
        {
            if (Session["login"] is null) return null;
            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var userDB = db.USERs.Where(x => x.IDUSER == id).FirstOrDefault();
                if (userDB is null) return null;
                return new JsonResult()
                {
                    Data = new { fullname = userDB.FULLNAME, Name = userDB.USERNAME, role = userDB.IDROLE },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
        //category của admin
        //orderaccpet
        [HttpPost]
        public string AccpetOrder(int id)
        {
            if (Session["login"] is null) return null;
            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var order = db.ORDERs.Where(x => x.IDODER == id).FirstOrDefault();
                if (order is null) return "Không tìm thấy đối tượng này";
                try
                {
                    order.STATUS = 6;
                    ORDER_HISTORY history = new ORDER_HISTORY();
                    history.IDODER = id;
                    history.IDUSER = (Session["login"] as USER).IDUSER;
                    history.STATUS = order.STATUS;
                    history.DATE = DateTime.Now;
                    order.ORDER_HISTORY.Add(history);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "ok";
        }
        // orderdeny
        [HttpPost]
        public string DenyOrder(int id)
        {
            if (Session["login"] is null) return null;
            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var order = db.ORDERs.Where(x => x.IDODER == id).FirstOrDefault();
                if (order is null) return "Không tìm thấy đối tượng này";
                
                try
                {
                    order.STATUS = 4;
                    ORDER_HISTORY history = new ORDER_HISTORY();
                    history.IDODER = id;
                    history.IDUSER = (Session["login"] as USER).IDUSER;
                    history.STATUS = order.STATUS;
                    history.DATE = DateTime.Now;
                    order.ORDER_HISTORY.Add(history);
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
        public string DeleteOrder(int id)
        {
            if (Session["login"] is null) return null;

            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var order = db.ORDERs.Where(x => x.IDODER == id).FirstOrDefault();
                if (order is null) return "Không tìm thấy đối tượng này";
                db.ORDERs.Remove(order);
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
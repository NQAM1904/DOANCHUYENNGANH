using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class Agency_InfoController : Controller
    {
        // GET: Agency_Info
        public ActionResult Info(int id)
        {
            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var agency = db.AGENCies.Where(x => x.IDAGENCY == id).FirstOrDefault();
                if (agency is null) return HttpNotFound();
                return View(agency);
            }
        }
        [HttpPost]
        public ActionResult AddOrder(ORDER order, int IDAGENCY, int[] dsDV, string note)
        {
            try
            {
              
                using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
                {
                    var user = (USER)Session["TaiKhoan"];
                    var custom = db.CUSTOMERs.Where(x => x.IDUSER == user.IDUSER).FirstOrDefault();
                    var service = db.SERVICES.Where(x => x.IDAGENCY == IDAGENCY).FirstOrDefault();
                    ORDER o = new ORDER();
                    o.IDCUSTOMER = custom.IDCUSTOMER;
                    o.CREATE_ORDER = DateTime.Now;
                    o.IDAGENCY = IDAGENCY;
                    o.STATUS = false;
                    o.NOTE = note;
                    if (o.IDODER < 1) db.ORDERs.Add(o);
                    db.SaveChanges();
                    foreach(var item in dsDV)
                    {
                        ORDER_INFO oi = new ORDER_INFO();
                        oi.IDSERVICE = item;
                        oi.TOTAL_PRICE = service.MAX_PRICE;
                        o.ORDER_INFO.Add(oi);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return RedirectToAction("Info", new { id = IDAGENCY });
        }
    }
}
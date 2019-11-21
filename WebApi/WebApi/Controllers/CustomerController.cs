using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CustomerController : Controller
    {
        DOANCHUYENNGANHEntities data = new DOANCHUYENNGANHEntities();
        // GET: Customer
        public ActionResult Info()
        {
            ViewBag.Title = "SortList";
            if (Session["TaiKhoan"] is null) return RedirectToAction("Home", "Index");
            var idRole = ((USER)Session["TaiKhoan"]).IDROLE;
            if (idRole != 3) return RedirectToAction("Index");
            var user = (USER)Session["TaiKhoan"];
            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var custom = db.CUSTOMERs.Where(x => x.IDUSER == user.IDUSER).FirstOrDefault();
                if (custom == null) return RedirectToAction("Create", "Customer");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["TaiKhoan"] is null) return RedirectToAction("Index", "Home");
            var user = (USER)Session["TaiKhoan"];
            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var custom = db.CUSTOMERs.Where(x => x.IDUSER == user.IDUSER).FirstOrDefault();
                
                if (custom != null) return RedirectToAction("Index");
            }

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CUSTOMER custom)
        {
            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var user = (USER)Session["TaiKhoan"];


                custom.IDUSER = user.IDUSER;
                db.CUSTOMERs.Add(custom);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }

            }
            return RedirectToAction("Info", new { id = custom.IDCUSTOMER });
        }



    }
}
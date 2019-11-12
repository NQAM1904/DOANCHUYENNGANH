using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuongMaiDienTu.Helper;

namespace WebApi.Controllers
{
    public class AgencyController : Controller
    {

        // GET: Agency
        public ActionResult Index()
        {
            if (Session["TaiKhoan"] is null) return RedirectToAction("SignUp", "Login");
            var idRole = ((USER)Session["TaiKhoan"]).IDROLE;
            if (idRole != 2) return RedirectToAction("Index");
            var user = (USER)Session["TaiKhoan"];
            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var agency = db.AGENCies.Where(x => x.IDUSER == user.IDUSER).FirstOrDefault();
                if (agency == null) return RedirectToAction("Create", "Agency");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["TaiKhoan"] is null) return RedirectToAction("SignUp", "Login");
            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                ViewBag.IDCATE = db.CATEGORies.FirstOrDefault().IDCATE;
            }

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(AGENCY agency)
        {
            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var user = (USER)Session["TaiKhoan"];

                ViewBag.IDCATE = db.CATEGORies.FirstOrDefault().IDCATE;
                agency.IDUSER = user.IDUSER;
                db.AGENCies.Add(agency);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                }

            }
            return RedirectToAction("Index", new { id = agency.IDAGENCY });
        }
        [HttpGet]
        public ActionResult Img()
        {
            if (Session["TaiKhoan"] is null) return RedirectToAction("SignUp", "Login");
            return View();
        }
        [HttpPost]
        public ActionResult Img(HttpPostedFileBase files1, HttpPostedFileBase files2)
        {
            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                int idUser = ((USER)Session["TaiKhoan"]).IDUSER;
                var agency = db.AGENCies.Where(x => x.IDUSER == idUser).FirstOrDefault();
                if (files1 == null && files2 == null)
                {
                    ViewBag.Error = "Vui lòng chọn ảnh";
                  
                }
                else
                {
                    var fileName = Path.GetFileName(files1.FileName);
                    var fileName2 = Path.GetFileName(files2.FileName);
                    var path = Path.Combine(Server.MapPath("~/img/agency/"), fileName);
                    var path1 = Path.Combine(Server.MapPath("~/img/agency/"), fileName2);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        files1.SaveAs(path);
                        files2.SaveAs(path1);
                        IMGAGENCY img = new IMGAGENCY();
                        img.FILENAME = files1.FileName;
                        agency.IMGAGENCies.Add(img);
                        db.SaveChanges();
                    }
                }
                
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("SignUp", "Login");
        }
    }
}
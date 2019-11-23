using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        DOANCHUYENNGANHEntities data = new DOANCHUYENNGANHEntities();
       
        public ActionResult Index()
        {
            
            ViewBag.Title = "SortList";
       
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection collection, USER users)
        {
            var name = collection["hoten"];
            var user = collection["tendn"];
            var password = collection["matkhau"];

            if (String.IsNullOrEmpty(user) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(name))
            {
                ViewBag.Error = "không được bỏ trống";
            }
            else
            {
                users.FULLNAME = name;
                users.USERNAME = user;
                users.PASSWORD = password;
                users.IDROLE = 3;
                data.USERs.Add(users);
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            return Index();
        }
        [HttpPost]
        public ActionResult DangNhap(Login data)
        {
            
            if (data is null) return HttpNotFound();
            if (String.IsNullOrEmpty(data.USERNAME) && String.IsNullOrEmpty(data.PASSWORD))
            {
                ViewBag.Error = "Vui lòng nhập tài khoản hoặc mật khẩu";
                return RedirectToAction("DangKy", "Index");
            }

            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var userDB = db.USERs.Where(x => x.USERNAME.Equals(data.USERNAME.ToLower().Trim()) && x.PASSWORD.Equals(data.PASSWORD)).FirstOrDefault();
                if (userDB is null)
                {
                    ViewBag.Error = "Tài khoản hoặc mật khẩu không chính xác";
                    return View("DangKy", "Index");
                }

                Session["TaiKhoan"] = userDB;
                var idRole = ((USER)Session["TaiKhoan"]).IDROLE;
                if (idRole != 3) return RedirectToAction("Index");
                return RedirectToAction("Index");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }


    }
}

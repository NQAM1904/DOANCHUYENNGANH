using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;


namespace WebApi.Controllers
{
    public class LoginController : Controller
    {
        DOANCHUYENNGANHEntities data = new DOANCHUYENNGANHEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(FormCollection collection, USER users)
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
                users.IDROLE = 2;
                data.USERs.Add(users);
                data.SaveChanges();
                return RedirectToAction("Index","Agency");
            }
            return SignUp();
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Login data)
        {

            if (data is null) return HttpNotFound();
            if (String.IsNullOrEmpty(data.USERNAME) && String.IsNullOrEmpty(data.PASSWORD))
            {
                ViewBag.Error = "Vui lòng nhập tài khoản hoặc mật khẩu";
                return RedirectToAction("SignUp", "Login");
            }

            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var userDB = db.USERs.Where(x => x.USERNAME.Equals(data.USERNAME.ToLower().Trim()) && x.PASSWORD.Equals(data.PASSWORD)).FirstOrDefault();
                if (userDB is null)
                {
                    ViewBag.Error = "Tài khoản hoặc mật khẩu không chính xác";
                    return View("SignUp");
                }

                Session["TaiKhoan"] = userDB;
                return RedirectToAction("Index","Agency");
            }
        }
    }
}

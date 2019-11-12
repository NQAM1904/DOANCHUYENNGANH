using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class Cate_InfoController : Controller
    {
        // GET: Cate_Info
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Info(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
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
            ViewBag.Id = id;
            return View();
        }
    }
}
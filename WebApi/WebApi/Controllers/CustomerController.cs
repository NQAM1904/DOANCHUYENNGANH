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
        public ActionResult Index()
        {
            return View();
        }
       

 
    }
}
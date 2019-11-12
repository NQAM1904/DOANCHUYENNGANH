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
        public ActionResult Info(int? id)
        {
            using (DOANCHUYENNGANHEntities db = new DOANCHUYENNGANHEntities())
            {
                var agency = db.AGENCies.Where(x => x.IDAGENCY == id).FirstOrDefault();
                if (agency is null) return HttpNotFound();
                return View(agency);
            }
        }
    }
}
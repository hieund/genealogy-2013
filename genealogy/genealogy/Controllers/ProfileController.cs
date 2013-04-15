using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace genealogy.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Login()
        {
            return PartialView();
        }

        public ActionResult ProfileInfo()
        {
            return View();
        }

        public ActionResult AccountInfo()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace genealogy.Controllers
{
    public class CommonController : Controller
    {
        //
        // GET: /Common/

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Support()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Link()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Comment()
        {
            return PartialView();
        }
    }
}

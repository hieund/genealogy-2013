using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace genealogy.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }


        public ActionResult NewsPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewsPost(FormCollection fcl)
        {
            return View();
        }
    }
}

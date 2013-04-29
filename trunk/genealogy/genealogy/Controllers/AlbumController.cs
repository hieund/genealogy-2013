using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace genealogy.Controllers
{
    public class AlbumController : Controller
    {
        //
        // GET: /Album/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AlbumImages()
        {

            return View();
        }

        public ActionResult AlbumVideos()
        {
            return View();
        }

    }
}

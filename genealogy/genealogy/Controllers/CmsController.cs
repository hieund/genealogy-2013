using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace genealogy.Controllers
{
    public class CmsController : Controller
    {

        //
        // GET: /Cms/

        #region ActionResult

        public ActionResult Index()
        {
            return View();
        }

        #region Category
        public ActionResult NewsCategory()
        {
            return View();
        }

        public ActionResult NewsCategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewsCategoryCreate(int NewsCategoryID)
        {
            return View();
        }
        #endregion

        #region News
        public ActionResult NewsList()
        {
            return View();
        }
        public ActionResult NewsCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewsCreate(int NewsID)
        {
            return View();
        }
        #endregion

        #region NewsEvents

        #endregion



        #endregion

        #region ChildAction
        [ChildActionOnly]
        public ActionResult MenuCms()
        {
            return PartialView();
        }

        #region CMSAJAX

        #endregion
        #endregion

    }
}

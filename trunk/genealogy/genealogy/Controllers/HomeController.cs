using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using genealogy.business.Base;
using genealogy.business.Custom;
using genealogy.business;
namespace genealogy.Controllers
{
    public class HomeController : Controller
    {
        #region Page
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region ChildAction

        /// <summary>
        /// Lay top tin tuc hot nhat: 10 news
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult GetNewsTopHot()
        {
            List<GENNews> lst = NewsRepository.Current.GetTopNewsHot();
            return PartialView(lst);
        }

        /// <summary>
        /// Lay list tin tuc moi nhat : 10 news
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult GetNewsTopView()
        {
            List<GENNews> lst = NewsRepository.Current.GetTopNewsView();
            return PartialView(lst);
        }

        #endregion

    }
}

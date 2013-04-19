using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using genealogy.business;
using genealogy.business.Base;
using genealogy.Models;
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
            NewsModels mdNews = new NewsModels();
            return View(mdNews);
        }

        [HttpPost]
        public ActionResult NewsPost(NewsModels mdNews, FormCollection fcl)
        {
            return View();
        }

        /// <summary>
        /// Lay danh sach danh muc tin tuc
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetSelectCategory()
        {
            //List<GENNewsCategories> lst = MenuRepository.Current.CMSGetListMenuParent();
            //if (lst != null && lst.Count > 0)
            //{
            //    List<SelectListItem> lstItem = lst.AsEnumerable().Select(n => new SelectListItem()
            //    {
            //        Value = n.MenuID.ToString(),
            //        Text = n.MenuName
            //    }).ToList();
            //    var emptyItem = new SelectListItem()
            //    {
            //        Value = "0",
            //        Text = "Menu Cha"
            //    };
            //    lstItem.Insert(0, emptyItem);
            //    return lstItem;
            //}
            return null;
        }
    }
}

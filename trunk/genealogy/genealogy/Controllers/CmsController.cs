using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using genealogy.business.Base;
using genealogy.business.Custom;
using genealogy.Models;
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

        [ChildActionOnly]
        public ActionResult SearchCategory(string strkeyword)
        {
            return View();
        }


        public ActionResult NewsCategoryCreate(int id = 0)
        {
            NewsCategoryModels objNcm = new NewsCategoryModels();
            if (id != 0)
            {
                GENNewsCategories objGENNewsCategories = NewsCategoryRepository.Current.CMSGetNewsCategoryByID(id);
                if (objGENNewsCategories != null)
                {
                    objNcm = ModelHelper.Current.LoadModelsNewsCate(objGENNewsCategories);
                }
            }
            ViewBag.NewsCategoryID = id;
            return View(objNcm);
        }

        [HttpPost]
        public ActionResult NewsCategoryCreate(NewsCategoryModels mdNewsCategory)
        {
            if (ModelState.IsValid)
            {
                GENNewsCategories objNewsCategories = new GENNewsCategories();
                objNewsCategories.NewsCategoryID = mdNewsCategory.NewsCategoryID;
                objNewsCategories.NewsCategoryName = mdNewsCategory.NewsCategoryName;
                objNewsCategories.NewsCategoryShortName = mdNewsCategory.NewsCategoryShortName;
                objNewsCategories.CreatedUserID = 1;
                object temp;
                int intNewsCategoryID = 0;
                if (mdNewsCategory.NewsCategoryID != 0)
                {
                    objNewsCategories.UpdatedUserID = 1;
                    temp = objNewsCategories.Update();
                    intNewsCategoryID = mdNewsCategory.NewsCategoryID;
                    ViewBag.Result = "Cập nhật thành công !";
                }
                else
                {
                    temp = objNewsCategories.Insert();
                    ViewBag.Result = " Thêm mới thành công !";

                }
                objNewsCategories = new GENNewsCategories();
                objNewsCategories.NewsCategoryID = intNewsCategoryID;
                objNewsCategories.LoadByPrimaryKeys();
                mdNewsCategory = ModelHelper.Current.LoadModelsNewsCate(objNewsCategories);

            }
            return View(mdNewsCategory);
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

        #region Menu

        public ActionResult MenuList()
        {
            return View();
        }

        public ActionResult MenuEdit(int id = 0)
        {
            MenuModels objMenu = new MenuModels();
            if (id != 0)
            {
                UIMenus objUIMenus = MenuRepository.Current.CMSGetMenuByID(id);
                if (objUIMenus != null)
                {
                    objMenu = ModelHelper.Current.LoadModelsNewsCate(objUIMenus);
                }
            }
            ViewBag.NewsCategoryID = id;
            return View(objMenu);
        }

        //public ActionResult MenuEdit()
        //{
        //    return View();
        //}
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

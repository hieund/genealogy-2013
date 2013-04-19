using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using genealogy.business;
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
            int intTotalCount = 0;
            List<GENNewsCategories> lstResult = NewsCategoryRepository.Current.Search("", DataHelper.PageIndex, DataHelper.PageSize, ref intTotalCount);
            ViewBag.page = intTotalCount;
            ViewBag.CurrentPage = DataHelper.PageIndex;
            return View(lstResult);
        }

        public ActionResult SearchNewsCategory(string strkeyword, int PageIndex = 1)
        {
            strkeyword = DataHelper.Filterkeyword(strkeyword);
            int intTotalCount = 0;
            List<GENNewsCategories> lstResult = NewsCategoryRepository.Current.Search(strkeyword, PageIndex, DataHelper.PageSize, ref intTotalCount);
            ViewBag.page = intTotalCount;
            ViewBag.CurrentPage = PageIndex;
            return PartialView("~/Views/Cms/Shared/_ListNewsCategory.cshtml", lstResult);
        }


        public ActionResult NewsCategoryEdit(int id = 0)
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
        public ActionResult NewsCategoryEdit(NewsCategoryModels mdNewsCategory)
        {
            if (ModelState.IsValid)
            {
                GENNewsCategories objNewsCategories = new GENNewsCategories();
                objNewsCategories.NewsCategoryID = mdNewsCategory.NewsCategoryID;
                objNewsCategories.NewsCategoryName = mdNewsCategory.NewsCategoryName;
                objNewsCategories.NewsCategoryShortName = mdNewsCategory.NewsCategoryShortName;
                objNewsCategories.IsActived = mdNewsCategory.IsActived;
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

        //public ActionResult MenuList()
        //{
        //    int intTotalCount = 0;
        //    List<UIMenus> lstResult = MenuRepository.Current.Search("", DataHelper.PageIndex, DataHelper.PageSize, ref intTotalCount);
        //    ViewBag.page = intTotalCount;
        //    ViewBag.CurrentPage = DataHelper.PageIndex;
        //    return View(lstResult);
        //}

        //public ActionResult SearchMenu(string strkeyword, int PageIndex = 1)
        //{
        //    strkeyword = DataHelper.Filterkeyword(strkeyword);
        //    int intTotalCount = 0;
        //    List<GENNewsCategories> lstResult = NewsRepository.Current.Search(strkeyword, PageIndex, DataHelper.PageSize, ref intTotalCount);
        //    ViewBag.page = intTotalCount;
        //    ViewBag.CurrentPage = PageIndex;
        //    return PartialView("~/Views/Cms/Shared/_ListNewsCategory.cshtml", lstResult);
        //}

        public ActionResult MenuEdit(int id = 0)
        {
            MenuModels objMenu = new MenuModels();
            if (id != 0)
            {
                UIMenus objUIMenus = MenuRepository.Current.CMSGetMenuByID(id);
                if (objUIMenus != null)
                {
                    objMenu = ModelHelper.Current.LoadMenuModels(objUIMenus);
                }
            }
            ViewBag.MenuID = id;
            ViewBag.SelectMenu = GetSelectMenu();
            return View(objMenu);
        }

        [HttpPost]
        public ActionResult MenuEdit(MenuModels mdMenu, FormCollection fcl)
        {
            if (ModelState.IsValid)
            {
                UIMenus objMenu = new UIMenus();
                objMenu.MenuID = mdMenu.MenuID;
                objMenu.MenuName = mdMenu.MenuName;
                objMenu.MenuDescription = mdMenu.MenuDescription;
                objMenu.MenuLink = mdMenu.MenuLink;
                objMenu.ParentMenuID = Convert.ToInt32(fcl["SelectMenu"]);
                objMenu.IsActived = mdMenu.IsActived;
                objMenu.CreatedUserID = 1;
                object temp;
                int intMenuID = 0;
                if (mdMenu.MenuID != 0)
                {
                    objMenu.UpdatedUserID = 1;
                    temp = objMenu.Update();
                    intMenuID = mdMenu.MenuID;
                    ViewBag.Result = "Cập nhật thành công !";
                }
                else
                {
                    temp = objMenu.Insert();
                    ViewBag.Result = " Thêm mới thành công !";

                }
                objMenu = new UIMenus();
                objMenu.MenuID = intMenuID;
                objMenu.LoadByPrimaryKeys();
                mdMenu = ModelHelper.Current.LoadMenuModels(objMenu);

            }
            ViewBag.MenuID = mdMenu.MenuID;
            ViewBag.SelectMenu = GetSelectMenu();
            return View(mdMenu);
        }
        #endregion

        #endregion

        #region ChildAction
        [ChildActionOnly]
        public ActionResult MenuCms()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult MenuGetParent()
        {

            return PartialView();
        }

        public List<SelectListItem> GetSelectMenu()
        {
            List<UIMenus> lst = MenuRepository.Current.CMSGetListMenuParent();
            if (lst != null && lst.Count > 0)
            {
                List<SelectListItem> lstItem = lst.AsEnumerable().Select(n => new SelectListItem()
                {
                    Value = n.MenuID.ToString(),
                    Text = n.MenuName
                }).ToList();
                var emptyItem = new SelectListItem()
                {
                    Value = "0",
                    Text = "Menu Cha"
                };
                lstItem.Insert(0, emptyItem);
                return lstItem;
            }
            return null;
        }

        #region CMSAJAX

        #endregion
        #endregion




        public object ParentMenuID { get; set; }
    }
}

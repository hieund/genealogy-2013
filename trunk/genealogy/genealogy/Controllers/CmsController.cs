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

        public ActionResult NewsCategoryList()
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
                    intNewsCategoryID = Convert.ToInt32(temp);
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
            int intTotalCount = 0;
            List<UIMenus> lstResult = MenuRepository.Current.Search("", DataHelper.PageIndex, DataHelper.PageSize, ref intTotalCount);
            ViewBag.page = intTotalCount;
            ViewBag.CurrentPage = DataHelper.PageIndex;
            return View(lstResult);
        }

        public ActionResult SearchMenu(string strkeyword, int PageIndex = 1)
        {
            strkeyword = DataHelper.Filterkeyword(strkeyword);
            int intTotalCount = 0;
            List<UIMenus> lstResult = MenuRepository.Current.Search(strkeyword, PageIndex, DataHelper.PageSize, ref intTotalCount);
            ViewBag.page = intTotalCount;
            ViewBag.CurrentPage = PageIndex;
            return PartialView("~/Views/Cms/Shared/_ListMenu.cshtml", lstResult);
        }

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

        #region Album

        public ActionResult AlbumList()
        {
            int intTotalCount = 0;
            List<GENAlbums> lstResult = AlbumRepository.Current.Search("", DataHelper.PageIndex, DataHelper.PageSize, ref intTotalCount);
            ViewBag.page = intTotalCount;
            ViewBag.CurrentPage = DataHelper.PageIndex;
            return View(lstResult);
        }

        public ActionResult SearchAlbum(string strkeyword, int PageIndex = 1)
        {
            strkeyword = DataHelper.Filterkeyword(strkeyword);
            int intTotalCount = 0;
            List<GENAlbums> lstResult = AlbumRepository.Current.Search(strkeyword, PageIndex, DataHelper.PageSize, ref intTotalCount);
            ViewBag.page = intTotalCount;
            ViewBag.CurrentPage = PageIndex;
            return PartialView("~/Views/Cms/Shared/_ListAlbum.cshtml", lstResult);
        }

        public ActionResult AlbumEdit(int id = 0)
        {
            AlbumModels objAlbums = new AlbumModels();
            if (id != 0)
            {
                GENAlbums objGENAlbums = AlbumRepository.Current.CMSGetAlbumByID(id);
                if (objGENAlbums != null)
                {
                    objAlbums = ModelHelper.Current.LoadAlbumModels(objGENAlbums);
                }
            }
            ViewBag.AlbumID = id;
            ViewBag.SelectMenu = GetSelectMenu();
            return View(objAlbums);
        }

        [HttpPost]
        public ActionResult AlbumEdit(AlbumModels mdAlbum)
        {
            if (ModelState.IsValid)
            {
                GENAlbums objAlbums = new GENAlbums();
                objAlbums.AlbumID = mdAlbum.AlbumID;
                objAlbums.AlbumName = mdAlbum.AlbumName;
                objAlbums.AlbumImage = mdAlbum.AlbumImage;
                objAlbums.IsActived = mdAlbum.IsActived;
                objAlbums.CreatedUserID = 1;
                object temp;
                int intAlbumID = 0;
                if (mdAlbum.AlbumID != 0)
                {
                    objAlbums.UpdatedUserID = 1;
                    temp = objAlbums.Update();
                    intAlbumID = mdAlbum.AlbumID;
                    ViewBag.Result = "Cập nhật thành công !";
                }
                else
                {
                    temp = objAlbums.Insert();
                    ViewBag.Result = " Thêm mới thành công !";

                }
                objAlbums = new GENAlbums();
                objAlbums.AlbumID = intAlbumID;
                objAlbums.LoadByPrimaryKeys();
                mdAlbum = ModelHelper.Current.LoadAlbumModels(objAlbums);

            }
            ViewBag.AlbumID = mdAlbum.AlbumID;
            return View(mdAlbum);
        }
        #endregion

        #region AlbumDetail

        public ActionResult AlbumDetailList(int id)
        {
            int intTotalCount = 0;
            List<GENAlbumDetails> lstResult = AlbumDetailRepository.Current.CMSGetListAlbumDetailByAlbumID(id);
            ViewBag.page = intTotalCount;
            ViewBag.CurrentPage = DataHelper.PageIndex;
            return View(lstResult);
        }

        public ActionResult AlbumDetailEdit(int id = 0)
        {
            AlbumDetailModels objAlbumDetail = new AlbumDetailModels();
            if (id != 0)
            {
                GENAlbumDetails objGENAlbumDetails = AlbumDetailRepository.Current.CMSGetAlbumDetailByID(id);
                if (objGENAlbumDetails != null)
                {
                    objAlbumDetail = ModelHelper.Current.LoadAlbumDetailModels(objGENAlbumDetails);
                }
            }
            ViewBag.AlbumID = id;
            ViewBag.SelectAlbumDetailType = GetSelectAlbumDetailType();
            return View(objAlbumDetail);
        }

        [HttpPost]
        public ActionResult AlbumDetailEdit(AlbumDetailModels mdAlbumDetail, FormCollection fcl)
        {
            if (ModelState.IsValid)
            {
                int intAlbumID = 0;
                if (Request["albumid"] != null)
                {
                    intAlbumID = Convert.ToInt32(Request["albumid"]);
                }
                GENAlbumDetails objAlbums = new GENAlbumDetails();
                objAlbums.AlbumDetailID = mdAlbumDetail.AlbumDetailID;
                objAlbums.AlbumDetailName = mdAlbumDetail.AlbumDetailName;
                objAlbums.AlbumDetailTypeID = Convert.ToInt32(fcl["SelectAlbumDetailType"]);
                objAlbums.URL = mdAlbumDetail.URL;
                objAlbums.AlbumDetailImage = mdAlbumDetail.AlbumDetailImage;
                objAlbums.AlbumID = intAlbumID;
                objAlbums.OrderIndex = mdAlbumDetail.OrderIndex;
                object temp;
                int intAlbumDetailID = 0;
                if (mdAlbumDetail.AlbumDetailID != 0)
                {
                    temp = objAlbums.Update();
                    intAlbumDetailID = mdAlbumDetail.AlbumDetailID;
                    ViewBag.Result = "Cập nhật thành công !";
                }
                else
                {
                    temp = objAlbums.Insert();
                    ViewBag.Result = " Thêm mới thành công !";

                }
                objAlbums = new GENAlbumDetails();
                objAlbums.AlbumDetailID = intAlbumDetailID;
                objAlbums.LoadByPrimaryKeys();
                mdAlbumDetail = ModelHelper.Current.LoadAlbumDetailModels(objAlbums);

            }
            ViewBag.SelectAlbumDetailType = GetSelectAlbumDetailType();
            ViewBag.AlbumDetailID = mdAlbumDetail.AlbumDetailID;
            return View(mdAlbumDetail);
        }
        #endregion

        #region DocumentDirectories

        //public ActionResult DocumentDirectoryList(int id)
        //{
        //    int intTotalCount = 0;
        //    GENDocumentDirectories lstResult = DocumentDirectoryRepository.Current.GetDocumentDirectoryByID(id);
        //    ViewBag.page = intTotalCount;
        //    ViewBag.CurrentPage = DataHelper.PageIndex;
        //    return View(lstResult);
        //}

        public ActionResult DocumentDirectoryList()
        {
            int intTotalCount = 0;
            List<GENDocumentDirectories> lstResult = DocumentDirectoryRepository.Current.Search("", DataHelper.PageIndex, DataHelper.PageSize, ref intTotalCount);
            ViewBag.page = intTotalCount;
            ViewBag.CurrentPage = DataHelper.PageIndex;
            return View(lstResult);
        }

        public ActionResult SearchDocumentDirectory(string strkeyword, int PageIndex = 1)
        {
            strkeyword = DataHelper.Filterkeyword(strkeyword);
            int intTotalCount = 0;
            List<GENDocumentDirectories> lstResult = DocumentDirectoryRepository.Current.Search(strkeyword, PageIndex, DataHelper.PageSize, ref intTotalCount);
            ViewBag.page = intTotalCount;
            ViewBag.CurrentPage = PageIndex;
            return PartialView("~/Views/Cms/Shared/_ListDirectory.cshtml", lstResult);
        }

        public ActionResult DocumentDirectoryEdit(int id = 0)
        {
            DocumentDirectoryModels objDocumentDirectory = new DocumentDirectoryModels();
            if (id != 0)
            {
                GENDocumentDirectories objGENDocumentDirectories = DocumentDirectoryRepository.Current.CMSGetDocumentDirectoryByID(id);
                if (objGENDocumentDirectories != null)
                {
                    objDocumentDirectory = ModelHelper.Current.LoadDocumentDirectoryModels(objGENDocumentDirectories);
                }
            }
            ViewBag.FolderID = id;
            ViewBag.SelectDirectoryTree = GetSelectDirectoryTree();
            return View(objDocumentDirectory);
        }

        [HttpPost]
        public ActionResult DocumentDirectoryEdit(DocumentDirectoryModels mdDocumentDirectory, FormCollection fcl)
        {
            if (ModelState.IsValid)
            {
                //int intAlbumID = 0;
                //if (Request["albumid"] != null)
                //{
                //    intAlbumID = Convert.ToInt32(Request["albumid"]);
                //}
                GENDocumentDirectories objDocumentDirectory = new GENDocumentDirectories();
                objDocumentDirectory.FolderID = mdDocumentDirectory.FolderID;
                objDocumentDirectory.FolderName = mdDocumentDirectory.FolderName;
                objDocumentDirectory.FolderParentID = Convert.ToInt32(fcl["SelectDirectoryTree"]);
                objDocumentDirectory.IsActived = mdDocumentDirectory.IsActived;
                objDocumentDirectory.CreatedUserID = 1;
                object temp;
                int intFolderID = 0;
                if (mdDocumentDirectory.FolderID != 0)
                {
                    temp = objDocumentDirectory.Update();
                    intFolderID = mdDocumentDirectory.FolderID;
                    ViewBag.Result = "Cập nhật thành công !";
                }
                else
                {
                    temp = objDocumentDirectory.Insert();
                    intFolderID = Convert.ToInt32(temp);
                    ViewBag.Result = " Thêm mới thành công !";
                }
                objDocumentDirectory = new GENDocumentDirectories();
                objDocumentDirectory.FolderID = intFolderID;
                ViewBag.SelectDirectoryTree = GetSelectDirectoryTree();
                objDocumentDirectory.LoadByPrimaryKeys();
                mdDocumentDirectory = ModelHelper.Current.LoadDocumentDirectoryModels(objDocumentDirectory);

            }
            //ViewBag.SelectAlbumDetailType = GetSelectAlbumDetailType();
            ViewBag.FolderID = mdDocumentDirectory.FolderID;
            return View(mdDocumentDirectory);
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

        public List<SelectListItem> GetSelectDirectoryTree()
        {
            List<GENDocumentDirectories> lst = DocumentDirectoryRepository.Current.CMSGetDocumentDirectoryTree();
            if (lst != null && lst.Count > 0)
            {
                List<SelectListItem> lstItem = lst.AsEnumerable().Select(n => new SelectListItem()
                {
                    Value = n.FolderID.ToString(),
                    Text = n.DirectoryTree
                }).ToList();
                return lstItem;
            }
            return null;
        }

        public List<SelectListItem> GetSelectAlbumDetailType()
        {
            List<GENAlbumDetailsType> lst = AlbumDetailRepository.Current.CMSGetListAlbumDetailType();
            if (lst != null && lst.Count > 0)
            {
                List<SelectListItem> lstItem = lst.AsEnumerable().Select(n => new SelectListItem()
                {
                    Value = n.AlbumDetailTypeID.ToString(),
                    Text = n.AlbumDetailTypeName
                }).ToList();
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

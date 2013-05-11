using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using genealogy.business;
using genealogy.business.Base;
using genealogy.business.Custom;
using genealogy.Models;
using System.IO;
using WebLibs;
using System.Globalization;
using System.Text;
using TGDD.Library.Caching;
namespace genealogy.Controllers
{
    public class CmsController : Controller
    {
        #region Properties
        private CultureInfo objCultureInfo = new CultureInfo("vi-VN");
        #endregion

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
                    var physicalPathTemp = Server.MapPath("~/Upload/Album/Temp");
                    var physicalPath = Path.Combine(Server.MapPath("~/Upload/Album"), intAlbumID.ToString());
                    string[] arrFile = System.IO.Directory.GetFiles(physicalPathTemp);
                    if (arrFile.Length > 0)
                    {
                        //create directory Album if not exits
                        if (!Directory.Exists(physicalPath))
                        {
                            Directory.CreateDirectory(physicalPath);
                        }
                        foreach (var file in arrFile)
                        {
                            string stfilename = Path.GetFileName(file);
                            GENAlbumDetails objAlbumDetail = new GENAlbumDetails();
                            objAlbumDetail.AlbumDetailName = string.Empty;
                            objAlbumDetail.AlbumDetailImage = stfilename;
                            //1:hinh anh
                            //2:video
                            objAlbumDetail.AlbumDetailTypeID = 1;
                            objAlbumDetail.AlbumID = intAlbumID;
                            var detailid = objAlbumDetail.Insert();
                            var detaildirectory = Path.Combine(physicalPath, detailid.ToString());
                            var detailpathimage = Path.Combine(detaildirectory, stfilename);
                            if (!Directory.Exists(detaildirectory))
                            {
                                Directory.CreateDirectory(detaildirectory);
                            }
                            if (System.IO.File.Exists(detailpathimage))
                                System.IO.File.Delete(detailpathimage);
                            //move file from temp to album
                            System.IO.File.Move(file, detailpathimage);
                        }
                    }
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

        [ChildActionOnly]
        public ActionResult DetailAlbum(int id)
        {
            int intTotalCount = 0;
            List<GENAlbumDetails> lstResult = AlbumDetailRepository.Current.CMSGetListAlbumDetailByAlbumID(id);
            ViewBag.page = intTotalCount;
            ViewBag.CurrentPage = DataHelper.PageIndex;
            return PartialView(lstResult);
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

        #region DocumentDirectory

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
            return PartialView("~/Views/Cms/Shared/_ListDocumentDirectory.cshtml", lstResult);
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

        #region Document

        public ActionResult DocumentList()
        {
            int intTotalCount = 0;
            List<GENDocuments> lstResult = DocumentRepository.Current.Search("", DataHelper.PageIndex, DataHelper.PageSize, ref intTotalCount);
            ViewBag.page = intTotalCount;
            ViewBag.CurrentPage = DataHelper.PageIndex;
            return View(lstResult);
        }

        public ActionResult SearchDocument(string strkeyword, int PageIndex = 1)
        {
            strkeyword = DataHelper.Filterkeyword(strkeyword);
            int intTotalCount = 0;
            List<GENDocuments> lstResult = DocumentRepository.Current.Search(strkeyword, PageIndex, DataHelper.PageSize, ref intTotalCount);
            ViewBag.page = intTotalCount;
            ViewBag.CurrentPage = PageIndex;
            return PartialView("~/Views/Cms/Shared/_ListDocument.cshtml", lstResult);
        }

        public ActionResult DocumentEdit(int id = 0)
        {
            DocumentModels objDocument = new DocumentModels();
            if (id != 0)
            {
                GENDocuments objGENDocuments = DocumentRepository.Current.CMSGetDocumentDirectoryByID(id);
                if (objGENDocuments != null)
                {
                    objDocument = ModelHelper.Current.LoadDocumentModels(objGENDocuments);
                }
            }
            ViewBag.DocumentID = id;
            ViewBag.SelectDirectoryTree = GetSelectDirectoryTree();
            return View(objDocument);
        }

        [HttpPost]
        public ActionResult DocumentEdit(DocumentModels mdDocument, FormCollection fcl)
        {
            if (ModelState.IsValid)
            {
                //int intAlbumID = 0;
                //if (Request["albumid"] != null)
                //{
                //    intAlbumID = Convert.ToInt32(Request["albumid"]);
                //}
                GENDocuments objDocument = new GENDocuments();
                objDocument.DocumentID = mdDocument.DocumentID;
                objDocument.DocumentTitle = mdDocument.DocumentTitle;
                objDocument.DocumentFileName = mdDocument.DocumentFileName;
                objDocument.FolderID = Convert.ToInt32(fcl["SelectDirectoryTree"]);
                objDocument.IsActived = mdDocument.IsActived;
                objDocument.CreatedUserID = 1;
                object temp;
                int intDocumentID = 0;
                if (mdDocument.DocumentID != 0)
                {
                    temp = objDocument.Update();
                    intDocumentID = mdDocument.DocumentID;
                    ViewBag.Result = "Cập nhật thành công !";
                }
                else
                {
                    temp = objDocument.Insert();
                    intDocumentID = Convert.ToInt32(temp);
                    ViewBag.Result = " Thêm mới thành công !";
                }
                objDocument = new GENDocuments();
                objDocument.DocumentID = intDocumentID;
                ViewBag.SelectDirectoryTree = GetSelectDirectoryTree();
                objDocument.LoadByPrimaryKeys();
                mdDocument = ModelHelper.Current.LoadDocumentModels(objDocument);

            }
            ViewBag.DocumentID = mdDocument.DocumentID;
            return View(mdDocument);
        }
        #endregion

        #region User

        public ActionResult UserList()
        {
            int intTotalCount = 0;
            List<GENUsers> lstResult = UserRepository.Current.Search("", DataHelper.PageIndex, DataHelper.PageSize, ref intTotalCount);
            ViewBag.page = intTotalCount;
            ViewBag.CurrentPage = DataHelper.PageIndex;
            return View(lstResult);
        }

        public ActionResult SearchUser(string strkeyword, int PageIndex = 1)
        {
            strkeyword = DataHelper.Filterkeyword(strkeyword);
            int intTotalCount = 0;
            List<GENUsers> lstResult = UserRepository.Current.Search(strkeyword, PageIndex, DataHelper.PageSize, ref intTotalCount);
            ViewBag.page = intTotalCount;
            ViewBag.CurrentPage = PageIndex;
            return PartialView("~/Views/Cms/Shared/_ListUser.cshtml", lstResult);
        }

        public ActionResult AddUser()
        {
            GenealogyUserModels mdUser = new GenealogyUserModels();
            ViewBag.SelectProvinceCurrent = GetSelectProvince();
            ViewBag.SelectProvinceBirth = GetSelectProvince();
            ViewBag.SelectTypeRelation = GetSelectTypeRelation();
            return View(mdUser);
        }

        [HttpPost]
        public ActionResult AddUser(GenealogyUserModels mdGuser, FormCollection flc)
        {
            try
            {
                #region InsertUser
                GENUsers objUser = new GENUsers();
                objUser.Email = mdGuser.Email;
                objUser.Mobile = mdGuser.Mobile;
                objUser.FirstName = mdGuser.FirstName;
                objUser.LastName = mdGuser.LastName;
                objUser.FullName = mdGuser.FirstName.Trim() + " " + mdGuser.LastName.Trim();
                objUser.Birthday = DateTime.Parse(mdGuser.Birthday, objCultureInfo);
                objUser.BirthPlace = mdGuser.BirthPlace;
                objUser.BirthProvinceID = Convert.ToInt32(flc["SelectProvinceBirth"]);
                var gender = flc["gender"];
                objUser.Gender = Convert.ToBoolean(Convert.ToInt32(flc["gender"]));
                var status = flc["staus"];
                objUser.Status = Convert.ToInt32(flc["staus"]);
                objUser.CurrentPlace = mdGuser.CurrentPlace;
                objUser.CurrentProvinceID = Convert.ToInt32(flc["SelectProvinceCurrent"]);
                if (!string.IsNullOrEmpty(mdGuser.Password))
                    objUser.Password = Globals.DecryptMD5(mdGuser.Password);
                objUser.CreatedUserID = 1;
                if (mdGuser.DeathDate != null)
                    objUser.DeathDate = DateTime.Parse(mdGuser.DeathDate, objCultureInfo);
                object temp = objUser.Insert();
                #endregion

                #region InsertRelation
                object objUserRelaton = flc["userrelationid"];
                object objRelatonType = flc["SelectTypeRelation"];
                if (objUserRelaton != null)
                {
                    GFUserRelations objUr = new GFUserRelations();
                    objUr.UserID = Convert.ToInt32(temp);
                    objUr.UserRelationID = Convert.ToInt32(objUserRelaton);
                    objUr.RelationTypeID = Convert.ToInt32(objRelatonType);
                    objUr.Insert();
                }
                #endregion



                ViewBag.Result = 1;


            }
            catch (Exception objEx)
            {
                new SystemMessage("Cms - loi them moi user", "", objEx.ToString());
            }
            ViewBag.SelectProvinceCurrent = GetSelectProvince();
            ViewBag.SelectProvinceBirth = GetSelectProvince();
            ViewBag.SelectTypeRelation = GetSelectTypeRelation();
            return View();
        }

        public ActionResult EditUser(int Id)
        {
            GenealogyUserModels mdUser = new GenealogyUserModels();
            GENUsers objGENUsers = new GENUsers();
            objGENUsers.UserID = Id;
            if (objGENUsers.LoadByPrimaryKeys())
            {
                mdUser = ModelHelper.Current.LoadGenealogyUserModels(objGENUsers);
            }
            ViewBag.SelectProvinceCurrent = GetSelectProvince();
            ViewBag.SelectProvinceBirth = GetSelectProvince();
            ViewBag.SelectTypeRelation = GetSelectTypeRelation();
            return View(mdUser);
        }

        [HttpPost]
        public ActionResult EditUser(GenealogyUserModels mdGuser)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
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

        #region User

        [ChildActionOnly]
        public ActionResult GetUserRelation()
        {

            return PartialView();
        }

        #endregion

        #region DropDownList

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

        public List<SelectListItem> GetSelectProvince()
        {
            List<GENProvinces> lst = UserRepository.Current.GetListProvince();
            if (lst != null && lst.Count > 0)
            {
                List<SelectListItem> lstItem = lst.AsEnumerable().Select(n => new SelectListItem()
                {
                    Value = n.ProvinceID.ToString(),
                    Text = n.ProvinceName
                }).ToList();
                var temp = new SelectListItem { Value = "-1", Text = " - Chọn tỉnh/thành phố -" };
                lstItem.Insert(0, temp);
                return lstItem;
            }
            return null;
        }

        public List<SelectListItem> GetSelectTypeRelation()
        {
            List<GFUserRelationsType> lst = UserRepository.Current.GetListRelationType();
            if (lst != null && lst.Count > 0)
            {
                List<SelectListItem> lstItem = lst.AsEnumerable().Select(n => new SelectListItem()
                {
                    Value = n.RelationTypeID.ToString(),
                    Text = n.RelationTypeName
                }).ToList();
                return lstItem;
            }
            return null;
        }

        #endregion

        #region CMSAJAX

        public string GetUserSuggestion(string strkeyword)
        {
            string strCache = "GetUserSuggestion_" + WebLibs.Globals.FilterVietkey(strkeyword);
            int intTotal = 0;
            StringBuilder sbResult = (StringBuilder)CacheHelper.Get(strCache);
            if (sbResult == null)
            {
                sbResult = new StringBuilder();
                List<GENUsers> lstUser = UserRepository.Current.Search(strkeyword, 1, 10, ref intTotal);
                sbResult.Append("<ul>");
                if (intTotal > 0)
                {
                    foreach (GENUsers user in lstUser)
                    {
                        sbResult.Append("<li onclick=\"Setdata(this)\" data-userid=\"" + user.UserID + "\" data-username=\"" + user.FullName + "\" >");
                        sbResult.Append("<span>");
                        sbResult.Append(user.FullName);
                        sbResult.Append("</span>");
                        if (user.Birthday != null)
                        {
                            sbResult.Append("<br/>");
                            sbResult.Append("<span>");
                            sbResult.Append(Convert.ToDateTime(user.Birthday).ToString("dd/MM/yyyy"));
                            sbResult.Append("</span>");
                        }
                        sbResult.Append("</li>");

                    }
                }
                sbResult.Append("</ul>");

                CacheHelper.Add(strCache, sbResult);
            }
            return sbResult.ToString(); ;
        }

        #endregion

        #endregion

        #region UploadImage
        [ChildActionOnly]
        public ActionResult UpLoadImage(bool? autoUpload, bool? multiple)
        {
            ViewData["autoUpload"] = autoUpload ?? true;
            ViewData["multiple"] = multiple ?? true;
            return PartialView();
        }
        public ActionResult Save(IEnumerable<HttpPostedFileBase> attachments)
        {
            // The Name of the Upload component is "attachments" 
            foreach (var file in attachments)
            {
                // Some browsers send file names with full path. This needs to be stripped.
                var fileName = Path.GetFileName(file.FileName);
                var physicalPath = Path.Combine(Server.MapPath("~/Upload/Album/Temp"), fileName);

                // The files are not actually saved in this demo
                file.SaveAs(physicalPath);
            }
            // Return an empty string to signify success
            return Content("");
        }
        public ActionResult Remove(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"
            foreach (var fullName in fileNames)
            {
                var fileName = Path.GetFileName(fullName);
                var physicalPath = Path.Combine(Server.MapPath("~/Upload/Album/Temp"), fileName);

                // TODO: Verify user permissions
                if (System.IO.File.Exists(physicalPath))
                {
                    // The files are not actually removed in this demo
                    System.IO.File.Delete(physicalPath);
                }
            }
            // Return an empty string to signify success
            return Content("");
        }
        #endregion

        public object ParentMenuID { get; set; }
    }
}

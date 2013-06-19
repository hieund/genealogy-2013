using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using genealogy.Models;
using genealogy.business.Base;
using genealogy.business.Custom;
using genealogy.business;
using System.IO;
using System.Globalization;
using System.Text;
using WebLibs;
using TGDD.Library.Caching;

namespace genealogy.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/

        #region Properties
        private CultureInfo objCultureInfo = new CultureInfo("vi-VN");
        #endregion

        #region ActionResult Page

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult LoginForm()
        {
            GENUsers objUser = new GENUsers();
            UserModels mdUser = new UserModels();
            if (UserRepository.Current.IsLogin())
            {
                objUser = Session[DataHelper.UserLogin] as GENUsers;
                mdUser = ModelHelper.Current.LoadUserModels(objUser);
            }
            return PartialView(mdUser);
        }

        [HttpPost]
        public ActionResult LoginForm(UserModels mdUser)
        {
            if (ModelState.IsValid)
            {
                GENUsers objUser = UserRepository.Current.Login(mdUser.Email, mdUser.Password);
                if (objUser == null)
                {
                    return Json(new { Error = 1, Message = "Email hoặc mật khẩu không đúng.!" }, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(new { Error = 0 }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Error = 1, Message = "Email hoặc mật khẩu không đúng.!" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session[DataHelper.UserLogin] = null;
            Response.Redirect("/");
            return View();
        }

        public ActionResult Login()
        {
            LoginModels mdlogin = new LoginModels();
            return PartialView(mdlogin);
        }

        [HttpPost]
        public ActionResult Login(LoginModels mdlogin)
        {
            if (ModelState.IsValid)
            {
                GENUsers objUser = UserRepository.Current.Login(mdlogin.Email, mdlogin.Password);
                if (objUser == null)
                {
                    return Json(new { Error = 1, Message = "Email hoặc mật khẩu không đúng.!" }, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(new { Error = 0 }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Error = 1, Message = "Email hoặc mật khẩu không đúng.!" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ForgetPassword()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ForgetPassword(UserModels mdUser)
        {
            return PartialView();
        }

        public ActionResult ProfileInfo()
        {
            if (UserRepository.Current.IsLogin())
            {
                GENUsers objUser = new GENUsers();
                UserModels mdUser = new UserModels();
                objUser = Session[DataHelper.UserLogin] as GENUsers;
                mdUser = ModelHelper.Current.LoadUserModels(objUser);
                ViewBag.SelectProvinceCurrent = GetSelectProvince();
                ViewBag.SelectProvinceBirth = GetSelectProvince();
                return View(mdUser);
            }
            else
            {
                Response.Redirect("/dang-nhap");
            }
            return View();
        }


        public ActionResult UserInfo(string strUsernameUrl)
        {

            GENUsers objUser = new GENUsers();
            UserModels mdUser = new UserModels();
            objUser = Session[DataHelper.UserLogin] as GENUsers;
            mdUser = ModelHelper.Current.LoadUserModels(objUser);
            ViewBag.SelectProvinceCurrent = GetSelectProvince();
            ViewBag.SelectProvinceBirth = GetSelectProvince();
            return View(mdUser);

            return View();
        }

        [HttpPost]
        public ActionResult ProfileInfo(UserModels mUser, FormCollection fcl)
        {

            return View();
        }


        public ActionResult AccountInfo()
        {
            GENUsers objUser = new GENUsers();
            UserModels mdUser = new UserModels();
            if (UserRepository.Current.IsLogin())
            {
                objUser = Session[DataHelper.UserLogin] as GENUsers;
                mdUser = ModelHelper.Current.LoadUserModels(objUser);
            }
            ViewBag.SelectProvinceCurrent = GetSelectProvince();
            ViewBag.SelectProvinceBirth = GetSelectProvince();
            return View(mdUser);
        }

        public ActionResult AcountGuestInfo(string UserNameUrl)
        {



            GENUsers objUser = new GENUsers();
            UserModels mdUser = new UserModels();
            objUser = Session[DataHelper.UserLogin] as GENUsers;
            mdUser = ModelHelper.Current.LoadUserModels(objUser);
            ViewBag.SelectProvinceCurrent = GetSelectProvince();
            ViewBag.SelectProvinceBirth = GetSelectProvince();
            return View(mdUser);
        }

        [HttpPost]
        public ActionResult AccountInfo(UserModels mdUsers, FormCollection flc)
        {

            return View();
        }

        public ActionResult Register()
        {
            var userCurrent = this.getCurrentUser();
            if (userCurrent != null)
            {
                return RedirectToAction("Index", "Home");
            }
            UserModels mdUser = new UserModels();
            ViewBag.CurrentProvinceID = GetSelectProvince();
            ViewBag.BirthProvinceID = GetSelectProvince();
            return View(mdUser);
        }

        [HttpPost]
        public ActionResult Register(UserModels mdUsers, FormCollection flc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    GENUsers objUser = new GENUsers();
                    objUser.Email = mdUsers.Email;
                    objUser.Mobile = mdUsers.Mobile;
                    objUser.FirstName = mdUsers.FirstName;
                    objUser.LastName = mdUsers.LastName;
                    objUser.FullName = mdUsers.FirstName + " " + mdUsers.LastName;
                    objUser.Birthday = DateTime.Parse(mdUsers.Birthday, objCultureInfo);
                    objUser.BirthPlace = mdUsers.BirthPlace;
                    objUser.BirthProvinceID = mdUsers.BirthProvinceID;
                    objUser.Gender = mdUsers.Gender;
                    objUser.Status = mdUsers.Status;
                    objUser.CurrentPlace = mdUsers.CurrentPlace;
                    objUser.CurrentProvinceID = mdUsers.CurrentProvinceID;
                    objUser.Password = Globals.DecryptMD5(mdUsers.Password);

                    HttpPostedFileBase httpfile = Request.Files["fileuploadavatar"] as HttpPostedFileBase;
                    objUser.Avatar = httpfile.FileName;
                    objUser.CreatedUserID = 1;
                    objUser.FirstName = mdUsers.FirstName;
                    if (mdUsers.DeathDate != null)
                        objUser.DeathDate = DateTime.Parse(mdUsers.DeathDate, objCultureInfo);
                    object temp = objUser.Insert();

                    UploadImageAvatar(temp.ToString(), httpfile);
                    var result = UserRepository.Current.Login(objUser.Email, mdUsers.Password);
                    if (result != null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception objEx)
                {
                    new SystemMessage("Loi them moi user", "", objEx.ToString());
                }

            }
            return View(mdUsers);
        }

        public ActionResult RegisterSuccess()
        {
            return View();
        }

        public ActionResult GenealogyTree()
        {
            List<GENUsers> lstAll = UserRepository.Current.GetGenegologyTree();
            var temp = lstAll.Where(n => n.ParentID == 0);
            StringBuilder sb = new StringBuilder();
            if (temp != null)
            {
                sb = BuildGenegoryTree(temp.ToList());
                ViewBag.DataChart = BuildGenegoryChart(temp.ToList());
            }

            return View(sb);
        }

        #endregion

        #region Function Support
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

        private void UploadImageAvatar(string strUserID, HttpPostedFileBase httpfile)
        {
            try
            {
                if (!Directory.Exists(Server.MapPath("~/Upload/Avatar")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Upload/Avatar/"));
                    if (Directory.Exists(Server.MapPath("~/Upload/Avatar/" + strUserID)))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Upload/Avatar/" + strUserID));
                    }
                }
                else
                {
                    if (!Directory.Exists(Server.MapPath("~/Upload/Avatar/" + strUserID)))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Upload/Avatar/" + strUserID));
                    }
                }
                var path = Path.Combine(Server.MapPath("~/Upload/Avatar/" + strUserID), httpfile.FileName);
                httpfile.SaveAs(path);
            }
            catch (Exception objEx)
            {
                new SystemMessage("Loi upload hinh tin tuc", "", objEx.ToString());
            }
        }

        public StringBuilder BuildGenegoryTree(List<GENUsers> lstUser)
        {
            string strache = "ProfileController_BuildMenuTree";
            StringBuilder sbResult = CacheHelper.Get(strache) as StringBuilder;
            if (sbResult == null)
            {
                sbResult = new StringBuilder();
                sbResult.Append(BuildGenegoryTreeSub(lstUser));
                CacheHelper.Add(strache, sbResult);
            }
            return sbResult;
        }

        public string BuildGenegoryTreeSub(List<GENUsers> lstUserSub)
        {
            StringBuilder sbResult = new StringBuilder();
            List<GENUsers> lstAll = UserRepository.Current.GetGenegologyTree();
            foreach (GENUsers user in lstUserSub)
            {
                List<GENUsers> lstchild = new List<GENUsers>();
                var temp = lstAll.Where(p => p.ParentID == user.UserID);
                if (temp != null)
                    lstchild = temp.ToList();
                string strWife = !string.IsNullOrEmpty(user.ListWifeName) ? "(vợ " + user.ListWifeName.Replace(",", " và ") + ")" : string.Empty;
                sbResult.Append("<li>");
                sbResult.Append("<span>");
                sbResult.Append(user.FullName);
                sbResult.Append(" " + strWife);
                sbResult.Append("</span>");
                if (lstchild != null && lstchild.Count > 0)
                {
                    sbResult.Append("<ul>");
                    sbResult.Append(BuildGenegoryTreeSub(lstchild));
                    sbResult.Append("</ul>");
                }
                sbResult.Append("</li>");
            }
            return sbResult.ToString();
        }


        public StringBuilder BuildGenegoryChart(List<GENUsers> lstUser)
        {
            string strache = "ProfileController_BuildGenegoryChart";
            StringBuilder sbResult = CacheHelper.Get(strache) as StringBuilder;
            if (sbResult == null)
            {
                sbResult = new StringBuilder();
                sbResult.Append(BuildGenegoryChartSub(lstUser));
                CacheHelper.Add(strache, sbResult);
            }
            return sbResult;
        }

        public string BuildGenegoryChartSub(List<GENUsers> lstUserSub)
        {
            StringBuilder sbResult = new StringBuilder();
            List<GENUsers> lstAll = UserRepository.Current.GetGenegologyTree();
            string strItemp = ",['{0}', '{1}', '{2}']";
            foreach (GENUsers user in lstUserSub)
            {
                GENUsers UserParent = new GENUsers();
                UserParent.UserID = user.ParentID;
                List<GENUsers> lstchild = new List<GENUsers>();
                var temp = lstAll.Where(p => p.ParentID == user.UserID);
                if (temp != null)
                    lstchild = temp.ToList();

                string strWife = !string.IsNullOrEmpty(user.ListWifeName) ? "(vợ " + user.ListWifeName.Replace(",", " và ") + ")" : string.Empty;
                string strTemp = string.Empty;
                if (UserParent.LoadByPrimaryKeys())
                {
                    strTemp = string.Format(strItemp, user.FullName, UserParent.FullName, string.Empty);
                }
                else
                {
                    strTemp = string.Format(strItemp, user.FullName, string.Empty, string.Empty);
                }
                sbResult.Append(strTemp);
                if (lstchild != null && lstchild.Count > 0)
                {
                    sbResult.Append(BuildGenegoryChartSub(lstchild));
                }
            }
            return sbResult.ToString();
        }

        #endregion


        private UserModels getCurrentUser()
        {
            GENUsers objUser = new GENUsers();
            UserModels mdUser = new UserModels();
            if (UserRepository.Current.IsLogin())
            {
                objUser = Session[DataHelper.UserLogin] as GENUsers;
                mdUser = ModelHelper.Current.LoadUserModels(objUser);
                return mdUser;
            }
            return null;
        }

    }
}
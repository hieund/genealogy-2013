﻿using System;
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
using WebLibs;

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

        [ChildActionOnly]
        [HttpPost]
        public ActionResult LoginForm(UserModels mdUser)
        {
            GENUsers objUser = UserRepository.Current.Login(mdUser.Email, mdUser.Password);
            UserModels mdUserLogin = new UserModels();
            if (objUser == null)
            {
                ViewBag.Error = 1;
            }
            else
            {
                mdUserLogin = ModelHelper.Current.LoadUserModels(objUser);
            }

            return PartialView(mdUserLogin);
        }

        [ChildActionOnly]
        public ActionResult LoginOut()
        {
            Session[DataHelper.UserLogin] = null;

            return PartialView();
        }

        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Login(UserModels mdUser)
        {
            GENUsers objUser = UserRepository.Current.Login(mdUser.Email, mdUser.Password);
            UserModels mdUserLogin = new UserModels();
            if (objUser == null)
            {
                ViewBag.Error = 1;
            }
            else
            {
                mdUserLogin = ModelHelper.Current.LoadUserModels(objUser);
            }
            return PartialView(mdUserLogin);
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        public ActionResult ProfileInfo()
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

        [HttpPost]
        public ActionResult AccountInfo(UserModels mdUsers, FormCollection flc)
        {

            return View();
        }

        public ActionResult Register()
        {
            UserModels mdUser = new UserModels();
            ViewBag.SelectProvinceCurrent = GetSelectProvince();
            ViewBag.SelectProvinceBirth = GetSelectProvince();
            return View(mdUser);
        }


        [HttpPost]
        public ActionResult Register(UserModels mdUsers, FormCollection flc)
        {

            //if (ModelState.IsValid)
            //{
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
                objUser.BirthProvinceID = Convert.ToInt32(flc["SelectProvinceBirth"]);

                var gender = flc["gender"];
                objUser.Gender = Convert.ToBoolean(Convert.ToInt32(flc["gender"]));

                var status = flc["staus"];
                objUser.Status = Convert.ToInt32(flc["staus"]);

                objUser.CurrentPlace = mdUsers.CurrentPlace;
                objUser.CurrentProvinceID = Convert.ToInt32(flc["SelectProvinceCurrent"]);
                objUser.Password = Globals.DecryptMD5(mdUsers.Password);

                // HttpPostedFileBase httpfile = Request.Files["flupload"] as HttpPostedFileBase;
                // objUser.Avatar = httpfile.FileName;
                objUser.CreatedUserID = 1;
                objUser.FirstName = mdUsers.FirstName;
                if (mdUsers.DeathDate != null)
                    objUser.DeathDate = DateTime.Parse(mdUsers.DeathDate, objCultureInfo);
                object temp = objUser.Insert();
                //UploadImageAvatar(temp.ToString(), httpfile);
                return View("RegisterSuccess");

            }
            catch (Exception objEx)
            {
                new SystemMessage("Loi them moi user", "", objEx.ToString());
            }
            //}

            ViewBag.SelectProvinceCurrent = GetSelectProvince();
            ViewBag.SelectProvinceBirth = GetSelectProvince();
            return View();
        }

        public ActionResult RegisterSuccess()
        {
            return View();
        }

        public ActionResult GenealogyTree()
        {
            return View();
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
        #endregion

    }
}
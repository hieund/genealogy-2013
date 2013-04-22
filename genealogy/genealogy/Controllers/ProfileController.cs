using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using genealogy.Models;
using genealogy.business.Base;
using genealogy.business.Custom;
using genealogy.business;
namespace genealogy.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult LoginForm()
        {
            return PartialView();
        }


        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Login(UserModels mdUser)
        {

            return View();
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

            return View();
        }

        [HttpPost]
        public ActionResult AccountInfo(UserModels mdUsers, FormCollection flc)
        {

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.SelectProvince = GetSelectProvince();
            return View();
        }

        public ActionResult Register(UserModels mdUsers, FormCollection flc)
        {
            ViewBag.SelectProvince = GetSelectProvince();
            return View();
        }

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
                return lstItem;
            }
            return null;
        }
        #endregion
    }
}
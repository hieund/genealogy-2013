﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using genealogy.business;
using genealogy.business.Base;
using genealogy.business.Custom;
using WebLibs;
using TGDD.Library.Caching;
using genealogy.Models;
namespace genealogy.Controllers
{
    public class CommonController : Controller
    {
        //
        // GET: /Common/

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            List<UIMenus> lst = MenuRepository.Current.GetAllMenu();
            var temp = lst.Where(m => m.ParentMenuID == 0).ToList();
            StringBuilder sb = BuildMenuTree(temp);
            return PartialView(sb);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Support()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Link()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult FeedBack()
        {
            FeedBackModels feedback = new FeedBackModels();
            return PartialView(feedback);
        }

        [HttpPost]
        public ActionResult FeedBack(FeedBackModels feedback)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    FeedBack fb = new FeedBack()
                    {
                        FullName = feedback.FullName,
                        Content = feedback.Content
                    };
                    var result = fb.Insert();
                    return Json(new { Error = 0 }, JsonRequestBehavior.AllowGet);
                }
                catch
                {
                    return Json(new { Error = 1, Message = "Hệ thống bận, Bạn vui lòng gửi góp ý sau." }, JsonRequestBehavior.AllowGet); 
                }
            } 
            String error = string.Join("<br/>", ModelState.Values
                              .SelectMany(x => x.Errors)
                              .Select(x => x.ErrorMessage));
            return Json(new { Error = 1, Message = error }, JsonRequestBehavior.AllowGet);
        }

        #region Function Support

        public StringBuilder BuildMenuTree(List<UIMenus> lstMenu)
        {
            string strache = "CommonController_BuildMenuTree";
            StringBuilder sbResult = CacheHelper.Get(strache) as StringBuilder;
            if (sbResult == null)
            {
                sbResult = new StringBuilder();
                sbResult.Append(BuildMenuTreeSub(lstMenu));
                CacheHelper.Add(strache, sbResult);
            }
            return sbResult;
        }

        public string BuildMenuTreeSub(List<UIMenus> lstMenuSub)
        {
            StringBuilder sbResult = new StringBuilder();
            foreach (UIMenus menu in lstMenuSub)
            {
                List<UIMenus> lstchild = MenuRepository.Current.GetChildByParentId(menu.MenuID);
                sbResult.Append("<li>");
                if (menu.MenuLink.Contains("#"))
                    sbResult.Append("<a href=\"" + menu.MenuLink + "\" data-toggle=\"modal\">");
                else
                    sbResult.Append("<a href=\"" + menu.MenuLink + "\">");
                sbResult.Append(menu.MenuName);
                sbResult.Append("</a>");
                if (lstchild != null && lstchild.Count > 0)
                {
                    sbResult.Append("<ul>");
                    sbResult.Append(BuildMenuTreeSub(lstchild));
                    sbResult.Append("</ul>");
                }
                sbResult.Append("</li>");
            }
            return sbResult.ToString();
        }

        #endregion
    }
}

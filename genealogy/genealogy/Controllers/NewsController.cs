using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using genealogy.business;
using genealogy.business.Base;
using genealogy.business.Custom;
using genealogy.Models;
using WebLibs;
using System.IO;
namespace genealogy.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/

        #region Page

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
            ViewBag.SelectCategory = GetSelectCategory();
            return View(mdNews);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult NewsPost(NewsModels mdNews, FormCollection fcl)
        {

            NewsModels mdN = new NewsModels();
            if (ModelState.IsValid)
            {
                try
                {
                    GENNews objGENNews = new GENNews();
                    objGENNews.NewsTitle = mdNews.NewsTitle;
                    objGENNews.NewsTypeID = 1;
                    objGENNews.Description = HttpUtility.HtmlEncode(mdNews.Description);
                    objGENNews.NewsContent = HttpUtility.HtmlEncode(mdNews.NewsContent);
                    objGENNews.NewsCategoryID = Convert.ToInt32(fcl["SelectCategory"]);
                    objGENNews.CreatedAuthor = mdNews.CreatedAuthor;
                    objGENNews.CreatedEmail = mdNews.CreatedEmail;
                    objGENNews.CreatedSource = mdNews.CreatedSource;
                    objGENNews.IsEvent = false;
                    objGENNews.CreatedUserID = 1;
                    HttpPostedFileBase httpfile = Request.Files["flupload"] as HttpPostedFileBase;
                    var name = Path.GetExtension(httpfile.FileName);
                    //Guid.NewGuid() + 
                    UploadImageNews(objGENNews.NewsCategoryID.ToString(), httpfile);
                    objGENNews.Thumbnail = httpfile.FileName;
                    object temp = objGENNews.Insert();
                }
                catch (Exception objEx)
                {
                    new SystemMessage("Loi them moi1 dai tin", "", objEx.ToString());
                }
            }
            ViewBag.SelectCategory = GetSelectCategory();
            return View(mdN);
        }


        public ActionResult NewsDetail(string strNewsCategoryUrl, string strNewsUrl, int intNewsId)
        {

            return View();
        }


        #endregion


        #region Function Support

        /// <summary>
        /// Lay danh sach danh muc tin tuc
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetSelectCategory()
        {
            List<GENNewsCategories> lst = NewsCategoryRepository.Current.CMSGetListCategory();
            if (lst != null && lst.Count > 0)
            {
                List<SelectListItem> lstItem = lst.AsEnumerable().Select(n => new SelectListItem()
                {
                    Value = n.NewsCategoryID.ToString(),
                    Text = n.NewsCategoryName
                }).ToList();
                var emptyItem = new SelectListItem()
                {
                    Value = "0",
                    Text = " - Chọn danh mục tin - "
                };
                lstItem.Insert(0, emptyItem);
                return lstItem;
            }
            return null;
        }

        private void UploadImageNews(string strNewsCategoryId, HttpPostedFileBase httpfile)
        {
            try
            {
                if (!Directory.Exists(Server.MapPath("~/Upload/Thumnail")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Upload/Thumnail/"));
                    if (Directory.Exists(Server.MapPath("~/Upload/Thumnail/" + strNewsCategoryId)))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Upload/Thumnail/" + strNewsCategoryId));
                    }
                }
                else
                {
                    if (!Directory.Exists(Server.MapPath("~/Upload/Thumnail/" + strNewsCategoryId)))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Upload/Thumnail/" + strNewsCategoryId));
                    }
                }
                var path = Path.Combine(Server.MapPath("~/Upload/Thumnail/" + strNewsCategoryId), httpfile.FileName);
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

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
using System.Data;
using System.Net;
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


        public ActionResult NewsDetail(string NewsCategoryUrl, string NewsUrl, int NewsId)
        {
            GENNews objGENNews = NewsRepository.Current.LoadNewsById(NewsId);
            ViewBag.id = NewsId;
            return View(objGENNews);
        }

        [ChildActionOnly]
        public ActionResult GetNewsByCateId(int intCategoryId)
        {
            List<GENNews> lstnews = NewsRepository.Current.GetNewsByCategoryId(intCategoryId, 1, 20);
            return PartialView(lstnews);
        }

        [ChildActionOnly]
        public ActionResult GetDataRss(string strUrl)
        {
            if (string.IsNullOrEmpty(strUrl))
                strUrl = "http://vnexpress.net/rss/gl/trang-chu.rss";
            List<RSSModels> lst = new List<RSSModels>();
            lst = ReadFeed(strUrl);
            return PartialView(lst);
        }

        public static List<RSSModels> ReadFeed(string url)
        {
            //create a new list of the rss feed items to return
            List<RSSModels> rssFeedItems = new List<RSSModels>();
            try
            {
                //create an http request which will be used to retrieve the rss feed
                HttpWebRequest rssFeed = (HttpWebRequest)WebRequest.Create(url);

                //use a dataset to retrieve the rss feed
                using (DataSet rssData = new DataSet())
                {
                    //read the xml from the stream of the web request
                    rssData.ReadXml(rssFeed.GetResponse().GetResponseStream());

                    //loop through the rss items in the dataset and populate the list of rss feed items
                    foreach (DataRow dataRow in rssData.Tables["item"].Rows)
                    {
                        rssFeedItems.Add(new RSSModels
                        {
                            ChannelId = Convert.ToInt32(dataRow["channel_Id"]),
                            Description = Convert.ToString(dataRow["description"]),
                            Link = Convert.ToString(dataRow["link"]),
                            PublishDate = Convert.ToDateTime(dataRow["pubDate"]),
                            Title = Convert.ToString(dataRow["title"])
                        });
                    }
                }
            }
            catch (Exception objEx)
            {
                new SystemMessage("Loi lay noi dung tu rss", "", objEx.ToString());
            }
            //return the rss feed items
            return rssFeedItems;
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
                List<SelectListItem> lstItem = lst.Select(n => new SelectListItem()
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

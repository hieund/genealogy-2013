using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using genealogy.business.Base;
using TGDD.Library.Caching;
namespace genealogy.business.Custom
{
    public class NewsRepository
    {
        #region static
        private static NewsRepository _instance;
        public static NewsRepository Current
        {
            get
            {
                return _instance ?? (_instance = new NewsRepository());
            }
        }

        #endregion

        #region Function Support

        /// <summary>
        /// Lay danh sach tin moi nhat
        /// </summary>
        /// <returns></returns>
        public List<GENNews> GetTopNewsHot()
        {
            string strCache = "NewsRepository_GetTopNewsHot";
            List<GENNews> lstNews = CacheHelper.Get(strCache) as List<GENNews>;
            if (lstNews != null)
                return lstNews;
            lstNews = GENNews.Current.GetTopNewsHot();
            CacheHelper.Add(strCache, lstNews);
            return lstNews;
        }

        /// <summary>
        /// Lay danh sach tin duoc xem nhieu nhat
        /// </summary>
        /// <returns></returns>
        public List<GENNews> GetTopNewsView()
        {
            string strCache = "NewsRepository_GetTopNewsView";
            List<GENNews> lstNews = CacheHelper.Get(strCache) as List<GENNews>;
            if (lstNews != null)
                return lstNews;
            lstNews = GENNews.Current.GetTopNewsView();
            CacheHelper.Add(strCache, lstNews);
            return lstNews;
        }

        /// <summary>
        /// Load thong tin News ByID
        /// </summary>
        /// <param name="intNewsId"></param>
        /// <returns></returns>
        public GENNews LoadNewsById(int intNewsId)
        {
            string strCache = "NewsRepository_LoadNewsById_" + intNewsId;
            GENNews objNews = CacheHelper.Get(strCache) as GENNews;
            if (objNews != null)
                return objNews;
            objNews = new GENNews();
            objNews.NewsID = intNewsId;
            objNews.LoadByPrimaryKeys();
            CacheHelper.Add(strCache, objNews);
            return objNews;
        }
        #endregion
    }
}
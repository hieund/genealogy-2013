using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace genealogy.business.Custom
{
    using genealogy.business.Base;
    using TGDD.Library.Caching;

    public class CommentsRepository
    {
        #region static
        private static CommentsRepository _instance;
        public static CommentsRepository Current
        {
            get
            {
                return _instance ?? (_instance = new CommentsRepository());
            }
        }
        #endregion

        #region properties

        private const string COMMENT_NEWS = "COMMENT_NEWS_";

        private const string COMMENT_ALL = "COMMENT_ALL";

        #endregion

        public List<GENComments> GetCommentByNews(int newsID)
        {
            string cacheKey = COMMENT_NEWS + newsID;
            List<GENComments> comments = CacheHelper.Get(cacheKey) as List<GENComments>;
            if (comments == null)
            {
                comments = GENComments.Current.GetByNews(newsID);
                CacheHelper.Add(cacheKey, comments);
            }
            return comments;
        }

        public void RemoveCommentByNews(int newsID)
        {
            string cacheKey = COMMENT_NEWS + newsID;
            CacheHelper.Remove(cacheKey);
            
        }

        public List<GENComments> GetAll()
        {
            string cacheKey = COMMENT_ALL;
            List<GENComments> comments = CacheHelper.Get(cacheKey) as List<GENComments>;
            if (comments == null)
            {
                comments = GENComments.Current.GetAll();
                CacheHelper.Add(cacheKey, comments);
            }
            return comments;
        }

        public object Insert(GENComments genComments)
        {
            return genComments.Insert();

        }
    }
}
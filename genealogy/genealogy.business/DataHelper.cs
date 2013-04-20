using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using genealogy.business.Base;
using WebLibs;
using System.Configuration;
using WebLibs;
namespace genealogy.business
{
    public class DataHelper
    {
        #region static
        private static DataHelper _instance;
        public static DataHelper Current
        {
            get
            {
                return _instance ?? (_instance = new DataHelper());
            }
        }
        #endregion

        public static string Filterkeyword(string strkeyword)
        {
            string strresult = string.Empty;
            strresult = HttpUtility.UrlDecode(strkeyword.Trim());
            strresult = Globals.FilterVietkey(strresult);
            return strresult.ToUpper();
        }

        public static int PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
        public static int PageIndex = Convert.ToInt32(ConfigurationManager.AppSettings["PageIndex"]);


        #region CommnHelper
        public string GenThumnailNews(GENNews objNews)
        {
            string strResult = string.Empty;
            strResult = Globals.ApplicationVRoot() + "/Upload/" + objNews.NewsCategoryID + "/" + objNews.Thumbnail;
            return strResult;
        }

        #endregion
    }
}
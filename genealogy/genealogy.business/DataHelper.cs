using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using genealogy.business.Base;
using WebLibs;
using System.Configuration;
using System.Text.RegularExpressions;

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

        /// <summary>
        /// Gen hinh Thumnail tin tuc
        /// </summary>
        /// <param name="objNews"></param>
        /// <returns></returns>
        public static string GenThumnailNews(GENNews objNews)
        {
            string strResult = string.Empty;
            strResult = Globals.ApplicationVRoot() + "/Upload/Thumnail/" + objNews.NewsCategoryID + "/" + objNews.Thumbnail;
            return strResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objNews"></param>
        /// <returns></returns>
        public static string GenNewsCategoryurl(GENNews objNews)
        {
            string strResult = string.Empty;
            strResult = Globals.ApplicationVRoot() + "/tin-tuc/" + Globals.FormatURLText(objNews.NewsCategoryName) + "/" + Globals.FormatURLText(objNews.NewsTitle) + "-" + objNews.NewsID;
            return strResult;
        }

        public static string FilterHtmlTag(string s)
        {
            s = s.Replace("&nbsp;", " ");
            s = s.Replace("&lt;", "<");
            s = s.Replace("&gt;", ">");
            s = s.Replace("&amp;", "&");
            s = s.Replace("&quot;", "\"");
            s = Regex.Replace(s, @"\x20{2,}", " ");
            s = Regex.Replace(s, "<[^>]*>", "");
            return s.Trim();
        }
        /// <summary>
        /// Cat chuoi hien thi tin tuc
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="intNumChar"></param>
        /// <returns></returns>
        public static string SubString(string strInput, int intNumChar)
        {
            string strRestult = string.Empty;
            strInput = FilterHtmlTag(strInput);
            if (strInput.Length > intNumChar)
            {
                strRestult = strInput.Substring(0, intNumChar) + "...";
            }
            else
            {
                strRestult = strInput + "...";
            }
            return strRestult;
        }

        public static string GenImageAvatar(int intUserID, string strAvatar)
        {
            return Globals.ApplicationVRoot() + "/Upload/Avatar/" + intUserID + "/" + strAvatar;
        }
        #endregion
    }
}
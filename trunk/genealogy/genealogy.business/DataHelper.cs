using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using genealogy.business.Base;
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

        public string Filterkeyword(string strkeyword)
        {
            string strresult = string.Empty;
            strresult = HttpUtility.UrlDecode(strkeyword.Trim());
            strresult = Globals.FilterVietkey(strresult);
            return strresult.ToUpper();
        }
    }
}
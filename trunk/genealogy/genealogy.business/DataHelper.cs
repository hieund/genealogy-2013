using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using genealogy.business.Base;


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

        
    }
}
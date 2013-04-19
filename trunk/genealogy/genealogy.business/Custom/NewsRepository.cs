using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using genealogy.business.Base;
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
    }
}
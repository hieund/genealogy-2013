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

        public List<GENNewsCategories> Search(string strkeyword, int intPageIndex, int intPageSize, ref int intTotalCount)
        {
            return GENNewsCategories.Current.Search(strkeyword, intPageSize, intPageIndex, ref intTotalCount);
        }
        #endregion
    }
}
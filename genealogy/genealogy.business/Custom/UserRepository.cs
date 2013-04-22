using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TGDD.Library.Caching;
using genealogy.business.Base;
using WebLibs;
using System.Data;

namespace genealogy.business.Custom
{
    public class UserRepository
    {
        #region static
        private static UserRepository _instance;
        public static UserRepository Current
        {
            get
            {
                return _instance ?? (_instance = new UserRepository());
            }
        }

        #endregion

        #region Method
        public List<GENProvinces> GetListProvince()
        {
            string strCache = "UserRepository_GetListProvince";
            List<GENProvinces> lst = CacheHelper.Get(strCache) as List<GENProvinces>;
            if (lst != null)
                return lst;
            lst = GENProvinces.Current.GetAllProvince();
            CacheHelper.Add(strCache, lst);
            return lst;
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TGDD.Library.Caching;
using genealogy.business.Base;
namespace genealogy.business.Custom
{
    public class MenuRepository
    {

        #region static
        private static MenuRepository _instance;
        public static MenuRepository Current
        {
            get
            {
                return _instance ?? (_instance = new MenuRepository());
            }
        }
        #endregion

        #region properties
        string strCacheCommon = "MenuRepository_";
        #endregion

        #region FrontEnd
        public UIMenus GetMenuByID(int intMenuID)
        {
            string strCachekey = strCacheCommon + "MenuRepositoryID" + intMenuID;
            UIMenus objUIMenus = CacheHelper.Get(strCachekey) as UIMenus;
            if (objUIMenus == null)
            {
                objUIMenus = new UIMenus();
                objUIMenus.MenuID = intMenuID;
                if (objUIMenus.LoadByPrimaryKeys())
                    CacheHelper.Add(strCachekey, objUIMenus);
            }
            return objUIMenus;
        }
        #endregion

        #region CMS
        public UIMenus CMSGetMenuByID(int intMenuID)
        {
            UIMenus objUIMenus = new UIMenus();
            objUIMenus.MenuID = intMenuID;
            objUIMenus.LoadByPrimaryKeys();
            return objUIMenus;
        }
        #endregion



    }
}
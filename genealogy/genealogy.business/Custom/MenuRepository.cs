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
        private IData objDataAccess = null;
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
        /// <summary>
        /// lay thong tin menu theo id
        /// </summary>
        /// <param name="intMenuID"></param>
        /// <returns></returns>
        /// 

        public List<UIMenus> Search(string strkeyword, int intPageIndex, int intPageSize, ref int intTotalCount)
        {
            return UIMenus.Current.Search(strkeyword, intPageSize, intPageIndex, ref intTotalCount);
        }

        public UIMenus CMSGetMenuByID(int intMenuID)
        {
            UIMenus objUIMenus = new UIMenus();
            objUIMenus.MenuID = intMenuID;
            objUIMenus.LoadByPrimaryKeys();
            return objUIMenus;
        }

        /// <summary>
        /// lay danh sach menu
        /// </summary>
        /// <returns></returns>
        public List<UIMenus> CMSGetListMenuParent()
        {
            return UIMenus.Current.CMSGetListMenuParent();
        }
        #endregion



    }
}
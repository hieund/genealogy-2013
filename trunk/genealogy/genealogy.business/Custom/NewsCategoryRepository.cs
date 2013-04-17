﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TGDD.Library.Caching;
using genealogy.business.Base;
namespace genealogy.business.Custom
{
    public class NewsCategoryRepository
    {

        #region static
        private static NewsCategoryRepository _instance;
        public static NewsCategoryRepository Current
        {
            get
            {
                return _instance ?? (_instance = new NewsCategoryRepository());
            }
        }
        #endregion

        #region properties
        string strCacheCommon = "NewsCategoryRepository_";
        #endregion

        #region FrontEnd
        public GENNewsCategories GetNewsCategoryByID(int intCategoryID)
        {
            string strCachekey = strCacheCommon + "GetNewsCategoryByID_" + intCategoryID;
            GENNewsCategories objGENNewsCategories = CacheHelper.Get(strCachekey) as GENNewsCategories;
            if (objGENNewsCategories == null)
            {
                objGENNewsCategories = new GENNewsCategories();
                objGENNewsCategories.NewsCategoryID = intCategoryID;
                if (objGENNewsCategories.LoadByPrimaryKeys())
                    CacheHelper.Add(strCachekey, objGENNewsCategories);
            }
            return objGENNewsCategories;
        }
        #endregion

        #region CMS
        public GENNewsCategories CMSGetNewsCategoryByID(int intCategoryID)
        {
            GENNewsCategories objGENNewsCategories = new GENNewsCategories();
            objGENNewsCategories.NewsCategoryID = intCategoryID;
            objGENNewsCategories.LoadByPrimaryKeys();
            return objGENNewsCategories;
        }
        #endregion



    }
}
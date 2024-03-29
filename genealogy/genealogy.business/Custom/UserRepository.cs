﻿using System;
using System.Web;
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

        #region properties
        string strCacheCommon = "UserRepository_";
        private IData objDataAccess = null;
        #endregion

        #region FrontEnd
        public GENUsers GetUserByID(int intUserID)
        {
            string strCachekey = strCacheCommon + "UserRepositoryID" + intUserID;
            GENUsers objUIUsers = CacheHelper.Get(strCachekey) as GENUsers;
            if (objUIUsers == null)
            {
                objUIUsers = new GENUsers();
                objUIUsers.UserID = intUserID;
                if (objUIUsers.LoadByPrimaryKeys())
                    CacheHelper.Add(strCachekey, objUIUsers);
            }
            return objUIUsers;
        }

        public GENUsers Login(string strEmail, string strPassword)
        {
            GENUsers objUser = HttpContext.Current.Session[DataHelper.UserLogin] as GENUsers;
            if (objUser == null)
            {
                objUser = new GENUsers();
                if (!string.IsNullOrEmpty(strEmail) && !string.IsNullOrEmpty(strPassword))
                {
                    objUser.Email = strEmail;
                    objUser.Password = Globals.DecryptMD5(strPassword);
                    if (objUser.Login())
                    {
                        HttpContext.Current.Session[DataHelper.UserLogin] = objUser;
                        return objUser;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    objUser = new GENUsers();
                }
            }
            return objUser;
        }

        public List<GFUserRelationsType> GetListRelationType()
        {
            string strCachekey = strCacheCommon + "GetListRelationType_";
            List<GFUserRelationsType> lstUrlt = CacheHelper.Get(strCachekey) as List<GFUserRelationsType>;
            if (lstUrlt == null)
            {
                lstUrlt = GFUserRelationsType.Current.GetAllUserRelationType();
                CacheHelper.Add(strCachekey, lstUrlt);
            }
            return lstUrlt;
        }

        public List<GENUsers> GetGenegologyTree()
        {
            string strcachekey = "UserRepository_GetGenegologyTree";
            List<GENUsers> lst = CacheHelper.Get(strcachekey) as List<GENUsers>;
            if (lst != null)
                return lst;
            lst = GENUsers.Current.GetUserForTree();
            CacheHelper.Add(strcachekey, lst);
            return lst;
        }

        public bool IsLogin()
        {
            if (HttpContext.Current.Session[DataHelper.UserLogin] != null)
                return true;
            else
                return false;
        }

        public GENUsers GetUserByUrl(string strUrl)
        {
            GENUsers objUser = new GENUsers();


            return objUser;
        }


        public List<GENUsers> GetAllUser()
        {
            List<GENUsers> lstAll = new List<GENUsers>();

            return lstAll;
        }

        public DataTable GetFamilyByUserId(int userId)
        {
            string strcachekey = "UserRepository_GetFamilyByUserId_" + userId;
            DataTable dtb = CacheHelper.Get(strcachekey) as DataTable;
            if (dtb != null)
                return dtb;
            dtb = GENUsers.Current.GetFamilyByUserId(userId);
            CacheHelper.Add(strcachekey, dtb);
            return dtb;
        }

        #endregion

        #region CMS

        public List<GENUsers> Search(string strkeyword, int intPageIndex, int intPageSize, ref int intTotalCount)
        {
            return GENUsers.Current.Search(strkeyword, intPageSize, intPageIndex, ref intTotalCount);
        }

        /// <summary>
        /// lay thong tin User theo id
        /// </summary>
        /// <param name="intUserID"></param>
        /// <returns></returns>
        /// 
        public GENUsers CMSGetUserByID(int intUserID)
        {
            GENUsers objGENUsers = new GENUsers();
            objGENUsers.UserID = intUserID;
            objGENUsers.LoadByPrimaryKeys();
            return objGENUsers;
        }

        public List<GENUsers> GetUserRelationsByUserId(int UserId)
        {
            return GENUsers.Current.GetUserRelationsByUserId(UserId);
        }

        #endregion
    }
}
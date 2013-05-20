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
    public class AlbumRepository
    {

        #region static
        private static AlbumRepository _instance;
        public static AlbumRepository Current
        {
            get
            {
                return _instance ?? (_instance = new AlbumRepository());
            }
        }
        #endregion

        #region properties
        string strCacheCommon = "AlbumRepository_";
        private IData objDataAccess = null;
        #endregion

        #region FrontEnd
        public List<GENAlbums> GetAllAlbum(int intTypeId)
        {
            string strCachekey = strCacheCommon + "GetAllAlbum_ " + intTypeId;
            List<GENAlbums> lstGENAlbums = CacheHelper.Get(strCachekey) as List<GENAlbums>;
            if (lstGENAlbums == null)
            {
                GENAlbums objGENAlbums = new GENAlbums();
                lstGENAlbums = objGENAlbums.GetAll(intTypeId);
                CacheHelper.Add(strCachekey, lstGENAlbums);
            }
            return lstGENAlbums;
        }
        public GENAlbums GetAlbumByID(int intAlbumID)
        {
            string strCachekey = strCacheCommon + "AlbumRepositoryID" + intAlbumID;
            GENAlbums objGENAlbums = CacheHelper.Get(strCachekey) as GENAlbums;
            if (objGENAlbums == null)
            {
                objGENAlbums = new GENAlbums();
                objGENAlbums.AlbumID = intAlbumID;
                if (objGENAlbums.LoadByPrimaryKeys())
                    CacheHelper.Add(strCachekey, objGENAlbums);
            }
            return objGENAlbums;
        }


        #endregion

        #region CMS
        /// <summary>
        /// lay thong tin Album theo id
        /// </summary>
        /// <param name="intAlbumID"></param>
        /// <returns></returns>
        /// 

        public List<GENAlbums> Search(string strkeyword, int intPageIndex, int intPageSize, int intTypeId, ref int intTotalCount)
        {
            return GENAlbums.Current.Search(strkeyword, intPageSize, intPageIndex, intTypeId, ref intTotalCount);
        }

        public GENAlbums CMSGetAlbumByID(int intAlbumID)
        {
            GENAlbums objGENAlbums = new GENAlbums();
            objGENAlbums.AlbumID = intAlbumID;
            objGENAlbums.LoadByPrimaryKeys();
            return objGENAlbums;
        }

        /// <summary>
        /// lay danh sach Album
        /// </summary>
        /// <returns></returns>
        //public List<GENAlbums> CMSGetListAlbumParent()
        //{
        //    return GENAlbums.Current.CMSGetListAlbumParent();
        //}

        #endregion



    }
}
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
    public class AlbumDetailRepository
    {

        #region static
        private static AlbumDetailRepository _instance;
        public static AlbumDetailRepository Current
        {
            get
            {
                return _instance ?? (_instance = new AlbumDetailRepository());
            }
        }
        #endregion

        #region properties
        string strCacheCommon = "AlbumDetailRepository_";
        private IData objDataAccess = null;
        #endregion

        #region FrontEnd
        public GENAlbumDetails GetAlbumDetailByID(int intAlbumDetailID)
        {
            string strCachekey = strCacheCommon + "AlbumDetailRepositoryID" + intAlbumDetailID;
            GENAlbumDetails objGENAlbumDetails = CacheHelper.Get(strCachekey) as GENAlbumDetails;
            if (objGENAlbumDetails == null)
            {
                objGENAlbumDetails = new GENAlbumDetails();
                objGENAlbumDetails.AlbumDetailID = intAlbumDetailID;
                if (objGENAlbumDetails.LoadByPrimaryKeys())
                    CacheHelper.Add(strCachekey, objGENAlbumDetails);
            }
            return objGENAlbumDetails;
        }

        /// <summary>
        /// lay danh sach alnumdetail theo albumid
        /// </summary>
        /// <param name="intAlbumID"></param>
        /// <returns></returns>
        public List<GENAlbumDetails> GetListAlbumDetailByAlbumID(int intAlbumID, int intTypeId)
        {
            string strCache = strCacheCommon + "GetListAlbumDetailByAlbumID_" + intAlbumID + "_" + intTypeId;
            List<GENAlbumDetails> lst = CacheHelper.Get(strCache) as List<GENAlbumDetails>;
            if (lst == null)
            {
                GENAlbumDetails objGENAlbumDetails = new GENAlbumDetails();
                objGENAlbumDetails.AlbumID = intAlbumID;
                objGENAlbumDetails.AlbumDetailTypeID = intTypeId;
                lst = objGENAlbumDetails.GetAlbumDetailByAlbumID();
            }
            return lst;
        }

        public List<GENAlbumDetails> GetListVideoBox(int intAlbumID, int intTypeId)
        {
            string strCache = strCacheCommon + "GetListVideoBox_" + intAlbumID + "_" + intTypeId;
            List<GENAlbumDetails> lst = CacheHelper.Get(strCache) as List<GENAlbumDetails>;
            if (lst == null)
            {
                GENAlbumDetails objGENAlbumDetails = new GENAlbumDetails();
                objGENAlbumDetails.AlbumID = intAlbumID;
                objGENAlbumDetails.AlbumDetailTypeID = intTypeId;
                lst = objGENAlbumDetails.GetAlbumDetailByAlbumID();
            }
            return lst;
        }

        #endregion

        #region CMS
        /// <summary>
        /// lay thong tin Album theo id
        /// </summary>
        /// <param name="intAlbumID"></param>
        /// <returns></returns>
        /// 


        public GENAlbumDetails CMSGetAlbumDetailByID(int intAlbumDetailID)
        {
            GENAlbumDetails objGENAlbumDetails = new GENAlbumDetails();
            objGENAlbumDetails.AlbumDetailID = intAlbumDetailID;
            objGENAlbumDetails.LoadByPrimaryKeys();
            return objGENAlbumDetails;
        }

        public List<GENAlbumDetails> CMSGetListAlbumDetailByAlbumID(int intAlbumID, int intTypeId)
        {
            GENAlbumDetails objGENAlbumDetails = new GENAlbumDetails();
            objGENAlbumDetails.AlbumID = intAlbumID;
            objGENAlbumDetails.AlbumDetailTypeID = intTypeId;
            List<GENAlbumDetails> lst = objGENAlbumDetails.GetAlbumDetailByAlbumID();
            return lst;
        }

        /// <summary>
        /// lay danh sach Album
        /// </summary>
        /// <returns></returns>
        //public List<GENAlbumDetails> CMSGetListAlbumParent()
        //{
        //    return GENAlbumDetails.Current.CMSGetListAlbumParent();
        //}
        public List<GENAlbumDetailsType> CMSGetListAlbumDetailType()
        {
            return GENAlbumDetails.Current.CMSGetListAlbumDetailType();
        }

        #endregion

    }
}
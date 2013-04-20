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
    public class DocumentRepository
    {

        #region static
        private static DocumentRepository _instance;
        public static DocumentRepository Current
        {
            get
            {
                return _instance ?? (_instance = new DocumentRepository());
            }
        }
        #endregion

        #region properties
        string strCacheCommon = "DocumentRepository_";
        private IData objDataAccess = null;
        #endregion

        #region FrontEnd
        public GENDocuments GetDocumentDirectoryByID(int intFolderID)
        {
            string strCachekey = strCacheCommon + "DocumentRepositoryID" + intFolderID;
            GENDocuments objGENDocuments = CacheHelper.Get(strCachekey) as GENDocuments;
            if (objGENDocuments == null)
            {
                objGENDocuments = new GENDocuments();
                objGENDocuments.FolderID = intFolderID;
                if (objGENDocuments.LoadByPrimaryKeys())
                    CacheHelper.Add(strCachekey, objGENDocuments);
            }
            return objGENDocuments;
        }
        #endregion

        #region CMS
        /// <summary>
        /// lay thong tin Album theo id
        /// </summary>
        /// <param name="intAlbumID"></param>
        /// <returns></returns>
        /// 


        public GENDocuments CMSGetDocumentDirectoryByID(int intFolderID)
        {
            GENDocuments objGENDocuments = new GENDocuments();
            objGENDocuments.FolderID = intFolderID;
            objGENDocuments.LoadByPrimaryKeys();
            return objGENDocuments;
        }
        #endregion

        //public List<GENDocuments> CMSGetDocumentDirectoryTree()
        //{
        //    return GENDocuments.Current.CMSGetDocumentDirectoryTree();
        //}

        public List<GENDocuments> Search(string strkeyword, int intPageIndex, int intPageSize, ref int intTotalCount)
        {
            return GENDocuments.Current.Search(strkeyword, intPageSize, intPageIndex, ref intTotalCount);
        }
    }
}
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
    public class DocumentDirectoryRepository
    {

        #region static
        private static DocumentDirectoryRepository _instance;
        public static DocumentDirectoryRepository Current
        {
            get
            {
                return _instance ?? (_instance = new DocumentDirectoryRepository());
            }
        }
        #endregion

        #region properties
        string strCacheCommon = "DocumentDirectoryRepository_";
        private IData objDataAccess = null;
        #endregion

        #region FrontEnd
        public GENDocumentDirectories GetDocumentDirectoryByID(int intFolderID)
        {
            string strCachekey = strCacheCommon + "DocumentDirectoryRepositoryID" + intFolderID;
            GENDocumentDirectories objGENDocumentDirectories = CacheHelper.Get(strCachekey) as GENDocumentDirectories;
            if (objGENDocumentDirectories == null)
            {
                objGENDocumentDirectories = new GENDocumentDirectories();
                objGENDocumentDirectories.FolderID = intFolderID;
                if (objGENDocumentDirectories.LoadByPrimaryKeys())
                    CacheHelper.Add(strCachekey, objGENDocumentDirectories);
            }
            return objGENDocumentDirectories;
        }
        #endregion

        #region CMS
        /// <summary>
        /// lay thong tin Album theo id
        /// </summary>
        /// <param name="intAlbumID"></param>
        /// <returns></returns>
        /// 


        public GENDocumentDirectories CMSGetDocumentDirectoryByID(int intFolderID)
        {
            GENDocumentDirectories objGENDocumentDirectories = new GENDocumentDirectories();
            objGENDocumentDirectories.FolderID = intFolderID;
            objGENDocumentDirectories.LoadByPrimaryKeys();
            return objGENDocumentDirectories;
        }
        #endregion

        public List<GENDocumentDirectories> CMSGetDocumentDirectoryTree()
        {
            return GENDocumentDirectories.Current.CMSGetDocumentDirectoryTree();
        }

        public List<GENDocumentDirectories> Search(string strkeyword, int intPageIndex, int intPageSize, ref int intTotalCount)
        {
            return GENDocumentDirectories.Current.Search(strkeyword, intPageSize, intPageIndex, ref intTotalCount);
        }
    }
}
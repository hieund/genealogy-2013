using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using genealogy.business.Base;
namespace genealogy.Models
{
    public class ModelHelper
    {
        #region static
        private static ModelHelper _instance;
        public static ModelHelper Current
        {
            get
            {
                return _instance ?? (_instance = new ModelHelper());
            }
        }
        #endregion

        /// <summary>
        /// Convert GENNewsCategories to NewsCategoryModels
        /// </summary>
        /// <param name="objGNC"></param>
        /// <returns></returns>
        public NewsCategoryModels LoadModelsNewsCate(GENNewsCategories objGNC)
        {
            NewsCategoryModels objModel = new NewsCategoryModels();
            objModel.NewsCategoryID = objGNC.NewsCategoryID;
            objModel.NewsCategoryName = objGNC.NewsCategoryName;
            objModel.NewsCategoryShortName = objGNC.NewsCategoryShortName;
            objModel.CreatedUserID = objGNC.CreatedUserID;
            objModel.CreatedDate = objGNC.CreatedDate;
            objModel.IsActived = objGNC.IsActived;
            return objModel;
        }

        /// <summary>
        /// Convert UIMenus to MenuModels
        /// </summary>
        /// <param name="objUIM"></param>
        /// <returns></returns>
        public MenuModels LoadMenuModels(UIMenus objUIM)
        {
            MenuModels objModel = new MenuModels();
            objModel.MenuID = objUIM.MenuID;
            objModel.MenuName = objUIM.MenuName;
            objModel.MenuDescription = objUIM.MenuDescription;
            objModel.MenuLink = objUIM.MenuLink;
            objModel.IsActived = objUIM.IsActived;
            objModel.IsDeleted = objUIM.IsDeleted;
            objModel.CreatedUserID = objUIM.CreatedUserID;
            objModel.CreatedDate = objUIM.CreatedDate;
            objModel.UpdatedUserID = objUIM.UpdatedUserID;
            objModel.UpdatedDate = objUIM.UpdatedDate;
            objModel.DeletedUserID = objUIM.DeletedUserID;
            objModel.DeletedDate = objUIM.DeletedDate;
            objModel.ParentMenuID = objUIM.ParentMenuID;
            return objModel;
        }

        /// <summary>
        /// Convert GENNews to NewsModels 
        /// </summary>
        /// <param name="objNews"></param>
        /// <returns></returns>
        public NewsModels LoadNewsModels(GENNews objNews)
        {
            NewsModels objModel = new NewsModels();
            objModel.NewsID = objNews.NewsID;
            objModel.NewsTitle = objNews.NewsTitle;
            objModel.NewsTypeID = objNews.NewsTypeID;
            objModel.NewsContent = objNews.NewsContent;
            objModel.NewsCategoryID = objNews.NewsID;
            objModel.Description = objNews.Description;
            objModel.Thumbnail = objNews.Thumbnail;
            objModel.StartEvent = objNews.StartEvent;
            objModel.EndEvent = objNews.EndEvent;
            objModel.IsEvent = objNews.IsEvent;
            objModel.CreatedAuthor = objNews.CreatedAuthor;
            objModel.CreatedEmail = objNews.CreatedEmail;
            objModel.CreatedSource = objNews.CreatedSource;
            objModel.IsActived = objNews.IsActived;
            objModel.IsDeleted = objNews.IsDeleted;
            objModel.CreatedUserID = objNews.CreatedUserID;
            objModel.CreatedDate = objNews.CreatedDate;
            objModel.UpdatedUserID = objNews.UpdatedUserID;
            objModel.UpdatedDate = objNews.UpdatedDate;
            objModel.DeletedUserID = objNews.DeletedUserID;
            objModel.DeletedDate = objNews.DeletedDate;
            return objModel;
        }

        public AlbumModels LoadAlbumModels(GENAlbums objGAL)
        {
            AlbumModels objModel = new AlbumModels();
            objModel.AlbumID = objGAL.AlbumID;
            objModel.AlbumName = objGAL.AlbumName;
            objModel.AlbumImage = objGAL.AlbumImage;
            objModel.IsActived = objGAL.IsActived;
            objModel.IsDeleted = objGAL.IsDeleted;
            objModel.CreatedUserID = objGAL.CreatedUserID;
            objModel.CreatedDate = objGAL.CreatedDate;
            objModel.UpdatedUserID = objGAL.UpdatedUserID;
            objModel.UpdatedDate = objGAL.UpdatedDate;
            objModel.DeletedUserID = objGAL.DeletedUserID;
            objModel.DeletedDate = objGAL.DeletedDate;
            return objModel;
        }
    }
}
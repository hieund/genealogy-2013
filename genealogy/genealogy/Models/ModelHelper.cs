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
            objModel.OrderIndex = Convert.ToInt32(objUIM.OrderIndex);
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


        public AlbumDetailModels LoadAlbumDetailModels(GENAlbumDetails objGALD)
        {
            AlbumDetailModels objModel = new AlbumDetailModels();
            objModel.AlbumDetailID = objGALD.AlbumDetailID;
            objModel.AlbumDetailName = objGALD.AlbumDetailName;
            objModel.AlbumDetailTypeID = objGALD.AlbumDetailTypeID;
            objModel.URL = objGALD.URL;
            objModel.AlbumDetailImage = objGALD.AlbumDetailImage;
            objModel.AlbumID = objGALD.AlbumID;
            objModel.OrderIndex = objGALD.OrderIndex;
            objModel.ContentFrame = objGALD.ContentFrame;
            return objModel;
        }

        public DocumentDirectoryModels LoadDocumentDirectoryModels(GENDocumentDirectories objGDD)
        {
            DocumentDirectoryModels objModel = new DocumentDirectoryModels();
            objModel.FolderID = objGDD.FolderID;
            objModel.FolderName = objGDD.FolderName;
            objModel.FolderParentID = objGDD.FolderParentID;
            objModel.NodeTree = objGDD.NodeTree;
            objModel.IsActived = objGDD.IsActived;
            objModel.IsDeleted = objGDD.IsDeleted;
            objModel.CreatedUserID = objGDD.CreatedUserID;
            objModel.CreatedDate = objGDD.CreatedDate;
            objModel.UpdatedUserID = objGDD.UpdatedUserID;
            objModel.UpdatedDate = objGDD.UpdatedDate;
            objModel.DeletedUserID = objGDD.DeletedUserID;
            objModel.DeletedDate = objGDD.DeletedDate;
            return objModel;
        }

        public DocumentModels LoadDocumentModels(GENDocuments objDM)
        {
            DocumentModels objModel = new DocumentModels();
            objModel.DocumentID = objDM.DocumentID;
            objModel.DocumentTitle = objDM.DocumentTitle;
            objModel.DocumentFileName = objDM.DocumentFileName;
            objModel.IsActived = objDM.IsActived;
            objModel.IsDeleted = objDM.IsDeleted;
            objModel.CreatedUserID = objDM.CreatedUserID;
            objModel.CreatedDate = objDM.CreatedDate;
            objModel.UpdatedUserID = objDM.UpdatedUserID;
            objModel.UpdatedDate = objDM.UpdatedDate;
            objModel.DeletedUserID = objDM.DeletedUserID;
            objModel.DeletedDate = objDM.DeletedDate;
            objModel.FolderID = objDM.FolderID;
            return objModel;
        }

        public UserModels LoadUserModels(GENUsers objUser)
        {
            UserModels objModel = new UserModels();
            objModel.UserID = objUser.UserID;
            objModel.FirstName = objUser.FirstName;
            objModel.LastName = objUser.LastName;
            objModel.Password = objUser.Password;
            objModel.NickName = objUser.NickName;
            objModel.KitoName = objUser.KitoName;
            objModel.FullName = objUser.FullName;
            objModel.IsAdmin = objUser.IsAdmin;
            objModel.Birthday = objUser.Birthday != null ? objUser.Birthday.ToString() : string.Empty;
            objModel.AboutMe = objUser.AboutMe;
            objModel.Hobby = objUser.Hobby;
            objModel.Email = objUser.Email;
            objModel.Address = objUser.Address;
            objModel.Jobs = objUser.Jobs;
            objModel.Gender = Convert.ToInt32(objUser.Gender);
            objModel.DeathDate = objUser.DeathDate != null ? objUser.DeathDate.ToString() : string.Empty;
            objModel.CurrentPlace = objUser.CurrentPlace;
            objModel.BirthPlace = objUser.BirthPlace;
            objModel.Status = objUser.Status;
            objModel.Mobile = objUser.Mobile;
            objModel.IsActived = objUser.IsActived;
            objModel.IsDeleted = objUser.IsDeleted;
            objModel.CreatedUserID = objUser.CreatedUserID; 
            objModel.CurrentProvinceID = objUser.CurrentProvinceID;
            objModel.BirthProvinceID = objUser.BirthProvinceID;


            return objModel;
        }

        public GenealogyUserModels LoadGenealogyUserModels(GENUsers objUser)
        {
            GenealogyUserModels objModel = new GenealogyUserModels();
            objModel.UserId = objUser.UserID;
            objModel.FirstName = objUser.FirstName;
            objModel.LastName = objUser.LastName;
            objModel.Password = objUser.Password;
            objModel.NickName = objUser.NickName;
            objModel.KitoName = objUser.KitoName;
            objModel.FullName = objUser.FullName;
            objModel.IsAdmin = objUser.IsAdmin;
            objModel.Birthday = objUser.Birthday != null ? objUser.Birthday : DateTime.Now;
            objModel.AboutMe = objUser.AboutMe;
            objModel.Hobby = objUser.Hobby;
            objModel.Email = objUser.Email;
            objModel.Address = objUser.Address;
            objModel.Jobs = objUser.Jobs;
            objModel.Gender = objUser.Gender;
            objModel.DeathDate = objUser.DeathDate != null ? objUser.DeathDate.ToString() : string.Empty;
            objModel.CurrentPlace = objUser.CurrentPlace;
            objModel.BirthPlace = objUser.BirthPlace;
            objModel.Status = objUser.Status;
            objModel.Mobile = objUser.Mobile;
            objModel.IsActived = objUser.IsActived;
            objModel.IsDeleted = objUser.IsDeleted;
            objModel.CreatedUserID = objUser.CreatedUserID;
            objModel.CreatedDate = objUser.CreatedDate;
            objModel.UpdatedUserID = objUser.UpdatedUserID;
            objModel.UpdatedDate = objUser.UpdatedDate;
            objModel.DeletedUserID = objUser.DeletedUserID;
            objModel.DeletedDate = objUser.DeletedDate;
            objModel.CurrentProvinceID = objUser.CurrentProvinceID;
            objModel.BirthProvinceID = objUser.BirthProvinceID;
            objModel.OrderPostion = objUser.OrderPostiion;
            return objModel;
        }
    }
}
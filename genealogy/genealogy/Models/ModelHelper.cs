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

        public MenuModels LoadModelsNewsCate(UIMenus objUIM)
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
    }
}
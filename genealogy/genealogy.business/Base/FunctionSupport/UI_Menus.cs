
#region Using

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using WebLibs;

#endregion
namespace genealogy.business.Base
{
    /// <summary>
    /// Created by 		: Nguyen Duc Hieu 
    /// Created date 	: 4/19/2013 
    /// Description 
    /// </summary>	
    public class UIMenus
    {

        #region Function Support
        public List<UIMenus> CMSGetListMenuParent()
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;

            List<UIMenus> lstMenu = new List<UIMenus>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("UI_Menus_GetParent");
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    UIMenus objUIMenus = new UIMenus();
                    if (!this.IsDBNull(reader["MenuID"])) objUIMenus.MenuID = Convert.ToInt32(reader["MenuID"]);
                    if (!this.IsDBNull(reader["MenuName"])) objUIMenus.MenuName = Convert.ToString(reader["MenuName"]);
                    if (!this.IsDBNull(reader["MenuDescription"])) objUIMenus.MenuDescription = Convert.ToString(reader["MenuDescription"]);
                    if (!this.IsDBNull(reader["MenuLink"])) objUIMenus.MenuLink = Convert.ToString(reader["MenuLink"]);
                    if (!this.IsDBNull(reader["IsActived"])) objUIMenus.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) objUIMenus.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) objUIMenus.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) objUIMenus.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) objUIMenus.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) objUIMenus.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) objUIMenus.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) objUIMenus.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    if (!this.IsDBNull(reader["ParentMenuID"])) objUIMenus.ParentMenuID = Convert.ToInt32(reader["ParentMenuID"]);
                    lstMenu.Add(objUIMenus);
                }
                reader.Close();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetAll() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
            }
            return lstMenu;
        }
        #endregion


        /******************************************************
            UI_Menus objUI_Menus = new UI_Menus();
            objUIMenus.MenuID = txtMenuID.Text;
            objUIMenus.MenuName = txtMenuName.Text;
            objUIMenus.MenuDescription = txtMenuDescription.Text;
            objUIMenus.MenuLink = txtMenuLink.Text;
            objUIMenus.IsActived = txtIsActived.Text;
            objUIMenus.IsDeleted = txtIsDeleted.Text;
            objUIMenus.CreatedUserID = txtCreatedUserID.Text;
            objUIMenus.CreatedDate = txtCreatedDate.Text;
            objUIMenus.UpdatedUserID = txtUpdatedUserID.Text;
            objUIMenus.UpdatedDate = txtUpdatedDate.Text;
            objUIMenus.DeletedUserID = txtDeletedUserID.Text;
            objUIMenus.DeletedDate = txtDeletedDate.Text;
            objUIMenus.ParentMenuID = txtParentMenuID.Text;

		 
         ******************************************************
		 
                    txtMenuID.Text = objUIMenus.MenuID;
            txtMenuName.Text = objUIMenus.MenuName;
            txtMenuDescription.Text = objUIMenus.MenuDescription;
            txtMenuLink.Text = objUIMenus.MenuLink;
            txtIsActived.Text = objUIMenus.IsActived;
            txtIsDeleted.Text = objUIMenus.IsDeleted;
            txtCreatedUserID.Text = objUIMenus.CreatedUserID;
            txtCreatedDate.Text = objUIMenus.CreatedDate;
            txtUpdatedUserID.Text = objUIMenus.UpdatedUserID;
            txtUpdatedDate.Text = objUIMenus.UpdatedDate;
            txtDeletedUserID.Text = objUIMenus.DeletedUserID;
            txtDeletedDate.Text = objUIMenus.DeletedDate;
            txtParentMenuID.Text = objUIMenus.ParentMenuID;

		 
        *******************************************************/

    }
}

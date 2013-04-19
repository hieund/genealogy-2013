
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



        #region Member Variables

        private int intMenuID = int.MinValue;
        private string strMenuName = string.Empty;
        private string strMenuDescription = string.Empty;
        private string strMenuLink = string.Empty;
        private bool bolIsActived;
        private bool bolIsDeleted;
        private int intCreatedUserID = int.MinValue;
        private DateTime dtmCreatedDate = DateTime.MinValue;
        private int intUpdatedUserID = int.MinValue;
        private DateTime dtmUpdatedDate = DateTime.MinValue;
        private int intDeletedUserID = int.MinValue;
        private DateTime dtmDeletedDate = DateTime.MinValue;
        private int intParentMenuID = int.MinValue;
        private IData objDataAccess = null;


        #endregion


        #region Properties

        public static string CacheKey
        {
            get { return "UIMenus_GetAll"; }
        }
        /// <summary>
        /// Đối tượng Data truyền từ ngoài vào
        /// </summary>
        public IData DataObject
        {
            get { return objDataAccess; }
            set { objDataAccess = value; }
        }
        /// <summary>
        /// MenuID
        /// 
        /// </summary>
        public int MenuID
        {
            get { return intMenuID; }
            set { intMenuID = value; }
        }

        /// <summary>
        /// MenuName
        /// 
        /// </summary>
        public string MenuName
        {
            get { return strMenuName; }
            set { strMenuName = value; }
        }

        /// <summary>
        /// MenuDescription
        /// 
        /// </summary>
        public string MenuDescription
        {
            get { return strMenuDescription; }
            set { strMenuDescription = value; }
        }

        /// <summary>
        /// MenuLink
        /// 
        /// </summary>
        public string MenuLink
        {
            get { return strMenuLink; }
            set { strMenuLink = value; }
        }

        /// <summary>
        /// IsActived
        /// 
        /// </summary>
        public bool IsActived
        {
            get { return bolIsActived; }
            set { bolIsActived = value; }
        }

        /// <summary>
        /// IsDeleted
        /// 
        /// </summary>
        public bool IsDeleted
        {
            get { return bolIsDeleted; }
            set { bolIsDeleted = value; }
        }

        /// <summary>
        /// CreatedUserID
        /// 
        /// </summary>
        public int CreatedUserID
        {
            get { return intCreatedUserID; }
            set { intCreatedUserID = value; }
        }

        /// <summary>
        /// CreatedDate
        /// 
        /// </summary>
        public DateTime CreatedDate
        {
            get { return dtmCreatedDate; }
            set { dtmCreatedDate = value; }
        }

        /// <summary>
        /// UpdatedUserID
        /// 
        /// </summary>
        public int UpdatedUserID
        {
            get { return intUpdatedUserID; }
            set { intUpdatedUserID = value; }
        }

        /// <summary>
        /// UpdatedDate
        /// 
        /// </summary>
        public DateTime UpdatedDate
        {
            get { return dtmUpdatedDate; }
            set { dtmUpdatedDate = value; }
        }

        /// <summary>
        /// DeletedUserID
        /// 
        /// </summary>
        public int DeletedUserID
        {
            get { return intDeletedUserID; }
            set { intDeletedUserID = value; }
        }

        /// <summary>
        /// DeletedDate
        /// 
        /// </summary>
        public DateTime DeletedDate
        {
            get { return dtmDeletedDate; }
            set { dtmDeletedDate = value; }
        }

        /// <summary>
        /// ParentMenuID
        /// 
        /// </summary>
        public int ParentMenuID
        {
            get { return intParentMenuID; }
            set { intParentMenuID = value; }
        }


        #endregion


        #region Constructor

        public UIMenus()
        {
        }
        private static UIMenus _current;
        static UIMenus()
        {
            _current = new UIMenus();
        }
        public static UIMenus Current
        {
            get
            {
                return _current;
            }
        }
        #endregion

        #region Methods



        ///<summary>
        /// Kiểm tra xem đối tượng có dữ liệu hay không
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool LoadByPrimaryKeys()
        {

            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;
            bool bolOK = false;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("UI_Menus_SEL");
                objData.AddParameter("@MenuID", this.MenuID);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (!this.IsDBNull(reader["MenuID"])) this.MenuID = Convert.ToInt32(reader["MenuID"]);
                    if (!this.IsDBNull(reader["MenuName"])) this.MenuName = Convert.ToString(reader["MenuName"]);
                    if (!this.IsDBNull(reader["MenuDescription"])) this.MenuDescription = Convert.ToString(reader["MenuDescription"]);
                    if (!this.IsDBNull(reader["MenuLink"])) this.MenuLink = Convert.ToString(reader["MenuLink"]);
                    if (!this.IsDBNull(reader["IsActived"])) this.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) this.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) this.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) this.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) this.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) this.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) this.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) this.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    if (!this.IsDBNull(reader["ParentMenuID"])) this.ParentMenuID = Convert.ToInt32(reader["ParentMenuID"]);
                    bolOK = true;
                }
                reader.Close();
            }
            catch (Exception objEx)
            {
                throw new Exception("LoadByPrimaryKeys() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
            }
            return bolOK;
        }

        ///<summary>
        /// Insert : UI_Menus
        /// Them moi du lieu
        ///</summary>
        public object Insert()
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;
            object objTemp = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("UI_Menus_ADD");
                //if(this.MenuID != int.MinValue) objData.AddParameter("@MenuID", this.MenuID);
                objData.AddParameter("@MenuName", this.MenuName);
                objData.AddParameter("@MenuDescription", this.MenuDescription);
                objData.AddParameter("@MenuLink", this.MenuLink);
                objData.AddParameter("@IsActived", this.IsActived);
                if (this.CreatedUserID != int.MinValue) objData.AddParameter("@CreatedUserID", this.CreatedUserID);
                //if(this.UpdatedUserID != int.MinValue) objData.AddParameter("@UpdatedUserID", this.UpdatedUserID);
                //if(this.DeletedUserID != int.MinValue) objData.AddParameter("@DeletedUserID", this.DeletedUserID);
                if (this.ParentMenuID != int.MinValue) objData.AddParameter("@ParentMenuID", this.ParentMenuID);
                objTemp = objData.ExecStoreToString();
            }
            catch (Exception objEx)
            {
                throw new Exception("Insert() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
            }
            return objTemp;
        }


        ///<summary>
        /// Update : UI_Menus
        /// Cap nhap thong tin
        ///</summary>
        public object Update()
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;
            object objTemp = null;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("UI_Menus_UPD");
                if (this.MenuID != int.MinValue) objData.AddParameter("@MenuID", this.MenuID);
                else objData.AddParameter("@MenuID", DBNull.Value);
                objData.AddParameter("@MenuName", this.MenuName);
                objData.AddParameter("@MenuDescription", this.MenuDescription);
                objData.AddParameter("@MenuLink", this.MenuLink);
                objData.AddParameter("@IsActived", this.IsActived);
                if (this.UpdatedUserID != int.MinValue) objData.AddParameter("@UpdatedUserID", this.UpdatedUserID);
                else objData.AddParameter("@UpdatedUserID", DBNull.Value);
                objTemp = objData.ExecNonQuery();
            }
            catch (Exception objEx)
            {
                throw new Exception("Update() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
            }
            return objTemp;
        }


        ///<summary>
        /// Delete : UI_Menus
        ///
        ///</summary>
        public int Delete()
        {

            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;
            int intTemp = 0;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("UI_Menus_DEL");
                objData.AddParameter("@MenuID", this.MenuID);
                intTemp = objData.ExecNonQuery();
            }
            catch (Exception objEx)
            {
                throw new Exception("Delete() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
            }
            return intTemp;
        }


        ///<summary>
        /// Get all : UI_Menus
        ///
        ///</summary>
        public DataTable GetAll()
        {

            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("UI_Menus_SRH");
                return objData.ExecStoreToDataTable();
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
        }
        #endregion

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

        /// <summary>
        /// Check Data IsDBNull 
        /// </summary>
        /// <param name="objObject"> Object Value</param>
        /// <returns>Null : true ? false </returns>
        private bool IsDBNull(object objObject)
        {
            return Convert.IsDBNull(objObject);
        }


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

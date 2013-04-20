
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
	/// Created date 	: 4/20/2013 
	/// Description 
	/// </summary>	
	public class GENDocumentDirectories
	{
	
		
	
		#region Member Variables

		private int intFolderID = int.MinValue;
		private string strFolderName = string.Empty;
		private int intFolderParentID = int.MinValue;
		private string strNodeTree = string.Empty;
		private bool bolIsActived;
		private bool bolIsDeleted;
		private int intCreatedUserID = int.MinValue;
		private DateTime dtmCreatedDate = DateTime.MinValue;
		private int intUpdatedUserID = int.MinValue;
		private DateTime dtmUpdatedDate = DateTime.MinValue;
		private int intDeletedUserID = int.MinValue;
		private DateTime dtmDeletedDate = DateTime.MinValue;
        private IData objDataAccess = null;
        //
        private string strDirectoryTree = string.Empty;


		#endregion


		#region Properties 

		public static string CacheKey
		{
  			get { return  "GENDocumentDirectories_GetAll";}
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
		/// FolderID
		/// 
		/// </summary>
		public int FolderID
		{
			get { return  intFolderID; }
			set { intFolderID = value; }
		}

		/// <summary>
		/// FolderName
		/// 
		/// </summary>
		public string FolderName
		{
			get { return  strFolderName; }
			set { strFolderName = value; }
		}

		/// <summary>
		/// FolderParentID
		/// 
		/// </summary>
		public int FolderParentID
		{
			get { return  intFolderParentID; }
			set { intFolderParentID = value; }
		}

		/// <summary>
		/// NodeTree
		/// 
		/// </summary>
		public string NodeTree
		{
			get { return  strNodeTree; }
			set { strNodeTree = value; }
		}

		/// <summary>
		/// IsActived
		/// 
		/// </summary>
		public bool IsActived
		{
			get { return  bolIsActived; }
			set { bolIsActived = value; }
		}

		/// <summary>
		/// IsDeleted
		/// 
		/// </summary>
		public bool IsDeleted
		{
			get { return  bolIsDeleted; }
			set { bolIsDeleted = value; }
		}

		/// <summary>
		/// CreatedUserID
		/// 
		/// </summary>
		public int CreatedUserID
		{
			get { return  intCreatedUserID; }
			set { intCreatedUserID = value; }
		}

		/// <summary>
		/// CreatedDate
		/// 
		/// </summary>
		public DateTime CreatedDate
		{
			get { return  dtmCreatedDate; }
			set { dtmCreatedDate = value; }
		}

		/// <summary>
		/// UpdatedUserID
		/// 
		/// </summary>
		public int UpdatedUserID
		{
			get { return  intUpdatedUserID; }
			set { intUpdatedUserID = value; }
		}

		/// <summary>
		/// UpdatedDate
		/// 
		/// </summary>
		public DateTime UpdatedDate
		{
			get { return  dtmUpdatedDate; }
			set { dtmUpdatedDate = value; }
		}

		/// <summary>
		/// DeletedUserID
		/// 
		/// </summary>
		public int DeletedUserID
		{
			get { return  intDeletedUserID; }
			set { intDeletedUserID = value; }
		}

		/// <summary>
		/// DeletedDate
		/// 
		/// </summary>
		public DateTime DeletedDate
		{
			get { return  dtmDeletedDate; }
			set { dtmDeletedDate = value; }
		}

        /// <summary>
        /// DirectoryTree
        /// Add
        /// </summary>
        public string DirectoryTree
        {
            get { return strDirectoryTree; }
            set { strDirectoryTree = value; }
        }

		#endregion		
		
		
		#region Constructor

		public GENDocumentDirectories()
		{
		}
		private static GENDocumentDirectories _current;
		static GENDocumentDirectories()
		{
			_current = new GENDocumentDirectories();
		}
		public static GENDocumentDirectories Current
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
				objData.CreateNewStoredProcedure("GEN_Document_Directories_SEL");
				objData.AddParameter("@FolderID", this.FolderID);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["FolderID"]))	this.FolderID = Convert.ToInt32(reader["FolderID"]);
					if(!this.IsDBNull(reader["FolderName"]))	this.FolderName = Convert.ToString(reader["FolderName"]);
					if(!this.IsDBNull(reader["FolderParentID"]))	this.FolderParentID = Convert.ToInt32(reader["FolderParentID"]);
					if(!this.IsDBNull(reader["NodeTree"]))	this.NodeTree = Convert.ToString(reader["NodeTree"]);
					if(!this.IsDBNull(reader["IsActived"]))	this.IsActived = Convert.ToBoolean(reader["IsActived"]);
					if(!this.IsDBNull(reader["IsDeleted"]))	this.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
					if(!this.IsDBNull(reader["CreatedUserID"]))	this.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
					if(!this.IsDBNull(reader["CreatedDate"]))	this.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
					if(!this.IsDBNull(reader["UpdatedUserID"]))	this.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
					if(!this.IsDBNull(reader["UpdatedDate"]))	this.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
					if(!this.IsDBNull(reader["DeletedUserID"]))	this.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
					if(!this.IsDBNull(reader["DeletedDate"]))	this.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
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
		/// Insert : GEN_Document_Directories
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
				objData.CreateNewStoredProcedure("GEN_Document_Directories_ADD");
				if(this.FolderID != int.MinValue) objData.AddParameter("@FolderID", this.FolderID);
				objData.AddParameter("@FolderName", this.FolderName);
				if(this.FolderParentID != int.MinValue) objData.AddParameter("@FolderParentID", this.FolderParentID);
				objData.AddParameter("@IsActived", this.IsActived);
				if(this.CreatedUserID != int.MinValue) objData.AddParameter("@CreatedUserID", this.CreatedUserID);
                objTemp = objData.ExecStoreToDataTable().Rows[0][0];
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
		/// Update : GEN_Document_Directories
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
				objData.CreateNewStoredProcedure("GEN_Document_Directories_UPD");
				if(this.FolderID != int.MinValue)	objData.AddParameter("@FolderID", this.FolderID);
				else objData.AddParameter("@FolderID", DBNull.Value);
				objData.AddParameter("@FolderName", this.FolderName);
				if(this.FolderParentID != int.MinValue)	objData.AddParameter("@FolderParentID", this.FolderParentID);
				else objData.AddParameter("@FolderParentID", DBNull.Value);
				objData.AddParameter("@NodeTree", this.NodeTree);
				objData.AddParameter("@IsActived", this.IsActived);
				if(this.UpdatedUserID != int.MinValue)	objData.AddParameter("@UpdatedUserID", this.UpdatedUserID);
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
		/// Delete : GEN_Document_Directories
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
				objData.CreateNewStoredProcedure("GEN_Document_Directories_DEL");
				objData.AddParameter("@FolderID", this.FolderID);
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
		/// Get all : GEN_Document_Directories
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
				objData.CreateNewStoredProcedure("GEN_Document_Directories_SRH");
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
		 	GEN_Document_Directories objGEN_Document_Directories = new GEN_Document_Directories();
			objGENDocumentDirectories.FolderID = txtFolderID.Text;
			objGENDocumentDirectories.FolderName = txtFolderName.Text;
			objGENDocumentDirectories.FolderParentID = txtFolderParentID.Text;
			objGENDocumentDirectories.NodeTree = txtNodeTree.Text;
			objGENDocumentDirectories.IsActived = txtIsActived.Text;
			objGENDocumentDirectories.IsDeleted = txtIsDeleted.Text;
			objGENDocumentDirectories.CreatedUserID = txtCreatedUserID.Text;
			objGENDocumentDirectories.CreatedDate = txtCreatedDate.Text;
			objGENDocumentDirectories.UpdatedUserID = txtUpdatedUserID.Text;
			objGENDocumentDirectories.UpdatedDate = txtUpdatedDate.Text;
			objGENDocumentDirectories.DeletedUserID = txtDeletedUserID.Text;
			objGENDocumentDirectories.DeletedDate = txtDeletedDate.Text;

		 
		 ******************************************************
		 
		 			txtFolderID.Text = objGENDocumentDirectories.FolderID;
			txtFolderName.Text = objGENDocumentDirectories.FolderName;
			txtFolderParentID.Text = objGENDocumentDirectories.FolderParentID;
			txtNodeTree.Text = objGENDocumentDirectories.NodeTree;
			txtIsActived.Text = objGENDocumentDirectories.IsActived;
			txtIsDeleted.Text = objGENDocumentDirectories.IsDeleted;
			txtCreatedUserID.Text = objGENDocumentDirectories.CreatedUserID;
			txtCreatedDate.Text = objGENDocumentDirectories.CreatedDate;
			txtUpdatedUserID.Text = objGENDocumentDirectories.UpdatedUserID;
			txtUpdatedDate.Text = objGENDocumentDirectories.UpdatedDate;
			txtDeletedUserID.Text = objGENDocumentDirectories.DeletedUserID;
			txtDeletedDate.Text = objGENDocumentDirectories.DeletedDate;

		 
		*******************************************************/

        #region Function Support

        /// <summary>
        /// Lay danh menu cha
        /// </summary>
        /// <returns></returns>
        public List<GENDocumentDirectories> Search(string strkeyword, int intPageSize, int intPageIndex, ref int intTotalCount)
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;
            List<GENDocumentDirectories> lst = new List<GENDocumentDirectories>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("GEN_Document_Directories_SRH");
                objData.AddParameter("@KeyWord", strkeyword);
                objData.AddParameter("@PageSize", intPageSize);
                objData.AddParameter("@PageIndex", intPageIndex);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    GENDocumentDirectories objDD = new GENDocumentDirectories();
                    if (!this.IsDBNull(reader["TotalCount"])) intTotalCount = Convert.ToInt32(reader["TotalCount"]);

                    if (!this.IsDBNull(reader["FolderID"])) objDD.FolderID = Convert.ToInt32(reader["FolderID"]);
                    if (!this.IsDBNull(reader["FolderName"])) objDD.FolderName = Convert.ToString(reader["FolderName"]);
                    if (!this.IsDBNull(reader["FolderParentID"])) objDD.FolderParentID = Convert.ToInt32(reader["FolderParentID"]);
                    if (!this.IsDBNull(reader["IsActived"])) objDD.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) objDD.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) objDD.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) objDD.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) objDD.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) objDD.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) objDD.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) objDD.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    lst.Add(objDD);
                }
                reader.Close();
            }
            catch (Exception objEx)
            {
                new SystemMessage("Search() Error", "", objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
            }
            return lst;
        }

        public List<GENDocumentDirectories> CMSGetDocumentDirectoryTree()
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;

            List<GENDocumentDirectories> lstMenu = new List<GENDocumentDirectories>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("GEN_Document_Directories_GetTree");
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    GENDocumentDirectories objGENDocumentDirectories = new GENDocumentDirectories();
                    if (!this.IsDBNull(reader["FolderID"])) objGENDocumentDirectories.FolderID = Convert.ToInt32(reader["FolderID"]);
                    if (!this.IsDBNull(reader["FolderName"])) objGENDocumentDirectories.FolderName = Convert.ToString(reader["FolderName"]);
                    if (!this.IsDBNull(reader["FolderParentID"])) objGENDocumentDirectories.FolderParentID = Convert.ToInt32(reader["FolderParentID"]);
                    if (!this.IsDBNull(reader["NodeTree"])) objGENDocumentDirectories.NodeTree = Convert.ToString(reader["NodeTree"]);
                    if (!this.IsDBNull(reader["DirectoryTree"])) objGENDocumentDirectories.DirectoryTree = Convert.ToString(reader["DirectoryTree"]);
                    if (!this.IsDBNull(reader["IsActived"])) objGENDocumentDirectories.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) objGENDocumentDirectories.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) objGENDocumentDirectories.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) objGENDocumentDirectories.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) objGENDocumentDirectories.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) objGENDocumentDirectories.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) objGENDocumentDirectories.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) objGENDocumentDirectories.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    lstMenu.Add(objGENDocumentDirectories);
                }
                reader.Close();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetDirectoryTree() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
            }
            return lstMenu;
        }
        #endregion

	}
}

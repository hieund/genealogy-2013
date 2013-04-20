
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
	public class GENDocuments
	{
	
		
	
		#region Member Variables

		private int intDocumentID = int.MinValue;
		private string strDocumentTitle = string.Empty;
		private string strDocumentFileName = string.Empty;
		private bool bolIsActived;
		private bool bolIsDeleted;
		private int intCreatedUserID = int.MinValue;
		private DateTime dtmCreatedDate = DateTime.MinValue;
		private int intUpdatedUserID = int.MinValue;
		private DateTime dtmUpdatedDate = DateTime.MinValue;
		private int intDeletedUserID = int.MinValue;
		private DateTime dtmDeletedDate = DateTime.MinValue;
		private int intFolderID = int.MinValue;
		private string strDocumentTitlesrh = string.Empty;
		private string strDocumentFileNamesrh = string.Empty;
		private IData objDataAccess = null;


		#endregion


		#region Properties 

		public static string CacheKey
		{
  			get { return  "GENDocuments_GetAll";}
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
		/// DocumentID
		/// 
		/// </summary>
		public int DocumentID
		{
			get { return  intDocumentID; }
			set { intDocumentID = value; }
		}

		/// <summary>
		/// DocumentTitle
		/// 
		/// </summary>
		public string DocumentTitle
		{
			get { return  strDocumentTitle; }
			set { strDocumentTitle = value; }
		}

		/// <summary>
		/// DocumentFileName
		/// 
		/// </summary>
		public string DocumentFileName
		{
			get { return  strDocumentFileName; }
			set { strDocumentFileName = value; }
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
		/// FolderID
		/// 
		/// </summary>
		public int FolderID
		{
			get { return  intFolderID; }
			set { intFolderID = value; }
		}

		/// <summary>
		/// DocumentTitlesrh
		/// 
		/// </summary>
		public string DocumentTitlesrh
		{
			get { return  strDocumentTitlesrh; }
			set { strDocumentTitlesrh = value; }
		}

		/// <summary>
		/// DocumentFileNamesrh
		/// 
		/// </summary>
		public string DocumentFileNamesrh
		{
			get { return  strDocumentFileNamesrh; }
			set { strDocumentFileNamesrh = value; }
		}


		#endregion		
		
		
		#region Constructor

		public GENDocuments()
		{
		}
		private static GENDocuments _current;
		static GENDocuments()
		{
			_current = new GENDocuments();
		}
		public static GENDocuments Current
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
				objData.CreateNewStoredProcedure("GEN_Documents_SEL");
				objData.AddParameter("@DocumentID", this.DocumentID);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["DocumentID"]))	this.DocumentID = Convert.ToInt32(reader["DocumentID"]);
					if(!this.IsDBNull(reader["DocumentTitle"]))	this.DocumentTitle = Convert.ToString(reader["DocumentTitle"]);
					if(!this.IsDBNull(reader["DocumentFileName"]))	this.DocumentFileName = Convert.ToString(reader["DocumentFileName"]);
					if(!this.IsDBNull(reader["IsActived"]))	this.IsActived = Convert.ToBoolean(reader["IsActived"]);
					if(!this.IsDBNull(reader["IsDeleted"]))	this.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
					if(!this.IsDBNull(reader["CreatedUserID"]))	this.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
					if(!this.IsDBNull(reader["CreatedDate"]))	this.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
					if(!this.IsDBNull(reader["UpdatedUserID"]))	this.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
					if(!this.IsDBNull(reader["UpdatedDate"]))	this.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
					if(!this.IsDBNull(reader["DeletedUserID"]))	this.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
					if(!this.IsDBNull(reader["DeletedDate"]))	this.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
					if(!this.IsDBNull(reader["FolderID"]))	this.FolderID = Convert.ToInt32(reader["FolderID"]);
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
		/// Insert : GEN_Documents
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
				objData.CreateNewStoredProcedure("GEN_Documents_ADD");
				if(this.DocumentID != int.MinValue) objData.AddParameter("@DocumentID", this.DocumentID);
				objData.AddParameter("@DocumentTitle", this.DocumentTitle);
				objData.AddParameter("@DocumentFileName", this.DocumentFileName);
				objData.AddParameter("@IsActived", this.IsActived);
				if(this.CreatedUserID != int.MinValue) objData.AddParameter("@CreatedUserID", this.CreatedUserID);
				if(this.FolderID != int.MinValue) objData.AddParameter("@FolderID", this.FolderID);
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
		/// Update : GEN_Documents
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
				objData.CreateNewStoredProcedure("GEN_Documents_UPD");
				if(this.DocumentID != int.MinValue)	objData.AddParameter("@DocumentID", this.DocumentID);
				else objData.AddParameter("@DocumentID", DBNull.Value);
				objData.AddParameter("@DocumentTitle", this.DocumentTitle);
				objData.AddParameter("@DocumentFileName", this.DocumentFileName);
				objData.AddParameter("@IsActived", this.IsActived);
				if(this.CreatedUserID != int.MinValue)	objData.AddParameter("@CreatedUserID", this.CreatedUserID);
				else objData.AddParameter("@CreatedUserID", DBNull.Value);
				if(this.FolderID != int.MinValue)	objData.AddParameter("@FolderID", this.FolderID);
				else objData.AddParameter("@FolderID", DBNull.Value);
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
		/// Delete : GEN_Documents
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
				objData.CreateNewStoredProcedure("GEN_Documents_DEL");
				objData.AddParameter("@DocumentID", this.DocumentID);
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
		/// Get all : GEN_Documents
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
				objData.CreateNewStoredProcedure("GEN_Documents_SRH");
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
            GEN_Documents objGEN_Documents = new GEN_Documents();
            objGENDocuments.DocumentID = txtDocumentID.Text;
            objGENDocuments.DocumentTitle = txtDocumentTitle.Text;
            objGENDocuments.DocumentFileName = txtDocumentFileName.Text;
            objGENDocuments.IsActived = txtIsActived.Text;
            objGENDocuments.IsDeleted = txtIsDeleted.Text;
            objGENDocuments.CreatedUserID = txtCreatedUserID.Text;
            objGENDocuments.CreatedDate = txtCreatedDate.Text;
            objGENDocuments.UpdatedUserID = txtUpdatedUserID.Text;
            objGENDocuments.UpdatedDate = txtUpdatedDate.Text;
            objGENDocuments.DeletedUserID = txtDeletedUserID.Text;
            objGENDocuments.DeletedDate = txtDeletedDate.Text;
            objGENDocuments.FolderID = txtFolderID.Text;
            objGENDocuments.DocumentTitlesrh = txtDocumentTitlesrh.Text;
            objGENDocuments.DocumentFileNamesrh = txtDocumentFileNamesrh.Text;

		 
         ******************************************************
		 
                    txtDocumentID.Text = objGENDocuments.DocumentID;
            txtDocumentTitle.Text = objGENDocuments.DocumentTitle;
            txtDocumentFileName.Text = objGENDocuments.DocumentFileName;
            txtIsActived.Text = objGENDocuments.IsActived;
            txtIsDeleted.Text = objGENDocuments.IsDeleted;
            txtCreatedUserID.Text = objGENDocuments.CreatedUserID;
            txtCreatedDate.Text = objGENDocuments.CreatedDate;
            txtUpdatedUserID.Text = objGENDocuments.UpdatedUserID;
            txtUpdatedDate.Text = objGENDocuments.UpdatedDate;
            txtDeletedUserID.Text = objGENDocuments.DeletedUserID;
            txtDeletedDate.Text = objGENDocuments.DeletedDate;
            txtFolderID.Text = objGENDocuments.FolderID;
            txtDocumentTitlesrh.Text = objGENDocuments.DocumentTitlesrh;
            txtDocumentFileNamesrh.Text = objGENDocuments.DocumentFileNamesrh;

		 
        *******************************************************/

        #region Function Support
        public List<GENDocuments> Search(string strkeyword, int intPageSize, int intPageIndex, ref int intTotalCount)
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;
            List<GENDocuments> lst = new List<GENDocuments>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("GEN_Documents_SRH");
                objData.AddParameter("@KeyWord", strkeyword);
                objData.AddParameter("@PageSize", intPageSize);
                objData.AddParameter("@PageIndex", intPageIndex);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    GENDocuments objGD = new GENDocuments();
                    if (!this.IsDBNull(reader["TotalCount"])) intTotalCount = Convert.ToInt32(reader["TotalCount"]);

                    if (!this.IsDBNull(reader["DocumentID"])) objGD.DocumentID = Convert.ToInt32(reader["DocumentID"]);
                    if (!this.IsDBNull(reader["DocumentTitle"])) objGD.DocumentTitle = Convert.ToString(reader["DocumentTitle"]);
                    if (!this.IsDBNull(reader["DocumentFileName"])) objGD.DocumentFileName = Convert.ToString(reader["DocumentFileName"]);
                    if (!this.IsDBNull(reader["IsActived"])) objGD.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) objGD.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) objGD.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) objGD.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) objGD.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) objGD.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) objGD.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) objGD.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    if (!this.IsDBNull(reader["FolderID"])) objGD.FolderID = Convert.ToInt32(reader["FolderID"]);
                    lst.Add(objGD);
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
        #endregion
    }
}

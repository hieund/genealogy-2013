
#region Using

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using WebLibs;

#endregion
namespace genealogy.business
{
    /// <summary>
	/// Created by 		: Nguyen Duc Hieu 
	/// Created date 	: 4/19/2013 
	/// Description 
	/// </summary>	
	public class SystemErrorLog
	{
	
		
	
		#region Member Variables

		private int intErrorID = int.MinValue;
		private int intErrorTypeID = int.MinValue;
		private string strErrorCaption = string.Empty;
		private string strErrorContent = string.Empty;
		private string strIPError = string.Empty;
		private string strActionError = string.Empty;
		private string strModuleName = string.Empty;
		private bool bolIsFix;
		private string strCreatedUser = string.Empty;
		private DateTime dtmCreatedDate = DateTime.MinValue;
		private string strUpdatedUser = string.Empty;
		private DateTime dtmUpdatedDate = DateTime.MinValue;
		private string strDeletedUser = string.Empty;
		private DateTime dtmDeletedDate = DateTime.MinValue;
		private bool bolIsDeleted;
		private IData objDataAccess = null;


		#endregion


		#region Properties 

		public static string CacheKey
		{
  			get { return  "SystemErrorLog_GetAll";}
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
		/// ErrorID
		/// 
		/// </summary>
		public int ErrorID
		{
			get { return  intErrorID; }
			set { intErrorID = value; }
		}

		/// <summary>
		/// ErrorTypeID
		/// Loại lỗi
		/// </summary>
		public int ErrorTypeID
		{
			get { return  intErrorTypeID; }
			set { intErrorTypeID = value; }
		}

		/// <summary>
		/// ErrorCaption
		/// Tiêu đề lỗi
		/// </summary>
		public string ErrorCaption
		{
			get { return  strErrorCaption; }
			set { strErrorCaption = value; }
		}

		/// <summary>
		/// ErrorContent
		/// Nội dung lỗi
		/// </summary>
		public string ErrorContent
		{
			get { return  strErrorContent; }
			set { strErrorContent = value; }
		}

		/// <summary>
		/// IPError
		/// IP của máy gây ra lỗi
		/// </summary>
		public string IPError
		{
			get { return  strIPError; }
			set { strIPError = value; }
		}

		/// <summary>
		/// ActionError
		/// Thao tác gây lỗi
		/// </summary>
		public string ActionError
		{
			get { return  strActionError; }
			set { strActionError = value; }
		}

		/// <summary>
		/// ModuleName
		/// Tên Module gây lỗi
		/// </summary>
		public string ModuleName
		{
			get { return  strModuleName; }
			set { strModuleName = value; }
		}

		/// <summary>
		/// IsFix
		/// =0; chưa Fix ; =1 Đã Fix
		/// </summary>
		public bool IsFix
		{
			get { return  bolIsFix; }
			set { bolIsFix = value; }
		}

		/// <summary>
		/// CreatedUser
		/// 
		/// </summary>
		public string CreatedUser
		{
			get { return  strCreatedUser; }
			set { strCreatedUser = value; }
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
		/// UpdatedUser
		/// 
		/// </summary>
		public string UpdatedUser
		{
			get { return  strUpdatedUser; }
			set { strUpdatedUser = value; }
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
		/// DeletedUser
		/// 
		/// </summary>
		public string DeletedUser
		{
			get { return  strDeletedUser; }
			set { strDeletedUser = value; }
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
		/// IsDeleted
		/// 
		/// </summary>
		public bool IsDeleted
		{
			get { return  bolIsDeleted; }
			set { bolIsDeleted = value; }
		}


		#endregion		
		
		
		#region Constructor

		public SystemErrorLog()
		{
		}
		private static SystemErrorLog _current;
		static SystemErrorLog()
		{
			_current = new SystemErrorLog();
		}
		public static SystemErrorLog Current
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
				objData.CreateNewStoredProcedure("System_ErrorLog_SEL");
				objData.AddParameter("@ErrorID", this.ErrorID);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["ErrorID"]))	this.ErrorID = Convert.ToInt32(reader["ErrorID"]);
					if(!this.IsDBNull(reader["ErrorTypeID"]))	this.ErrorTypeID = Convert.ToInt32(reader["ErrorTypeID"]);
					if(!this.IsDBNull(reader["ErrorCaption"]))	this.ErrorCaption = Convert.ToString(reader["ErrorCaption"]);
					if(!this.IsDBNull(reader["ErrorContent"]))	this.ErrorContent = Convert.ToString(reader["ErrorContent"]);
					if(!this.IsDBNull(reader["IPError"]))	this.IPError = Convert.ToString(reader["IPError"]);
					if(!this.IsDBNull(reader["ActionError"]))	this.ActionError = Convert.ToString(reader["ActionError"]);
					if(!this.IsDBNull(reader["ModuleName"]))	this.ModuleName = Convert.ToString(reader["ModuleName"]);
					if(!this.IsDBNull(reader["IsFix"]))	this.IsFix = Convert.ToBoolean(reader["IsFix"]);
					if(!this.IsDBNull(reader["CreatedUser"]))	this.CreatedUser = Convert.ToString(reader["CreatedUser"]);
					if(!this.IsDBNull(reader["CreatedDate"]))	this.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
					if(!this.IsDBNull(reader["UpdatedUser"]))	this.UpdatedUser = Convert.ToString(reader["UpdatedUser"]);
					if(!this.IsDBNull(reader["UpdatedDate"]))	this.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
					if(!this.IsDBNull(reader["DeletedUser"]))	this.DeletedUser = Convert.ToString(reader["DeletedUser"]);
					if(!this.IsDBNull(reader["DeletedDate"]))	this.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
					if(!this.IsDBNull(reader["IsDeleted"]))	this.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
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
		/// Insert : System_ErrorLog
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
				objData.CreateNewStoredProcedure("System_ErrorLog_ADD");
				if(this.ErrorID != int.MinValue) objData.AddParameter("@ErrorID", this.ErrorID);
				if(this.ErrorTypeID != int.MinValue) objData.AddParameter("@ErrorTypeID", this.ErrorTypeID);
				objData.AddParameter("@ErrorCaption", this.ErrorCaption);
				objData.AddParameter("@ErrorContent", this.ErrorContent);
				objData.AddParameter("@IPError", this.IPError);
				objData.AddParameter("@ActionError", this.ActionError);
				objData.AddParameter("@ModuleName", this.ModuleName);
				objData.AddParameter("@IsFix", this.IsFix);
				objData.AddParameter("@CreatedUser", this.CreatedUser);
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
		/// Update : System_ErrorLog
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
				objData.CreateNewStoredProcedure("System_ErrorLog_UPD");
				if(this.ErrorID != int.MinValue)	objData.AddParameter("@ErrorID", this.ErrorID);
				else objData.AddParameter("@ErrorID", DBNull.Value);
				if(this.ErrorTypeID != int.MinValue)	objData.AddParameter("@ErrorTypeID", this.ErrorTypeID);
				else objData.AddParameter("@ErrorTypeID", DBNull.Value);
				objData.AddParameter("@ErrorCaption", this.ErrorCaption);
				objData.AddParameter("@ErrorContent", this.ErrorContent);
				objData.AddParameter("@IPError", this.IPError);
				objData.AddParameter("@ActionError", this.ActionError);
				objData.AddParameter("@ModuleName", this.ModuleName);
				objData.AddParameter("@IsFix", this.IsFix);
				objData.AddParameter("@UpdatedUser", this.UpdatedUser);
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
		/// Delete : System_ErrorLog
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
				objData.CreateNewStoredProcedure("System_ErrorLog_DEL");
				objData.AddParameter("@ErrorID", this.ErrorID);
				objData.AddParameter("@DeletedUser", this.DeletedUser);
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
		/// Get all : System_ErrorLog
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
				objData.CreateNewStoredProcedure("System_ErrorLog_SRH");
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
		 	System_ErrorLog objSystem_ErrorLog = new System_ErrorLog();
			objSystemErrorLog.ErrorID = txtErrorID.Text;
			objSystemErrorLog.ErrorTypeID = txtErrorTypeID.Text;
			objSystemErrorLog.ErrorCaption = txtErrorCaption.Text;
			objSystemErrorLog.ErrorContent = txtErrorContent.Text;
			objSystemErrorLog.IPError = txtIPError.Text;
			objSystemErrorLog.ActionError = txtActionError.Text;
			objSystemErrorLog.ModuleName = txtModuleName.Text;
			objSystemErrorLog.IsFix = txtIsFix.Text;
			objSystemErrorLog.CreatedUser = txtCreatedUser.Text;
			objSystemErrorLog.CreatedDate = txtCreatedDate.Text;
			objSystemErrorLog.UpdatedUser = txtUpdatedUser.Text;
			objSystemErrorLog.UpdatedDate = txtUpdatedDate.Text;
			objSystemErrorLog.DeletedUser = txtDeletedUser.Text;
			objSystemErrorLog.DeletedDate = txtDeletedDate.Text;
			objSystemErrorLog.IsDeleted = txtIsDeleted.Text;

		 
		 ******************************************************
		 
		 			txtErrorID.Text = objSystemErrorLog.ErrorID;
			txtErrorTypeID.Text = objSystemErrorLog.ErrorTypeID;
			txtErrorCaption.Text = objSystemErrorLog.ErrorCaption;
			txtErrorContent.Text = objSystemErrorLog.ErrorContent;
			txtIPError.Text = objSystemErrorLog.IPError;
			txtActionError.Text = objSystemErrorLog.ActionError;
			txtModuleName.Text = objSystemErrorLog.ModuleName;
			txtIsFix.Text = objSystemErrorLog.IsFix;
			txtCreatedUser.Text = objSystemErrorLog.CreatedUser;
			txtCreatedDate.Text = objSystemErrorLog.CreatedDate;
			txtUpdatedUser.Text = objSystemErrorLog.UpdatedUser;
			txtUpdatedDate.Text = objSystemErrorLog.UpdatedDate;
			txtDeletedUser.Text = objSystemErrorLog.DeletedUser;
			txtDeletedDate.Text = objSystemErrorLog.DeletedDate;
			txtIsDeleted.Text = objSystemErrorLog.IsDeleted;

		 
		*******************************************************/
		
	}
}

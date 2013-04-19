
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
	public class SystemErrorType
	{
	
		
	
		#region Member Variables

		private int intErrorTypeID = int.MinValue;
		private string strErrorTypeName = string.Empty;
		private string strDescription = string.Empty;
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
  			get { return  "SystemErrorType_GetAll";}
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
		/// ErrorTypeID
		/// 
		/// </summary>
		public int ErrorTypeID
		{
			get { return  intErrorTypeID; }
			set { intErrorTypeID = value; }
		}

		/// <summary>
		/// ErrorTypeName
		/// 
		/// </summary>
		public string ErrorTypeName
		{
			get { return  strErrorTypeName; }
			set { strErrorTypeName = value; }
		}

		/// <summary>
		/// Description
		/// 
		/// </summary>
		public string Description
		{
			get { return  strDescription; }
			set { strDescription = value; }
		}

		/// <summary>
		/// CreatedUser
		/// Người tạo
		/// </summary>
		public string CreatedUser
		{
			get { return  strCreatedUser; }
			set { strCreatedUser = value; }
		}

		/// <summary>
		/// CreatedDate
		/// Ngày tạo
		/// </summary>
		public DateTime CreatedDate
		{
			get { return  dtmCreatedDate; }
			set { dtmCreatedDate = value; }
		}

		/// <summary>
		/// UpdatedUser
		/// Người chỉnh sửa
		/// </summary>
		public string UpdatedUser
		{
			get { return  strUpdatedUser; }
			set { strUpdatedUser = value; }
		}

		/// <summary>
		/// UpdatedDate
		/// Ngày chỉnh sửa
		/// </summary>
		public DateTime UpdatedDate
		{
			get { return  dtmUpdatedDate; }
			set { dtmUpdatedDate = value; }
		}

		/// <summary>
		/// DeletedUser
		/// Người xoá
		/// </summary>
		public string DeletedUser
		{
			get { return  strDeletedUser; }
			set { strDeletedUser = value; }
		}

		/// <summary>
		/// DeletedDate
		/// Ngày xoá
		/// </summary>
		public DateTime DeletedDate
		{
			get { return  dtmDeletedDate; }
			set { dtmDeletedDate = value; }
		}

		/// <summary>
		/// IsDeleted
		/// Đánh dấu xoá
		/// </summary>
		public bool IsDeleted
		{
			get { return  bolIsDeleted; }
			set { bolIsDeleted = value; }
		}


		#endregion		
		
		
		#region Constructor

		public SystemErrorType()
		{
		}
		private static SystemErrorType _current;
		static SystemErrorType()
		{
			_current = new SystemErrorType();
		}
		public static SystemErrorType Current
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
				objData.CreateNewStoredProcedure("System_ErrorType_SEL");
				objData.AddParameter("@ErrorTypeID", this.ErrorTypeID);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["ErrorTypeID"]))	this.ErrorTypeID = Convert.ToInt32(reader["ErrorTypeID"]);
					if(!this.IsDBNull(reader["ErrorTypeName"]))	this.ErrorTypeName = Convert.ToString(reader["ErrorTypeName"]);
					if(!this.IsDBNull(reader["Description"]))	this.Description = Convert.ToString(reader["Description"]);
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
		/// Insert : System_ErrorType
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
				objData.CreateNewStoredProcedure("System_ErrorType_ADD");
				if(this.ErrorTypeID != int.MinValue) objData.AddParameter("@ErrorTypeID", this.ErrorTypeID);
				objData.AddParameter("@ErrorTypeName", this.ErrorTypeName);
				objData.AddParameter("@Description", this.Description);
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
		/// Update : System_ErrorType
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
				objData.CreateNewStoredProcedure("System_ErrorType_UPD");
				if(this.ErrorTypeID != int.MinValue)	objData.AddParameter("@ErrorTypeID", this.ErrorTypeID);
				else objData.AddParameter("@ErrorTypeID", DBNull.Value);
				objData.AddParameter("@ErrorTypeName", this.ErrorTypeName);
				objData.AddParameter("@Description", this.Description);
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
		/// Delete : System_ErrorType
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
				objData.CreateNewStoredProcedure("System_ErrorType_DEL");
				objData.AddParameter("@ErrorTypeID", this.ErrorTypeID);
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
		/// Get all : System_ErrorType
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
				objData.CreateNewStoredProcedure("System_ErrorType_SRH");
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
		 	System_ErrorType objSystem_ErrorType = new System_ErrorType();
			objSystemErrorType.ErrorTypeID = txtErrorTypeID.Text;
			objSystemErrorType.ErrorTypeName = txtErrorTypeName.Text;
			objSystemErrorType.Description = txtDescription.Text;
			objSystemErrorType.CreatedUser = txtCreatedUser.Text;
			objSystemErrorType.CreatedDate = txtCreatedDate.Text;
			objSystemErrorType.UpdatedUser = txtUpdatedUser.Text;
			objSystemErrorType.UpdatedDate = txtUpdatedDate.Text;
			objSystemErrorType.DeletedUser = txtDeletedUser.Text;
			objSystemErrorType.DeletedDate = txtDeletedDate.Text;
			objSystemErrorType.IsDeleted = txtIsDeleted.Text;

		 
		 ******************************************************
		 
		 			txtErrorTypeID.Text = objSystemErrorType.ErrorTypeID;
			txtErrorTypeName.Text = objSystemErrorType.ErrorTypeName;
			txtDescription.Text = objSystemErrorType.Description;
			txtCreatedUser.Text = objSystemErrorType.CreatedUser;
			txtCreatedDate.Text = objSystemErrorType.CreatedDate;
			txtUpdatedUser.Text = objSystemErrorType.UpdatedUser;
			txtUpdatedDate.Text = objSystemErrorType.UpdatedDate;
			txtDeletedUser.Text = objSystemErrorType.DeletedUser;
			txtDeletedDate.Text = objSystemErrorType.DeletedDate;
			txtIsDeleted.Text = objSystemErrorType.IsDeleted;

		 
		*******************************************************/
		
	}
}

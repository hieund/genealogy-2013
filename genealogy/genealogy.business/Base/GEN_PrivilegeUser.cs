
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
	/// Created by 		: Nguyễn Đức Hiếu 
	/// Created date 	: 6/1/2013 
	/// Description 
	/// </summary>	
	public class GENPrivilegeUser
	{
	
		
	
		#region Member Variables

		private int intPrivilegeID = int.MinValue;
		private int intUserID = int.MinValue;
		private IData objDataAccess = null;


		#endregion


		#region Properties 

		public static string CacheKey
		{
  			get { return  "GENPrivilegeUser_GetAll";}
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
		/// PrivilegeID
		/// 
		/// </summary>
		public int PrivilegeID
		{
			get { return  intPrivilegeID; }
			set { intPrivilegeID = value; }
		}

		/// <summary>
		/// UserID
		/// 
		/// </summary>
		public int UserID
		{
			get { return  intUserID; }
			set { intUserID = value; }
		}


		#endregion		
		
		
		#region Constructor

		public GENPrivilegeUser()
		{
		}
		private static GENPrivilegeUser _current;
		static GENPrivilegeUser()
		{
			_current = new GENPrivilegeUser();
		}
		public static GENPrivilegeUser Current
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
				objData.CreateNewStoredProcedure("GEN_PrivilegeUser_SEL");
				objData.AddParameter("@PrivilegeID", this.PrivilegeID);
				objData.AddParameter("@UserID", this.UserID);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["PrivilegeID"]))	this.PrivilegeID = Convert.ToInt32(reader["PrivilegeID"]);
					if(!this.IsDBNull(reader["UserID"]))	this.UserID = Convert.ToInt32(reader["UserID"]);
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
		/// Insert : GEN_PrivilegeUser
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
				objData.CreateNewStoredProcedure("GEN_PrivilegeUser_ADD");
				if(this.PrivilegeID != int.MinValue) objData.AddParameter("@PrivilegeID", this.PrivilegeID);
				if(this.UserID != int.MinValue) objData.AddParameter("@UserID", this.UserID);
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
		/// Update : GEN_PrivilegeUser
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
				objData.CreateNewStoredProcedure("GEN_PrivilegeUser_UPD");
				if(this.PrivilegeID != int.MinValue)	objData.AddParameter("@PrivilegeID", this.PrivilegeID);
				else objData.AddParameter("@PrivilegeID", DBNull.Value);
				if(this.UserID != int.MinValue)	objData.AddParameter("@UserID", this.UserID);
				else objData.AddParameter("@UserID", DBNull.Value);
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
		/// Delete : GEN_PrivilegeUser
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
				objData.CreateNewStoredProcedure("GEN_PrivilegeUser_DEL");
				objData.AddParameter("@PrivilegeID", this.PrivilegeID);
				objData.AddParameter("@UserID", this.UserID);
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
		/// Get all : GEN_PrivilegeUser
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
				objData.CreateNewStoredProcedure("GEN_PrivilegeUserSRH");
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
		 	GEN_PrivilegeUser objGEN_PrivilegeUser = new GEN_PrivilegeUser();
			objGENPrivilegeUser.PrivilegeID = txtPrivilegeID.Text;
			objGENPrivilegeUser.UserID = txtUserID.Text;

		 
		 ******************************************************
		 
		 			txtPrivilegeID.Text = objGENPrivilegeUser.PrivilegeID;
			txtUserID.Text = objGENPrivilegeUser.UserID;

		 
		*******************************************************/
		
	}
}

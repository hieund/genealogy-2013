
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
	public class GENPrivileges
	{
	
		
	
		#region Member Variables

		private int intPrivilegeID = int.MinValue;
		private string strPrivilegeName = string.Empty;
		private string strDescriptions = string.Empty;
		private IData objDataAccess = null;


		#endregion


		#region Properties 

		public static string CacheKey
		{
  			get { return  "GENPrivileges_GetAll";}
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
		/// PrivilegeName
		/// 
		/// </summary>
		public string PrivilegeName
		{
			get { return  strPrivilegeName; }
			set { strPrivilegeName = value; }
		}

		/// <summary>
		/// Descriptions
		/// 
		/// </summary>
		public string Descriptions
		{
			get { return  strDescriptions; }
			set { strDescriptions = value; }
		}


		#endregion		
		
		
		#region Constructor

		public GENPrivileges()
		{
		}
		private static GENPrivileges _current;
		static GENPrivileges()
		{
			_current = new GENPrivileges();
		}
		public static GENPrivileges Current
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
				objData.CreateNewStoredProcedure("GEN_Privileges_SEL");
				objData.AddParameter("@PrivilegeID", this.PrivilegeID);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["PrivilegeID"]))	this.PrivilegeID = Convert.ToInt32(reader["PrivilegeID"]);
					if(!this.IsDBNull(reader["PrivilegeName"]))	this.PrivilegeName = Convert.ToString(reader["PrivilegeName"]);
					if(!this.IsDBNull(reader["Descriptions"]))	this.Descriptions = Convert.ToString(reader["Descriptions"]);
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
		/// Insert : GEN_Privileges
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
				objData.CreateNewStoredProcedure("GEN_Privileges_ADD");
				if(this.PrivilegeID != int.MinValue) objData.AddParameter("@PrivilegeID", this.PrivilegeID);
				objData.AddParameter("@PrivilegeName", this.PrivilegeName);
				objData.AddParameter("@Descriptions", this.Descriptions);
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
		/// Update : GEN_Privileges
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
				objData.CreateNewStoredProcedure("GEN_Privileges_UPD");
				if(this.PrivilegeID != int.MinValue)	objData.AddParameter("@PrivilegeID", this.PrivilegeID);
				else objData.AddParameter("@PrivilegeID", DBNull.Value);
				objData.AddParameter("@PrivilegeName", this.PrivilegeName);
				objData.AddParameter("@Descriptions", this.Descriptions);
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
		/// Delete : GEN_Privileges
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
				objData.CreateNewStoredProcedure("GEN_Privileges_DEL");
				objData.AddParameter("@PrivilegeID", this.PrivilegeID);
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
		/// Get all : GEN_Privileges
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
				objData.CreateNewStoredProcedure("GEN_PrivilegesSRH");
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
		 	GEN_Privileges objGEN_Privileges = new GEN_Privileges();
			objGENPrivileges.PrivilegeID = txtPrivilegeID.Text;
			objGENPrivileges.PrivilegeName = txtPrivilegeName.Text;
			objGENPrivileges.Descriptions = txtDescriptions.Text;

		 
		 ******************************************************
		 
		 			txtPrivilegeID.Text = objGENPrivileges.PrivilegeID;
			txtPrivilegeName.Text = objGENPrivileges.PrivilegeName;
			txtDescriptions.Text = objGENPrivileges.Descriptions;

		 
		*******************************************************/
		
	}
}

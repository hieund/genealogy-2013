
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
	/// Created by 		: YourName 
	/// Created date 	: 6/9/2013 
	/// Description 
	/// </summary>	
	public class SystemConfig
	{
	
		
	
		#region Member Variables

		private string strName = string.Empty;
		private string strContent = string.Empty;
		private DateTime dtmCreated = DateTime.MinValue;
		private string strCreatedUser = string.Empty;
		private IData objDataAccess = null;


		#endregion


		#region Properties 

		public static string CacheKey
		{
  			get { return  "SystemConfig_GetAll";}
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
		/// Name
		/// 
		/// </summary>
		public string Name
		{
			get { return  strName; }
			set { strName = value; }
		}

		/// <summary>
		/// Content
		/// 
		/// </summary>
		public string Content
		{
			get { return  strContent; }
			set { strContent = value; }
		}

		/// <summary>
		/// Created
		/// 
		/// </summary>
		public DateTime Created
		{
			get { return  dtmCreated; }
			set { dtmCreated = value; }
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


		#endregion		
		
		
		#region Constructor

		public SystemConfig()
		{
		}
		private static SystemConfig _current;
		static SystemConfig()
		{
			_current = new SystemConfig();
		}
		public static SystemConfig Current
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
				objData.CreateNewStoredProcedure("System_Config_Select");
				objData.AddParameter("@Name", this.Name);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["Name"]))	this.Name = Convert.ToString(reader["Name"]);
					if(!this.IsDBNull(reader["Content"]))	this.Content = Convert.ToString(reader["Content"]);
					if(!this.IsDBNull(reader["Created"]))	this.Created = Convert.ToDateTime(reader["Created"]);
					if(!this.IsDBNull(reader["CreatedUser"]))	this.CreatedUser = Convert.ToString(reader["CreatedUser"]);
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
		/// Insert : System_Config
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
				objData.CreateNewStoredProcedure("System_Config_Insert");
				objData.AddParameter("@Name", this.Name);
				objData.AddParameter("@Content", this.Content);
				if(this.Created != DateTime.MinValue) objData.AddParameter("@Created", this.Created);
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
		/// Update : System_Config
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
				objData.CreateNewStoredProcedure("System_Config_Update");
				objData.AddParameter("@Name", this.Name);
				objData.AddParameter("@Content", this.Content);
				if(this.Created != DateTime.MinValue)	objData.AddParameter("@Created", this.Created);
				else objData.AddParameter("@Created", DBNull.Value);
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
		/// Delete : System_Config
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
				objData.CreateNewStoredProcedure("System_Config_Delete");
				objData.AddParameter("@Name", this.Name);
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
		/// Get all : System_Config
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
				objData.CreateNewStoredProcedure("System_Config_SelectAll");
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
		 	System_Config objSystem_Config = new System_Config();
			objSystemConfig.Name = txtName.Text;
			objSystemConfig.Content = txtContent.Text;
			objSystemConfig.Created = txtCreated.Text;
			objSystemConfig.CreatedUser = txtCreatedUser.Text;

		 
		 ******************************************************
		 
		 			txtName.Text = objSystemConfig.Name;
			txtContent.Text = objSystemConfig.Content;
			txtCreated.Text = objSystemConfig.Created;
			txtCreatedUser.Text = objSystemConfig.CreatedUser;

		 
		*******************************************************/
		
	}
}

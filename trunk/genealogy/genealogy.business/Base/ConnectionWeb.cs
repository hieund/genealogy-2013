
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
	public class ConnectionWeb
	{
	
		
	
		#region Member Variables

		private int intLinkID = int.MinValue;
		private string strName = string.Empty;
		private string strURL = string.Empty;
		private DateTime dtmCreated = DateTime.MinValue;
		private string strCreatedUser = string.Empty;
		private IData objDataAccess = null;


		#endregion


		#region Properties 

		public static string CacheKey
		{
  			get { return  "ConnectionWeb_GetAll";}
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
		/// LinkID
		/// 
		/// </summary>
		public int LinkID
		{
			get { return  intLinkID; }
			set { intLinkID = value; }
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
		/// URL
		/// 
		/// </summary>
		public string URL
		{
			get { return  strURL; }
			set { strURL = value; }
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

		public ConnectionWeb()
		{
		}
		private static ConnectionWeb _current;
		static ConnectionWeb()
		{
			_current = new ConnectionWeb();
		}
		public static ConnectionWeb Current
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
				objData.CreateNewStoredProcedure("ConnectionWeb_Select");
				objData.AddParameter("@LinkID", this.LinkID);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["LinkID"]))	this.LinkID = Convert.ToInt32(reader["LinkID"]);
					if(!this.IsDBNull(reader["Name"]))	this.Name = Convert.ToString(reader["Name"]);
					if(!this.IsDBNull(reader["URL"]))	this.URL = Convert.ToString(reader["URL"]);
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
		/// Insert : ConnectionWeb
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
				objData.CreateNewStoredProcedure("ConnectionWeb_Insert");
				if(this.LinkID != int.MinValue) objData.AddParameter("@LinkID", this.LinkID);
				objData.AddParameter("@Name", this.Name);
				objData.AddParameter("@URL", this.URL);
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
		/// Update : ConnectionWeb
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
				objData.CreateNewStoredProcedure("ConnectionWeb_Update");
				if(this.LinkID != int.MinValue)	objData.AddParameter("@LinkID", this.LinkID);
				else objData.AddParameter("@LinkID", DBNull.Value);
				objData.AddParameter("@Name", this.Name);
				objData.AddParameter("@URL", this.URL);
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
		/// Delete : ConnectionWeb
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
				objData.CreateNewStoredProcedure("ConnectionWeb_Delete");
				objData.AddParameter("@LinkID", this.LinkID);
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
		/// Get all : ConnectionWeb
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
				objData.CreateNewStoredProcedure("ConnectionWeb_SelectAll");
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
		 	ConnectionWeb objConnectionWeb = new ConnectionWeb();
			objConnectionWeb.LinkID = txtLinkID.Text;
			objConnectionWeb.Name = txtName.Text;
			objConnectionWeb.URL = txtURL.Text;
			objConnectionWeb.Created = txtCreated.Text;
			objConnectionWeb.CreatedUser = txtCreatedUser.Text;

		 
		 ******************************************************
		 
		 			txtLinkID.Text = objConnectionWeb.LinkID;
			txtName.Text = objConnectionWeb.Name;
			txtURL.Text = objConnectionWeb.URL;
			txtCreated.Text = objConnectionWeb.Created;
			txtCreatedUser.Text = objConnectionWeb.CreatedUser;

		 
		*******************************************************/
		
	}
}


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
	/// Created date 	: 4/16/2013 
	/// Description 
	/// </summary>	
	public class GENEventsDel
	{
	
		
	
		#region Member Variables

		private int intEventID = int.MinValue;
		private string strEventName = string.Empty;
		private int intEventType = int.MinValue;
		private string strEventContent = string.Empty;
		private bool bolIsActived;
		private bool bolIsDeleted;
		private int intCreatedUserID = int.MinValue;
		private DateTime dtmCreatedDate = DateTime.MinValue;
		private int intUpdatedUserID = int.MinValue;
		private DateTime dtmUpdatedDate = DateTime.MinValue;
		private int intDeletedUserID = int.MinValue;
		private DateTime dtmDeletedDate = DateTime.MinValue;
		private IData objDataAccess = null;


		#endregion


		#region Properties 

		public static string CacheKey
		{
  			get { return  "GENEventsDel_GetAll";}
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
		/// EventID
		/// 
		/// </summary>
		public int EventID
		{
			get { return  intEventID; }
			set { intEventID = value; }
		}

		/// <summary>
		/// EventName
		/// 
		/// </summary>
		public string EventName
		{
			get { return  strEventName; }
			set { strEventName = value; }
		}

		/// <summary>
		/// EventType
		/// 
		/// </summary>
		public int EventType
		{
			get { return  intEventType; }
			set { intEventType = value; }
		}

		/// <summary>
		/// EventContent
		/// 
		/// </summary>
		public string EventContent
		{
			get { return  strEventContent; }
			set { strEventContent = value; }
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


		#endregion		
		
		
		#region Constructor

		public GENEventsDel()
		{
		}
		private static GENEventsDel _current;
		static GENEventsDel()
		{
			_current = new GENEventsDel();
		}
		public static GENEventsDel Current
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
				objData.CreateNewStoredProcedure("GEN_Events_Del_SEL");
				objData.AddParameter("@EventID", this.EventID);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["EventID"]))	this.EventID = Convert.ToInt32(reader["EventID"]);
					if(!this.IsDBNull(reader["EventName"]))	this.EventName = Convert.ToString(reader["EventName"]);
					if(!this.IsDBNull(reader["EventType"]))	this.EventType = Convert.ToInt32(reader["EventType"]);
					if(!this.IsDBNull(reader["EventContent"]))	this.EventContent = Convert.ToString(reader["EventContent"]);
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
		/// Insert : GEN_Events_Del
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
				objData.CreateNewStoredProcedure("GEN_Events_Del_ADD");
				if(this.EventID != int.MinValue) objData.AddParameter("@EventID", this.EventID);
				objData.AddParameter("@EventName", this.EventName);
				if(this.EventType != int.MinValue) objData.AddParameter("@EventType", this.EventType);
				objData.AddParameter("@EventContent", this.EventContent);
				objData.AddParameter("@IsActived", this.IsActived);
				if(this.CreatedUserID != int.MinValue) objData.AddParameter("@CreatedUserID", this.CreatedUserID);
				if(this.UpdatedUserID != int.MinValue) objData.AddParameter("@UpdatedUserID", this.UpdatedUserID);
				if(this.DeletedUserID != int.MinValue) objData.AddParameter("@DeletedUserID", this.DeletedUserID);
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
		/// Update : GEN_Events_Del
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
				objData.CreateNewStoredProcedure("GEN_Events_Del_UPD");
				if(this.EventID != int.MinValue)	objData.AddParameter("@EventID", this.EventID);
				else objData.AddParameter("@EventID", DBNull.Value);
				objData.AddParameter("@EventName", this.EventName);
				if(this.EventType != int.MinValue)	objData.AddParameter("@EventType", this.EventType);
				else objData.AddParameter("@EventType", DBNull.Value);
				objData.AddParameter("@EventContent", this.EventContent);
				objData.AddParameter("@IsActived", this.IsActived);
				if(this.CreatedUserID != int.MinValue)	objData.AddParameter("@CreatedUserID", this.CreatedUserID);
				else objData.AddParameter("@CreatedUserID", DBNull.Value);
				if(this.UpdatedUserID != int.MinValue)	objData.AddParameter("@UpdatedUserID", this.UpdatedUserID);
				else objData.AddParameter("@UpdatedUserID", DBNull.Value);
				if(this.DeletedUserID != int.MinValue)	objData.AddParameter("@DeletedUserID", this.DeletedUserID);
				else objData.AddParameter("@DeletedUserID", DBNull.Value);
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
		/// Delete : GEN_Events_Del
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
				objData.CreateNewStoredProcedure("GEN_Events_Del_DEL");
				objData.AddParameter("@EventID", this.EventID);
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
		/// Get all : GEN_Events_Del
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
				objData.CreateNewStoredProcedure("GEN_Events_DelSRH");
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
		 	GEN_Events_Del objGEN_Events_Del = new GEN_Events_Del();
			objGENEventsDel.EventID = txtEventID.Text;
			objGENEventsDel.EventName = txtEventName.Text;
			objGENEventsDel.EventType = txtEventType.Text;
			objGENEventsDel.EventContent = txtEventContent.Text;
			objGENEventsDel.IsActived = txtIsActived.Text;
			objGENEventsDel.IsDeleted = txtIsDeleted.Text;
			objGENEventsDel.CreatedUserID = txtCreatedUserID.Text;
			objGENEventsDel.CreatedDate = txtCreatedDate.Text;
			objGENEventsDel.UpdatedUserID = txtUpdatedUserID.Text;
			objGENEventsDel.UpdatedDate = txtUpdatedDate.Text;
			objGENEventsDel.DeletedUserID = txtDeletedUserID.Text;
			objGENEventsDel.DeletedDate = txtDeletedDate.Text;

		 
		 ******************************************************
		 
		 			txtEventID.Text = objGENEventsDel.EventID;
			txtEventName.Text = objGENEventsDel.EventName;
			txtEventType.Text = objGENEventsDel.EventType;
			txtEventContent.Text = objGENEventsDel.EventContent;
			txtIsActived.Text = objGENEventsDel.IsActived;
			txtIsDeleted.Text = objGENEventsDel.IsDeleted;
			txtCreatedUserID.Text = objGENEventsDel.CreatedUserID;
			txtCreatedDate.Text = objGENEventsDel.CreatedDate;
			txtUpdatedUserID.Text = objGENEventsDel.UpdatedUserID;
			txtUpdatedDate.Text = objGENEventsDel.UpdatedDate;
			txtDeletedUserID.Text = objGENEventsDel.DeletedUserID;
			txtDeletedDate.Text = objGENEventsDel.DeletedDate;

		 
		*******************************************************/
		
	}
}

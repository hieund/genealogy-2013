
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
	/// Created date 	: 4/18/2013 
	/// Description 
	/// </summary>	
	public class GENNewsType
	{
	
		
	
		#region Member Variables

		private int intNewsTypeID = int.MinValue;
		private string strNewsTypeName = string.Empty;
		private string strNewsTypeShortName = string.Empty;
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
  			get { return  "GENNewsType_GetAll";}
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
		/// NewsTypeID
		/// 
		/// </summary>
		public int NewsTypeID
		{
			get { return  intNewsTypeID; }
			set { intNewsTypeID = value; }
		}

		/// <summary>
		/// NewsTypeName
		/// 
		/// </summary>
		public string NewsTypeName
		{
			get { return  strNewsTypeName; }
			set { strNewsTypeName = value; }
		}

		/// <summary>
		/// NewsTypeShortName
		/// 
		/// </summary>
		public string NewsTypeShortName
		{
			get { return  strNewsTypeShortName; }
			set { strNewsTypeShortName = value; }
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

		public GENNewsType()
		{
		}
		private static GENNewsType _current;
		static GENNewsType()
		{
			_current = new GENNewsType();
		}
		public static GENNewsType Current
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
				objData.CreateNewStoredProcedure("GEN_News_Type_SEL");
				objData.AddParameter("@NewsTypeID", this.NewsTypeID);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["NewsTypeID"]))	this.NewsTypeID = Convert.ToInt32(reader["NewsTypeID"]);
					if(!this.IsDBNull(reader["NewsTypeName"]))	this.NewsTypeName = Convert.ToString(reader["NewsTypeName"]);
					if(!this.IsDBNull(reader["NewsTypeShortName"]))	this.NewsTypeShortName = Convert.ToString(reader["NewsTypeShortName"]);
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
		/// Insert : GEN_News_Type
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
				objData.CreateNewStoredProcedure("GEN_News_Type_ADD");
				if(this.NewsTypeID != int.MinValue) objData.AddParameter("@NewsTypeID", this.NewsTypeID);
				objData.AddParameter("@NewsTypeName", this.NewsTypeName);
				objData.AddParameter("@NewsTypeShortName", this.NewsTypeShortName);
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
		/// Update : GEN_News_Type
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
				objData.CreateNewStoredProcedure("GEN_News_Type_UPD");
				if(this.NewsTypeID != int.MinValue)	objData.AddParameter("@NewsTypeID", this.NewsTypeID);
				else objData.AddParameter("@NewsTypeID", DBNull.Value);
				objData.AddParameter("@NewsTypeName", this.NewsTypeName);
				objData.AddParameter("@NewsTypeShortName", this.NewsTypeShortName);
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
		/// Delete : GEN_News_Type
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
				objData.CreateNewStoredProcedure("GEN_News_Type_DEL");
				objData.AddParameter("@NewsTypeID", this.NewsTypeID);
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
		/// Get all : GEN_News_Type
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
				objData.CreateNewStoredProcedure("GEN_News_TypeSRH");
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
		 	GEN_News_Type objGEN_News_Type = new GEN_News_Type();
			objGENNewsType.NewsTypeID = txtNewsTypeID.Text;
			objGENNewsType.NewsTypeName = txtNewsTypeName.Text;
			objGENNewsType.NewsTypeShortName = txtNewsTypeShortName.Text;
			objGENNewsType.IsActived = txtIsActived.Text;
			objGENNewsType.IsDeleted = txtIsDeleted.Text;
			objGENNewsType.CreatedUserID = txtCreatedUserID.Text;
			objGENNewsType.CreatedDate = txtCreatedDate.Text;
			objGENNewsType.UpdatedUserID = txtUpdatedUserID.Text;
			objGENNewsType.UpdatedDate = txtUpdatedDate.Text;
			objGENNewsType.DeletedUserID = txtDeletedUserID.Text;
			objGENNewsType.DeletedDate = txtDeletedDate.Text;

		 
		 ******************************************************
		 
		 			txtNewsTypeID.Text = objGENNewsType.NewsTypeID;
			txtNewsTypeName.Text = objGENNewsType.NewsTypeName;
			txtNewsTypeShortName.Text = objGENNewsType.NewsTypeShortName;
			txtIsActived.Text = objGENNewsType.IsActived;
			txtIsDeleted.Text = objGENNewsType.IsDeleted;
			txtCreatedUserID.Text = objGENNewsType.CreatedUserID;
			txtCreatedDate.Text = objGENNewsType.CreatedDate;
			txtUpdatedUserID.Text = objGENNewsType.UpdatedUserID;
			txtUpdatedDate.Text = objGENNewsType.UpdatedDate;
			txtDeletedUserID.Text = objGENNewsType.DeletedUserID;
			txtDeletedDate.Text = objGENNewsType.DeletedDate;

		 
		*******************************************************/
		
	}
}

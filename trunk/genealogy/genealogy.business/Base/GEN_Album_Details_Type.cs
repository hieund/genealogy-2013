
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
	public class GENAlbumDetailsType
	{
	
		
	
		#region Member Variables

		private int intAlbumDetailTypeID = int.MinValue;
		private string strAlbumDetailTypeName = string.Empty;
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
  			get { return  "GENAlbumDetailsType_GetAll";}
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
		/// AlbumDetailTypeID
		/// 
		/// </summary>
		public int AlbumDetailTypeID
		{
			get { return  intAlbumDetailTypeID; }
			set { intAlbumDetailTypeID = value; }
		}

		/// <summary>
		/// AlbumDetailTypeName
		/// 
		/// </summary>
		public string AlbumDetailTypeName
		{
			get { return  strAlbumDetailTypeName; }
			set { strAlbumDetailTypeName = value; }
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

		public GENAlbumDetailsType()
		{
		}
		private static GENAlbumDetailsType _current;
		static GENAlbumDetailsType()
		{
			_current = new GENAlbumDetailsType();
		}
		public static GENAlbumDetailsType Current
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
				objData.CreateNewStoredProcedure("GEN_Album_Details_Type_SEL");
				objData.AddParameter("@AlbumDetailTypeID", this.AlbumDetailTypeID);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["AlbumDetailTypeID"]))	this.AlbumDetailTypeID = Convert.ToInt32(reader["AlbumDetailTypeID"]);
					if(!this.IsDBNull(reader["AlbumDetailTypeName"]))	this.AlbumDetailTypeName = Convert.ToString(reader["AlbumDetailTypeName"]);
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
		/// Insert : GEN_Album_Details_Type
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
				objData.CreateNewStoredProcedure("GEN_Album_Details_Type_ADD");
				if(this.AlbumDetailTypeID != int.MinValue) objData.AddParameter("@AlbumDetailTypeID", this.AlbumDetailTypeID);
				objData.AddParameter("@AlbumDetailTypeName", this.AlbumDetailTypeName);
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
		/// Update : GEN_Album_Details_Type
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
				objData.CreateNewStoredProcedure("GEN_Album_Details_Type_UPD");
				if(this.AlbumDetailTypeID != int.MinValue)	objData.AddParameter("@AlbumDetailTypeID", this.AlbumDetailTypeID);
				else objData.AddParameter("@AlbumDetailTypeID", DBNull.Value);
				objData.AddParameter("@AlbumDetailTypeName", this.AlbumDetailTypeName);
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
		/// Delete : GEN_Album_Details_Type
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
				objData.CreateNewStoredProcedure("GEN_Album_Details_Type_DEL");
				objData.AddParameter("@AlbumDetailTypeID", this.AlbumDetailTypeID);
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
		/// Get all : GEN_Album_Details_Type
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
				objData.CreateNewStoredProcedure("GEN_Album_Details_TypeSRH");
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
		 	GEN_Album_Details_Type objGEN_Album_Details_Type = new GEN_Album_Details_Type();
			objGENAlbumDetailsType.AlbumDetailTypeID = txtAlbumDetailTypeID.Text;
			objGENAlbumDetailsType.AlbumDetailTypeName = txtAlbumDetailTypeName.Text;
			objGENAlbumDetailsType.IsActived = txtIsActived.Text;
			objGENAlbumDetailsType.IsDeleted = txtIsDeleted.Text;
			objGENAlbumDetailsType.CreatedUserID = txtCreatedUserID.Text;
			objGENAlbumDetailsType.CreatedDate = txtCreatedDate.Text;
			objGENAlbumDetailsType.UpdatedUserID = txtUpdatedUserID.Text;
			objGENAlbumDetailsType.UpdatedDate = txtUpdatedDate.Text;
			objGENAlbumDetailsType.DeletedUserID = txtDeletedUserID.Text;
			objGENAlbumDetailsType.DeletedDate = txtDeletedDate.Text;

		 
		 ******************************************************
		 
		 			txtAlbumDetailTypeID.Text = objGENAlbumDetailsType.AlbumDetailTypeID;
			txtAlbumDetailTypeName.Text = objGENAlbumDetailsType.AlbumDetailTypeName;
			txtIsActived.Text = objGENAlbumDetailsType.IsActived;
			txtIsDeleted.Text = objGENAlbumDetailsType.IsDeleted;
			txtCreatedUserID.Text = objGENAlbumDetailsType.CreatedUserID;
			txtCreatedDate.Text = objGENAlbumDetailsType.CreatedDate;
			txtUpdatedUserID.Text = objGENAlbumDetailsType.UpdatedUserID;
			txtUpdatedDate.Text = objGENAlbumDetailsType.UpdatedDate;
			txtDeletedUserID.Text = objGENAlbumDetailsType.DeletedUserID;
			txtDeletedDate.Text = objGENAlbumDetailsType.DeletedDate;

		 
		*******************************************************/
		
	}
}

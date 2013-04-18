
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
	public class GFUserRelations
	{
	
		
	
		#region Member Variables

		private int intUserID = int.MinValue;
		private int intUserRelationID = int.MinValue;
		private int intRelationTypeID = int.MinValue;
		private IData objDataAccess = null;


		#endregion


		#region Properties 

		public static string CacheKey
		{
  			get { return  "GFUserRelations_GetAll";}
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
		/// UserID
		/// 
		/// </summary>
		public int UserID
		{
			get { return  intUserID; }
			set { intUserID = value; }
		}

		/// <summary>
		/// UserRelationID
		/// 
		/// </summary>
		public int UserRelationID
		{
			get { return  intUserRelationID; }
			set { intUserRelationID = value; }
		}

		/// <summary>
		/// RelationTypeID
		/// 
		/// </summary>
		public int RelationTypeID
		{
			get { return  intRelationTypeID; }
			set { intRelationTypeID = value; }
		}


		#endregion		
		
		
		#region Constructor

		public GFUserRelations()
		{
		}
		private static GFUserRelations _current;
		static GFUserRelations()
		{
			_current = new GFUserRelations();
		}
		public static GFUserRelations Current
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
				objData.CreateNewStoredProcedure("GF_User_Relations_SEL");
				objData.AddParameter("@UserID", this.UserID);
				objData.AddParameter("@UserRelationID", this.UserRelationID);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["UserID"]))	this.UserID = Convert.ToInt32(reader["UserID"]);
					if(!this.IsDBNull(reader["UserRelationID"]))	this.UserRelationID = Convert.ToInt32(reader["UserRelationID"]);
					if(!this.IsDBNull(reader["RelationTypeID"]))	this.RelationTypeID = Convert.ToInt32(reader["RelationTypeID"]);
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
		/// Insert : GF_User_Relations
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
				objData.CreateNewStoredProcedure("GF_User_Relations_ADD");
				if(this.UserID != int.MinValue) objData.AddParameter("@UserID", this.UserID);
				if(this.UserRelationID != int.MinValue) objData.AddParameter("@UserRelationID", this.UserRelationID);
				if(this.RelationTypeID != int.MinValue) objData.AddParameter("@RelationTypeID", this.RelationTypeID);
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
		/// Update : GF_User_Relations
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
				objData.CreateNewStoredProcedure("GF_User_Relations_UPD");
				if(this.UserID != int.MinValue)	objData.AddParameter("@UserID", this.UserID);
				else objData.AddParameter("@UserID", DBNull.Value);
				if(this.UserRelationID != int.MinValue)	objData.AddParameter("@UserRelationID", this.UserRelationID);
				else objData.AddParameter("@UserRelationID", DBNull.Value);
				if(this.RelationTypeID != int.MinValue)	objData.AddParameter("@RelationTypeID", this.RelationTypeID);
				else objData.AddParameter("@RelationTypeID", DBNull.Value);
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
		/// Delete : GF_User_Relations
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
				objData.CreateNewStoredProcedure("GF_User_Relations_DEL");
				objData.AddParameter("@UserID", this.UserID);
				objData.AddParameter("@UserRelationID", this.UserRelationID);
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
		/// Get all : GF_User_Relations
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
				objData.CreateNewStoredProcedure("GF_User_Relations_SRH");
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
		 	GF_User_Relations objGF_User_Relations = new GF_User_Relations();
			objGFUserRelations.UserID = txtUserID.Text;
			objGFUserRelations.UserRelationID = txtUserRelationID.Text;
			objGFUserRelations.RelationTypeID = txtRelationTypeID.Text;

		 
		 ******************************************************
		 
		 			txtUserID.Text = objGFUserRelations.UserID;
			txtUserRelationID.Text = objGFUserRelations.UserRelationID;
			txtRelationTypeID.Text = objGFUserRelations.RelationTypeID;

		 
		*******************************************************/
		
	}
}

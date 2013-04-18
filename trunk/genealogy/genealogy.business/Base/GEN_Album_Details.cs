
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
	public class GENAlbumDetails
	{
	
		
	
		#region Member Variables

		private int intAlbumDetailID = int.MinValue;
		private string strAlbumDetailName = string.Empty;
		private int intAlbumDetailTypeID = int.MinValue;
		private string strURL = string.Empty;
		private string strAlbumDetailImage = string.Empty;
		private int intAlbumID = int.MinValue;
		private IData objDataAccess = null;


		#endregion


		#region Properties 

		public static string CacheKey
		{
  			get { return  "GENAlbumDetails_GetAll";}
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
		/// AlbumDetailID
		/// 
		/// </summary>
		public int AlbumDetailID
		{
			get { return  intAlbumDetailID; }
			set { intAlbumDetailID = value; }
		}

		/// <summary>
		/// AlbumDetailName
		/// 
		/// </summary>
		public string AlbumDetailName
		{
			get { return  strAlbumDetailName; }
			set { strAlbumDetailName = value; }
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
		/// URL
		/// 
		/// </summary>
		public string URL
		{
			get { return  strURL; }
			set { strURL = value; }
		}

		/// <summary>
		/// AlbumDetailImage
		/// 
		/// </summary>
		public string AlbumDetailImage
		{
			get { return  strAlbumDetailImage; }
			set { strAlbumDetailImage = value; }
		}

		/// <summary>
		/// AlbumID
		/// 
		/// </summary>
		public int AlbumID
		{
			get { return  intAlbumID; }
			set { intAlbumID = value; }
		}


		#endregion		
		
		
		#region Constructor

		public GENAlbumDetails()
		{
		}
		private static GENAlbumDetails _current;
		static GENAlbumDetails()
		{
			_current = new GENAlbumDetails();
		}
		public static GENAlbumDetails Current
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
				objData.CreateNewStoredProcedure("GEN_Album_Details_SEL");
				objData.AddParameter("@AlbumDetailID", this.AlbumDetailID);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["AlbumDetailID"]))	this.AlbumDetailID = Convert.ToInt32(reader["AlbumDetailID"]);
					if(!this.IsDBNull(reader["AlbumDetailName"]))	this.AlbumDetailName = Convert.ToString(reader["AlbumDetailName"]);
					if(!this.IsDBNull(reader["AlbumDetailTypeID"]))	this.AlbumDetailTypeID = Convert.ToInt32(reader["AlbumDetailTypeID"]);
					if(!this.IsDBNull(reader["URL"]))	this.URL = Convert.ToString(reader["URL"]);
					if(!this.IsDBNull(reader["AlbumDetailImage"]))	this.AlbumDetailImage = Convert.ToString(reader["AlbumDetailImage"]);
					if(!this.IsDBNull(reader["AlbumID"]))	this.AlbumID = Convert.ToInt32(reader["AlbumID"]);
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
		/// Insert : GEN_Album_Details
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
				objData.CreateNewStoredProcedure("GEN_Album_Details_ADD");
				if(this.AlbumDetailID != int.MinValue) objData.AddParameter("@AlbumDetailID", this.AlbumDetailID);
				objData.AddParameter("@AlbumDetailName", this.AlbumDetailName);
				if(this.AlbumDetailTypeID != int.MinValue) objData.AddParameter("@AlbumDetailTypeID", this.AlbumDetailTypeID);
				objData.AddParameter("@URL", this.URL);
				objData.AddParameter("@AlbumDetailImage", this.AlbumDetailImage);
				if(this.AlbumID != int.MinValue) objData.AddParameter("@AlbumID", this.AlbumID);
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
		/// Update : GEN_Album_Details
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
				objData.CreateNewStoredProcedure("GEN_Album_Details_UPD");
				if(this.AlbumDetailID != int.MinValue)	objData.AddParameter("@AlbumDetailID", this.AlbumDetailID);
				else objData.AddParameter("@AlbumDetailID", DBNull.Value);
				objData.AddParameter("@AlbumDetailName", this.AlbumDetailName);
				if(this.AlbumDetailTypeID != int.MinValue)	objData.AddParameter("@AlbumDetailTypeID", this.AlbumDetailTypeID);
				else objData.AddParameter("@AlbumDetailTypeID", DBNull.Value);
				objData.AddParameter("@URL", this.URL);
				objData.AddParameter("@AlbumDetailImage", this.AlbumDetailImage);
				if(this.AlbumID != int.MinValue)	objData.AddParameter("@AlbumID", this.AlbumID);
				else objData.AddParameter("@AlbumID", DBNull.Value);
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
		/// Delete : GEN_Album_Details
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
				objData.CreateNewStoredProcedure("GEN_Album_Details_DEL");
				objData.AddParameter("@AlbumDetailID", this.AlbumDetailID);
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
		/// Get all : GEN_Album_Details
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
				objData.CreateNewStoredProcedure("GEN_Album_DetailsSRH");
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
		 	GEN_Album_Details objGEN_Album_Details = new GEN_Album_Details();
			objGENAlbumDetails.AlbumDetailID = txtAlbumDetailID.Text;
			objGENAlbumDetails.AlbumDetailName = txtAlbumDetailName.Text;
			objGENAlbumDetails.AlbumDetailTypeID = txtAlbumDetailTypeID.Text;
			objGENAlbumDetails.URL = txtURL.Text;
			objGENAlbumDetails.AlbumDetailImage = txtAlbumDetailImage.Text;
			objGENAlbumDetails.AlbumID = txtAlbumID.Text;

		 
		 ******************************************************
		 
		 			txtAlbumDetailID.Text = objGENAlbumDetails.AlbumDetailID;
			txtAlbumDetailName.Text = objGENAlbumDetails.AlbumDetailName;
			txtAlbumDetailTypeID.Text = objGENAlbumDetails.AlbumDetailTypeID;
			txtURL.Text = objGENAlbumDetails.URL;
			txtAlbumDetailImage.Text = objGENAlbumDetails.AlbumDetailImage;
			txtAlbumID.Text = objGENAlbumDetails.AlbumID;

		 
		*******************************************************/
		
	}
}

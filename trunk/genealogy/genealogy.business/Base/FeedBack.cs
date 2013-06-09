
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
	public class FeedBack
	{
	
		
	
		#region Member Variables

		private int intFeedBackID = int.MinValue;
		private string strFullName = string.Empty;
		private string strContent = string.Empty;
		private DateTime dtmCreatedDate = DateTime.MinValue;
		private IData objDataAccess = null;


		#endregion


		#region Properties 

		public static string CacheKey
		{
  			get { return  "FeedBack_GetAll";}
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
		/// FeedBackID
		/// 
		/// </summary>
		public int FeedBackID
		{
			get { return  intFeedBackID; }
			set { intFeedBackID = value; }
		}

		/// <summary>
		/// FullName
		/// 
		/// </summary>
		public string FullName
		{
			get { return  strFullName; }
			set { strFullName = value; }
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
		/// CreatedDate
		/// 
		/// </summary>
		public DateTime CreatedDate
		{
			get { return  dtmCreatedDate; }
			set { dtmCreatedDate = value; }
		}


		#endregion		
		
		
		#region Constructor

		public FeedBack()
		{
		}
		private static FeedBack _current;
		static FeedBack()
		{
			_current = new FeedBack();
		}
		public static FeedBack Current
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
				objData.CreateNewStoredProcedure("FeedBack_Select");
				objData.AddParameter("@FeedBackID", this.FeedBackID);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["FeedBackID"]))	this.FeedBackID = Convert.ToInt32(reader["FeedBackID"]);
					if(!this.IsDBNull(reader["FullName"]))	this.FullName = Convert.ToString(reader["FullName"]);
					if(!this.IsDBNull(reader["Content"]))	this.Content = Convert.ToString(reader["Content"]);
					if(!this.IsDBNull(reader["CreatedDate"]))	this.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
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
		/// Insert : FeedBack
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
				objData.CreateNewStoredProcedure("FeedBack_Insert"); 
				objData.AddParameter("@FullName", this.FullName);
				objData.AddParameter("@Content", this.Content);
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
		/// Update : FeedBack
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
				objData.CreateNewStoredProcedure("FeedBack_Update");
				if(this.FeedBackID != int.MinValue)	objData.AddParameter("@FeedBackID", this.FeedBackID);
				else objData.AddParameter("@FeedBackID", DBNull.Value);
				objData.AddParameter("@FullName", this.FullName);
				objData.AddParameter("@Content", this.Content);
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
		/// Delete : FeedBack
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
				objData.CreateNewStoredProcedure("FeedBack_Delete");
				objData.AddParameter("@FeedBackID", this.FeedBackID);
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
		/// Get all : FeedBack
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
				objData.CreateNewStoredProcedure("FeedBack_SelectAll");
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
		 	FeedBack objFeedBack = new FeedBack();
			objFeedBack.FeedBackID = txtFeedBackID.Text;
			objFeedBack.FullName = txtFullName.Text;
			objFeedBack.Content = txtContent.Text;
			objFeedBack.CreatedDate = txtCreatedDate.Text;

		 
		 ******************************************************
		 
		 			txtFeedBackID.Text = objFeedBack.FeedBackID;
			txtFullName.Text = objFeedBack.FullName;
			txtContent.Text = objFeedBack.Content;
			txtCreatedDate.Text = objFeedBack.CreatedDate;

		 
		*******************************************************/
		
	}
}

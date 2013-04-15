
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
	/// Created date 	: 4/16/2013 
	/// Manage Genealogy
	/// </summary>	
	public class UIMenusHierarchy
	{
	
		#region Member Variables

		private int intMenuID = int.MinValue;
		private int intParentMenuID = int.MinValue;
		private IData objDataAccess = null;

		#endregion


		#region Properties 

		public static string CacheKey
		{
  			get { return  "UIMenusHierarchy_All";}
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
		/// MenuID
		/// 
		/// </summary>
		public int MenuID
		{
			get { return  intMenuID; }
			set { intMenuID = value; }
		}

		/// <summary>
		/// ParentMenuID
		/// 
		/// </summary>
		public int ParentMenuID
		{
			get { return  intParentMenuID; }
			set { intParentMenuID = value; }
		}


		#endregion		
		
		
		#region Constructor

		public UIMenusHierarchy()
		{
		}
		private static UIMenusHierarchy _current;
		static UIMenusHierarchy()
		{
			_current = new UIMenusHierarchy();
		}
		public static UIMenusHierarchy Current
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
				objData.CreateNewStoredProcedure("UI_Menus_Hierarchy_SEL");
				objData.AddParameter("@MenuID", this.MenuID);
				objData.AddParameter("@ParentMenuID", this.ParentMenuID);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["MenuID"]))	this.MenuID = Convert.ToInt32(reader["MenuID"]);
					if(!this.IsDBNull(reader["ParentMenuID"]))	this.ParentMenuID = Convert.ToInt32(reader["ParentMenuID"]);
 					bolOK = true;
 				}
				reader.Close();
			}
			catch (Exception)
			{
				throw;
			}
			finally
    		{
    			if (objDataAccess == null)
        			objData.DeConnect();
    		}
    		return bolOK;
		}

		///<summary>
		/// Insert : UI_Menus_Hierarchy
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
				objData.CreateNewStoredProcedure("UI_Menus_Hierarchy_ADD");
				if(this.MenuID != int.MinValue) objData.AddParameter("@MenuID", this.MenuID);
				if(this.ParentMenuID != int.MinValue) objData.AddParameter("@ParentMenuID", this.ParentMenuID);
                objTemp = objData.ExecStoreToString();
			}
			catch (Exception)
			{
				throw;
			}
			finally
    		{
    			if (objDataAccess == null)
        			objData.DeConnect();
    		}
    		return objTemp;
		}


		///<summary>
		/// Update : UI_Menus_Hierarchy
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
				objData.CreateNewStoredProcedure("UI_Menus_Hierarchy_UPD");
				if(this.MenuID != int.MinValue)	objData.AddParameter("@MenuID", this.MenuID);
				else objData.AddParameter("@MenuID", DBNull.Value);
				if(this.ParentMenuID != int.MinValue)	objData.AddParameter("@ParentMenuID", this.ParentMenuID);
				else objData.AddParameter("@ParentMenuID", DBNull.Value);
                objTemp = objData.ExecNonQuery();
			}
			catch (Exception)
			{
				throw;
			}
			finally
    		{
    			if (objDataAccess == null)
        			objData.DeConnect();
    		}
    		return objTemp;
		}


		///<summary>
		/// Delete : UI_Menus_Hierarchy
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
				objData.CreateNewStoredProcedure("UI_Menus_Hierarchy_DEL");
				objData.AddParameter("@MenuID", this.MenuID);
				objData.AddParameter("@ParentMenuID", this.ParentMenuID);
 				intTemp = objData.ExecNonQuery();
			}
			catch (Exception)
			{
				throw;
			}
			finally
    		{
    			if (objDataAccess == null)
        			objData.DeConnect();
    		}
    		return intTemp;
		}


		///<summary>
		/// Get all : UI_Menus_Hierarchy
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
				objData.CreateNewStoredProcedure("UI_Menus_Hierarchy_SRH");
				return objData.ExecStoreToDataTable();
			}
			catch (Exception)
			{
				throw;
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
	}
}

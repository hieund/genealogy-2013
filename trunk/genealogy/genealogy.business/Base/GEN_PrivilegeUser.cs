
#region Using

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Libs;

#endregion
namespace genelogy.business
{
    /// <summary>
	/// Created by 		: Nguyễn Đức Hiếu 
	/// Created date 	: 5/30/2013 
	/// Description 
	/// </summary>	
	public class GENPrivilegeUser
	{
	
	
		#region Member Variables

		private int intPrivilegeID;
		private int intUserID;
		private bool bolIsExist = false;


		#endregion


		#region Properties 

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
		/// UserID
		/// 
		/// </summary>
		public int UserID
		{
			get { return  intUserID; }
			set { intUserID = value; }
		}

		/// <summary>
		/// Có tồn tại không?
		/// </summary>
		public bool IsExist
		{
  			get { return bolIsExist; }
   			set { bolIsExist = value; }
		}

		#endregion		
		
		#region Methods	
		
		

		///<summary>
		/// Nạp thông tin từ CSDL
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool LoadInfo()
		{
			Data objData = new Data(SystemConfig.strConnect);
			try 
			{
				objData.Connect();
				objData.CreateNewStoredProcedure("GEN_PrivilegeUser_SEL");
				objData.AddParameter("@PrivilegeID", this.PrivilegeID);
				objData.AddParameter("@UserID", this.UserID);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["PrivilegeID"]))	this.intPrivilegeID = Convert.ToInt32(reader["PrivilegeID"]);
					if(!this.IsDBNull(reader["UserID"]))	this.intUserID = Convert.ToInt32(reader["UserID"]);
 					bolIsExist = true;
 				}
 				else
 				{
 					bolIsExist = false;
 				}
				reader.Close();
			}
			catch (Exception objEx)
			{
				new SystemError(objData, "Lỗi nạp thông tin GEN_PrivilegeUser", objExce);
				MessageBox.Show(this, "Lỗi nạp thông tin GEN_PrivilegeUser", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally
    		{
        		objData.DeConnect();
    		}
    		return true;
		}

		///<summary>
		/// Insert : GEN_PrivilegeUser
		/// Thêm dữ liệu
		///</summary>
		public bool Insert()
		{
			Data objData = new Data(SystemConfig.strConnect);
			try 
			{
				objData.Connect();
				objData.CreateNewStoredProcedure("GEN_PrivilegeUser_ADD");
				objData.AddParameter("@PrivilegeID", this.intPrivilegeID);
				objData.AddParameter("@UserID", this.intUserID);
                objData.ExecNonQuery();
			}
			catch (Exception objEx)
			{
				new SystemError(objData, "Lỗi thêm thông tin GEN_PrivilegeUser", objExce);
				MessageBox.Show(this, "Lỗi thêm thông tin GEN_PrivilegeUser", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally
    		{
        		objData.DeConnect();
    		}
    		return true;
		}


		///<summary>
		/// Update : GEN_PrivilegeUser
		/// Cập nhật dữ liệu
		///</summary>
		public bool Update()
		{
			Data objData = new Data(SystemConfig.strConnect);
			try 
			{
				objData.Connect();
				objData.CreateNewStoredProcedure("GEN_PrivilegeUser_UPD");
				objData.AddParameter("@PrivilegeID", this.intPrivilegeID);
				objData.AddParameter("@UserID", this.intUserID);
              objData.ExecNonQuery();
			}
			catch (Exception objEx)
			{
				new SystemError(objData, "Lỗi cập nhật thông tin GEN_PrivilegeUser", objExce);
				MessageBox.Show(this, "Lỗi cập nhật thông tin GEN_PrivilegeUser", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally
    		{
        		objData.DeConnect();
    		}
    		return true;
		}


		///<summary>
		/// Delete : GEN_PrivilegeUser
		///Xóa dữ liệu
		///</summary>
		public bool Delete()
		{

			Data objData = new Data(SystemConfig.strConnect);
			try 
			{
				objData.Connect();
				objData.CreateNewStoredProcedure("GEN_PrivilegeUser_DEL");
				objData.AddParameter("@PrivilegeID", this.intPrivilegeID);
				objData.AddParameter("@UserID", this.intUserID);
 				objData.ExecNonQuery();
			}
			catch (Exception objEx)
			{
				new SystemError(objData, "Lỗi cập nhật thông tin GEN_PrivilegeUser", objExce);
				MessageBox.Show(this, "Lỗi cập nhật thông tin GEN_PrivilegeUser", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally
    		{
        		objData.DeConnect();
    		}
    		return true;
		}


		///<summary>
		/// Get all : GEN_PrivilegeUser
		///
		///</summary>
		public DataTable GetData()
		{

			Data objData = new Data(SystemConfig.strConnect);
			try
			{
				objData.Connect();
				objData.CreateNewStoredProcedure("GEN_PrivilegeUser_SEL");
				return objData.ExecStoreToDataTable();
			}
			catch (Exception objEx)
			{
				new SystemError(objData, "Lỗi nạp thông tin GEN_PrivilegeUser", objExce);
				MessageBox.Show(this, "Lỗi nạp thông tin GEN_PrivilegeUser", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
			finally
			{
        		objData.DeConnect();
			}
		}
		#endregion

		#region Constructor

		public GENPrivilegeUser()
		{
		}
		public GENPrivilegeUser()
		{
			this.LoadInfo();
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
		 	GEN_PrivilegeUser objGEN_PrivilegeUser = new GEN_PrivilegeUser();
			objGENPrivilegeUser.PrivilegeID = txtPrivilegeID.Text;
			objGENPrivilegeUser.UserID = txtUserID.Text;

		 
		 ******************************************************
		 
		 			txtPrivilegeID.Text = objGENPrivilegeUser.PrivilegeID;
			txtUserID.Text = objGENPrivilegeUser.UserID;

		 
		*******************************************************/
		
	}
}

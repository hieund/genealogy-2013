
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
	public class GENPrivileges
	{
	
	
		#region Member Variables

		private int intPrivilegeID;
		private string strPrivilegeName = string.Empty;
		private string strDescriptions = string.Empty;
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
		/// PrivilegeName
		/// 
		/// </summary>
		public string PrivilegeName
		{
			get { return  strPrivilegeName; }
			set { strPrivilegeName = value; }
		}

		/// <summary>
		/// Descriptions
		/// 
		/// </summary>
		public string Descriptions
		{
			get { return  strDescriptions; }
			set { strDescriptions = value; }
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
				objData.CreateNewStoredProcedure("GEN_Privileges_SEL");
				objData.AddParameter("@PrivilegeID", this.PrivilegeID);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["PrivilegeID"]))	this.intPrivilegeID = Convert.ToInt32(reader["PrivilegeID"]);
					if(!this.IsDBNull(reader["PrivilegeName"]))	this.strPrivilegeName = Convert.ToString(reader["PrivilegeName"]).Trim();
					if(!this.IsDBNull(reader["Descriptions"]))	this.strDescriptions = Convert.ToString(reader["Descriptions"]).Trim();
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
				new SystemError(objData, "Lỗi nạp thông tin GEN_Privileges", objExce);
				MessageBox.Show(this, "Lỗi nạp thông tin GEN_Privileges", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally
    		{
        		objData.DeConnect();
    		}
    		return true;
		}

		///<summary>
		/// Insert : GEN_Privileges
		/// Thêm dữ liệu
		///</summary>
		public bool Insert()
		{
			Data objData = new Data(SystemConfig.strConnect);
			try 
			{
				objData.Connect();
				objData.CreateNewStoredProcedure("GEN_Privileges_ADD");
				objData.AddParameter("@PrivilegeID", this.intPrivilegeID);
				objData.AddParameter("@PrivilegeName", this.strPrivilegeName);
				objData.AddParameter("@Descriptions", this.strDescriptions);
                objData.ExecNonQuery();
			}
			catch (Exception objEx)
			{
				new SystemError(objData, "Lỗi thêm thông tin GEN_Privileges", objExce);
				MessageBox.Show(this, "Lỗi thêm thông tin GEN_Privileges", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally
    		{
        		objData.DeConnect();
    		}
    		return true;
		}


		///<summary>
		/// Update : GEN_Privileges
		/// Cập nhật dữ liệu
		///</summary>
		public bool Update()
		{
			Data objData = new Data(SystemConfig.strConnect);
			try 
			{
				objData.Connect();
				objData.CreateNewStoredProcedure("GEN_Privileges_UPD");
				objData.AddParameter("@PrivilegeID", this.intPrivilegeID);
				objData.AddParameter("@PrivilegeName", this.strPrivilegeName);
				objData.AddParameter("@Descriptions", this.strDescriptions);
              objData.ExecNonQuery();
			}
			catch (Exception objEx)
			{
				new SystemError(objData, "Lỗi cập nhật thông tin GEN_Privileges", objExce);
				MessageBox.Show(this, "Lỗi cập nhật thông tin GEN_Privileges", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally
    		{
        		objData.DeConnect();
    		}
    		return true;
		}


		///<summary>
		/// Delete : GEN_Privileges
		///Xóa dữ liệu
		///</summary>
		public bool Delete()
		{

			Data objData = new Data(SystemConfig.strConnect);
			try 
			{
				objData.Connect();
				objData.CreateNewStoredProcedure("GEN_Privileges_DEL");
				objData.AddParameter("@PrivilegeID", this.intPrivilegeID);
 				objData.ExecNonQuery();
			}
			catch (Exception objEx)
			{
				new SystemError(objData, "Lỗi cập nhật thông tin GEN_Privileges", objExce);
				MessageBox.Show(this, "Lỗi cập nhật thông tin GEN_Privileges", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally
    		{
        		objData.DeConnect();
    		}
    		return true;
		}


		///<summary>
		/// Get all : GEN_Privileges
		///
		///</summary>
		public DataTable GetData()
		{

			Data objData = new Data(SystemConfig.strConnect);
			try
			{
				objData.Connect();
				objData.CreateNewStoredProcedure("GEN_Privileges_SEL");
				return objData.ExecStoreToDataTable();
			}
			catch (Exception objEx)
			{
				new SystemError(objData, "Lỗi nạp thông tin GEN_Privileges", objExce);
				MessageBox.Show(this, "Lỗi nạp thông tin GEN_Privileges", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
			finally
			{
        		objData.DeConnect();
			}
		}
		#endregion

		#region Constructor

		public GENPrivileges()
		{
		}
		public GENPrivileges()
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
		 	GEN_Privileges objGEN_Privileges = new GEN_Privileges();
			objGENPrivileges.PrivilegeID = txtPrivilegeID.Text;
			objGENPrivileges.PrivilegeName = txtPrivilegeName.Text;
			objGENPrivileges.Descriptions = txtDescriptions.Text;

		 
		 ******************************************************
		 
		 			txtPrivilegeID.Text = objGENPrivileges.PrivilegeID;
			txtPrivilegeName.Text = objGENPrivileges.PrivilegeName;
			txtDescriptions.Text = objGENPrivileges.Descriptions;

		 
		*******************************************************/
		
	}
}


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
	public class GENUsers
	{
	
		
	
		#region Member Variables

		private int intUserID = int.MinValue;
		private string strPassword = string.Empty;
		private string strNickName = string.Empty;
		private bool bolIsLogin;
		private bool bolIsAdmin;
		private string strBirthday = string.Empty;
		private string strAboutMe = string.Empty;
		private string strHobby = string.Empty;
		private string strEmail = string.Empty;
		private string strAddress = string.Empty;
		private string strSchools = string.Empty;
		private string strJobs = string.Empty;
		private string strGender = string.Empty;
		private string strDeathDate = string.Empty;
		private string strHometown = string.Empty;
		private string strBirthPlace = string.Empty;
		private int intStatus = int.MinValue;
		private string strFirstName = string.Empty;
		private string strLastName = string.Empty;
		private string strFullName = string.Empty;
		private string strMobile = string.Empty;
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
  			get { return  "GENUsers_GetAll";}
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
		/// Password
		/// 
		/// </summary>
		public string Password
		{
			get { return  strPassword; }
			set { strPassword = value; }
		}

		/// <summary>
		/// NickName
		/// 
		/// </summary>
		public string NickName
		{
			get { return  strNickName; }
			set { strNickName = value; }
		}

		/// <summary>
		/// IsLogin
		/// 
		/// </summary>
		public bool IsLogin
		{
			get { return  bolIsLogin; }
			set { bolIsLogin = value; }
		}

		/// <summary>
		/// IsAdmin
		/// 
		/// </summary>
		public bool IsAdmin
		{
			get { return  bolIsAdmin; }
			set { bolIsAdmin = value; }
		}

		/// <summary>
		/// Birthday
		/// 
		/// </summary>
		public string Birthday
		{
			get { return  strBirthday; }
			set { strBirthday = value; }
		}

		/// <summary>
		/// AboutMe
		/// 
		/// </summary>
		public string AboutMe
		{
			get { return  strAboutMe; }
			set { strAboutMe = value; }
		}

		/// <summary>
		/// Hobby
		/// 
		/// </summary>
		public string Hobby
		{
			get { return  strHobby; }
			set { strHobby = value; }
		}

		/// <summary>
		/// Email
		/// 
		/// </summary>
		public string Email
		{
			get { return  strEmail; }
			set { strEmail = value; }
		}

		/// <summary>
		/// Address
		/// 
		/// </summary>
		public string Address
		{
			get { return  strAddress; }
			set { strAddress = value; }
		}

		/// <summary>
		/// Schools
		/// 
		/// </summary>
		public string Schools
		{
			get { return  strSchools; }
			set { strSchools = value; }
		}

		/// <summary>
		/// Jobs
		/// 
		/// </summary>
		public string Jobs
		{
			get { return  strJobs; }
			set { strJobs = value; }
		}

		/// <summary>
		/// Gender
		/// 
		/// </summary>
		public string Gender
		{
			get { return  strGender; }
			set { strGender = value; }
		}

		/// <summary>
		/// DeathDate
		/// 
		/// </summary>
		public string DeathDate
		{
			get { return  strDeathDate; }
			set { strDeathDate = value; }
		}

		/// <summary>
		/// Hometown
		/// quê quán
		/// </summary>
		public string Hometown
		{
			get { return  strHometown; }
			set { strHometown = value; }
		}

		/// <summary>
		/// BirthPlace
		/// Nơi sinh
		/// </summary>
		public string BirthPlace
		{
			get { return  strBirthPlace; }
			set { strBirthPlace = value; }
		}

		/// <summary>
		/// Status
		/// 0 - độc thân, 1- đã kết hôn
		/// </summary>
		public int Status
		{
			get { return  intStatus; }
			set { intStatus = value; }
		}

		/// <summary>
		/// FirstName
		/// 
		/// </summary>
		public string FirstName
		{
			get { return  strFirstName; }
			set { strFirstName = value; }
		}

		/// <summary>
		/// LastName
		/// 
		/// </summary>
		public string LastName
		{
			get { return  strLastName; }
			set { strLastName = value; }
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
		/// Mobile
		/// 
		/// </summary>
		public string Mobile
		{
			get { return  strMobile; }
			set { strMobile = value; }
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

		public GENUsers()
		{
		}
		private static GENUsers _current;
		static GENUsers()
		{
			_current = new GENUsers();
		}
		public static GENUsers Current
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
				objData.CreateNewStoredProcedure("GEN_Users_SEL");
				objData.AddParameter("@UserID", this.UserID);
				IDataReader reader = objData.ExecStoreToDataReader();
				if (reader.Read())
 				{
					if(!this.IsDBNull(reader["UserID"]))	this.UserID = Convert.ToInt32(reader["UserID"]);
					if(!this.IsDBNull(reader["Password"]))	this.Password = Convert.ToString(reader["Password"]);
					if(!this.IsDBNull(reader["NickName"]))	this.NickName = Convert.ToString(reader["NickName"]);
					if(!this.IsDBNull(reader["IsLogin"]))	this.IsLogin = Convert.ToBoolean(reader["IsLogin"]);
					if(!this.IsDBNull(reader["IsAdmin"]))	this.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
					if(!this.IsDBNull(reader["Birthday"]))	this.Birthday = Convert.ToString(reader["Birthday"]);
					if(!this.IsDBNull(reader["AboutMe"]))	this.AboutMe = Convert.ToString(reader["AboutMe"]);
					if(!this.IsDBNull(reader["Hobby"]))	this.Hobby = Convert.ToString(reader["Hobby"]);
					if(!this.IsDBNull(reader["Email"]))	this.Email = Convert.ToString(reader["Email"]);
					if(!this.IsDBNull(reader["Address"]))	this.Address = Convert.ToString(reader["Address"]);
					if(!this.IsDBNull(reader["Schools"]))	this.Schools = Convert.ToString(reader["Schools"]);
					if(!this.IsDBNull(reader["Jobs"]))	this.Jobs = Convert.ToString(reader["Jobs"]);
					if(!this.IsDBNull(reader["Gender"]))	this.Gender = Convert.ToString(reader["Gender"]);
					if(!this.IsDBNull(reader["DeathDate"]))	this.DeathDate = Convert.ToString(reader["DeathDate"]);
					if(!this.IsDBNull(reader["Hometown"]))	this.Hometown = Convert.ToString(reader["Hometown"]);
					if(!this.IsDBNull(reader["BirthPlace"]))	this.BirthPlace = Convert.ToString(reader["BirthPlace"]);
					if(!this.IsDBNull(reader["Status"]))	this.Status = Convert.ToInt32(reader["Status"]);
					if(!this.IsDBNull(reader["FirstName"]))	this.FirstName = Convert.ToString(reader["FirstName"]);
					if(!this.IsDBNull(reader["LastName"]))	this.LastName = Convert.ToString(reader["LastName"]);
					if(!this.IsDBNull(reader["FullName"]))	this.FullName = Convert.ToString(reader["FullName"]);
					if(!this.IsDBNull(reader["Mobile"]))	this.Mobile = Convert.ToString(reader["Mobile"]);
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
		/// Insert : GEN_Users
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
				objData.CreateNewStoredProcedure("GEN_Users_ADD");
				if(this.UserID != int.MinValue) objData.AddParameter("@UserID", this.UserID);
				objData.AddParameter("@Password", this.Password);
				objData.AddParameter("@NickName", this.NickName);
				objData.AddParameter("@IsLogin", this.IsLogin);
				objData.AddParameter("@IsAdmin", this.IsAdmin);
				objData.AddParameter("@Birthday", this.Birthday);
				objData.AddParameter("@AboutMe", this.AboutMe);
				objData.AddParameter("@Hobby", this.Hobby);
				objData.AddParameter("@Email", this.Email);
				objData.AddParameter("@Address", this.Address);
				objData.AddParameter("@Schools", this.Schools);
				objData.AddParameter("@Jobs", this.Jobs);
				objData.AddParameter("@Gender", this.Gender);
				objData.AddParameter("@DeathDate", this.DeathDate);
				objData.AddParameter("@Hometown", this.Hometown);
				objData.AddParameter("@BirthPlace", this.BirthPlace);
				if(this.Status != int.MinValue) objData.AddParameter("@Status", this.Status);
				objData.AddParameter("@FirstName", this.FirstName);
				objData.AddParameter("@LastName", this.LastName);
				objData.AddParameter("@FullName", this.FullName);
				objData.AddParameter("@Mobile", this.Mobile);
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
		/// Update : GEN_Users
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
				objData.CreateNewStoredProcedure("GEN_Users_UPD");
				if(this.UserID != int.MinValue)	objData.AddParameter("@UserID", this.UserID);
				else objData.AddParameter("@UserID", DBNull.Value);
				objData.AddParameter("@Password", this.Password);
				objData.AddParameter("@NickName", this.NickName);
				objData.AddParameter("@IsLogin", this.IsLogin);
				objData.AddParameter("@IsAdmin", this.IsAdmin);
				objData.AddParameter("@Birthday", this.Birthday);
				objData.AddParameter("@AboutMe", this.AboutMe);
				objData.AddParameter("@Hobby", this.Hobby);
				objData.AddParameter("@Email", this.Email);
				objData.AddParameter("@Address", this.Address);
				objData.AddParameter("@Schools", this.Schools);
				objData.AddParameter("@Jobs", this.Jobs);
				objData.AddParameter("@Gender", this.Gender);
				objData.AddParameter("@DeathDate", this.DeathDate);
				objData.AddParameter("@Hometown", this.Hometown);
				objData.AddParameter("@BirthPlace", this.BirthPlace);
				if(this.Status != int.MinValue)	objData.AddParameter("@Status", this.Status);
				else objData.AddParameter("@Status", DBNull.Value);
				objData.AddParameter("@FirstName", this.FirstName);
				objData.AddParameter("@LastName", this.LastName);
				objData.AddParameter("@FullName", this.FullName);
				objData.AddParameter("@Mobile", this.Mobile);
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
		/// Delete : GEN_Users
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
				objData.CreateNewStoredProcedure("GEN_Users_DEL");
				objData.AddParameter("@UserID", this.UserID);
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
		/// Get all : GEN_Users
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
				objData.CreateNewStoredProcedure("GEN_UsersSRH");
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
		 	GEN_Users objGEN_Users = new GEN_Users();
			objGENUsers.UserID = txtUserID.Text;
			objGENUsers.Password = txtPassword.Text;
			objGENUsers.NickName = txtNickName.Text;
			objGENUsers.IsLogin = txtIsLogin.Text;
			objGENUsers.IsAdmin = txtIsAdmin.Text;
			objGENUsers.Birthday = txtBirthday.Text;
			objGENUsers.AboutMe = txtAboutMe.Text;
			objGENUsers.Hobby = txtHobby.Text;
			objGENUsers.Email = txtEmail.Text;
			objGENUsers.Address = txtAddress.Text;
			objGENUsers.Schools = txtSchools.Text;
			objGENUsers.Jobs = txtJobs.Text;
			objGENUsers.Gender = txtGender.Text;
			objGENUsers.DeathDate = txtDeathDate.Text;
			objGENUsers.Hometown = txtHometown.Text;
			objGENUsers.BirthPlace = txtBirthPlace.Text;
			objGENUsers.Status = txtStatus.Text;
			objGENUsers.FirstName = txtFirstName.Text;
			objGENUsers.LastName = txtLastName.Text;
			objGENUsers.FullName = txtFullName.Text;
			objGENUsers.Mobile = txtMobile.Text;
			objGENUsers.IsActived = txtIsActived.Text;
			objGENUsers.IsDeleted = txtIsDeleted.Text;
			objGENUsers.CreatedUserID = txtCreatedUserID.Text;
			objGENUsers.CreatedDate = txtCreatedDate.Text;
			objGENUsers.UpdatedUserID = txtUpdatedUserID.Text;
			objGENUsers.UpdatedDate = txtUpdatedDate.Text;
			objGENUsers.DeletedUserID = txtDeletedUserID.Text;
			objGENUsers.DeletedDate = txtDeletedDate.Text;

		 
		 ******************************************************
		 
		 			txtUserID.Text = objGENUsers.UserID;
			txtPassword.Text = objGENUsers.Password;
			txtNickName.Text = objGENUsers.NickName;
			txtIsLogin.Text = objGENUsers.IsLogin;
			txtIsAdmin.Text = objGENUsers.IsAdmin;
			txtBirthday.Text = objGENUsers.Birthday;
			txtAboutMe.Text = objGENUsers.AboutMe;
			txtHobby.Text = objGENUsers.Hobby;
			txtEmail.Text = objGENUsers.Email;
			txtAddress.Text = objGENUsers.Address;
			txtSchools.Text = objGENUsers.Schools;
			txtJobs.Text = objGENUsers.Jobs;
			txtGender.Text = objGENUsers.Gender;
			txtDeathDate.Text = objGENUsers.DeathDate;
			txtHometown.Text = objGENUsers.Hometown;
			txtBirthPlace.Text = objGENUsers.BirthPlace;
			txtStatus.Text = objGENUsers.Status;
			txtFirstName.Text = objGENUsers.FirstName;
			txtLastName.Text = objGENUsers.LastName;
			txtFullName.Text = objGENUsers.FullName;
			txtMobile.Text = objGENUsers.Mobile;
			txtIsActived.Text = objGENUsers.IsActived;
			txtIsDeleted.Text = objGENUsers.IsDeleted;
			txtCreatedUserID.Text = objGENUsers.CreatedUserID;
			txtCreatedDate.Text = objGENUsers.CreatedDate;
			txtUpdatedUserID.Text = objGENUsers.UpdatedUserID;
			txtUpdatedDate.Text = objGENUsers.UpdatedDate;
			txtDeletedUserID.Text = objGENUsers.DeletedUserID;
			txtDeletedDate.Text = objGENUsers.DeletedDate;

		 
		*******************************************************/
		
	}
}

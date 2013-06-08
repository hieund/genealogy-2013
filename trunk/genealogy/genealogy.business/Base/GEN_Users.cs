
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
    /// Created date 	: 4/19/2013 
    /// Description 
    /// </summary>	
    public class GENUsers
    {

        #region Member Variables

        private int intUserID = int.MinValue;
        private int intUserRelationId = 0;
        private string strPassword = string.Empty;
        private string strNickName = string.Empty;
        private bool bolIsLogin;
        private bool bolIsAdmin;
        private DateTime? dtmBirthday = null;
        private string strAboutMe = string.Empty;
        private string strHobby = string.Empty;
        private string strEmail = string.Empty;
        private string strAddress = string.Empty;
        private string strAvatar = string.Empty;
        private string strSchools = string.Empty;
        private string strJobs = string.Empty;
        private int intGender;
        private DateTime? dtmDeathDate = null;
        private string strCurrentPlace = string.Empty;
        private string strBirthPlace = string.Empty;
        private int intStatus = int.MinValue;
        private int intCurrentProvinceID = int.MinValue;
        private int intBirthProvinceID = int.MinValue;
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
            get { return "GENUsers_GetAll"; }
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
            get { return intUserID; }
            set { intUserID = value; }
        }

        /// <summary>
        /// Password
        /// 
        /// </summary>
        public string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }

        /// <summary>
        /// NickName
        /// 
        /// </summary>
        public string NickName
        {
            get { return strNickName; }
            set { strNickName = value; }
        }
        public string Avatar
        {
            get { return strAvatar; }
            set { strAvatar = value; }
        }
        /// <summary>
        /// IsLogin
        /// 
        /// </summary>
        public bool IsLogin
        {
            get { return bolIsLogin; }
            set { bolIsLogin = value; }
        }

        /// <summary>
        /// IsAdmin
        /// 
        /// </summary>
        public bool IsAdmin
        {
            get { return bolIsAdmin; }
            set { bolIsAdmin = value; }
        }

        /// <summary>
        /// Birthday
        /// 
        /// </summary>
        public DateTime Birthday
        {
            get;
            set;
        }

        /// <summary>
        /// AboutMe
        /// 
        /// </summary>
        public string AboutMe
        {
            get { return strAboutMe; }
            set { strAboutMe = value; }
        }

        /// <summary>
        /// Hobby
        /// 
        /// </summary>
        public string Hobby
        {
            get { return strHobby; }
            set { strHobby = value; }
        }

        /// <summary>
        /// Email
        /// 
        /// </summary>
        public string Email
        {
            get { return strEmail; }
            set { strEmail = value; }
        }

        /// <summary>
        /// Address
        /// 
        /// </summary>
        public string Address
        {
            get { return strAddress; }
            set { strAddress = value; }
        }

        /// <summary>
        /// Schools
        /// 
        /// </summary>
        public string Schools
        {
            get { return strSchools; }
            set { strSchools = value; }
        }

        /// <summary>
        /// Jobs
        /// 
        /// </summary>
        public string Jobs
        {
            get { return strJobs; }
            set { strJobs = value; }
        }

        /// <summary>
        /// Gender
        /// 
        /// </summary>
        public int Gender
        {
            get { return intGender; }
            set { intGender = value; }
        }

        /// <summary>
        /// DeathDate
        /// 
        /// </summary>
        public DateTime? DeathDate
        {
            get { return dtmDeathDate; }
            set { dtmDeathDate = value; }
        }

        /// <summary>
        /// CurrentPlace
        /// quê quán
        /// </summary>
        public string CurrentPlace
        {
            get { return strCurrentPlace; }
            set { strCurrentPlace = value; }
        }

        /// <summary>
        /// BirthPlace
        /// Nơi sinh
        /// </summary>
        public string BirthPlace
        {
            get { return strBirthPlace; }
            set { strBirthPlace = value; }
        }

        /// <summary>
        /// Status
        /// 0 - độc thân, 1- đã kết hôn
        /// </summary>
        public int Status
        {
            get { return intStatus; }
            set { intStatus = value; }
        }

        /// <summary>
        /// FirstName
        /// 
        /// </summary>
        public string FirstName
        {
            get { return strFirstName; }
            set { strFirstName = value; }
        }

        /// <summary>
        /// LastName
        /// 
        /// </summary>
        public string LastName
        {
            get { return strLastName; }
            set { strLastName = value; }
        }

        /// <summary>
        /// FullName
        /// 
        /// </summary>
        public string FullName
        {
            get { return strFullName; }
            set { strFullName = value; }
        }

        /// <summary>
        /// Mobile
        /// 
        /// </summary>
        public string Mobile
        {
            get { return strMobile; }
            set { strMobile = value; }
        }

        /// <summary>
        /// IsActived
        /// 
        /// </summary>
        public bool IsActived
        {
            get { return bolIsActived; }
            set { bolIsActived = value; }
        }

        /// <summary>
        /// IsDeleted
        /// 
        /// </summary>
        public bool IsDeleted
        {
            get { return bolIsDeleted; }
            set { bolIsDeleted = value; }
        }

        /// <summary>
        /// CreatedUserID
        /// 
        /// </summary>
        public int CreatedUserID
        {
            get { return intCreatedUserID; }
            set { intCreatedUserID = value; }
        }

        /// <summary>
        /// CreatedDate
        /// 
        /// </summary>
        public DateTime CreatedDate
        {
            get { return dtmCreatedDate; }
            set { dtmCreatedDate = value; }
        }

        /// <summary>
        /// UpdatedUserID
        /// 
        /// </summary>
        public int UpdatedUserID
        {
            get { return intUpdatedUserID; }
            set { intUpdatedUserID = value; }
        }

        /// <summary>
        /// UpdatedDate
        /// 
        /// </summary>
        public DateTime UpdatedDate
        {
            get { return dtmUpdatedDate; }
            set { dtmUpdatedDate = value; }
        }

        /// <summary>
        /// DeletedUserID
        /// 
        /// </summary>
        public int DeletedUserID
        {
            get { return intDeletedUserID; }
            set { intDeletedUserID = value; }
        }

        /// <summary>
        /// DeletedDate
        /// 
        /// </summary>
        public DateTime DeletedDate
        {
            get { return dtmDeletedDate; }
            set { dtmDeletedDate = value; }
        }

        public int CurrentProvinceID
        {
            get { return intCurrentProvinceID; }
            set { intCurrentProvinceID = value; }
        }

        public int BirthProvinceID
        {
            get { return intBirthProvinceID; }
            set { intBirthProvinceID = value; }
        }

        public int UserRelationID
        {
            get { return intUserRelationId; }
            set { intUserRelationId = value; }
        }

        public int? RelationTypeId
        {
            get;
            set;
        }

        public string RelationTypeName
        {
            get;
            set;
        }

        public int OrderPostiion { get; set; }

        public int Level { get; set; }

        public int ParentID { get; set; }

        public string ListWife { get; set; }

        public string ListWifeName { get; set; }

        public bool IsInGenealogy { get; set; }

        public string KitoName { get; set; }
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
                    if (!this.IsDBNull(reader["UserID"])) this.UserID = Convert.ToInt32(reader["UserID"]);
                    //if (!this.IsDBNull(reader["Password"])) this.Password = Convert.ToString(reader["Password"]);
                    if (!this.IsDBNull(reader["NickName"])) this.NickName = Convert.ToString(reader["NickName"]);
                    if (!this.IsDBNull(reader["IsLogin"])) this.IsLogin = Convert.ToBoolean(reader["IsLogin"]);
                    if (!this.IsDBNull(reader["IsAdmin"])) this.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                    if (!this.IsDBNull(reader["Birthday"])) this.Birthday = Convert.ToDateTime(reader["Birthday"]);
                    if (!this.IsDBNull(reader["AboutMe"])) this.AboutMe = Convert.ToString(reader["AboutMe"]);
                    if (!this.IsDBNull(reader["Hobby"])) this.Hobby = Convert.ToString(reader["Hobby"]);
                    if (!this.IsDBNull(reader["Avatar"])) this.Avatar = Convert.ToString(reader["Avatar"]);
                    if (!this.IsDBNull(reader["Email"])) this.Email = Convert.ToString(reader["Email"]);
                    if (!this.IsDBNull(reader["Address"])) this.Address = Convert.ToString(reader["Address"]);
                    if (!this.IsDBNull(reader["Schools"])) this.Schools = Convert.ToString(reader["Schools"]);
                    if (!this.IsDBNull(reader["Jobs"])) this.Jobs = Convert.ToString(reader["Jobs"]);
                    if (!this.IsDBNull(reader["Gender"])) this.Gender = Convert.ToInt32(reader["Gender"]);
                    if (!this.IsDBNull(reader["DeathDate"])) this.DeathDate = Convert.ToDateTime(reader["DeathDate"]);
                    if (!this.IsDBNull(reader["CurrentPlace"])) this.CurrentPlace = Convert.ToString(reader["CurrentPlace"]);
                    if (!this.IsDBNull(reader["BirthPlace"])) this.BirthPlace = Convert.ToString(reader["BirthPlace"]);
                    if (!this.IsDBNull(reader["Status"])) this.Status = Convert.ToInt32(reader["Status"]);
                    if (!this.IsDBNull(reader["FirstName"])) this.FirstName = Convert.ToString(reader["FirstName"]);
                    if (!this.IsDBNull(reader["LastName"])) this.LastName = Convert.ToString(reader["LastName"]);
                    if (!this.IsDBNull(reader["FullName"])) this.FullName = Convert.ToString(reader["FullName"]);
                    if (!this.IsDBNull(reader["Mobile"])) this.Mobile = Convert.ToString(reader["Mobile"]);
                    if (!this.IsDBNull(reader["IsActived"])) this.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) this.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) this.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) this.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) this.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) this.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) this.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) this.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    if (!this.IsDBNull(reader["CurrentProvinceID"])) this.CurrentProvinceID = Convert.ToInt32(reader["CurrentProvinceID"]);
                    if (!this.IsDBNull(reader["BirthProvinceID"])) this.BirthProvinceID = Convert.ToInt32(reader["BirthProvinceID"]);
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
                objData.AddParameter("@Password", this.Password);
                objData.AddParameter("@NickName", this.NickName);
                objData.AddParameter("@IsLogin", this.IsLogin);
                objData.AddParameter("@IsAdmin", this.IsAdmin);
                if (this.Birthday != null) objData.AddParameter("@Birthday", this.Birthday);
                objData.AddParameter("@AboutMe", this.AboutMe);
                objData.AddParameter("@Hobby", this.Hobby);
                objData.AddParameter("@Email", this.Email);
                objData.AddParameter("@CurrentPlace", this.CurrentPlace);
                objData.AddParameter("@Schools", this.Schools);
                objData.AddParameter("@Jobs", this.Jobs);
                objData.AddParameter("@Gender", this.Gender);
                if (this.DeathDate != null) objData.AddParameter("@DeathDate", this.DeathDate); 
                objData.AddParameter("@Avatar", this.Avatar);
                objData.AddParameter("@BirthPlace", this.BirthPlace);
                objData.AddParameter("@FirstName", this.FirstName);
                objData.AddParameter("@LastName", this.LastName);
                objData.AddParameter("@FullName", this.FullName);
                objData.AddParameter("@Mobile", this.Mobile);
                objData.AddParameter("@IsActived", this.IsActived);
                if (this.CreatedUserID != int.MinValue) objData.AddParameter("@CreatedUserID", this.CreatedUserID);
                objData.AddParameter("@CurrentProvinceID", this.CurrentProvinceID);
                objData.AddParameter("@BirthProvinceID", this.BirthProvinceID);
                objTemp = objData.ExecStoreToDataTable().Rows[0][0];
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
                objData.AddParameter("@UserID", this.UserID);
                objData.AddParameter("@Password", this.Password);
                objData.AddParameter("@NickName", this.NickName);
                objData.AddParameter("@IsLogin", this.IsLogin);
                objData.AddParameter("@IsAdmin", this.IsAdmin);
                objData.AddParameter("@Birthday", this.Birthday);
                objData.AddParameter("@AboutMe", this.AboutMe);
                objData.AddParameter("@Hobby", this.Hobby);
                objData.AddParameter("@Email", this.Email);
                objData.AddParameter("@CurrentPlace", this.CurrentPlace);
                objData.AddParameter("@Schools", this.Schools);
                objData.AddParameter("@Jobs", this.Jobs);
                objData.AddParameter("@Gender", this.Gender);
                objData.AddParameter("@DeathDate", this.DeathDate);
                objData.AddParameter("@CurrentPlace", this.CurrentPlace);
                objData.AddParameter("@Avatar", this.Avatar);
                objData.AddParameter("@BirthPlace", this.BirthPlace);
                objData.AddParameter("@FirstName", this.FirstName);
                objData.AddParameter("@LastName", this.LastName);
                objData.AddParameter("@FullName", this.FullName);
                objData.AddParameter("@Mobile", this.Mobile);
                objData.AddParameter("@Status", this.Status);
                objData.AddParameter("@IsActived", this.IsActived);
                objData.AddParameter("@UpdatedUserID", this.UpdatedUserID);
                objData.AddParameter("@CurrentProvinceID", this.CurrentProvinceID);
                objData.AddParameter("@BirthProvinceID", this.BirthProvinceID);
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
                objData.AddParameter("@DeletedUserID", this.DeletedUserID);
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
                objData.CreateNewStoredProcedure("GEN_Users_SRH");
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

        public bool Login()
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
                objData.CreateNewStoredProcedure("GEN_Users_CheckLogin");
                objData.AddParameter("@Email", this.Email);
                objData.AddParameter("@Password", this.Password);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (!this.IsDBNull(reader["UserID"])) this.UserID = Convert.ToInt32(reader["UserID"]);
                    if (!this.IsDBNull(reader["Password"])) this.Password = Convert.ToString(reader["Password"]);
                    if (!this.IsDBNull(reader["NickName"])) this.NickName = Convert.ToString(reader["NickName"]);
                    if (!this.IsDBNull(reader["IsLogin"])) this.IsLogin = Convert.ToBoolean(reader["IsLogin"]);
                    if (!this.IsDBNull(reader["IsAdmin"])) this.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                    if (!this.IsDBNull(reader["Birthday"])) this.Birthday = Convert.ToDateTime(reader["Birthday"]);
                    if (!this.IsDBNull(reader["AboutMe"])) this.AboutMe = Convert.ToString(reader["AboutMe"]);
                    if (!this.IsDBNull(reader["Hobby"])) this.Hobby = Convert.ToString(reader["Hobby"]);
                    if (!this.IsDBNull(reader["Avatar"])) this.Avatar = Convert.ToString(reader["Avatar"]);
                    if (!this.IsDBNull(reader["Email"])) this.Email = Convert.ToString(reader["Email"]);
                    if (!this.IsDBNull(reader["Address"])) this.Address = Convert.ToString(reader["Address"]);
                    if (!this.IsDBNull(reader["Schools"])) this.Schools = Convert.ToString(reader["Schools"]);
                    if (!this.IsDBNull(reader["Jobs"])) this.Jobs = Convert.ToString(reader["Jobs"]);
                    if (!this.IsDBNull(reader["Gender"])) this.Gender = Convert.ToInt32(reader["Gender"]);
                    if (!this.IsDBNull(reader["DeathDate"])) this.DeathDate = Convert.ToDateTime(reader["DeathDate"]);
                    if (!this.IsDBNull(reader["CurrentPlace"])) this.CurrentPlace = Convert.ToString(reader["CurrentPlace"]);
                    if (!this.IsDBNull(reader["BirthPlace"])) this.BirthPlace = Convert.ToString(reader["BirthPlace"]);
                    if (!this.IsDBNull(reader["Status"])) this.Status = Convert.ToInt32(reader["Status"]);
                    if (!this.IsDBNull(reader["FirstName"])) this.FirstName = Convert.ToString(reader["FirstName"]);
                    if (!this.IsDBNull(reader["LastName"])) this.LastName = Convert.ToString(reader["LastName"]);
                    if (!this.IsDBNull(reader["FullName"])) this.FullName = Convert.ToString(reader["FullName"]);
                    if (!this.IsDBNull(reader["Mobile"])) this.Mobile = Convert.ToString(reader["Mobile"]);
                    if (!this.IsDBNull(reader["IsActived"])) this.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) this.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) this.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) this.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) this.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) this.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) this.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) this.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    if (!this.IsDBNull(reader["CurrentProvinceID"])) this.CurrentProvinceID = Convert.ToInt32(reader["CurrentProvinceID"]);
                    if (!this.IsDBNull(reader["BirthProvinceID"])) this.BirthProvinceID = Convert.ToInt32(reader["BirthProvinceID"]);
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
            objGENUsers.CurrentPlace = txtCurrentPlace.Text;
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
            txtCurrentPlace.Text = objGENUsers.CurrentPlace;
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

        #region Function Support
        public List<GENUsers> Search(string strkeyword, int intPageSize, int intPageIndex, ref int intTotalCount)
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;
            List<GENUsers> lst = new List<GENUsers>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("GEN_Users_SRH");
                objData.AddParameter("@KeyWord", strkeyword);
                objData.AddParameter("@PageSize", intPageSize);
                objData.AddParameter("@PageIndex", intPageIndex);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    GENUsers objGD = new GENUsers();
                    if (!this.IsDBNull(reader["TotalCount"])) intTotalCount = Convert.ToInt32(reader["TotalCount"]);

                    if (!this.IsDBNull(reader["UserID"])) objGD.UserID = Convert.ToInt32(reader["UserID"]);
                    if (!this.IsDBNull(reader["NickName"])) objGD.NickName = Convert.ToString(reader["NickName"]);
                    if (!this.IsDBNull(reader["IsLogin"])) objGD.IsLogin = Convert.ToBoolean(reader["IsLogin"]);
                    if (!this.IsDBNull(reader["IsAdmin"])) objGD.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
                    if (!this.IsDBNull(reader["Birthday"])) objGD.Birthday = Convert.ToDateTime(reader["Birthday"]);
                    if (!this.IsDBNull(reader["AboutMe"])) objGD.AboutMe = Convert.ToString(reader["AboutMe"]);
                    if (!this.IsDBNull(reader["Hobby"])) objGD.Hobby = Convert.ToString(reader["Hobby"]);
                    if (!this.IsDBNull(reader["Email"])) objGD.Email = Convert.ToString(reader["Email"]);
                    if (!this.IsDBNull(reader["Schools"])) objGD.Schools = Convert.ToString(reader["Schools"]);
                    if (!this.IsDBNull(reader["Jobs"])) objGD.Jobs = Convert.ToString(reader["Jobs"]);
                    if (!this.IsDBNull(reader["Gender"])) objGD.Gender = Convert.ToInt32(reader["Gender"]);
                    if (!this.IsDBNull(reader["DeathDate"])) objGD.DeathDate = Convert.ToDateTime(reader["DeathDate"]);
                    if (!this.IsDBNull(reader["CurrentPlace"])) objGD.CurrentPlace = Convert.ToString(reader["CurrentPlace"]);
                    if (!this.IsDBNull(reader["BirthPlace"])) objGD.BirthPlace = Convert.ToString(reader["BirthPlace"]);
                    if (!this.IsDBNull(reader["Status"])) objGD.Status = Convert.ToInt32(reader["Status"]);
                    if (!this.IsDBNull(reader["FirstName"])) objGD.FirstName = Convert.ToString(reader["FirstName"]);
                    if (!this.IsDBNull(reader["DeathDate"])) objGD.LastName = Convert.ToString(reader["LastName"]);
                    if (!this.IsDBNull(reader["FullName"])) objGD.FullName = Convert.ToString(reader["FullName"]);
                    if (!this.IsDBNull(reader["Mobile"])) objGD.Mobile = Convert.ToString(reader["Mobile"]);
                    if (!this.IsDBNull(reader["CurrentProvinceID"])) objGD.Status = Convert.ToInt32(reader["CurrentProvinceID"]);
                    if (!this.IsDBNull(reader["BirthProvinceID"])) objGD.Status = Convert.ToInt32(reader["BirthProvinceID"]);
                    if (!this.IsDBNull(reader["IsInGenealogy"])) objGD.IsInGenealogy = Convert.ToBoolean(reader["IsInGenealogy"]);
                    if (!this.IsDBNull(reader["IsActived"])) objGD.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) objGD.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) objGD.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) objGD.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) objGD.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) objGD.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) objGD.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) objGD.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) objGD.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    lst.Add(objGD);
                }
                reader.Close();
            }
            catch (Exception objEx)
            {
                new SystemMessage("Search() Error", "", objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
            }
            return lst;
        }

        public List<GENUsers> GetUserRelationsByUserId(int UserId)
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;
            List<GENUsers> lst = new List<GENUsers>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("GF_User_Relations_ByUserId");
                objData.AddParameter("@UserID", UserId);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    GENUsers objGD = new GENUsers();
                    if (!this.IsDBNull(reader["UserID"])) objGD.UserID = Convert.ToInt32(reader["UserID"]);
                    if (!this.IsDBNull(reader["UserRelationID"])) objGD.UserRelationID = Convert.ToInt32(reader["UserRelationID"]);
                    if (!this.IsDBNull(reader["RelationTypeId"])) objGD.RelationTypeId = Convert.ToInt32(reader["RelationTypeId"]);
                    if (!this.IsDBNull(reader["RelationTypeName"])) objGD.RelationTypeName = Convert.ToString(reader["RelationTypeName"]);
                    if (!this.IsDBNull(reader["FullName"])) objGD.FullName = Convert.ToString(reader["FullName"]);
                    if (!this.IsDBNull(reader["Birthday"])) objGD.Birthday = Convert.ToDateTime(reader["Birthday"]);
                    lst.Add(objGD);
                }
                reader.Close();
            }
            catch (Exception objEx)
            {
                new SystemMessage("GetUserRelationsByUserId() Error", "", objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
            }
            return lst;
        }

        public List<GENUsers> GetUserForTree()
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;
            List<GENUsers> lst = new List<GENUsers>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("GL_GenealogyTree");
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    GENUsers objGD = new GENUsers();
                    if (!this.IsDBNull(reader["UserID"])) objGD.UserID = Convert.ToInt32(reader["UserID"]);
                    if (!this.IsDBNull(reader["ParentID"])) objGD.ParentID = Convert.ToInt32(reader["ParentID"]);
                    if (!this.IsDBNull(reader["Level"])) objGD.Level = Convert.ToInt32(reader["Level"]);
                    if (!this.IsDBNull(reader["ListWife"])) objGD.ListWife = Convert.ToString(reader["ListWife"]);
                    if (!this.IsDBNull(reader["ListWifeName"])) objGD.ListWifeName = Convert.ToString(reader["ListWifeName"]);
                    if (!this.IsDBNull(reader["FullName"])) objGD.FullName = Convert.ToString(reader["FullName"]);
                    if (!this.IsDBNull(reader["Birthday"])) objGD.Birthday = Convert.ToDateTime(reader["Birthday"]);

                    lst.Add(objGD);
                }
                reader.Close();
            }
            catch (Exception objEx)
            {
                new SystemMessage("GL_GenealogyTree() Error", "", objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
            }
            return lst;
        }

        public DataTable GetFamilyByUserId(int userId)
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
                objData.CreateNewStoredProcedure("GEN_Users_GetFamily_ByUserID");
                objData.AddParameter("@UserID", userId);
                return objData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                throw new Exception("GEN_Users_GetFamily_ByUserID() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
            }
        }
        #endregion

    }
}

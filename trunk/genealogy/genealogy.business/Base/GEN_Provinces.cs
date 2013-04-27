
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
    /// Created date 	: 4/23/2013 
    /// Description 
    /// </summary>	
    public class GENProvinces
    {



        #region Member Variables

        private int intProvinceID = int.MinValue;
        private string strProvinceName = string.Empty;
        private int intAreaID = int.MinValue;
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
            get { return "GENProvinces_GetAll"; }
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
        /// ProvinceID
        /// 
        /// </summary>
        public int ProvinceID
        {
            get { return intProvinceID; }
            set { intProvinceID = value; }
        }

        /// <summary>
        /// ProvinceName
        /// 
        /// </summary>
        public string ProvinceName
        {
            get { return strProvinceName; }
            set { strProvinceName = value; }
        }

        /// <summary>
        /// AreaID
        /// 
        /// </summary>
        public int AreaID
        {
            get { return intAreaID; }
            set { intAreaID = value; }
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


        #endregion


        #region Constructor

        public GENProvinces()
        {
        }
        private static GENProvinces _current;
        static GENProvinces()
        {
            _current = new GENProvinces();
        }
        public static GENProvinces Current
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
                objData.CreateNewStoredProcedure("GEN_Provinces_SEL");
                objData.AddParameter("@ProvinceID", this.ProvinceID);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (!this.IsDBNull(reader["ProvinceID"])) this.ProvinceID = Convert.ToInt32(reader["ProvinceID"]);
                    if (!this.IsDBNull(reader["ProvinceName"])) this.ProvinceName = Convert.ToString(reader["ProvinceName"]);
                    if (!this.IsDBNull(reader["AreaID"])) this.AreaID = Convert.ToInt32(reader["AreaID"]);
                    if (!this.IsDBNull(reader["IsActived"])) this.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) this.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) this.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) this.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) this.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) this.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) this.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) this.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
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
        /// Insert : GEN_Provinces
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
                objData.CreateNewStoredProcedure("GEN_Provinces_ADD");
                if (this.ProvinceID != int.MinValue) objData.AddParameter("@ProvinceID", this.ProvinceID);
                objData.AddParameter("@ProvinceName", this.ProvinceName);
                if (this.AreaID != int.MinValue) objData.AddParameter("@AreaID", this.AreaID);
                objData.AddParameter("@IsActived", this.IsActived);
                if (this.CreatedUserID != int.MinValue) objData.AddParameter("@CreatedUserID", this.CreatedUserID);
                if (this.UpdatedUserID != int.MinValue) objData.AddParameter("@UpdatedUserID", this.UpdatedUserID);
                if (this.DeletedUserID != int.MinValue) objData.AddParameter("@DeletedUserID", this.DeletedUserID);
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
        /// Update : GEN_Provinces
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
                objData.CreateNewStoredProcedure("GEN_Provinces_UPD");
                if (this.ProvinceID != int.MinValue) objData.AddParameter("@ProvinceID", this.ProvinceID);
                else objData.AddParameter("@ProvinceID", DBNull.Value);
                objData.AddParameter("@ProvinceName", this.ProvinceName);
                if (this.AreaID != int.MinValue) objData.AddParameter("@AreaID", this.AreaID);
                else objData.AddParameter("@AreaID", DBNull.Value);
                objData.AddParameter("@IsActived", this.IsActived);
                if (this.CreatedUserID != int.MinValue) objData.AddParameter("@CreatedUserID", this.CreatedUserID);
                else objData.AddParameter("@CreatedUserID", DBNull.Value);
                if (this.UpdatedUserID != int.MinValue) objData.AddParameter("@UpdatedUserID", this.UpdatedUserID);
                else objData.AddParameter("@UpdatedUserID", DBNull.Value);
                if (this.DeletedUserID != int.MinValue) objData.AddParameter("@DeletedUserID", this.DeletedUserID);
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
        /// Delete : GEN_Provinces
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
                objData.CreateNewStoredProcedure("GEN_Provinces_DEL");
                objData.AddParameter("@ProvinceID", this.ProvinceID);
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
        /// Get all : GEN_Provinces
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
                objData.CreateNewStoredProcedure("GEN_Provinces_SRH");
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

        ///<summary>
        /// Get all : GEN_Provinces
        ///
        ///</summary>
        public List<GENProvinces> GetAllProvince()
        {

            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;
            List<GENProvinces> lst = new List<GENProvinces>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("GEN_Provinces_GetAll");
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    GENProvinces objP = new GENProvinces();
                    if (!this.IsDBNull(reader["ProvinceID"])) objP.ProvinceID = Convert.ToInt32(reader["ProvinceID"]);
                    if (!this.IsDBNull(reader["ProvinceName"])) objP.ProvinceName = Convert.ToString(reader["ProvinceName"]);
                    if (!this.IsDBNull(reader["AreaID"])) objP.AreaID = Convert.ToInt32(reader["AreaID"]);
                    if (!this.IsDBNull(reader["IsActived"])) objP.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) objP.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) objP.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) objP.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) objP.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) objP.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) objP.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) objP.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    lst.Add(objP);
                }
                reader.Close();
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
            return lst;
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
            GEN_Provinces objGEN_Provinces = new GEN_Provinces();
            objGENProvinces.ProvinceID = txtProvinceID.Text;
            objGENProvinces.ProvinceName = txtProvinceName.Text;
            objGENProvinces.AreaID = txtAreaID.Text;
            objGENProvinces.IsActived = txtIsActived.Text;
            objGENProvinces.IsDeleted = txtIsDeleted.Text;
            objGENProvinces.CreatedUserID = txtCreatedUserID.Text;
            objGENProvinces.CreatedDate = txtCreatedDate.Text;
            objGENProvinces.UpdatedUserID = txtUpdatedUserID.Text;
            objGENProvinces.UpdatedDate = txtUpdatedDate.Text;
            objGENProvinces.DeletedUserID = txtDeletedUserID.Text;
            objGENProvinces.DeletedDate = txtDeletedDate.Text;

		 
         ******************************************************
		 
                    txtProvinceID.Text = objGENProvinces.ProvinceID;
            txtProvinceName.Text = objGENProvinces.ProvinceName;
            txtAreaID.Text = objGENProvinces.AreaID;
            txtIsActived.Text = objGENProvinces.IsActived;
            txtIsDeleted.Text = objGENProvinces.IsDeleted;
            txtCreatedUserID.Text = objGENProvinces.CreatedUserID;
            txtCreatedDate.Text = objGENProvinces.CreatedDate;
            txtUpdatedUserID.Text = objGENProvinces.UpdatedUserID;
            txtUpdatedDate.Text = objGENProvinces.UpdatedDate;
            txtDeletedUserID.Text = objGENProvinces.DeletedUserID;
            txtDeletedDate.Text = objGENProvinces.DeletedDate;

		 
        *******************************************************/

    }
}

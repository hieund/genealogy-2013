
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
    public class GENAlbumDetails
    {

        #region Member Variables

        private int intAlbumDetailID = int.MinValue;
        private string strAlbumDetailName = string.Empty;
        private int intAlbumDetailTypeID = int.MinValue;
        private string strURL = string.Empty;
        private string strAlbumDetailImage = string.Empty;
        private int intAlbumID = int.MinValue;
        private int intOrderIndex = int.MinValue;
        private IData objDataAccess = null;
        private string strContentFrame = string.Empty;

        #endregion

        #region Properties

        public static string CacheKey
        {
            get { return "GENAlbumDetails_GetAll"; }
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
            get { return intAlbumDetailID; }
            set { intAlbumDetailID = value; }
        }

        /// <summary>
        /// AlbumDetailName
        /// 
        /// </summary>
        public string AlbumDetailName
        {
            get { return strAlbumDetailName; }
            set { strAlbumDetailName = value; }
        }

        /// <summary>
        /// AlbumDetailTypeID
        /// 
        /// </summary>
        public int AlbumDetailTypeID
        {
            get { return intAlbumDetailTypeID; }
            set { intAlbumDetailTypeID = value; }
        }

        /// <summary>
        /// URL
        /// 
        /// </summary>
        public string URL
        {
            get { return strURL; }
            set { strURL = value; }
        }

        /// <summary>
        /// AlbumDetailImage
        /// 
        /// </summary>
        public string AlbumDetailImage
        {
            get { return strAlbumDetailImage; }
            set { strAlbumDetailImage = value; }
        }

        /// <summary>
        /// AlbumID
        /// 
        /// </summary>
        public int AlbumID
        {
            get { return intAlbumID; }
            set { intAlbumID = value; }
        }
        public int OrderIndex
        {
            get { return intOrderIndex; }
            set { intOrderIndex = value; }
        }

        public string ContentFrame
        {
            get { return strContentFrame; }
            set { strContentFrame = value; }
        }

        public int DeletedUserID { get; set; }
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
                    if (!this.IsDBNull(reader["AlbumDetailID"])) this.AlbumDetailID = Convert.ToInt32(reader["AlbumDetailID"]);
                    if (!this.IsDBNull(reader["AlbumDetailName"])) this.AlbumDetailName = Convert.ToString(reader["AlbumDetailName"]);
                    if (!this.IsDBNull(reader["AlbumDetailTypeID"])) this.AlbumDetailTypeID = Convert.ToInt32(reader["AlbumDetailTypeID"]);
                    if (!this.IsDBNull(reader["URL"])) this.URL = Convert.ToString(reader["URL"]);
                    if (!this.IsDBNull(reader["AlbumDetailImage"])) this.AlbumDetailImage = Convert.ToString(reader["AlbumDetailImage"]);
                    if (!this.IsDBNull(reader["AlbumID"])) this.AlbumID = Convert.ToInt32(reader["AlbumID"]);
                    if (!this.IsDBNull(reader["OrderIndex"])) this.OrderIndex = Convert.ToInt32(reader["OrderIndex"]);
                    if (!this.IsDBNull(reader["ContentFrame"])) this.ContentFrame = Convert.ToString(reader["ContentFrame"]);
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
                objData.AddParameter("@AlbumDetailName", this.AlbumDetailName);
                if (this.AlbumDetailTypeID != int.MinValue) objData.AddParameter("@AlbumDetailTypeID", this.AlbumDetailTypeID);
                objData.AddParameter("@URL", this.URL);
                objData.AddParameter("@AlbumDetailImage", this.AlbumDetailImage);
                objData.AddParameter("@AlbumID", this.AlbumID);
                objData.AddParameter("@OrderIndex", this.OrderIndex);
                objData.AddParameter("@ContentFrame", this.ContentFrame);
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
                if (this.AlbumDetailID != int.MinValue) objData.AddParameter("@AlbumDetailID", this.AlbumDetailID);
                else objData.AddParameter("@AlbumDetailID", DBNull.Value);
                objData.AddParameter("@AlbumDetailName", this.AlbumDetailName);
                if (this.AlbumDetailTypeID != int.MinValue) objData.AddParameter("@AlbumDetailTypeID", this.AlbumDetailTypeID);
                else objData.AddParameter("@AlbumDetailTypeID", DBNull.Value);
                objData.AddParameter("@URL", this.URL);
                objData.AddParameter("@AlbumDetailImage", this.AlbumDetailImage);
                objData.AddParameter("@AlbumID", this.AlbumID);
                objData.AddParameter("@OrderIndex", this.OrderIndex);
                objData.AddParameter("@ContentFrame", this.ContentFrame);
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
                objData.CreateNewStoredProcedure("GEN_Album_Details_SRH");
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
        #region Function Support

        public List<GENAlbumDetails> GetAlbumDetailByAlbumID()
        {

            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;

            List<GENAlbumDetails> lstMenu = new List<GENAlbumDetails>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("GEN_Album_Details_GetByAlbumID");
                objData.AddParameter("@AlbumID", this.AlbumID);
                objData.AddParameter("@AlbumDetailTypeID", this.AlbumDetailTypeID);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    GENAlbumDetails objGENAlbumDetails = new GENAlbumDetails();
                    if (!this.IsDBNull(reader["AlbumDetailID"])) objGENAlbumDetails.AlbumDetailID = Convert.ToInt32(reader["AlbumDetailID"]);
                    if (!this.IsDBNull(reader["AlbumDetailName"])) objGENAlbumDetails.AlbumDetailName = Convert.ToString(reader["AlbumDetailName"]);
                    if (!this.IsDBNull(reader["AlbumDetailTypeID"])) objGENAlbumDetails.AlbumDetailTypeID = Convert.ToInt32(reader["AlbumDetailTypeID"]);
                    if (!this.IsDBNull(reader["URL"])) objGENAlbumDetails.URL = Convert.ToString(reader["URL"]);
                    if (!this.IsDBNull(reader["AlbumDetailImage"])) objGENAlbumDetails.AlbumDetailImage = Convert.ToString(reader["AlbumDetailImage"]);
                    if (!this.IsDBNull(reader["AlbumID"])) objGENAlbumDetails.AlbumID = Convert.ToInt32(reader["AlbumID"]);
                    if (!this.IsDBNull(reader["OrderIndex"])) objGENAlbumDetails.OrderIndex = Convert.ToInt32(reader["OrderIndex"]);
                    if (!this.IsDBNull(reader["ContentFrame"])) objGENAlbumDetails.ContentFrame = Convert.ToString(reader["ContentFrame"]);
                    lstMenu.Add(objGENAlbumDetails);
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
            return lstMenu;
        }

        public List<GENAlbumDetailsType> CMSGetListAlbumDetailType()
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;

            List<GENAlbumDetailsType> lstMenu = new List<GENAlbumDetailsType>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("GEN_Album_Details_Type_SRH");
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    GENAlbumDetailsType objGENAlbumDetails = new GENAlbumDetailsType();
                    if (!this.IsDBNull(reader["AlbumDetailTypeID"])) objGENAlbumDetails.AlbumDetailTypeID = Convert.ToInt32(reader["AlbumDetailTypeID"]);
                    if (!this.IsDBNull(reader["AlbumDetailTypeName"])) objGENAlbumDetails.AlbumDetailTypeName = Convert.ToString(reader["AlbumDetailTypeName"]);
                    if (!this.IsDBNull(reader["IsActived"])) objGENAlbumDetails.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) objGENAlbumDetails.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) objGENAlbumDetails.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) objGENAlbumDetails.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) objGENAlbumDetails.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) objGENAlbumDetails.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) objGENAlbumDetails.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) objGENAlbumDetails.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    lstMenu.Add(objGENAlbumDetails);
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
            return lstMenu;
        }
        #endregion
    }
}

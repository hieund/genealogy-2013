
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
    public class GENAlbums
    {



        #region Member Variables

        private int intAlbumID = int.MinValue;
        private string strAlbumName = string.Empty;
        private string strAlbumImage = string.Empty;
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
            get { return "GENAlbums_GetAll"; }
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
        /// AlbumID
        /// 
        /// </summary>
        public int AlbumID
        {
            get { return intAlbumID; }
            set { intAlbumID = value; }
        }

        /// <summary>
        /// AlbumName
        /// 
        /// </summary>
        public string AlbumName
        {
            get { return strAlbumName; }
            set { strAlbumName = value; }
        }

        /// <summary>
        /// AlbumImage
        /// 
        /// </summary>
        public string AlbumImage
        {
            get { return strAlbumImage; }
            set { strAlbumImage = value; }
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

        public GENAlbums()
        {
        }
        private static GENAlbums _current;
        static GENAlbums()
        {
            _current = new GENAlbums();
        }
        public static GENAlbums Current
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
                objData.CreateNewStoredProcedure("GEN_Albums_SEL");
                objData.AddParameter("@AlbumID", this.AlbumID);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (!this.IsDBNull(reader["AlbumID"])) this.AlbumID = Convert.ToInt32(reader["AlbumID"]);
                    if (!this.IsDBNull(reader["AlbumName"])) this.AlbumName = Convert.ToString(reader["AlbumName"]);
                    if (!this.IsDBNull(reader["AlbumImage"])) this.AlbumImage = Convert.ToString(reader["AlbumImage"]);
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
        /// Insert : GEN_Albums
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
                objData.CreateNewStoredProcedure("GEN_Albums_ADD");
                objData.AddParameter("@AlbumName", this.AlbumName);
                objData.AddParameter("@IsActived", this.IsActived);
                if (this.CreatedUserID != int.MinValue) objData.AddParameter("@CreatedUserID", this.CreatedUserID);
                DataTable dtb = objData.ExecStoreToDataTable();
                objTemp = dtb.Rows[0][0];
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
        /// Update : GEN_Albums
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
                objData.CreateNewStoredProcedure("GEN_Albums_UPD");
                objData.AddParameter("@AlbumID", this.AlbumID);
                objData.AddParameter("@AlbumName", this.AlbumName);
                objData.AddParameter("@AlbumImage", this.AlbumImage);
                objData.AddParameter("@IsActived", this.IsActived);
                if (this.UpdatedUserID != int.MinValue) objData.AddParameter("@UpdatedUserID", this.UpdatedUserID);
                else objData.AddParameter("@UpdatedUserID", DBNull.Value);
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
        /// Delete : GEN_Albums
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
                objData.CreateNewStoredProcedure("GEN_Albums_DEL");
                objData.AddParameter("@AlbumID", this.AlbumID);
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
        /// Get all : GEN_Albums
        ///
        ///</summary>
        public List<GENAlbums> GetAll(int intTypeId)
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;
            List<GENAlbums> lst = new List<GENAlbums>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("GEN_Albums_SELALL");
                objData.AddParameter("@AlbumDetailTypeID", intTypeId);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    GENAlbums objAL = new GENAlbums();
                    if (!this.IsDBNull(reader["AlbumID"])) objAL.AlbumID = Convert.ToInt32(reader["AlbumID"]);
                    if (!this.IsDBNull(reader["AlbumName"])) objAL.AlbumName = Convert.ToString(reader["AlbumName"]);
                    if (!this.IsDBNull(reader["AlbumImage"])) objAL.AlbumImage = Convert.ToString(reader["AlbumImage"]);
                    if (!this.IsDBNull(reader["IsActived"])) objAL.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) objAL.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) objAL.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) objAL.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) objAL.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) objAL.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) objAL.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) objAL.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    lst.Add(objAL);
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
            GEN_Albums objGEN_Albums = new GEN_Albums();
            objGENAlbums.AlbumID = txtAlbumID.Text;
            objGENAlbums.AlbumName = txtAlbumName.Text;
            objGENAlbums.AlbumImage = txtAlbumImage.Text;
            objGENAlbums.IsActived = txtIsActived.Text;
            objGENAlbums.IsDeleted = txtIsDeleted.Text;
            objGENAlbums.CreatedUserID = txtCreatedUserID.Text;
            objGENAlbums.CreatedDate = txtCreatedDate.Text;
            objGENAlbums.UpdatedUserID = txtUpdatedUserID.Text;
            objGENAlbums.UpdatedDate = txtUpdatedDate.Text;
            objGENAlbums.DeletedUserID = txtDeletedUserID.Text;
            objGENAlbums.DeletedDate = txtDeletedDate.Text;

		 
         ******************************************************
		 
                    txtAlbumID.Text = objGENAlbums.AlbumID;
            txtAlbumName.Text = objGENAlbums.AlbumName;
            txtAlbumImage.Text = objGENAlbums.AlbumImage;
            txtIsActived.Text = objGENAlbums.IsActived; 
            txtIsDeleted.Text = objGENAlbums.IsDeleted;
            txtCreatedUserID.Text = objGENAlbums.CreatedUserID;
            txtCreatedDate.Text = objGENAlbums.CreatedDate;
            txtUpdatedUserID.Text = objGENAlbums.UpdatedUserID;
            txtUpdatedDate.Text = objGENAlbums.UpdatedDate;
            txtDeletedUserID.Text = objGENAlbums.DeletedUserID;
            txtDeletedDate.Text = objGENAlbums.DeletedDate;

		 
        *******************************************************/
        #region Function Support
        public List<GENAlbums> Search(string strkeyword, int intPageSize, int intPageIndex, int AlbumdetailtypeId, ref int intTotalCount)
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;
            List<GENAlbums> lst = new List<GENAlbums>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("GEN_Albums_SRH");
                objData.AddParameter("@KeyWord", strkeyword);
                objData.AddParameter("@PageSize", intPageSize);
                objData.AddParameter("@PageIndex", intPageIndex);
                objData.AddParameter("@AlbumDetailTypeID", AlbumdetailtypeId);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    GENAlbums objAL = new GENAlbums();
                    if (!this.IsDBNull(reader["TotalCount"])) intTotalCount = Convert.ToInt32(reader["TotalCount"]);

                    if (!this.IsDBNull(reader["AlbumID"])) objAL.AlbumID = Convert.ToInt32(reader["AlbumID"]);
                    if (!this.IsDBNull(reader["AlbumName"])) objAL.AlbumName = Convert.ToString(reader["AlbumName"]);
                    if (!this.IsDBNull(reader["AlbumImage"])) objAL.AlbumImage = Convert.ToString(reader["AlbumImage"]);
                    if (!this.IsDBNull(reader["IsActived"])) objAL.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) objAL.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) objAL.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) objAL.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) objAL.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) objAL.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) objAL.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) objAL.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    lst.Add(objAL);
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
        #endregion

    }
}

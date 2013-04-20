
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
    public class GENNewsCategories
    {



        #region Member Variables

        private int intNewsCategoryID = int.MinValue;
        private string strNewsCategoryName = string.Empty;
        private string strNewsCategoryShortName = string.Empty;
        private bool bolIsActived;
        private bool bolIsDeleted;
        private int intCreatedUserID = int.MinValue;
        private DateTime dtmCreatedDate = DateTime.MinValue;
        private int intUpdatedUserID = int.MinValue;
        private DateTime dtmUpdatedDate = DateTime.MinValue;
        private int intDeletedUserID = int.MinValue;
        private DateTime dtmDeletedDate = DateTime.MinValue;
        private string strNewsCategoryNamesrh = string.Empty;
        private string strNewsCategoryShortNamesrh = string.Empty;
        private IData objDataAccess = null;


        #endregion


        #region Properties

        public static string CacheKey
        {
            get { return "GENNewsCategories_GetAll"; }
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
        /// NewsCategoryID
        /// 
        /// </summary>
        public int NewsCategoryID
        {
            get { return intNewsCategoryID; }
            set { intNewsCategoryID = value; }
        }

        /// <summary>
        /// NewsCategoryName
        /// 
        /// </summary>
        public string NewsCategoryName
        {
            get { return strNewsCategoryName; }
            set { strNewsCategoryName = value; }
        }

        /// <summary>
        /// NewsCategoryShortName
        /// 
        /// </summary>
        public string NewsCategoryShortName
        {
            get { return strNewsCategoryShortName; }
            set { strNewsCategoryShortName = value; }
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

        /// <summary>
        /// NewsCategoryNamesrh
        /// 
        /// </summary>
        public string NewsCategoryNamesrh
        {
            get { return strNewsCategoryNamesrh; }
            set { strNewsCategoryNamesrh = value; }
        }

        /// <summary>
        /// NewsCategoryShortNamesrh
        /// 
        /// </summary>
        public string NewsCategoryShortNamesrh
        {
            get { return strNewsCategoryShortNamesrh; }
            set { strNewsCategoryShortNamesrh = value; }
        }


        #endregion


        #region Constructor

        public GENNewsCategories()
        {
        }
        private static GENNewsCategories _current;
        static GENNewsCategories()
        {
            _current = new GENNewsCategories();
        }
        public static GENNewsCategories Current
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
                objData.CreateNewStoredProcedure("GEN_News_Categories_SEL");
                objData.AddParameter("@NewsCategoryID", this.NewsCategoryID);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (!this.IsDBNull(reader["NewsCategoryID"])) this.NewsCategoryID = Convert.ToInt32(reader["NewsCategoryID"]);
                    if (!this.IsDBNull(reader["NewsCategoryName"])) this.NewsCategoryName = Convert.ToString(reader["NewsCategoryName"]);
                    if (!this.IsDBNull(reader["NewsCategoryShortName"])) this.NewsCategoryShortName = Convert.ToString(reader["NewsCategoryShortName"]);
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
        /// Insert : GEN_News_Categories
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
                objData.CreateNewStoredProcedure("GEN_News_Categories_ADD");
                if (this.NewsCategoryID != int.MinValue) objData.AddParameter("@NewsCategoryID", this.NewsCategoryID);
                objData.AddParameter("@NewsCategoryName", this.NewsCategoryName);
                objData.AddParameter("@NewsCategoryShortName", this.NewsCategoryShortName);
                objData.AddParameter("@IsActived", this.IsActived);
                if (this.CreatedUserID != int.MinValue) objData.AddParameter("@CreatedUserID", this.CreatedUserID);
                if (this.UpdatedUserID != int.MinValue) objData.AddParameter("@UpdatedUserID", this.UpdatedUserID);
                if (this.DeletedUserID != int.MinValue) objData.AddParameter("@DeletedUserID", this.DeletedUserID);
                objData.AddParameter("@NewsCategoryNamesrh", this.NewsCategoryNamesrh);
                objData.AddParameter("@NewsCategoryShortNamesrh", this.NewsCategoryShortNamesrh);
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
        /// Update : GEN_News_Categories
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
                objData.CreateNewStoredProcedure("GEN_News_Categories_UPD");
                if (this.NewsCategoryID != int.MinValue) objData.AddParameter("@NewsCategoryID", this.NewsCategoryID);
                else objData.AddParameter("@NewsCategoryID", DBNull.Value);
                objData.AddParameter("@NewsCategoryName", this.NewsCategoryName);
                objData.AddParameter("@NewsCategoryShortName", this.NewsCategoryShortName);
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
        /// Delete : GEN_News_Categories
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
                objData.CreateNewStoredProcedure("GEN_News_Categories_DEL");
                objData.AddParameter("@NewsCategoryID", this.NewsCategoryID);
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
        /// Get all : GEN_News_Categories
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
                objData.CreateNewStoredProcedure("GEN_News_Categories_SRH");
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

        #region Function Support
        public List<GENNewsCategories> Search(string strkeyword, int intPageSize, int intPageIndex, ref int intTotalCount)
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;
            List<GENNewsCategories> lst = new List<GENNewsCategories>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("GEN_News_Categories_SRH");
                objData.AddParameter("@KeyWord", strkeyword);
                objData.AddParameter("@PageSize", intPageSize);
                objData.AddParameter("@PageIndex", intPageIndex);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    GENNewsCategories objNC = new GENNewsCategories();
                    if (!this.IsDBNull(reader["TotalCount"])) intTotalCount = Convert.ToInt32(reader["TotalCount"]);
                    if (!this.IsDBNull(reader["NewsCategoryID"])) objNC.NewsCategoryID = Convert.ToInt32(reader["NewsCategoryID"]);
                    if (!this.IsDBNull(reader["NewsCategoryName"])) objNC.NewsCategoryName = Convert.ToString(reader["NewsCategoryName"]);
                    if (!this.IsDBNull(reader["NewsCategoryShortName"])) objNC.NewsCategoryShortName = Convert.ToString(reader["NewsCategoryShortName"]);
                    if (!this.IsDBNull(reader["IsActived"])) objNC.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) objNC.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) objNC.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) objNC.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) objNC.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) objNC.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) objNC.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) objNC.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    lst.Add(objNC);
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

        public List<GENNewsCategories> CMSGetListCategory()
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;

            List<GENNewsCategories> lst = new List<GENNewsCategories>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("GEN_News_Categories_SELALL");
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    GENNewsCategories objGNC = new GENNewsCategories();
                    if (!this.IsDBNull(reader["NewsCategoryID"])) objGNC.NewsCategoryID = Convert.ToInt32(reader["NewsCategoryID"]);
                    if (!this.IsDBNull(reader["NewsCategoryName"])) objGNC.NewsCategoryName = Convert.ToString(reader["NewsCategoryName"]);
                    if (!this.IsDBNull(reader["NewsCategoryShortName"])) objGNC.NewsCategoryShortName = Convert.ToString(reader["NewsCategoryShortName"]);
                    if (!this.IsDBNull(reader["IsActived"])) objGNC.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) objGNC.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) objGNC.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) objGNC.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) objGNC.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) objGNC.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) objGNC.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) objGNC.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    lst.Add(objGNC);
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
            GEN_News_Categories objGEN_News_Categories = new GEN_News_Categories();
            objGENNewsCategories.NewsCategoryID = txtNewsCategoryID.Text;
            objGENNewsCategories.NewsCategoryName = txtNewsCategoryName.Text;
            objGENNewsCategories.NewsCategoryShortName = txtNewsCategoryShortName.Text;
            objGENNewsCategories.IsActived = txtIsActived.Text;
            objGENNewsCategories.IsDeleted = txtIsDeleted.Text;
            objGENNewsCategories.CreatedUserID = txtCreatedUserID.Text;
            objGENNewsCategories.CreatedDate = txtCreatedDate.Text;
            objGENNewsCategories.UpdatedUserID = txtUpdatedUserID.Text;
            objGENNewsCategories.UpdatedDate = txtUpdatedDate.Text;
            objGENNewsCategories.DeletedUserID = txtDeletedUserID.Text;
            objGENNewsCategories.DeletedDate = txtDeletedDate.Text;
            objGENNewsCategories.NewsCategoryNamesrh = txtNewsCategoryNamesrh.Text;
            objGENNewsCategories.NewsCategoryShortNamesrh = txtNewsCategoryShortNamesrh.Text;

		 
         ******************************************************
		 
                    txtNewsCategoryID.Text = objGENNewsCategories.NewsCategoryID;
            txtNewsCategoryName.Text = objGENNewsCategories.NewsCategoryName;
            txtNewsCategoryShortName.Text = objGENNewsCategories.NewsCategoryShortName;
            txtIsActived.Text = objGENNewsCategories.IsActived;
            txtIsDeleted.Text = objGENNewsCategories.IsDeleted;
            txtCreatedUserID.Text = objGENNewsCategories.CreatedUserID;
            txtCreatedDate.Text = objGENNewsCategories.CreatedDate;
            txtUpdatedUserID.Text = objGENNewsCategories.UpdatedUserID;
            txtUpdatedDate.Text = objGENNewsCategories.UpdatedDate;
            txtDeletedUserID.Text = objGENNewsCategories.DeletedUserID;
            txtDeletedDate.Text = objGENNewsCategories.DeletedDate;
            txtNewsCategoryNamesrh.Text = objGENNewsCategories.NewsCategoryNamesrh;
            txtNewsCategoryShortNamesrh.Text = objGENNewsCategories.NewsCategoryShortNamesrh;

		 
        *******************************************************/

    }
}

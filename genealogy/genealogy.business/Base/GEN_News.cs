
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
    public class GENNews
    {



        #region Member Variables

        private int intNewsID = int.MinValue;
        private int intNewsTypeID = int.MinValue;
        private string strNewsTitle = string.Empty;
        private string strNewsContent = string.Empty;
        private bool bolIsActived;
        private bool bolIsDeleted;
        private int intCreatedUserID = int.MinValue;
        private DateTime dtmCreatedDate = DateTime.MinValue;
        private int intUpdatedUserID = int.MinValue;
        private DateTime dtmUpdatedDate = DateTime.MinValue;
        private int intDeletedUserID = int.MinValue;
        private DateTime dtmDeletedDate = DateTime.MinValue;
        private bool bolIsEvent;
        private DateTime dtmStartEvent = DateTime.MinValue;
        private DateTime dtmEndEvent = DateTime.MinValue;
        private string strDescription = string.Empty;
        private string strThumbnail = string.Empty;
        private string strCreatedAuthor = string.Empty;
        private string strCreatedEmail = string.Empty;
        private string strCreatedSource = string.Empty;
        private int intNewsCategoryID = int.MinValue;
        private string strNewsCategoryName = string.Empty;
        private IData objDataAccess = null;


        #endregion


        #region Properties

        public static string CacheKey
        {
            get { return "GENNews_GetAll"; }
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
        /// NewsID
        /// 
        /// </summary>
        public int NewsID
        {
            get { return intNewsID; }
            set { intNewsID = value; }
        }

        /// <summary>
        /// NewsTypeID
        /// 
        /// </summary>
        public int NewsTypeID
        {
            get { return intNewsTypeID; }
            set { intNewsTypeID = value; }
        }

        /// <summary>
        /// NewsTitle
        /// 
        /// </summary>
        public string NewsTitle
        {
            get { return strNewsTitle; }
            set { strNewsTitle = value; }
        }

        /// <summary>
        /// NewsContent
        /// 
        /// </summary>
        public string NewsContent
        {
            get { return strNewsContent; }
            set { strNewsContent = value; }
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
        /// IsEvent
        /// 
        /// </summary>
        public bool IsEvent
        {
            get { return bolIsEvent; }
            set { bolIsEvent = value; }
        }

        /// <summary>
        /// StartEvent
        /// 
        /// </summary>
        public DateTime StartEvent
        {
            get { return dtmStartEvent; }
            set { dtmStartEvent = value; }
        }

        /// <summary>
        /// EndEvent
        /// 
        /// </summary>
        public DateTime EndEvent
        {
            get { return dtmEndEvent; }
            set { dtmEndEvent = value; }
        }

        /// <summary>
        /// Description
        /// 
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }

        /// <summary>
        /// Thumbnail
        /// 
        /// </summary>
        public string Thumbnail
        {
            get;
            set;
        }

        /// <summary>
        /// CreatedAuthor
        /// 
        /// </summary>
        public string CreatedAuthor
        {
            get { return strCreatedAuthor; }
            set { strCreatedAuthor = value; }
        }

        /// <summary>
        /// CreatedEmail
        /// 
        /// </summary>
        public string CreatedEmail
        {
            get { return strCreatedEmail; }
            set { strCreatedEmail = value; }
        }

        /// <summary>
        /// CreatedSource
        /// 
        /// </summary>
        public string CreatedSource
        {
            get { return strCreatedSource; }
            set { strCreatedSource = value; }
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
        /// NewsCategoryID
        /// 
        /// </summary>
        public string NewsCategoryName
        {
            get { return strNewsCategoryName; }
            set { strNewsCategoryName = value; }
        }
        #endregion


        #region Constructor

        public GENNews()
        {
        }
        private static GENNews _current;
        static GENNews()
        {
            _current = new GENNews();
        }
        public static GENNews Current
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
                objData.CreateNewStoredProcedure("GEN_News_SEL");
                objData.AddParameter("@NewsID", this.NewsID);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (!this.IsDBNull(reader["NewsID"])) this.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!this.IsDBNull(reader["NewsTypeID"])) this.NewsTypeID = Convert.ToInt32(reader["NewsTypeID"]);
                    if (!this.IsDBNull(reader["NewsTitle"])) this.NewsTitle = Convert.ToString(reader["NewsTitle"]);
                    if (!this.IsDBNull(reader["NewsContent"])) this.NewsContent = Convert.ToString(reader["NewsContent"]);
                    if (!this.IsDBNull(reader["IsActived"])) this.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) this.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) this.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) this.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) this.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) this.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) this.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) this.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    if (!this.IsDBNull(reader["IsEvent"])) this.IsEvent = Convert.ToBoolean(reader["IsEvent"]);
                    if (!this.IsDBNull(reader["StartEvent"])) this.StartEvent = Convert.ToDateTime(reader["StartEvent"]);
                    if (!this.IsDBNull(reader["EndEvent"])) this.EndEvent = Convert.ToDateTime(reader["EndEvent"]);
                    if (!this.IsDBNull(reader["Description"])) this.Description = Convert.ToString(reader["Description"]);
                    if (!this.IsDBNull(reader["Thumbnail"])) this.Thumbnail = Convert.ToString(reader["Thumbnail"]);
                    if (!this.IsDBNull(reader["CreatedAuthor"])) this.CreatedAuthor = Convert.ToString(reader["CreatedAuthor"]);
                    if (!this.IsDBNull(reader["CreatedEmail"])) this.CreatedEmail = Convert.ToString(reader["CreatedEmail"]);
                    if (!this.IsDBNull(reader["CreatedSource"])) this.CreatedSource = Convert.ToString(reader["CreatedSource"]);
                    if (!this.IsDBNull(reader["NewsCategoryID"])) this.NewsCategoryID = Convert.ToInt32(reader["NewsCategoryID"]);
                    if (!this.IsDBNull(reader["NewsCategoryName"])) this.NewsCategoryName = Convert.ToString(reader["NewsCategoryName"]);
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
        /// Insert : GEN_News
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
                objData.CreateNewStoredProcedure("GEN_News_ADD");
                if (this.NewsID != int.MinValue) objData.AddParameter("@NewsID", this.NewsID);
                if (this.NewsTypeID != int.MinValue) objData.AddParameter("@NewsTypeID", this.NewsTypeID);
                objData.AddParameter("@NewsTitle", this.NewsTitle);
                objData.AddParameter("@NewsContent", this.NewsContent);
                objData.AddParameter("@IsActived", this.IsActived);
                if (this.CreatedUserID != int.MinValue) objData.AddParameter("@CreatedUserID", this.CreatedUserID);
                objData.AddParameter("@IsEvent", this.IsEvent);
                if (this.StartEvent != DateTime.MinValue) objData.AddParameter("@StartEvent", this.StartEvent);
                if (this.EndEvent != DateTime.MinValue) objData.AddParameter("@EndEvent", this.EndEvent);
                objData.AddParameter("@Description", this.Description);
                objData.AddParameter("@Thumbnail", this.Thumbnail);
                objData.AddParameter("@CreatedAuthor", this.CreatedAuthor);
                objData.AddParameter("@CreatedEmail", this.CreatedEmail);
                objData.AddParameter("@CreatedSource", this.CreatedSource);
                if (this.NewsCategoryID != int.MinValue) objData.AddParameter("@NewsCategoryID", this.NewsCategoryID);
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
        /// Update : GEN_News
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
                objData.CreateNewStoredProcedure("GEN_News_UPD");
                objData.AddParameter("@NewsID", this.NewsID);
                objData.AddParameter("@NewsTypeID", this.NewsTypeID);
                objData.AddParameter("@NewsTitle", this.NewsTitle);
                objData.AddParameter("@NewsContent", this.NewsContent);
                objData.AddParameter("@IsActived", this.IsActived);
                objData.AddParameter("@UpdatedUserID", this.UpdatedUserID);
                objData.AddParameter("@IsEvent", this.IsEvent);
                objData.AddParameter("@Description", this.Description);
                objData.AddParameter("@Thumbnail", this.Thumbnail);
                objData.AddParameter("@CreatedAuthor", this.CreatedAuthor);
                objData.AddParameter("@CreatedEmail", this.CreatedEmail);
                objData.AddParameter("@CreatedSource", this.CreatedSource);
                objData.AddParameter("@NewsCategoryID", this.NewsCategoryID);
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
        /// Delete : GEN_News
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
                objData.CreateNewStoredProcedure("GEN_News_DEL");
                objData.AddParameter("@NewsID", this.NewsID);
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
        /// Get all : GEN_News
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
                objData.CreateNewStoredProcedure("GEN_News_SRH");
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

        /// <summary>
        /// lay danh sach tin moi nhat
        /// </summary>
        /// <returns></returns>
        public List<GENNews> GetTopNewsHot()
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;

            List<GENNews> lst = new List<GENNews>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("GEN_NewsGetTopHot");
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    GENNews objNC = new GENNews();
                    if (!this.IsDBNull(reader["NewsID"])) objNC.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!this.IsDBNull(reader["NewsTypeID"])) objNC.NewsTypeID = Convert.ToInt32(reader["NewsTypeID"]);
                    if (!this.IsDBNull(reader["NewsTitle"])) objNC.NewsTitle = Convert.ToString(reader["NewsTitle"]);
                    if (!this.IsDBNull(reader["NewsContent"])) objNC.NewsContent = Convert.ToString(reader["NewsContent"]);
                    if (!this.IsDBNull(reader["IsActived"])) objNC.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) objNC.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) objNC.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) objNC.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) objNC.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) objNC.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) objNC.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) objNC.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    if (!this.IsDBNull(reader["IsEvent"])) objNC.IsEvent = Convert.ToBoolean(reader["IsEvent"]);
                    if (!this.IsDBNull(reader["StartEvent"])) objNC.StartEvent = Convert.ToDateTime(reader["StartEvent"]);
                    if (!this.IsDBNull(reader["EndEvent"])) objNC.EndEvent = Convert.ToDateTime(reader["EndEvent"]);
                    if (!this.IsDBNull(reader["Description"])) objNC.Description = Convert.ToString(reader["Description"]);
                    if (!this.IsDBNull(reader["Thumbnail"])) objNC.Thumbnail = Convert.ToString(reader["Thumbnail"]);
                    if (!this.IsDBNull(reader["CreatedAuthor"])) objNC.CreatedAuthor = Convert.ToString(reader["CreatedAuthor"]);
                    if (!this.IsDBNull(reader["CreatedEmail"])) objNC.CreatedEmail = Convert.ToString(reader["CreatedEmail"]);
                    if (!this.IsDBNull(reader["CreatedSource"])) objNC.CreatedSource = Convert.ToString(reader["CreatedSource"]);
                    if (!this.IsDBNull(reader["NewsCategoryID"])) objNC.NewsCategoryID = Convert.ToInt32(reader["NewsCategoryID"]);
                    if (!this.IsDBNull(reader["NewsCategoryName"])) objNC.NewsCategoryName = Convert.ToString(reader["NewsCategoryName"]);
                    lst.Add(objNC);
                }
                reader.Close();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetTopnewsHot() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
            }
            return lst;
        }

        /// <summary>
        /// lay danh sach tin xem nhieu nhat
        /// </summary>
        /// <returns></returns>
        public List<GENNews> GetTopNewsView()
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;

            List<GENNews> lst = new List<GENNews>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("GEN_NewsGetTopView");
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    GENNews objNC = new GENNews();
                    if (!this.IsDBNull(reader["NewsID"])) objNC.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!this.IsDBNull(reader["NewsTypeID"])) objNC.NewsTypeID = Convert.ToInt32(reader["NewsTypeID"]);
                    if (!this.IsDBNull(reader["NewsTitle"])) objNC.NewsTitle = Convert.ToString(reader["NewsTitle"]);
                    if (!this.IsDBNull(reader["NewsContent"])) objNC.NewsContent = Convert.ToString(reader["NewsContent"]);
                    if (!this.IsDBNull(reader["IsActived"])) objNC.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) objNC.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) objNC.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) objNC.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) objNC.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) objNC.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) objNC.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) objNC.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    if (!this.IsDBNull(reader["IsEvent"])) objNC.IsEvent = Convert.ToBoolean(reader["IsEvent"]);
                    if (!this.IsDBNull(reader["StartEvent"])) objNC.StartEvent = Convert.ToDateTime(reader["StartEvent"]);
                    if (!this.IsDBNull(reader["EndEvent"])) objNC.EndEvent = Convert.ToDateTime(reader["EndEvent"]);
                    if (!this.IsDBNull(reader["Description"])) objNC.Description = Convert.ToString(reader["Description"]);
                    if (!this.IsDBNull(reader["Thumbnail"])) objNC.Thumbnail = Convert.ToString(reader["Thumbnail"]);
                    if (!this.IsDBNull(reader["CreatedAuthor"])) objNC.CreatedAuthor = Convert.ToString(reader["CreatedAuthor"]);
                    if (!this.IsDBNull(reader["CreatedEmail"])) objNC.CreatedEmail = Convert.ToString(reader["CreatedEmail"]);
                    if (!this.IsDBNull(reader["CreatedSource"])) objNC.CreatedSource = Convert.ToString(reader["CreatedSource"]);
                    if (!this.IsDBNull(reader["NewsCategoryID"])) objNC.NewsCategoryID = Convert.ToInt32(reader["NewsCategoryID"]);
                    if (!this.IsDBNull(reader["NewsCategoryName"])) objNC.NewsCategoryName = Convert.ToString(reader["NewsCategoryName"]);
                    lst.Add(objNC);
                }
                reader.Close();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetTopnewsHot() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
            }
            return lst;
        }


        public List<GENNews> GetNewsByCategoryId(int categorynewsId, int iPageIndex, int iPageSize)
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;

            List<GENNews> lst = new List<GENNews>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("GEN_NewsGetByCategoryId");
                objData.AddParameter("@NewsCategoryID", categorynewsId);
                objData.AddParameter("@PageIndex", iPageIndex);
                objData.AddParameter("@PageSize", iPageSize);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    GENNews objNC = new GENNews();
                    if (!this.IsDBNull(reader["NewsID"])) objNC.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!this.IsDBNull(reader["NewsTypeID"])) objNC.NewsTypeID = Convert.ToInt32(reader["NewsTypeID"]);
                    if (!this.IsDBNull(reader["NewsTitle"])) objNC.NewsTitle = Convert.ToString(reader["NewsTitle"]);
                    if (!this.IsDBNull(reader["NewsContent"])) objNC.NewsContent = Convert.ToString(reader["NewsContent"]);
                    if (!this.IsDBNull(reader["IsActived"])) objNC.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) objNC.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) objNC.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) objNC.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) objNC.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) objNC.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) objNC.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) objNC.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    if (!this.IsDBNull(reader["IsEvent"])) objNC.IsEvent = Convert.ToBoolean(reader["IsEvent"]);
                    if (!this.IsDBNull(reader["StartEvent"])) objNC.StartEvent = Convert.ToDateTime(reader["StartEvent"]);
                    if (!this.IsDBNull(reader["EndEvent"])) objNC.EndEvent = Convert.ToDateTime(reader["EndEvent"]);
                    if (!this.IsDBNull(reader["Description"])) objNC.Description = Convert.ToString(reader["Description"]);
                    if (!this.IsDBNull(reader["Thumbnail"])) objNC.Thumbnail = Convert.ToString(reader["Thumbnail"]);
                    if (!this.IsDBNull(reader["CreatedAuthor"])) objNC.CreatedAuthor = Convert.ToString(reader["CreatedAuthor"]);
                    if (!this.IsDBNull(reader["CreatedEmail"])) objNC.CreatedEmail = Convert.ToString(reader["CreatedEmail"]);
                    if (!this.IsDBNull(reader["CreatedSource"])) objNC.CreatedSource = Convert.ToString(reader["CreatedSource"]);
                    if (!this.IsDBNull(reader["NewsCategoryID"])) objNC.NewsCategoryID = Convert.ToInt32(reader["NewsCategoryID"]);
                    if (!this.IsDBNull(reader["NewsCategoryName"])) objNC.NewsCategoryName = Convert.ToString(reader["NewsCategoryName"]);
                    lst.Add(objNC);
                }
                reader.Close();
            }
            catch (Exception objEx)
            {
                throw new Exception("GetTopnewsHot() Error   " + objEx.Message.ToString());
            }
            finally
            {
                if (objDataAccess == null)
                    objData.DeConnect();
            }
            return lst;
        }

        public List<GENNews> Search(string strkeyword, int intPageSize, int intPageIndex, ref int intTotalCount)
        {
            IData objData;
            if (objDataAccess == null)
                objData = new IData();
            else
                objData = objDataAccess;
            List<GENNews> lst = new List<GENNews>();
            try
            {
                if (objData.GetConnection() == null || objData.GetConnection().State == ConnectionState.Closed)
                    objData.Connect();
                objData.CreateNewStoredProcedure("GEN_News_SRH");
                objData.AddParameter("@KeyWord", strkeyword);
                objData.AddParameter("@PageSize", intPageSize);
                objData.AddParameter("@PageIndex", intPageIndex);
                IDataReader reader = objData.ExecStoreToDataReader();
                while (reader.Read())
                {
                    GENNews objNC = new GENNews();
                    if (!this.IsDBNull(reader["NewsID"])) objNC.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!this.IsDBNull(reader["NewsTypeID"])) objNC.NewsTypeID = Convert.ToInt32(reader["NewsTypeID"]);
                    if (!this.IsDBNull(reader["NewsTitle"])) objNC.NewsTitle = Convert.ToString(reader["NewsTitle"]);
                    if (!this.IsDBNull(reader["NewsContent"])) objNC.NewsContent = Convert.ToString(reader["NewsContent"]);
                    if (!this.IsDBNull(reader["IsActived"])) objNC.IsActived = Convert.ToBoolean(reader["IsActived"]);
                    if (!this.IsDBNull(reader["IsDeleted"])) objNC.IsDeleted = Convert.ToBoolean(reader["IsDeleted"]);
                    if (!this.IsDBNull(reader["CreatedUserID"])) objNC.CreatedUserID = Convert.ToInt32(reader["CreatedUserID"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) objNC.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    if (!this.IsDBNull(reader["UpdatedUserID"])) objNC.UpdatedUserID = Convert.ToInt32(reader["UpdatedUserID"]);
                    if (!this.IsDBNull(reader["UpdatedDate"])) objNC.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    if (!this.IsDBNull(reader["DeletedUserID"])) objNC.DeletedUserID = Convert.ToInt32(reader["DeletedUserID"]);
                    if (!this.IsDBNull(reader["DeletedDate"])) objNC.DeletedDate = Convert.ToDateTime(reader["DeletedDate"]);
                    if (!this.IsDBNull(reader["IsEvent"])) objNC.IsEvent = Convert.ToBoolean(reader["IsEvent"]);
                    if (!this.IsDBNull(reader["StartEvent"])) objNC.StartEvent = Convert.ToDateTime(reader["StartEvent"]);
                    if (!this.IsDBNull(reader["EndEvent"])) objNC.EndEvent = Convert.ToDateTime(reader["EndEvent"]);
                    if (!this.IsDBNull(reader["Description"])) objNC.Description = Convert.ToString(reader["Description"]);
                    if (!this.IsDBNull(reader["Thumbnail"])) objNC.Thumbnail = Convert.ToString(reader["Thumbnail"]);
                    if (!this.IsDBNull(reader["CreatedAuthor"])) objNC.CreatedAuthor = Convert.ToString(reader["CreatedAuthor"]);
                    if (!this.IsDBNull(reader["CreatedEmail"])) objNC.CreatedEmail = Convert.ToString(reader["CreatedEmail"]);
                    if (!this.IsDBNull(reader["CreatedSource"])) objNC.CreatedSource = Convert.ToString(reader["CreatedSource"]);
                    if (!this.IsDBNull(reader["NewsCategoryID"])) objNC.NewsCategoryID = Convert.ToInt32(reader["NewsCategoryID"]);
                    //if (!this.IsDBNull(reader["NewsCategoryName"])) objNC.NewsCategoryName = Convert.ToString(reader["NewsCategoryName"]);
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
            GEN_News objGEN_News = new GEN_News();
            objGENNews.NewsID = txtNewsID.Text;
            objGENNews.NewsTypeID = txtNewsTypeID.Text;
            objGENNews.NewsTitle = txtNewsTitle.Text;
            objGENNews.NewsContent = txtNewsContent.Text;
            objGENNews.IsActived = txtIsActived.Text;
            objGENNews.IsDeleted = txtIsDeleted.Text;
            objGENNews.CreatedUserID = txtCreatedUserID.Text;
            objGENNews.CreatedDate = txtCreatedDate.Text;
            objGENNews.UpdatedUserID = txtUpdatedUserID.Text;
            objGENNews.UpdatedDate = txtUpdatedDate.Text;
            objGENNews.DeletedUserID = txtDeletedUserID.Text;
            objGENNews.DeletedDate = txtDeletedDate.Text;
            objGENNews.IsEvent = txtIsEvent.Text;
            objGENNews.StartEvent = txtStartEvent.Text;
            objGENNews.EndEvent = txtEndEvent.Text;
            objGENNews.Description = txtDescription.Text;
            objGENNews.Thumbnail = txtThumbnail.Text;
            objGENNews.CreatedAuthor = txtCreatedAuthor.Text;
            objGENNews.CreatedEmail = txtCreatedEmail.Text;
            objGENNews.CreatedSource = txtCreatedSource.Text;
            objGENNews.NewsCategoryID = txtNewsCategoryID.Text;

		 
         ******************************************************
		 
                    txtNewsID.Text = objGENNews.NewsID;
            txtNewsTypeID.Text = objGENNews.NewsTypeID;
            txtNewsTitle.Text = objGENNews.NewsTitle;
            txtNewsContent.Text = objGENNews.NewsContent;
            txtIsActived.Text = objGENNews.IsActived;
            txtIsDeleted.Text = objGENNews.IsDeleted;
            txtCreatedUserID.Text = objGENNews.CreatedUserID;
            txtCreatedDate.Text = objGENNews.CreatedDate;
            txtUpdatedUserID.Text = objGENNews.UpdatedUserID;
            txtUpdatedDate.Text = objGENNews.UpdatedDate;
            txtDeletedUserID.Text = objGENNews.DeletedUserID;
            txtDeletedDate.Text = objGENNews.DeletedDate;
            txtIsEvent.Text = objGENNews.IsEvent;
            txtStartEvent.Text = objGENNews.StartEvent;
            txtEndEvent.Text = objGENNews.EndEvent;
            txtDescription.Text = objGENNews.Description;
            txtThumbnail.Text = objGENNews.Thumbnail;
            txtCreatedAuthor.Text = objGENNews.CreatedAuthor;
            txtCreatedEmail.Text = objGENNews.CreatedEmail;
            txtCreatedSource.Text = objGENNews.CreatedSource;
            txtNewsCategoryID.Text = objGENNews.NewsCategoryID;

		 
        *******************************************************/

    }
}

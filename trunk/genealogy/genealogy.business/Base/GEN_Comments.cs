
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
    /// Created by 		: YourName 
    /// Created date 	: 6/2/2013 
    /// Description 
    /// </summary>	
    public class GENComments
    { 

        #region Member Variables

        private int intCommentID = int.MinValue;
        private int intNewsID = int.MinValue;
        private int intUserID = int.MinValue;
        private string strContent = string.Empty;
        private bool bolIsShow;
        private string strEmail = string.Empty;
        private string strFullName = string.Empty;
        private DateTime createdDate;
        private IData objDataAccess = null;


        #endregion 

        #region Properties

        public static string CacheKey
        {
            get { return "GENComments_GetAll"; }
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
        /// CommentID
        /// 
        /// </summary>
        public int CommentID
        {
            get { return intCommentID; }
            set { intCommentID = value; }
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
        /// UserID
        /// 
        /// </summary>
        public int UserID
        {
            get { return intUserID; }
            set { intUserID = value; }
        }

        /// <summary>
        /// Content
        /// 
        /// </summary>
        public string Content
        {
            get { return strContent; }
            set { strContent = value; }
        }

        /// <summary>
        /// IsShow
        /// 
        /// </summary>
        public bool IsShow
        {
            get { return bolIsShow; }
            set { bolIsShow = value; }
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
        /// FullName
        /// 
        /// </summary>
        public string FullName
        {
            get { return strFullName; }
            set { strFullName = value; }
        }

        /// <summary>
        /// CreatedDate
        /// 
        /// </summary>
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        public string Avartar { get; set; }

        #endregion


        #region Constructor

        public GENComments()
        {
        }
        private static GENComments _current;
        static GENComments()
        {
            _current = new GENComments();
        }
        public static GENComments Current
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
                objData.CreateNewStoredProcedure("GEN_Comments_Select");
                objData.AddParameter("@CommentID", this.CommentID);
                IDataReader reader = objData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (!this.IsDBNull(reader["CommentID"])) this.CommentID = Convert.ToInt32(reader["CommentID"]);
                    if (!this.IsDBNull(reader["NewsID"])) this.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!this.IsDBNull(reader["UserID"])) this.UserID = Convert.ToInt32(reader["UserID"]);
                    if (!this.IsDBNull(reader["Content"])) this.Content = Convert.ToString(reader["Content"]);
                    if (!this.IsDBNull(reader["IsShow"])) this.IsShow = Convert.ToBoolean(reader["IsShow"]);
                    if (!this.IsDBNull(reader["Email"])) this.Email = Convert.ToString(reader["Email"]);
                    if (!this.IsDBNull(reader["FullName"])) this.FullName = Convert.ToString(reader["FullName"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) this.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
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
        /// Insert : GEN_Comments
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
                objData.CreateNewStoredProcedure("GEN_Comments_Insert");
               
                if (this.NewsID != int.MinValue) objData.AddParameter("@NewsID", this.NewsID);
                if (this.UserID != int.MinValue) objData.AddParameter("@UserID", this.UserID);
                objData.AddParameter("@Content", this.Content);
                objData.AddParameter("@IsShow", this.IsShow);
                objData.AddParameter("@Email", this.Email);
                objData.AddParameter("@FullName", this.FullName);
                objData.AddParameter("@Avartar", this.Avartar);
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
        /// Update : GEN_Comments
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
                objData.CreateNewStoredProcedure("GEN_Comments_Update");
                if (this.CommentID != int.MinValue) objData.AddParameter("@CommentID", this.CommentID);
                else objData.AddParameter("@CommentID", DBNull.Value);
                if (this.NewsID != int.MinValue) objData.AddParameter("@NewsID", this.NewsID);
                else objData.AddParameter("@NewsID", DBNull.Value);
                if (this.UserID != int.MinValue) objData.AddParameter("@UserID", this.UserID);
                else objData.AddParameter("@UserID", DBNull.Value);
                objData.AddParameter("@Content", this.Content);
                objData.AddParameter("@IsShow", this.IsShow);
                objData.AddParameter("@Email", this.Email);
                objData.AddParameter("@FullName", this.FullName);
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
        /// Delete : GEN_Comments
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
                objData.CreateNewStoredProcedure("GEN_Comments_Delete");
                objData.AddParameter("@CommentID", this.CommentID);
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
        /// Get all : GEN_Comments
        ///
        ///</summary>
        public List<GENComments> GetAll()
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
                objData.CreateNewStoredProcedure("GEN_Comments_SelectAll");
                IDataReader reader = objData.ExecStoreToDataReader();
                List<GENComments> comments = new List<GENComments>();
                while (reader.Read())
                {
                    GENComments comment = new GENComments();
                    if (!this.IsDBNull(reader["CommentID"])) comment.CommentID = Convert.ToInt32(reader["CommentID"]);
                    if (!this.IsDBNull(reader["NewsID"])) comment.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!this.IsDBNull(reader["UserID"])) comment.UserID = Convert.ToInt32(reader["UserID"]);
                    if (!this.IsDBNull(reader["Content"])) comment.Content = Convert.ToString(reader["Content"]);
                    if (!this.IsDBNull(reader["IsShow"])) comment.IsShow = Convert.ToBoolean(reader["IsShow"]);
                    if (!this.IsDBNull(reader["Email"])) comment.Email = Convert.ToString(reader["Email"]);
                    if (!this.IsDBNull(reader["FullName"])) comment.FullName = Convert.ToString(reader["FullName"]);
                    if (!this.IsDBNull(reader["Avartar"])) comment.Avartar = Convert.ToString(reader["Avartar"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) comment.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    comments.Add(comment);
                }
                reader.Close();
                return comments;
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

        public List<GENComments> GetByNews(int newsId)
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
                objData.CreateNewStoredProcedure("GEN_Comments_Select_By_News");
                objData.AddParameter("@NewsID", newsId);
                IDataReader reader = objData.ExecStoreToDataReader();
                List<GENComments> comments = new List<GENComments>();
                while (reader.Read())
                {
                    GENComments comment = new GENComments();
                    if (!this.IsDBNull(reader["CommentID"])) comment.CommentID = Convert.ToInt32(reader["CommentID"]);
                    if (!this.IsDBNull(reader["NewsID"])) comment.NewsID = Convert.ToInt32(reader["NewsID"]);
                    if (!this.IsDBNull(reader["UserID"])) comment.UserID = Convert.ToInt32(reader["UserID"]);
                    if (!this.IsDBNull(reader["Content"])) comment.Content = Convert.ToString(reader["Content"]);
                    if (!this.IsDBNull(reader["IsShow"])) comment.IsShow = Convert.ToBoolean(reader["IsShow"]);
                    if (!this.IsDBNull(reader["Email"])) comment.Email = Convert.ToString(reader["Email"]);
                    if (!this.IsDBNull(reader["FullName"])) comment.FullName = Convert.ToString(reader["FullName"]);
                    if (!this.IsDBNull(reader["Avartar"])) comment.Avartar = Convert.ToString(reader["Avartar"]);
                    if (!this.IsDBNull(reader["CreatedDate"])) comment.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    comments.Add(comment);
                }
                reader.Close();
                return comments;
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
            GEN_Comments objGEN_Comments = new GEN_Comments();
            objGENComments.CommentID = txtCommentID.Text;
            objGENComments.NewsID = txtNewsID.Text;
            objGENComments.UserID = txtUserID.Text;
            objGENComments.Content = txtContent.Text;
            objGENComments.IsShow = txtIsShow.Text;
            objGENComments.Email = txtEmail.Text;
            objGENComments.FullName = txtFullName.Text;
            objGENComments.CreatedDate = txtCreatedDate.Text;

		 
         ******************************************************
		 
                    txtCommentID.Text = objGENComments.CommentID;
            txtNewsID.Text = objGENComments.NewsID;
            txtUserID.Text = objGENComments.UserID;
            txtContent.Text = objGENComments.Content;
            txtIsShow.Text = objGENComments.IsShow;
            txtEmail.Text = objGENComments.Email;
            txtFullName.Text = objGENComments.FullName;
            txtCreatedDate.Text = objGENComments.CreatedDate;

		 
        *******************************************************/


        
    }
}

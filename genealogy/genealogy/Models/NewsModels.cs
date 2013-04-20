using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace genealogy.Models
{
    public class NewsModels
    {

        public int NewsID { get; set; }

        public int NewsTypeID { get; set; }

        [Required(ErrorMessage = "Nhập chủ đề bài tin")]
        public string NewsTitle { get; set; }

        public int NewsCategoryID { get; set; }

        [Required(ErrorMessage = "Nhập nội bài tin")]
        public string NewsContent { get; set; }

        public string Thumbnail { get; set; }

        public bool IsEvent { get; set; }

        [Required(ErrorMessage = "Trích dẫn bài tin")]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartEvent { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndEvent { get; set; }

        [Required(ErrorMessage = "Nhập người tạo")]
        public string CreatedAuthor { get; set; }

        [Required(ErrorMessage = "Nhập email")]
        public string CreatedEmail { get; set; }

        public string CreatedSource { get; set; }

        private bool bIsActived = true;
        public bool IsActived { get { return bIsActived; } set { bIsActived = value; } }

        public bool IsDeleted { get; set; }

        public int CreatedUserID { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedUserID { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int DeletedUserID { get; set; }

        public DateTime DeletedDate { get; set; }

    }
}
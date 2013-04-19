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

        public string NewsTitle { get; set; }

        public int NewsCategoryID { get; set; }

        public string NewsContent { get; set; }

        public string Thumbnail { get; set; }

        public bool IsEvent { get; set; }

        public string Description { get; set; }

        public DateTime StartEvent { get; set; }

        public DateTime EndEvent { get; set; }

        public string CreatedAuthor { get; set; }

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
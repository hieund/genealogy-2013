﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace genealogy.Models
{
    public class NewsCategoryModels
    {
        public int NewsCategoryID { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên danh mục")]
        [Display(Name = "Tên danh mục")]
        public string NewsCategoryName { get; set; }

        public string NewsCategoryShortName { get; set; }

        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }

        public int CreatedUserID { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedUserID { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int DeletedUserID { get; set; }

        public DateTime DeletedDate { get; set; }

    }
}
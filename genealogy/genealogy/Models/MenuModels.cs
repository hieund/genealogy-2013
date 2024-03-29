﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace genealogy.Models
{
    public class MenuModels
    {

        public int MenuID { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên menu")]
        [Display(Name = "Tên Menu")]
        public string MenuName { get; set; }

        [Display(Name = "Mô tả Menu")]
        public string MenuDescription { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập link menu")]
        [Display(Name = "Link Menu")]
        public string MenuLink { get; set; }


        public int OrderIndex { get; set; }


        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }

        public int CreatedUserID { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedUserID { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int DeletedUserID { get; set; }

        public DateTime DeletedDate { get; set; }

        public int ParentMenuID { get; set; }

    }
}
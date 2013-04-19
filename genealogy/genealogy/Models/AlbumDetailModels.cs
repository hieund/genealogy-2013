using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace genealogy.Models
{
    public class AlbumDetailModels
    {

        public int AlbumDetailID { get; set; }

        //[Required(ErrorMessage = "Bạn cần nhập tên danh mục")]
        //[Display(Name = "Tên danh mục")]
        public string AlbumDetailName { get; set; }

        public int AlbumDetailTypeID { get; set; }

        public string URL { get; set; }

        public string AlbumDetailImage { get; set; }

        public int AlbumID { get; set; }

        public int OrderIndex { get; set; }
        
    }
}
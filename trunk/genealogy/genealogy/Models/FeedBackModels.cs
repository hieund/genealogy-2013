using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace genealogy.Models
{
    public class FeedBackModels
    {
        [Required(ErrorMessage = "Nhập tên")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Nhập Nội dung")]
        public string Content { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace genealogy.Models
{
    public class CommentsModels
    {
        public int CommentID { get; set; }

        [Required]
        public int NewsID { get; set; }

        public int UserID { get; set; }

        [Required]
        public string Content { get; set; }

        public string Avartar { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Sai định dạng Email")]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }
    }
}
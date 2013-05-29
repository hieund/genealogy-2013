using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace genealogy.Models
{
    public class LoginModels
    {
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập password")]
        public string Password { get; set; }
    }
}
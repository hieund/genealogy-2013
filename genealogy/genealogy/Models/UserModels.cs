using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace genealogy.Models
{
    public class UserModels
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập xác nhận password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập NickName")]
        public string NickName { get; set; }

        public bool IsLogin { get; set; }

        public bool IsAdmin { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập NickName")]
        public DateTime Birthday { get; set; }

        public string AboutMe { get; set; }

        public string Avatar { get; set; }

        public string Hobby { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ hiện tại")]
        public string Address { get; set; }

        public string Schools { get; set; }

        public string Jobs { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        public bool Gender { get; set; }

        public string DeathDate { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nguyên quán")]
        public string CurrentPlace { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nơi sinh")]
        public string BirthPlace { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn trạng thái hôn nhân")]
        public int Status { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên đệm")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Mobile { get; set; }

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
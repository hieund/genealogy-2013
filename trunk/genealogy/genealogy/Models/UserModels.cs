namespace genealogy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Web.Mvc;
    using System.Web.Security;

    public class UserModels
    {

        public int UserID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(100, ErrorMessage = " {0} phải ít nhất là {2} ký tự.", MinimumLength = 6)]
        public string Password { get; set; }

        [StringLength(100)]

        [Compare("Password", ErrorMessage = "Mật khẩu không khớp.")]
        [Required(ErrorMessage = "Vui lòng xác nhận nhập mật khẩu")]
        public string ConfirmPassword { get; set; }

        public string NickName { get; set; }

        public string KitoName { get; set; }

        public bool IsLogin { get; set; }

        public bool IsAdmin { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        [DataType(DataType.Date)]
        [StringLength(100)]
        public string Birthday { get; set; }

        public string AboutMe { get; set; }

        public string Avatar { get; set; }

        public string Hobby { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Sai định dạng Email")]
        public string Email { get; set; }

        public string Address { get; set; }

        public string Schools { get; set; }

        public string Jobs { get; set; }

        public int Gender { get; set; }

        public string DeathDate { get; set; }

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

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [RegularExpression(@"\d{9,11}", ErrorMessage = "Điện thoại")]
        public string Mobile { get; set; }

        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }

        public int CreatedUserID { get; set; }

        public int CurrentProvinceID { get; set; }

        public int BirthProvinceID { get; set; }

    }

}
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
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Vui lòng xác nhận nhập mật khẩu")]
        public string ConfirmPassword { get; set; }

        public string NickName { get; set; }

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
        [DataType(DataType.EmailAddress, ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }

        public string Address { get; set; }

        public string Schools { get; set; }

        public string Jobs { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
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
        [DataType(DataType.PhoneNumber, ErrorMessage = "Số điện thoại không đúng")]
        public string Mobile { get; set; }

        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }

        public int CreatedUserID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int UpdatedUserID { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int DeletedUserID { get; set; }

        public DateTime? DeletedDate { get; set; }

        public int CurrentProvinceID
        {
            get;
            set;
        }

        public int BirthProvinceID
        {
            get;
            set;
        }

    }

}
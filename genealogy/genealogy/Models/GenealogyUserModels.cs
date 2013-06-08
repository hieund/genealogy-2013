using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace genealogy.Models
{
    public class GenealogyUserModels
    {
        public int UserId { get; set; }

        public int ParentId { get; set; }

        public int? UserRelationId { get; set; }

        public int RelationTypeId { get; set; }

        public int OrderPostion { get; set; }

        //[Required(ErrorMessage = "Vui lòng nhập password")]
        //[Compare("ConfirmPassword", ErrorMessage = "password xác nhận khống đúng")]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string NickName { get; set; }

        public string KitoName { get; set; }

        public bool IsLogin { get; set; }

        public bool IsAdmin { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        public string Birthday { get; set; }

        public string AboutMe { get; set; }

        public string Avatar { get; set; }

        public string Hobby { get; set; }

        public string Email { get; set; }

        //[Required(ErrorMessage = "Vui lòng nhập địa chỉ hiện tại")]
        //[EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Address { get; set; }

        public string Schools { get; set; }

        public string Jobs { get; set; }

        public int Gender { get; set; }

        public string DeathDate { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nguyên quán")]
        public string CurrentPlace { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nơi sinh")]
        public string BirthPlace { get; set; }

        public int Status { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên đệm")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên")]
        public string LastName { get; set; }

        public string FullName { get; set; }

        //[Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Mobile { get; set; }

        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }

        public int CreatedUserID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int UpdatedUserID { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int DeletedUserID { get; set; }

        public DateTime? DeletedDate { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn tỉnh/thành phố đang sống")]
        public int CurrentProvinceID
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Vui lòng chọn tỉnh/thành phố sinh")]
        public int BirthProvinceID
        {
            get;
            set;
        }


    }
}
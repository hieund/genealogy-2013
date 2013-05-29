﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace genealogy.Models
{
    public class UserModels
    {
        public int UserID { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string NickName { get; set; }

        public bool IsLogin { get; set; }

        public bool IsAdmin { get; set; }

        public string Birthday { get; set; }

        public string AboutMe { get; set; }

        public string Avatar { get; set; }

        public string Hobby { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Schools { get; set; }

        public string Jobs { get; set; }

        public bool Gender { get; set; }

        public string DeathDate { get; set; }

        public string CurrentPlace { get; set; }

        public string BirthPlace { get; set; }

        public int Status { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

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
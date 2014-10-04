﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoStream.Models
{
    public class UserModel
    {
        [Required]
        [EmailAddress]
        [StringLength(200)]
        [Display(Name = "")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength=8)]
        [Display(Name = "")]
        public string password { get; set; }

        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength=3)]
        public string userName { get; set; }
    }
}
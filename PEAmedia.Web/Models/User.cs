using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PEAmedia.Web.Models
{
    public class User
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3)]
        public string userName { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string eMail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6)]
        public string password { get; set; }
    }
}
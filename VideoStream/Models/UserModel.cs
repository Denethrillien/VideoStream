using System;
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
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength=8)]
        public string Password { get; set; }

        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength=3)]
        public string UserName { get; set; }
    }
}
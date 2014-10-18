using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PEAmedia.Web.Models
{
    public class UserProfile
    {
        public string userName { get; set; }
        public UserProfile(String userName)
        {
            this.userName = userName;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PEAmedia.Web.Models
{
    public class Profile_Comment
    {
        public string Sender { get; set; }
        public int Recipient { get; set; }
        public string Title { get; set; }
        public string Entry { get; set; }
        public DateTime Date { get; set; }
        public Nullable<int> ReplyTo { get; set; }
    }
}
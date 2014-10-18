using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PEAmedia.Web.Models
{
    public class Message
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Title { get; set; }
        public string Entry { get; set; }
        public DateTime Date { get; set; }
    }
}
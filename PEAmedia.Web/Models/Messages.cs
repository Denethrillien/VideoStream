//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PEAmedia.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Messages
    {
        public int Message_ID { get; set; }
        public int Sender_ID { get; set; }
        public int Recipient_ID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public System.DateTime Date_Time { get; set; }
    
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
    }
}

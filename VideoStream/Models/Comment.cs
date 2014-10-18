using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VideoStream.Models
{
    public class Comment
    {
        [Required]
        public int author { get; set; }

        [Required]
        public int recipient { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime dateTime { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string entry { get; set; }

        public Nullable<int> isCommentFor { get; set; }

        public string author_name { get; set; }
    }
}
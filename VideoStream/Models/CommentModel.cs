using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoStream.Models
{
    public class CommentModel
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string author { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime dateTime { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string comment { get; set; }
    }
}
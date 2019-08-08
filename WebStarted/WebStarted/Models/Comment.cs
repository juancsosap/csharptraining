using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebStarted.Models
{
    public class Comment
    {
        public Int32 Id { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public String Content { get; set; }

        // [Required]
        // public Int32 AuthorId { get; set; }
        // public virtual User Author { get; set; }
        
        [Required]
        public Int32 BlogPostId { get; set; }
        public virtual BlogPost BlogPost { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Publication Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Publication { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSite.Models
{
    public class Comment : Indexable
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Publication Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Publication { get; set; }

        public int BlogPostId { get; set; }
        public virtual BlogPost BlogPost { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebStarted.Models
{
    public class BlogPost
    {
        public Int32 Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "The field {0} length must be between {2} and {1} characters")]
        public String Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(Int32.MaxValue, MinimumLength = 100, ErrorMessage = "The field {0} length must be between {2} and {1} characters")]
        public String Content { get; set; }

        [Required]
        public BlogPostCategory Category { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Publication Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Publication { get; set; }
        
        // [Required]
        // public Int32 AuthorId { get; set; }
        // public virtual User Author { get; set; }
        
        public List<Comment> Comments { get; set; }
    }

    public enum BlogPostCategory { SPORTS, FOODS, RELIGION, FUN, SCIENCE }
}
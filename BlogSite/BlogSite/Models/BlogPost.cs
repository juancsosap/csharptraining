using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogSite.Models
{
    public class BlogPost : Indexable
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "The field {0} length must be between {2} and {1} characters")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(Int32.MaxValue, MinimumLength = 100, ErrorMessage = "The field {0} length must be between {2} and {1} characters")]
        public string Content { get; set; }

        [Required]
        [DefaultValue(BlogPostCategory.SPORTS)]
        public BlogPostCategory Category { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Publication Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Publication { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }

    public enum BlogPostCategory { SPORTS, FOODS, RELIGION, FUN, SCIENCE }
}
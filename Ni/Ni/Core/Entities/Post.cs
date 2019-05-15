using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ni.Core.Entities
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Text { get; set; }
        
        [Required]
        public List<Tag> Tags { get; set; }
    }
}
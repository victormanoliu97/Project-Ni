using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace
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
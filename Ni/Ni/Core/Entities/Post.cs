using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ni.Core.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Text { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ni.Core.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Category")]
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }

}
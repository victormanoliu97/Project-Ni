using System.ComponentModel.DataAnnotations;

namespace Ni.Core.Entities
{
    public class Commentary
    {
        [Key]
        public int CommentaryId { get; set; }
        
        [Required]
        public string Text { get; set; }
    }
}
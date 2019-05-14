using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace
{
    public class Commentary
    {
        [Key]
        public int CommentaryId { get; set; }
        
        [Required]
        public string Text { get; set; }
    }
}
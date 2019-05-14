using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DefaultNamespace
{
    public class PostCommentary
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        [Required]
        [ForeignKey("Commentary")]
        public int CommentaryId { get; set; }
    }
}
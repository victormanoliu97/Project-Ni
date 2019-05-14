using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DefaultNamespace
{
    public class PostCommentary
    {
        [ForeignKey("Post")]
        public int PostId { get; set; }
        
        [ForeignKey("Commentary")]
        public int CommentaryId { get; set; }
    }
}
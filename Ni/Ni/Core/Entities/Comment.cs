using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ni.Core.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Post")]
        [Required]
        public int PostId { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
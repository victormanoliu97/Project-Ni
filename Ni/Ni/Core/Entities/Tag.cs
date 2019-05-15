using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ni.Core.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Post")]
        public int PostId { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
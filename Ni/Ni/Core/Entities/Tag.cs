using System.ComponentModel.DataAnnotations;

namespace Ni.Core.Entities
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        
        [Required]
        public string Title { get; set; }
    }
}
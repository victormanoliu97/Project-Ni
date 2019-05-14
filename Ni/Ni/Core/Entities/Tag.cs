using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        
        [Required]
        public string Title { get; set; }
    }
}
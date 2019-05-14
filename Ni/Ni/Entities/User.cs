using System;
using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string PasswordHash { get; set; }
        
        [Required]
        public string PasswordHashed { get; set; }
       
    }
}
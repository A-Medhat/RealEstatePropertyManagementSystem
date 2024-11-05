using System.ComponentModel.DataAnnotations;

namespace realEstate1.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; } // Primary Key

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } // Admin or User
    }
}

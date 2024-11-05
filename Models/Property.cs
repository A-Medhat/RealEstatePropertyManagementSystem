using System.ComponentModel.DataAnnotations;

namespace realEstate1.Models
{
    public class Property 
    {
        [Key]
        public int PropertyID { get; set; } // Primary Key

        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(255, ErrorMessage = "Address cannot exceed 255 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Owner Name is required.")]
        [MaxLength(100, ErrorMessage = "Owner name cannot exceed 100 characters.")]
        public string Owner { get; set; }

        [Required(ErrorMessage = "Owner phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Owner phone number must be exactly 11 digits.")]
        public int Ownerphone { get; set; }

        [Required(ErrorMessage = "Property type is required.")]
        [MaxLength(50, ErrorMessage = "Type cannot exceed 50 characters.")]
        public string Type { get; set; }

        //[MaxLength(20, ErrorMessage = "Status cannot exceed 20 characters.")]
        //public string? Status { get; set; }

        public ICollection<Lease>? Leases { get; set; }

        [Required(ErrorMessage = "Price per day is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Price per day must be greater than 0.")]
        public decimal PricePerDay { get; set; }

        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public ICollection<PropertyImage>? PropertiesImages { get; set; }
    }


}

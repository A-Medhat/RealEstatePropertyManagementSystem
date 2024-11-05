using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace realEstate1.Models
{
    public class Tenant
    {
        [Key]
        public int TenantID { get; set; } // Primary Key

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string PhoneNumber { get; set; }

        public int PropertyID { get; set; }

        [ForeignKey("PropertyID")]
        public Property Property { get; set; }

        public ICollection<Lease> Leases { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<IssueReport> IssueReports { get; set; }
    }

}

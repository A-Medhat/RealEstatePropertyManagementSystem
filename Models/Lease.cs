using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace realEstate1.Models
{
public class Lease
{
    [Key]
    public int LeaseID { get; set; } // Primary Key

    // Foreign Key to Property
    public int PropertyID { get; set; }

    [ForeignKey("PropertyID")]
    public Property Property { get; set; }

    // Foreign Key to Tenant
    public int TenantID { get; set; }

    [ForeignKey("TenantID")]
    public Tenant Tenant { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now; // Default to current date

    [Required(ErrorMessage = "Start date is required.")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "End date is required.")]
    [DataType(DataType.Date)]

    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "Terms are required.")]
    [MaxLength(1000, ErrorMessage = "Terms cannot exceed 1000 characters.")]
    public string Terms { get; set; }

        // Validation method for checking that EndDate is after StartDate

    }

}

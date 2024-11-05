using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace realEstate1.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; } // Primary Key

        // Foreign Key to Tenant
        public int TenantID { get; set; }
        [ForeignKey("TenantID")]
        public Tenant Tenant { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Status { get; set; }

        // New fields for payment via Visa/Mastercard
        [Required(ErrorMessage = "Credit card number is required.")]
        [RegularExpression(@"^[0-9]{16}$", ErrorMessage = "Credit card number must be 16 digits.")]
        [Display(Name = "Credit Card Number")]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "CVV is required.")]
        [RegularExpression(@"^[0-9]{3}$", ErrorMessage = "CVV must be 3 digits")]
        public string CVV { get; set; }

        [Required(ErrorMessage = "Expiration date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Expiration Date")]
        [CustomValidation(typeof(Payment), nameof(ValidateExpirationDate))]
        public DateTime ExpirationDate { get; set; }

   
        public static ValidationResult? ValidateExpirationDate(DateTime expirationDate, ValidationContext context)
        {
            if (expirationDate < DateTime.Now)
            {
                return new ValidationResult("The expiration date must be in the future.");
            }
            return ValidationResult.Success;
        }
    }

}

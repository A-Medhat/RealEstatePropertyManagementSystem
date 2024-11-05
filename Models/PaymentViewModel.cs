using System.ComponentModel.DataAnnotations;

namespace realEstate1.Models
{
    public class PaymentViewModel
    {
        public int TenantID { get; set; }
        public int LeaseID { get; set; }
        public decimal Amount { get; set; }

        // Ensure these match the form fields
        [Required(ErrorMessage = "Card number is required.")]
        [RegularExpression(@"^[0-9]{16}$", ErrorMessage = "Credit card number must be 16 digits.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Expiration date is required.")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "CVV is required.")]
        [RegularExpression(@"^[0-9]{3}$", ErrorMessage = "CVV must be 3 digits.")]
        public string CVV { get; set; }
    }

}

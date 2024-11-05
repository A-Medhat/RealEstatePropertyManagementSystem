using Microsoft.EntityFrameworkCore;
using realEstate1.Data;
using realEstate1.Interfaces;
using realEstate1.Models;

namespace realEstate1.servcies
{
    public class PaymentService : IPaymentcs
    {
        private readonly MyAppDbcontext _context;

        public PaymentService(MyAppDbcontext context)
        {
            _context = context;
        }
        public bool ProcessPayment( string cardNumber, DateTime expirationDate, string cvv)
        {


            if (expirationDate < DateTime.Now)
            {
                return false;
            }

            
            return true; // Payment is successful
        }

 
        public void SavePayment(Payment payment)
        {
            _context.payments.Add(payment);
            _context.SaveChanges();
        }
    }
}

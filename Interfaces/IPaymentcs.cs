using realEstate1.Models;

namespace realEstate1.Interfaces
{
    public interface IPaymentcs
    {
        bool ProcessPayment(string cardNumber, DateTime expirationDate, string cvv);
        void SavePayment(Payment payment);
    }
}


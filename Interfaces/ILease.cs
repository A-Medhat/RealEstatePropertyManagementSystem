using realEstate1.Models;

namespace realEstate1.Interfaces
{
    public interface ILease
    {
        Lease CreateLease(int propertyId, int tenantId, DateTime startDate, DateTime endDate, string terms);
        public decimal CalculatePaymentAmount(int propertyId, DateTime startDate, DateTime endDate);
        public void RemoveLease(int leaseId);
        public IEnumerable<Lease> GetAllLeases();
        public void Updatelease(Lease lease);
        public Lease GetLeaseById(int id);

    }
}

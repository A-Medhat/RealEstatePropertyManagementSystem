using Microsoft.EntityFrameworkCore;
using realEstate1.Data;
using realEstate1.Interfaces;
using realEstate1.Models;

namespace realEstate1.servcies
{
    public class LeaseService : ILease
    {
        private readonly MyAppDbcontext _context;

        public LeaseService(MyAppDbcontext context)
        {
            _context = context;
        }

        public Lease CreateLease(int propertyId, int tenantId, DateTime startDate, DateTime endDate, string terms)
        {
            var lease = new Lease
            {
                PropertyID = propertyId,
                TenantID = tenantId,
                StartDate = startDate,
                EndDate = endDate,
                Terms = terms
            };

            _context.leases.Add(lease);
            _context.SaveChanges();
            return lease;
        }
        public bool IsPropertyAvailable(int propertyId, DateTime startDate, DateTime endDate)
        {
            var existingLeases = _context.leases
                .Where(l => l.PropertyID == propertyId &&
                       (l.StartDate < endDate && l.EndDate > startDate)) // Overlapping dates check
                .ToList();

            return !existingLeases.Any(); 
        }
        public decimal CalculatePaymentAmount(int propertyId, DateTime startDate, DateTime endDate)
        {
             var property = _context.properties.FirstOrDefault(p => p.PropertyID == propertyId);
            if (property != null)
            {
                int numberOfDays = (endDate - startDate).Days;
                return numberOfDays * property.PricePerDay;
            }

            throw new Exception("Property not found.");
        }
        public void RemoveLease(int leaseId)
        {
            var lease = _context.leases.Find(leaseId);
            if (lease != null)
            {
                _context.leases.Remove(lease);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Lease> GetAllLeases()
        {
            var leases = _context.leases
        .Include(l => l.Property) 
        .Include(l => l.Tenant)   
        .ToList();


            return leases;
        }
        public void Updatelease(Lease lease)
        {
            _context.Update(lease);
            _context.SaveChanges();
        }
        public Lease GetLeaseById(int id)
        {
            return _context.leases.Include(l => l.Property)
        .Include(l => l.Tenant).FirstOrDefault(m => m.LeaseID == id);
        }


    }
}

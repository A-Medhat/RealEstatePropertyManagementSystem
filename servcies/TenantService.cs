using realEstate1.Data;
using realEstate1.Interfaces;
using realEstate1.Models;

namespace realEstate1.servcies
{
    public class TenantService:ITenant
    {
        private readonly MyAppDbcontext _context;

        public TenantService(MyAppDbcontext context)
        {
            _context = context;
        }

        public Tenant CreateTenant(string name, string contactInfo, int propertyId)
        {
            var tenant = new Tenant
            {
                Name = name,
                PhoneNumber = contactInfo,
                PropertyID = propertyId
            };

            _context.tenants.Add(tenant);
            _context.SaveChanges();
            return tenant;
        }
        public void RemoveTenant(int tenantId)
        {
            var tenant = _context.tenants.Find(tenantId);
            if (tenant != null)
            {
                _context.tenants.Remove(tenant);
                _context.SaveChanges();
            }
        }
    }

}

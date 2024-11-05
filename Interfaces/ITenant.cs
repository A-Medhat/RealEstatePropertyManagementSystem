using realEstate1.Models;

namespace realEstate1.Interfaces
{
    public interface ITenant
    {
        Tenant CreateTenant(string name, string contactInfo, int propertyId);
        public void RemoveTenant(int TenantId);
    }
}

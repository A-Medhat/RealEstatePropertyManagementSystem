using realEstate1.Models;

namespace realEstate1.Interfaces
{
    public interface IProperty
    {
        IEnumerable<Property> GetAllProperties();
        Property GetPropertyById(int id);
        void CreateProperty(Property property, List<IFormFile> imageFiles);
        void UpdateProperty(Property property);
        void DeleteProperty(int id);
        bool PropertyExists(int id);
        public List<DateTime> GetBookedDates(int propertyId);
        public IEnumerable<Property> GetPropertiesByCategory(string category);
    }
}

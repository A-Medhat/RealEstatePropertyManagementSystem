using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using realEstate1.Data;
using realEstate1.Interfaces;
using realEstate1.Models;

namespace realEstate1.servcies
{
    public class PropertyService : IProperty
    {
        private readonly MyAppDbcontext _context;
        private readonly IImages _imageService;

        public PropertyService(MyAppDbcontext context, IImages imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        public void CreateProperty(Property property, List<IFormFile> imageFiles)
        {
            _context.properties.Add(property);
            _context.SaveChanges();

            if (imageFiles != null && imageFiles.Count > 0)
            {
                _imageService.SaveImages(property.PropertyID, imageFiles);
            }
        }

        public Property GetPropertyById(int id)
        {
            return _context.properties
                .Include(p => p.PropertiesImages)
                .FirstOrDefault(m => m.PropertyID == id);
        }
        public void DeleteProperty(int id)
        {
            var property = _context.properties.Find(id);

            if (property != null)
            {
                _context.properties.Remove(property);
                _context.SaveChanges();
            }
        }
        public List<DateTime> GetBookedDates(int propertyId)
        {
            var bookedDates = new List<DateTime>();

            var leases = _context.leases.Where(l => l.PropertyID == propertyId).ToList();


            foreach (var lease in leases)
            {
                for (var date = lease.StartDate; date <= lease.EndDate; date = date.AddDays(1))
                {
                    bookedDates.Add(date);
                }
            }

            return bookedDates;
        }

        public IEnumerable<Property> GetAllProperties()
        {
         
            return _context.properties
                .Include(p => p.PropertiesImages)
                .ToList();
        }
        //public Property GetPropertyById(int id)
        //{
        //    return _context.properties.FirstOrDefault(m => m.PropertyID == id);
        //}

        public bool PropertyExists(int id)
        {
            return _context.properties.Any(e => e.PropertyID == id);
        }

        public void UpdateProperty(Property property)
        {
            _context.Update(property);
            _context.SaveChanges();
        }


        public IEnumerable<Property> GetPropertiesByCategory(string category) {


            return _context.properties.Include(p => p.PropertiesImages)
                .Where(p => p.Type == category) 
                .ToList();
        }
    }


}


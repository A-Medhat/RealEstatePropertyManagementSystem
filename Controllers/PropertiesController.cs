using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using realEstate1.Data;
using realEstate1.Interfaces;
using realEstate1.Models;
using realEstate1.servcies;

namespace realEstate1.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly ITenant _tenantService;
        private readonly ILease _leaseService;
        private readonly IPaymentcs _paymentService;
        private readonly IProperty _propertyService;
        public PropertiesController(IProperty propertyService,IPaymentcs paymentService, ITenant tenantService, ILease leaseService)
        {
            _propertyService = propertyService;
            _tenantService = tenantService;
            _leaseService = leaseService;
            _paymentService = paymentService;

        }
        public IActionResult Index()
        {
            var properties = _propertyService.GetAllProperties();
            return View(properties);
        }
        //public IActionResult Details(int? id)
        //{   
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var property = _propertyService.GetPropertyById(id.Value);
            
        //    if (property == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(property);
        //}

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
   
        public IActionResult Create(Property property, List<IFormFile> imageFiles)
        {
            if (ModelState.IsValid)
            {
                _propertyService.CreateProperty(property, imageFiles);
                return RedirectToAction("Index","Home");
            }
            return View(property);
        }

        public IActionResult Details(int id)
        {
            var property = _propertyService.GetPropertyById(id);
            if (property == null)
            {
                return NotFound();
            }
            return View(property);
        }





        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = _propertyService.GetPropertyById(id.Value);
            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        [HttpPost]
       
        public IActionResult Edit(int id, [Bind("PropertyID,Address,Owner,Type,Status")] Property property)
        {
            if (id != property.PropertyID)
            {
                return NotFound();
            }

            
                _propertyService.UpdateProperty(property);
                return RedirectToAction(nameof(Index));
            

            return View(property);
        }

        
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = _propertyService.GetPropertyById(id.Value);
            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _propertyService.DeleteProperty(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(int id)
        {
            return _propertyService.PropertyExists(id);
        }
        public IActionResult Rent(int id)
        {
            var property = _propertyService.GetPropertyById(id);
            if (property == null)
            {
                return NotFound();
            }

            var bookedDates = _propertyService.GetBookedDates(id);

            var model = new RentViewModel
            {
                PropertyId = id,
                Address = property.Address ?? "No Address Available", 
                Description = property.Description ?? "No Description Available", 
                PricePerDay = property.PricePerDay,
              
            };

            ViewBag.BookedDates = bookedDates.Select(d => d.ToString("yyyy-MM-dd")).ToList();

            return View(model); 
        }

  
        [HttpPost]
        
        public IActionResult Rent(RentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                
                return View(model);
            }

            try
            {
                
                var tenant = _tenantService.CreateTenant(model.TenantName, model.TenantContact, model.PropertyId);

                var lease = _leaseService.CreateLease(model.PropertyId, tenant.TenantID, model.StartDate, model.EndDate, "Standard lease terms");
                decimal amount = _leaseService.CalculatePaymentAmount(model.PropertyId, model.StartDate, model.EndDate);

          
                //var payment = _paymentService.CreatePayment(tenant.TenantID, amount, DateTime.Now);

                return RedirectToAction("Payment", "Payment", new
                {
                    tenantId = tenant.TenantID,
                    leaseId = lease.LeaseID,
                    amount = amount
                });
            }
            catch (Exception ex)
            {
                
                return View("Error");
            }
        }
        public IActionResult GetPropritesByCategroy(string Category) {
            ViewBag.Category = Category;
            var properties =_propertyService.GetPropertiesByCategory(Category);
            return View(properties);
        }

    }
}

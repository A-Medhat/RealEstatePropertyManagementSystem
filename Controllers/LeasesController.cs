using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using realEstate1.Interfaces;
using realEstate1.Models;
using realEstate1.servcies;

namespace realEstate1.Controllers
{
    public class LeasesController : Controller
    {
        private readonly ILease _leaseService;

        public LeasesController(ILease leaseService)
        {
            _leaseService = leaseService;
        }

        public IActionResult Index()
        {
        var leases=_leaseService.GetAllLeases();

    var leaseViewModels = leases.Select(l => new LeaseViewModel
    {
        LeaseID = l.LeaseID,
        PropertyAddress = l.Property.Address,
        TenantName = l.Tenant.Name,
        StartDate = l.StartDate,
        EndDate = l.EndDate
    }).ToList();

    return View(leaseViewModels);

        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lease = _leaseService.GetLeaseById(id.Value);
            if (lease == null)
            {
                return NotFound();
            }

           
            var leaseViewModel = new LeaseViewModel
            {
                LeaseID = lease.LeaseID,
                //PropertyID = lease.PropertyID,
                PropertyAddress = lease.Property.Address, 
                TenantName = lease.Tenant.Name, 
                StartDate = lease.StartDate,
                EndDate = lease.EndDate,
                Terms = lease.Terms
            };

            return View(leaseViewModel);
        }

     
        [HttpPost]
        public IActionResult Edit(int id, LeaseViewModel leaseViewModel)
        {
            if (id != leaseViewModel.LeaseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingLease = _leaseService.GetLeaseById(id);
                if (existingLease == null)
                {
                    return NotFound();
                }

                existingLease.StartDate = leaseViewModel.StartDate;
                existingLease.EndDate = leaseViewModel.EndDate;
                existingLease.Terms = leaseViewModel.Terms;
                _leaseService.Updatelease(existingLease);
                return RedirectToAction(nameof(Index));
            }

            return View(leaseViewModel);
        }



        // GET: Leases/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lease = _leaseService.GetLeaseById(id.Value);
            if (lease == null)
            {
                return NotFound();
            }

            // Map the Lease to LeaseViewModel
            var leaseViewModel = new LeaseViewModel
            {
                LeaseID = lease.LeaseID,
                PropertyAddress = lease.Property.Address,
                TenantName = lease.Tenant.Name,
                StartDate = lease.StartDate,
                EndDate = lease.EndDate,
                Terms = lease.Terms
            };

            return View(leaseViewModel);
        }

        // POST: Leases/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Confirming the lease deletion
            var lease = _leaseService.GetLeaseById(id);
            if (lease == null)
            {
                return NotFound();
            }

            // Call the service to remove the lease
            _leaseService.RemoveLease(id);
            return RedirectToAction(nameof(Index));
        }




    }
}

using Microsoft.AspNetCore.Mvc;
using realEstate1.Interfaces;
using realEstate1.Models;
using realEstate1.servcies;

namespace realEstate1.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ITenant _tenantService;
        private readonly ILease _leaseService;
        private readonly IPaymentcs _paymentService;


        public PaymentController(IPaymentcs paymentService, ITenant tenantService, ILease leaseService)
        {
            _tenantService = tenantService;
            _leaseService = leaseService;
            _paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult Payment(int tenantId, int leaseId, decimal amount)
        {
            var paymentViewModel = new PaymentViewModel
            {
                TenantID = tenantId,
                LeaseID = leaseId,
                Amount = amount
            };

       
            return View(paymentViewModel);
        }

        [HttpPost]
        public IActionResult ProcessPayment(PaymentViewModel model)
        {

 
            if (ModelState.IsValid)
            {
                var payment = new Payment
                {
                    TenantID = model.TenantID,
                    Amount = model.Amount,
                    Date = DateTime.Now,
                    Status = "Completed",
                    CreditCardNumber = model.CardNumber, 
                    CVV = model.CVV, 
                    ExpirationDate = model.ExpirationDate
                };

                _paymentService.SavePayment(payment);
                return RedirectToAction("Index", "Home");
            }
            else
            {
               
               
                //_leaseService.RemoveLease(model.LeaseID);
                //_tenantService.RemoveTenant(model.TenantID);

                return View("Payment", model);
            }
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using realEstate1.Interfaces;
using realEstate1.Models;
using System.Diagnostics;

namespace realEstate1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProperty _propertyService;
        public HomeController(ILogger<HomeController> logger, IProperty propertyService)
        {
            _logger = logger;
            _propertyService = propertyService;
        }


        public IActionResult Index()
        {
            var properties = _propertyService.GetAllProperties();
            return View(properties);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ProductManagement.DataAccess.Services;
using ProductManagement.Models;
using System.Diagnostics;

namespace ProductManagement.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly ProductServices _productServices = new();

        [HttpGet]
        public IActionResult Index()
        {
            var products = _productServices.GetProducts();

            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

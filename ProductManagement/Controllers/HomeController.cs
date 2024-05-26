using Microsoft.AspNetCore.Mvc;
using ProductManagement.DataAccess.DBContext;
using ProductManagement.DataAccess.Objects;
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
            var models = new List<ProductModel>();

            foreach (var item in _productServices.GetProducts())
            {
                
            }

            return View(models);
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

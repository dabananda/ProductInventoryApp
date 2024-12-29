using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductInventoryApp.Models;
using ProductInventoryApp.Repository;

namespace ProductInventoryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepo _productRepo;

        public HomeController(ILogger<HomeController> logger, IProductRepo productRepo)
        {
            _logger = logger;
            _productRepo = productRepo;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepo.GetAllProducts();
            ViewBag.TotalValue = products.Sum(x => x.Price * x.Quantity);
            ViewBag.TotalQuantity = products.Sum(x => x.Quantity);
            ViewBag.TotalCategories = products.Select(x => x.Category).Distinct().Count();
            ViewBag.TotalItems = products.Select(x => x.Name).Distinct().Count();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

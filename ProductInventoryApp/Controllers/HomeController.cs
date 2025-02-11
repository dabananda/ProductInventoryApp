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
        private readonly ICategoryRepo _categoryRepo;

        public HomeController(ILogger<HomeController> logger, IProductRepo productRepo, ICategoryRepo categoryRepo)
        {
            _logger = logger;
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepo.GetAllProducts();
            var categories = await _categoryRepo.GetAllCategories();
            ViewBag.TotalValue = products.Sum(x => x.Price * x.Quantity);
            ViewBag.TotalQuantity = products.Sum(x => x.Quantity);
            ViewBag.TotalCategories = categories.Count();
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

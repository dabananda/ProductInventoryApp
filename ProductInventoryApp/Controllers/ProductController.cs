using Microsoft.AspNetCore.Mvc;
using ProductInventoryApp.Data;
using ProductInventoryApp.Models;

namespace ProductInventoryApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all products
        [HttpGet]
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            var totalValue = products.Sum(x => x.Price * x.Quantity);
            var totalQuantity = products.Sum(x => x.Quantity);
            var totalCategories = products.Select(x => x.Category).Distinct().Count();
            var totalUniqueItems = products.Select(x => x.Name).Distinct().Count();
            ViewBag.TotalValue = totalValue;
            ViewBag.TotalQuantity = totalQuantity;
            ViewBag.TotalCategories = totalCategories;
            ViewBag.TotalItems = totalUniqueItems;
            return View(products);
        }

        // Get "Add Product" page
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Add new product
        [HttpPost]
        public IActionResult Create(PostProductModel postProductModel)
        {
            var product = new Product
            {
                Name = postProductModel.Name,
                Category = postProductModel.Category,
                Price = postProductModel.Price,
                Quantity = postProductModel.Quantity,
                QuantityUnit = postProductModel.QuantityUnit
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Get the edit product form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                var updatedProduct = new PutProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Category = product.Category,
                    Price = product.Price,
                    Quantity = product.Quantity,
                };
                return View(updatedProduct);
            }
            return View(null);
        }

        // Update the product
        [HttpPost]
        public IActionResult Edit(PutProductModel putProductModel)
        {
            var existingProduct = _context.Products.Find(putProductModel.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = putProductModel.Name;
                existingProduct.Category = putProductModel.Category;
                existingProduct.Price = putProductModel.Price;
                existingProduct.Quantity = putProductModel.Quantity;
                existingProduct.QuantityUnit = putProductModel.QuantityUnit;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Delete product
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

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
        public IActionResult Create(CreateProductModel createProductModel)
        {
            var product = new Product
            {
                Name = createProductModel.Name,
                Category = createProductModel.Category,
                Price = createProductModel.Price,
                Quantity = createProductModel.Quantity,
                QuantityUnit = createProductModel.QuantityUnit,
                InStock = createProductModel.Quantity > 0
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
                var updatedProduct = new UpdateProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Category = product.Category,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    QuantityUnit = product.QuantityUnit,
                };
                return View(updatedProduct);
            }
            return View(null);
        }

        // Update the product
        [HttpPost]
        public IActionResult Edit(UpdateProductModel updateProductModel)
        {
            var existingProduct = _context.Products.Find(updateProductModel.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = updateProductModel.Name;
                existingProduct.Category = updateProductModel.Category;
                existingProduct.Price = updateProductModel.Price;
                existingProduct.Quantity = updateProductModel.Quantity;
                existingProduct.QuantityUnit = updateProductModel.QuantityUnit;
                existingProduct.InStock = updateProductModel.Quantity > 0;
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

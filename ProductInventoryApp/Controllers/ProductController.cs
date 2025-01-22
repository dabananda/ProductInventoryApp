using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductInventoryApp.Models;
using ProductInventoryApp.Repository;

namespace ProductInventoryApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _productRepo;
        private readonly ICategoryRepo _categoryRepo;
        public ProductController(IProductRepo productRepo, ICategoryRepo categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        // Get all products
        public async Task<IActionResult> Index()
        {
            var products = await _productRepo.GetAllProducts();
            var categories = await _categoryRepo.GetAllCategories();
            ViewBag.TotalValue = products.Sum(x => x.Price * x.Quantity);
            ViewBag.TotalQuantity = products.Sum(x => x.Quantity);
            ViewBag.TotalCategories = categories.Count();
            ViewBag.TotalItems = products.Select(x => x.Name).Distinct().Count();
            return View(products);
        }

        // GET: Get the create new product page
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryRepo.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        // POST: Add new product
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ImageFile != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        product.ImageFile.CopyTo(memoryStream);
                        product.Image = memoryStream.ToArray();
                    }
                }
                await _productRepo.AddProduct(product);
                TempData["success"] = "Product added successfully!";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // Get the edit product form
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepo.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            var categories = await _categoryRepo.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Update the product
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ImageFile != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        product.ImageFile.CopyTo(memoryStream);
                        product.Image = memoryStream.ToArray();
                    }
                }
                await _productRepo.UpdateProduct(product);
                TempData["success"] = "Product updated successfully!";
                return RedirectToAction("Index");
            }
            var categories = await _categoryRepo.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // Delete product
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepo.DeleteProduct(id);
            TempData["success"] = "Product deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}

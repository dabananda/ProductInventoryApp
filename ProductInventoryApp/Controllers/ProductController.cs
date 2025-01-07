using Microsoft.AspNetCore.Mvc;
using ProductInventoryApp.Models;
using ProductInventoryApp.Repository;

namespace ProductInventoryApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _productRepo;
        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        // Get all products
        public async Task<IActionResult> Index()
        {
            var products = await _productRepo.GetAllProducts();
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

        // GET: Get the create new product page
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Add new product
        //[HttpPost]
        //public async Task<IActionResult> Create(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (product.ImageFile != null)
        //        {
        //            using (var memoryStream = new MemoryStream())
        //            {
        //                product.ImageFile.CopyTo(memoryStream);
        //                product.Image = memoryStream.ToArray();
        //            }
        //        }
        //        await _productRepo.AddProduct(product);
        //        TempData["success"] = "Product added successfully!";
        //        return RedirectToAction("Index");
        //    }
        //    return View(product);
        //}

        // Get the edit product form
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepo.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
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

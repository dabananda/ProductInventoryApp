using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductInventoryApp.Data;
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
        [HttpGet]
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

        // Get "Add Product" page
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Add new product
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductModel createProductModel)
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
            await _productRepo.AddProduct(product);
            return RedirectToAction("Index");
        }

        // Get the edit product form
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepo.GetProductById(id);
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
        public async Task<IActionResult> Edit(UpdateProductModel updateProductModel)
        {
            var product = new Product
            {
                Id = updateProductModel.Id,
                Name = updateProductModel.Name,
                Category = updateProductModel.Category,
                Price = updateProductModel.Price,
                Quantity = updateProductModel.Quantity,
                QuantityUnit = updateProductModel.QuantityUnit,
                InStock = updateProductModel.Quantity > 0
            };
            var existingProduct = await _productRepo.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        // Delete product
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepo.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}

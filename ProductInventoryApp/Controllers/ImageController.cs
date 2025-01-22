using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductInventoryApp.Repository;

namespace ProductInventoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepo _imageRepo;
        public ImageController(IImageRepo imageRepo)
        {
            _imageRepo = imageRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("This is ImageController");
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var imageUrl = await _imageRepo.Upload(file);
            if (imageUrl == null)
            {
                return Problem("Image upload failed", null, (int) HttpStatusCode.InternalServerError);
            }
            return new JsonResult(new {link = imageUrl });
        }
    }
}

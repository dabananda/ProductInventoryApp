using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace ProductInventoryApp.Repository
{
    public class ImageRepo : IImageRepo
    {
        private readonly IConfiguration _configuration;
        private readonly Account _account;
        public ImageRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            _account = new Account(
                _configuration.GetSection("Cloudinary")["CloudName"],
                _configuration.GetSection("Cloudinary")["ApiKey"],
                _configuration.GetSection("Cloudinary")["ApiSecret"]
            );
        }

        public async Task<string> Upload(IFormFile file)
        {
            var client = new Cloudinary(_account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                DisplayName = file.FileName
            };
            var uploadResult = await client.UploadAsync(uploadParams);
            if (uploadResult != null && uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadResult.SecureUrl.ToString();
            }
            return null;
        }
    }
}

namespace ProductInventoryApp.Repository
{
    public interface IImageRepo
    {
        Task<string> Upload(IFormFile file);
    }
}

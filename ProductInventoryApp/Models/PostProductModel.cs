namespace ProductInventoryApp.Models
{
    public class PostProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string QuantityUnit { get; set; }
    }
}

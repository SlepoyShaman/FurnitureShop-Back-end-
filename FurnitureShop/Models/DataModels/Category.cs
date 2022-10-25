namespace FurnitureShop.Models.DataModels
{
    public class Category : IWithId
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}

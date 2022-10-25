namespace FurnitureShop.Models.DataModels
{
    public class Company : IWithId
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}

namespace FurnitureShop.Models.CartModels
{
    public class CartProduct
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }
        public int Quantity { get; set; }
    }
}

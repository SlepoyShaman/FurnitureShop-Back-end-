namespace FurnitureShop.Models.CartModels
{
    public class Cart
    {
        public List<CartProduct> Products { get; set; }

        public decimal GetTotal()
        {
            decimal total = 0;
            foreach (var p in Products) total += p.Price * p.Quantity;
            return total;
        }
    }
}

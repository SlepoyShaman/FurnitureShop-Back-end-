using FurnitureShop.Extentions;
using FurnitureShop.Models.DataModels;

namespace FurnitureShop.Models.CartModels
{
    public class ShopingCart
    {
        private readonly ISession _session;
        public ShopingCart(ISession session)
        {
            _session = session;
        }

        public void AddToCart(Product product)
        {
            var cartList = _session.GetCart<List<CartProduct>>();

            if (cartList == null)
                cartList = new List<CartProduct>() { new CartProduct { ProductId = product.Id, Name = product.Name,
                                                     Price = product.Price, Img = product.Img, Quantity = 1 } };
            else if (cartList.Any(p => p.ProductId == product.Id))
                cartList.Find(p => p.ProductId == product.Id).Quantity += 1;
            else
                cartList.Add(new CartProduct
                {
                    ProductId = product.Id,
                    Price = product.Price,
                    Name = product.Name,
                    Img = product.Img,
                    Quantity = 1
                });

            _session.SetCart(cartList);
            
        }

        public void RemoveFromCart(int productId)
        {
            var cartList = _session.GetCart<List<CartProduct>>();
            if (cartList.Any(p => p.ProductId == productId))
            {
                int cartProductQuantity = cartList.Find(p => p.ProductId == productId).Quantity;

                if (cartProductQuantity < 2)
                    cartList.Remove(cartList.Find(p => p.ProductId == productId));
                else
                    cartList.Find(p => p.ProductId == productId).Quantity -= 1;

                _session.SetCart(cartList);
            }
            else throw new Exception("There is no product in a cart with that id");
        }

        public Cart GetCart()
        {
            Cart cart = new Cart();
            cart.Products = _session.GetCart<List<CartProduct>>() ?? new List<CartProduct>();
            return cart;
        }

    }
}

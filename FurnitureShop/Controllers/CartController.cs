using FurnitureShop.Data;
using Microsoft.AspNetCore.Mvc;
using FurnitureShop.Models.DataModels;
using FurnitureShop.Models.VIewModels;
using FurnitureShop.Models.CartModels;

namespace FurnitureShop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IRepository _repository;

        public CartController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]GetProductModel model)
        {
            var product = await _repository.GetByIdAsync<Product>(model.ProductId);
            new ShopingCart(HttpContext.Session).AddToCart(product);
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Remove([FromBody] GetProductModel model)
        {
            try
            {
                new ShopingCart(HttpContext.Session).RemoveFromCart(model.ProductId);
                return Ok();
            } 
            catch(Exception ex)
            {
                return BadRequest( new { Error = ex.Message });
            }

        }

        [HttpGet]
        public IActionResult Show()
        {
            var cart = new ShopingCart(HttpContext.Session).GetCart();
            return Ok(new { Products = cart.Products, Total = cart.GetTotal() });
        }

    }
}

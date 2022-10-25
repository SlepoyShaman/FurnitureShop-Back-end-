using FurnitureShop.Data;
using FurnitureShop.Models.DataModels;
using FurnitureShop.Models.VIewModels;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FurnitureShop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IRepository _repository;
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        private readonly int ProductsOnHomePage = 9;

        [HttpPost]
        public IActionResult Index() 
            => Ok(_repository.GetAll<Product>().Take(ProductsOnHomePage)
                .Select(p => new RetProductModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Img = p.Img
                }));
            
    }
}

using FurnitureShop.Data;
using FurnitureShop.Models.DataModels;
using FurnitureShop.Models.VIewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FurnitureShop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IRepository _repository;
        public ShopController(IRepository repository)
        {
            _repository = repository;
        }

        private readonly int ProductsOnPage = 6;

        [HttpPost("GetSideBarData")]
        public async Task<IActionResult> GetSideBarData()
        {
            var categories =  await _repository.GetAll<Category>().Select(c => new { Id = c.Id, Name = c.Name }).ToArrayAsync();
            var companies = await _repository.GetAll<Company>().Select(c => new { Id = c.Id, Name = c.Name }).ToArrayAsync();

            return Ok(new
            {
                Categories = categories,
                Companies = companies
            });
        }
            
        [HttpPost("GetCategorysProducts")]
        public IActionResult GetCategoryProducts([FromBody] GetCategorysProductsModel model)
        {
            IQueryable<Product> products = _repository.GetAll<Product>().Where(p => p.CategoryId == model.CategoryId);

            if (model.Companies.Any())
            {
                products = products.Where(p => model.Companies.Contains(p.CompanyId));
            }
           
            return Ok(products.Skip(ProductsOnPage * (model.CurrPage - 1))
                              .Take(ProductsOnPage)
                              .Select(p => new RetProductModel { Id = p.Id, Name = p.Name, Price = p.Price, Img = p.Img }));
        }
    }
}

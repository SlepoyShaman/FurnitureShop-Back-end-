using FurnitureShop.Data;
using FurnitureShop.Models.DataModels;
using FurnitureShop.Models.VIewModels;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly List<Category> _categories;
        private readonly List<Company> _companies;
        private readonly int ProductsOnPage = 6;

        public ShopController(IRepository repository)
        {
            _repository = repository;
            _categories = _repository.GetAll<Category>().ToList();
            _companies = _repository.GetAll<Company>().ToList();
        }

        [HttpGet("GetSideBarData")]
        public IActionResult GetSideBarData() =>
           Ok(new
            {
                Categories = _categories.Select(c => new { Id = c.Id, Name = c.Name }),
                Companies = _companies.Select(c => new { Id = c.Id, Name = c.Name })
            });
        
            
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

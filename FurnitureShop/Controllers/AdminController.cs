using FurnitureShop.Data;
using FurnitureShop.Models.DataModels;
using FurnitureShop.Models.VIewModels;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IWebHostEnvironment _appEnvironment;
        public AdminController(IRepository repository, IWebHostEnvironment appEnvironment)
        {
            _repository = repository;
            _appEnvironment = appEnvironment;
        }

        [HttpPost("AddNewProduct")]
        public async Task<IActionResult> AddNewProduct([FromForm]GetNewProductModel model)
        {
            string path = "/img/" + model.Img.FileName;
            
            using(var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await model.Img.CopyToAsync(fileStream);
            }

            Product product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Img = model.Img.FileName,
                CompanyId = model.CompanyId,
                CategoryId = model.CategoryId
            };

            await _repository.AddNewItemAsync<Product>(product);

            return Ok();
        }

        [HttpDelete("RemoveProductById")]
        public async Task<IActionResult> RemoveProductById([FromBody]GetProductModel model)
        {
            try
            {
                await _repository.RemoveByIdAsync<Product>(model.ProductId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            } 
        }
    }
}

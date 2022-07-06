using System;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsRepository _productsRepo;

        public ProductsController(ProductsRepository productsRepo)
        {
            _productsRepo = productsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _productsRepo.SelectAllAsync();
            return Ok(products);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSingleAsync(Guid id)
        {
            var product = await _productsRepo.SelectSingleAsync(id);
            return Ok(product);
        }

        public record PostData(string Name, Guid CategoryId, int Stock, string Unit, float Price);

        [HttpPost]
        public async Task<IActionResult> PostAsync(PostData data)
        {
            var product =
                Product.Create(data.Name, data.CategoryId, data.Stock, data.Unit, data.Price);

            await _productsRepo.InsertAsync(product);
            return Ok(product.ProductId);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Product product)
        {
            await _productsRepo.UpdateAsync(product);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _productsRepo.DeleteAsync(id);
            return Ok();
        }
    }
}
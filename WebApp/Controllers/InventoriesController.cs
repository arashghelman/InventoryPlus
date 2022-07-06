using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoriesController : Controller
    {
        private readonly InventoriesRepository _inventoriesRepo;

        public InventoriesController(InventoriesRepository inventoriesRepo)
        {
            _inventoriesRepo = inventoriesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var inventories = await _inventoriesRepo.SelectAllAsync();
            return Ok(inventories);
        }

        public record PostData(string RoomNumber, string FloorNumber, string ShelfNumber);

        [HttpPost]
        public async Task<IActionResult> PostAsync(PostData data)
        {
            var inventory = Inventory.Create(data.RoomNumber, data.FloorNumber, data.ShelfNumber);

            await _inventoriesRepo.InsertAsync(inventory);
            return Ok(inventory.InventoryId);
        }

        public record PutProductData(Guid ProductId);

        [HttpPost("{inventoryId:guid}/products")]
        public async Task<IActionResult> PutProductAsync(Guid inventoryId, PutProductData data)
        {
            await _inventoriesRepo.InsertProductAsync(inventoryId, data.ProductId);
            return Ok();
        }
    }
}


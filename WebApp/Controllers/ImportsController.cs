using System;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportsController : ControllerBase
    {
        private readonly ImportOrdersRepository _importOrdersRepo;
        private readonly OrdersRepository _ordersRepo;

        public ImportsController(ImportOrdersRepository importOrdersRepo,
            OrdersRepository ordersRepo)
        {
            _importOrdersRepo = importOrdersRepo;
            _ordersRepo = ordersRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var imports = await _importOrdersRepo.SelectAllAsync();
            return Ok(imports);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSingleAsync(Guid id)
        {
            var import = await _importOrdersRepo.SelectSingleAsync(id);
            return Ok(import);
        }

        public record PostData(Guid SourceId, DateTime ArrivalDate, string Description);

        [HttpPost]
        public async Task<IActionResult> PostAsync(PostData data)
        {
            var import = ImportOrder.Create(data.SourceId, data.ArrivalDate, data.Description);

            await _importOrdersRepo.InsertAsync(import);
            return Ok(import.OrderId);
        }

        public record PutData(Guid OrderId, string State);

        [HttpPut]
        public async Task<IActionResult> PutAsync(PutData data)
        {
            var import = await _importOrdersRepo.SelectSingleAsync(data.OrderId);

            if (import is null) return NotFound();

            Enum.TryParse(data.State, out OrderState orderState);
            import.ChangeState(orderState);

            await _ordersRepo.UpdateAsync(import);

            return Ok();
        }
    }
}


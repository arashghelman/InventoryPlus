using System;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExportsController : ControllerBase
    {
        private readonly ExportOrdersRepository _exportOrdersRepo;
        private readonly OrdersRepository _ordersRepo;

        public ExportsController(ExportOrdersRepository exportOrdersRepo,
            OrdersRepository ordersRepo)
        {
            _exportOrdersRepo = exportOrdersRepo;
            _ordersRepo = ordersRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var exports = await _exportOrdersRepo.SelectAllAsync();
            return Ok(exports);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSingleAsync(Guid id)
        {
            var export = await _exportOrdersRepo.SelectSingleAsync(id);
            return Ok(export);
        }

        public record PostData(Guid DestinationId, DateTime ExportDate, string Description);

        [HttpPost]
        public async Task<IActionResult> PostAsync(PostData data)
        {
            var export = ExportOrder.Create(data.DestinationId, data.ExportDate, data.Description);

            await _exportOrdersRepo.InsertAsync(export);
            return Ok(export.OrderId);
        }

        public record PutData(Guid OrderId, string State);

        [HttpPut]
        public async Task<IActionResult> PutAsync(PutData data)
        {
            var export = await _exportOrdersRepo.SelectSingleAsync(data.OrderId);

            if (export is null) return NotFound();

            Enum.TryParse(data.State, out OrderState orderState);
            export.ChangeState(orderState);

            await _ordersRepo.UpdateAsync(export);
            return Ok();
        }
    }
}


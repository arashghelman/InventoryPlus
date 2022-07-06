using System;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/orders/details")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly OrderDetailsRepository _orderDetailsRepo;

        public OrderDetailsController(OrderDetailsRepository orderDetailsRepo)
        {
            _orderDetailsRepo = orderDetailsRepo;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(OrderDetail orderDetail)
        {
            await _orderDetailsRepo.InsertAsync(orderDetail);
            return Ok();
        }
    }
}


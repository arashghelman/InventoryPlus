using System;
using Microsoft.AspNetCore.Mvc;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoresController : ControllerBase
    {
        private readonly StoresRepository _storesRepo;

        public StoresController(StoresRepository storesRepo)
        {
            _storesRepo = storesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var stores = await _storesRepo.SelectAllAsync();
            return Ok(stores);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSingleAsync(Guid id)
        {
            var store = await _storesRepo.SelectSingleAsync(id);
            return Ok(store);
        }
    }
}


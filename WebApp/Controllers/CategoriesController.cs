using System;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesRepository _categoriesRepo;

        public CategoriesController(CategoriesRepository categoriesRepo)
        {
            _categoriesRepo = categoriesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _categoriesRepo.SelectAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSingleAsync(Guid id)
        {
            var category = await _categoriesRepo.SelectSingleAsync(id);
            return Ok(category);
        }
    }
}
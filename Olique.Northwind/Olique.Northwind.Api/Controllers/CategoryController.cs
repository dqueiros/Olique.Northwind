using Microsoft.AspNetCore.Mvc;
using Olique.Northwind.Application.Dtos;
using Olique.Northwind.Application.Interfaces;

namespace Olique.Northwind.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDto dto)
        {
            var _category = await _categoryService.CreateAsync(dto);

            return Created($"api/categories/{_category.CategoryID}", _category);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryDto dto)
        {
            await _categoryService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpPatch]
        [Route("{id:int}/categoryName")]
        public async Task<IActionResult> PatchCategoryName(int id, [FromBody] string categoryName)
        {
            await _categoryService.UpdateNameAsync(id, categoryName);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }

    }
}

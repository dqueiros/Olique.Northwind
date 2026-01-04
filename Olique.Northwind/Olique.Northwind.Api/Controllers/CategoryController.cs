using Microsoft.AspNetCore.Mvc;
using Olique.Northwind.Application.Interfaces;

namespace Olique.Northwind.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _CategoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_CategoryService.GetCategories());
        }
    }
}

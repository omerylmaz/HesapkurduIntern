using BusinessLogic.Base;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryService.GetAllCategories());
        }

        [HttpGet]
        public IActionResult GetCategoryById(int categoryId)
        {
            return Ok(_categoryService.GetCategory(categoryId));
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _categoryService.AddCategory(category);
            return Ok();
        }

        [HttpDelete] // Bunun yerine HttpPost da kullanılabilir
        public IActionResult RemoveCategoryById(int categoryId)
        {
            _categoryService.RemoveCategoryById(categoryId);
            return Ok();
        }

        [HttpPut] //Bunun yerine HttpPost da kullanılabilir
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.Update(category);
            return Ok(category);
        }
    }
}

using BusinessLogic.Base;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;
        private ILogger<CategoriesController> _logger;
        public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            try
            {
                var x = _categoryService.GetAllCategories();
                if (x == null)
                    return NotFound();

                _logger.LogInformation("Get method called successfully");
                //Log.ForContext<CategoriesController>().Information("denemedenemedeneme");
                return Ok(x);

            }
            catch (System.Exception e)
            {
                _logger.LogError($"Categories/GetAllCategories - There is an exception: {e.Message}");

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("GetCategoryById")]
        public IActionResult GetCategoryById(int categoryId)
        {
            var x = _categoryService.GetCategory(categoryId);

            try
            {
                if (x == null)
                    return NotFound();
                    
                return Ok(x);
            }
            catch (System.Exception e)
            {
                _logger.LogError($"Categories/GetCategoryById/{categoryId} - There is an exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("AddCategory")]
        public IActionResult AddCategory(Category category)
        {
            try
            {
                _categoryService.AddCategory(category);
                return StatusCode(201);
            }
            catch (System.Exception e)
            {
                _logger.LogError($"Categories/AddCategory - There is an exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }


        [HttpDelete] // Bunun yerine HttpPost da kullanılabilir
        [Route("RemoveCategoryById")]
        public IActionResult RemoveCategoryById(int categoryId)
        {
            try
            {
            Category c = _categoryService.RemoveCategoryById(categoryId);
            return Ok(c);
            }
            catch (System.Exception e)
            {
                _logger.LogError($"Categories/RemoveCategoryById/{categoryId} - There is an exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut] //Bunun yerine HttpPost da kullanılabilir
        [Route("UpdateCategory")]
        public IActionResult UpdateCategory(Category category)
        {
            try
            {
            _categoryService.Update(category);
            return Ok(category);
            }
            catch (System.Exception e)
            {
                _logger.LogError($"Categories/UpdateCategory - There is an exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }
    }
}

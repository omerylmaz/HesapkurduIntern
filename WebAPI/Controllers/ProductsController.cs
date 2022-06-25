using BusinessLogic.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("application/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
                _productService = productService;   
        }

        [HttpGet("getall")]
        public IActionResult GetAllProducts()
        {
            return Ok(_productService.GetAllProducts());
        }
    }
}

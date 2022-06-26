using BusinessLogic.Base;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet]
        public IActionResult GetProductById(int productId)
        {
            return Ok(_productService.GetProduct(productId));
        }

        [HttpGet]
        public IActionResult GetProductsByCategoryId(int categoryId)
        {
            return Ok(_productService.GetProductsByCategoryId(categoryId));
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productService.AddProduct(product);
            return new ObjectResult(product) { StatusCode=StatusCodes.Status201Created}; // Bunun yerine direk Ok() deyipte geçilebilir
        }

        [HttpDelete] // Bunun yerine HttpPost da kullanılabilir
        public IActionResult RemoveProductById(int productId)
        {
            _productService.RemoveProductById(productId);
            return Ok();
        }

        [HttpPut] //Bunun yerine HttpPost da kullanılabilir
        public IActionResult UpdateProduct(Product product)
        {
            try
            {
                _productService.Update(product);
                return Ok(product);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}

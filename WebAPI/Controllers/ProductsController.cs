using BusinessLogic.Base;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace WebAPI.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        private ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;

        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var x = _productService.GetAllProducts();
                if (x == null)
                    return NotFound();

                return Ok(_productService.GetAllProducts());

            }
            catch (System.Exception e)
            {
                _logger.LogError($"Products/GetAllProducts - There is an exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("GetProductById")]
        public IActionResult GetProductById(int productId)
        {
            var x = _productService.GetProduct(productId);

            try
            {
                if (x == null)
                    return NotFound();

                return Ok(x);
            }
            catch (System.Exception e)
            {
                _logger.LogError($"Products/GetProductById/{productId} - There is an exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                _productService.AddProduct(product);
                return StatusCode(201, product);
            }
            catch (System.Exception e)
            {
                _logger.LogError($"Products/AddProduct - There is an exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }


        [HttpDelete] // Bunun yerine HttpPost da kullanılabilir
        [Route("RemoveProductById")]
        public IActionResult RemoveProductById(int productId)
        {
            try
            {
                Product p = _productService.RemoveProductById(productId);
                return Ok(p);
            }
            catch (System.Exception e)
            {
                _logger.LogError($"Products/RemoveProductById/{productId} - There is an exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut] //Bunun yerine HttpPost da kullanılabilir
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct(Product product)
        {
            try
            {
                _productService.Update(product);
                return Ok(product);
            }
            catch (System.Exception e)
            {
                _logger.LogError($"Products/UpdateProduct - There is an exception: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

    }
}

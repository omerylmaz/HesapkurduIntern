using BusinessLogic.Base;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private ISellerService _sellerService;
        public SellersController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpGet]
        public IActionResult GetAllSellers()
        {
            return Ok(_sellerService.GetAllSellers());
        }

        [HttpGet]
        public IActionResult GetSellerById(int sellerId)
        {
            return Ok(_sellerService.GetSellerById(sellerId));
        }

        [HttpGet]
        public IActionResult GetSellersByRating(double rating)
        {
            return Ok(_sellerService.GetSellersByRating(rating));
        }

        [HttpPost]
        public IActionResult AddSeller(Seller seller)
        {
            _sellerService.AddSeller(seller);
            return Ok();
        }

        [HttpDelete] // Bunun yerine HttpPost da kullanılabilir
        public IActionResult RemoveSellerById(int sellerId)
        {
            _sellerService.RemoveSellerById(sellerId);
            return Ok();
        }

        [HttpPut] //Bunun yerine HttpPost da kullanılabilir
        public IActionResult UpdateSeller(Seller seller)
        {
            _sellerService.Update(seller);
            return Ok(seller);
        }
    }
}

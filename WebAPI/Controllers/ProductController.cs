using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("application")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public async Task<IActionResult> Index()
        {
            return Ok();
        }
    }
}

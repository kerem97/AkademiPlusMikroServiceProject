using AkademiPlusMikroServiceProje.Shared.ControllerBases;
using AkademiPlusMikroServiceProje.Shared.Services;
using AkademiPlusMikroServiceProject.Basket.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AkademiPlusMikroServiceProject.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : CustomBaseController
    {
        private readonly BasketService _basketService;
        private readonly ISharedIdentityService _identityService;

        public BasketController(BasketService basketService, ISharedIdentityService identityService)
        {
            _basketService = basketService;
            _identityService = identityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using project.Customer.Dto;
using project.Customer.Interface;
using project.Customer.Servise;
using project.Models.Customer;

namespace project.Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class GetGiftController : ControllerBase
    {
        private readonly IGiftService _giftService;


        public GetGiftController(IGiftService giftService)
        {
            _giftService = giftService;
        }
        [HttpGet("Gifts")]
        public async Task<ActionResult<IEnumerable<GiftsDto.GetGift>>> GetGift()
        {
            IEnumerable<GiftsDto.GetGift> getGift = await _giftService.GetGift();
            return Ok(getGift);
        }
        [HttpPost("addToCart:id")]
        public async Task<ActionResult<ShoppingCartModel>> AddToCart([FromQuery] int Id, [FromBody] string UserName)
        {
            try
            {
                var result = await _giftService.AddGiftToCart(Id , UserName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "אירעה שגיאה בעת הוספת הפריט לסל.");
            }

        }
    }
}

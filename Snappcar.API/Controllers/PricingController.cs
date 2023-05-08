using Microsoft.AspNetCore.Mvc;
using Snappcar.API.RequestModels;
using Snappcar.Services;
using Snappcar.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Snappcar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IPricingService _pricingService;
        public PricingController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        [HttpPost]
        public IActionResult Get([FromBody] PricingRequest request)
        {
            try
            {
                return Ok(_pricingService.GetPricings(new Car { Id = request.CarId }, request.StartDate, request.EndDate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

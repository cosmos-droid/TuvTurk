namespace TuvTurk.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TuvTurk.Business.Abstract;
    using TuvTurk.Entities.Concrete;

    [ApiController]
    [Route("api/[controller]")]
    public class PricesController : ControllerBase
    {
        private readonly IPriceService _priceService;

        public PricesController(IPriceService priceService)
        {
            _priceService = priceService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(long priceId)
        {
            var result = _priceService.GetPriceById(priceId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _priceService.GetAllPrices();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("gettotalprice")]
        public IActionResult GetTotalPrice(long vehicleTypeId, long inspectionTypeId)
        {
            var result = _priceService.GetTotalPrice(vehicleTypeId, inspectionTypeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Price price)
        {
            var result = _priceService.AddPrice(price);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Price price)
        {
            var result = _priceService.UpdatePrice(price);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Price price)
        {
            var result = _priceService.DeletePrice(price);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



    }
}
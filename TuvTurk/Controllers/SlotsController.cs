namespace TuvTurk.Controllers
{
    using Business.Abstract;
    using Entities.Concrete;
    using Entities.Utilities;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class SlotsController : ControllerBase
    {
        private readonly ISlotService _slotsService;

        public SlotsController(ISlotService slotsService)
        {
            _slotsService = slotsService;
        }

        [HttpGet(template: "getbyid")]
        public IActionResult GetById(long id)
        {
            var result = _slotsService.GetSlotById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "add")]
        public IActionResult Add(Slots slot)
        {
            var result = _slotsService.AddSlot(slot);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "delete")]
        public IActionResult Delete(Slots slot)
        {
            var result = _slotsService.DeleteSlot(slot);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "update")]
        public IActionResult Update(Slots slot)
        {
            var result = _slotsService.UpdateSlot(slot);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getall")]
        public IActionResult GetAll()
        {
            var result = _slotsService.GetAllSlots();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getallempty")]
        public IActionResult GetAllEmptySlots(long stationId)
        {
            var result = _slotsService.GetEmptySlots(stationId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getallemptybydate")]
        public IActionResult GetAllEmptySlotsByDate(DateOnly availableDate, long stationId)
        {
            var result = _slotsService.GetEmptySlotsByDate(availableDate, stationId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }





    }
}
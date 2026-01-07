namespace TuvTurk.Controllers
{
    using Business.Abstract;
    using Entities.Concrete;
    using Entities.Utilities;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class StationsController : ControllerBase
    {
        private readonly IStationService _stationService;

        public StationsController(IStationService stationService)
        {
            _stationService = stationService;
        }

        [HttpGet(template: "getbyid")]
        public IActionResult GetById(long id)
        {
            var result = _stationService.GetStationById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "add")]
        public IActionResult Add(Station station)
        {
            var result = _stationService.AddStation(station);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "delete")]
        public IActionResult Delete(Station station)
        {
            var result = _stationService.DeleteStation(station);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpPost(template: "update")]
        public IActionResult Update(Station station)
        {
            var result = _stationService.UpdateStation(station);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpGet(template: "getall")]
        public IActionResult GetAll()
        {
            var result = _stationService.GetAllStations();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpGet(template: "getallbycityid")]
        public IActionResult GetAllByCityId(long cityId)
        {
            var result = _stationService.GetStationsByCityId(cityId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }





    }
}
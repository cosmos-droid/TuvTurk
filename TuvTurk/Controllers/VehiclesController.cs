namespace TuvTurk.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TuvTurk.Business.Abstract;
    using TuvTurk.Entities.Concrete;

    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {

        private readonly IvehicleService _vehicleService;
        public VehiclesController(IvehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet(template:("getbyid"))]
        public IActionResult GetById(long vehicleId)
        {
            var result = _vehicleService.GetVehicleById(vehicleId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);        
        }


        [HttpPost(template: "delete")]
        public IActionResult Delete(Vehicle vehicle)
        {
            var result = _vehicleService.DeleteVehicle(vehicle);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpPost(template: "update")]
        public IActionResult Update(Vehicle vehicle)
        {
            var result = _vehicleService.UpdateVehicle(vehicle);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpGet(template: "getall")]
        public IActionResult GetAll()
        {
            var result = _vehicleService.GetAllVehicles();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "doesplateexist")]
        public IActionResult DoesPlateExist(string plateNo)
        {
            var result = _vehicleService.DoesPlateExist(plateNo);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpPost(template: "plateruhsatcheck")]
        public IActionResult PlateRuhsatCheck(string plateNo, string vehicleSerialNumberNo)
        {
            var result = _vehicleService.PlateRuhsatCheck(plateNo, vehicleSerialNumberNo);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
            
        }

    
        [HttpPost(template: "checkvehicletypebyplateno")]
        public IActionResult ChekVehicleTypeByPlateNo(string plateNo)
        {
            var result = _vehicleService.CheckVehicleTypeByPlateNo(plateNo);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
            
        }

            



        
    }

}
namespace TuvTurk.Controllers
{
    using Business.Abstract;
    using Entities.Concrete;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using TuvTurk.Entities.Utilities;

    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(long cityId)
        {
            var result = _cityService.GetCityById(cityId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "add")]
        public IActionResult Add(City city)
        {
            var result = _cityService.AddCity(city);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "delete")]
        public IActionResult Delete(City city)
        {
            var result = _cityService.DeleteCity(city);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost(template: "update")]
        public IActionResult Update(City city)
        {
            var result = _cityService.UpdateCity(city);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getall")]
        public IActionResult GetAll()
        {
            var result = _cityService.GetAllCities();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getallcitieswithstation")]
        public IActionResult GetAllCitiesWithStation()
        {
            var result = _cityService.GetAllCitiesWithStaion();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


    }
}
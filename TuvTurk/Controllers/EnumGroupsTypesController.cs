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
    public class EnumGroupsTypesController : ControllerBase
    {
        private readonly IEnumGroupTypeService _enumGroupTypeService;

        public EnumGroupsTypesController(IEnumGroupTypeService enumGroupTypeService)
        {
            _enumGroupTypeService = enumGroupTypeService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(long enumGroupTypeId)
        {
            var result = _enumGroupTypeService.GetEnumGroupTypeById(enumGroupTypeId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "add")]
        public IActionResult Add(EnumGroupType enumGroupType)
        {
            var result = _enumGroupTypeService.AddEnumGroupType(enumGroupType);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "delete")]
        public IActionResult Delete(EnumGroupType enumGroupType)
        {
            var result = _enumGroupTypeService.DeleteEnumGroupType(enumGroupType);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost(template: "update")]
        public IActionResult Update(EnumGroupType enumGroupType)
        {
            var result = _enumGroupTypeService.UpdateEnumGroupType(enumGroupType);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpGet(template: "getall")]
        public IActionResult GetAll()
        {
            var result = _enumGroupTypeService.GetAllEnumGroupTypes();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getallbyenumgroupid")]
        public IActionResult GetAllByEnumGroupId(long enumGroupId)
        {
            var result = _enumGroupTypeService.GetEnumGroupTypeByEnumGroupId(enumGroupId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


    }
}
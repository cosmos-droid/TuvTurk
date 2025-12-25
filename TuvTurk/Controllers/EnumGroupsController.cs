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
    public class EnumGroupsController : ControllerBase
    {
        private readonly IEnumGroupService _enumGroupService;

        public EnumGroupsController(IEnumGroupService enumGroupService)
        {
            _enumGroupService = enumGroupService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(long enumGroupId)
        {
            var result = _enumGroupService.GetEnumGroupById(enumGroupId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "add")]
        public IActionResult Add(EnumGroup enumGroup)
        {
            var result = _enumGroupService.AddEnumGroup(enumGroup);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "delete")]
        public IActionResult Delete(EnumGroup enumGroup)
        {
            var result = _enumGroupService.DeleteEnumGroup(enumGroup);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost(template: "update")]
        public IActionResult Update(EnumGroup enumGroup)
        {
            var result = _enumGroupService.UpdateEnumGroup(enumGroup);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpGet(template: "getall")]
        public IActionResult GetAll()
        {
            var result = _enumGroupService.GetAllEnumGroups();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

    }
}
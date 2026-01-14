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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(long customerId)
        {
            var result = _customerService.GetCustomerById(customerId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getcustomerbyreservationno")]
        public IActionResult GetCustomerByReservationNo(string reservationNo)
        {
            var result = _customerService.GetCustomerByReservationNo(reservationNo);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }        

        [HttpPost(template: "add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.AddCustomer(customer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.DeleteCustomer(customer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.UpdateCustomer(customer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAllCustomers();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

    }
}
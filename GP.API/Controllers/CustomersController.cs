using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GP.API.Services;
using GP.API.Models;
using AutoMapper;

namespace GP.API.Controllers
{
    //[ApiVersion("1.0"), Route("api/v{version:apiVersion}/[controller]")]
    //[Route( "api/v{version:apiVersion}/[controller]" )]
    //[Route("api/v{version:apiVersion}/customers")]
    [Route("api/v1/customers")]
    public class CustomersController : Controller
    {
        private ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet(), MapToApiVersion("1.0")]
        public IActionResult GetCustomers()
        {
            var customerEntities = _customerRepository.GetCustomers();

            var customerResults = Mapper.Map<List<CustomerDto>>(customerEntities);

            return Ok(customerResults);
        }

        [HttpGet("{custnmbr}"), MapToApiVersion("1.0")]
        public IActionResult GetCustomer(string Custnmbr)
        {
            var customer = _customerRepository.GetCustomer(Custnmbr);

            if (customer == null)
            {
                return NotFound();
            }

            var itemResult = Mapper.Map<CustomerDto>(customer);

            return Ok(itemResult);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GP.API.Entities;
using GP.API.Models;
using GP.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Dynamics.GP.eConnect.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GP.API;
using GP.API.Controllers;

namespace API.Controllers
{
	[ApiVersion("1.0")]
	[Route("api/v1/[controller]")]
	public class VendorController : Controller
    {
		private IVendorRepository _vendorRepository;
		private IImportVendor _importVendor;

		private ILogger<VendorController> _logger;
		private readonly IOptions<APIConfig> _config;
		private readonly IHttpContextAccessor _accessor;
		private readonly HttpContext _context;
		private string queryString;

		//private readonly GPContext _dbcontext;

		public VendorController(IVendorRepository vendorRepository, IImportVendor importVendor, ILogger<VendorController> logger, IOptions<APIConfig> config, IHttpContextAccessor accessor)  //GPSysContext dbcontext, 
		{
			_vendorRepository = vendorRepository;
			_importVendor = importVendor;

			_logger = logger;
			_config = config;
			_accessor = accessor;
			_context = accessor.HttpContext;
			queryString = _context.Request.QueryString.ToString();
		}

		[HttpGet("{vendorid}")]
		public IActionResult GetVendor(string vendorID, [FromQuery]string Key, [FromQuery]string Timestamp, [FromQuery]string Signature)
		{
			_logger.LogInformation(LoggingEvents.GET_VENDOR, $"GetVendor request parameters: {Key}, {Timestamp}, {Signature}");

			//if (string.IsNullOrEmpty(Key) || string.IsNullOrEmpty(Timestamp) || string.IsNullOrEmpty(Signature))
			//{
			//	return Unauthorized();
			//}

			var item = _vendorRepository.GetVendor(vendorID);

			if (item == null)
			{
				return NotFound();
			}

			var vendorResult = Mapper.Map<VendorSQLDto>(item);
			
			return Ok(vendorResult);

		}


		[HttpGet("addresses/{vendorid}")]
		public IActionResult GetVendorWithAddresses(string vendorID, [FromQuery]string Key, [FromQuery]string Timestamp, [FromQuery]string Signature)
		{
			_logger.LogInformation(LoggingEvents.GET_VENDOR, $"GetVendorWithAddresses request parameters: {Key}, {Timestamp}, {Signature}");

			//if (string.IsNullOrEmpty(Key) || string.IsNullOrEmpty(Timestamp) || string.IsNullOrEmpty(Signature))
			//{
			//	return Unauthorized();
			//}

			var item = _vendorRepository.GetVendorWithAddresses(vendorID);

			if (item == null)
			{
				return NotFound();
			}

			var vendorResult = Mapper.Map<VendorSQLDto>(item);

			return Ok(vendorResult);

		}


		[HttpPut]
		public IActionResult ImportVendor([FromBody] VendorECDto vendor, [FromQuery]string Key, [FromQuery]string Timestamp, [FromQuery]string Signature)
		{
			var sw = new Stopwatch();
			sw.Start();
			decimal elapsedTime = 0;

			_logger.LogInformation(LoggingEvents.INSERT_VENDOR, $"ImportVendor post parameters: {Key}, {Timestamp}, {Signature}");
			
			//if (string.IsNullOrEmpty(Key) || string.IsNullOrEmpty(Timestamp) || string.IsNullOrEmpty(Signature))
			//{
			//	return Unauthorized();
			//}

			if (vendor == null)
			{
				_logger.LogInformation(LoggingEvents.INSERT_VENDOR_EXCEPTION, $"ImportVendor: Bad Request: Vendor object was not provided in body (null)");
				return BadRequest();
			}

			if (ModelState.IsValid == false)
			{
				_logger.LogInformation(LoggingEvents.INSERT_VENDOR_EXCEPTION, $"ImportVendor: Invalid Request: Invalid vendor values were submitted");
				return BadRequest(ModelState);
			}


			var response = new VendorResponseDto();

			var eConnVendor = Mapper.Map<taUpdateCreateVendorRcd>(vendor);

            var vendorResponse = _importVendor.ImportGPVendor(eConnVendor);

            sw.Stop();

			elapsedTime = Convert.ToDecimal(sw.ElapsedMilliseconds);
			vendorResponse.Elapsed = elapsedTime.ToString();

			_logger.LogInformation(LoggingEvents.INSERT_VENDOR_COMPLETE, "ImportVendor complete: " + vendorResponse.Elapsed);

			//return Created(new Uri(_context.Request.Path, UriKind.Relative), vendorResponse);
			return Ok(vendorResponse);

		}
		
	}
}
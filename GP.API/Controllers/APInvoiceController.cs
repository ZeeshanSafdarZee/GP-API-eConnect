using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using GP.API.Models;
using GP.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GP.API.Controllers
{
	[ApiVersion("1.0")]
	[Route("api/v1/[controller]")]
	public class APInvoiceController : Controller
    {
		private IAPInvoiceRepository _invoiceRepository;
		private IAPImportInvoice _importInvoice;

		private ILogger<APInvoiceController> _logger;
		private readonly IOptions<APIConfig> _config;
		private readonly IHttpContextAccessor _accessor;
		private readonly HttpContext _context;
		private string queryString;

		public APInvoiceController(IAPInvoiceRepository invoiceRepository, IAPImportInvoice importInvoice, ILogger<APInvoiceController> logger, IOptions<APIConfig> config, IHttpContextAccessor accessor)  //GPSysContext dbcontext, 
		{
			_invoiceRepository = invoiceRepository;
			_importInvoice = importInvoice;

			_logger = logger;
			_config = config;
			_accessor = accessor;
			_context = accessor.HttpContext;
			queryString = _context.Request.QueryString.ToString();
		}


		[HttpGet("open/{UpdatedSince}")]
		public IActionResult GetOpenInvoices(DateTime UpdatedSince, [FromQuery]string Key, [FromQuery]string Timestamp, [FromQuery]string Signature)
		{
			_logger.LogInformation(LoggingEvents.GET_VENDOR, $"GetOpenInvoices request parameters: {UpdatedSince}, {Key}, {Timestamp}, {Signature}");

			//if (string.IsNullOrEmpty(Key) || string.IsNullOrEmpty(Timestamp) || string.IsNullOrEmpty(Signature))
			//{
			//	return Unauthorized();
			//}

			if (UpdatedSince == null || UpdatedSince < Convert.ToDateTime("01/01/2000"))
			{
				return StatusCode(400);
			}

			var openInvoices = _invoiceRepository.GetOpenInvoices(UpdatedSince);

			if (openInvoices == null)
			{
				return NotFound();
			}

			var result = Mapper.Map<IEnumerable<PMOpenDto>>(openInvoices);

			return Ok(result);

		}


		[HttpGet("vendor/{vendorID}")]
		public IActionResult GetOpenVendorInvoices(string VendorID, [FromQuery]DateTime UpdatedSince, [FromQuery]string Key, [FromQuery]string Timestamp, [FromQuery]string Signature)
		{
			_logger.LogInformation(LoggingEvents.GET_VENDOR, $"GetOpenVendorInvoices request parameters: {VendorID}, {UpdatedSince}, {Key}, {Timestamp}, {Signature}");

			//if (string.IsNullOrEmpty(Key) || string.IsNullOrEmpty(Timestamp) || string.IsNullOrEmpty(Signature))
			//{
			//	return Unauthorized();
			//}

			if (VendorID == null || UpdatedSince == null)
			{
				return StatusCode(400);
			}

			if (UpdatedSince < Convert.ToDateTime("01/01/2000"))
			{
				return StatusCode(400);
			}

			var openInvoices = _invoiceRepository.GetOpenVendorInvoices(VendorID, UpdatedSince);

			if (openInvoices == null)
			{
				return NotFound();
			}

			var result = Mapper.Map<IEnumerable<PMOpenDto>>(openInvoices);

			return Ok(result);

		}


		[HttpPost()]
		public IActionResult ImportInvoice([FromBody]APInvoiceECDto invoiceEC, [FromQuery]string Key, [FromQuery]string Timestamp, [FromQuery]string Signature)  //[FromBody] InvoiceECDto invoiceEC
		{
			var sw = new Stopwatch();
			sw.Start();
			decimal elapsedTime = 0;

			_logger.LogInformation(LoggingEvents.GET_VENDOR, $"ImportInvoice request parameters: {Key}, {Timestamp}, {Signature}");

			//if (string.IsNullOrEmpty(Key) || string.IsNullOrEmpty(Timestamp) || string.IsNullOrEmpty(Signature))
			//{
			//	return Unauthorized();
			//}

			if (invoiceEC == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var pmTransaction = _importInvoice.PrepGPInvoice(invoiceEC);

			var response = _importInvoice.ImportGPInvoice(pmTransaction);

			sw.Stop();
			elapsedTime = Convert.ToDecimal(sw.ElapsedMilliseconds);
			response.Elapsed = elapsedTime.ToString();

			return Ok(response);

			//return Ok(null);

		}

	}
}
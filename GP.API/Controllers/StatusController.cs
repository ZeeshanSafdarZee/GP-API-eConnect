using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GP.API.Entities;
using GP.API.Models;

namespace GP.API.Controllers
{
	[ApiVersion("1.0")]
	[Route("api/v1/[controller]")]
	public class StatusController : Controller
    {
		private ILogger<StatusController> _logger;
		private readonly APIConfig _config;
		private readonly IHttpContextAccessor _accessor;
		private readonly HttpContext _context;
		private readonly GPSysContext _dbcontext;

		public StatusController(ILogger<StatusController> logger, IOptions<APIConfig> config, GPSysContext dbcontext, IHttpContextAccessor accessor) 
		{
			_logger = logger;
			_config = config.Value;
			_dbcontext = dbcontext;
			_accessor = accessor;
			_context = accessor.HttpContext;
		}

		[HttpGet]
		public IActionResult Status([FromQuery]string Key, [FromQuery]string Timestamp, [FromQuery]string Signature)
		{
			var sw = new Stopwatch();
			sw.Start();
			decimal elapsedTime = 0;
			
			StatusDto status = new StatusDto();

			_logger.LogInformation(LoggingEvents.GET_STATUS, $"Status request parameters: {Key}, {Timestamp}, {Signature}");

			//if (string.IsNullOrEmpty(Key) || string.IsNullOrEmpty(Timestamp) || string.IsNullOrEmpty(Signature))
			//{
			//	return Unauthorized();
			//}

			try
			{
				var result = _dbcontext.Activity.Count();
				status.SQLAvailable = true;
			}
			catch (Exception ex)
			{
				_logger.LogError(LoggingEvents.GET_STATUS_EXCEPTION, $"Get Status error: " + ex.Message);
				status.SQLAvailable = false;
				status.Message = ex.Message;
			}
			
			try
			{
				int errorNumber = 0;
				string errorMessage = string.Empty;
                bool success = eConn.CheckeConnectVendor(_config.GPCompanyDB, _config.eConnectTestVendorID, ref errorNumber, ref errorMessage);
                //bool success = eConn.SaleTransactionEntry(_config.GPCompanyDB, _config.eConnectTestVendorID, ref errorNumber, ref errorMessage);
                //bool success = eConn.DeleteSaleTransactionEntry(_config.GPCompanyDB, _config.eConnectTestVendorID, ref errorNumber, ref errorMessage);
                //bool success = eConn.UpdateSaleTransactionEntry(_config.GPCompanyDB, _config.eConnectTestVendorID, ref errorNumber, ref errorMessage);
                status.eConnectAvailable = success;
				if (!String.IsNullOrEmpty(status.Message))
				{
					status.Message += Environment.NewLine;
				}
				status.Message += errorMessage;
			}
			catch (Exception ex)
			{
				_logger.LogError(LoggingEvents.GET_STATUS_EXCEPTION, $"Get Status eConnect exception: " + ex.Message);
				status.eConnectAvailable = false;
			}
            
			sw.Stop();
			elapsedTime = Convert.ToDecimal(sw.ElapsedMilliseconds);
			status.Elapsed = elapsedTime.ToString();

			
			_logger.LogInformation(LoggingEvents.GET_STATUS, "Status call completed in " + status.Elapsed + "ms");

			return Ok(status);
			
		}
	}
}
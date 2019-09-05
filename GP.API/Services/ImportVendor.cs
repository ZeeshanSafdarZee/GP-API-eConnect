using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using GP.API.Controllers;
using GP.API.Models;
using Microsoft.Dynamics.GP.eConnect.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GP.API.Services
{
    public class ImportVendor : IImportVendor
    {
		private ILogger<ImportVendor> _logger;
		private readonly IOptions<APIConfig> _config;

		public ImportVendor(ILogger<ImportVendor> logger, IOptions<APIConfig> config)
		{
			_logger = logger;
			_config = config;
		}
		
		public VendorResponseDto ImportGPVendor(taUpdateCreateVendorRcd vendor)
		{
			var response = new VendorResponseDto();
			//var sw = new Stopwatch();
			//sw.Start();
			//decimal elapsedTime = 0;

			try
			{
				string clearValue = "~~~";
				string cdataValue = "<![CDATA[ ]]>";
				
				//Replace null or empty string properties with the clear data value
				vendor = Fn.ReplaceNullOrEmptyStringProperties(vendor, clearValue);
				
				var PMVendor = new PMVendorMasterType();
				PMVendor.taUpdateCreateVendorRcd = vendor;

				PMVendorMasterType[] PMVendorType = { PMVendor };

				eConnectType eConnect = new eConnectType();
				eConnect.PMVendorMasterType = PMVendorType;

				MemoryStream memStream = new MemoryStream();
				XmlSerializer serializer = new XmlSerializer(eConnect.GetType());
				serializer.Serialize(memStream, eConnect);
				memStream.Position = 0;

				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(memStream);
				memStream.Close();

				string finalXML = xmlDocument.OuterXml;
				//After serialization, replace clearValue with the eConnect CDATA value to clear field values that should now be empty
				finalXML = finalXML.Replace(clearValue, cdataValue);

				string responseMessage = string.Empty;
				string errorMessage = string.Empty;

				string vendorID = vendor.VENDORID;
				string vendorName = vendor.VENDNAME;

				bool success = eConn.CreateEntity(ref responseMessage, finalXML, _config.Value.GPCompanyDB);

				response.Success = success;
				response.ErrorCode = 0;

				if (success)
				{
					response.Message = "Vendor " + vendorID + " imported successfully";
				}
				else
				{ 
					errorMessage = "Failed to import vendor " + vendorID + " - " + vendorName + ": " + responseMessage;
					response.Message = errorMessage;
					response.ErrorCode = LoggingEvents.INSERT_VENDOR_FAILED;
				}

				//sw.Stop();
				//elapsedTime = Convert.ToDecimal(sw.ElapsedMilliseconds);
				//response.Elapsed = elapsedTime.ToString();

				//_logger.LogInformation(LoggingEvents.INSERT_VENDOR_COMPLETE, $"ImportVendor {vendorID} complete: " + response.Elapsed);

				return response;

			}
			catch (Exception ex)
			{
				//sw.Stop();
				//elapsedTime = Convert.ToDecimal(sw.ElapsedMilliseconds);
				//response.Elapsed = elapsedTime.ToString();

				response.Success = false;
				response.ErrorCode = LoggingEvents.INSERT_VENDOR_EXCEPTION;
				response.Message = "An unexpected error occured in ImportGPVendor: " + ex.Message;
				return response;
			}
			
		}

	}
}

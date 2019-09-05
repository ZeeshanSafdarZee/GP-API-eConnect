using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using Microsoft.Dynamics.GP.eConnect.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GP.API.Models;
using GP.API.Services;
using GP.API.Controllers;

namespace GP.API.Services
{
	public class APImportInvoice : IAPImportInvoice
	{
		private ILogger<APImportInvoice> _logger;
		private readonly IOptions<APIConfig> _config;

		public APImportInvoice(ILogger<APImportInvoice> logger, IOptions<APIConfig> config)
		{
			_logger = logger;
			_config = config;
		}

		public taPMTransactionInsert PrepGPInvoice(APInvoiceECDto invoiceEC)
		{
			try
			{
				string error = string.Empty;
				DateTime dateValue;

				if (invoiceEC.BACHNUMB.Trim() == string.Empty)
				{
					invoiceEC.BACHNUMB = _config.Value.APInvoiceBatch;
				}

				if (DateTime.TryParse(invoiceEC.DOCDATE.ToString(), out dateValue))
				{
					invoiceEC.DOCDATE = dateValue.Date;
				}
				else
				{
					invoiceEC.DOCDATE = DateTime.Today;
				}

				if (DateTime.TryParse(invoiceEC.PSTGDATE.ToString(), out dateValue))
				{
					invoiceEC.PSTGDATE = dateValue.Date;
				}
				else
				{
					invoiceEC.PSTGDATE = invoiceEC.DOCDATE;
				}

				var pmTransaction = Mapper.Map<taPMTransactionInsert>(invoiceEC);

				pmTransaction.VCHNUMWK = DataAccess.GetNextVoucherNumber(ref error);
				pmTransaction.DOCTYPE = 1; //1 = Invoice

				if (pmTransaction.PRCHAMNT == 0)
				{
					pmTransaction.PRCHAMNT = pmTransaction.DOCAMNT;
				}

				pmTransaction.DOCAMNT = pmTransaction.PRCHAMNT + pmTransaction.MSCCHAMT + pmTransaction.TAXAMNT + pmTransaction.FRTAMNT;

				pmTransaction.CHRGAMNT = pmTransaction.DOCAMNT;
				
				pmTransaction.MDFUSRID = "eConnect";
				pmTransaction.BatchCHEKBKID = _config.Value.APInvoiceCheckbookID;

				return pmTransaction;
			}
			catch (Exception)
			{
				throw;
			}
            
		}

		public APInvoiceResponseDto ImportGPInvoice(taPMTransactionInsert pmTransaction)
		{
			var response = new APInvoiceResponseDto();

			try
			{
				var PMTransaction = new PMTransactionType();
				PMTransaction.taPMTransactionInsert = pmTransaction;

				PMTransactionType[] PMTransType = { PMTransaction };

				eConnectType eConnect = new eConnectType();
				eConnect.PMTransactionType = PMTransType;

				MemoryStream memStream = new MemoryStream();
				XmlSerializer serializer = new XmlSerializer(eConnect.GetType());
				serializer.Serialize(memStream, eConnect);
				memStream.Position = 0;

				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(memStream);
				memStream.Close();

				string finalXML = xmlDocument.OuterXml;

				string responseMessage = string.Empty;
				string errorMessage = string.Empty;

				string voucher = pmTransaction.VCHNUMWK;
				string docNumber = pmTransaction.DOCNUMBR;
				string vendorID = pmTransaction.VENDORID;

				bool success = eConn.CreateTransactionEntity(ref responseMessage, finalXML, _config.Value.GPCompanyDB);

				response.Success = success;
				response.ErrorCode = 0;

				if (success)
				{
					response.Message = "Vendor " + vendorID + " invoice " + docNumber + " imported as voucher " + voucher;
				}
				else
				{
					errorMessage = "Failed to import vendor " + vendorID + " invoice " + docNumber + ": " + responseMessage;
					response.Message = errorMessage;
					response.ErrorCode = LoggingEvents.INSERT_INVOICE_FAILED;
				}

				return response;

			}
			catch (Exception ex)
			{
				response.Success = false;
				response.ErrorCode = LoggingEvents.INSERT_INVOICE_EXCEPTION;
				response.Message = "An unexpected error occured in ImportGPInvoice: " + ex.Message;
				return response;
			}
            
		}

		
	}
}

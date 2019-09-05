using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.API.Entities;
using GP.API.Services;

namespace GP.API.Services
{
	public class APInvoiceRepository : IAPInvoiceRepository
	{
		private GPContext _context;

		public APInvoiceRepository(GPContext context)
		{
			_context = context;
		}

		public bool OpenInvoiceExists(string VendorID, string InvoiceNumber)
		{
			if (_context.PMOpenEntity.Any(c => c.Doctype == 1 && c.Vendorid == VendorID && c.Docnumbr == InvoiceNumber))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
				
		public IEnumerable<PMOpenEntity> GetOpenInvoices(DateTime UpdatedSince)
		{
			return _context.PMOpenEntity.Where(c => c.Doctype == 1 && c.DexRowTs >= UpdatedSince).ToList();
		}
		
		public IEnumerable<PMOpenEntity> GetOpenVendorInvoices(string VendorID, DateTime UpdatedSince)
		{
			return _context.PMOpenEntity.Where(c => c.Doctype == 1 && c.Vendorid == VendorID && c.DexRowTs >= UpdatedSince).ToList();
		}

		public PMOpenEntity GetOpenInvoice(string VendorID, string InvoiceNumber)
		{
			return _context.PMOpenEntity.Where(c => c.Doctype == 1 && c.Vendorid == VendorID && c.Docnumbr == InvoiceNumber).FirstOrDefault();
		}
		
		        
	}
}

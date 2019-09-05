using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.API.Entities;

namespace GP.API.Services
{
	public interface IAPInvoiceRepository
    {
		bool OpenInvoiceExists(string VendorID, string InvoiceNumber);
		IEnumerable<PMOpenEntity> GetOpenInvoices(DateTime UpdatedSince);
		IEnumerable<PMOpenEntity> GetOpenVendorInvoices(string VendorID, DateTime UpdatedSince);
		PMOpenEntity GetOpenInvoice(string VendorID, string InvoiceNumber);
        
	}
}

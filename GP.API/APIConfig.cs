using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API
{
    public class APIConfig
    {
		public string LogDir { get; set; }
		public string LogFile { get; set; }
		public string ErrorFile { get; set; }

		public string GPServer { get; set; }
		public string GPCompanyDB { get; set; }
		public string GPSystemDB { get; set; }

		public string GPLoginType { get; set; }
		public string GPUser { get; set; }
		public string GPPassword { get; set; }

		public string CurrencyID { get; set; }

		public string SMTPServer { get; set; }
		public short SMTPPort { get; set; }
		public bool SMTPAuthRequired { get; set; }
		public string SMTPUser { get; set; }
		public string SMTPPassword { get; set; }
		public bool SMTPTLS { get; set; }

		public string EmailFrom { get; set; }
		public string EmailToUsers { get; set; }
		public string EmailToAdmins { get; set; }
		public string EmailSubject { get; set; }

		public string eConnectTestVendorID { get; set; }

		public string HMACSecret { get; set; }
		public string KeyFile { get; set; }

		public string APInvoiceBatch { get; set; }
		public string APInvoiceCheckbookID { get; set; }

		public string JEBatch { get; set; }

        public string SOPTypeID { get; set; }
        public short QtyShortageOption { get; set; }

    }
}

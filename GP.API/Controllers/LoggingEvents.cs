using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Controllers
{
    public class LoggingEvents
    {
		public const int HMAC = 100;

		public const int GET_STATUS = 1000;
		public const int GET_STATUS_SUCCESS = 1100;
		public const int GET_STATUS_FAILED = 1200;
		public const int GET_STATUS_EXCEPTION = 1999;

		public const int GET_VENDOR = 2000;
		public const int GET_VENDOR_SUCCESS = 2100;
		public const int GET_VENDOR_NOTFOUND = 2200;
		public const int GET_VENDOR_EXCEPTION = 2999;

		public const int INSERT_VENDOR = 3000;
		public const int INSERT_VENDOR_SUCCESS = 3100;
		public const int INSERT_VENDOR_COMPLETE = 3110;
		public const int INSERT_VENDOR_FAILED = 3200;
		public const int INSERT_VENDOR_EXCEPTION = 3999;

		public const int INSERT_EFT = 4000;
		public const int INSERT_EFT_SUCCESS = 4100;
		public const int INSERT_EFT_COMPLETE = 4110;
		public const int INSERT_EFT_FAILED = 4200;
		public const int INSERT_EFT_EXCEPTION = 4999;

		public const int INSERT_INVOICE = 4000;
		public const int INSERT_INVOICE_SUCCESS = 4100;
		public const int INSERT_INVOICE_FAILED = 4200;
		public const int INSERT_INVOICE_EXCEPTION = 4999;

		public const int INSERT_JE = 5000;
		public const int INSERT_JE_SUCCESS = 5100;
		public const int INSERT_JE_FAILED = 5200;
		public const int INSERT_JE_EXCEPTION = 5999;

        public const int GET_ORDER = 6000;
        public const int GET_ORDER_SUCCESS = 6100;
        public const int GET_ORDER_NOTFOUND = 6200;
        public const int GET_ORDER_EXCEPTION = 6999;

        public const int INSERT_ORDER = 7000;
        public const int INSERT_ORDER_SUCCESS = 7100;
        public const int INSERT_ORDER_FAILED = 7200;
        public const int INSERT_ORDER_EXCEPTION = 7999;

    }
}


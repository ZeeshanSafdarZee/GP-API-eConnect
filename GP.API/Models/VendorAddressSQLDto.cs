using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Models
{
    public class VendorAddressSQLDto
    {
		public string Vendorid { get; set; }
		public string Adrscode { get; set; }
		public string Vndcntct { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string Address3 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zipcode { get; set; }
		public string Country { get; set; }
		public string Upszone { get; set; }
		public string Phnumbr1 { get; set; }
		public string Phnumbr2 { get; set; }
		public string Phone3 { get; set; }
		public string Faxnumbr { get; set; }
		public string Shipmthd { get; set; }
		public string Taxschid { get; set; }
		public byte EmailPos { get; set; }
		public string PoemailRecipient { get; set; }
		public short EmailPoformat { get; set; }
		public byte FaxPos { get; set; }
		public string PofaxNumber { get; set; }
		public short FaxPoformat { get; set; }
		public string Ccode { get; set; }
		public string Declid { get; set; }
		public DateTime DexRowTs { get; set; }
		public int DexRowId { get; set; }
	}
}

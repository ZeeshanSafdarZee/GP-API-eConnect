using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Models
{
    public class EFTInfoCreateDto
    {
		[Required]
		[Display(Name = "VendorID")]
		public string Vendorid { get; set; }
		[Required]
		[Display(Name = "AddressID")]
		public string Adrscode { get; set; }
		[Display(Name = "BankName")]
		public string Bankname { get; set; }
		[Display(Name = "BankAccount")]
		public string EftbankAcct { get; set; }
		[Display(Name = "BankBranch")]
		public string EftbankBranch { get; set; }
		[Display(Name = "BankCode")]
		public string EftbankCode { get; set; }
		[Display(Name = "BankBranchCode")]
		public string EftbankBranchCode { get; set; }
		[Display(Name = "BankCheckDigit")]
		public string EftbankCheckDigit { get; set; }
		[Display(Name = "RoutingNumber")]
		public string EfttransitRoutingNo { get; set; }
		[Display(Name = "TransferMethod")]
		public short EfttransferMethod { get; set; }
		[Display(Name = "AccountType")]
		public short EftaccountType { get; set; }
		
	}
}

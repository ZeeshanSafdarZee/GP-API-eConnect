using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Models
{
    public class EFTInfoDto
    {
		public short Series
		{
			get
			{
				return 4;  //4 = Payables / Vendor
			}
		}

		public string CustomerVendorId
		{
			get
			{
				return Vendorid;
			}
		}
		
		[Required]
		public string Vendorid { get; set; }
		
		[Required]
		public string Adrscode { get; set; }
		public string Custnmbr { get; set; }
		public short EftuseMasterId
		{
			get
			{
				return 1;
			}
		}

		public short EftbankType
		{
			get
			{
				return 31;  //31 = United States
			}
		}

		public byte Frgnbank
		{
			get
			{
				return 0;  //0 = false
			}
		}

		public byte Inactive { get; set; }
		public string Bankname { get; set; }
		public string EftbankAcct { get; set; }
		public string EftbankBranch { get; set; }
		public short GiropostType
		{
			get
			{
				return 0;  
			}
		}
		public string EftbankCode { get; set; }
		public string EftbankBranchCode { get; set; }
		public string EftbankCheckDigit { get; set; }

		public string Bsrollno
		{
			get
			{
				return string.Empty;
			}
		}
		public string IntlBankAcctNum
		{
			get
			{
				return string.Empty;
			}
		}
		public string Swiftaddr
		{
			get
			{
				return string.Empty;
			}
		}
		public string CustVendCountryCode
		{
			get
			{
				return string.Empty;
			}
		}
		public string DeliveryCountryCode
		{
			get
			{
				return string.Empty;
			}
		}
		public string Bnkctrcd
		{
			get
			{
				return string.Empty;
			}
		}
		public string Cbankcd
		{
			get
			{
				return string.Empty;
			}
		}
		public string Address1
		{
			get
			{
				return string.Empty;
			}
		}
		public string Address2
		{
			get
			{
				return string.Empty;
			}
		}
		public string Address3
		{
			get
			{
				return string.Empty;
			}
		}
		public string Address4
		{
			get
			{
				return string.Empty;
			}
		}
		public string RegCode1
		{
			get
			{
				return string.Empty;
			}
		}
		public string RegCode2
		{
			get
			{
				return string.Empty;
			}
		}
		public short BankInfo7
		{
			get
			{
				return 0;
			}
		}

		public string EfttransitRoutingNo { get; set; }
		public string Curncyid { get; set; }
		
		public short EfttransferMethod { get; set; }
		public short EftaccountType { get; set; }
		public DateTime EftprenoteDate { get; set; }
		public DateTime EftterminationDate { get; set; }
		public int DexRowId { get; set; }
	}
}

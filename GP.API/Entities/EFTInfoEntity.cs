using System;
using System.Collections.Generic;

namespace GP.API.Entities
{
    public partial class EFTInfoEntity
    {
		public short Series { get; set; }
		public string CustomerVendorId { get; set; }
		public string Vendorid { get; set; }
		public string Adrscode { get; set; }

		public string Custnmbr { get; set; }
		public short EftuseMasterId { get; set; }
		public short EftbankType { get; set; }
		public byte Frgnbank { get; set; }
		public byte Inactive { get; set; }
		public string Bankname { get; set; }
		public string EftbankAcct { get; set; }
		public string EftbankBranch { get; set; }
		public short GiropostType { get; set; }
		public string EftbankCode { get; set; }
		public string EftbankBranchCode { get; set; }
		public string EftbankCheckDigit { get; set; }
		public string Bsrollno { get; set; }
		public string IntlBankAcctNum { get; set; }
		public string Swiftaddr { get; set; }
		public string CustVendCountryCode { get; set; }
		public string DeliveryCountryCode { get; set; }
		public string Bnkctrcd { get; set; }
		public string Cbankcd { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string Address3 { get; set; }
		public string Address4 { get; set; }
		public string RegCode1 { get; set; }
		public string RegCode2 { get; set; }
		public short BankInfo7 { get; set; }
		public string EfttransitRoutingNo { get; set; }
		public string Curncyid { get; set; }
		public short EfttransferMethod { get; set; }
		public short EftaccountType { get; set; }
		//public DateTime EftprenoteDate { get; set; }
		//public DateTime EftterminationDate { get; set; }
		public int DexRowId { get; set; }
	}
}

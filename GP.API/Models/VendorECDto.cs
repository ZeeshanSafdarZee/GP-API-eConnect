using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace GP.API.Models
{
    public class VendorECDto
    {
		[Required(ErrorMessage = "Vendor ID is required")]
		[MaxLength(15)]
		public string VENDORID { get; set; }
		[Required(ErrorMessage = "Vendor Name is required")]
		[MaxLength(60)]
		public string VENDNAME { get; set; }
		public string VENDSHNM { get; set; }
		public string VNDCHKNM { get; set; }
		//public short HOLD { get; set; }
		//public short VENDSTTS { get; set; }
		public string VNDCLSID { get; set; }
		public string VADDCDPR { get; set; }
		public string VNDCNTCT { get; set; }
		public string ADDRESS1 { get; set; }
		public string ADDRESS2 { get; set; }
		public string ADDRESS3 { get; set; }
		public string CITY { get; set; }
		public string STATE { get; set; }
		public string ZIPCODE { get; set; }
		public string CCode { get; set; }
		public string COUNTRY { get; set; }
		public string PHNUMBR1 { get; set; }
		public string PHNUMBR2 { get; set; }
		public string PHNUMBR3 { get; set; }
		public string FAXNUMBR { get; set; }
		//public string TAXSCHID { get; set; }
		//public string SHIPMTHD { get; set; }
		//public string UPSZONE { get; set; }
		//public string VADCDPAD { get; set; }
		//public string VADCDTRO { get; set; }
		//public string VADCDSFR { get; set; }
		public string ACNMVNDR { get; set; }
		public string COMMENT1 { get; set; }
		public string COMMENT2 { get; set; }
		public string NOTETEXT { get; set; }
		//public string CURNCYID { get; set; }
		//public string RATETPID { get; set; }
		public string PYMTRMID { get; set; }
		//public short DISGRPER { get; set; }
		//public short DUEGRPER { get; set; }
		//public string PYMNTPRI { get; set; }
		//decimal MINORDER { get; set; }
		//decimal TRDDISCT { get; set; }
		public string TXIDNMBR { get; set; }
		//public string TXRGNNUM { get; set; }
		//public string CHEKBKID { get; set; }
		public string USERDEF1 { get; set; }
		public string USERDEF2 { get; set; }
		public short TEN99TYPE { get; set; }
		public short TEN99BOXdecimal { get; set; }
		//public short FREEONBOARD { get; set; }
		//public short USERLANG { get; set; }
		//public short MINPYTYP { get; set; }
		//decimal MINPYDLR { get; set; }
		//decimal MINPYPCT { get; set; }
		//public short MXIAFVND { get; set; }
		//decimal MAXINDLR { get; set; }
		//public short CREDTLMT { get; set; }
		//decimal CRLMTDLR { get; set; }
		//public short WRITEOFF { get; set; }
		//decimal MXWOFAMT { get; set; }
		//public short Revalue_Vendor { get; set; }
		//public short Post_Results_To { get; set; }
		//public short KPCALHST { get; set; }
		//public short KPERHIST { get; set; }
		//public short KPTRXHST { get; set; }
		//public short KGLDSTHS { get; set; }
		//public short PTCSHACF { get; set; }
		//public string PMCSHACTNUMST { get; set; }
		//public string PMAPACTNUMST { get; set; }
		//public string PMDAVACTNUMST { get; set; }
		//public string PMDTKACTNUMST { get; set; }
		//public string PMFINACTNUMST { get; set; }
		//public string PMPRCHACTNUMST { get; set; }
		//public string PMTDSCACTNUMST { get; set; }
		//public string PMMSCHACTNUMST { get; set; }
		//public string PMFRTACTNUMST { get; set; }
		//public string PMTAXACTNUMST { get; set; }
		//public string PMWRTACTNUMST { get; set; }
		//public string ACPURACTNUMST { get; set; }
		//public string PURPVACTNUMST { get; set; }
		//public short UseVendorClass { get; set; }
		//public short CreateAddress { get; set; }
		public short UpdateIfExists { get; set; }
		//public short RequesterTrx { get; set; }
		//public string USRDEFND1 { get; set; }
		//public string USRDEFND2 { get; set; }
		//public string USRDEFND3 { get; set; }
		//public string USRDEFND4 { get; set; }
		//public string USRDEFND5 { get; set; }

	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace GP.API.Models
{
    public class APInvoiceECDto
    {
		public string BACHNUMB { get; set; }
		//public string VCHNUMWK { get; set; }

		[Required(ErrorMessage = "Vendor ID is required")]
		[MaxLength(15)]
		public string VENDORID { get; set; }
		[Required(ErrorMessage = "DocNumber is required")]
		[MaxLength(15)]
		public string DOCNUMBR { get; set; }
				
		public DateTime? DOCDATE { get; set; }  //Model binding requires nullable datetime to handle invalid/blank/null values
		public DateTime? PSTGDATE { get; set; }  //Model binding requires nullable datetime to handle invalid/blank/null values

		public string VADCDTRO { get; set; }
		public string VADDCDPR { get; set; }
		public string PYMTRMID { get; set; }
		
		public DateTime? DUEDATE { get; set; }  //Model binding requires nullable datetime to handle invalid/blank/null values

		public string TRXDSCRN { get; set; }
		public string PORDNMBR { get; set; }

		public decimal PRCHAMNT { get; set; }
		public decimal MSCCHAMT { get; set; }
		public decimal TEN99AMNT { get; set; }

		//public short DOCTYPE { get; set; }

		//public decimal DOCAMNT { get; set; }

		//public string TAXSCHID { get; set; }

		//public decimal DSCDLRAM { get; set; }
		//public DateTime DISCDATE { get; set; }

		//public decimal CHRGAMNT { get; set; }
		//public decimal CASHAMNT { get; set; }
		//public string CAMCBKID { get; set; }
		//public string CDOCNMBR { get; set; }
		//public DateTime CAMTDATE { get; set; }
		//public string CAMPMTNM { get; set; }
		//public decimal CHEKAMNT { get; set; }
		//public string CHAMCBID { get; set; }
		//public DateTime CHEKDATE { get; set; }
		//public string CAMPYNBR { get; set; }
		//public decimal CRCRDAMT { get; set; }
		//public string CCAMPYNM { get; set; }
		//public string CHEKNMBR { get; set; }
		//public string CARDNAME { get; set; }
		//public string CCRCTNUM { get; set; }
		//public DateTime CRCARDDT { get; set; }
		//public string CHEKBKID { get; set; }

		//public decimal TRDISAMT { get; set; }
		//public decimal TAXAMNT { get; set; }
		//public decimal FRTAMNT { get; set; }

		//public string SHIPMTHD { get; set; }
		//public decimal DISAMTAV { get; set; }
		//public decimal DISTKNAM { get; set; }
		//public decimal APDSTKAM { get; set; }
		//public string MDFUSRID { get; set; }
		//public DateTime POSTEDDT { get; set; }
		//public string PTDURID { get; set; }
		//public string PCHSCHID { get; set; }
		//public string FRTSCHID { get; set; }
		//public string MSCSCHID { get; set; }
		//public decimal PRCTDISC { get; set; }
		//public DateTime Tax_Date { get; set; }
		//public string CURNCYID { get; set; }
		//public decimal XCHGRATE { get; set; }
		//public string RATEPID { get; set; }
		//public DateTime EXPNDATE { get; set; }
		//public DateTime EXCHDATE { get; set; }
		//public string EXGTBDSC { get; set; }
		//public string EXTBLSRC { get; set; }
		//public short RATEEXPR { get; set; }
		//public short DYSTINCR { get; set; }
		//public decimal RATEVARC { get; set; }
		//public short TRXDTDEF { get; set; }
		//public short RTCLCMTD { get; set; }
		//public short PRVDSLMT { get; set; }
		//public short DATELMTS { get; set; }
		//public DateTime TIME1 { get; set; }
		//public string BatchCHEKBKID { get; set; }
		//public short CREATEDIST { get; set; }
		//public short RequesterTrx { get; set; }
		//public string USRDEFND1 { get; set; }
		//public string USRDEFND2 { get; set; }
		//public string USRDEFND3 { get; set; }
		//public string USRDEFND4 { get; set; }
		//public string USRDEFND5 { get; set; }

	}
}

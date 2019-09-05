using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Models
{
    public class SalesOrderDto
    {
        public short SOPTYPE { get; set; }
        public string DOCID { get; set; }
        public string SOPNUMBE { get; set; }
        //public string ORIGNUMB { get; set; }
        //public int ORIGTYPE { get; set; }
        //public string TAXSCHID { get; set; }
        //public string FRTSCHID { get; set; }
        //public string MSCSCHID { get; set; }
        public string SHIPMTHD { get; set; }
        public decimal TAXAMNT { get; set; }
        public string LOCNCODE { get; set; }
        public DateTime DOCDATE { get; set; }  //S. Endow: using DateTime data type requires use of using System, which apparently references .NET Framework 4.5.2, which results in a bug, causing the controller to receive NULL
        public decimal FRTAMNT { get; set; }
        public decimal MISCAMNT { get; set; }
        public decimal TRDISAMT { get; set; }
        //public decimal TRADEPCT { get; set; }
        //public decimal DISTKNAM { get; set; }
        public decimal MRKDNAMT { get; set; }
        public string CUSTNMBR { get; set; }
        public string CUSTNAME { get; set; }
        public string CSTPONBR { get; set; }
        public string ShipToName { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string ADDRESS3 { get; set; }
        public string CNTCPRSN { get; set; }
        public string FAXNUMBR { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string ZIPCODE { get; set; }
        public string COUNTRY { get; set; }
        public string PHNUMBR1 { get; set; }
        public string PHNUMBR2 { get; set; }
        public string PHNUMBR3 { get; set; }
        //public int Print_Phone_NumberGB { get; set; }
        public decimal SUBTOTAL { get; set; }
        public decimal DOCAMNT { get; set; }
        public decimal PYMTRCVD { get; set; }
        public string SALSTERR { get; set; }
        public string SLPRSNID { get; set; }
        public string UPSZONE { get; set; }
        public string USER2ENT { get; set; }
        public string BACHNUMB { get; set; }
        //public string PRBTADCD { get; set; }
        //public string PRSTADCD { get; set; }
        //public decimal FRTTXAMT { get; set; }
        //public decimal MSCTXAMT { get; set; }
        public DateTime ORDRDATE { get; set; }  //S. Endow: using DateTime data type requires use of using System, which apparently references .NET Framework 4.5.2, which results in a bug, causing the controller to receive NULL
        //public int MSTRNUMB { get; set; }
        public string PYMTRMID { get; set; }
        //public DateTime DUEDATE { get; set; }
        //public DateTime DISCDATE { get; set; }
        public string REFRENCE { get; set; }
        public int USINGHEADERLEVELTAXES { get; set; }
        public string BatchCHEKBKID { get; set; }
        //public int CREATECOMM { get; set; }
        //public decimal COMMAMNT { get; set; }
        //public decimal COMPRCNT { get; set; }
        public int CREATEDIST { get; set; }
        public int CREATETAXES { get; set; }
        //public int DEFTAXSCHDS { get; set; }
        //public string CURNCYID { get; set; }
        //public decimal XCHGRATE { get; set; }
        //public string RATETPID { get; set; }
        //public DateTime EXPNDATE { get; set; }
        //public DateTime EXCHDATE { get; set; }
        //public string EXGTBDSC { get; set; }
        //public string EXTBLSRC { get; set; }
        //public int RATEEXPR { get; set; }
        //public int DYSTINCR { get; set; }
        //public decimal RATEVARC { get; set; }
        //public int TRXDTDEF { get; set; }
        //public int RTCLCMTD { get; set; }
        //public int PRVDSLMT { get; set; }
        //public int DATELMTS { get; set; }
        //public DateTime TIME1 { get; set; }
        //public decimal DISAVAMT { get; set; }
        //public decimal DSCDLRAM { get; set; }
        //public decimal DSCPCTAM { get; set; }
        //public int FREIGTBLE { get; set; }
        //public int MISCTBLE { get; set; }
        public string COMMNTID { get; set; }
        public string COMMENT_1 { get; set; }
        public string COMMENT_2 { get; set; }
        public string COMMENT_3 { get; set; }
        public string COMMENT_4 { get; set; }
        //public string GPSFOINTEGRATIONID { get; set; }
        //public int INTEGRATIONSOURCE { get; set; }
        //public string INTEGRATIONID { get; set; }
        public DateTime ReqShipDate { get; set; }  //S. Endow: using DateTime data type requires use of using System, which apparently references .NET Framework 4.5.2, which results in a bug, causing the controller to receive NULL
        public int RequesterTrx { get; set; }
        public int CKCreditLimit { get; set; }
        public int CKHOLD { get; set; }
        public int UpdateExisting { get; set; }
        //public DateTime QUOEXPDA { get; set; }
        //public DateTime QUOTEDAT { get; set; }
        public DateTime INVODATE { get; set; }   //S. Endow: using DateTime data type requires use of using System, which apparently references .NET Framework 4.5.2, which results in a bug, causing the controller to receive NULL
        public DateTime BACKDATE { get; set; }   //S. Endow: using DateTime data type requires use of using System, which apparently references .NET Framework 4.5.2, which results in a bug, causing the controller to receive NULL
        public DateTime RETUDATE { get; set; }   //S. Endow: using DateTime data type requires use of using System, which apparently references .NET Framework 4.5.2, which results in a bug, causing the controller to receive NULL
        public string CMMTTEXT { get; set; }
        public string PRCLEVEL { get; set; }
        public int DEFPRICING { get; set; }
        public string TAXEXMT1 { get; set; }
        public string TAXEXMT2 { get; set; }
        //public string TXRGNNUM { get; set; }
        //public int REPTING { get; set; }
        //public int TRXFREQU { get; set; }
        //public int TIMETREP { get; set; }
        //public int QUOTEDYSTINCR { get; set; }
        public string NOTETEXT { get; set; }
        public string USRDEFND1 { get; set; }
        public string USRDEFND2 { get; set; }
        public string USRDEFND3 { get; set; }
        public string USRDEFND4 { get; set; }
        public string USRDEFND5 { get; set; }
        
        public List<SalesOrderLineDto> SalesOrderLines { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API.Models
{
    public class SalesOrderLineDto
    {
        public int SOPTYPE { get; set; }
        public string SOPNUMBE { get; set; }
        public string CUSTNMBR { get; set; }
        public DateTime DOCDATE { get; set; }  //S. Endow: using DateTime data type requires use of using System, which apparently references .NET Framework 4.5.2, which results in a bug, causing the controller to receive NULL
        //public DateTime USERDATE { get; set; }
        public string LOCNCODE { get; set; }
        public string ITEMNMBR { get; set; }
        public int AutoAssignBin { get; set; }
        public decimal UNITPRCE { get; set; }
        public decimal XTNDPRCE { get; set; }
        public decimal QUANTITY { get; set; }
        public decimal MRKDNAMT { get; set; }
        public decimal MRKDNPCT { get; set; }
        public string COMMNTID { get; set; }
        public string COMMENT_1 { get; set; }
        public string COMMENT_2 { get; set; }
        public string COMMENT_3 { get; set; }
        public string COMMENT_4 { get; set; }
        //public decimal UNITCOST { get; set; }
        public string PRCLEVEL { get; set; }
        public string ITEMDESC { get; set; }
        public decimal TAXAMNT { get; set; }
        //public decimal QTYONHND { get; set; }
        //public decimal QTYRTRND { get; set; }
        //public decimal QTYINUSE { get; set; }
        //public decimal QTYINSVC { get; set; }
        //public decimal QTYDMGED { get; set; }
        public short NONINVEN { get; set; }
        public int LNITMSEQ { get; set; }
        public short DROPSHIP { get; set; }
        public decimal QTYTBAOR { get; set; }
        public string DOCID { get; set; }
        public string SALSTERR { get; set; }
        public string SLPRSNID { get; set; }
        public string ITMTSHID { get; set; }
        public short IVITMTXB { get; set; }
        public string TAXSCHID { get; set; }
        public string PRSTADCD { get; set; }
        public string ShipToName { get; set; }
        public string CNTCPRSN { get; set; }
        public string ADDRESS1 { get; set; }
        public string ADDRESS2 { get; set; }
        public string ADDRESS3 { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string ZIPCODE { get; set; }
        public string COUNTRY { get; set; }
        public string PHONE1 { get; set; }
        public string PHONE2 { get; set; }
        public string PHONE3 { get; set; }
        public string FAXNUMBR { get; set; }
        //public int Print_Phone_NumberGB { get; set; }
        //public int EXCEPTIONALDEMAND { get; set; }
        public DateTime ReqShipDate { get; set; }    //S. Endow: using DateTime data type requires use of using System, which apparently references .NET Framework 4.5.2, which results in a bug, causing the controller to receive NULL
        public DateTime FUFILDAT { get; set; }
        public DateTime ACTLSHIP { get; set; }
        public string SHIPMTHD { get; set; }
        public string INVINDX { get; set; }
        public string CSLSINDX { get; set; }
        public string SLSINDX { get; set; }
        public string MKDNINDX { get; set; }
        public string RTNSINDX { get; set; }
        public string INUSINDX { get; set; }
        public string INSRINDX { get; set; }
        public string DMGDINDX { get; set; }
        public int AUTOALLOCATESERIAL { get; set; }
        public int AUTOALLOCATELOT { get; set; }
        //public string GPSFOINTEGRATIONID { get; set; }
        //public int INTEGRATIONSOURCE { get; set; }
        //public string INTEGRATIONID { get; set; }
        public int RequesterTrx { get; set; }
        public decimal QTYCANCE { get; set; }
        public decimal QTYFULFI { get; set; }
        public short ALLOCATE { get; set; }
        public short UpdateIfExists { get; set; }
        public short RecreateDist { get; set; }
        public decimal QUOTEQTYTOINV { get; set; }
        public decimal TOTALQTY { get; set; }
        public string CMMTTEXT { get; set; }
        //public int KitCompMan { get; set; }
        public int DEFPRICING { get; set; }
        public int DEFEXTPRICE { get; set; }
        public string CURNCYID { get; set; }
        public string UOFM { get; set; }
        public int IncludePromo { get; set; }
        public int CKCreditLimit { get; set; }
        public int QtyShrtOpt { get; set; }
        public string USRDEFND1 { get; set; }
        public string USRDEFND2 { get; set; }
        public string USRDEFND3 { get; set; }
        public string USRDEFND4 { get; set; }
        public string USRDEFND5 { get; set; }
                
    }
}

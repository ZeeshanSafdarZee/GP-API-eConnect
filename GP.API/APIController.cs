using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Dynamics.GP.eConnect.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GP.API.Models;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace GP.API
{
    public class APIController
    {
		private static APIModel model = new APIModel();
		private static readonly APIController instance = new APIController();
		
		public static APIController Instance
		{
			get { return APIController.instance; }
		}

		public APIModel APIModel
		{
			get { return APIController.model; }
		}
        
        public bool ImportSalesOrder(SalesOrderDto salesOrder, ref SalesOrderResponseDto orderResponse)
        {
            try
            {
                taSopHdrIvcInsert sopHeader; 
                List<taSopLineIvcInsert_ItemsTaSopLineIvcInsert> sopLines = new List<taSopLineIvcInsert_ItemsTaSopLineIvcInsert>();
                taSopLineIvcInsert_ItemsTaSopLineIvcInsert sopLine;

                bool success = false;
                string orderNumber = salesOrder.SOPNUMBE;
                string customerID = salesOrder.CUSTNMBR;
                int errorCode = 0;
                string errorMessage = string.Empty;

                sopHeader = new taSopHdrIvcInsert
                {
                    
                    SOPTYPE = salesOrder.SOPTYPE,
                    SOPNUMBE = salesOrder.SOPNUMBE,
                    DOCID = instance.APIModel.APIConfig.SOPTypeID,
                    SHIPMTHD = salesOrder.SHIPMTHD,
                    TAXAMNT = salesOrder.TAXAMNT,
                    LOCNCODE = salesOrder.LOCNCODE,
                    DOCDATE = salesOrder.DOCDATE.ToShortDateString(),
                    TRDISAMT = salesOrder.TRDISAMT,
                    MRKDNAMT = salesOrder.MRKDNAMT,
                    CUSTNMBR = salesOrder.CUSTNMBR,
                    CUSTNAME = salesOrder.CUSTNAME,
                    CSTPONBR = salesOrder.CSTPONBR,
                    ShipToName = salesOrder.ShipToName,
                    ADDRESS1 = salesOrder.ADDRESS1,
                    ADDRESS2 = salesOrder.ADDRESS2,
                    ADDRESS3 = salesOrder.ADDRESS3,
                    CNTCPRSN = salesOrder.CNTCPRSN,
                    FAXNUMBR = salesOrder.FAXNUMBR,
                    CITY = salesOrder.CITY,
                    STATE = salesOrder.STATE,
                    ZIPCODE = salesOrder.ZIPCODE,
                    COUNTRY = salesOrder.COUNTRY,
                    PHNUMBR1 = salesOrder.PHNUMBR1,
                    PHNUMBR2 = salesOrder.PHNUMBR2,
                    PHNUMBR3 = salesOrder.PHNUMBR3,
                    SUBTOTAL = salesOrder.SUBTOTAL,
                    FREIGHT = salesOrder.FRTAMNT,
                    MISCAMNT = salesOrder.MISCAMNT,
                    DOCAMNT = salesOrder.DOCAMNT,
                    SALSTERR = salesOrder.SALSTERR,
                    SLPRSNID = salesOrder.SLPRSNID,
                    UPSZONE = salesOrder.UPSZONE,
                    USER2ENT = "GPWEBAPI",
                    BACHNUMB = "WEBORDERS",

                    USINGHEADERLEVELTAXES = 1,
                    DEFTAXSCHDS = 1

                };

                foreach (SalesOrderLineDto line in salesOrder.SalesOrderLines)
                {
                    sopLine = new taSopLineIvcInsert_ItemsTaSopLineIvcInsert
                    {
                        SOPTYPE = sopHeader.SOPTYPE,
                        SOPNUMBE = sopHeader.SOPNUMBE,
                        CUSTNMBR = sopHeader.CUSTNMBR,
                        DOCDATE = sopHeader.DOCDATE,
                        LOCNCODE = line.LOCNCODE,
                        ITEMNMBR = line.ITEMNMBR,
                        ITEMDESC = line.ITEMDESC,
                        UNITPRCE = line.UNITPRCE,
                        XTNDPRCE = line.XTNDPRCE,
                        QUANTITY = line.QUANTITY,

                        COMMNTID = line.COMMNTID,
                        COMMENT_1 = line.COMMENT_1,
                        COMMENT_2 = line.COMMENT_2,
                        COMMENT_3 = line.COMMENT_3,
                        COMMENT_4 = line.COMMENT_4,
                        PRCLEVEL = line.PRCLEVEL,
                        TAXAMNT = line.TAXAMNT,
                        NONINVEN = line.NONINVEN,
                        LNITMSEQ = line.LNITMSEQ,
                        DROPSHIP = line.DROPSHIP,
                        QTYTBAOR = line.QTYTBAOR,
                        DOCID = line.DOCID,
                        SALSTERR = line.SALSTERR,
                        SLPRSNID = line.SLPRSNID,
                        ITMTSHID = line.ITMTSHID,
                        IVITMTXB = line.IVITMTXB,
                        TAXSCHID = line.TAXSCHID,
                        PRSTADCD = line.PRSTADCD,
                        ShipToName = line.ShipToName,
                        CNTCPRSN = line.CNTCPRSN,
                        ADDRESS1 = line.ADDRESS1,
                        ADDRESS2 = line.ADDRESS2,
                        ADDRESS3 = line.ADDRESS3,
                        CITY = line.CITY,
                        STATE = line.STATE,
                        ZIPCODE = line.ZIPCODE,
                        COUNTRY = line.COUNTRY,
                        PHONE1 = line.PHONE1,
                        PHONE2 = line.PHONE2,
                        PHONE3 = line.PHONE3,
                        FAXNUMBR = line.FAXNUMBR,
                        QTYCANCE = line.QTYCANCE,
                        QTYFULFI = line.QTYFULFI,
                        ALLOCATE = line.ALLOCATE,
                        TOTALQTY = line.TOTALQTY,
                        CMMTTEXT = line.CMMTTEXT,

                        //Quantity shortage option: 
                        //1 = Sell balance;
                        //2 = Override shortage;
                        //3 = Back Order all;
                        //4 = Back Order balance;
                        //5 = Cancel all;
                        //6 = Cancel balance

                        QtyShrtOpt = instance.APIModel.APIConfig.QtyShortageOption,
                        UOFM = line.UOFM
                    };
                    sopLines.Add(sopLine);
                }


                //**********************************************************************
                //Assemble document
                //**********************************************************************

                SOPTransactionType sopTransaction = new SOPTransactionType();
                sopTransaction.taSopHdrIvcInsert = sopHeader;
                sopTransaction.taSopLineIvcInsert_Items = sopLines.ToArray();

                SOPTransactionType[] sopTransactionType = { sopTransaction };

                eConnectType eConnect = new eConnectType();
                eConnect.SOPTransactionType = sopTransactionType;

                MemoryStream memStream = new MemoryStream();
                XmlSerializer serializer = new XmlSerializer(eConnect.GetType());
                serializer.Serialize(memStream, eConnect);
                memStream.Position = 0;

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(memStream);
                memStream.Close();

                string response = string.Empty;
                success = eConn.InsertTransaction(ref response, xmlDocument.OuterXml, instance.APIModel.APIConfig.GPCompanyDB);  

                if (success == false)
                {
                    errorMessage = "Failed to import order " + orderNumber + " for customer " + customerID + ": " + response;
                }

                orderResponse.Success = success;
                orderResponse.OrderNumber = orderNumber;
                orderResponse.ErrorCode = errorCode;
                orderResponse.ErrorMessage = errorMessage;
                orderResponse.DocumentData = xmlDocument.OuterXml;

                return success;

            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool UpdateSalesOrder(SalesOrderDto salesOrder, ref SalesOrderResponseDto orderResponse)
        {
            try
            {
                taSopHdrIvcInsert sopHeader; 
                List<taSopLineIvcInsert_ItemsTaSopLineIvcInsert> sopLines = new List<taSopLineIvcInsert_ItemsTaSopLineIvcInsert>();
                taSopLineIvcInsert_ItemsTaSopLineIvcInsert sopLine;

                bool success = false;
                string orderNumber = salesOrder.SOPNUMBE;
                string customerID = salesOrder.CUSTNMBR;
                int errorCode = 0;
                string errorMessage = string.Empty;

                sopHeader = new taSopHdrIvcInsert
                {
                    
                    SOPTYPE = salesOrder.SOPTYPE,
                    SOPNUMBE = salesOrder.SOPNUMBE,
                    DOCID = instance.APIModel.APIConfig.SOPTypeID,
                    SHIPMTHD = salesOrder.SHIPMTHD,
                    TAXAMNT = salesOrder.TAXAMNT,
                    LOCNCODE = salesOrder.LOCNCODE,
                    DOCDATE = salesOrder.DOCDATE.ToShortDateString(),
                    TRDISAMT = salesOrder.TRDISAMT,
                    MRKDNAMT = salesOrder.MRKDNAMT,
                    CUSTNMBR = salesOrder.CUSTNMBR,
                    CUSTNAME = salesOrder.CUSTNAME,
                    CSTPONBR = salesOrder.CSTPONBR,
                    ShipToName = salesOrder.ShipToName,
                    ADDRESS1 = salesOrder.ADDRESS1,
                    ADDRESS2 = salesOrder.ADDRESS2,
                    ADDRESS3 = salesOrder.ADDRESS3,
                    CNTCPRSN = salesOrder.CNTCPRSN,
                    FAXNUMBR = salesOrder.FAXNUMBR,
                    CITY = salesOrder.CITY,
                    STATE = salesOrder.STATE,
                    ZIPCODE = salesOrder.ZIPCODE,
                    COUNTRY = salesOrder.COUNTRY,
                    PHNUMBR1 = salesOrder.PHNUMBR1,
                    PHNUMBR2 = salesOrder.PHNUMBR2,
                    PHNUMBR3 = salesOrder.PHNUMBR3,
                    SUBTOTAL = salesOrder.SUBTOTAL,
                    FREIGHT = salesOrder.FRTAMNT,
                    MISCAMNT = salesOrder.MISCAMNT,
                    DOCAMNT = salesOrder.DOCAMNT,
                    SALSTERR = salesOrder.SALSTERR,
                    SLPRSNID = salesOrder.SLPRSNID,
                    UPSZONE = salesOrder.UPSZONE,
                    USER2ENT = "GPWEBAPI",
                    BACHNUMB = "WEBORDERS",

                    USINGHEADERLEVELTAXES = 1,
                    DEFTAXSCHDS = 1,
                    UpdateExisting =  1,

                };

                foreach (SalesOrderLineDto line in salesOrder.SalesOrderLines)
                {
                    sopLine = new taSopLineIvcInsert_ItemsTaSopLineIvcInsert
                    {
                        SOPTYPE = sopHeader.SOPTYPE,
                        SOPNUMBE = sopHeader.SOPNUMBE,
                        CUSTNMBR = sopHeader.CUSTNMBR,
                        DOCDATE = sopHeader.DOCDATE,
                        LOCNCODE = line.LOCNCODE,
                        ITEMNMBR = line.ITEMNMBR,
                        ITEMDESC = line.ITEMDESC,
                        UNITPRCE = line.UNITPRCE,
                        XTNDPRCE = line.XTNDPRCE,
                        QUANTITY = line.QUANTITY,

                        COMMNTID = line.COMMNTID,
                        COMMENT_1 = line.COMMENT_1,
                        COMMENT_2 = line.COMMENT_2,
                        COMMENT_3 = line.COMMENT_3,
                        COMMENT_4 = line.COMMENT_4,
                        PRCLEVEL = line.PRCLEVEL,
                        TAXAMNT = line.TAXAMNT,
                        NONINVEN = line.NONINVEN,
                        LNITMSEQ = line.LNITMSEQ,
                        DROPSHIP = line.DROPSHIP,
                        QTYTBAOR = line.QTYTBAOR,
                        DOCID = line.DOCID,
                        SALSTERR = line.SALSTERR,
                        SLPRSNID = line.SLPRSNID,
                        ITMTSHID = line.ITMTSHID,
                        IVITMTXB = line.IVITMTXB,
                        TAXSCHID = line.TAXSCHID,
                        PRSTADCD = line.PRSTADCD,
                        ShipToName = line.ShipToName,
                        CNTCPRSN = line.CNTCPRSN,
                        ADDRESS1 = line.ADDRESS1,
                        ADDRESS2 = line.ADDRESS2,
                        ADDRESS3 = line.ADDRESS3,
                        CITY = line.CITY,
                        STATE = line.STATE,
                        ZIPCODE = line.ZIPCODE,
                        COUNTRY = line.COUNTRY,
                        PHONE1 = line.PHONE1,
                        PHONE2 = line.PHONE2,
                        PHONE3 = line.PHONE3,
                        FAXNUMBR = line.FAXNUMBR,
                        QTYCANCE = line.QTYCANCE,
                        QTYFULFI = line.QTYFULFI,
                        ALLOCATE = line.ALLOCATE,
                        TOTALQTY = line.TOTALQTY,
                        CMMTTEXT = line.CMMTTEXT,

                        //Quantity shortage option: 
                        //1 = Sell balance;
                        //2 = Override shortage;
                        //3 = Back Order all;
                        //4 = Back Order balance;
                        //5 = Cancel all;
                        //6 = Cancel balance

                        QtyShrtOpt = instance.APIModel.APIConfig.QtyShortageOption,
                        UOFM = line.UOFM,
                        UpdateIfExists = 1,
                    };
                    sopLines.Add(sopLine);
                }


                //**********************************************************************
                //Assemble document
                //**********************************************************************

                SOPTransactionType sopTransaction = new SOPTransactionType();
                sopTransaction.taSopHdrIvcInsert = sopHeader;
                sopTransaction.taSopLineIvcInsert_Items = sopLines.ToArray();

                SOPTransactionType[] sopTransactionType = { sopTransaction };

                eConnectType eConnect = new eConnectType();
                eConnect.SOPTransactionType = sopTransactionType;

                MemoryStream memStream = new MemoryStream();
                XmlSerializer serializer = new XmlSerializer(eConnect.GetType());
                serializer.Serialize(memStream, eConnect);
                memStream.Position = 0;

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(memStream);
                memStream.Close();

                string response = string.Empty;
                success = eConn.UpdateTransaction(ref response, xmlDocument.OuterXml, instance.APIModel.APIConfig.GPCompanyDB);  

                if (success == false)
                {
                    errorMessage = "Failed to import order " + orderNumber + " for customer " + customerID + ": " + response;
                }

                orderResponse.Success = success;
                orderResponse.OrderNumber = orderNumber;
                orderResponse.ErrorCode = errorCode;
                orderResponse.ErrorMessage = errorMessage;
                orderResponse.DocumentData = xmlDocument.OuterXml;

                return success;

            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}

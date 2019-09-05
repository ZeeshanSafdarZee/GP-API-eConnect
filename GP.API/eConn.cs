using Microsoft.Dynamics.GP.eConnect;
using Microsoft.Dynamics.GP.eConnect.Serialization;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace GP.API
{

    public static class eConn
    {
		public static bool CreateEntity(ref string response, string transactionXML, string companyDB)
        {
            string connString = DataAccess.ConnectionStringWindows;

            bool returnValue;
            response = "";

            eConnectMethods eConnCall = new eConnectMethods();

            try
            {
                returnValue = eConnCall.CreateEntity(connString, transactionXML);
                return true;
            }
            catch (eConnectException ex)
            {
                response = ex.Message;
                return false;
            }
            catch (SqlException ex)
            {
                foreach (SqlError sqlErr in ex.Errors)
                {
                    response += sqlErr.Message + "\r\n";
                }
                return false;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return false;
            }

        }

        public static bool DeleteEntity(ref string response, string transactionXML, string companyDB)
        {
            string connString = DataAccess.ConnectionStringWindows;

            bool returnValue;
            response = "";

            eConnectMethods eConnCall = new eConnectMethods();

            try
            {
                returnValue = eConnCall.DeleteEntity(connString, transactionXML);
                return true;
            }
            catch (eConnectException ex)
            {
                response = ex.Message;
                return false;
            }
            catch (SqlException ex)
            {
                foreach (SqlError sqlErr in ex.Errors)
                {
                    response += sqlErr.Message + "\r\n";
                }
                return false;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return false;
            }

        }

        public static bool UpdateEntity(ref string response, string transactionXML, string companyDB)
        {
            string connString = DataAccess.ConnectionStringWindows;

            bool returnValue;
            response = "";

            eConnectMethods eConnCall = new eConnectMethods();

            try
            {
                returnValue = eConnCall.UpdateEntity(connString, transactionXML);
                return true;
            }
            catch (eConnectException ex)
            {
                response = ex.Message;
                return false;
            }
            catch (SqlException ex)
            {
                foreach (SqlError sqlErr in ex.Errors)
                {
                    response += sqlErr.Message + "\r\n";
                }
                return false;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return false;
            }

        }

        public static bool CreateTransactionEntity(ref string response, string transactionXML, string companyDB)
        {
            string connString = DataAccess.ConnectionStringWindows;

            string returnValue = string.Empty;
            response = "";

            eConnectMethods eConnCall = new eConnectMethods();

            try
            {
                returnValue = eConnCall.CreateTransactionEntity(connString, transactionXML);

                return true;
            }
            catch (eConnectException ex)
            {
                response = ex.Message;
                return false;
            }
            catch (SqlException ex)
            {
                foreach (SqlError sqlErr in ex.Errors)
                {
                    response += sqlErr.Message + "\r\n";
                }
                return false;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return false;
            }

        }

        private static string SerializeObject(object obj, System.Type type)
        {
            try
            {
                string XmlString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(type);
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                xs.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlString = UTF8ByteArrayToString(memoryStream.ToArray());
                return XmlString;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static string UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            string constructedString = encoding.GetString(characters);
            constructedString = constructedString.Remove(0, 1);
            return (constructedString);
        }

        public  static bool InsertTransaction(ref string response, string transactionXML, string gpDatabase)
        {
            string connString = DataAccess.ConnectionStringWindows;
            string returnValue;
            response = "";

            eConnectMethods eConnCall = new eConnectMethods();

            try
            {
                returnValue = eConnCall.CreateTransactionEntity(connString, transactionXML);
                return true;
            }
            catch (eConnectException ex)
            {
                response = ex.Message;
                return false;
            }
            catch (SqlException ex)
            {
                foreach (SqlError sqlErr in ex.Errors)
                {
                    response += sqlErr.Message + "\r\n";
                }
                return false;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return false;
            }

        }
		public  static bool UpdateTransaction(ref string response, string transactionXML, string gpDatabase)
        {
            string connString = DataAccess.ConnectionStringWindows;
            bool returnValue;
            response = "";

            eConnectMethods eConnCall = new eConnectMethods();

            try
            {
                returnValue = eConnCall.UpdateTransactionEntity(connString, transactionXML);
                return true;
            }
            catch (eConnectException ex)
            {
                response = ex.Message;
                return false;
            }
            catch (SqlException ex)
            {
                foreach (SqlError sqlErr in ex.Errors)
                {
                    response += sqlErr.Message + "\r\n";
                }
                return false;
            }
            catch (Exception ex)
            {
                response = ex.Message;
                return false;
            }

        }
		
        public static bool CheckeConnectVendor(string gpDatabase, string gpVendorID, ref int errorNumber, ref string errorMessage)
        {
            try
            {
				//Create / update test vendor to check eConnect status
				taUpdateCreateVendorRcd vendor = new taUpdateCreateVendorRcd();

				vendor.VENDORID = gpVendorID;
				vendor.VENDNAME = "eConnect Status TEST VENDOR";
				vendor.HOLD = 1;
				vendor.HOLDSpecified = true;
				vendor.VENDSTTS = 2;
				vendor.VENDSTTSSpecified = true;
				vendor.VADDCDPR = "TEST";
				vendor.VNDCNTCT = "eConnect Status Test GP Web API";
				vendor.ADDRESS1 = "eConnect Status Test";
				vendor.ADDRESS2 = "eConnect Status Test";
				vendor.ADDRESS3 = "eConnect Status Test";
				vendor.COMMENT1 = "Updated " + DateTime.Now;
				
                vendor.UpdateIfExists = 1;

				PMVendorMasterType PMVendor = new PMVendorMasterType();
				PMVendor.taUpdateCreateVendorRcd = vendor;

				PMVendorMasterType[] PMVendorType = { PMVendor };
				
                eConnectType eConnect = new eConnectType();
				eConnect.PMVendorMasterType = PMVendorType;
				
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xmlSerializer = new XmlSerializer(eConnect.GetType());
                xmlSerializer.Serialize(memoryStream, eConnect);
                memoryStream.Position = 0;

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(memoryStream);
                memoryStream.Close();

                string response = string.Empty;

                bool returnValue = CreateEntity(ref response, xmlDocument.OuterXml, gpDatabase);

                if (returnValue == true)
                {
                    errorNumber = 0;
                    errorMessage = string.Empty;
                    return true;
                }
                else
                {
                    gpVendorID = string.Empty;
                    errorNumber = 520;
                    errorMessage = "Failed to import eConnect test vendor: " + response;
                    return false;
                }

            }
            catch (Exception ex)
            {
                gpVendorID = string.Empty;
                errorNumber = 529;
                errorMessage = "An unexpected error occurred in CheckeConnect: " + ex.Message;
                return false;
            }
        }

        public static bool CheckeConnectCustomer(string gpDatabase, string gpCustomerID, ref int errorNumber, ref string errorMessage)
		{
			try
			{
				//Create / update test customer to check eConnect status
				taUpdateCreateCustomerRcd customer = new taUpdateCreateCustomerRcd();

				customer.CUSTNMBR = gpCustomerID;
				customer.HOLD = 1;
				customer.HOLDSpecified = true;
				customer.INACTIVE = 1;
				customer.INACTIVESpecified = true;
				customer.CUSTNAME = "eConnect Status Test GP Web API";
				customer.CNTCPRSN = "eConnect Status Test";
				customer.ADRSCODE = "MAILING";
				customer.ADDRESS1 = "eConnect Status Test";
				customer.ADDRESS2 = "eConnect Status Test";
				customer.ADDRESS3 = "eConnect Status Test";
				customer.CITY = "eConnect Test";
				customer.STATE = "TEST";
				customer.ZIPCODE = "00000";
				customer.COMMENT1 = "Updated " + DateTime.Now;

				customer.UpdateIfExists = 1;

				RMCustomerMasterType RMCust = new RMCustomerMasterType();
				RMCust.taUpdateCreateCustomerRcd = customer;
				RMCustomerMasterType[] RMCustType = { RMCust };

				eConnectType eConnect = new eConnectType();
				eConnect.RMCustomerMasterType = RMCustType;

				MemoryStream memoryStream = new MemoryStream();
				XmlSerializer xmlSerializer = new XmlSerializer(eConnect.GetType());
				xmlSerializer.Serialize(memoryStream, eConnect);
				memoryStream.Position = 0;

				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(memoryStream);
				memoryStream.Close();

				string response = string.Empty;

				bool returnValue = CreateEntity(ref response, xmlDocument.OuterXml, gpDatabase);

				if (returnValue == true)
				{
					errorNumber = 0;
					errorMessage = string.Empty;
					return true;
				}
				else
				{
					gpCustomerID = string.Empty;
					errorNumber = 520;
					errorMessage = "Failed to import eConnect test customer: " + response;
					return false;
				}

			}
			catch (Exception ex)
			{
				gpCustomerID = string.Empty;
				errorNumber = 529;
				errorMessage = "An unexpected error occurred in CheckeConnect: " + ex.Message;
				return false;
			}
		}

        public static bool SaleTransactionEntry(string gpDatabase, string gpVendorID, ref int errorNumber, ref string errorMessage)
        {
            try
            {
                //Create / update test vendor to check eConnect status
                SOPTransactionType salesOrder = new SOPTransactionType();

                taSopLineIvcInsert_ItemsTaSopLineIvcInsert salesLine = new taSopLineIvcInsert_ItemsTaSopLineIvcInsert();
                taSopHdrIvcInsert salesHdr = new taSopHdrIvcInsert();

                taSopLineIvcInsert_ItemsTaSopLineIvcInsert[] LineItems = new taSopLineIvcInsert_ItemsTaSopLineIvcInsert[1];

                salesLine.CUSTNMBR = "AARONFIT0001";
                salesLine.SOPTYPE = 2;
                salesLine.DOCID = "STDORD";
                salesLine.QUANTITY = 2;
                salesLine.ITEMNMBR = "3-B3813A";
                salesLine.UNITPRCE = 100;
                salesLine.XTNDPRCE = 200;
                //salesLine.DOCDATE = System.DateTime.Today.ToString("MM/dd/yyyy");
                salesLine.DOCDATE = "04/12/2027";
                LineItems[0] = salesLine;

                salesOrder.taSopLineIvcInsert_Items = LineItems;

                salesHdr.SOPTYPE = 2;
                salesHdr.DOCID = "STDORD";
                salesHdr.BACHNUMB = "B1";
                //salesHdr.DOCDATE = System.DateTime.Today.ToString("MM/dd/yyyy");
                salesHdr.DOCDATE = "04/12/2027";
                salesHdr.CUSTNMBR = "AARONFIT0001";
                salesHdr.SUBTOTAL = 200;
                salesHdr.DOCAMNT = 200;
                salesHdr.USINGHEADERLEVELTAXES = 0;
                salesHdr.PYMTRMID = "Net 30";
                salesHdr.UpdateExisting = 1;

                salesOrder.taSopHdrIvcInsert = salesHdr;
                eConnectType eConnect = new eConnectType();
                SOPTransactionType[] MySopTransactionType = new SOPTransactionType[1] { salesOrder };

                eConnect.SOPTransactionType = MySopTransactionType;

                // Serialize the master vendor type in memory.
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xmlSerializer = new XmlSerializer(eConnect.GetType());


                // Serialize the eConnectType.
                xmlSerializer.Serialize(memoryStream, eConnect);

                // Reset the position of the memory stream to the start.              
                memoryStream.Position = 0;

                // Create an XmlDocument from the serialized eConnectType in memory.
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(memoryStream);
                memoryStream.Close();

                string response = string.Empty;

                bool returnValue = CreateEntity(ref response, xmlDocument.OuterXml, gpDatabase);

                if (returnValue == true)
                {
                    errorNumber = 0;
                    errorMessage = string.Empty;
                    return true;
                }
                else
                {
                    errorNumber = 520;
                    errorMessage = "Failed to import eConnect test Sale Transaction: " + response;
                    return false;
                }

            }
            catch (Exception ex)
            {
                gpVendorID = string.Empty;
                errorNumber = 529;
                errorMessage = "An unexpected error occurred in CheckeConnect: " + ex.Message;
                return false;
            }
        }

        public static bool UpdateSaleTransactionEntry(string gpDatabase, string gpVendorID, ref int errorNumber, ref string errorMessage)
        {
            try
            {

                SOPTransactionType salesOrder = new SOPTransactionType();

                taSopLineIvcInsert_ItemsTaSopLineIvcInsert salesLine = new taSopLineIvcInsert_ItemsTaSopLineIvcInsert();
                taSopLineIvcInsert_ItemsTaSopLineIvcInsert salesLine2 = new taSopLineIvcInsert_ItemsTaSopLineIvcInsert();
                taSopHdrIvcInsert salesHdr = new taSopHdrIvcInsert();

                taSopLineIvcInsert_ItemsTaSopLineIvcInsert[] LineItems = new taSopLineIvcInsert_ItemsTaSopLineIvcInsert[2];

                salesLine.CUSTNMBR = "AARONFIT0001";
                salesLine.SOPTYPE = 2;
                salesLine.DOCID = "STDORD";
                salesLine.QUANTITY = 2;
                salesLine.ITEMNMBR = "3-B3813A";
                salesLine.UNITPRCE = 100;
                salesLine.XTNDPRCE = 200;
                //salesLine.DOCDATE = System.DateTime.Today.ToString("MM/dd/yyyy");
                salesLine.DOCDATE = "04/12/2027";
                salesLine.UpdateIfExists = 1;
                salesLine.SOPNUMBE = "ORDST2236";

                salesLine2.CUSTNMBR = "AARONFIT0001";
                salesLine2.SOPTYPE = 2;
                salesLine2.DOCID = "STDORD";
                salesLine2.QUANTITY = 0;
                salesLine2.ITEMNMBR = "100XLG";
                salesLine2.UNITPRCE = (decimal)59.95;
                salesLine2.XTNDPRCE = (decimal)(0);
                //salesLine.DOCDATE = System.DateTime.Today.ToString("MM/dd/yyyy");
                salesLine2.DOCDATE = "04/12/2027";
                salesLine2.UpdateIfExists = 1;
                salesLine2.SOPNUMBE = "ORDST2236";


                LineItems[0] = salesLine;
                LineItems[1] = salesLine2;

                salesOrder.taSopLineIvcInsert_Items = LineItems;

                salesHdr.SOPTYPE = 2;
                salesHdr.DOCID = "STDORD";
                salesHdr.SOPNUMBE = "ORDST2236";
                salesHdr.BACHNUMB = "B1";
                //salesHdr.DOCDATE = System.DateTime.Today.ToString("MM/dd/yyyy");
                salesHdr.DOCDATE = "04/12/2027";
                salesHdr.CUSTNMBR = "AARONFIT0001";
                salesHdr.SUBTOTAL = 200;
                salesHdr.DOCAMNT = 200;
                salesHdr.USINGHEADERLEVELTAXES = 0;
                salesHdr.PYMTRMID = "Net 30";
                salesHdr.MSTRNUMB = 410;
                salesHdr.UpdateExisting = 1;

                salesOrder.taSopHdrIvcInsert = salesHdr;
                eConnectType eConnect = new eConnectType();
                SOPTransactionType[] MySopTransactionType = new SOPTransactionType[1] { salesOrder };

                eConnect.SOPTransactionType = MySopTransactionType;

                // Serialize the master vendor type in memory.
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xmlSerializer = new XmlSerializer(eConnect.GetType());


                // Serialize the eConnectType.
                xmlSerializer.Serialize(memoryStream, eConnect);

                // Reset the position of the memory stream to the start.              
                memoryStream.Position = 0;

                // Create an XmlDocument from the serialized eConnectType in memory.
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(memoryStream);
                memoryStream.Close();

                string response = string.Empty;

                bool returnValue = UpdateEntity(ref response, xmlDocument.OuterXml, gpDatabase);

                if (returnValue == true)
                {
                    errorNumber = 0;
                    errorMessage = string.Empty;
                    return true;
                }
                else
                {
                    errorNumber = 520;
                    errorMessage = "Failed to delete eConnect test Sale Transaction: " + response;
                    return false;
                }

            }
            catch (Exception ex)
            {
                gpVendorID = string.Empty;
                errorNumber = 529;
                errorMessage = "An unexpected error occurred in CheckeConnect: " + ex.Message;
                return false;
            }
        }

        public static bool DeleteSaleTransactionEntry(string gpDatabase, string gpVendorID, ref int errorNumber, ref string errorMessage)
        {
            try
            {
                SOPDeleteLineType deleteLineType = new SOPDeleteLineType();

                taSopLineDelete salesLine = new taSopLineDelete();

                taSopDeleteDocument sopDeleteDocument = new taSopDeleteDocument();
                salesLine.SOPNUMBE = "ORDST0007";
                salesLine.ITEMNMBR = "3-B3813A";
                salesLine.SOPTYPE = 2;
                //salesLine.DeleteType = 1; // delete one line item
                salesLine.DeleteType = 2; 

                sopDeleteDocument.SOPNUMBE = "ORDST0007";
                sopDeleteDocument.SOPTYPE = 2;

                deleteLineType.taSopLineDelete = salesLine;

                eConnectType eConnect = new eConnectType();
                SOPDeleteLineType[] MySopTransactionType = new SOPDeleteLineType[1] { deleteLineType };

                eConnect.SOPDeleteLineType = MySopTransactionType;

                // Serialize the master vendor type in memory.
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xmlSerializer = new XmlSerializer(eConnect.GetType());


                // Serialize the eConnectType.
                xmlSerializer.Serialize(memoryStream, eConnect);

                // Reset the position of the memory stream to the start.              
                memoryStream.Position = 0;

                // Create an XmlDocument from the serialized eConnectType in memory.
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(memoryStream);
                memoryStream.Close();

                //XmlDocument xmlDocument = new XmlDocument();
                //xmlDocument.LoadXml("\"D:\\\\DEVELOPMENT\\\\DOT_NET\\\\Connexus\\\\GP_API\\\\GP.API\\\\SOPDeleteDocument.xsd\"");
                string response = string.Empty;

                bool returnValue = DeleteEntity(ref response, xmlDocument.OuterXml, gpDatabase);

                if (returnValue == true)
                {
                    errorNumber = 0;
                    errorMessage = string.Empty;
                    return true;
                }
                else
                {
                    errorNumber = 520;
                    errorMessage = "Failed to delete eConnect test Sale Transaction: " + response;
                    return false;
                }

            }
            catch (Exception ex)
            {
                gpVendorID = string.Empty;
                errorNumber = 529;
                errorMessage = "An unexpected error occurred in CheckeConnect: " + ex.Message;
                return false;
            }
        }

    }


}

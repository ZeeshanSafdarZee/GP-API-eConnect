using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GP.API
{
    public static class DataAccess
    {
        static string gpServer;
        static string gpDatabase;
        static string gpLoginType;
        static string gpUser;
        static string gpPassword;
        static string gpConnString;

        static DataAccess()
        {
            RetrieveDBConnectionSettings();
        }


        static public void RetrieveDBConnectionSettings()
        {
            try
            {
                //Get GP server and login info from model
                gpServer = APIController.Instance.APIModel.APIConfig.GPServer;
                gpDatabase = APIController.Instance.APIModel.APIConfig.GPCompanyDB;
                gpLoginType = APIController.Instance.APIModel.APIConfig.GPLoginType;
                gpUser = APIController.Instance.APIModel.APIConfig.GPUser;
                gpPassword = APIController.Instance.APIModel.APIConfig.GPPassword;
                gpConnString = ConnectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        static public string ConnectionString
        {

            get
            {
                if (gpLoginType == "SQL" && gpServer != string.Empty && gpDatabase != string.Empty && gpUser != string.Empty && gpPassword != string.Empty)
                {
                    //Return connection string for ".NET Framework Data Provider for SQL Server"  (System.Data.SqlClient.SqlConnection)
                    return @"Data Source=" + gpServer + ";Initial Catalog=" + gpDatabase + ";User ID=" + gpUser + ";Password=" + gpPassword + ";";
                }
                else if (gpLoginType == "WINDOWS" && gpServer != string.Empty && gpDatabase != string.Empty)
                {
                    //Return connection string for ".NET Framework Data Provider for SQL Server"  (System.Data.SqlClient.SqlConnection)
                    return @"Data Source=" + gpServer + ";Initial Catalog=" + gpDatabase + ";Integrated Security=SSPI;";
                }

                //else if (gpServer == string.Empty && gpDatabase == string.Empty && gpConnString != string.Empty)
                //{
                //    return gpConnString;
                //}
                else
                {
                    return "";
                }
            }
            set
            {
                gpConnString = value;
            }
        }
        
        static public string ConnectionStringWindows
        {

            get
            {
                //Return connection string for ".NET Framework Data Provider for SQL Server"  (System.Data.SqlClient.SqlConnection)
                return @"Data Source=" + gpServer + ";Initial Catalog=" + gpDatabase + ";Integrated Security=SSPI;";
            }
        }
        
        static public SqlConnection Connection()
        {

            //Create and open a connection to GP SQL Server
            //Return open connection object

            RetrieveDBConnectionSettings();

            SqlConnection gpConn = new SqlConnection();

            if (gpLoginType == "SQL" || gpLoginType == "WINDOWS")
            {
                gpConn.ConnectionString = ConnectionString;
                gpConn.Open();

            }
            //else if (gpLoginType == "GP")
            //{

            //    int response = GPConnection.Startup();

            //    GPConnection GPConnObj = new GPConnection();

            //    GPConnObj.Init("yourkey1", "yourkey2");
            //    gpConn.ConnectionString = "DATABASE=" + gpDatabase;
            //    GPConnObj.Connect(gpConn, gpServer, gpUser, gpPassword);
            //    //If login is successful, gpConn is returned as an open connection

            //}
            
            return gpConn;

        }



        static public int ExecuteDataSet(ref DataTable dataTable, string database, CommandType commandType, string commandText, SqlParameter[] sqlParameters)
        {
            gpDatabase = database;

            SqlConnection gpConn = new SqlConnection();

            try
            {

                gpConn = Connection();

                SqlCommand gpCommand = new SqlCommand(commandText);
                gpCommand.Connection = gpConn;
                gpCommand.CommandType = commandType;
                
                if (sqlParameters != null)
                {
                    foreach (SqlParameter sqlParameter in sqlParameters)
                    {
                        gpCommand.Parameters.Add(sqlParameter);
                    }
                }
                
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(gpCommand);
                sqlDataAdapter.Fill(dataTable);

                return dataTable.Rows.Count;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gpConn.Close();
            }
        }
        
        static public int ExecuteNonQuery(string database, CommandType commandType, string commandText, SqlParameter[] sqlParameters)
        {

            gpDatabase = database;

            int rowsAffected = 0;

            SqlConnection gpConn = new SqlConnection();

            try
            {
                gpConn = Connection();

                SqlCommand gpCommand = new SqlCommand(commandText);
                gpCommand.Connection = gpConn;
                gpCommand.CommandType = commandType;

                if ((commandType == CommandType.StoredProcedure) || (commandType == CommandType.Text))
                {
                    if (sqlParameters != null)
                    {
                        foreach (SqlParameter sqlParameter in sqlParameters)
                        {
                            gpCommand.Parameters.Add(sqlParameter);
                        }
                    }
                }

                rowsAffected = gpCommand.ExecuteNonQuery();

                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gpConn.Close();
            }
        }
        
		static public int ExecuteNonQueryRef(string database, CommandType commandType, string commandText, ref SqlParameter[] sqlParameters)
		{

			gpDatabase = database;

			int rowsAffected = 0;

			SqlConnection gpConn = new SqlConnection();

			try
			{
				gpConn = Connection();

				SqlCommand gpCommand = new SqlCommand(commandText);
				gpCommand.Connection = gpConn;
				gpCommand.CommandType = commandType;

				if ((commandType == CommandType.StoredProcedure) || (commandType == CommandType.Text))
				{
					if (sqlParameters != null)
					{
						foreach (SqlParameter sqlParameter in sqlParameters)
						{
							gpCommand.Parameters.Add(sqlParameter);
						}
					}
				}

				rowsAffected = gpCommand.ExecuteNonQuery();


				return rowsAffected;

			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				gpConn.Close();
			}
		}
        
		static public string ExecuteScalar(string database, CommandType commandType, string commandText, SqlParameter[] sqlParameters)
        {
            gpDatabase = database;

            string scalarResult = "";

            SqlConnection gpConn = new SqlConnection();

            try
            {
                gpConn = Connection();

                SqlCommand gpCommand = new SqlCommand(commandText);
                gpCommand.Connection = gpConn;
                gpCommand.CommandType = commandType;


                if ((commandType == CommandType.StoredProcedure) || (commandType == CommandType.Text))
                {
                    if (sqlParameters != null)
                    {
                        foreach (SqlParameter sqlParameter in sqlParameters)
                        {
                            gpCommand.Parameters.Add(sqlParameter);
                        }
                    }
                }

                object result = gpCommand.ExecuteScalar();

                if (result != null)
                {
                    scalarResult = Convert.ToString(result).Trim();
                }
                else
                {
                    scalarResult = string.Empty;
                }

                return scalarResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gpConn.Close();
            }
        }
        
        static public List<string> ExecuteProcWithOutput(string database, CommandType commandType, string commandText, SqlParameter[] sqlParameters, List<int> paramsToReturn)
        {

            //Executes stored procedure with parameters and returns output parameters
            //paramsToReturn is a zero based list of parameter indexes to return

            gpDatabase = database;

            SqlConnection gpConn = new SqlConnection();

            try
            {
                int records = 0;
                List<string> output = new List<string>();

                gpConn = Connection();

                SqlCommand gpCommand = new SqlCommand(commandText);
                gpCommand.Connection = gpConn;
                gpCommand.CommandType = commandType;

                if ((commandType == CommandType.StoredProcedure) || (commandType == CommandType.Text))
                {
                    if (sqlParameters != null)
                    {
                        foreach (SqlParameter sqlParameter in sqlParameters)
                        {
                            gpCommand.Parameters.Add(sqlParameter);
                        }
                    }
                }

                records = gpCommand.ExecuteNonQuery();

                foreach (int param in paramsToReturn)
                {
                    output.Add(sqlParameters[param].Value.ToString().Trim());
                }

                return output;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gpConn.Close();
            }
        }



        internal static bool ValidSQLLogin(ref string error)
        {
            
            string result = string.Empty;
            error = string.Empty;
            
            SqlConnection gpConn = new SqlConnection();

            try
            {
                gpConn = Connection();
                if (gpConn.State == ConnectionState.Closed)
                    gpConn.Open();
                error = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }

        }


        //internal static bool ValidGPLogin(ref string error)
        //{
            
        //    string result = string.Empty;
        //    error = string.Empty;

        //    try
        //    {
        //        result = ExecuteScalar("DYNAMICS", CommandType.Text, "SELECT COUNT(*) AS Records FROM DYNAMICS..ACTIVITY", null);
        //        if (result.Trim() != "")
        //            return true;
        //        else
        //            return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        error = ex.Message;
        //        return false;
        //    }

        //}


		public static string GetFunctionalCurrency(string database)
		{
			
			try
			{
				string result = ExecuteScalar(database, CommandType.Text, "SELECT FUNLCURR FROM MC40000", null);
				if (result.Trim() != "")
				{
					return result.Trim();
				}
				else
				{
					return string.Empty;
				}

			}
			catch (Exception)
			{
				return string.Empty;
			}

		}


		internal static bool VendorEFTExists(string vendorID, string addressID)
		{

			try
			{
				SqlParameter[] sqlParameters = new SqlParameter[2];
				sqlParameters[0] = new SqlParameter("@VENDORID", System.Data.SqlDbType.VarChar, 15);
				sqlParameters[0].Value = vendorID;
				sqlParameters[1] = new SqlParameter("@ADRSCODE", System.Data.SqlDbType.VarChar, 15);
				sqlParameters[1].Value = addressID;
				
				string result = ExecuteScalar(APIController.Instance.APIModel.APIConfig.GPCompanyDB, CommandType.Text, "SELECT COUNT(*) AS Records FROM SY06000 WHERE SERIES = 4 AND VENDORID = @VENDORID AND ADRSCODE = @ADRSCODE", sqlParameters);

				int recordCount = Convert.ToInt32(result);

				if (recordCount > 0)
				{
					return true;
				}
				else
				{
					return false;
				}

			}
			catch (Exception ex)
			{
				throw ex;
				//return false;
			}

		}


		public static bool InsertUpdateEFT(Models.EFTInfoDto eftInfo)
		{
			try
			{
				bool success = false;

				if (VendorEFTExists(eftInfo.Vendorid, eftInfo.Adrscode))
				{
					success = UpdateEFT(eftInfo);
				}
				else
				{
					success = InsertEFT(eftInfo);
				}

				return success;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public static bool InsertEFT(Models.EFTInfoDto eftInfo)
		{
			string commandText = "zDP_SY06000SI";

			SqlParameter[] sqlParameters = new SqlParameter[37];

			sqlParameters[0] = new SqlParameter("@SERIES", SqlDbType.SmallInt);
			sqlParameters[0].Value = eftInfo.Series;
			sqlParameters[1] = new SqlParameter("@CustomerVendor_ID", SqlDbType.VarChar, 15);
			sqlParameters[1].Value = eftInfo.CustomerVendorId;
			sqlParameters[2] = new SqlParameter("@ADRSCODE", SqlDbType.VarChar, 15);
			sqlParameters[2].Value = eftInfo.Adrscode;
			sqlParameters[3] = new SqlParameter("@VENDORID", SqlDbType.VarChar, 15);
			sqlParameters[3].Value = eftInfo.Vendorid;
			sqlParameters[4] = new SqlParameter("@CUSTNMBR", SqlDbType.VarChar, 15);
			sqlParameters[4].Value = eftInfo.Custnmbr;
			sqlParameters[5] = new SqlParameter("@EFTUseMasterID", SqlDbType.SmallInt);
			sqlParameters[5].Value = eftInfo.EftuseMasterId;
			sqlParameters[6] = new SqlParameter("@EFTBankType", SqlDbType.SmallInt);
			sqlParameters[6].Value = eftInfo.EftbankType;
			sqlParameters[7] = new SqlParameter("@FRGNBANK", SqlDbType.TinyInt);
			sqlParameters[7].Value = eftInfo.Frgnbank;
			sqlParameters[8] = new SqlParameter("@INACTIVE", SqlDbType.TinyInt);
			sqlParameters[8].Value = eftInfo.Inactive;
			sqlParameters[9] = new SqlParameter("@BANKNAME", SqlDbType.VarChar, 31);
			sqlParameters[9].Value = eftInfo.Bankname;
			sqlParameters[10] = new SqlParameter("@EFTBankAcct", SqlDbType.VarChar, 35);
			sqlParameters[10].Value = eftInfo.EftbankAcct;
			sqlParameters[11] = new SqlParameter("@EFTBankBranch", SqlDbType.VarChar, 15);
			sqlParameters[11].Value = eftInfo.EftbankBranch;
			sqlParameters[12] = new SqlParameter("@GIROPostType", SqlDbType.SmallInt);
			sqlParameters[12].Value = eftInfo.GiropostType;
			sqlParameters[13] = new SqlParameter("@EFTBankCode", SqlDbType.VarChar, 15);
			sqlParameters[13].Value = eftInfo.EftbankCode;
			sqlParameters[14] = new SqlParameter("@EFTBankBranchCode", SqlDbType.VarChar, 5);
			sqlParameters[14].Value = eftInfo.EftbankBranchCode;
			sqlParameters[15] = new SqlParameter("@EFTBankCheckDigit", SqlDbType.VarChar, 3);
			sqlParameters[15].Value = eftInfo.EftbankCheckDigit;
			sqlParameters[16] = new SqlParameter("@BSROLLNO", SqlDbType.VarChar, 31);
			sqlParameters[16].Value = eftInfo.Bsrollno;
			sqlParameters[17] = new SqlParameter("@IntlBankAcctNum", SqlDbType.VarChar, 35);
			sqlParameters[17].Value = eftInfo.IntlBankAcctNum;
			sqlParameters[18] = new SqlParameter("@SWIFTADDR", SqlDbType.VarChar, 11);
			sqlParameters[18].Value = eftInfo.Swiftaddr;
			sqlParameters[19] = new SqlParameter("@CustVendCountryCode", SqlDbType.VarChar, 3);
			sqlParameters[19].Value = eftInfo.CustVendCountryCode;
			sqlParameters[20] = new SqlParameter("@DeliveryCountryCode", SqlDbType.VarChar, 3);
			sqlParameters[20].Value = eftInfo.DeliveryCountryCode;
			sqlParameters[21] = new SqlParameter("@BNKCTRCD", SqlDbType.VarChar, 3);
			sqlParameters[21].Value = eftInfo.Bnkctrcd;
			sqlParameters[22] = new SqlParameter("@CBANKCD", SqlDbType.VarChar, 9);
			sqlParameters[22].Value = eftInfo.Cbankcd;
			sqlParameters[23] = new SqlParameter("@ADDRESS1", SqlDbType.VarChar, 61);
			sqlParameters[23].Value = eftInfo.Address1;
			sqlParameters[24] = new SqlParameter("@ADDRESS2", SqlDbType.VarChar, 61);
			sqlParameters[24].Value = eftInfo.Address2;
			sqlParameters[25] = new SqlParameter("@ADDRESS3", SqlDbType.VarChar, 61);
			sqlParameters[25].Value = eftInfo.Address3;
			sqlParameters[26] = new SqlParameter("@ADDRESS4", SqlDbType.VarChar, 61);
			sqlParameters[26].Value = eftInfo.Address4;
			sqlParameters[27] = new SqlParameter("@RegCode1", SqlDbType.VarChar, 31);
			sqlParameters[27].Value = eftInfo.RegCode1;
			sqlParameters[28] = new SqlParameter("@RegCode2", SqlDbType.VarChar, 31);
			sqlParameters[28].Value = eftInfo.RegCode2;
			sqlParameters[29] = new SqlParameter("@BankInfo7", SqlDbType.SmallInt);
			sqlParameters[29].Value = eftInfo.BankInfo7;
			sqlParameters[30] = new SqlParameter("@EFTTransitRoutingNo", SqlDbType.VarChar, 11);
			sqlParameters[30].Value = eftInfo.EfttransitRoutingNo;
			sqlParameters[31] = new SqlParameter("@CURNCYID", SqlDbType.VarChar, 15);
			sqlParameters[31].Value = eftInfo.Curncyid;
			sqlParameters[32] = new SqlParameter("@EFTTransferMethod", SqlDbType.SmallInt);
			sqlParameters[32].Value = eftInfo.EfttransferMethod;
			sqlParameters[33] = new SqlParameter("@EFTAccountType", SqlDbType.SmallInt);
			sqlParameters[33].Value = eftInfo.EftaccountType;
			sqlParameters[34] = new SqlParameter("@EFTPrenoteDate", SqlDbType.DateTime);
			sqlParameters[34].Value = Convert.ToDateTime("1900-01-01");
			sqlParameters[35] = new SqlParameter("@EFTTerminationDate", SqlDbType.DateTime);
			sqlParameters[35].Value = Convert.ToDateTime("1900-01-01");
			sqlParameters[36] = new SqlParameter("@DEX_ROW_ID", SqlDbType.Int);
			sqlParameters[36].Direction = ParameterDirection.InputOutput;
			sqlParameters[36].Value = 0;  // eftInfo.DexRowId;
			
			var paramsToReturn = new List<int>();
			paramsToReturn.Add(36);

			List<string> returnParams = DataAccess.ExecuteProcWithOutput(APIController.Instance.APIModel.APIConfig.GPCompanyDB, CommandType.StoredProcedure, commandText, sqlParameters, paramsToReturn);

			if (Convert.ToInt32(returnParams[0]) > 0)
			{
				return true;
			}
			else
			{
				return false;
			}

		}


		public static bool UpdateEFT(Models.EFTInfoDto eftInfo)
		{
			string commandText = "UPDATE SY06000 SET ";
			commandText += "EFTUseMasterID = @EFTUseMasterID, EFTBankType = @EFTBankType, FRGNBANK = @FRGNBANK, ";
			commandText += "INACTIVE = @INACTIVE, BANKNAME = @BANKNAME, EFTBankAcct = @EFTBankAcct, EFTBankBranch = @EFTBankBranch, ";
			commandText += "GIROPostType = @GIROPostType, EFTBankCode = @EFTBankCode, EFTBankBranchCode = @EFTBankBranchCode, ";
			commandText += "EFTBankCheckDigit = @EFTBankCheckDigit, BSROLLNO = @BSROLLNO, IntlBankAcctNum = @IntlBankAcctNum, ";
			commandText += "SWIFTADDR = @SWIFTADDR, CustVendCountryCode = @CustVendCountryCode, DeliveryCountryCode = @DeliveryCountryCode, ";
			commandText += "BNKCTRCD = @BNKCTRCD, CBANKCD = @CBANKCD, ADDRESS1 = @ADDRESS1, ADDRESS2 = @ADDRESS2, ADDRESS3 = @ADDRESS3, ";
			commandText += "ADDRESS4 = @ADDRESS4, RegCode1 = @RegCode1, RegCode2 = @RegCode2, BankInfo7 = @BankInfo7, ";
			commandText += "EFTTransitRoutingNo = @EFTTransitRoutingNo, CURNCYID = @CURNCYID, EFTTransferMethod = @EFTTransferMethod, ";
			commandText += "EFTAccountType = @EFTAccountType "; // EFTPrenoteDate = @EFTPrenoteDate, EFTTerminationDate = @EFTTerminationDate ";
			commandText += "WHERE SERIES = 4 AND VENDORID = @VENDORID AND ADRSCODE = @ADRSCODE";

			SqlParameter[] sqlParameters = new SqlParameter[31];

			sqlParameters[0] = new SqlParameter("@VENDORID", SqlDbType.VarChar, 15);
			sqlParameters[0].Value = eftInfo.Vendorid;
			sqlParameters[1] = new SqlParameter("@ADRSCODE", SqlDbType.VarChar, 15);
			sqlParameters[1].Value = eftInfo.Adrscode;
			sqlParameters[2] = new SqlParameter("@EFTUseMasterID", SqlDbType.SmallInt);
			sqlParameters[2].Value = eftInfo.EftuseMasterId;
			sqlParameters[3] = new SqlParameter("@EFTBankType", SqlDbType.SmallInt);
			sqlParameters[3].Value = eftInfo.EftbankType;
			sqlParameters[4] = new SqlParameter("@FRGNBANK", SqlDbType.TinyInt);
			sqlParameters[4].Value = eftInfo.Frgnbank;
			sqlParameters[5] = new SqlParameter("@INACTIVE", SqlDbType.TinyInt);
			sqlParameters[5].Value = eftInfo.Inactive;
			sqlParameters[6] = new SqlParameter("@BANKNAME", SqlDbType.VarChar, 31);
			sqlParameters[6].Value = eftInfo.Bankname;
			sqlParameters[7] = new SqlParameter("@EFTBankAcct", SqlDbType.VarChar, 35);
			sqlParameters[7].Value = eftInfo.EftbankAcct;
			sqlParameters[8] = new SqlParameter("@EFTBankBranch", SqlDbType.VarChar, 15);
			sqlParameters[8].Value = eftInfo.EftbankBranch;
			sqlParameters[9] = new SqlParameter("@GIROPostType", SqlDbType.SmallInt);
			sqlParameters[9].Value = eftInfo.GiropostType;
			sqlParameters[10] = new SqlParameter("@EFTBankCode", SqlDbType.VarChar, 15);
			sqlParameters[10].Value = eftInfo.EftbankCode;
			sqlParameters[11] = new SqlParameter("@EFTBankBranchCode", SqlDbType.VarChar, 5);
			sqlParameters[11].Value = eftInfo.EftbankBranchCode;
			sqlParameters[12] = new SqlParameter("@EFTBankCheckDigit", SqlDbType.VarChar, 3);
			sqlParameters[12].Value = eftInfo.EftbankCheckDigit;
			sqlParameters[13] = new SqlParameter("@BSROLLNO", SqlDbType.VarChar, 31);
			sqlParameters[13].Value = eftInfo.Bsrollno;
			sqlParameters[14] = new SqlParameter("@IntlBankAcctNum", SqlDbType.VarChar, 35);
			sqlParameters[14].Value = eftInfo.IntlBankAcctNum;
			sqlParameters[15] = new SqlParameter("@SWIFTADDR", SqlDbType.VarChar, 11);
			sqlParameters[15].Value = eftInfo.Swiftaddr;
			sqlParameters[16] = new SqlParameter("@CustVendCountryCode", SqlDbType.VarChar, 3);
			sqlParameters[16].Value = eftInfo.CustVendCountryCode;
			sqlParameters[17] = new SqlParameter("@DeliveryCountryCode", SqlDbType.VarChar, 3);
			sqlParameters[17].Value = eftInfo.DeliveryCountryCode;
			sqlParameters[18] = new SqlParameter("@BNKCTRCD", SqlDbType.VarChar, 3);
			sqlParameters[18].Value = eftInfo.Bnkctrcd;
			sqlParameters[19] = new SqlParameter("@CBANKCD", SqlDbType.VarChar, 9);
			sqlParameters[19].Value = eftInfo.Cbankcd;
			sqlParameters[20] = new SqlParameter("@ADDRESS1", SqlDbType.VarChar, 61);
			sqlParameters[20].Value = eftInfo.Address1;
			sqlParameters[21] = new SqlParameter("@ADDRESS2", SqlDbType.VarChar, 61);
			sqlParameters[21].Value = eftInfo.Address2;
			sqlParameters[22] = new SqlParameter("@ADDRESS3", SqlDbType.VarChar, 61);
			sqlParameters[22].Value = eftInfo.Address3;
			sqlParameters[23] = new SqlParameter("@ADDRESS4", SqlDbType.VarChar, 61);
			sqlParameters[23].Value = eftInfo.Address4;
			sqlParameters[24] = new SqlParameter("@RegCode1", SqlDbType.VarChar, 31);
			sqlParameters[24].Value = eftInfo.RegCode1;
			sqlParameters[25] = new SqlParameter("@RegCode2", SqlDbType.VarChar, 31);
			sqlParameters[25].Value = eftInfo.RegCode2;
			sqlParameters[26] = new SqlParameter("@BankInfo7", SqlDbType.SmallInt);
			sqlParameters[26].Value = eftInfo.BankInfo7;
			sqlParameters[27] = new SqlParameter("@EFTTransitRoutingNo", SqlDbType.VarChar, 11);
			sqlParameters[27].Value = eftInfo.EfttransitRoutingNo;
			sqlParameters[28] = new SqlParameter("@CURNCYID", SqlDbType.VarChar, 15);
			sqlParameters[28].Value = eftInfo.Curncyid;
			sqlParameters[29] = new SqlParameter("@EFTTransferMethod", SqlDbType.SmallInt);
			sqlParameters[29].Value = eftInfo.EfttransferMethod;
			sqlParameters[30] = new SqlParameter("@EFTAccountType", SqlDbType.SmallInt);
			sqlParameters[30].Value = eftInfo.EftaccountType;
			//sqlParameters[31] = new SqlParameter("@EFTPrenoteDate", SqlDbType.DateTime);
			//sqlParameters[31].Value = eftInfo.EftprenoteDate;
			//sqlParameters[32] = new SqlParameter("@EFTTerminationDate", SqlDbType.DateTime);
			//sqlParameters[32].Value = eftInfo.EftterminationDate;
			
			int records = DataAccess.ExecuteNonQuery(APIController.Instance.APIModel.APIConfig.GPCompanyDB, CommandType.Text, commandText, sqlParameters);
						
			if (records == 1)
			{
				return true;
			}
			else
			{
				return false;
			}

		}


		public static string GetNextVoucherNumber(ref string error)
		{

			try
			{
				string nextVoucher = string.Empty;
				error = string.Empty;

				string commandText = "taGetPMNextVoucherNumber";
				
				SqlParameter[] sqlParameters = new SqlParameter[3];

				sqlParameters[0] = new SqlParameter("@O_vCNTRLNUM", SqlDbType.VarChar, 17);
				sqlParameters[0].Direction = ParameterDirection.Output;
				//sqlParameters[0].Value = string.Empty;

				sqlParameters[1] = new SqlParameter("@I_sCNTRLTYP", SqlDbType.SmallInt);
				//sqlParameters[1].Direction = ParameterDirection.InputOutput;
				sqlParameters[1].Value = 0;

				sqlParameters[2] = new SqlParameter("@O_iErrorState", SqlDbType.SmallInt);
				//sqlParameters[2].Direction = ParameterDirection.InputOutput;
				sqlParameters[2].Value = 0;

				int records = ExecuteNonQueryRef(APIController.Instance.APIModel.APIConfig.GPCompanyDB, CommandType.StoredProcedure, commandText, ref sqlParameters);

				if (Convert.ToInt32(sqlParameters[2].Value.ToString()) == 0)
				{
					nextVoucher = sqlParameters[0].Value.ToString().Trim();
				}
				else
				{
					error = "An error occurred getting the next PM Voucher number: " + sqlParameters[2].Value.ToString();
					nextVoucher = string.Empty;
				}
				
				return nextVoucher;
			}
			catch (Exception ex)
			{
				error = "An unexpected error occurred in GetNextVoucherNumber: " + ex.Message;
				return string.Empty;
			}

		}


		public static int GetNextJENumber()
		{

			string commandText = "taGetNextJournalEntry";

			SqlParameter[] sqlParameters = new SqlParameter[3];
			sqlParameters[0] = new SqlParameter("@I_vInc_Dec", System.Data.SqlDbType.TinyInt);
			sqlParameters[0].Value = 1;
			sqlParameters[1] = new SqlParameter("@O_vJournalEntryNumber", System.Data.SqlDbType.Char, 13);
			sqlParameters[1].Direction = ParameterDirection.Output;
			sqlParameters[1].Value = 1;
			sqlParameters[2] = new SqlParameter("@O_iErrorState", System.Data.SqlDbType.Int);
			sqlParameters[2].Direction = ParameterDirection.Output;
			sqlParameters[2].Value = 0;

			int nextJE = 0;
			int recordCount = ExecuteNonQueryRef(APIController.Instance.APIModel.APIConfig.GPCompanyDB, CommandType.StoredProcedure, commandText, ref sqlParameters);
			nextJE = int.Parse(sqlParameters[1].Value.ToString());

			return nextJE;

		}


		public static int GetInvoicePayments(ref DataTable dataTable, string vendorID, string docNumber)
		{

			string commandText = "csspInvoicePayments";

			SqlParameter[] sqlParameters = new SqlParameter[2];
			sqlParameters[0] = new SqlParameter("@VENDORID", System.Data.SqlDbType.VarChar, 15);
			sqlParameters[0].Value = vendorID;
			sqlParameters[1] = new SqlParameter("@DOCNUMBR", System.Data.SqlDbType.VarChar, 21);
			sqlParameters[1].Value = docNumber;

			int recordCount = ExecuteDataSet(ref dataTable, APIController.Instance.APIModel.APIConfig.GPCompanyDB, CommandType.StoredProcedure, commandText, sqlParameters);

			return recordCount;

		}

	}
}

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Globalization;
using System.IO;

using Business.Entity;

namespace ERP
{
    public enum SortingDirection { Ascending, Descending }

    [Serializable]
    public class PageData
    {

        public string BranchCode = null;
        public string AccountCode = null;
        public string RecordLocator = null;
        public string InvoiceNoFrom = null;
        public string InvoiceNoTo = null;
        public string PassengerName = null;
        public DateTime TicketDateFrom = DateTime.MinValue;
        public DateTime TicketDateTo = DateTime.MaxValue;
        public string Departure = null;
        public string Arrive = null;
        public string IsNonAirInvoice = null;
        public string TicketNumber = null;
        public string AgentCode = null;

        public bool ChangedOnly = false;

        public SortingDirection TicketDateOrder = SortingDirection.Descending;
        public SortingDirection InvoiceNoOrder = SortingDirection.Descending;

        public int TotalPageNumber = -1;
        public int PageSize = 100;
        public int CurrentPageNumber = 1;

    }

    public class Pager
    {
        public Pager(int number, string tx)
        {
            PageNumber = number;
            Text = tx;
        }
        public int PageNumber = 1;
        public string Text = "1";
    }

    public class Comm
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Comm));

        //private static IList<TBranch> m_branchs = null;

        public Comm()
        {

        }


        //#endregion

        //#region Invoice
        /// <summary>
        /// 组合查询条件
        /// </summary>
        private static string BuildCondition(string branchCode, string accountCode, string rl,
                                          string invNoFrom, string invNoTo,
                                          DateTime dateFrom, DateTime dateTo, bool changeOnly, string IsNonAirInvoice, string TicketNumber)
        {
            string condition = "";

            //Branch Code
            if (!string.IsNullOrEmpty(branchCode))
            {
                //condition += "BranchCode LIKE '%" + branchCode + "%'";
                condition += "BranchCode = '" + branchCode + "'";
            }

            //Account Code
            if (!string.IsNullOrEmpty(accountCode))
            {
                if (!string.IsNullOrEmpty(condition))
                {
                    condition += " AND ";
                }

                //condition += "AccountCode LIKE '%" + accountCode + "%' ";
                condition += "AccountCode = '" + accountCode + "' ";
            }

            //Record Locator
            if (!string.IsNullOrEmpty(rl))
            {
                if (!string.IsNullOrEmpty(condition))
                {
                    condition += " AND ";
                }

                //condition += "RecordLocator LIKE '%" + rl + "%' ";
                condition += "RecordLocator = '" + rl + "' ";
            }

            //Invoice Number
            if (!string.IsNullOrEmpty(invNoFrom) && !string.IsNullOrEmpty(invNoTo))
            {

                if (!string.IsNullOrEmpty(condition))
                {
                    condition += " AND ";
                }

                if (invNoFrom == invNoTo)
                {
                    //condition += "InvoiceNo LIKE '%" + invNoFrom + "%'";
                    condition += "InvoiceNo = '" + invNoFrom + "'";
                }
                else
                {
                    condition += "InvoiceNo BETWEEN '" + invNoFrom + "' AND '" + invNoTo + "'";
                }
            }
            else if (!string.IsNullOrEmpty(invNoFrom))
            {
                if (!string.IsNullOrEmpty(condition))
                {
                    condition += " AND ";
                }

                //condition += "InvoiceNo LIKE '%" + invNoFrom + "%'";
                condition += "InvoiceNo = '" + invNoFrom + "'";
            }
            else if (!string.IsNullOrEmpty(invNoTo))
            {
                if (!string.IsNullOrEmpty(condition))
                {
                    condition += " AND ";
                }

                //condition += "InvoiceNo LIKE '%" + invNoTo + "%'";
                condition += "InvoiceNo = '" + invNoTo + "'";
            }

            //DateTime
            if (dateFrom != DateTime.MinValue && dateTo != DateTime.MaxValue)
            {
                if (!string.IsNullOrEmpty(condition))
                {
                    condition += " AND ";
                }

                condition += "TicketTime BETWEEN '" + dateFrom.ToString("yyyy/MM/dd") + "' AND '" + dateTo.ToString("yyyy/MM/dd") + "'";
            }
            else if (dateFrom != DateTime.MinValue)
            {
                if (!string.IsNullOrEmpty(condition))
                {
                    condition += " AND ";
                }

                condition += "TicketTime >= '" + dateFrom.ToString("yyyy/MM/dd");
            }
            else if (dateTo != DateTime.MaxValue)
            {
                if (!string.IsNullOrEmpty(condition))
                {
                    condition += " AND ";
                }

                condition += "TicketTime <= '" + dateTo.ToString("yyyy/MM/dd");
            }

            //Changed Only
            if (changeOnly)
            {
                if (!string.IsNullOrEmpty(condition))
                {
                    condition += " AND ";
                }

                condition += "Changed = 1";
            }

            //New TypeAir Status.
            //if (changeOnly)
            //{
            //    if (!string.IsNullOrEmpty(condition))
            //    {
            //        condition += " AND ";
            //    }

            //    condition += "IsNonAirInvoice = 1";
            //}

            //IsNonAirInvoice
            if (!string.IsNullOrEmpty(IsNonAirInvoice))
            {
                if (!string.IsNullOrEmpty(condition))
                {
                    condition += " AND ";
                }

                //condition += "AccountCode LIKE '%" + accountCode + "%' ";
                condition += "IsNonAirInvoice = '" + IsNonAirInvoice + "' ";
            }

            //TicketNumber
            if (!string.IsNullOrEmpty(TicketNumber))
            {
                if (!string.IsNullOrEmpty(condition))
                {
                    condition += " AND ";
                }

                //condition += "AccountCode LIKE '%" + accountCode + "%' ";
                //condition += "RecordLocator in (select RecordLocator from T_INVOICE where ID in (select InvoiceID from  T_TICKETINFO where TicketNumber = '" + TicketNumber + "') )  ";
            }

            return condition;
        }

        /// <summary>
        /// 或许符合条件总数
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int GetInvTotalRecordNumber(string branchCode, string accountCode, string rl,
                                          string invNoFrom, string invNoTo,
                                          DateTime dateFrom, DateTime dateTo, bool changeOnly, string IsNonAirInvoice, string TicketNumber)
        {
            int total = 0;
            string strSql = "SELECT COUNT(*) FROM T_INVOICE";
            string condition = BuildCondition(branchCode, accountCode, rl, invNoFrom, invNoTo, dateFrom, dateTo, changeOnly, IsNonAirInvoice, TicketNumber);
            if (!string.IsNullOrEmpty(condition))
            {
                strSql += " WHERE " + condition;
            }

            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                connection.Open();
                cmd = new SqlCommand(strSql, connection);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    total = dr.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                //log.Error("GetBrachAndAccount", ex);
            }
            finally
            {
                if (dr != null && !dr.IsClosed)
                {
                    dr.Close();
                }

                if (connection != null)
                {
                    connection.Close();
                }
            }

            return total;
        }

      

        /// <summary>
        /// 获取单页数据
        /// </summary>
        private static IList<TInvoice> GetInvPageData(string condition, SortingDirection dateDir, SortingDirection noDir,
                                                        int pageSize, int pageNo)
        {
            SqlConnection connection = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            IList<TInvoice> invs = new List<TInvoice>();


            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerInvoiceDA.ConnectionString"].ConnectionString);
                connection.Open();
                cmd = new SqlCommand("GetInvoiceData", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Condition", condition));
                cmd.Parameters.Add(new SqlParameter("@TktDateOrder", (dateDir == SortingDirection.Ascending ? "ASC" : "DESC")));
                cmd.Parameters.Add(new SqlParameter("@InvNoOrder", (noDir == SortingDirection.Ascending ? "ASC" : "DESC")));
                cmd.Parameters.Add(new SqlParameter("@PageSize", ((pageSize < 20) ? 20 : pageSize)));
                cmd.Parameters.Add(new SqlParameter("@PageNo", ((pageNo < 1) ? 1 : pageNo)));
                cmd.CommandTimeout = 120;
                dr = cmd.ExecuteReader();

                TInvoice inv = new TInvoice();

                while (dr.Read())
                {
                    //TKT
                    TTicketInfo tkt = new TTicketInfo();
                    tkt.Id = dr.GetGuid(26);
                    tkt.InvoiceId = dr.GetGuid(27);
                    tkt.Position = dr.GetString(28);
                    tkt.FirstName = dr.GetString(29);
                    tkt.MiddleName = dr.GetString(30);
                    tkt.LastName = dr.GetString(31);
                    tkt.TicketNumber = dr.GetString(32);
                    tkt.Charge = dr.GetDecimal(33);
                    tkt.SellingPrice = dr.GetDecimal(34);
                    tkt.OfficeName = dr.GetString(35);
                    tkt.AirlineName = dr.GetString(36);
                    tkt.TourCode = dr.GetString(37);
                    tkt.ARCCode = dr.GetString(38);
                    tkt.FareBasis = dr.GetString(39);
                    tkt.DateOfIssue = dr.GetString(40);
                    tkt.RecordLocator = dr.GetString(41);
                    tkt.Endorsement = dr.GetString(42);
                    tkt.FareCalculation = dr.GetString(43);
                    tkt.Fare = dr.GetString(44);
                    tkt.FlightInfo = dr.GetString(45);

                    if (tkt.InvoiceId != inv.Id)
                    {
                        //new inv
                        if (inv.Id != Guid.Empty)
                        {
                            invs.Add(inv);
                        }

                        //INVOICE
                        inv = new TInvoice();
                        inv.Id = dr.GetGuid(0);
                        inv.InvoiceNo = dr.GetString(1);
                        inv.RecordLocator = dr.GetString(2);
                        inv.AccountCode = dr.GetString(3);
                        inv.BookingSID = dr.GetString(4);
                        inv.BookingBranchCode = dr.GetString(5);
                        inv.TicketTime = dr.GetDateTime(6);
                        inv.AgentInfo = dr.GetString(7);
                        inv.OfficeInfo = dr.GetString(8);
                        inv.CreditCompany = dr.GetString(9);
                        inv.CreditNo = dr.GetString(10);
                        inv.Fare = dr.GetDecimal(11);
                        inv.Tax = dr.GetDecimal(12);
                        inv.Total = dr.GetDecimal(13);
                        inv.Amount = dr.GetDecimal(14);
                        inv.PDFPath = dr.GetString(15);
                        inv.Remark = dr.GetString(16);
                        inv.GateWay = dr.GetString(17);
                        inv.CreditAmount = dr.GetDecimal(18);
                        inv.Status = dr.GetInt32(20);
                        inv.Profit = dr.GetDecimal(21);
                        inv.Locked = dr.GetBoolean(22);
                        inv.LLocked = dr.GetBoolean(23);
                        inv.Changed = dr.GetBoolean(24);
                        inv.IsNonAirInvoice = dr.GetBoolean(25);
                    }

                    inv.TTicketInfoList.Add(tkt);
                }

                //last inv
                invs.Add(inv);
            }
            catch (Exception ex)
            {
                //log.Error("SearchInvoices", ex);
            }
            finally
            {
                if (dr != null && !dr.IsClosed)
                {
                    dr.Close();
                }

                if (connection != null)
                {
                    connection.Close();
                }
            }

            return invs;
        }

      


        /// <summary>
        ///  获取单页数据
        /// </summary>
        public static IList<TInvoice> GetInvPageData(string branchCode, string accountCode, string rl,
                                                  string invNoFrom, string invNoTo,
                                                  DateTime dateFrom, DateTime dateTo, bool changeOnly,
                                                  SortingDirection dateDir, SortingDirection noDir,
                                                  int pageSize, int pageNo, string IsNonAirInvoice, string TicketNumber)
        {
            return GetInvPageData(BuildCondition(branchCode, accountCode, rl, invNoFrom, invNoTo, dateFrom, dateTo, changeOnly, IsNonAirInvoice, TicketNumber),
                                    dateDir, noDir, pageSize, pageNo);
        }

          
    }
}

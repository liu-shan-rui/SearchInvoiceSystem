using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class CustomerInvoiceDA
    {

        public String GetTicketStatus(String TicketNumber)
        {

            DataSet ds = new DataSet();

            System.Data.SqlClient.SqlConnection Connection = new System.Data.SqlClient.SqlConnection();
            Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CustomerInvoiceDA.ConnectionString"].ConnectionString;

            System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand();
            Command.CommandText = "Sp_GetMissingTicket";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Connection = Connection;

            Command.CommandTimeout = 300000;

            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TicketNumber", TicketNumber));
            

            System.Data.SqlClient.SqlDataAdapter SqlAdp = new System.Data.SqlClient.SqlDataAdapter();
            SqlAdp.SelectCommand = Command;
            SqlAdp.Fill(ds);

            Connection.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                return "HAVEING";
            }
            else
            {
                return "MISSING";
            }

        }



        public DataSet SearchAgent(String username, String realName,
           String role, String accountCode, String telephone, String email)
        {
            DataSet ds = new DataSet();

            String ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CustomerInvoiceDA.ConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Sp_SearchAgent";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300000;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                 
                    cmd.Parameters.Add(new SqlParameter("@realName", realName));
                    cmd.Parameters.Add(new SqlParameter("@role", role));
                    cmd.Parameters.Add(new SqlParameter("@accountCode", accountCode));
                    cmd.Parameters.Add(new SqlParameter("@telephone", telephone));
                    cmd.Parameters.Add(new SqlParameter("@email", email));

                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        adapter.Fill(ds);
                    }
                }
            }
            return ds;
        }

        public DataSet Search(DateTime StartDate, DateTime EndDate, String AccountCode, String RecordLocator, String Branch)
        {
            DataSet ds = new DataSet();

            System.Data.SqlClient.SqlConnection Connection = new System.Data.SqlClient.SqlConnection();
            Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CustomerInvoiceDA.ConnectionString"].ConnectionString;

            System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand();
            Command.CommandText = "Sp_SearchTickets";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Connection = Connection;

            Command.CommandTimeout = 300000;

            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RecordLocator", RecordLocator));           
            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountCode", AccountCode));          
            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Branch", Branch));
            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InvoiceDateStart", StartDate));
            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InvoiceDateEnd", EndDate));

            System.Data.SqlClient.SqlDataAdapter SqlAdp = new System.Data.SqlClient.SqlDataAdapter();
            SqlAdp.SelectCommand = Command;
            SqlAdp.Fill(ds);

            return ds;
        }

        public DataSet SearchByAcct(String RecordLocator, String Branch, String TicketNumber, String PaxName,String AccountCode,
            String AgentCode, String InvoiceFrom, String InvoiceTo, DateTime StartDate, DateTime EndDate)
        {
            DataSet ds = new DataSet();

            System.Data.SqlClient.SqlConnection Connection = new System.Data.SqlClient.SqlConnection();
            Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CustomerInvoiceDA.ConnectionString"].ConnectionString;

            System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand();
            Command.CommandText = "Sp_SearchAcctTickets";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Connection = Connection;

            Command.CommandTimeout = 300000;

            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RecordLocator", RecordLocator));
            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Branch", Branch));
            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TicketNumber", TicketNumber));
            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaxName", PaxName));
            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountCode", AccountCode));
            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AgentCode", AgentCode));
            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InvoiceFrom", InvoiceFrom));
            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InvoiceTo", InvoiceTo));
            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InvoiceDateStart", StartDate));
            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InvoiceDateEnd", EndDate));

            System.Data.SqlClient.SqlDataAdapter SqlAdp = new System.Data.SqlClient.SqlDataAdapter();
            SqlAdp.SelectCommand = Command;
            SqlAdp.Fill(ds);

            return ds;
        }


        public DataSet GetInvoice(Guid invoiceID)
        {
            
            try
            {
                //invoice info
                StringBuilder strBuild = new StringBuilder();
                strBuild.Append(" select i.InvoiceNumber, i.BranchCode, i.AccountCode, i.AgentInfo, i.OfficeInfo,");
                strBuild.Append(" i.InvoiceDate, p.RecordLocator from dbo.Invoice i");
                strBuild.Append(" inner join dbo.PNRMaster p on i.PNRMasterID = p.ID where i.id = '");
                strBuild.Append(invoiceID).Append("';");

                //Passenger
                strBuild.Append(" select * from dbo.Passenger p inner join dbo.PNRMaster pnr on p.PNRMasterID = pnr.ID");
                strBuild.Append(" inner join dbo.Invoice i on i.PNRMasterID = pnr.ID where i.ID = '");
                strBuild.Append(invoiceID).Append("';");

                //cc number
                strBuild.Append(" select CardNumber, PaymentType, CardType from dbo.Ticket where invoiceid = '");
                strBuild.Append(invoiceID).Append("';");

                //Remark
                strBuild.Append(" select r.* from dbo.Remark r inner join dbo.PNRMaster p on r.PNRmasterID = p.ID");
                strBuild.Append(" inner join dbo.Invoice i on i.PNRMasterID = p.ID ");
                strBuild.Append(" where i.ID = '").Append(invoiceID).Append("' order by SortIndex;");

                //Routing 
                strBuild.Append(" select tr.* from dbo.TicketRounting tr inner join dbo.Ticket t on tr.TicketID = t.ID");
                strBuild.Append(" inner join dbo.Invoice i on i.ID = t.InvoiceID where i.id = '").Append(invoiceID).Append("'");
                strBuild.Append(" order by ticketid, startDate;");

                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CustomerInvoiceDA.ConnectionString"].ConnectionString;
                SqlDataAdapter sda = new SqlDataAdapter(strBuild.ToString(), connection);
                sda.SelectCommand.CommandTimeout = 120;
                DataSet ds = new DataSet();
                sda.Fill(ds);

                connection.Close();

                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetTicketInfo(Guid ticketID)
        {

            DataSet ds = new DataSet();

            System.Data.SqlClient.SqlConnection Connection = new System.Data.SqlClient.SqlConnection();
            Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CustomerInvoiceDA.ConnectionString"].ConnectionString;

            System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand();
            Command.CommandText = "Sp_GetImageTicket";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Connection = Connection;

            Command.CommandTimeout = 300000;

            Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TicketID", ticketID));


            System.Data.SqlClient.SqlDataAdapter SqlAdp = new System.Data.SqlClient.SqlDataAdapter();
            SqlAdp.SelectCommand = Command;
            SqlAdp.Fill(ds);
            return ds;

        }
    }
}

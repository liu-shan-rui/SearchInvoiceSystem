using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

using System.Data;

namespace DataAccess
{
    public class WLTicketDA
    {
        private static String connectionString = ConfigurationManager.ConnectionStrings["CustomerInvoiceDA.ConnectionString"].ConnectionString;

        public void InsertWLTicket(DataSet dataSet)
        {

            //dataSet.Tables[0].Rows[0]["RL"].ToString()
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                DataTable newTable = new DataTable();
                DataTable table = dataSet.Tables[0];

                newTable.Columns.Add("ID", typeof(Guid));
                newTable.Columns.Add("ReacordLocator", typeof(String));
                newTable.Columns.Add("InvoiceNumber", typeof(String));
                newTable.Columns.Add("AirLineNumber", typeof(String));
                newTable.Columns.Add("TicketNumber", typeof(String));

                int lines = table.Rows.Count;
                for (int i = 0; i < lines; i++)
                {
                    DataRow row = newTable.NewRow();

                    row["ID"] = Guid.NewGuid();
                    row["ReacordLocator"] = table.Rows[i]["R/L"].ToString().Trim();
                    row["InvoiceNumber"] = table.Rows[i]["INV#"].ToString().PadLeft(6, '0').Trim();
                    row["AirLineNumber"] = table.Rows[i]["A/L"].ToString().Trim();
                    row["TicketNumber"] = table.Rows[i]["Ticket#"].ToString().PadLeft(10, '0').Trim();
                    newTable.Rows.Add(row);
                }
                conn.Open();

                using (SqlBulkCopy copy = new SqlBulkCopy(connectionString))
                {
                    //copy.DestinationTableName = "WLTicket";

                    copy.BatchSize = lines;
                    copy.DestinationTableName = "WLTicket";

                    copy.ColumnMappings.Add("ID", "ID");
                    copy.ColumnMappings.Add("ReacordLocator", "ReacordLocator");
                    copy.ColumnMappings.Add("InvoiceNumber", "InvoiceNumber");
                    copy.ColumnMappings.Add("AirLineNumber", "AirLineNumber");
                    copy.ColumnMappings.Add("TicketNumber", "TicketNumber");

                    copy.WriteToServer(newTable);
                }
            }
            
        }

        public void ClearWLTicket()
        {
            String sql = "delete from WLTicket";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataSet ReturnCompareTicket()
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Sp_CompareTicket";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300000;
                  
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        adapter.Fill(ds);
                    }
                }
            }
            return ds;
        }
    }
}

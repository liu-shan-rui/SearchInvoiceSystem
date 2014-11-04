using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace DataAccess
{
    public class Excel
    {
        public DataSet ReaderExcel(String SheetName, String FileName)
        {
            // FileName = @"E:\lsrlsr\TTTProjects\UF-SAP\Website\Mapping\20131114135205.xls";
            String ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + FileName + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1; '";
            OleDbConnection Connection = new OleDbConnection(ConnectionString);
            Connection.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter OleDbDataAdapter = new OleDbDataAdapter("select * from [" + SheetName + "$]", Connection);
            OleDbDataAdapter.Fill(ds);
            return ds;
        }

    }
}

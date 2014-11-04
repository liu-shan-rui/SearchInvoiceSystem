using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CustomerInvoiceCollectionWS
{
    /// <summary>
    /// Summary description for CustomerInvoiceCollectionWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CustomerInvoiceCollectionWS : System.Web.Services.WebService
    {

        [WebMethod]
        public void CollectionInvoice(String Content)
        {
            DataAccess.CustomerInvoiceEntities Context = new DataAccess.CustomerInvoiceEntities();
            DataAccess.ReadingLog ReadingLog = CreateReadingLog(FileInfo);
            Context.AddToReadingLog(ReadingLog);
            // Context.SaveChanges();

            DataAccess.Invoice Invoice = CreateInvoice(ReadingLog.Content);

            if (String.IsNullOrEmpty(Invoice.InvoiceNumber) == false)
            {

                Invoice.ReadingLogID = ReadingLog.ID;
                Context.AddToInvoice(Invoice);

                List<DataAccess.ReadingLogLine> ReadingLogLines = CreateReadingLogLines(FileInfo);

                foreach (DataAccess.ReadingLogLine ReadingLogLine in ReadingLogLines)
                {
                    ReadingLogLine.ReadingLogID = ReadingLog.ID;
                    Context.AddToReadingLogLine(ReadingLogLine);
                }

                List<DataAccess.InvoicePassenger> InvoicePassengers = CreateInvoicePassengers(ReadingLog.Content);
                foreach (DataAccess.InvoicePassenger InvoicePassenger in InvoicePassengers)
                {
                    InvoicePassenger.InvoiceID = Invoice.ID;
                    InvoicePassenger.ReadingLogID = ReadingLog.ID;
                    Context.AddToInvoicePassenger(InvoicePassenger);
                }
            }

            Context.SaveChanges();
        }
    }
}

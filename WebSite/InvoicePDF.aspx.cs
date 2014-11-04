using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Utilities;
using System.Configuration;
using DataAccess;
using System.Data;
using Business.Entity;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Globalization;
using System.Text;

namespace ERP
{
    public partial class InvoicePDF : System.Web.UI.Page
    {
        
        private Guid INVID
        {
            get
            {
                if (Request["INVID"] != null)
                {
                    Guid invid = new Guid(Request["INVID"]);
                    return invid;
                }
                return Guid.Empty;
            }
        }       

        protected void Page_Load(object sender, EventArgs e)
        {
            //form1.Target = "_blank";

            if (!IsPostBack)
            {
                if (Request["INVID"] != null)
                {
                    Guid invid = new Guid(Request["INVID"]);
                    string pdfPath = Server.MapPath("PDFFile/");
                    CustomerInvoiceDA ciDA = new CustomerInvoiceDA();
                    DataSet dsInvoice = ciDA.GetInvoice(invid);
                    InvoiceInfo invoiceInfo = GetInvoiceInfo(dsInvoice);
                    if (invoiceInfo != null)
                    {
                        string invoicePDFPath = GetPDF(invoiceInfo, pdfPath);

                        hfPDFUrl.Value = invoicePDFPath;
                    }
                    else
                    {
                        Response.Write("PDF CREATE ERROR!");
                    }
                }
            }

            hlkShow.NavigateUrl = "PdfView.aspx?pdfurl=" + hfPDFUrl.Value;
            hlkShow.Target = "_blank";
        }

        private InvoiceInfo GetInvoiceInfo(DataSet ds)
        {
            InvoiceInfo invoiceInfo = null;
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    invoiceInfo = new InvoiceInfo();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        invoiceInfo.AccountCode = dr["AccountCode"].ToString();
                        invoiceInfo.BranchOffice = dr["BranchCode"].ToString();
                        invoiceInfo.InvoiceNumber = dr["InvoiceNumber"].ToString();                        
                        invoiceInfo.RecordLocator = dr["RecordLocator"].ToString();
                        invoiceInfo.InvoiceDate = Convert.ToDateTime(dr["InvoiceDate"]);
                        invoiceInfo.AgentInfo = dr["AgentInfo"].ToString();
                        invoiceInfo.OfficeInfo = dr["OfficeInfo"].ToString();
                    }

                    List<Passenger> passengers = new List<Passenger>();
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        Passenger p = new Passenger();
                        p.FirstName = dr["FirstName"].ToString();
                        p.LastName = dr["LastName"].ToString();
                        passengers.Add(p);
                    }
                    invoiceInfo.Passengers = passengers;

                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        invoiceInfo.CreditcardNumber = dr["CardNumber"].ToString();
                        invoiceInfo.PaymentType = dr["PaymentType"].ToString();
                        invoiceInfo.CreditcardType = dr["CardType"].ToString();
                        break;
                    }

                    invoiceInfo.Remarks = new List<string>();
                    foreach (DataRow dr in ds.Tables[3].Rows)
                    {
                        string rm = dr["info"].ToString();
                        if(rm.IndexOf("IR-AFF/") == -1 && rm.IndexOf("IR-APR/") == -1)
                            invoiceInfo.Remarks.Add(rm);
                    }

                    //invoiceInfo.TicketInfo = new List<TicketInfo>();
                    List<TicketRouting> ticketRoutings = new List<TicketRouting>();
                    foreach (DataRow dr in ds.Tables[4].Rows)
                    {
                        TicketRouting tr = new TicketRouting();
                        tr.Airline = dr["AirlineCode"].ToString();
                        tr.Departure = dr["StartPoint"].ToString();
                        tr.Destination = dr["EndPoint"].ToString();
                        tr.DepartureDatetime = Convert.ToDateTime(dr["StartDate"]);
                        tr.ArrivalDatetime = Convert.ToDateTime(dr["EndDate"]);
                        tr.BookingClass = dr["BookingClass"].ToString();
                        tr.FlightNumber = dr["FlightNumber"].ToString();
                        tr.StopNumber = dr["StopNumber"].ToString();
                        tr.TicketStatus = dr["TicketStatus"].ToString();
                        tr.SegmentStatus = dr["SegmentStatus"].ToString();
                        tr.FareBasis = dr["FareBasis"].ToString();
                        ticketRoutings.Add(tr);
                    }
                    invoiceInfo.TicketRoutings = ticketRoutings;

                    hfInvoiceNumber.Value = invoiceInfo.InvoiceNumber;
                    if (invoiceInfo.Passengers != null && invoiceInfo.Passengers.Count > 0)
                        hfPaxName.Value = invoiceInfo.Passengers[0].LastName + " " + invoiceInfo.Passengers[0].FirstName;

                    hfInvoiceDate.Value = invoiceInfo.InvoiceDate.ToString("MM/dd/yyyy");
                }
            }
            catch
            {

            }

            return invoiceInfo;
        }

        private string GetPDF(InvoiceInfo invoiceInfo, string pdfPath)
        {
            string invoicePDFPath = string.Empty;
            try
            {
                string pdfName = invoiceInfo.RecordLocator + "_" + invoiceInfo.InvoiceDate.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo) + ".pdf";
                if (File.Exists(pdfName))
                {
                    return pdfName;
                }

                Font font = new Font();
                font.Size = 10;

                iTextSharp.text.Image top1 = iTextSharp.text.Image.GetInstance(pdfPath + "GTT-logo-head.gif");
                top1.ScalePercent(80);

                #region Code
                iTextSharp.text.Table tableCode = new iTextSharp.text.Table(3, 4);
                tableCode.AutoFillEmptyCells = true;
                tableCode.Alignment = Element.ALIGN_RIGHT;
                tableCode.AbsWidth = "535";
                tableCode.Widths = new float[] { 65, 8, 20 };
                tableCode.Border = Rectangle.NO_BORDER;
                tableCode.DefaultCellBorder = Rectangle.NO_BORDER;

                Cell cell1 = new Cell(top1);
                cell1.HorizontalAlignment = Element.ALIGN_MIDDLE;
                cell1.Rowspan = 4;
                tableCode.AddCell(cell1);

                tableCode.AddCell(new Paragraph(invoiceInfo.InvoiceNumber, font));
                tableCode.AddCell(new Paragraph("ITINERARY INVOICE", font));
                tableCode.AddCell(new Paragraph("  ", font));
                tableCode.AddCell(new Paragraph("PAGE NO. 1", font));
                tableCode.AddCell(new Paragraph("  ", font));
                tableCode.AddCell(new Paragraph("PNR: 1P-" + invoiceInfo.RecordLocator, font));
                tableCode.AddCell(new Paragraph("  ", font));
                tableCode.AddCell(new Paragraph("BK-" + invoiceInfo.AccountCode + "/" + invoiceInfo.BranchOffice, font));
                #endregion

                #region Info
                iTextSharp.text.Table tableInfo = new iTextSharp.text.Table(3, 1);
                tableInfo.AutoFillEmptyCells = true;
                tableInfo.AbsWidth = "450";
                tableInfo.Widths = new float[] { 40, 10, 40 };
                tableInfo.Border = Rectangle.NO_BORDER;
                tableInfo.DefaultCellBorder = Rectangle.NO_BORDER;

                tableInfo.AddCell(new Paragraph(invoiceInfo.AgentInfo, font));
                tableInfo.AddCell(new Paragraph("  ", font));
                tableInfo.AddCell(new Paragraph(invoiceInfo.OfficeInfo, font));
                #endregion

                #region PassengerName
                iTextSharp.text.Table tableTicketInfo = new iTextSharp.text.Table(2);
                tableTicketInfo.AutoFillEmptyCells = true;
                tableTicketInfo.AbsWidth = "450";
                tableTicketInfo.Widths = new float[] { 60, 60 };
                tableTicketInfo.Border = Rectangle.NO_BORDER;
                tableTicketInfo.DefaultCellBorder = Rectangle.NO_BORDER;

                int index = 1;
                foreach (Passenger p in invoiceInfo.Passengers)
                {
                    tableTicketInfo.AddCell(new Paragraph(index + "." + p.LastName + "/" + p.FirstName, font));
                    index++;
                }
                #endregion

                #region Routing
                iTextSharp.text.Table tableRouting = new iTextSharp.text.Table(11);
                tableRouting.AutoFillEmptyCells = true;
                tableRouting.AbsWidth = "535";
                tableRouting.Widths = new float[] { 4, 6, 11, 6, 40, 10, 40, 11, 5, 11, 6 };
                tableRouting.Border = Rectangle.NO_BORDER;
                tableRouting.DefaultCellBorder = Rectangle.NO_BORDER;

                Cell cell = new Cell(new Paragraph("  ", font));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Colspan = 3;
                tableRouting.AddCell(cell, 0, 0);

                cell = new Cell(new Paragraph("  ", font));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                tableRouting.AddCell(cell, 0, 4);
                cell = new Cell(new Paragraph(invoiceInfo.AccountCode, font));
                cell.HorizontalAlignment = Element.ALIGN_MIDDLE;
                tableRouting.AddCell(cell, 0, 6);

                cell = new Cell(new Paragraph(invoiceInfo.InvoiceDate.ToString("ddMMMyy", DateTimeFormatInfo.InvariantInfo).ToUpper(), font));
                cell.HorizontalAlignment = Element.ALIGN_MIDDLE;
                cell.Colspan = 2;
                tableRouting.AddCell(cell, 0, 9);

                string[] depDateTime;
                string[] arrDateTime;
                foreach (TicketRouting routing in invoiceInfo.InvoiceRoutingMaps)
                {
                    depDateTime = routing.DepartureDatetime.ToString("ddd,ddMMM,hmmt", DateTimeFormatInfo.InvariantInfo).Split(",".ToCharArray());
                    arrDateTime = routing.ArrivalDatetime.ToString("ddd,ddMMM,hmmt", DateTimeFormatInfo.InvariantInfo).Split(",".ToCharArray());

                    cell = new Cell(new Paragraph("A", font));
                    tableRouting.AddCell(cell);

                    cell = new Cell(new Paragraph(depDateTime[0].Substring(0, 2).ToUpper(), font));
                    tableRouting.AddCell(cell);

                    cell = new Cell(new Paragraph(depDateTime[1].ToUpper(), font));
                    tableRouting.AddCell(cell);

                    cell = new Cell(new Paragraph("LV", font));
                    tableRouting.AddCell(cell);

                    cell = new Cell(new Paragraph(routing.Departure, font));
                    tableRouting.AddCell(cell);

                    cell = new Cell(new Paragraph(depDateTime[2], font));
                    tableRouting.AddCell(cell);

                    cell = new Cell(new Paragraph(routing.Airline, font));
                    tableRouting.AddCell(cell);

                    cell = new Cell(new Paragraph(routing.FlightNumber + routing.BookingClass, font));
                    tableRouting.AddCell(cell);

                    cell = new Cell(new Paragraph("OK", font));
                    tableRouting.AddCell(cell);

                    cell = new Cell(new Paragraph("  ", font));
                    cell.Colspan = 2;
                    tableRouting.AddCell(cell);

                    cell = new Cell(new Paragraph("  ", font));
                    cell.Colspan = 2;
                    tableRouting.AddCell(cell);

                    cell = new Cell(new Paragraph(arrDateTime[1].ToUpper(), font));
                    tableRouting.AddCell(cell);

                    cell = new Cell(new Paragraph("AR", font));
                    tableRouting.AddCell(cell);

                    cell = new Cell(new Paragraph(routing.Destination, font));
                    tableRouting.AddCell(cell);

                    cell = new Cell(new Paragraph(arrDateTime[2], font));
                    tableRouting.AddCell(cell);

                    cell = new Cell(new Paragraph("  ", font));
                    cell.Colspan = 3;
                    tableRouting.AddCell(cell);

                    cell = new Cell(new Paragraph(routing.StopNumber + "STOP", font));
                    tableRouting.AddCell(cell);

                    cell = new Cell(new Paragraph(string.Empty, font));
                    tableRouting.AddCell(cell);
                }

                #endregion

                #region CreditNo
                iTextSharp.text.Table tableCreditNo = new iTextSharp.text.Table(1);
                tableCreditNo.AutoFillEmptyCells = true;
                tableCreditNo.AbsWidth = "535";
                tableCreditNo.Border = Rectangle.NO_BORDER;
                tableCreditNo.DefaultCellBorder = Rectangle.NO_BORDER;
                if (string.IsNullOrEmpty(invoiceInfo.PaymentType))
                {
                    tableCreditNo.AddCell(new Paragraph("NO FORM OF PAYMENT", font));
                }
                else if (invoiceInfo.PaymentType.ToUpper() == "CK")
                {
                    tableCreditNo.AddCell(new Paragraph("CHECK PAYMENT", font));
                }
                else
                {
                    if (!string.IsNullOrEmpty(invoiceInfo.CreditcardNumber))
                    {
                        string[] creditNo = invoiceInfo.CreditcardNumber.Insert(4, " ").Insert(9, " ").Insert(14, " ").Split(" ".ToCharArray());
                        tableCreditNo.AddCell(new Paragraph("THIS AMOUNT WILL BE CHARGED TO CREDIT CARD: " + invoiceInfo.CreditcardType + " XXXX XXXX XXXX " + creditNo[3], font));
                    }
                }
                #endregion

                #region Remark
                iTextSharp.text.Table tableRemark = new iTextSharp.text.Table(1);
                tableRemark.AutoFillEmptyCells = true;
                tableRemark.AbsWidth = "535";
                tableRemark.Border = Rectangle.NO_BORDER;
                tableRemark.DefaultCellBorder = Rectangle.NO_BORDER;

                foreach (String r in invoiceInfo.Remarks)
                {
                    String editR = r.Substring(r.IndexOf(".") + 1);
                    tableRemark.AddCell(new Paragraph(editR, font));
                }
                #endregion

                #region Add Document
                Document document = new Document();

                PdfWriter.GetInstance(document, new FileStream(pdfPath + pdfName, FileMode.Create));

                document.Open();
                document.Add(tableCode);
                document.Add(new Paragraph("  ", font));
                document.Add(tableInfo);
                document.Add(new Paragraph("  ", font));
                document.Add(tableTicketInfo);
                document.Add(new Paragraph("  ", font));
                document.Add(tableRouting);
                document.Add(new Paragraph("  ", font));
                document.Add(tableCreditNo);
                document.Add(new Paragraph("  ", font));
                document.Add(tableRemark);
                document.Close();
                #endregion

                return "PDFFile/" + pdfName;
                //invoice.PDFPath = "PDFFile/" + pdfName;
            }
            catch (Exception ex)
            {
                //log.Error("SavePDF", ex);
            }

            return invoicePDFPath;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
                string smtpUserName = ConfigurationManager.AppSettings["SmtpUserName"];
                string smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];

                MailNotifier mailNotifier = new MailNotifier(smtpServer, smtpUserName, smtpPassword);

                mailNotifier.Subject = "GTT INVOICE" + hfInvoiceNumber.Value + " FOR " + hfPaxName.Value.ToUpper() + " " + hfInvoiceDate.Value;
                mailNotifier.From = "noreply@gttglobal.com";
                mailNotifier.To = txtMailAddress.Text;
                mailNotifier.AttachmentsPath = Server.MapPath(hfPDFUrl.Value);
                mailNotifier.Body = GetMailBody();

                mailNotifier.Notice();
                lblMsg.Visible = true;
                lblMsg.Text = "Send mail success.";
            }
            catch(Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Send mail failed.";
            }
        }

        private String GetMailBody()
        {
            StringBuilder sbBody = new StringBuilder();
            sbBody.Append("DEAR TRAVEL PROFESSIONAL:\r\n\r\n");
            sbBody.Append("We ARE PLEASED TO DELIVER YOUR INVOICE ").Append(hfInvoiceNumber.Value).Append(" FOR ").Append(hfPaxName.Value.ToUpper());
            sbBody.Append(" THROUGH OUR GTT INVOICE SYSTEM.\r\n\r\n");
            sbBody.Append("PLEASE CHECK IMMEDIATELY THE NAMES AND FLIGHTS INFO UPON RECEIPT OF THE TICKET.\r\n");
            sbBody.Append("FAILURE TO RECONFIRM MAY RESULT IN CANCELLATION.\r\n");
            sbBody.Append("A 35.00 GTT SERVICE FEE PLUS AIRLINE CHARGES WILL BE BILLED TO YOUR ACCOUNT ");
            sbBody.Append("FOR ANY APPLICABLE ANCELLATION / VOID/ EXCHANGE OR REFUND TICKETS.\r\n");
            sbBody.Append("IT IS YOUR RESPONSIBILITY TO MEET THE ENTRY REQUIREMENTS FOR ");
            sbBody.Append("THE COUNTRIES YOU ARE TRAVELING TO AND CONNECTING THROUGH.\r\n");
            sbBody.Append("PLEASE BE SURE YOU PASSPORT IS VALID FOR AT LEAST SIX MONTHS ");
            sbBody.Append("FROM THE DATE OF ARRIVAL AT YOUR DESTINATION.\r\n");

            return sbBody.ToString();
        }

        //protected void btnShow_Click(object sender, EventArgs e)
        //{

        //    String url = "<javascript>window.open('PdfView.aspx?pdfurl=" + hfPDFUrl.Value + "')</javascript>";
        //    Response.Redirect(url);
        //}
    }
}
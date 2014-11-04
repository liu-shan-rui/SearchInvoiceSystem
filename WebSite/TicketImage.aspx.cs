using System;
using System.Drawing;
using System.Globalization;
using System.Web.UI;

using System.Data;
using System.Collections;
using System.Configuration;
using Business.Entity;

using Business.Utilities;
using System.Text;



namespace ERP
{
    public partial class TicketImage : Page
    {

       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["TKTID"] != null)
                {

                    Guid tktID = new Guid(Request["TKTID"].ToString());

                    Ticket ticket = GetTicket(tktID);
                   
                    if (ticket != null)
                    {
                        string imagePath = Server.MapPath("Images/");
                        string newImgPath = Server.MapPath("TktImages/");
                        string imageName = ticket.RecordLocator + "_" + ticket.TicketNumber + ".jpg";

                        Bitmap map = new Bitmap(imagePath + "Ticket.png");                  
                        if (ticket.Status.ToUpper().Equals("VOID"))
                            map = new Bitmap(imagePath + "TicketVoid.png");

                        PutText(map, ticket);                        

                        map.RotateFlip(RotateFlipType.Rotate90FlipXY);
                        map.Save(newImgPath + imageName);
                        ticketImage.ImageUrl = "TktImages/" + imageName;

                        attachmentsPath.Value = newImgPath + imageName;
                    }
                    else
                    {
                        Response.Write("IMAGE CREATE ERROR!");
                    }
                }
            }
        }

        /// <summary>
        /// 画图
        /// </summary>
        /// <param name="img">背景图片</param>
        private void PutText(Image img, Ticket ticket)
        {
            Graphics graph = Graphics.FromImage(img);

            PutText(graph, "DOCUMENT IS HEAT SENSITIVE", 14, FontStyle.Bold, Color.Black, 45, 25, StringFormatFlags.NoWrap, string.Empty);
            PutText(graph, "Do not expose to prolonged periods of excessive heat or light", 10, FontStyle.Regular, Color.Black, 20, 40, StringFormatFlags.NoWrap, string.Empty);
            PutText(graph, "PASSENGER TICKET AND BAGGAGE CHECK", 11, FontStyle.Bold, Color.Black, 295, 95, StringFormatFlags.DirectionVertical, string.Empty);
            PutText(graph, ticket.OfficeName, 11, FontStyle.Bold, Color.Black, 295, 558, StringFormatFlags.DirectionVertical, string.Empty);
            PutText(graph, "ETKT", 11, FontStyle.Bold, Color.Black, 277, 190, StringFormatFlags.DirectionVertical, string.Empty);
            PutText(graph, "TOUR CODE", 11, FontStyle.Bold, Color.Black, 277, 388, StringFormatFlags.DirectionVertical, string.Empty);
            PutText(graph, "ARC CODE", 11, FontStyle.Bold, Color.Black, 277, 578, StringFormatFlags.DirectionVertical, string.Empty);
            PutText(graph, ticket.AirlineName, 11, FontStyle.Bold, Color.Black, 262, 95, StringFormatFlags.DirectionVertical, string.Empty);
            PutText(graph, ticket.TourCode, 11, FontStyle.Bold, Color.Black, 262, 395, StringFormatFlags.DirectionVertical, string.Empty);
            PutText(graph, ticket.ARCCode, 11, FontStyle.Bold, Color.Black, 262, 585, StringFormatFlags.DirectionVertical, string.Empty);
            PutText(graph, ticket.PassengerName, 11, FontStyle.Bold, Color.Black, 242, 110, StringFormatFlags.DirectionVertical, string.Empty);

            int x;
            int y;
            if (!string.IsNullOrEmpty(ticket.FlightInfo))
            {
                string[] flightInfos = ticket.FlightInfo.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                x = 227;
                foreach (string flightInfo in flightInfos)
                {
                    PutText(graph, flightInfo, 11, FontStyle.Bold, Color.Black, x, 528, StringFormatFlags.DirectionVertical, string.Empty);
                    x = x - 13;
                }
            }

            PutText(graph, "FARE BASIS", 11, FontStyle.Bold, Color.Black, 242, 315, StringFormatFlags.DirectionVertical, string.Empty);
            PutText(graph, "DATE OF ISSUE", 11, FontStyle.Bold, Color.Black, 242, 413, StringFormatFlags.DirectionVertical, string.Empty);
            PutText(graph, ticket.PassengerName, 11, FontStyle.Bold, Color.Black, 242, 550, StringFormatFlags.DirectionVertical, string.Empty);
            PutText(graph, ticket.FareBasis, 11, FontStyle.Bold, Color.Black, 227, 326, StringFormatFlags.DirectionVertical, string.Empty);
            PutText(graph, ticket.DateOfIssue, 11, FontStyle.Bold, Color.Black, 227, 438, StringFormatFlags.DirectionVertical, string.Empty);
            PutText(graph, "***NOT VALID FOR ***", 11, FontStyle.Bold, Color.Black, 205, 100, StringFormatFlags.DirectionVertical, string.Empty);
            PutText(graph, "***TRANSPORTATION***", 11, FontStyle.Bold, Color.Black, 192, 95, StringFormatFlags.DirectionVertical, string.Empty);
            PutText(graph, "PNR CARRIER CODE", 11, FontStyle.Bold, Color.Black, 192, 393, StringFormatFlags.DirectionVertical, string.Empty);

            if (!string.IsNullOrEmpty(ticket.RecordLocator))
            {
                PutText(graph, ticket.RecordLocator + "/1P", 11, FontStyle.Bold, Color.Black, 175, 430, StringFormatFlags.DirectionVertical, string.Empty);
            }

            if (!string.IsNullOrEmpty(ticket.Endorsement))
            {
                if (ticket.Endorsement.Length >= 87)
                {
                    PutText(graph, ticket.Endorsement.Substring(0, 87), 11, FontStyle.Bold, Color.Black, 122, 95, StringFormatFlags.DirectionVertical, string.Empty);
                    PutText(graph, ticket.Endorsement.Substring(87, ticket.Endorsement.Length - 87), 11, FontStyle.Bold, Color.Black, 112, 95, StringFormatFlags.DirectionVertical, string.Empty);
                }
                else
                {
                    PutText(graph, ticket.Endorsement, 11, FontStyle.Bold, Color.Black, 122, 95, StringFormatFlags.DirectionVertical, string.Empty);
                }
            }

            if (!string.IsNullOrEmpty(ticket.FareCalculation))
            {
                if (ticket.FareCalculation.Length >= 87)
                {
                    PutText(graph, ticket.FareCalculation.Substring(0, 87), 11, FontStyle.Bold, Color.Black, 97, 95, StringFormatFlags.DirectionVertical, string.Empty);
                    PutText(graph, ticket.FareCalculation.Substring(87, ticket.FareCalculation.Length - 87), 11, FontStyle.Bold, Color.Black, 87, 95, StringFormatFlags.DirectionVertical, string.Empty);
                }
                else
                {
                    PutText(graph, ticket.FareCalculation, 11, FontStyle.Bold, Color.Black, 97, 95, StringFormatFlags.DirectionVertical, string.Empty);
                }
            }

            if (!string.IsNullOrEmpty(ticket.Fare))
            {
                string[] fares = ticket.Fare.Replace("\r\n", ";").Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                PutText(graph, "FARE", 11, FontStyle.Bold, Color.Black, 72, 95, StringFormatFlags.DirectionVertical, string.Empty);

                x = 62;
                y = 95;
                for (int i = 0; i < fares.Length; i++)
                {
                    foreach (string fare in fares[i].Split(",".ToCharArray(), StringSplitOptions.None))
                    {
                        if (y == 175)
                        {
                            PutText(graph, fare.PadLeft(8, ' '), 11, FontStyle.Regular, Color.Black, x, y, StringFormatFlags.DirectionVertical, "Courier New");
                        }
                        else
                        {
                            PutText(graph, fare, 11, FontStyle.Bold, Color.Black, x, y, StringFormatFlags.DirectionVertical, string.Empty);
                        }

                        y = y + 40;
                    }

                    y = 95;
                    x = x - 12;
                }
            }

            PutText(graph, "DOCUMENT NUMBER", 11, FontStyle.Bold, Color.Black, 24, 290, StringFormatFlags.DirectionVertical, string.Empty);
            PutText(graph, "NOT VALID FOR TRAVEL", 11, FontStyle.Bold, Color.Black, 24, 528, StringFormatFlags.DirectionVertical, string.Empty);

            PutText(graph, ticket.TicketNumber, 11, FontStyle.Regular, Color.Black, 12, 290, StringFormatFlags.DirectionVertical, string.Empty);
            PutText(graph, ticket.TicketNumber, 11, FontStyle.Regular, Color.Black, 12, 528, StringFormatFlags.DirectionVertical, string.Empty);
        }

        /// <summary>
        /// 画图
        /// </summary>
        /// <param name="graph">背景图片</param>
        /// <param name="text">要写的文字</param>
        /// <param name="fontSize">字体大小</param>
        /// <param name="style">字体样式</param>
        /// <param name="color">颜色</param>
        /// <param name="x">X坐标</param>
        /// <param name="y">Y坐标</param>
        /// <param name="flags">布局</param>
        private void PutText(Graphics graph, string text, int fontSize, FontStyle style, Color color, int x, int y, StringFormatFlags flags, string familyName)
        {
            if (string.IsNullOrEmpty(familyName))
            {
                graph.DrawString(text, SetFont(fontSize, style, string.Empty), SetBrush(color), x, y, SetFormat(flags));
            }
            else
            {
                graph.DrawString(text, SetFont(fontSize, style, familyName), SetBrush(color), x, y, SetFormat(flags));
            }
        }

        /// <summary>
        /// 设置字体
        /// </summary>
        /// <param name="size">字体大小</param>
        /// <param name="style">字体样式</param>
        /// <returns>Font</returns>
        private Font SetFont(int size, FontStyle style, string familyName)
        {
            if (string.IsNullOrEmpty(familyName))
            {
                return new Font(FontFamily.GenericSansSerif, size, style, GraphicsUnit.Pixel);
            }
            else
            {
                return new Font(familyName, size, style, GraphicsUnit.Pixel);
            }
        }

        /// <summary>
        /// 设置颜色
        /// </summary>
        /// <param name="color">颜色</param>
        /// <returns>SolidBrush</returns>
        private SolidBrush SetBrush(Color color)
        {
            return new SolidBrush(color);
        }

        /// <summary>
        /// 设置布局
        /// </summary>
        /// <param name="flags">布局</param>
        /// <returns>StringFormat</returns>
        private StringFormat SetFormat(StringFormatFlags flags)
        {
            return new StringFormat(flags);
        }

        private Ticket GetTicket(Guid ticketID)
        {
            Ticket ticket = new Ticket();
            DataAccess.CustomerInvoiceDA DA = new DataAccess.CustomerInvoiceDA();
            DataSet dataSet = DA.GetTicketInfo(ticketID);
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {

                    if (dataSet.Tables[0].Columns.Contains("TicketNumber") && !Convert.IsDBNull(row["TicketNumber"]))
                        ticket.TicketNumber = (string)row["TicketNumber"];

                    if (dataSet.Tables[0].Columns.Contains("DateOfIssue") && !Convert.IsDBNull(row["DateOfIssue"]))
                    {
                        DateTime dateOfIssue =  Convert.ToDateTime(row["DateOfIssue"]);
                       
                        ticket.DateOfIssue = dateOfIssue.ToString("ddMMMyy", DateTimeFormatInfo.InvariantInfo).ToUpper();
                    }
                    if (dataSet.Tables[0].Columns.Contains("ARCCode") && !Convert.IsDBNull(row["ARCCode"]))
                        ticket.ARCCode = (string)(row["ARCCode"]);

                    if (dataSet.Tables[0].Columns.Contains("Endorsement") && !Convert.IsDBNull(row["Endorsement"]))
                        ticket.Endorsement = (string)(row["Endorsement"]);

                    if (dataSet.Tables[0].Columns.Contains("FareCalculation") && !Convert.IsDBNull(row["FareCalculation"]))
                        ticket.FareCalculation = (string)(row["FareCalculation"]);

                    if (dataSet.Tables[0].Columns.Contains("TourCode") && !Convert.IsDBNull(row["TourCode"]))
                        ticket.TourCode = (string)(row["TourCode"]);

                    if (dataSet.Tables[0].Columns.Contains("RecordLocator") && !Convert.IsDBNull(row["RecordLocator"]))
                        ticket.RecordLocator = (string)(row["RecordLocator"]);

                    if (dataSet.Tables[0].Columns.Contains("FirstName") && !Convert.IsDBNull(row["FirstName"]))
                        ticket.FirstName = (string)(row["FirstName"]);

                    if (dataSet.Tables[0].Columns.Contains("LastName") && !Convert.IsDBNull(row["LastName"]))
                        ticket.LastName = (string)(row["LastName"]);

                    if (dataSet.Tables[0].Columns.Contains("AirlineName") && !Convert.IsDBNull(row["AirlineName"]))
                        ticket.AirlineName = (string)(row["AirlineName"]);

                    if (dataSet.Tables[0].Columns.Contains("Status") && !Convert.IsDBNull(row["Status"]))
                        ticket.Status = (string)(row["Status"]);
                }

                passengerName.Value = ticket.PassengerName;
                ArrayList faresInfo = new ArrayList();

                for(int i =0;i < dataSet.Tables[1].Rows.Count ; i++) 
                {
                    DataRow row = dataSet.Tables[1].Rows[i];
                    ArrayList fareItem = new ArrayList();
                    if (dataSet.Tables[1].Columns.Contains("Name") && !Convert.IsDBNull(row["Name"]))
                        fareItem.Add(((string)(row["Name"])).ToUpper());

                    if (dataSet.Tables[1].Columns.Contains("Type") && !Convert.IsDBNull(row["Type"]))
                       fareItem.Add(((string)row["Type"]).ToUpper());

                    

                    if (dataSet.Tables[1].Columns.Contains("Amount") && !Convert.IsDBNull(row["Amount"]))
                         fareItem.Add(Convert.ToString((Decimal)(row["Amount"])));
                    faresInfo.Add(String.Join(",", fareItem.ToArray()));
                    

                }
                if (faresInfo.Count>0)
                    ticket.Fare = String.Join(";", faresInfo.ToArray());


                ArrayList segments = new ArrayList();
                ArrayList fareBasisList =  new ArrayList();

                for(int i =0;i < dataSet.Tables[2].Rows.Count ; i++) 
                {
                    DataRow row = dataSet.Tables[2].Rows[i];
                    string segment = String.Empty;
                    

                    if (dataSet.Tables[2].Columns.Contains("DeptAirport") && !Convert.IsDBNull(row["DeptAirport"]))
                        segment = (string)row["DeptAirport"];
                    if (dataSet.Tables[2].Columns.Contains("DestAirport") && !Convert.IsDBNull(row["DestAirport"]))
                        segment += (string)row["DestAirport"];

                    if (dataSet.Tables[2].Columns.Contains("AirlineCode") && !Convert.IsDBNull(row["AirlineCode"]))
                        segment += (string)row["AirlineCode"];

                    if (dataSet.Tables[2].Columns.Contains("BookingClass") && !Convert.IsDBNull(row["BookingClass"]))
                        segment += "  "+ (string)row["BookingClass"];

                    if (dataSet.Tables[2].Columns.Contains("FlightNumber") && !Convert.IsDBNull(row["FlightNumber"]))
                        segment += "  "+ (string)row["FlightNumber"];

                    if (dataSet.Tables[2].Columns.Contains("DeptDate") && !Convert.IsDBNull(row["DeptDate"]))
                    {
                        DateTime deptDate = Convert.ToDateTime(row["DeptDate"]);
                        if(i==0)
                            travellingDate.Value = deptDate.ToString("MM/dd/yy", DateTimeFormatInfo.InvariantInfo).ToUpper();
                        segment += "  " + deptDate.ToString("ddMMMyy", DateTimeFormatInfo.InvariantInfo).ToUpper();
                    }
                    segments.Add(segment);
                   
                    if (dataSet.Tables[2].Columns.Contains("FareBasis") && !Convert.IsDBNull(row["FareBasis"]) && !fareBasisList.Contains((string)(row["FareBasis"])))                        
                        fareBasisList.Add((string)(row["FareBasis"]));

                    
                }
                if (segments.Count > 0)
                    ticket.FlightInfo = String.Join("\r\n", segments.ToArray());
                if (fareBasisList.Count > 0)
                    ticket.FareBasis = String.Join("", fareBasisList.ToArray());
            }


           
            
            return ticket;
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            lblStatus.Text = "";
            string smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
            string smtpUserName = ConfigurationManager.AppSettings["SmtpUserName"];
            string smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];

            MailNotifier mailNotifier = new MailNotifier(smtpServer, smtpUserName, smtpPassword);
            
            StringBuilder mailBody = new StringBuilder();
            mailBody.Append("DEAR TRAVEL PROFESSIONAL:");
            mailBody.Append("\r\n\r\n");
            mailBody.Append("We ARE PLEASED TO DELIVER YOUR E TKT IMAGE FOR ");
            mailBody.Append(passengerName.Value);
            if (!String.IsNullOrEmpty(travellingDate.Value))
            {
                mailBody.Append(" TRAVELLING ON ");
                mailBody.Append(travellingDate.Value);
            }
            mailBody.Append(" THROUGH OUR GTT INVOICE SYSTEM.");

            mailNotifier.Body = mailBody.ToString();
            mailNotifier.Subject = "GTT E TKT FOR " + passengerName.Value + " " + travellingDate.Value;
            mailNotifier.To = this.EmailAddress.Text;
            mailNotifier.From = "noreply@gttglobal.com";
            mailNotifier.AttachmentsPath = attachmentsPath.Value;
            
            mailNotifier.Notice();

            lblStatus.Visible = true;
            lblStatus.Text = "Succeed!";
        }

      
        
    }
}
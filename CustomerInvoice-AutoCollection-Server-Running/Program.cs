using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace CustomerInvoice_AutoCollection_Server_Running
{
    class Program
    {
        static void Main(string[] args)
        {
            String DirectoryPath = System.Configuration.ConfigurationManager.AppSettings["FTP.DirectoryPath"];
            Reading(DirectoryPath);
        }


        private static void Reading(String DirectoryPath)
        {
            DirectoryInfo DirectoryInfo = new DirectoryInfo(DirectoryPath);
            FileInfo[] FileInfos  = DirectoryInfo.GetFiles();
            

            foreach (FileInfo FileInfo in FileInfos)
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

        private static DataAccess.ReadingLog  CreateReadingLog(FileInfo FileInfo)
        {
            DataAccess.ReadingLog Entity = new DataAccess.ReadingLog();
            DateTime CreationTimeUtc = FileInfo.CreationTimeUtc;
            DateTime LastWriteTimeUtc = FileInfo.LastWriteTimeUtc;

            StreamReader StreamReader = null;
            try
            {
                StreamReader = new StreamReader(FileInfo.FullName, System.Text.Encoding.UTF8);

            }
            catch
            {
            }
            String Line;
            String Content = "";

            while ((Line = StreamReader.ReadLine()) != null)
            {
                Content = Content + Line;
            }

           
            Entity.ID = Guid.NewGuid();
            Entity.FileName = FileInfo.FullName;
            Entity.ReadingDate = DateTime.Now;
            Entity.Content = Content;
            Entity.FileCreateDate = CreationTimeUtc;
            Entity.FileModifyDate = LastWriteTimeUtc;

            return Entity;
        }



        private static List<DataAccess.ReadingLogLine> CreateReadingLogLines(FileInfo FileInfo)
        {
            List<DataAccess.ReadingLogLine> Entitys = new List<DataAccess.ReadingLogLine>();
           
            StreamReader StreamReader = null;
            try
            {
                StreamReader = new StreamReader(FileInfo.FullName, System.Text.Encoding.UTF8);

            }
            catch
            {
            }
            int Index = 0;
            String Line;

            while ((Line = StreamReader.ReadLine()) != null)
            {
                if (String.IsNullOrEmpty(Line) == false)
                {
                    Index = Index + 1;
                    DataAccess.ReadingLogLine Entity = new DataAccess.ReadingLogLine();
                    Entity.ID = Guid.NewGuid();
                    Entity.Index = Index;
                    Entity.Line = Line;
                    Entitys.Add(Entity);
                }
            }

            return Entitys;
        }



        private static DataAccess.Invoice CreateInvoice(String Content)
        {
            DataAccess.Invoice Entity = new DataAccess.Invoice();
            //579031 ITINERARY INVOICE
            //                                         PAGE NO. 1
            //                                         PNR: 1P-3ARCVR

            String InvoiceNumberPattern = @"(?<InvoiceNumber>[0-9]{6})\s*ITINERARY INVOICE";
            Match InvoiceNumberMatch = Regex.Match(Content, InvoiceNumberPattern, RegexOptions.IgnoreCase);
            String InvoiceNumber = InvoiceNumberMatch.Groups["InvoiceNumber"].Value;


            String RecordLocatorPattern = @"1P-(?<RecordLocator>[0-9A-Z]{6})";
            Match RecordLocatorMatch = Regex.Match(Content, RecordLocatorPattern, RegexOptions.IgnoreCase);
            String RecordLocator = RecordLocatorMatch.Groups["RecordLocator"].Value;

            Entity.ID = Guid.NewGuid();
            Entity.CreateDate = DateTime.Now;
            Entity.RecordLocator = RecordLocator;
            Entity.InvoiceNumber = InvoiceNumber;


            //****CARMEN***  WIL                           CB                27MAR14
            // DP             WIL                           ERSLAX            27MAR14

            String AgentBranchAccountDatePattern = @"(?<AgentCode>[0-9A-Z]{2,})\s*\**\s*(?<BranchCode>[A-Z]{3})\s*(?<AccountCode>[A-Z0-9]{2,6})\s*(?<InvoiceDateString>[0-9]{2}[A-Z]{3}[0-9]{2})";
            Match AgentBranchAccountDateMatch = Regex.Match(Content, AgentBranchAccountDatePattern, RegexOptions.IgnoreCase);

            Entity.AgentName = AgentBranchAccountDateMatch.Groups["AgentCode"].Value.Replace("DATE", "").Replace("*", "").Trim();
            Entity.Branch = AgentBranchAccountDateMatch.Groups["BranchCode"].Value;
            Entity.AccountCode = AgentBranchAccountDateMatch.Groups["AccountCode"].Value;

            String InvoiceDateString = AgentBranchAccountDateMatch.Groups["InvoiceDateString"].Value;

            if (String.IsNullOrEmpty(InvoiceDateString) == false)
            {              

                Entity.InvoiceDate = DateTime.ParseExact(InvoiceDateString, "ddMMMyy", DateTimeFormatInfo.InvariantInfo);                
            }


             // AIR FARE                  292.00
             //             TAXES AND CARRIER IMPOSED FEES          664.40
             //                           TOTAL AIR FARE            956.40



            String FareAmountPattern = @"AIR FARE\s*(?<FareAmountString>[1-9]{1}[0-9]*\.[0-9]{2})";
            Match FareAmountMatch = Regex.Match(Content, FareAmountPattern, RegexOptions.IgnoreCase);
            String FareAmountString = FareAmountMatch.Groups["FareAmountString"].Value;

            if (String.IsNullOrEmpty(FareAmountString) == false)
            {
                Entity.FareAmount = Decimal.Parse(FareAmountString);
            }

            String TaxAmountPattern = @"TAXES AND CARRIER IMPOSED FEES\s*(?<TaxAmountString>[0-9]*\.[0-9]{2})";
            Match TaxAmountMatch = Regex.Match(Content, TaxAmountPattern, RegexOptions.IgnoreCase);
            String TaxAmountString = TaxAmountMatch.Groups["TaxAmountString"].Value;

            if (String.IsNullOrEmpty(TaxAmountString) == false)
            {
                Entity.TaxAmount = Decimal.Parse(TaxAmountString);
            }

            String TotalAmountPattern = @"TOTAL AIR FARE\s*(?<TotalAmountString>[1-9]{1}[0-9]*\.[0-9]{2})";
            Match TotalAmountMatch = Regex.Match(Content, TotalAmountPattern, RegexOptions.IgnoreCase);
            String TotalAmountString = TotalAmountMatch.Groups["TotalAmountString"].Value;

            if (String.IsNullOrEmpty(TotalAmountString) == false)
            {
                Entity.TotalAmount = Decimal.Parse(TotalAmountString);
            }

            return Entity;
        }


        private static List<DataAccess.InvoicePassenger> CreateInvoicePassengersFromNameAgent(String Content)
        {
            List<DataAccess.InvoicePassenger> Entitys = new List<DataAccess.InvoicePassenger>();
            String NameContent = "";
            int StartIndex = 0;
            int EndIndex = 0;
            StartIndex = Content.IndexOf("NAME");
            EndIndex = Content.IndexOf("AGENT");


            NameContent = Content.Substring(StartIndex, EndIndex - StartIndex);

            // NAME : BERHANE/MINIA.HAILESILASE.MRS
            // NAME : 1.ROSALES.JR/RAMON                2.ROSALES/MATTHEW
            NameContent = NameContent.Replace("NAMES", "");
            NameContent = NameContent.Replace("NAME", "");

            String Pattern = @"(?<Position>[0-9]{0,})[\.]{0,}(?<Name>[A-Z\.\/]{1,})";
            MatchCollection Paxs = Regex.Matches(NameContent, Pattern, RegexOptions.IgnoreCase);

            for (int index = 0; index < Paxs.Count; index++)
            {
                DataAccess.InvoicePassenger Entity = new DataAccess.InvoicePassenger();
                Entity.ID = Guid.NewGuid();

                if (String.IsNullOrEmpty(Paxs[index].Groups["Position"].Value) == false)
                {
                    Entity.Position = int.Parse(Paxs[index].Groups["Position"].Value);
                }
                Entity.PassengerName = Paxs[index].Groups["Name"].Value;
                Entitys.Add(Entity);
            }


            return Entitys;
        }


        private static List<DataAccess.InvoicePassenger> CreateInvoicePassengersFromAMT(String Content)
        {
            List<DataAccess.InvoicePassenger> Entitys = new List<DataAccess.InvoicePassenger>();
            

//           PASSENGER                                                        AIR AMT
//LIZARDO/LIZAMRS                                                  1153.10
//GALLARDO/VICTORNATHAN                                            1153.10

           Content = Content.Replace("**PASSENGER NAMES BELOW**", "");

            int StartIndex = Content.IndexOf("PASSENGER");
            int EndIndex = Content.IndexOf("AIR FARE");
            //if(EndIndex > -1 && StartIndex > -1 && EndIndex > StartIndex)
            String NameContent = Content.Substring(StartIndex, EndIndex - StartIndex + 1);
            String Pattern = @"(?<Name>[A-Z\/\.]{2,})\s*[0-9]{1,}[0-9]{2}";
            MatchCollection Paxs = Regex.Matches(NameContent, Pattern, RegexOptions.IgnoreCase);

            for (int index = 0; index < Paxs.Count; index++)
            {
                DataAccess.InvoicePassenger Entity = new DataAccess.InvoicePassenger();
                Entity.ID = Guid.NewGuid();

                
                Entity.PassengerName = Paxs[index].Groups["Name"].Value;
                Entitys.Add(Entity);
            }


            return Entitys;
        }

        
        private static List<DataAccess.InvoicePassenger> CreateInvoicePassengers(String Content)
        {
            List<DataAccess.InvoicePassenger> Entitys = new List<DataAccess.InvoicePassenger>();
            // 第一种情况 有Name 标志， 有Agent标志的
            // NAME : 1.ROSALES.JR/RAMON                2.ROSALES/MATTHEW
            //AGENT
          

            int StartIndex = 0;
            int EndIndex = 0;
            StartIndex = Content.IndexOf("NAME");
            EndIndex = Content.IndexOf("AGENT");
            int FIndex = Content.IndexOf("**PASSENGER NAMES BELOW**");
            if (StartIndex > -1 && EndIndex > -1 && EndIndex > StartIndex && FIndex == -1)
            {
                Entitys = CreateInvoicePassengersFromNameAgent(Content);
            }

            else if (Entitys.Count == 0 && FIndex > -1)
            {
                 StartIndex = Content.IndexOf("PASSENGER");
                 EndIndex = Content.IndexOf("AIR FARE");
                if (EndIndex > -1 && StartIndex > -1 && EndIndex > StartIndex)
                {
                    Entitys = CreateInvoicePassengersFromAMT(Content);
                }
            }

            return Entitys;
        }


        private static DataAccess.AccountInfo CreateAccountInfo(String Content)
        {
            DataAccess.AccountInfo Entity = new DataAccess.AccountInfo();
            Entity.ID = Guid.NewGuid();

            Entity.AccountCode = "";

            Entity.Detail = "";


            return Entity;

        }
    }
}

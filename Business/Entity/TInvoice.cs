using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entity
{
    public class TInvoice
    {
        private Guid id;
        private String invoiceno;
        private String recordlocator;
        private String accountcode;
        private String tktAgentCode;
        private String bkSID;
        private String tktSID;
        private String bkBranchCode;
        private String tktBranchCode;
        private DateTime tickettime;
        private String agentinfo;
        private String officeinfo;
        private String creditcompany;
        private String creditno;
        private Decimal fare;
        private Decimal tax;
        private Decimal total;
        private Decimal amount;
        private String pdfpath;
        private String remark;
        private String gateway;
        private Decimal creditamount;
        private Decimal calcCreditAmount;
        private Int32 status;
        private Decimal profit = -999999.99M;
        private Boolean locked;
        private Boolean llocked;
        private bool changed;
        private bool isNonAirInvoice;
        private List<TTicketInfo> tTicketInfolist = new List<TTicketInfo>();
        private List<TRouting> routinglist = new List<TRouting>();

        public Guid Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public String InvoiceNo
        {
            get
            {
                return invoiceno;
            }
            set
            {
                invoiceno = value;
            }
        }

        public String RecordLocator
        {
            get
            {
                return recordlocator;
            }
            set
            {
                recordlocator = value;
            }
        }

        public String AccountCode
        {
            get
            {
                return accountcode;
            }
            set
            {
                accountcode = value;
            }
        }

        public String TicketedAgentCode
        {
            get
            {
                return tktAgentCode;
            }
            set
            {
                tktAgentCode = value;
            }
        }

        public String BookingSID
        {
            get
            {
                return bkSID;
            }
            set
            {
                bkSID = value;
            }
        }

        public String BookingBranchCode
        {
            get
            {
                return bkBranchCode;
            }
            set
            {
                bkBranchCode = value;
            }
        }

        public String TicktedSID
        {
            get
            {
                return tktSID;
            }
            set
            {
                tktSID = value;
            }
        }

        public String TicketedBranchCode
        {
            get
            {
                return tktBranchCode;
            }
            set
            {
                tktBranchCode = value;
            }
        }

        public DateTime TicketTime
        {
            get
            {
                return tickettime;
            }
            set
            {
                tickettime = value;
            }
        }

        public String AgentInfo
        {
            get
            {
                return agentinfo;
            }
            set
            {
                agentinfo = value;
            }
        }

        public String OfficeInfo
        {
            get
            {
                return officeinfo;
            }
            set
            {
                officeinfo = value;
            }
        }

        public String CreditCompany
        {
            get
            {
                return creditcompany;
            }
            set
            {
                creditcompany = value;
            }
        }

        public String CreditNo
        {
            get
            {
                return creditno;
            }
            set
            {
                creditno = value;
            }
        }

        public Decimal Fare
        {
            get
            {
                return fare;
            }
            set
            {
                fare = value;
            }
        }

        public Decimal Tax
        {
            get
            {
                return tax;
            }
            set
            {
                tax = value;
            }
        }

        public Decimal Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
        }

        public Decimal Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        public String PDFPath
        {
            get
            {
                return pdfpath;
            }
            set
            {
                pdfpath = value;
            }
        }

        public String Remark
        {
            get
            {
                return remark;
            }
            set
            {
                remark = value;
            }
        }

        public String GateWay
        {
            get
            {
                return gateway;
            }
            set
            {
                gateway = value;
            }
        }

        public Decimal CreditAmount
        {
            get
            {
                return creditamount;
            }
            set
            {
                creditamount = value;
            }
        }

        public Decimal CalcCreditAmount
        {
            get
            {
                if (tTicketInfolist == null) return 0;
                decimal result = 0;
                foreach (TTicketInfo tkt in tTicketInfolist)
                {
                    result += tkt.SellingPrice - tkt.Charge;
                }

                return result;
            }
        }

        public Int32 Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public Decimal Profit
        {
            get
            {
                return profit;
            }
            set
            {
                profit = value;
            }
        }

        public Boolean Locked
        {
            get
            {
                return locked;
            }
            set
            {
                locked = value;
            }
        }

        public Boolean LLocked
        {
            get
            {
                return llocked;
            }
            set
            {
                llocked = value;
            }
        }

        public bool Changed
        {
            get
            {
                return changed;
            }
            set
            {
                changed = value;
            }
        }

        public bool IsNonAirInvoice
        {
            get
            {
                return isNonAirInvoice;
            }
            set
            {
                isNonAirInvoice = value;
            }
        }
        public List<TTicketInfo> TTicketInfoList
        {
            get
            {
                return tTicketInfolist;
            }
            set
            {
                tTicketInfolist = value;
            }
        }

        public List<TRouting> RoutingList
        {
            get
            {
                return routinglist;
            }
            set
            {
                routinglist = value;
            }
        }

        public String Compare(TInvoice invoice)
        {
            StringBuilder invoiceString = new StringBuilder();

            if (!this.Id.Equals(invoice.Id))
            {
                invoiceString.Append("OLD Id:\n\r" + this.Id + "\n\rNEW Id:\n\r" + invoice.Id + "\n\r");
            }

            if (!this.InvoiceNo.Equals(invoice.InvoiceNo))
            {
                invoiceString.Append("OLD InvoiceNo:\n\r" + this.InvoiceNo + "\n\rNEW InvoiceNo:\n\r" + invoice.InvoiceNo + "\n\r");
            }

            if (!this.RecordLocator.Equals(invoice.RecordLocator))
            {
                invoiceString.Append("OLD RecordLocator:\n\r" + this.RecordLocator + "\n\rNEW RecordLocator:\n\r" + invoice.RecordLocator + "\n\r");
            }

            if (!this.AccountCode.Equals(invoice.AccountCode))
            {
                invoiceString.Append("OLD AccountCode:\n\r" + this.AccountCode + "\n\rNEW AccountCode:\n\r" + invoice.AccountCode + "\n\r");
            }

            if (!this.TicketedAgentCode.Equals(invoice.TicketedAgentCode))
            {
                invoiceString.Append("OLD TicketedAgentCode:\n\r" + this.TicketedAgentCode + "\n\rNEW TicketedAgentCode:\n\r" + invoice.TicketedAgentCode + "\n\r");
            }

            if (!this.BookingSID.Equals(invoice.BookingSID))
            {
                invoiceString.Append("OLD BookingSID:\n\r" + this.BookingSID + "\n\rNEW BookingSID:\n\r" + invoice.BookingSID + "\n\r");
            }

            if (!this.BookingBranchCode.Equals(invoice.BookingBranchCode))
            {
                invoiceString.Append("OLD BookingBranchCode:\n\r" + this.BookingBranchCode + "\n\rNEW BranchCode:\n\r" + invoice.BookingBranchCode + "\n\r");
            }

            if (!this.TicktedSID.Equals(invoice.TicktedSID))
            {
                invoiceString.Append("OLD TicktedSID:\n\r" + this.TicktedSID + "\n\rNEW TicktedSID:\n\r" + invoice.TicktedSID + "\n\r");
            }

            if (!this.TicketedBranchCode.Equals(invoice.TicketedBranchCode))
            {
                invoiceString.Append("OLD TicketedBranchCode:\n\r" + this.TicketedBranchCode + "\n\rNEW TicketedBranchCode:\n\r" + invoice.TicketedBranchCode + "\n\r");
            }

            if (!this.TicketTime.Equals(invoice.TicketTime))
            {
                invoiceString.Append("OLD TicketTime:\n\r" + this.TicketTime + "\n\rNEW TicketTime:\n\r" + invoice.TicketTime + "\n\r");
            }

            if (!this.AgentInfo.Equals(invoice.AgentInfo))
            {
                invoiceString.Append("OLD AgentInfo:\n\r" + this.AgentInfo + "\n\rNEW AgentInfo:\n\r" + invoice.AgentInfo + "\n\r");
            }

            if (!this.OfficeInfo.Equals(invoice.OfficeInfo))
            {
                invoiceString.Append("OLD OfficeInfo:\n\r" + this.OfficeInfo + "\n\rNEW OfficeInfo:\n\r" + invoice.OfficeInfo + "\n\r");
            }

            if (!this.CreditCompany.Equals(invoice.CreditCompany))
            {
                invoiceString.Append("OLD CreditCompany:\n\r" + this.CreditCompany + "\n\rNEW CreditCompany:\n\r" + invoice.CreditCompany + "\n\r");
            }

            if (!this.CreditNo.Equals(invoice.CreditNo))
            {
                invoiceString.Append("OLD CreditNo:\n\r" + this.CreditNo + "\n\rNEW CreditNo:\n\r" + invoice.CreditNo + "\n\r");
            }

            if (!this.Fare.Equals(invoice.Fare))
            {
                invoiceString.Append("OLD Fare:\n\r" + this.Fare + "\n\rNEW Fare:\n\r" + invoice.Fare + "\n\r");
            }

            if (!this.Tax.Equals(invoice.Tax))
            {
                invoiceString.Append("OLD Tax:\n\r" + this.Tax + "\n\rNEW Tax:\n\r" + invoice.Tax + "\n\r");
            }

            if (!this.Total.Equals(invoice.Total))
            {
                invoiceString.Append("OLD Total:\n\r" + this.Total + "\n\rNEW Total:\n\r" + invoice.Total + "\n\r");
            }

            if (!this.Amount.Equals(invoice.Amount))
            {
                invoiceString.Append("OLD Amount:\n\r" + this.Amount + "\n\rNEW Amount:\n\r" + invoice.Amount + "\n\r");
            }

            if (!this.PDFPath.Equals(invoice.PDFPath))
            {
                invoiceString.Append("OLD PDFPath:\n\r" + this.PDFPath + "\n\rNEW PDFPath:\n\r" + invoice.PDFPath + "\n\r");
            }

            //if (!this.Remark.Equals(invoice.Remark))
            //{
            //    invoiceString.Append("OLD Remark:\n\r" + this.Remark + "\n\rNEW Remark:\n\r" + invoice.Remark + "\n\r");
            //}

            if (!this.GateWay.Equals(invoice.GateWay))
            {
                invoiceString.Append("OLD GateWay:\n\r" + this.GateWay + "\n\rNEW GateWay:\n\r" + invoice.GateWay + "\n\r");
            }

            if (!this.CreditAmount.Equals(invoice.CreditAmount))
            {
                invoiceString.Append("OLD CreditAmount:\n\r" + this.CreditAmount + "\n\rNEW CreditAmount:\n\r" + invoice.CreditAmount + "\n\r");
            }

            if (!this.Status.Equals(invoice.Status))
            {
                invoiceString.Append("OLD Status:\n\r" + this.Status + "\n\rNEW Status:\n\r" + invoice.Status + "\n\r");
            }

            if (!this.Profit.Equals(invoice.Profit))
            {
                invoiceString.Append("OLD Profit:\n\r" + this.Profit + "\n\rNEW Profit:\n\r" + invoice.Profit + "\n\r");
            }

            if (!this.Locked.Equals(invoice.Locked))
            {
                invoiceString.Append("OLD Locked:\n\r" + this.Locked + "\n\rNEW Locked:\n\r" + invoice.Locked + "\n\r");
            }

            StringBuilder ticketInfoString = new StringBuilder();
            List<String> ticketNumberList = new List<String>();

            foreach (TTicketInfo oldTicketInfo in this.TTicketInfoList)
            {
                foreach (TTicketInfo newTicketInfo in invoice.TTicketInfoList)
                {
                    if (oldTicketInfo.TicketNumber == newTicketInfo.TicketNumber)
                    {
                        ticketNumberList.Add(oldTicketInfo.TicketNumber);

                        if (!oldTicketInfo.Id.Equals(newTicketInfo.Id))
                        {
                            ticketInfoString.Append("OLD Id:\n\r" + oldTicketInfo.Id + "\n\rNEW Id:\n\r" + newTicketInfo.Id + "\n\r");
                        }

                        if (!oldTicketInfo.InvoiceId.Equals(newTicketInfo.InvoiceId))
                        {
                            ticketInfoString.Append("OLD InvoiceId:\n\r" + oldTicketInfo.InvoiceId + "\n\rNEW InvoiceId:\n\r" + newTicketInfo.InvoiceId + "\n\r");
                        }

                        if (!oldTicketInfo.Position.Equals(newTicketInfo.Position))
                        {
                            ticketInfoString.Append("OLD Position:\n\r" + oldTicketInfo.Position + "\n\rNEW Position:\n\r" + newTicketInfo.Position + "\n\r");
                        }

                        if (!oldTicketInfo.FirstName.Equals(newTicketInfo.FirstName))
                        {
                            ticketInfoString.Append("OLD FirstName:\n\r" + oldTicketInfo.FirstName + "\n\rNEW FirstName:\n\r" + newTicketInfo.FirstName + "\n\r");
                        }

                        if (!oldTicketInfo.MiddleName.Equals(newTicketInfo.MiddleName))
                        {
                            ticketInfoString.Append("OLD MiddleName:\n\r" + oldTicketInfo.MiddleName + "\n\rNEW MiddleName:\n\r" + newTicketInfo.MiddleName + "\n\r");
                        }

                        if (!oldTicketInfo.LastName.Equals(newTicketInfo.LastName))
                        {
                            ticketInfoString.Append("OLD LastName:\n\r" + oldTicketInfo.LastName + "\n\rNEW LastName:\n\r" + newTicketInfo.LastName + "\n\r");
                        }

                        if (!oldTicketInfo.TicketNumber.Equals(newTicketInfo.TicketNumber))
                        {
                            ticketInfoString.Append("OLD TicketNumber:\n\r" + oldTicketInfo.TicketNumber + "\n\rNEW TicketNumber:\n\r" + newTicketInfo.TicketNumber + "\n\r");
                        }

                        if (!oldTicketInfo.Charge.Equals(newTicketInfo.Charge))
                        {
                            ticketInfoString.Append("OLD Charge:\n\r" + oldTicketInfo.Charge + "\n\rNEW Charge:\n\r" + newTicketInfo.Charge + "\n\r");
                        }

                        if (!oldTicketInfo.SellingPrice.Equals(newTicketInfo.SellingPrice))
                        {
                            ticketInfoString.Append("OLD SellingPrice:\n\r" + oldTicketInfo.SellingPrice + "\n\rNEW SellingPrice:\n\r" + newTicketInfo.SellingPrice + "\n\r");
                        }

                        if (!oldTicketInfo.OfficeName.Equals(newTicketInfo.OfficeName))
                        {
                            ticketInfoString.Append("OLD OfficeName:\n\r" + oldTicketInfo.OfficeName + "\n\rNEW OfficeName:\n\r" + newTicketInfo.OfficeName + "\n\r");
                        }

                        if (!oldTicketInfo.AirlineName.Equals(newTicketInfo.AirlineName))
                        {
                            ticketInfoString.Append("OLD AirlineName:\n\r" + oldTicketInfo.AirlineName + "\n\rNEW AirlineName:\n\r" + newTicketInfo.AirlineName + "\n\r");
                        }

                        if (!oldTicketInfo.TourCode.Equals(newTicketInfo.TourCode))
                        {
                            ticketInfoString.Append("OLD TourCode:\n\r" + oldTicketInfo.TourCode + "\n\rNEW TourCode:\n\r" + newTicketInfo.TourCode + "\n\r");
                        }

                        if (!oldTicketInfo.ARCCode.Equals(newTicketInfo.ARCCode))
                        {
                            ticketInfoString.Append("OLD ARCCode:\n\r" + oldTicketInfo.ARCCode + "\n\rNEW ARCCode:\n\r" + newTicketInfo.ARCCode + "\n\r");
                        }

                        if (!oldTicketInfo.PassengerName.Equals(newTicketInfo.PassengerName))
                        {
                            ticketInfoString.Append("OLD PassengerName:\n\r" + oldTicketInfo.PassengerName + "\n\rNEW PassengerName:\n\r" + newTicketInfo.PassengerName + "\n\r");
                        }

                        if (!oldTicketInfo.FareBasis.Equals(newTicketInfo.FareBasis))
                        {
                            ticketInfoString.Append("OLD FareBasis:\n\r" + oldTicketInfo.FareBasis + "\n\rNEW FareBasis:\n\r" + newTicketInfo.FareBasis + "\n\r");
                        }

                        if (!oldTicketInfo.DateOfIssue.Equals(newTicketInfo.DateOfIssue))
                        {
                            ticketInfoString.Append("OLD DateOfIssue:\n\r" + oldTicketInfo.DateOfIssue + "\n\rNEW DateOfIssue:\n\r" + newTicketInfo.DateOfIssue + "\n\r");
                        }

                        if (!oldTicketInfo.RecordLocator.Equals(newTicketInfo.RecordLocator))
                        {
                            ticketInfoString.Append("OLD RecordLocator:\n\r" + oldTicketInfo.RecordLocator + "\n\rNEW RecordLocator:\n\r" + newTicketInfo.RecordLocator + "\n\r");
                        }

                        if (!oldTicketInfo.Endorsement.Equals(newTicketInfo.Endorsement))
                        {
                            ticketInfoString.Append("OLD Endorsement:\n\r" + oldTicketInfo.Endorsement + "\n\rNEW Endorsement:\n\r" + newTicketInfo.Endorsement + "\n\r");
                        }

                        if (!oldTicketInfo.FareCalculation.Equals(newTicketInfo.FareCalculation))
                        {
                            ticketInfoString.Append("OLD FareCalculation:\n\r" + oldTicketInfo.FareCalculation + "\n\rNEW FareCalculation:\n\r" + newTicketInfo.FareCalculation + "\n\r");
                        }

                        if (!oldTicketInfo.Fare.Equals(newTicketInfo.Fare))
                        {
                            ticketInfoString.Append("OLD Fare:\n\r" + oldTicketInfo.Fare + "\n\rNEW Fare:\n\r" + newTicketInfo.Fare + "\n\r");
                        }

                        if (!oldTicketInfo.FlightInfo.Equals(newTicketInfo.FlightInfo))
                        {
                            ticketInfoString.Append("OLD FlightInfo:\n\r" + oldTicketInfo.FlightInfo + "\n\rNEW FlightInfo:\n\r" + newTicketInfo.FlightInfo + "\n\r");
                        }
                    }
                }
            }

            foreach (TTicketInfo ticketInfo in this.TTicketInfoList)
            {
                if (!ticketNumberList.Contains(ticketInfo.TicketNumber))
                {
                    ticketInfoString.Append("Ticket:" + ticketInfo.TicketNumber + "has been Delete.\n\r");
                }
            }

            ticketNumberList = new List<string>();
            foreach (TTicketInfo ticketInfo in this.TTicketInfoList)
            {
                ticketNumberList.Add(ticketInfo.TicketNumber);
            }

            foreach (TTicketInfo ticketInfo in invoice.TTicketInfoList)
            {
                if (!ticketNumberList.Contains(ticketInfo.TicketNumber))
                {
                    ticketInfoString.Append("Ticket:" + ticketInfo.TicketNumber + "is new.\n\r");
                }
            }

            StringBuilder routingString = new StringBuilder();
            int count = this.RoutingList.Count;
            TRouting oldRouting;
            TRouting newRouting;

            for (int i = 0; i < count; i++)
            {
                oldRouting = this.RoutingList[i];

                try
                {
                    newRouting = invoice.RoutingList[i];

                    if (!oldRouting.Id.Equals(newRouting.Id))
                    {
                        routingString.Append("OLD Id:\n\r" + oldRouting.Id + "\n\rNEW Id:\n\r" + newRouting.Id + "\n\r");
                    }

                    if (!oldRouting.Index.Equals(newRouting.Index))
                    {
                        routingString.Append("OLD Index:\n\r" + oldRouting.Index + "\n\rNEW Index:\n\r" + newRouting.Index + "\n\r");
                    }

                    if (!oldRouting.InvoiceId.Equals(newRouting.InvoiceId))
                    {
                        routingString.Append("OLD InvoiceId:\n\r" + oldRouting.InvoiceId + "\n\rNEW InvoiceId:\n\r" + newRouting.InvoiceId + "\n\r");
                    }

                    if (!oldRouting.AirLine.Equals(newRouting.AirLine))
                    {
                        routingString.Append("OLD AirLine:\n\r" + oldRouting.AirLine + "\n\rNEW AirLine:\n\r" + newRouting.AirLine + "\n\r");
                    }

                    if (!oldRouting.DepartureAirport.Equals(newRouting.DepartureAirport))
                    {
                        routingString.Append("OLD DepartureAirport:\n\r" + oldRouting.DepartureAirport + "\n\rNEW DepartureAirport:\n\r" + newRouting.DepartureAirport + "\n\r");
                    }

                    if (!oldRouting.DepartureDateTime.Equals(newRouting.DepartureDateTime))
                    {
                        routingString.Append("OLD DepartureDateTime:\n\r" + oldRouting.DepartureDateTime + "\n\rNEW DepartureDateTime:\n\r" + newRouting.DepartureDateTime + "\n\r");
                    }

                    if (!oldRouting.ArrivalAirport.Equals(newRouting.ArrivalAirport))
                    {
                        routingString.Append("OLD ArrivalAirport:\n\r" + oldRouting.ArrivalAirport + "\n\rNEW ArrivalAirport:\n\r" + newRouting.ArrivalAirport + "\n\r");
                    }

                    if (!oldRouting.ArrivalDateTime.Equals(newRouting.ArrivalDateTime))
                    {
                        routingString.Append("OLD ArrivalDateTime:\n\r" + oldRouting.ArrivalDateTime + "\n\rNEW ArrivalDateTime:\n\r" + newRouting.ArrivalDateTime + "\n\r");
                    }

                    if (!oldRouting.BookingClass.Equals(newRouting.BookingClass))
                    {
                        routingString.Append("OLD BookingClass:\n\r" + oldRouting.BookingClass + "\n\rNEW BookingClass:\n\r" + newRouting.BookingClass + "\n\r");
                    }

                    if (!oldRouting.FlightNumber.Equals(newRouting.FlightNumber))
                    {
                        routingString.Append("OLD FlightNumber:\n\r" + oldRouting.FlightNumber + "\n\rNEW FlightNumber:\n\r" + newRouting.FlightNumber + "\n\r");
                    }

                    if (!oldRouting.NumberOfStop.Equals(newRouting.NumberOfStop))
                    {
                        routingString.Append("OLD NumberOfStop:\n\r" + oldRouting.NumberOfStop + "\n\rNEW NumberOfStop:\n\r" + newRouting.NumberOfStop + "\n\r");
                    }

                    if (!oldRouting.EquipmentType.Equals(newRouting.EquipmentType))
                    {
                        routingString.Append("OLD EquipmentType:\n\r" + oldRouting.EquipmentType + "\n\rNEW EquipmentType:\n\r" + newRouting.EquipmentType + "\n\r");
                    }
                }
                catch
                {
                    routingString.Append("Routing:" + oldRouting.Id + "has been Delete.\n\r");
                }
            }

            if (this.RoutingList.Count < invoice.RoutingList.Count)
            {
                int startIndex = invoice.RoutingList.Count - this.RoutingList.Count;

                for (int i = invoice.RoutingList.Count - startIndex; i < invoice.RoutingList.Count; i++)
                {
                    newRouting = invoice.RoutingList[i];
                    routingString.Append("Routing:" + newRouting.Id + "is new.\n\r");
                }
            }

            StringBuilder diffentString = new StringBuilder();

            if (invoiceString.Length != 0)
            {
                diffentString.Append("Invoice has been Changed, Changed Info:\n\r" + invoiceString + "\n\r");
            }

            if (ticketInfoString.Length != 0)
            {
                diffentString.Append("TicketInfo has been Changed, Changed Info:\n\r" + ticketInfoString + "\n\r");
            }

            if (routingString.Length != 0)
            {
                diffentString.Append("Routing has been Changed, Changed Info:\n\r" + routingString + "\n\r");
            }

            return diffentString.ToString();
        }
    }
}
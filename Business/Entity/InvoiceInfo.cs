using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Business.Entity
{
    public class InvoiceInfo
    {
        private Guid _invoiceID;
        private String _invoiceNumber;
        private String _accountCode;
        private String _branchOffice;
        private String _recordLocator;
        private DateTime _invoiceDate;
        private String _agentInfo;
        private String _officeInfo;
        
        private List<Passenger> _passengers;       
        private String _paymentType;
        private String _creditcardType;
        private String _creditcardNumber;
        private List<TicketRouting> _ticketRoutings;
        private List<String> _remarks;

        private Hashtable _routingKeys;
        private List<TicketRouting> _invoiceRoutingMaps;


        public InvoiceInfo()
        { 
        
        }

        public Guid InvoiceID
        {
            get { return _invoiceID; }
            set { _invoiceID = value; }
        }

        public String InvoiceNumber
        {
            get { return _invoiceNumber; }
            set { _invoiceNumber = value; }
        }

        public String AccountCode
        {
            get { return _accountCode; }
            set { _accountCode = value; }
        }

        public String BranchOffice
        {
            get { return _branchOffice; }
            set { _branchOffice = value; }
        }

        public String RecordLocator
        {
            get { return _recordLocator; }
            set { _recordLocator = value; }
        }

        public List<Passenger> Passengers
        {
            get { return _passengers; }
            set { _passengers = value; }
        }

        public String CreditcardNumber
        {
            get { return _creditcardNumber; }
            set { _creditcardNumber = value; }
        }

        public String CreditcardType
        {
            get { return _creditcardType; }
            set { _creditcardType = value; }
        }

        public String PaymentType
        {
            get { return _paymentType; }
            set { _paymentType = value; }
        }

        public List<TicketRouting> TicketRoutings
        {
            get { return _ticketRoutings; }
            set { _ticketRoutings = value; }
        }

        public List<String> Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        public DateTime InvoiceDate
        {
            get { return _invoiceDate; }
            set { _invoiceDate = value; }
        }

        public String AgentInfo
        {
            get { return _agentInfo; }
            set { _agentInfo = value; }
        }

        public String OfficeInfo
        {
            get { return _officeInfo; }
            set { _officeInfo = value; }
        }

        public List<TicketRouting> InvoiceRoutingMaps
        {
            get
            {
                _routingKeys = new Hashtable();
                _invoiceRoutingMaps = new List<TicketRouting>();
                foreach (TicketRouting tr in _ticketRoutings)
                {                    
                    StringBuilder sbuilder = new StringBuilder();
                    sbuilder.Append(tr.Airline).Append("_");
                    sbuilder.Append(tr.Departure).Append("_");
                    sbuilder.Append(tr.Destination).Append("_");
                    sbuilder.Append(tr.DepartureDatetime).Append("_");
                    sbuilder.Append(tr.ArrivalDatetime).Append("_");
                    sbuilder.Append(tr.BookingClass).Append("_");
                    sbuilder.Append(tr.FlightNumber).Append("_");

                    String mapKey = sbuilder.ToString();
                    if (!_routingKeys.ContainsKey(mapKey))
                    {
                        _routingKeys.Add(mapKey, tr);
                        _invoiceRoutingMaps.Add(tr);
                    }
                }
                return _invoiceRoutingMaps;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Entity
{
    public class Ticket
    {
        private Guid id;
        private Guid invoiceid;
        private String position;
        private String firstname;
        private String middlename;
        private String lastname;
        private String paxType;
        private String ticketnumber;
        private Decimal charge;
        private Decimal sellingprice;
        private String officename;
        private String airlineCode;
        private String airlinename;
        private String tourcode;
        private String arccode;
        private String farebasis;
        private String dateofissue;
        private String pnrcode;
        private String endorsement;
        private String farecalculation;
        private String fare;
        private String flightinfo;
        private String ticketTransactionDate;
        private String status;
        public String TicketTransactionDate
        {
            get
            {

                if (ticketTransactionDate == null)
                {
                    ticketTransactionDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                }

                return ticketTransactionDate;

            }
            set { ticketTransactionDate = value; }
        }

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

        public Guid InvoiceId
        {
            get
            {
                return invoiceid;
            }
            set
            {
                invoiceid = value;
            }
        }

        
        public String Position
        {
            get
            {
                if (string.IsNullOrEmpty(position))
                {
                    position = string.Empty;
                }

                return position;
            }
            set
            {
                position = value;
            }
        }

        public String FirstName
        {
            get
            {
                if (string.IsNullOrEmpty(firstname))
                {
                    firstname = string.Empty;
                }

                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public String MiddleName
        {
            get
            {
                if (string.IsNullOrEmpty(middlename))
                {
                    middlename = string.Empty;
                }

                return middlename;
            }
            set
            {
                middlename = value;
            }
        }

        public String LastName
        {
            get
            {
                if (string.IsNullOrEmpty(lastname))
                {
                    lastname = string.Empty;
                }

                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public String PaxType
        {
            get
            {
                return paxType;
            }
            set
            {
                paxType = value;
            }
        }

        public String TicketNumber
        {
            get
            {
                if (string.IsNullOrEmpty(ticketnumber))
                {
                    ticketnumber = string.Empty;
                }

                return ticketnumber;
            }
            set
            {
                ticketnumber = value;
            }
        }

        public Decimal Charge
        {
            get
            {
                return charge;
            }
            set
            {
                charge = value;
            }
        }

        public Decimal SellingPrice
        {
            get
            {
                return sellingprice;
            }
            set
            {
                sellingprice = value;
            }
        }

        public String OfficeName
        {
            get
            {
                if (string.IsNullOrEmpty(officename))
                {
                    officename = string.Empty;
                }

                return officename;
            }
            set
            {
                officename = value;
            }
        }

        public String AirlineName
        {
            get
            {
                if (string.IsNullOrEmpty(airlinename))
                {
                    airlinename = string.Empty;
                }

                return airlinename;
            }
            set
            {
                airlinename = value;
            }
        }

        public String AirlineCode
        {
            get
            {
                return airlineCode;
            }
            set
            {
                airlineCode = value;
            }
        }

        public String TourCode
        {
            get
            {
                if (string.IsNullOrEmpty(tourcode))
                {
                    tourcode = string.Empty;
                }

                return tourcode;
            }
            set
            {
                tourcode = value;
            }
        }

        public String ARCCode
        {
            get
            {
                if (string.IsNullOrEmpty(arccode))
                {
                    arccode = string.Empty;
                }

                return arccode;
            }
            set
            {
                arccode = value;
            }
        }

        public String PassengerName
        {
            get
            {
                return FirstName + "/" + LastName ;
            }
        }

        public String FareBasis
        {
            get
            {
                if (string.IsNullOrEmpty(farebasis))
                {
                    farebasis = string.Empty;
                }

                return farebasis;
            }
            set
            {
                farebasis = value;
            }
        }

        public String DateOfIssue
        {
            get
            {
                if (string.IsNullOrEmpty(dateofissue))
                {
                    dateofissue = string.Empty;
                }

                return dateofissue;
            }
            set
            {
                dateofissue = value;
            }
        }

        public String RecordLocator
        {
            get
            {
                if (string.IsNullOrEmpty(pnrcode))
                {
                    pnrcode = string.Empty;
                }

                return pnrcode;
            }
            set
            {
                pnrcode = value;
            }
        }

        public String Endorsement
        {
            get
            {
                if (string.IsNullOrEmpty(endorsement))
                {
                    endorsement = string.Empty;
                }

                return endorsement;
            }
            set
            {
                endorsement = value;
            }
        }

        public String FareCalculation
        {
            get
            {
                if (string.IsNullOrEmpty(farecalculation))
                {
                    farecalculation = string.Empty;
                }

                return farecalculation;
            }
            set
            {
                farecalculation = value;
            }
        }

        public String Fare
        {
            get
            {
                if (string.IsNullOrEmpty(fare))
                {
                    fare = string.Empty;
                }

                return fare;
            }
            set
            {
                fare = value;
            }
        }

        public String FlightInfo
        {
            get
            {
                if (string.IsNullOrEmpty(flightinfo))
                {
                    flightinfo = string.Empty;
                }

                return flightinfo;
            }
            set
            {
                flightinfo = value;
            }
        }

        public bool IsShowTicketImage
        {
            get
            {
                if (string.IsNullOrEmpty(ticketnumber) || ticketnumber.Substring(0, 3) == "890" ||
                        string.IsNullOrEmpty(endorsement) || string.IsNullOrEmpty(farecalculation))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public String Status
        {
            get
            {
                if (string.IsNullOrEmpty(status))
                {
                    status = string.Empty;
                }

                return status;
            }
            set
            {
                status = value;
            }
        }

    }
}
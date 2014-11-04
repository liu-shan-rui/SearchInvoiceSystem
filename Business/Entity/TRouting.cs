using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entity
{
    public class TRouting
    {
        private Guid id;
        private int idx;
        private Guid invoiceid;
        private String airline;
        private String departureairport;
        private DateTime departuredatetime = DateTime.Now;
        private String arrivalairport;
        private DateTime arrivaldatetime = DateTime.Now;
        private String bookingclass;
        private String flightnumber;
        private int numberofstop;
        private String equipmenttype;

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

        public int Index
        {
            get
            {
                return idx;
            }
            set
            {
                idx = value;
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

        public String AirLine
        {
            get
            {
                return airline;
            }
            set
            {
                airline = value;
            }
        }

        public String DepartureAirport
        {
            get
            {
                return departureairport;
            }
            set
            {
                departureairport = value;
            }
        }

        public DateTime DepartureDateTime
        {
            get
            {
                return departuredatetime;
            }
            set
            {
                departuredatetime = value;
            }
        }

        public String ArrivalAirport
        {
            get
            {
                return arrivalairport;
            }
            set
            {
                arrivalairport = value;
            }
        }

        public DateTime ArrivalDateTime
        {
            get
            {
                return arrivaldatetime;
            }
            set
            {
                arrivaldatetime = value;
            }
        }

        public String BookingClass
        {
            get
            {
                return bookingclass;
            }
            set
            {
                bookingclass = value;
            }
        }

        public String FlightNumber
        {
            get
            {
                return flightnumber;
            }
            set
            {
                flightnumber = value;
            }
        }

        public int NumberOfStop
        {
            get
            {
                return numberofstop;
            }
            set
            {
                numberofstop = value;
            }
        }

        public String EquipmentType
        {
            get
            {
                return equipmenttype;
            }
            set
            {
                equipmenttype = value;
            }
        }
    }
}
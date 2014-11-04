using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entity
{
    public class TicketRouting
    {
        private Guid m_ticketID;
        private String m_airline;
        private String m_departure;
        private DateTime m_departureDatetime = DateTime.Now;
        private String m_destination;
        private DateTime m_arrivalDatetime = DateTime.Now;
        private String m_bookingClass;
        private String m_flightNumber;
        private String m_segmentStatus;
        private String m_ticketStatus;
        private String m_stopNumber;
        private String m_fareBasis;

        public Guid TicketID
        {
            get { return m_ticketID; }
            set { m_ticketID = value; }
        }
       
        public String Airline
        {
            get { return m_airline; }
            set { m_airline = value; }
        }

        public String Departure
        {
            get { return m_departure; }
            set { m_departure = value; }
        }

        public DateTime DepartureDatetime
        {
            get { return m_departureDatetime; }
            set { m_departureDatetime = value; }
        }

        public String Destination
        {
            get { return m_destination; }
            set { m_destination = value; }
        }

        public DateTime ArrivalDatetime
        {
            get { return m_arrivalDatetime; }
            set { m_arrivalDatetime = value; }
        }

        public String BookingClass
        {
            get { return m_bookingClass; }
            set { m_bookingClass = value; }
        }

        public String FlightNumber
        {
            get { return m_flightNumber; }
            set { m_flightNumber = value; }
        }

        public String SegmentStatus
        {
            get { return m_segmentStatus; }
            set { m_segmentStatus = value; }
        }

        public String TicketStatus
        {
            get { return m_ticketStatus; }
            set { m_ticketStatus = value; }
        }

        public String StopNumber
        {
            get { return m_stopNumber; }
            set { m_stopNumber = value; }
        }

        public String FareBasis
        {
            get { return m_fareBasis; }
            set { m_fareBasis = value; }
        }

    }
}

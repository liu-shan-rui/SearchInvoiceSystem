using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entity
{
    public class TicketInfo
    {
        private Guid m_ticketID;
        private String m_ticketNumber;
        private List<TicketRouting> m_ticketRoutings;

        public TicketInfo()
        { 
            
        }

        public Guid TicketID
        {
            get { return m_ticketID; }
            set { m_ticketID = value; }
        }

        public String TicketNumber
        {
            get { return m_ticketNumber; }
            set { m_ticketNumber = value; }
        }

        public List<TicketRouting> TicketRoutings
        {
            get { return m_ticketRoutings; }
            set { m_ticketRoutings = value; }
        }
    }
}

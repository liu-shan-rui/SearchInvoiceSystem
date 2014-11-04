using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entity
{
    public class Passenger
    {
        private String m_firstName;        
        private String m_lastName;

        public String FirstName
        {
            get { return m_firstName; }
            set { m_firstName = value; }
        }

        public String LastName
        {
            get { return m_lastName; }
            set { m_lastName = value; }
        }
    }
}

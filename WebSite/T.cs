using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP
{
    public class T
    {
        private int _RowIndex;

        public int RowIndex
        {
            get { return _RowIndex; }
            set { _RowIndex = value; }
        }
        private String _TicketNumber;

        public String TicketNumber
        {
            get { return _TicketNumber; }
            set { _TicketNumber = value; }
        }
        private String _RL;

        public String RL
        {
            get { return _RL; }
            set { _RL = value; }
        }
        private String _Inv;

        public String Inv
        {
            get { return _Inv; }
            set { _Inv = value; }
        }
        private String _Status;

        public String Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
    }
}
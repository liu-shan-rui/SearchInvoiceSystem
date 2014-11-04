using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace DataAccess.Entitys
{
    public class EntityPair
    {
        private String _Name;

        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private String _Value;

        public String Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }
}

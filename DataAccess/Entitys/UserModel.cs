using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Entitys
{
    public class UserModel
    {
        private Guid _ID;

        public Guid ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private String _Username;

        public String Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        private String _Password;

        public String Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private String _Role;

        public String Role
        {
            get { return _Role; }
            set { _Role = value; }
        }

        private String _RealName;

        public String RealName
        {
            get { return _RealName; }
            set { _RealName = value; }
        }

        private String _AccountCode;

        public String AccountCode
        {
            get { return _AccountCode; }
            set { _AccountCode = value; }
        }

        private Guid _ParentID;

        public Guid ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }

        private String _Telephone;

        public String Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }

        private String _Email;

        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private int _IsDelete;

        public int IsDelete
        {
            get { return _IsDelete; }
            set { _IsDelete = value; }
        }
    }
}

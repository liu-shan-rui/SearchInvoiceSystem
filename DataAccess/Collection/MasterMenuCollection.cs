using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entitys.SystemStore;
using DataAccess; 

namespace DataAccess.Collection
{
    public class MasterMenuCollection
    {
        private DataAccess.CustomerInvoiceEntities _Context = new CustomerInvoiceEntities();
        private List<MasterMenuDA> _MasterMenuDAs = new List<MasterMenuDA>();

        public List<MasterMenuDA> MasterMenuDAs
        {
            get { return _MasterMenuDAs.OrderBy(v => v.Entity.CreateDate).ToList(); }
        }

        public MasterMenuCollection()
        {
            List<DataAccess.MasterMenu> Entitys = _Context.MasterMenu.Where(v => v.IsDelete == 0).ToList();
            foreach (DataAccess.MasterMenu e in Entitys)
            {
                MasterMenuDA DA = new MasterMenuDA(e);
                this._MasterMenuDAs.Add(DA);
            }
        }
    }
}

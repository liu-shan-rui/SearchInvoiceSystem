using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entitys.SystemStore;
using DataAccess;

namespace DataAccess.Collection
{
    public class ObjectMenuCollection
    {
        private CustomerInvoiceEntities _Context = new DataAccess.CustomerInvoiceEntities();
        private List<ObjectMenuDA> _ObjectMenuDAs = new List<ObjectMenuDA>();

        public List<ObjectMenuDA> ObjectMenuDAs
        {
            get { return _ObjectMenuDAs.OrderBy(v => v.Entity.CreateDate).ToList(); }
        }

        public ObjectMenuCollection()
        {
            List<DataAccess.ObjectMenu> Entitys = _Context.ObjectMenu.Where(v => v.IsDelete == 0).ToList();
            foreach (DataAccess.ObjectMenu e in Entitys)
            {
                ObjectMenuDA DA = new ObjectMenuDA(e);
                this._ObjectMenuDAs.Add(DA);
            }
        }

        public ObjectMenuCollection(Guid MasterMenuID)
        {
            String MasterMenuIDString = MasterMenuID.ToString();
            List<EntityNameValue> EntityNameValues = this._Context.EntityNameValue.Where(v => v.Name == "MasterMenuID"
                && v.Value == MasterMenuIDString
                && v.IsDelete == 0).ToList();
            List<Guid> IDs = new List<Guid>();
            foreach (EntityNameValue ENV in EntityNameValues)
            {
                if (IDs.Contains(ENV.EntityID) == false)
                {
                    IDs.Add(ENV.EntityID);
                }
            }
            foreach (Guid ID in IDs)
            {
                ObjectMenuDA DA = new ObjectMenuDA(ID);
                if (DA.Entity.IsDelete == 0)
                {
                    this._ObjectMenuDAs.Add(DA);
                }
            }
        }
    }
}

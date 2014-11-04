using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Entitys.SystemStore;
using DataAccess;

namespace DataAccess.Collection
{
    public class PersonMenuCollection
    {
        private CustomerInvoiceEntities _Context = new CustomerInvoiceEntities();
        private List<PersonMenuDA> _PersonMenuDAs = new List<PersonMenuDA>();

        public List<PersonMenuDA> PersonMenuDAs
        {
            get { return _PersonMenuDAs.OrderBy(v => v.Entity.CreateDate).ToList(); }
        }

        public PersonMenuCollection()
        {
            List<DataAccess.PersonMenu> Entitys = _Context.PersonMenu.Where(v => v.IsDelete == 0).ToList();
            foreach (DataAccess.PersonMenu e in Entitys)
            {
                PersonMenuDA DA = new PersonMenuDA(e);
                this._PersonMenuDAs.Add(DA);
            }
        }

        public PersonMenuCollection(Guid ObjectMenuID)
        {
            String ObjectMenuIDString = ObjectMenuID.ToString();
            List<EntityNameValue> EntityNameValues = this._Context.EntityNameValue.Where(v => v.Name == "ObjectMenuID"
                && v.Value == ObjectMenuIDString
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
                PersonMenuDA DA = new PersonMenuDA(ID);
                if (DA.Entity.IsDelete == 0)
                {
                    this._PersonMenuDAs.Add(DA);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace DataAccess.Entitys
{
    public class EntityNameValues
    {
        private CustomerInvoiceEntities _Context;
        private Guid _EntityID;
        private List<EntityNameValue> _EntityNameValues;

        public List<EntityNameValue> ENameValues
        {
            get { return _EntityNameValues; }

        }
        public EntityNameValues(Guid EntityID)
        {
            this._Context = new CustomerInvoiceEntities();
            this._EntityID = EntityID;
            _EntityNameValues = _Context.EntityNameValue.Where(v => v.EntityID == _EntityID && v.IsDelete == 0).ToList();
        }

        public void Delete()
        {
            foreach (EntityNameValue EN in _EntityNameValues)
            {
                EN.IsDelete = 1;
            }
            this._Context.SaveChanges();
        }

        public void Init(List<EntityPair> NameValues)
        {
            foreach (EntityNameValue EN in _EntityNameValues)
            {
                EN.IsDelete = 1;
            }

            if (NameValues != null && NameValues.Count > 0)
            {
                foreach (EntityPair NV in NameValues)
                {
                    EntityNameValue ENV = new EntityNameValue();
                    ENV.ID = Guid.NewGuid();
                    ENV.EntityID = this._EntityID;
                    ENV.Name = NV.Name;
                    ENV.Value = NV.Value;
                    ENV.IsDelete = 0;
                    this._Context.EntityNameValue.AddObject(ENV);
                }

                this._Context.SaveChanges();
            }
            _EntityNameValues = _Context.EntityNameValue.Where(v => v.EntityID == _EntityID).ToList();
        }

        public bool Update(Guid EntityID, List<EntityPair> NameValues)
        {
            this._Context = new CustomerInvoiceEntities();
            this._EntityID = EntityID;
            foreach (EntityPair ep in NameValues)
            {
                EntityNameValue entityNameValue = _Context.EntityNameValue.FirstOrDefault(v => v.EntityID == _EntityID && v.Name == ep.Name && v.IsDelete == 0);
                if (entityNameValue != null)
                {
                    entityNameValue.Value = ep.Value;
                }
                else
                {
                    entityNameValue = new EntityNameValue();
                    entityNameValue.Name = ep.Name;
                    entityNameValue.Value = ep.Value;
                    entityNameValue.IsDelete = 0;
                    entityNameValue.EntityID = _EntityID;
                    entityNameValue.ID = Guid.NewGuid();
                    this._Context.EntityNameValue.AddObject(entityNameValue);
                }
            }
            try
            {
                this._Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public String GetValue(String Name)
        {
            foreach (EntityNameValue n in this._EntityNameValues)
            {
                if (n.Name == Name)
                {
                    return n.Value;
                }
            }
            return null;
        }

        public void SetValue(String Name, String Value)
        {
            foreach (EntityNameValue n in this._EntityNameValues)
            {
                if (n.Name == Name)
                {
                    n.Value = Value;
                    return;
                }
            }
        }
    }
}

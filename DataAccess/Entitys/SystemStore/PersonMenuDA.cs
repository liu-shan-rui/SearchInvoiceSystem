using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using DataAccess.Entitys;

namespace DataAccess.Entitys.SystemStore
{
    public class PersonMenuDA
    {
        public String GetValue(String Name)
        {
            return this._EntityNameValues.GetValue(Name);
        }

        private static List<String> _Propertys = new List<string>();
        public static List<String> Propertys
        {
            get
            {
                if (_Propertys.Count == 0)
                {
                    InitPropertys();
                }
                return PersonMenuDA._Propertys;
            }

        }
        private static void InitPropertys()
        {
            PersonMenuDA._Propertys.Add("Name");
            PersonMenuDA._Propertys.Add("URL");
            PersonMenuDA._Propertys.Add("ObjectMenuID");
        }

        public Guid ObjectMenuID
        {
            get
            {
                String ObjectMenuIDStr = this._EntityNameValues.GetValue("ObjectMenuID");
                if (String.IsNullOrEmpty(ObjectMenuIDStr) == false)
                {
                    return new Guid(ObjectMenuIDStr);
                }
                return new Guid();
            }
        }

        public ObjectMenuDA ObjectMenuDA
        {
            get
            {
                return new ObjectMenuDA(ObjectMenuID);
            }
        }


        public String Name
        {
            get
            {
                return this._EntityNameValues.GetValue("Name");
            }
        }

        public String URL
        {
            get
            {
                return this._EntityNameValues.GetValue("URL");
            }
        }

        private CustomerInvoiceEntities _Context = new CustomerInvoiceEntities();
        private DataAccess.PersonMenu _Entity;

        public DataAccess.PersonMenu Entity
        {
            get { return _Entity; }

        }
        private Guid _EntityID;
        private EntityNameValues _EntityNameValues;

        public PersonMenuDA(Guid ID)
        {
            this.InitbyID(ID);
        }

        private void InitbyID(Guid ID)
        {
            this._EntityID = ID;
            this._Entity = _Context.PersonMenu.FirstOrDefault(v => v.ID == this._EntityID);
            this._EntityNameValues = new EntityNameValues(this._EntityID);
        }


        public void Delete()
        {
            this._Entity.IsDelete = 1;
            this._Context.SaveChanges();
            this._EntityNameValues.Delete();
        }

        public PersonMenuDA(PersonMenu Entity)
        {
            this._EntityID = Entity.ID;
            this._Entity = Entity;
            _EntityNameValues = new EntityNameValues(this._EntityID);
        }

        public PersonMenuDA(PersonMenu Entity, List<EntityPair> NameValues)
        {
            PersonMenu E = this._Context.PersonMenu.FirstOrDefault(v => v.ID == Entity.ID && v.IsDelete == 0);
            if (E != null)
            {
                E.CreateDate = DateTime.Now;
                E.CreatorID = Entity.CreatorID;
            }
            else
            {
                E = Entity;
                this._Context.AddToPersonMenu(E);
            }

            this._Context.SaveChanges();

            EntityNameValues ENVS = new EntityNameValues(Entity.ID);
            ENVS.Init(NameValues);

            this.InitbyID(Entity.ID);
        }
    }
}

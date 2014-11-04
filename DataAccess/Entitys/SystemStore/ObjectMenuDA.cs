using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using DataAccess.Entitys;

namespace DataAccess.Entitys.SystemStore
{
    public class ObjectMenuDA
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
                return ObjectMenuDA._Propertys;
            }

        }
        private static void InitPropertys()
        {
            ObjectMenuDA._Propertys.Add("Name");
            ObjectMenuDA._Propertys.Add("URL");
            ObjectMenuDA._Propertys.Add("MasterMenuID");
        }
        

        public Guid MasterMenuID
        {
            get
            {
                String MasterMenuIDStr = this._EntityNameValues.GetValue("MasterMenuID");
                if (String.IsNullOrEmpty(MasterMenuIDStr) == false)
                {
                    return new Guid(MasterMenuIDStr);
                }
                return new Guid();


            }
        }

        public MasterMenuDA MasterMenuDA
        {
            get
            {
                return new MasterMenuDA(MasterMenuID);
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
        private DataAccess.ObjectMenu _Entity;

        public DataAccess.ObjectMenu Entity
        {
            get { return _Entity; }

        }
        private Guid _EntityID;
        private EntityNameValues _EntityNameValues;

        public ObjectMenuDA(Guid ID)
        {
            this.InitbyID(ID);
        }

        private void InitbyID(Guid ID)
        {
            this._EntityID = ID;
            this._Entity = _Context.ObjectMenu.FirstOrDefault(v => v.ID == this._EntityID);
            this._EntityNameValues = new EntityNameValues(this._EntityID);

        }


        public void Delete()
        {
            this._Entity.IsDelete = 1;
            this._Context.SaveChanges();
            this._EntityNameValues.Delete();
        }

        public ObjectMenuDA(ObjectMenu Entity)
        {
            this._EntityID = Entity.ID;
            this._Entity = Entity;
            _EntityNameValues = new EntityNameValues(this._EntityID);
        }

        public ObjectMenuDA(ObjectMenu Entity, List<EntityPair> NameValues)
        {
            ObjectMenu E = this._Context.ObjectMenu.FirstOrDefault(v => v.ID == Entity.ID && v.IsDelete == 0);
            if (E != null)
            {
                E.CreateDate = DateTime.Now;
                E.CreatorID = Entity.CreatorID;
            }
            else
            {
                E = Entity;
                this._Context.AddToObjectMenu(E);
            }

            this._Context.SaveChanges();

            EntityNameValues ENVS = new EntityNameValues(Entity.ID);
            ENVS.Init(NameValues);

            this.InitbyID(Entity.ID);
        }
    }
}

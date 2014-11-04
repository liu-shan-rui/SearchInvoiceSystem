using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace DataAccess.Entitys.SystemStore
{
    public class MasterMenuDA
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
                return MasterMenuDA._Propertys;
            }

        }

        private static void InitPropertys()
        {
            MasterMenuDA._Propertys.Add("Name");
            MasterMenuDA._Propertys.Add("URL");
        }
        

        #region 属性

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
        #endregion

        private CustomerInvoiceEntities _Context = new CustomerInvoiceEntities();
        
        private DataAccess.MasterMenu _Entity;
        public DataAccess.MasterMenu Entity
        {
            get { return _Entity; }          
        }

        private Guid _EntityID;
        private EntityNameValues _EntityNameValues;
        
        public MasterMenuDA(Guid ID)
        {
            this.InitbyID(ID);
        }

        private void InitbyID(Guid ID)
        {
            this._EntityID = ID;
            this._Entity = _Context.MasterMenu.FirstOrDefault(v => v.ID == this._EntityID);
            this._EntityNameValues= new EntityNameValues(this._EntityID);
            
        }


        public void Delete()
        {
            this._Entity.IsDelete = 1;
            this._Context.SaveChanges();
            this._EntityNameValues.Delete();
        }

        public MasterMenuDA(MasterMenu Entity)
        {
            this._EntityID = Entity.ID;
            this._Entity =Entity;
            _EntityNameValues = new EntityNameValues(this._EntityID);           
        }

        public MasterMenuDA(MasterMenu Entity, List<EntityPair> NameValues)
        {
            MasterMenu E = this._Context.MasterMenu.FirstOrDefault(v => v.ID == Entity.ID && v.IsDelete == 0);
            if (E != null)
            {
                E.CreateDate = DateTime.Now;
                E.CreatorID = Entity.CreatorID;
            }
            else
            {
                E = Entity;
                this._Context.AddToMasterMenu(E);
            }          
          
            this._Context.SaveChanges();

            EntityNameValues ENVS = new EntityNameValues(Entity.ID);
            ENVS.Init(NameValues);

            this.InitbyID(Entity.ID);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using DataAccess.Entitys;
using DataAccess.Entitys.SystemStore;
using DataAccess.Collection;

namespace ERP
{
    public partial class SystemPersonMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack == false)
            {
                this.InitMasterMenu();
                this.InitObjectMenu();
                String IDString = this.Page.Request["ID"];
                if (String.IsNullOrEmpty(IDString) == false)
                {
                    this.DataShow(new Guid(IDString));
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            PersonMenu EM = new PersonMenu();
            EM.CreateDate = DateTime.Now;
            EM.CreatorID = new Guid("1E814B64-6765-43E0-AC74-1719034376F2");
            if (String.IsNullOrEmpty(this.lblID.Text))
            {
                EM.ID = Guid.NewGuid();
            }
            else
            {
                EM.ID = new Guid(this.lblID.Text);
            }
            EM.IsDelete = 0;

            List<EntityPair> EntityPairs = new List<EntityPair>();

            List<String> Propertys = PersonMenuDA.Propertys;

            ContentPlaceHolder MainContent = (ContentPlaceHolder)this.Master.FindControl("MainContent");
            if (MainContent != null)
            {
                for (int index = 0; index < Propertys.Count; index++)
                {
                    EntityPair EP = new EntityPair();
                    EP.Name = Propertys[index];
                    TextBox txtBox = (TextBox)(MainContent.FindControl("txt" + Propertys[index]));
                    if (txtBox != null)
                    {
                        EP.Value = txtBox.Text;
                    }
                    else if (txtBox == null)
                    {
                        DropDownList ddl = (DropDownList)(MainContent.FindControl("ddl" + Propertys[index]));
                        EP.Value = ddl.SelectedValue;
                    }
                    EntityPairs.Add(EP);
                }
            }

            PersonMenuDA Company = new PersonMenuDA(EM, EntityPairs);
            this.DataClear();
        }

        private void DataShow(Guid ID)
        {
            PersonMenuDA DA = new PersonMenuDA(ID);
            this.lblID.Text = DA.Entity.ID.ToString();

            ContentPlaceHolder MainContent = (ContentPlaceHolder)this.Master.FindControl("MainContent");
            if (MainContent != null)
            {
                List<String> Propertys = PersonMenuDA.Propertys;

                for (int index = 0; index < Propertys.Count; index++)
                {
                    TextBox txtBox = (TextBox)(MainContent.FindControl("txt" + Propertys[index]));
                    if (txtBox != null)
                    {
                        txtBox.Text = DA.GetValue(Propertys[index]);
                    }
                    else
                    {
                        DropDownList ddl = (DropDownList)(MainContent.FindControl("ddl" + Propertys[index]));
                        if (ddl != null)
                        {
                            ddl.SelectedValue = DA.GetValue(Propertys[index]);
                        }
                    }
                }
            }
        }
        private void DataClear()
        {
            ContentPlaceHolder MainContent = (ContentPlaceHolder)this.Master.FindControl("MainContent");
            if (MainContent != null)
            {
                List<String> Propertys = PersonMenuDA.Propertys;

                for (int index = 0; index < Propertys.Count; index++)
                {
                    TextBox txtBox = (TextBox)(MainContent.FindControl("txt" + Propertys[index]));
                    if (txtBox != null)
                    {
                        txtBox.Text = "";
                    }
                }
            }
            this.lblID.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String URL = "SystemPersonMenuCollection.aspx";
            this.Page.Response.Redirect(URL);
        }


        private void InitMasterMenu()
        {
            MasterMenuCollection Collection = new MasterMenuCollection();
            foreach (MasterMenuDA DA in Collection.MasterMenuDAs)
            {
                ListItem item = new ListItem(DA.Name, DA.Entity.ID.ToString());
                this.ddlMasterMenuID.Items.Add(item);
            }
        }

        private void InitObjectMenu()
        {
            this.ddlObjectMenuID.Items.Clear();
            ObjectMenuCollection Collection = new ObjectMenuCollection(new Guid(this.ddlMasterMenuID.SelectedValue));
            foreach (ObjectMenuDA DA in Collection.ObjectMenuDAs)
            {
                ListItem item = new ListItem(DA.Name, DA.Entity.ID.ToString());
                this.ddlObjectMenuID.Items.Add(item);
            }
        }

        protected void ddlMasterMenuID_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InitObjectMenu();
        }
    }
}
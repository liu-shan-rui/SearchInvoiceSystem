using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using DataAccess.Entitys;
using DataAccess.Entitys.SystemStore;

namespace ERP
{
    public partial class SystemMasterMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack == false)
            {
                String IDString = this.Page.Request["ID"];
                if (String.IsNullOrEmpty(IDString) == false)
                {
                    this.DataShow(new Guid(IDString));
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MasterMenu EM = new MasterMenu();
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

            List<String> Propertys = MasterMenuDA.Propertys;

            ContentPlaceHolder MainContent = (ContentPlaceHolder)this.Master.FindControl("MainContent");
            if (MainContent != null)
            {
                for (int index = 0; index < Propertys.Count; index++)
                {
                    TextBox txtBox = (TextBox)(MainContent.FindControl("txt" + Propertys[index]));
                    if (txtBox != null)
                    {
                        EntityPair EP = new EntityPair();
                        EP.Name = Propertys[index];
                        EP.Value = txtBox.Text;
                        EntityPairs.Add(EP);
                    }
                }
            }

            MasterMenuDA Company = new MasterMenuDA(EM, EntityPairs);
            this.DataClear();
        }

        private void DataShow(Guid ID)
        {
            MasterMenuDA DA = new MasterMenuDA(ID);
            this.lblID.Text = DA.Entity.ID.ToString();

            ContentPlaceHolder MainContent = (ContentPlaceHolder)this.Master.FindControl("MainContent");
            if (MainContent != null)
            {
                List<String> Propertys = MasterMenuDA.Propertys;

                for (int index = 0; index < Propertys.Count; index++)
                {
                    TextBox txtBox = (TextBox)(MainContent.FindControl("txt" + Propertys[index]));
                    if (txtBox != null)
                    {
                        txtBox.Text = DA.GetValue(Propertys[index]);
                    }
                }
            }
        }
        private void DataClear()
        {
            ContentPlaceHolder MainContent = (ContentPlaceHolder)this.Master.FindControl("MainContent");
            if (MainContent != null)
            {
                List<String> Propertys = MasterMenuDA.Propertys;

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
            String URL = "SystemMasterMenuCollection.aspx";
            this.Page.Response.Redirect(URL);
        }
    }
}
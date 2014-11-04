using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Collection;
using DataAccess.Entitys.SystemStore;

namespace ERP
{
    public partial class SystemMasterMenuCollection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack == false)
            {
                this.InitDGInfo();
            }
        }

        private void InitDGInfo()
        {
            MasterMenuCollection Collection = new MasterMenuCollection();
            this.DGInfo.DataSource = Collection.MasterMenuDAs;
            this.DGInfo.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.InitDGInfo();
        }

        private String GetFirstID()
        {
            String ID = "";
            for (int index = 0; index < this.DGInfo.Items.Count; index++)
            {
                CheckBox chkSelect = (CheckBox)this.DGInfo.Items[index].FindControl("chkSelect");
                Label lblID = (Label)this.DGInfo.Items[index].FindControl("lblID");

                if (chkSelect.Checked)
                {
                    ID = lblID.Text;
                    return ID;
                }
            }

            return "";
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            String ID = this.GetFirstID();

            if (String.IsNullOrEmpty(ID) == false)
            {
                String url = "SystemMasterMenu.aspx?ID=" + ID;
                this.Page.Response.Redirect(url);
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < this.DGInfo.Items.Count; index++)
            {
                CheckBox chkSelect = (CheckBox)this.DGInfo.Items[index].FindControl("chkSelect");
                Label lblID = (Label)this.DGInfo.Items[index].FindControl("lblID");

                if (chkSelect.Checked)
                {
                    MasterMenuDA DA = new MasterMenuDA(new Guid(lblID.Text));
                    DA.Delete();
                }
            }

            this.InitDGInfo();

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            String url = "SystemMasterMenu.aspx"; ;
            this.Page.Response.Redirect(url);
        }
    }
}
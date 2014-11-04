using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ERP
{
    public partial class SearchAgent : System.Web.UI.Page
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
            DataAccess.CustomerInvoiceDA DA = new DataAccess.CustomerInvoiceDA();
            DataSet ds = DA.SearchAgent(txtUsername.Text, txtName.Text, ddlRole.SelectedValue, txtAccountCode.Text, txtPhone.Text, txtEmail.Text);
            DGInfo.DataSource = ds;
            DGInfo.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.InitDGInfo();
        }
    }
}
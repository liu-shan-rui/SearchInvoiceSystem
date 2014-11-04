using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ERP
{
    public partial class CustomerInvoiceSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime StartDate = new DateTime(2000,1,1);
            DateTime EndDate = DateTime.Now.Date;

            try
            {
                StartDate = DateTime.Parse(this.txtStartDate.Text);
            }
            catch
            {
            }

            try
            {
                EndDate = DateTime.Parse(this.txtEndDate.Text);
            }
            catch
            {
            }


            DataAccess.CustomerInvoiceDA DA = new DataAccess.CustomerInvoiceDA();
            DataSet ds = DA.Search(StartDate, EndDate, this.txtAccountCode.Text, this.txtRecordLocator.Text, this.txtBranch.Text);

            this.DGInfo.DataSource = ds;
            this.DGInfo.DataBind();

        }

        protected void DGInfo_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string invoiceNumber = DataBinder.Eval(e.Item.DataItem, "InvoiceNumber").ToString();
                string invoiceID = DataBinder.Eval(e.Item.DataItem, "InvoiceID").ToString();
                //string paxName = DataBinder.Eval(e.Item.DataItem, "PassengerName").ToString();
                //string invoiceDate = DataBinder.Eval(e.Item.DataItem, "InvoiceDate").ToString();

                HyperLink lkbInvoice = (HyperLink)e.Item.FindControl("lnkInvoiceShow");
                if (lkbInvoice != null)
                {
                    lkbInvoice.NavigateUrl = "InvoicePDF.aspx?INVID=" + invoiceID;
                    lkbInvoice.Target = "_blank";
                    lkbInvoice.Text = invoiceNumber;
                }


                string tktID = ((DataRowView)e.Item.DataItem)["TicketID"].ToString();
                string url = string.Format("TicketImage.aspx?TKTID={0}", tktID);
                e.Item.Cells[6].Text = "<a target=\"_blank\" href=" + url + ">" + e.Item.Cells[6].Text + "</a>";

            }


        }
    }
}
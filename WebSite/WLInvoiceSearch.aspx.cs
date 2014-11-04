using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataAccess;

namespace ERP
{
    public partial class WLInvoiceSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
               
            }
        }   

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            //DataAccess.CustomerInvoiceDA DA = new DataAccess.CustomerInvoiceDA();
            //DataSet ds = DA.Search(StartDate, EndDate, this.txtAccountCode.Text, this.txtRecordLocator.Text, this.txtBranch.Text);

            //this.DGInfo.DataSource = ds;
            //this.DGInfo.DataBind();

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            String Path = Server.MapPath("WL");
            String FileName = Path + "\\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-sss") + ".xls";
            this.FileUpload.PostedFile.SaveAs(FileName);

            DataAccess.Excel Excel = new DataAccess.Excel();
            DataSet DS = Excel.ReaderExcel("Tickets", FileName);

            WLTicketDA da = new WLTicketDA();

            da.ClearWLTicket();
            da.InsertWLTicket(DS);
            InitDgInfo();
        }

        private void InitDgInfo()
        {
            WLTicketDA da = new WLTicketDA();
            DataSet ds = da.ReturnCompareTicket();
            DGInfo.DataSource = ds;
            DGInfo.DataBind();
        }
    }
}
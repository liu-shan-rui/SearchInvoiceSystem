using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataAccess.Entitys;

namespace ERP
{
    public partial class SearchbyAgt : System.Web.UI.Page
    {
        private UserModel m_user
        {
            get
            {
                return (UserModel)Session["CurrentUser"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (m_user == null)
            {
                Response.Redirect("login.aspx");
            }

            //针对 subagent 锁定 account code 的值，使其只能看到自己公司代理的 Invoice
            if (m_user.Role == "AGT")
            {
                txtAccountCode.Text = m_user.AccountCode;
                txtAccountCode.ReadOnly = true;
            }

            if (!IsPostBack)
            {
                
            }
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime StartDate = DateTime.Now.AddMonths(-3); //默认查询三个月的数据
            DateTime EndDate = DateTime.Now.Date;

            DateTime.TryParse(this.txtStartDate.Text, out StartDate);
            DateTime.TryParse(this.txtEndDate.Text, out EndDate);

            DataAccess.CustomerInvoiceDA DA = new DataAccess.CustomerInvoiceDA();
            DataSet ds = DA.SearchByAcct(txtRecordLocator.Text, txtBranch.Text, txtTicketNumber.Text, txtPaxName.Text,
                txtAccountCode.Text, txtAgentCode.Text, txtInvoiceFrom.Text, txtInvoiceTo.Text, StartDate, EndDate);

            this.InvList.DataSource = ds;
            this.InvList.DataBind();
        }

         /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                //GridView paxList = (GridView)e.Row.FindControl("PaxList");
                //GridView tktList = (GridView)e.Row.FindControl("TktList");
                //GridView spList = (GridView)e.Row.FindControl("SpList");
                //GridView ccList = (GridView)e.Row.FindControl("CcList");

                //TInvoice inv = (TInvoice)e.Row.DataItem;
                string invoiceNumber = DataBinder.Eval(e.Row.DataItem, "InvoiceNumber").ToString();
                string invoiceID = DataBinder.Eval(e.Row.DataItem, "InvoiceID").ToString();
                string tktID = ((DataRowView)e.Row.DataItem)["TicketID"].ToString();

                //Pdf
                HyperLink lnkInvPdf = (HyperLink)e.Row.FindControl("lnkInvPdf");
                if (lnkInvPdf != null)
                {
                    string url = string.Format("InvoicePDF.aspx?INVID={0}", invoiceID);
                    lnkInvPdf.NavigateUrl = url;
                }

                //Img
                HyperLink lnkInvImg = (HyperLink)e.Row.FindControl("lnkInvImg");
                if (lnkInvImg != null)
                {
                    string url = string.Format("TicketImage.aspx?TKTID={0}", tktID);
                    lnkInvImg.NavigateUrl = url;
                }
            }
        }
    }
}
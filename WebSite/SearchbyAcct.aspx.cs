using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Business.Entity;

namespace ERP
{
    public partial class SearchbyAcct : System.Web.UI.Page
    {
        private PageData m_pageData
        {
            get
            {
                if (ViewState["PAGE_DATA"] == null)
                {
                    ViewState["PAGE_DATA"] = new PageData();
                }

                return (PageData)ViewState["PAGE_DATA"];
            }
            set
            {
                ViewState["PAGE_DATA"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime StartDate = new DateTime(2000, 1, 1);
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
            DataSet ds = DA.SearchByAcct(txtRecordLocator.Text, txtBranch.Text, txtTicketNumber.Text, txtPaxName.Text,
                txtAccountCode.Text, txtAgentCode.Text, txtInvoiceFrom.Text, txtInvoiceTo.Text, StartDate, EndDate);

            this.InvList.DataSource = ds;
            this.InvList.DataBind();

            m_pageData = new PageData();

            m_pageData.BranchCode = txtBranch.Text.Trim();
            m_pageData.AccountCode = txtAccountCode.Text.Trim();
            m_pageData.InvoiceNoFrom = txtInvoiceFrom.Text.Trim();
            m_pageData.InvoiceNoTo = txtInvoiceTo.Text.Trim();
            m_pageData.RecordLocator = txtRecordLocator.Text;
            m_pageData.PassengerName = txtPaxName.Text;
            m_pageData.TicketDateFrom = StartDate;
            m_pageData.TicketDateTo = EndDate;
            m_pageData.TicketNumber = txtTicketNumber.Text.Trim();
            m_pageData.AgentCode = txtAgentCode.Text.Trim();

            //ShowData();
        }

        public DataSet dsIvn()
        {
            DataAccess.CustomerInvoiceDA DA = new DataAccess.CustomerInvoiceDA();
            DataSet ds = DA.SearchByAcct(m_pageData.PassengerName, m_pageData.BranchCode, m_pageData.TicketNumber, m_pageData.PassengerName,
                m_pageData.AccountCode, m_pageData.AgentCode, m_pageData.InvoiceNoFrom, m_pageData.InvoiceNoTo, m_pageData.TicketDateFrom, m_pageData.TicketDateTo);

            return ds;
        }
        private void InitControl()
        {
            //Login Info
            //lblLogIn.Text = m_user.RoleName + " : " + m_user.UserName;
            //if (m_user.Role == Role.LocalAccounting)
            //{
            //    lblLogIn.Text += " - " + m_user.AccountOrBranchCode;
            //}

            ////Manage User
            //if (!m_user.IsAllow("USERMANAGE", "View"))
            //{
            //    hlMngUser.Visible = false;
            //}

            ////Manage Branch
            //if (!m_user.IsAllow("BRANCHMANAGE", "View"))
            //{
            //    hlMngBranch.Visible = false;
            //}

            //Branch
            //if (m_user.Role == Role.CentralAccounting)
            //{
            //    trBranch.Visible = true;
            //    ddlBranch.Items.Clear();

            //    ddlBranch.Items.Add(new ListItem("", ""));
            //    IList<TBranch> branchs = Comm.GetBranchs(m_user);
            //    int bLen = branchs.Count;

            //    for (int bCount = 0; bCount < bLen; bCount++)
            //    {
            //        //loop branch 
            //        TBranch tBranch = branchs[bCount];

            //        ddlBranch.Items.Add(new ListItem(tBranch.LocationNumber + tBranch.BranchNumber, tBranch.BranchCode));
            //    }

            //    //if (ddlBranch.Items.Count > 1)
            //    //{
            //    //    ddlBranch.Items[1].Selected = true;
            //    //}
            //}
            //else
            //{
            //    trBranch.Visible = false;
            //    trChg.Visible = false;
            //}

            //Lock Date Range
            //lockFrom.Text = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
            //lockTo.Text = DateTime.Now.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="datas"></param>
        private void ShowData()
        {

            //获取总记录数
            //int total = Comm.GetInvTotalRecordNumber(m_pageData.BranchCode, m_pageData.AccountCode, m_pageData.RecordLocator,
                                                       // m_pageData.InvoiceNoFrom, m_pageData.InvoiceNoTo,
                                                       // m_pageData.TicketDateFrom, m_pageData.TicketDateTo, m_pageData.ChangedOnly, m_pageData.IsNonAirInvoice, m_pageData.TicketNumber);

            //计算总页数
            //m_pageData.TotalPageNumber = (int)Math.Ceiling((float)total / (float)m_pageData.PageSize);
            m_pageData.TotalPageNumber = 1;


            //获取记录
            if (m_pageData.TotalPageNumber != 0)
            {

                IList<TInvoice> invs = Comm.GetInvPageData(m_pageData.BranchCode, m_pageData.AccountCode, m_pageData.RecordLocator,
                                                            m_pageData.InvoiceNoFrom, m_pageData.InvoiceNoTo,
                                                            m_pageData.TicketDateFrom, m_pageData.TicketDateTo, m_pageData.ChangedOnly,
                                                            m_pageData.TicketDateOrder, m_pageData.InvoiceNoOrder,
                                                            m_pageData.PageSize, m_pageData.CurrentPageNumber, m_pageData.IsNonAirInvoice, m_pageData.TicketNumber);
                InvList.DataSource = invs;

            }
            else
            {
                InvList.DataSource = null;
            }

            //绑定
            InvList.DataBind();

            //if (!m_user.IsAllow("ACCTINFO", "Edit"))
            //{
            //    InvList.Columns[14].Visible = false;
            //}

            //if (!m_user.IsAllow("ACCTINFO", "Lock"))
            //{
            //    InvList.Columns[16].Visible = false;
            //}

            //if (m_user.Role != Role.CentralAccounting)
            //{
            //    InvList.Columns[0].Visible = false;
            //}

            //设置页码
            SetPager();

        }


        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InvList_Sorting(object sender, GridViewSortEventArgs e)
        {
            //if (e.SortExpression == "TKT_DATE")
            //{
            //    if (m_pageData.TicketDateOrder == SortingDirection.Descending)
            //    {
            //        InvList.Columns[3].HeaderText = InvList.Columns[3].HeaderText.Replace("▼", "▲");
            //        m_pageData.TicketDateOrder = SortingDirection.Ascending;
            //    }
            //    else
            //    {
            //        InvList.Columns[3].HeaderText = InvList.Columns[3].HeaderText.Replace("▲", "▼");
            //        m_pageData.TicketDateOrder = SortingDirection.Descending;
            //    }
            //}
            //else if (e.SortExpression == "INV_NO")
            //{
            //    if (m_pageData.InvoiceNoOrder == SortingDirection.Descending)
            //    {
            //        InvList.Columns[4].HeaderText = InvList.Columns[4].HeaderText.Replace("▼", "▲");
            //        m_pageData.InvoiceNoOrder = SortingDirection.Ascending;
            //    }
            //    else
            //    {
            //        InvList.Columns[4].HeaderText = InvList.Columns[4].HeaderText.Replace("▲", "▼");
            //        m_pageData.InvoiceNoOrder = SortingDirection.Descending;
            //    }
            //}

            //ShowData();
        }

        #region Pager
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrePage_Click(object sender, EventArgs e)
        {
            m_pageData.CurrentPageNumber--;
            //ShowData();
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNextPage_Click(object sender, EventArgs e)
        {
            m_pageData.CurrentPageNumber++;
            //ShowData();
        }

        /// <summary>
        /// 设置页码
        /// </summary>
        private void SetPager()
        {
            //设置按钮
            btnPrePage.Visible = (m_pageData.TotalPageNumber > 0);
            btnNextPage.Visible = (m_pageData.TotalPageNumber > 0);

            if (m_pageData.CurrentPageNumber == 1)
            {
                btnPrePage.Enabled = false;
            }
            else if (m_pageData.CurrentPageNumber > 1)
            {
                btnPrePage.Enabled = true;
            }

            if (m_pageData.TotalPageNumber == 0 || m_pageData.CurrentPageNumber == m_pageData.TotalPageNumber)
            {
                btnNextPage.Enabled = false;
            }
            else if (m_pageData.TotalPageNumber > m_pageData.CurrentPageNumber)
            {
                btnNextPage.Enabled = true;
            }

            //计算数字
            if (m_pageData.TotalPageNumber > 0)
            {
                int start = 1;
                int end = m_pageData.TotalPageNumber;

                if (m_pageData.TotalPageNumber > 20)
                {
                    int len = 20;
                    start = m_pageData.CurrentPageNumber - len / 2;
                    end = m_pageData.CurrentPageNumber + len / 2;

                    if (start < 1)
                    {
                        end += (1 - start);
                        start = 1;
                    }
                    else if (end > m_pageData.TotalPageNumber)
                    {
                        start -= (end - m_pageData.TotalPageNumber);
                        end = m_pageData.TotalPageNumber;
                    }
                }

                //显示
                List<Pager> pagers = new List<Pager>();

                //Head
                if (start > 1)
                {
                    pagers.Add(new Pager(start - 1, "..."));
                }

                //Body
                for (int i = start; i <= end; i++)
                {
                    pagers.Add(new Pager(i, i.ToString()));
                }

                //Tail
                if (end < m_pageData.TotalPageNumber)
                {
                    pagers.Add(new Pager(end + 1, "..."));
                }


                dlPageNumber.DataSource = pagers;
                dlPageNumber.DataBind();
            }
            else
            {
                dlPageNumber.DataSource = null;
                dlPageNumber.DataBind();
            }
        }

        protected void dlPageNumber_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton btnPage = (LinkButton)e.Item.FindControl("btnPage");
                Pager pager = (Pager)e.Item.DataItem;
                if (btnPage != null)
                {
                    btnPage.Text = pager.Text;
                    btnPage.CommandName = "TURN_PAGE";
                    btnPage.CommandArgument = pager.PageNumber.ToString();

                    if (m_pageData.CurrentPageNumber == pager.PageNumber)
                    {
                        btnPage.Enabled = false;
                    }
                }
            }
        }

        protected void dlPageNumber_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "TURN_PAGE")
            {
                int page = Convert.ToInt32(e.CommandArgument);
                m_pageData.CurrentPageNumber = page;
                //ShowData();
            }
        }
        #endregion



        #region 数据显示处理

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

                //HyperLink lkbInvoice = (HyperLink)e.Row.FindControl("lnkInvoiceShow");
                //if (lkbInvoice != null)
                //{
                //    lkbInvoice.NavigateUrl = "PdfView.aspx?INVID=" + invoiceID;
                //    lkbInvoice.Target = "_blank";
                //    lkbInvoice.Text = invoiceNumber;
                //}


                //string tktID = ((DataRowView)e.Row.DataItem)["TicketID"].ToString();
                //string url = string.Format("TicketImage.aspx?TKTID={0}", tktID);
                //e.Row.Cells[6].Text = "<a target=\"_blank\" href=" + url + ">" + e.Row.Cells[6].Text + "</a>";

                ////Changee
                //ImageButton btnClearChanged = (ImageButton)e.Row.FindControl("btnClearChanged");
                //if (btnClearChanged != null)
                //{
                //    btnClearChanged.CommandArgument = inv.Id.ToString();
                //    btnClearChanged.Visible = inv.Changed;
                //}

                ////Passenger Name
                //if (paxList != null && inv != null)
                //{
                //    paxList.DataSource = inv.TTicketInfoList;
                //    paxList.DataBind();
                //}

                ////Ticket Number
                //if (tktList != null && inv != null)
                //{
                //    tktList.DataSource = inv.TTicketInfoList;
                //    tktList.DataBind();
                //}

                ////Selling
                //if (spList != null && inv != null)
                //{
                //    spList.DataSource = inv.TTicketInfoList;
                //    spList.DataBind();
                //}
                ////Charge
                //if (ccList != null && inv != null)
                //{
                //    ccList.DataSource = inv.TTicketInfoList;
                //    ccList.DataBind();
                //}

                //Credit
                //Invoice Balance
                //if (inv.CalcCreditAmount.ToString() != null)
                //{
                //    //e.Row.Cells[9].Text = Math.Abs(inv.CalcCreditAmount).ToString();
                //    e.Row.Cells[9].Text = inv.CalcCreditAmount.ToString();
                //}
                //if (inv.CalcCreditAmount > 0)
                //{
                //    e.Row.Cells[9].Text = string.Empty;
                //    e.Row.Cells[10].Text = Math.Abs(inv.CalcCreditAmount).ToString();
                //}
                //else if (inv.CalcCreditAmount == 0)
                //{
                //    e.Row.Cells[9].Text = string.Empty;
                //    e.Row.Cells[10].Text = string.Empty;
                //}
                //else
                //{
                //    e.Row.Cells[9].Text = Math.Abs(inv.CalcCreditAmount).ToString();
                //    e.Row.Cells[10].Text = string.Empty;
                //}

                //Profit
                //if (inv.Profit == -999999.99M)
                //{
                //    e.Row.Cells[11].Text = "***";
                //}
                //else
                //{
                //    if (inv.Profit < 0)
                //    {
                //        e.Row.Cells[11].Text = inv.Profit.ToString();
                //        e.Row.Cells[11].ForeColor = System.Drawing.Color.Red;
                //    }
                //    else if (inv.Profit == 0)
                //    {
                //        e.Row.Cells[11].Text = string.Empty;
                //    }
                //    else
                //    {
                //        e.Row.Cells[11].Text = inv.Profit.ToString();
                //    }
                //}

                //Status
                //if (inv.Status == 0)
                //{
                //    e.Row.Cells[12].Text = "VOID";
                //}
                //else
                //{
                //    e.Row.Cells[12].Text = string.Empty;
                //}

                ////Pdf
                //HyperLink lnkInvPdf = (HyperLink)e.Row.FindControl("lnkInvPdf");
                //if (lnkInvPdf != null)
                //{
                //    string url = string.Format("pdfView.aspx?INVID={0}", inv.Id);
                //    lnkInvPdf.NavigateUrl = url;
                //}

                ////Edit
                //HyperLink lnkInvEdit = (HyperLink)e.Row.FindControl("lnkInvEdit");
                //if (lnkInvEdit != null)
                //{
                //    string url = string.Format("pdfEdit.aspx?RL={0}", inv.RecordLocator);
                //    lnkInvEdit.NavigateUrl = url;
                //}



                //Lock
                //ImageButton btnCentLock = (ImageButton)e.Row.FindControl("btnCentLock");
                //ImageButton btnLoclLock = (ImageButton)e.Row.FindControl("btnLoclLock");

                //if (!inv.Locked)
                //{
                //    btnCentLock.ImageUrl = "images/open.gif";
                //    btnCentLock.AlternateText = "Click To Lock";
                //    btnCentLock.CommandName = "CL_LOCK";
                //    inv.Locked = false;
                //}
                //else
                //{
                //    btnCentLock.ImageUrl = "images/lock.gif";
                //    btnCentLock.AlternateText = "Click To Unlock";
                //    btnCentLock.CommandName = "CL_UNLOCK";
                //    inv.Locked = true;
                //}
                //btnCentLock.CommandArgument = inv.Id.ToString();

                //if (!inv.LLocked)
                //{
                //    btnLoclLock.ImageUrl = "images/open.gif";
                //    btnLoclLock.AlternateText = "Click To Lock";
                //    btnLoclLock.CommandName = "LL_LOCK";
                //    inv.LLocked = false;
                //}
                //else
                //{
                //    btnLoclLock.ImageUrl = "images/lock.gif";
                //    btnLoclLock.AlternateText = "Click To Unlock";
                //    btnLoclLock.CommandName = "LL_UNLOCK";
                //    inv.LLocked = true;
                //}
                //btnLoclLock.CommandArgument = inv.Id.ToString();

                //
                //if (!m_user.IsAllow("ACCTINFO", "LLock"))
                //{
                //    btnLoclLock.Enabled = false;
                //}

                //if (!m_user.IsAllow("ACCTINFO", "Lock"))
                //{
                //    btnCentLock.Enabled = false;
                //}


                //if (inv.Locked)
                //{
                //    lnkInvEdit.Visible = false;
                //    btnLoclLock.Visible = false;
                //}
                //else if (m_user.Role == Role.LocalAccounting && inv.LLocked)
                //{
                //    lnkInvEdit.Visible = false;
                //}
            }
        }

        /// <summary>
        /// Ticket 处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TktList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Tkt
                HyperLink lnkTktImage = (HyperLink)e.Row.FindControl("lnkTktImage");
                TTicketInfo tkt = (TTicketInfo)e.Row.DataItem;
                //if (string.IsNullOrEmpty(tkt.TicketNumber))
                //{
                //    e.Row.Cells[0].Visible = false;
                //    lnkTktImage.Visible = false;
                //}

                if (lnkTktImage != null && tkt != null)
                {
                    lnkTktImage.Visible = tkt.IsShowTicketImage;
                    if (tkt.IsShowTicketImage)
                    {
                        string url = string.Format("TicketImage.aspx?INVID={0}&TKTID={1}", tkt.InvoiceId, tkt.Id);
                        lnkTktImage.NavigateUrl = url;
                    }
                }

            }
        }


        /// <summary>
        /// Selling 处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SpList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Tkt
                TTicketInfo tkt = (TTicketInfo)e.Row.DataItem;
                if (tkt.SellingPrice == 0)
                {
                    e.Row.Cells[0].Text = string.Empty;
                    e.Row.Cells[0].Visible = false;
                }
            }
        }

        /// <summary>
        /// Charg 处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CcList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Tkt
                TTicketInfo tkt = (TTicketInfo)e.Row.DataItem;
                if (tkt.Charge == 0)
                {
                    e.Row.Cells[0].Text = string.Empty;
                    e.Row.Cells[0].Visible = false;
                }
            }
        }
        #endregion

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("login.aspx");
        }

        /// <summary>
        /// 行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName.IndexOf("LOCK") != -1)
            //{
            //    ImageButton imgBtn = (ImageButton)e.CommandSource;
            //    DataControlFieldCell cell = (DataControlFieldCell)imgBtn.Parent;
            //    GridViewRow gvr = (GridViewRow)cell.Parent;
            //    HyperLink lnkInvEdit = (HyperLink)gvr.FindControl("lnkInvEdit");

            //    Guid id = new Guid((string)e.CommandArgument);
            //    if (e.CommandName == "CL_LOCK")
            //    {
            //        if (Comm.ChangeLocked(id, true))
            //        {
            //            imgBtn.ImageUrl = "images/lock.gif";
            //            imgBtn.AlternateText = "Click To Unlock";
            //            imgBtn.CommandName = "CL_UNLOCK";
            //            lnkInvEdit.Visible = false;
            //        }
            //    }
            //    else if (e.CommandName == "CL_UNLOCK")
            //    {
            //        if (Comm.ChangeLocked(id, false))
            //        {
            //            imgBtn.ImageUrl = "images/open.gif";
            //            imgBtn.AlternateText = "Click To Lock";
            //            imgBtn.CommandName = "CL_LOCK";
            //            lnkInvEdit.Visible = true;
            //        }
            //    }
            //    else if (e.CommandName == "LL_LOCK")
            //    {
            //        if (Comm.ChangeLLocked(id, true))
            //        {
            //            imgBtn.ImageUrl = "images/lock.gif";
            //            imgBtn.AlternateText = "Click To Unlock";
            //            imgBtn.CommandName = "LL_UNLOCK";
            //            lnkInvEdit.Visible = false;
            //        }
            //    }
            //    else if (e.CommandName == "LL_UNLOCK")
            //    {
            //        if (Comm.ChangeLLocked(id, false))
            //        {
            //            imgBtn.ImageUrl = "images/open.gif";
            //            imgBtn.AlternateText = "Click To Lock";
            //            imgBtn.CommandName = "LL_LOCK";
            //            lnkInvEdit.Visible = true;
            //        }
            //    }
            //}
            //else if (e.CommandName == "CLR_CHG")
            //{
            //    Guid id = new Guid((string)e.CommandArgument);
            //    if (Comm.ClearChanged(id))
            //    {
            //        ImageButton imgBtn = (ImageButton)e.CommandSource;
            //        imgBtn.Visible = false;
            //    }
            //}
        }


        //protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        //{
        //    btnExport.Visible = true;
        //    //Branch Code
        //    m_pageData = new PageData();

        //    if (m_user.Role == Role.LocalAccounting)
        //    {
        //        m_pageData.BranchCode = m_user.AccountOrBranchCode;
        //    }
        //    else
        //    {
        //        m_pageData.BranchCode = ddlBranch.SelectedValue;
        //    }

        //    //Agent
        //    m_pageData.AccountCode = txtAccountCode.Text.Trim();

        //    //Invoice No
        //    m_pageData.InvoiceNoFrom = txtInvFrom.Text.Trim();
        //    m_pageData.InvoiceNoTo = txtInvTo.Text.Trim();

        //    //R/L
        //    m_pageData.RecordLocator = txtRecordLocator.Text;

        //    //Passenger
        //    m_pageData.PassengerName = txtPaxName.Text;

        //    //Date Range
        //    if (!string.IsNullOrEmpty(txtFrom.Text))
        //    {
        //        m_pageData.TicketDateFrom = Convert.ToDateTime(txtFrom.Text);
        //    }
        //    if (!string.IsNullOrEmpty(txtTo.Text))
        //    {
        //        m_pageData.TicketDateTo = Convert.ToDateTime(txtTo.Text);
        //    }

        //    //Changed Only
        //    m_pageData.ChangedOnly = rdChged.Checked;
        //    m_pageData.IsNonAirInvoice = ddlAirType.SelectedValue;
        //    m_pageData.TicketNumber = txtTicketNo.Text;

        //    ShowData();
        //}

        //public void Export(DataTable dt, string FileName)
        //{

        //    Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        //    Response.ContentType = "application/msexcel";

        //    Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + "");
        //    string colHeaders = "", Is_item = "";
        //    int i = 0;

        //    //System.Data.DataTable dt = ds.Tables[0];
        //    DataRow[] myRow = dt.Select("");
        //    //for (i = 0; i < dt.Columns.Count; i++)
        //    //{
        //    //    colHeaders += dt.Columns[i].Caption.ToString() + "\t";
        //    //}
        //    colHeaders = "SEQNO" + "\t" + "DEPTNO" + "\t" + "INVNO" + "\t" + "DATE" + "\t" + "CCODE" + "\t" + "PNAME" + "\t" + "TRNID" + "\t" + "TKTNO" + "\t" + "STATUS" + "\t" + "D" + "\t" + "INVT" + "\t" + "CCHG" + "\t" + "IVB" + "\t" + "ERROR" + "\t";
        //    colHeaders += "\n";

        //    Response.Write(colHeaders);
        //    foreach (DataRow row in myRow)
        //    {
        //        object RotingInfo1 = row[29];
        //        int countList = ((System.Collections.Generic.List<TicketManageDLL.Entity.TTicketInfo>)RotingInfo1).Count;
        //        if (countList > 0)
        //        {
        //            for (int a = 0; a < countList; a++)
        //            {
        //                object SEQNO = row[2];
        //                object DEPTNO = row[6];
        //                object INVNO = row[1];
        //                object DATE = row[9];
        //                object CCODE = row[3];
        //                object RotingInfo = row[29];
        //                object TicketInfo = row[30];
        //                string PassengerName = ((System.Collections.Generic.List<TicketManageDLL.Entity.TTicketInfo>)RotingInfo)[a].PassengerName.ToString();
        //                string TktNo = ((System.Collections.Generic.List<TicketManageDLL.Entity.TTicketInfo>)RotingInfo)[a].TicketNumber.ToString();
        //                decimal INVT = ((System.Collections.Generic.List<TicketManageDLL.Entity.TTicketInfo>)RotingInfo)[a].SellingPrice;
        //                decimal CCHG = ((System.Collections.Generic.List<TicketManageDLL.Entity.TTicketInfo>)RotingInfo)[a].Charge;
        //                decimal IVB = INVT - CCHG;
        //                //string TicketInfo[0] = (string)object TicketInfo;
        //                if (TktNo.Length > 14)
        //                {
        //                    TktNo = TktNo.Substring(0, 13);
        //                }

        //                Is_item += SEQNO.ToString() + "\t" + DEPTNO.ToString().Substring(3, 3) + "\t" + "'" + INVNO.ToString() + "\t" + Convert.ToDateTime(DATE).ToString("MM/dd/yyyy") + "\t" + CCODE.ToString() + "\t" + PassengerName + "\t" + "" + "\t" + "'" + TktNo + "\t" + "" + "\t" + "" + "\t" + INVT + "\t" + CCHG + "\t" + IVB + "\t" + "" + "\t";
        //                //Is_item += Convert.ToDateTime(SEQNO).ToString("MM/dd/yyyy") + "\t" + "'"+INV.ToString() + "\t" + "'"+TICKET.ToString().Substring(0, 3) + " " + TICKET.ToString().Substring(3, TICKET.ToString().Length - 3) + "\t" + PASSENGER.ToString() + "\t";
        //                Is_item += "\n";
        //                Response.Write(Is_item);
        //                Is_item = "";
        //            }
        //        }
        //    }

        //    Response.End();
        //}

        //protected void btnExport_Click(object sender, EventArgs e)
        //{

        //    IList<TInvoice> invs = Comm.GetInvPageDataV2(m_pageData.BranchCode, m_pageData.AccountCode, m_pageData.RecordLocator,
        //                                                     m_pageData.InvoiceNoFrom, m_pageData.InvoiceNoTo,
        //                                                     m_pageData.TicketDateFrom, m_pageData.TicketDateTo, m_pageData.ChangedOnly,
        //                                                     m_pageData.TicketDateOrder, m_pageData.InvoiceNoOrder,
        //                                                     m_pageData.IsNonAirInvoice, m_pageData.TicketNumber);


        //    DataTable dt = ConvertToDataTable(invs);
        //    //  WriteExcel(dt, "d:\\a.xls");
        //    Export(dt, "accinv.xls");
        //}

        //#region 导出Excel

        //public DataTable ConvertToDataTable<T>(IList<T> i_objlist)
        //{
        //    if (i_objlist == null || i_objlist.Count <= 0)
        //    {
        //        return null;
        //    }
        //    DataTable dt = new DataTable(typeof(T).Name);
        //    DataColumn column;
        //    DataRow row;
        //    System.Reflection.PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
        //    foreach (T t in i_objlist)
        //    {
        //        if (t == null)
        //        {
        //            continue;
        //        }
        //        row = dt.NewRow();
        //        for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
        //        {
        //            System.Reflection.PropertyInfo pi = myPropertyInfo[i];

        //            string name = pi.Name;

        //            if (dt.Columns[name] == null)
        //            {
        //                column = new DataColumn(name, pi.PropertyType);
        //                dt.Columns.Add(column);
        //            }

        //            row[name] = pi.GetValue(t, null);
        //        }
        //        dt.Rows.Add(row);
        //    }
        //    return dt;
        //}

        //#endregion
    }
}

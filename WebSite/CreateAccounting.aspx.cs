using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Entitys;
using DataAccess;
using System.Data;

namespace ERP
{
    public partial class CreateAccounting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lblException.Text = "";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblException.Text = "";
            UserDA dao = new UserDA();

            if (lblMark.Text.Length > 10)
            {
                Guid ID = new Guid(lblMark.Text);
                String role = "";
                if (rdoAccounting.Checked == true)
                {
                    role = "Accounting";
                }
                if (rdoAccountManager.Checked == true)
                {
                    role = "AccountManage";
                }
                if (rdoBranchManager.Checked == true)
                {
                    role = "BranchManage";
                }

                UserModel existsCodeUserModel = dao.VerificationAccountCode(txtAccountCode.Text, ID);
                UserModel existsNameUserModel = dao.VerificationUsername(txtUsername.Text, ID);
                if (existsCodeUserModel.ID == Guid.Empty && existsNameUserModel.ID == Guid.Empty)
                {
                    dao.changeUser(txtUsername.Text, txtPassword.Text, txtName.Text, role, txtAccountCode.Text, txtPhone.Text, txtEmail.Text, ID);
                    clear();
                    InitDgInfo();
                }
                else
                {
                    lblException.Text = "您填写的AccountCode之前已经被使用!";
                }

            }
            else
            {
                UserModel existsCodeUserModel = dao.VerificationAccountCode(txtAccountCode.Text);
                UserModel existsNameUserModel = dao.VerificationUsername(txtUsername.Text);
                if (existsCodeUserModel.ID == Guid.Empty && existsNameUserModel.ID == Guid.Empty)
                {
                    UserModel model = new UserModel();
                    Guid ID = Guid.NewGuid();
                    model.ID = ID;
                    model.Username = txtUsername.Text;
                    model.Password = txtPassword.Text;
                    model.RealName = txtName.Text;
                    model.AccountCode = txtAccountCode.Text;
                    model.Email = txtEmail.Text;
                    model.Telephone = txtPhone.Text;
                    model.ParentID = ID;
                    if (rdoAccounting.Checked == true)
                    {
                        model.Role = "LAT";
                    }
                    if (rdoAccountManager.Checked == true)
                    {
                        model.Role = "LAT";
                    }
                    if (rdoBranchManager.Checked == true)
                    {
                        model.Role = "BMN";
                    }
                    model.IsDelete = 0;
                    dao.AddUserModel(model);
                    clear();
                    InitDgInfo();
                }
                else
                {
                    lblException.Text = "您填写的AccountCode之前已经被使用!";
                }
            }

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void clear()
        {
            txtName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtAccountCode.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }


        private void InitDgInfo()
        {
            UserDA dao = new UserDA();
            String role = "";
            if (rdoAccounting.Checked == true)
            {
                role = "Accounting";
            }
            if (rdoAccountManager.Checked == true)
            {
                role = "AccountManage";
            }
            if (rdoBranchManager.Checked == true)
            {
                role = "BranchManage";
            }
            DataSet ds = dao.GetUserModels(txtUsername.Text, txtPassword.Text, txtName.Text, role, txtAccountCode.Text, txtPhone.Text, txtEmail.Text);
            DGInfo.DataSource = ds;
            DGInfo.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            InitDgInfo();
        }

        protected void DGInfo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            UserDA dao = new UserDA();
            Label lblID = (Label)e.Item.FindControl("lblID");
            if (e.CommandName == "edit")
            {
                if (String.IsNullOrEmpty(lblID.Text) == false)
                {
                    Guid ID = new Guid(lblID.Text);
                    UserModel model = dao.GetUserModel(ID);
                    txtUsername.Text = model.Username;
                    txtPassword.Text = model.Password;
                    txtAccountCode.Text = model.AccountCode;
                    txtName.Text = model.RealName;
                    txtPhone.Text = model.Telephone;
                    txtEmail.Text = model.Email;
                    String originalRole = model.Role;
                    if (originalRole == "Accounting")
                    {
                        rdoAccounting.Checked = true;
                    }
                    else if (originalRole == "AccountManager")
                    {
                        rdoAccountManager.Checked = true;
                    }
                    else if (originalRole == "BranchManager")
                    {
                        rdoBranchManager.Checked = true;
                    }
                    lblMark.Text = lblID.Text;


                }
            }

            if (e.CommandName == "delete")
            {
                if (String.IsNullOrEmpty(lblID.Text) == false)
                {
                    Guid ID = new Guid(lblID.Text);
                    dao.changeUser(ID);
                }
                InitDgInfo();
            }
        }
    }
}
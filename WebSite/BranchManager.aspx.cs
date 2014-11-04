using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Entitys;
using DataAccess;

namespace ERP
{
    public partial class BranchManager : System.Web.UI.Page
    {
        public Guid BranchManageID
        {
            get
            {
                if (Session["CurrentUser"] != null)
                {
                    UserModel model = Session["CurrentUser"] as UserModel;
                    return model.ID;
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                InitDgInfo();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            InitDgInfo();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserDA dao = new UserDA();



            if (String.IsNullOrEmpty(lblMark.Text) == false)
            {
                Guid ID = new Guid(lblMark.Text);
                UserModel model = dao.GetUserModel(ID);

                UserModel existsCodeUserModel = dao.VerificationAccountCode(txtAccountCode.Text, ID);
                UserModel existsNameUserModel = dao.VerificationUsername(txtUsername.Text, ID);
                if (existsCodeUserModel.ID == Guid.Empty && existsNameUserModel.ID == Guid.Empty)
                {
                    dao.changeUser(txtUsername.Text, txtPassword.Text, txtName.Text, model.Role, txtAccountCode.Text, txtPhone.Text, txtEmail.Text, ID);
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
                    model.ParentID = BranchManageID;
                    model.Role = "AGT";
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

        private void InitDgInfo()
        {
            UserDA dao = new UserDA();
            List<UserModel> models = dao.GetParentID(BranchManageID, txtUsername.Text, txtPassword.Text,
                txtAccountCode.Text, txtName.Text, txtEmail.Text, txtPhone.Text);
            DGInfo.DataSource = models;
            DGInfo.DataBind();

            for (int i = 0; i < DGInfo.Items.Count; i++)
            {
                Label lblID = (Label)DGInfo.Items[i].FindControl("lblID");
                ImageButton btnDelete = (ImageButton)DGInfo.Items[i].FindControl("btnDelete");
                if (String.IsNullOrEmpty(lblID.Text) == false)
                {
                    Guid branchManageID = new Guid(lblID.Text);
                    if (branchManageID == BranchManageID)
                    {
                        btnDelete.Visible = false;
                    }
                }
            }
        }

        protected void DGInfo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            UserDA dao = new UserDA();
            Label lblID = (Label)e.Item.FindControl("lblID");
            if (e.CommandName == "edit")
            {
                if (String.IsNullOrEmpty(lblID.Text) == false)
                {
                    lblMark.Text = lblID.Text;
                    Guid ID = new Guid(lblID.Text);
                    UserModel model = dao.GetUserModel(ID);

                    txtUsername.Text = model.Username;
                    txtPassword.Text = model.Password;
                    txtName.Text = model.RealName;
                    txtAccountCode.Text = model.AccountCode;
                    txtEmail.Text = model.Email;
                    txtPhone.Text = model.Telephone;
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

        private void clear()
        {
            txtName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtAccountCode.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }
    }
}
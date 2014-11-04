using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using DataAccess;

using System.Text.RegularExpressions;
using System.Data.SqlClient;
using DataAccess.Entitys;

namespace ERP.info
{
    public partial class login : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {              
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;

            UserDA dao = new UserDA();
            UserModel model = dao.Verification(username, password);
            if (model.ID != Guid.Empty)
            {
                Session["CurrentUser"] = model;
                Page.Response.Redirect("Home.aspx");
            }
            else
            {
                lblMessage.Text = "用户名或密码错误,请重新登录!";
            }

        }

       

    }
}
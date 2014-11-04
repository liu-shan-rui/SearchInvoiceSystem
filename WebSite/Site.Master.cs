using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using DataAccess.Collection;
using DataAccess.Entitys.SystemStore;
using DataAccess.Entitys;

namespace ERP
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["CurrentUser"] != null)
            {
                UserModel user = (UserModel)Session["CurrentUser"];
                if (user.Role == "AGT")
                {
                    tvMenuAGT.Visible = true;
                    tvMenuACT.Visible = false;
                }
                else
                {
                    tvMenuAGT.Visible = false;
                    tvMenuACT.Visible = true;
                }
            }
            else
            {
                Page.Response.Redirect("login.aspx");
            }

            if (!IsPostBack)
            {
                
            }
        }
   

        //private void InitMenu()
        //{
        //    String SourceCode = this.Page.Request["Code"];
        //    BasePage bp = new BasePage();
        //    TreeNode Node = bp.GetMenu(SourceCode);
        //    tvMenu.Nodes.Add(Node);
        //    tvMenu.ExpandAll();



        //}

        private void InitMenu(Guid MasterMenuID)
        {
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
           
        }

        protected void repMenu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           
        }
    }
}

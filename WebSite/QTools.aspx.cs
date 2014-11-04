using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERP.WSPANWS;

namespace ERP
{
    public partial class QTools : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<String> QTo(String[] RLs)
        {
            WorldSpanwsService Client = new WorldSpanwsService();

            List<String> Messages = new List<String>();

            String sid = "V88";
            String sessionNumber = Client.createSession(sid);

            foreach (String RL in RLs)
            {


                String Message = "QEP " + RL + " -> " + "V88/25【QEP/V88/25】";

                String Res = Client.execute("*" + RL, sessionNumber, sid);

                if (Res.Length > 100)
                {
                    String QEPResult = Client.execute("QEP/V88/25", sessionNumber, sid);
                    Message = Message + " - > OK. ";
                }
                else
                {
                    Message = Message + " - > Error.";
                }

                Messages.Add(Message);
            }


            String closeResult = Client.closeSession(sessionNumber, sid);

            return Messages;
        }


        protected void btnExecute_Click(object sender, EventArgs e)
        {         
            String[] RLs = this.txtRecordLocators.Text.Split(',');
            List<String> Messages = this.QTo(RLs);
            DGInfo.DataSource = Messages;
            DGInfo.DataBind();
        }
    }
}
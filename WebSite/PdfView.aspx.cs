using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataAccess;
using Business.Entity;
using System.IO;
using System.Globalization;

using iTextSharp.text;
using iTextSharp.text.pdf;


namespace ERP
{
    public partial class PdfView : System.Web.UI.Page
    {
        private String pdfUrl
        {
            get
            {
                if (Request["pdfurl"] != null)
                {
                    return Request["pdfurl"].ToString();
                }
                return string.Empty;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(pdfUrl))
            {
                Response.Redirect(pdfUrl);
            }
            else
            {
                Response.Write("PDF CREATE ERROR!");
            }

            if (!IsPostBack)
            {
                
            }
        }
    }
}
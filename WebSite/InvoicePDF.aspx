<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoicePDF.aspx.cs" Inherits="ERP.InvoicePDF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="box_title">
        Invoice PDF
    </div>
    <div class="accountInfo">
        <fieldset>
            <table cellspacing="2" cellpadding="2" border="0" style="color: #333333; width: 99%;
                border-collapse: collapse; font-weight: normal; word-break: break-all;">
                <tr>
                    <td>
                        Mail Address:
                    </td>
                    <td style="width: 60%;">
                        <asp:TextBox ID="txtMailAddress" runat="server" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMail" runat="server" ErrorMessage="*" ForeColor="Red"
                            ControlToValidate="txtMailAddress" ValidationGroup="Mail"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revMail" runat="server" ControlToValidate="txtMailAddress"
                            ForeColor="Red" ErrorMessage="Please enter a valid email address" ValidationGroup="Mail"
                            ValidationExpression="^\s*([A-Za-z0-9_-]+(\.\w+)*@([\w-]+\.)+\w{2,3})\s*$"></asp:RegularExpressionValidator>
                    </td>
                    <td align="right" style="width: 20%;">
                        <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" ValidationGroup="Mail" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMsg" Visible="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                    <td colspan="2" align="right">
                        <asp:HiddenField ID="hfPDFUrl" runat="server" />
                        <asp:HiddenField ID="hfPaxName" runat="server" />
                        <asp:HiddenField ID="hfInvoiceNumber" runat="server" />
                        <asp:HiddenField ID="hfInvoiceDate" runat="server" />
                        <asp:HyperLink ID="hlkShow" runat="server">Show Invoice</asp:HyperLink>
                        <%--<asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />--%>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    </form>
</body>
</html>

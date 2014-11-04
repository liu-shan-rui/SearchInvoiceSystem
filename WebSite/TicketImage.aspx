<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketImage.aspx.cs" Inherits="ERP.TicketImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>TicketImage</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="passengerName" runat="server" />
        <asp:HiddenField ID="travellingDate" runat="server"/>
        <asp:HiddenField ID="attachmentsPath" runat="server"/>
        <div>
            <asp:Image ID="ticketImage" runat="server" />
        </div>
        
        <br />
        &nbsp;&nbsp;<asp:Label Text="Email Address" runat="server"></asp:Label>&nbsp;&nbsp;
        <asp:TextBox ID="EmailAddress" runat="server" Width="300"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button Text="Send" runat="server" ID="btnSendMail" 
            onclick="btnSendMail_Click" />&nbsp;&nbsp;<asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label>
        
    </form>
</body>
</html>

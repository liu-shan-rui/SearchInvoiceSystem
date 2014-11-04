<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SearchbyAgt.aspx.cs" Inherits="ERP.SearchbyAgt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box_title">
        Invoice Search
    </div>
    <div class="accountInfo">
        <fieldset>
            <table cellspacing="2" cellpadding="2" border="0" style="color: #333333; width: 99%;
                border-collapse: collapse; font-weight: normal; word-break: break-all;">
                <tr>
                    <td>
                        R/L
                    </td>
                    <td>
                        <asp:TextBox ID="txtRecordLocator" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Branch:
                    </td>
                    <td>
                        <asp:TextBox ID="txtBranch" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Ticket #:
                    </td>
                    <td>
                        <asp:TextBox ID="txtTicketNumber" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Pax Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtPaxName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        AccountCode :
                    </td>
                    <td>
                        <asp:TextBox ID="txtAccountCode" runat="server" ></asp:TextBox>
                    </td>
                    <td>
                        AgentCode:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAgentCode" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Invoice From :
                    </td>
                    <td>
                        <asp:TextBox ID="txtInvoiceFrom" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Invoice To:
                    </td>
                    <td>
                        <asp:TextBox ID="txtInvoiceTo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Issue Date From:
                    </td>
                    <td>
                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="date_class"></asp:TextBox>
                    </td>
                    <td>
                        Issue Date To:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="date_class"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="btnSearch" runat="server" Text=" Search " OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div class="box_title">
        Invoice List
    </div>
    <div class="accountInfo">
        <fieldset>
          <%--  <asp:LinkButton ID="btnPrePage" runat="server" OnClick="btnPrePage_Click" Visible="false">Pre</asp:LinkButton>
            <asp:DataList ID="dlPageNumber" runat="server" OnItemDataBound="dlPageNumber_ItemDataBound"
                RepeatDirection="Horizontal" RepeatLayout="Flow" OnItemCommand="dlPageNumber_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="btnPage"></asp:LinkButton>
                </ItemTemplate>
            </asp:DataList>
            <asp:LinkButton ID="btnNextPage" runat="server" OnClick="btnNextPage_Click" Visible="false">Next</asp:LinkButton>--%>
            <asp:GridView ID="InvList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                Style="font-weight: normal; word-break: break-all;" GridLines="None" Width="99%"
                ForeColor="#333333"  OnRowDataBound="InvList_RowDataBound">
                <Columns>
                    <asp:BoundField Visible="False" DataField="InvoiceID" HeaderText=""></asp:BoundField>
                    <asp:BoundField Visible="False" DataField="TicketID" HeaderText=""></asp:BoundField>
                    <asp:BoundField DataField="RowIndex" HeaderText="Idx"></asp:BoundField>
                    <asp:BoundField DataField="BranchCode" HeaderText="Branch"></asp:BoundField>
                    <asp:BoundField DataField="AgentCode" HeaderText="Agent"></asp:BoundField>
                    <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" DataFormatString="{0:MM/dd/yyyy}"></asp:BoundField>
                    <asp:BoundField DataField="InvoiceNumber" HeaderText="Inv #"></asp:BoundField>
                    <asp:BoundField DataField="PaxName" HeaderText="Pax Name"></asp:BoundField>
                 
                    <asp:BoundField DataField="TicketNumber" HeaderText="Ticket #"></asp:BoundField>
                   <%-- <asp:BoundField DataField="GttSellingPrice" HeaderText="Selling"></asp:BoundField>
                    <asp:BoundField DataField="Charge" HeaderText="Charge"></asp:BoundField>
                    <asp:BoundField DataField="CreditAmount" HeaderText="Credit"></asp:BoundField>
                    <asp:BoundField DataField="DebitAmount" HeaderText="Debit Amt"></asp:BoundField>
                    <asp:BoundField DataField="Profit" HeaderText="Profit"></asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>--%>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="lnkInvImg" Target="INV_PDF">
                             <img border="0" src="image/ticketImage.gif" alt="View Invoice" />
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="lnkInvPdf" Target="INV_PDF">
                              <img border="0" src="image/view.gif" alt="View Invoice" />
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                 
                </Columns>
                </asp:GridView>
        </fieldset>
    </div>
</asp:Content>

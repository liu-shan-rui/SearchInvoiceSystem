<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CustomerInvoiceSearch.aspx.cs" Inherits="ERP.CustomerInvoiceSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box_title">
        Ticket Search
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
                        AccountCode :
                    </td>
                    <td>
                        <asp:TextBox ID="txtAccountCode" runat="server"></asp:TextBox>
                    </td>


                    <td>
                        
                    </td>
                    <td>
                       
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
        Ticket List
    </div>
    <div class="accountInfo">
        <fieldset>
            <asp:DataGrid ID="DGInfo" runat="server" AutoGenerateColumns="False" CellPadding="4"
                Style="font-weight: normal; word-break: break-all;" GridLines="None" Width="99%"
                ForeColor="#333333" onitemdatabound="DGInfo_ItemDataBound">
                <Columns>

                    


                    <asp:BoundColumn DataField="RowIndex" HeaderText="Idx"></asp:BoundColumn>


                    <asp:BoundColumn DataField="RecordLocator" HeaderText="R/L"></asp:BoundColumn>
                    <asp:BoundColumn Visible="False" DataField="InvoiceID" HeaderText=""></asp:BoundColumn>
                    <asp:BoundColumn Visible="False" DataField="InvoiceNumber" HeaderText="INV #"></asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="INV #">
                        <ItemTemplate>
                        <%--<asp:LinkButton runat="server" ID="lkbInvoice"></asp:LinkButton>--%>
                        <asp:HyperLink ID="lnkInvoiceShow" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                     <asp:TemplateColumn>
                        <ItemTemplate>
                        <asp:Label ID="Label1" Text='<%#Eval("TicketID")%>' runat="server" Visible="false"></asp:Label>
                        

                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="TicketNumber" HeaderText="Ticket#"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PassengerName" HeaderText="Pax Name"></asp:BoundColumn>
                    <asp:BoundColumn DataField="BaseFare" HeaderText="Base"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Tax" HeaderText="Tax"></asp:BoundColumn>
                    <asp:BoundColumn DataField="GttSellingPrice" HeaderText="Selling"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Comm" HeaderText="Comm"></asp:BoundColumn>
                    <asp:BoundColumn DataField="AccountCode" HeaderText="AC"></asp:BoundColumn>
                    <asp:BoundColumn DataField="BranchCode" HeaderText="Branch"></asp:BoundColumn>
                    <asp:BoundColumn DataField="InvoiceDate" HeaderText="Issue Date"></asp:BoundColumn>
                </Columns>
                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                <ItemStyle HorizontalAlign="Left" Font-Size="13px" BackColor="#F7F6F3" ForeColor="#333333" />
                <HeaderStyle HorizontalAlign="Left" Font-Bold="true" BackColor="#5D7B9D" ForeColor="White"
                    Font-Size="13px" />
                <EditItemStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            </asp:DataGrid>
        </fieldset>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="WLInvoiceSearch.aspx.cs" Inherits="ERP.WLInvoiceSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box_title">
        Invoice Search Condition
    </div>
    <div class="accountInfo">
        <fieldset>
            <table cellspacing="2" cellpadding="2" border="0" style="color: #333333; width: 99%;
                border-collapse: collapse; font-weight: normal; word-break: break-all;">
                <tr>
                    <td>
                       选择需要核对的Excel文件
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload" runat="server" />
                        
                    </td>
                    <td>
                       
                    </td>
                    <td>
                        
                    </td>
                </tr>
               
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="btn" runat="server" Text="开始比对" onclick="btn_Click" />
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
            <asp:DataGrid ID="DGInfo" runat="server" AutoGenerateColumns="False" CellPadding="4"
                Style="font-weight: normal; word-break: break-all;" GridLines="None" Width="99%"
                ForeColor="#333333">
                <Columns>
                   <%-- <asp:BoundColumn DataField="RowIndex" HeaderText="Idx"></asp:BoundColumn>--%>
                    <asp:BoundColumn DataField="ReacordLocator" HeaderText="R/L"></asp:BoundColumn>
                    <asp:BoundColumn DataField="InvoiceNumber" HeaderText="INV #"></asp:BoundColumn>
                    <asp:BoundColumn DataField="TicketNumber" HeaderText="Ticket#"></asp:BoundColumn>
                     <asp:BoundColumn DataField="Status" HeaderText="Status"></asp:BoundColumn>
                      <asp:BoundColumn DataField="READING" HeaderText="Readed"></asp:BoundColumn>
                   
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

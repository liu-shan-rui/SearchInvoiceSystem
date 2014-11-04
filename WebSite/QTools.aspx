<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="QTools.aspx.cs" Inherits="ERP.QTools" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box_title">
        Q Tools
    </div>
    <div class="accountInfo">
        <fieldset>
            <table cellspacing="2" cellpadding="2" border="0" style="color: #333333; width: 99%;
                border-collapse: collapse; font-weight: normal; word-break: break-all;">
                <tr>
                    <td style="width: 90px">
                        R/L【,】:
                    </td>
                    <td>
                        <asp:TextBox ID="txtRecordLocators" runat="server" TextMode="MultiLine" Rows="4"
                            Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="btnExecute" runat="server" Text="QEP/V88*25" OnClick="btnExecute_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>

        <div class="box_title">
        执行结果
    </div>

    <div class="accountInfo">
        <fieldset>
            <asp:DataGrid ID="DGInfo" runat="server" CellPadding="4"
                Style="font-weight: normal; word-break: break-all;" GridLines="None" Width="99%" ForeColor="#333333">
                <Columns>                                  
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

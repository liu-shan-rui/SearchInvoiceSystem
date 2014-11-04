<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SystemObjectMenuCollection.aspx.cs" Inherits="ERP.SystemObjectMenuCollection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="box_title">
        <asp:Label ID="lblInfoTitle" runat="server" Text="一级菜单卡片"></asp:Label>
    </div>
    <div class="accountInfo">
        <fieldset>
            <table cellspacing="2" cellpadding="2" border="0" style="color: #333333; width: 99%;
                border-collapse: collapse; font-weight: normal; word-break: break-all;">
                <tr>
                    <td>
                        显示名称：
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="textEntry"></asp:TextBox>
                    </td>
                    <td>
                        定位页面：
                    </td>
                    <td>
                        <asp:TextBox ID="txtURL" runat="server" CssClass="textEntry"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div class="box_title">
        <asp:Label ID="lblListTitle" runat="server" Text="一级菜单卡片列表"></asp:Label>
    </div>
    <div class="accountInfo">
        <table cellspacing="2" cellpadding="2" border="0" style="color: #333333; width: 99%;
            border-collapse: collapse; font-weight: normal; word-break: break-all;">
            <tr>
                <td>  
                    <asp:Button ID="btnCreate" runat="server" Text="新建" onclick="btnCreate_Click"/>
                    <asp:Button ID="btnEdit" runat="server" Text="编辑" onclick="btnEdit_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="删除"  
                        OnClientClick="return confirm('确定要屏蔽此信息');" runat="server" 
                        onclick="btnDelete_Click"/>
                </td>
            </tr>
        </table>
       
        <fieldset>
            <asp:DataGrid ID="DGInfo" runat="server" AutoGenerateColumns="False" CellPadding="4"
                Style="font-weight: normal; word-break: break-all;" GridLines="None" Width="99%"
                ForeColor="#333333">
                <Columns>
                    <asp:TemplateColumn Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("Entity.ID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn ItemStyle-Width="1%" HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkSelect" />
                        </ItemTemplate>
                    </asp:TemplateColumn>

                    <asp:TemplateColumn ItemStyle-Width="8%" HeaderText="主菜单">
                        <ItemTemplate>
                            <%#Eval("MasterMenuDA.Name")%>
                        </ItemTemplate>
                    </asp:TemplateColumn>

                    <asp:TemplateColumn ItemStyle-Width="8%" HeaderText="显示名称">
                        <ItemTemplate>
                            <%#Eval("Name")%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn ItemStyle-Width="8%" HeaderText="定位页面">
                        <ItemTemplate>
                            <%#Eval("URL")%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
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

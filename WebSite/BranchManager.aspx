<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BranchManager.aspx.cs" Inherits="ERP.BranchManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="box_title">
       Branch Manage
    </div>
    <div class="accountInfo">
        <fieldset>
            <table cellspacing="2" cellpadding="2" border="0" style="color: #333333; width: 99%;
                    border-collapse: collapse; font-weight: normal; word-break: break-all;">
                <tr>
                    <td>Username</td><td><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
                    <td>Password</td><td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>                
                <tr>
                    <td>RealName</td><td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                    <td>AccountCode</td><td><asp:TextBox ID="txtAccountCode" runat="server"></asp:TextBox></td>                    
                </tr>
                <tr>
                    <td>Email</td><td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                    <td>Telephone</td><td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>                    
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblException" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <asp:Label ID="lblMark" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                    <td colspan="2" align="right">                        
                        <asp:Button ID="btnSearch" runat="server" Text=" Search " 
                            onclick="btnSearch_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnSave" runat="server" Text=" Save " onclick="btnSave_Click" />&nbsp;&nbsp;
                    </td>                    
                </tr>
            </table>
        </fieldset>
   </div>

   <div class="box_title">
       Branch Manage
    </div>
    <div class="accountInfo">
        <fieldset>
            <asp:DataGrid ID="DGInfo" runat="server" AutoGenerateColumns="False" CellPadding="4"
                Style="font-weight: normal; word-break: break-all;" GridLines="None" 
                Width="99%" ForeColor="#333333" onitemcommand="DGInfo_ItemCommand">
                <Columns>                    
                    <asp:TemplateColumn HeaderText="ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="username">
                        <ItemTemplate>
                            <%#Eval("Username")%>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="password" HeaderText="Passeword"></asp:BoundColumn>
                    <asp:BoundColumn DataField="RealName" HeaderText="RealName"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Role" HeaderText="Role"></asp:BoundColumn>
                    <asp:BoundColumn DataField="AccountCode" HeaderText="AccountCode"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Telephone" HeaderText="Telephone"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Email" HeaderText="Email"></asp:BoundColumn>

                    <asp:TemplateColumn ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/image/edit.gif" CommandName="edit" AlternateText="编辑" />
                            <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/image/del.gif" CommandName="delete" AlternateText="删除" OnClientClick="return confirm('确定要屏蔽此信息');" />
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

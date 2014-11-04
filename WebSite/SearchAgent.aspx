<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SearchAgent.aspx.cs" Inherits="ERP.SearchAgent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box_title">
        Search Agent
    </div>
    <div class="accountInfo">
        <fieldset>
            <table cellspacing="2" cellpadding="2" border="0" style="color: #333333; width: 99%;
                border-collapse: collapse; font-weight: normal; word-break: break-all;">
                <tr>
                    <td>
                        User name
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Agent Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        ACC Code
                    </td>
                    <td>
                        <asp:TextBox ID="txtAccountCode" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Telephone
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Type
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRole" runat="server">
                            <asp:ListItem Value="">ALL</asp:ListItem>
                            <asp:ListItem Value="AGT">Agent</asp:ListItem>
                            <asp:ListItem Value="AGT">Subagent</asp:ListItem>
                            <asp:ListItem Value="BMN">Branch Manage</asp:ListItem>
                            <asp:ListItem Value="LAT">Accounting</asp:ListItem>
                            <asp:ListItem Value="LAT">Accounting Manage</asp:ListItem>
                          
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        &nbsp;
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
        Agent List
    </div>
    <div class="accountInfo">
        <fieldset>
            <asp:DataGrid ID="DGInfo" runat="server" AutoGenerateColumns="False" CellPadding="4"
                Style="font-weight: normal; word-break: break-all;" GridLines="None" Width="99%"
                ForeColor="#333333">
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
                    <asp:BoundColumn DataField="name" HeaderText="RealName"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Role" HeaderText="Role"></asp:BoundColumn>
                    <asp:BoundColumn DataField="AccountCode" HeaderText="AccountCode"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Telephone" HeaderText="Telephone"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Email" HeaderText="Email"></asp:BoundColumn>
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

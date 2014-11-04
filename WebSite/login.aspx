<%@ Page Title="" Language="C#" MasterPageFile="~/LoginSite.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ERP.info.login" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


  <div class="box_title">
        <asp:Label ID="lblUserLoad" runat="server" Text="用户登录" EnableViewState="false"></asp:Label>
    </div>

    <div class="accountInfo">
        <fieldset>
            <table border="0" style="width: 99%">
                <tr>
                    <td style="width: 23%">
                    </td>
                    <td align="left" style="width: 99%">
                        <table cellspacing="2" cellpadding="2" border="0" style="color: #333333; width: 60%;
                            border-collapse: collapse; azimuth: left; font-weight: normal; word-break: break-all;">
                            <tr>
                                <td align="center">
                                    UserName
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUsername" runat="server" CssClass="textEntry"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    Password
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="textEntry" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>


    
</asp:Content>

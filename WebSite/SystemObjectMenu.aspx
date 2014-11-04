<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SystemObjectMenu.aspx.cs" Inherits="ERP.SystemObjectMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="box_title">
        <asp:Label ID="lblInfoTitle" runat="server" Text="一级菜单资料卡"></asp:Label>
    </div>
    <div class="accountInfo">
        <fieldset>
            <table cellspacing="2" cellpadding="2" border="0" style="color: #333333; width: 99%;
                border-collapse: collapse; font-weight: normal; word-break: break-all;">

                 <tr>
                    <td>
                        一级菜单：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMasterMenuID" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                       &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>


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
                    <td  colspan="4" align="right">
                       <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" />
                        <asp:Button ID="btnSearch" runat="server" Text="查看列表" onclick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
           </table>
        </fieldset>
    </div>

</asp:Content>

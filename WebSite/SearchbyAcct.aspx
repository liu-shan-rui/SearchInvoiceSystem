<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SearchbyAcct.aspx.cs" Inherits="ERP.SearchbyAcct" %>

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
                        <asp:TextBox ID="txtAccountCode" runat="server"></asp:TextBox>
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
            <asp:LinkButton ID="btnPrePage" runat="server" OnClick="btnPrePage_Click" Visible="false">Pre</asp:LinkButton>
            <asp:DataList ID="dlPageNumber" runat="server" OnItemDataBound="dlPageNumber_ItemDataBound"
                RepeatDirection="Horizontal" RepeatLayout="Flow" OnItemCommand="dlPageNumber_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="btnPage"></asp:LinkButton>
                </ItemTemplate>
            </asp:DataList>
            <asp:LinkButton ID="btnNextPage" runat="server" OnClick="btnNextPage_Click" Visible="false">Next</asp:LinkButton>
            <asp:GridView ID="InvList" runat="server" AutoGenerateColumns="False" CellPadding="4"
                Style="font-weight: normal; word-break: break-all;" GridLines="None" Width="99%"
                ForeColor="#333333"  OnRowDataBound="InvList_RowDataBound">
                <Columns>
                    <asp:BoundField Visible="False" DataField="InvoiceID" HeaderText=""></asp:BoundField>
                    <asp:BoundField Visible="False" DataField="TicketID" HeaderText=""></asp:BoundField>
                    <asp:BoundField DataField="RowIndex" HeaderText="Idx"></asp:BoundField>
                    <asp:BoundField DataField="BranchCode" HeaderText="Branch"></asp:BoundField>
                    <asp:BoundField DataField="AgentCode" HeaderText="Agent"></asp:BoundField>
                    <asp:BoundField DataField="IssueDate" HeaderText="Issue Date"></asp:BoundField>
                    <asp:BoundField DataField="InvoiceNumber" HeaderText="Inv #"></asp:BoundField>
                    <asp:BoundField DataField="PaxName" HeaderText="Pax Name"></asp:BoundField>
                    <asp:TemplateField HeaderText="Pax Name">
                        <ItemTemplate>
                            <asp:GridView ID="PaxList" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                                BorderStyle="none" Width="100%" BorderWidth="0">
                                <Columns>
                                    <asp:BoundField DataField="PaxName" />
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TicketNumber" HeaderText="Ticket #"></asp:BoundField>
                    <asp:BoundField DataField="GttSellingPrice" HeaderText="Selling"></asp:BoundField>
                    <asp:BoundField DataField="Charge" HeaderText="Charge"></asp:BoundField>
                    <asp:BoundField DataField="CreditAmount" HeaderText="Credit"></asp:BoundField>
                    <asp:BoundField DataField="DebitAmount" HeaderText="Debit Amt"></asp:BoundField>
                    <asp:BoundField DataField="Profit" HeaderText="Profit"></asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
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
              <%-- <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                <ItemStyle HorizontalAlign="Left" Font-Size="13px" BackColor="#F7F6F3" ForeColor="#333333" />
                <HeaderStyle HorizontalAlign="Left" Font-Bold="true" BackColor="#5D7B9D" ForeColor="White"
                    Font-Size="13px" />
                <EditItemStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />--%>
            </asp:GridView>

            <%--<asp:GridView ID="InvList" runat="server" AutoGenerateColumns = "false" CssClass="result_Table" Width="100%" 
                                             AllowSorting="True" OnSorting="InvList_Sorting" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="InvList_RowDataBound" OnRowCommand="InvList_RowCommand">
                                            <Columns>

                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnClearChanged" runat="server" ImageUrl="images/changed.gif" CommandName="CLR_CHG"/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Inv No.▼" DataField="InvoiceNo"  SortExpression="INV_NO"/>
                                                <asp:BoundField HeaderText="Issue Date ▼" DataField="TicketTime" DataFormatString="{0:MM/dd/yyyy}" SortExpression="TKT_DATE"/>
                                                <asp:BoundField HeaderText="Client Code" DataField="AccountCode" />
                                                <asp:TemplateField HeaderText = "Passenger">
                                                    <ItemTemplate>
                                                        <asp:GridView ID="PaxList" runat="server" AutoGenerateColumns="false" ShowHeader="false" 
                                                                BorderStyle="none" Width="100%" BorderWidth="0">
                                                            <Columns>
                                                                <asp:BoundField DataField="PassengerName" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="RL" DataField="recordlocator"/>
                                                <asp:TemplateField HeaderText = "Ticket No.">
                                                    <ItemTemplate>
                                                        <asp:GridView ID="TktList" runat="server" AutoGenerateColumns="false" ShowHeader="false" 
                                                                BorderStyle="none" Width="100%" BorderWidth="0" OnRowDataBound = "TktList_RowDataBound">
                                                            <Columns>
                                                                <asp:BoundField DataField="TicketNumber" />
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink runat="server" ID="lnkTktImage" Target="TKT_IMAGE">
                                                                            <img border="0" src="Images/ticketImage.gif" alt="Show Ticket Image" />
                                                                        </asp:HyperLink>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText = "INV AMOUNT">
                                                    <ItemTemplate>
                                                        <asp:GridView ID="SpList" runat="server" AutoGenerateColumns="false" ShowHeader="false" 
                                                                BorderStyle="none" Width="100%" BorderWidth="0"  OnRowDataBound = "SpList_RowDataBound">
                                                            <Columns>
                                                                <asp:BoundField DataField="SellingPrice" ItemStyle-HorizontalAlign="right"/>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText = "CLIENT CHARGE">
                                                    <ItemTemplate>
                                                        <asp:GridView ID="CcList" runat="server" AutoGenerateColumns="false" ShowHeader="false" 
                                                                BorderStyle="none" Width="100%" BorderWidth="0" OnRowDataBound = "CcList_RowDataBound">
                                                            <Columns>
                                                                <asp:BoundField DataField="Charge" ItemStyle-HorizontalAlign="right"/>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="INVOICE BALANCE" DataField=""  ItemStyle-HorizontalAlign="right"/>
                                                <asp:BoundField HeaderText="" DataField=""  ItemStyle-HorizontalAlign="right" Visible="false"/>
                                                <asp:BoundField HeaderText="" DataField=""  ItemStyle-HorizontalAlign="right" Visible="false"/>
                                                <asp:BoundField HeaderText="" DataField=""  Visible="false"/>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:HyperLink runat="server" ID ="lnkInvPdf" Target="INV_PDF">
                                                             <img border="0" src="Images/view.gif" alt="View Invoice" />
                                                        </asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:HyperLink runat="server" ID ="lnkInvEdit" Target="INV_EDIT">
                                                             <img border="0" src="Images/edit.gif" alt="Edit" />
                                                        </asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="LL" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnLoclLock" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CL" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnCentLock" runat="server"/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <AlternatingRowStyle BackColor="#FFFFCC" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        </asp:GridView>--%>

        </fieldset>
    </div>
</asp:Content>

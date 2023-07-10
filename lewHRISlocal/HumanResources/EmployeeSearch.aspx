<%@ Page Title="Human Resources - Employee Search Results" Language="C#" MasterPageFile="~/HumanResources/HRSite.Master" AutoEventWireup="true" CodeBehind="EmployeeSearch.aspx.cs" Inherits="lewHRISlocal.HumanResources.EmployeeSearch" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <br />
    <h2>Employee Search Results</h2>
    <asp:Button ID="btnBack" runat="server" Text="&laquo; Back" OnClientClick="JavaScript:window.history.back(1); return false;" CssClass="w3-btn w3-light-grey w3-ripple w3-round-large"/>
    <br />
    <br />
    
        <asp:TextBox ID="CounselingRecord" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>

        <asp:GridView ID="mydatagrid" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" DataKeyNames="EE" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="mydatagrid_PageIndexChanging" CssClass="mydatagrid">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton1_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="EE" HeaderText="Employee ID" ReadOnly="True" SortExpression="EE"/>
            <asp:BoundField DataField="EE_Name" HeaderText="Employee Name" ReadOnly="True" SortExpression="EE_Name" />
            <asp:BoundField DataField="Cost_Center_Description" HeaderText="Department" ReadOnly="True" SortExpression="Cost_Center_Description" />
            <%--<asp:TemplateField>--%>
                <%--<ItemTemplate>--%>
<%--                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select" Text="Void" OnClick="LinkButton3_Click"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandName="Select" Text="Documents" OnClick="LinkButton5_Click"></asp:LinkButton>--%>
                    <%--<asp:LinkButton ID="lnkSelectRow" runat="server" CausesValidation="False" CommandName="Select" Text="Void" OnClientClick="confirmDelete()"></asp:LinkButton>--%>
                <%--</ItemTemplate>--%>
            <%--</asp:TemplateField>--%>
        </Columns>

        <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
            <PagerStyle BackColor="#FF9933" Font-Size="12px" Height="12px" />
        <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
                <SelectedRowStyle BackColor="#FF6600" />
    </asp:GridView>
    
    
    <hr style="border-width: 3px; border-color: #000000" />
    
    <br />
    <br />
    <br />
</asp:Content>

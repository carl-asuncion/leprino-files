﻿<%@ Page Title="Human Resources - Results" Language="C#" MasterPageFile="~/HumanResources/HRSite.Master" AutoEventWireup="true" CodeBehind="DashboardResultReview.aspx.cs" Inherits="lewHRISlocal.HumanResources.DashboardResultReview" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color: rgba(255, 255, 255, 0.6); padding: 10px;  border-radius: 10px;">
    <br />
    <h2>Dashboard Results</h2>
    <asp:Button ID="btnBack" runat="server" Text="&laquo; Back" PostBackUrl="~/HumanResources/HRDash.aspx" CssClass="w3-btn w3-light-grey w3-ripple w3-round-large"/>
    <br />
    <br />
    <h3>New Counseling for Review</h3>
    <asp:TextBox ID="CounselingRecord" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
    <asp:GridView ID="mydatagrid" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="mydatagrid_PageIndexChanging" OnDataBound="mydatagrid_DataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton1_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered" HeaderStyle-CssClass="myheader" />
            <asp:BoundField DataField="EE_Name" HeaderText="EE Name" ReadOnly="True" SortExpression="EE_Name"  HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False"  HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
            <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
            <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject"   HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_Level" HeaderText="Level" SortExpression="Counseling_Level"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
            <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
        </Columns>

    <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
        <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
    <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
            <SelectedRowStyle BackColor="#FF6600" />
    </asp:GridView>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    </div>
</asp:Content>

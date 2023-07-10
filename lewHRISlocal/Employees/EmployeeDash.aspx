<%@ Page Title="Employee Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeDash.aspx.cs" Inherits="lewHRISlocal.Employees.EmployeeDash" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2><strong>Employee Dashboard</strong></h2>
    <p>
        <asp:Label ID="WelcomeLabel" runat="server" Text="Label" Font-Italic="True"></asp:Label>
    </p>
    <br />
    <asp:Button ID="btnBack" runat="server" Text="&laquo; Back" OnClientClick="JavaScript:window.history.back(1); return false;"  CssClass="w3-btn w3-light-grey w3-ripple w3-round-large"/>
    <br />
    <br />
    <%--<h3>COUNSELING - Requires Acknowledgement</h3>
    <asp:TextBox ID="ReqAck" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
    <asp:GridView ID="mydatagrid" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="mydatagrid_PageIndexChanging" OnDataBound="mydatagrid_DataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select" OnClick="LinkButton1_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered"/>
            <asp:BoundField DataField="Supervisor_Name" HeaderText="Assigned Supervisor" ReadOnly="True" SortExpression="Supervisor_Name" />
            <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False" />
            <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" />
            <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" />
            <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject" />
            <asp:BoundField DataField="Counseling_Level" HeaderText="Corrective Action" SortExpression="Counseling_Level" />
            <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status"  Visible="False" />
        </Columns>

    <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
        <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
    <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
            <SelectedRowStyle BackColor="#FF6600" />
    </asp:GridView>

    <hr style="border-width: 3px; border-color: #000000" />
    <h3>DISCIPLINARY - Requires Acknowledgement</h3>
    <asp:TextBox ID="txtReqAckDA" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="GridView3_PageIndexChanging" OnDataBound="GridView3_DataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Select" Text="Select" OnClick="LinkButton4_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered"/>
            <asp:BoundField DataField="Supervisor_Name" HeaderText="Assigned Supervisor" ReadOnly="True" SortExpression="Supervisor_Name" />
            <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False" />
            <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" />
            <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" />
            <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject" />
            <asp:BoundField DataField="Counseling_Level" HeaderText="Corrective Action" SortExpression="Counseling_Level" />
            <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status"  Visible="False" />
        </Columns>

    <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
        <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
    <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
            <SelectedRowStyle BackColor="#FF6600" />
    </asp:GridView>

    <hr style="border-width: 3px; border-color: #000000" />--%>
    <h3>Counseling Records</h3>
    <asp:TextBox ID="CounselingRecords" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="GridView1_PageIndexChanging" OnDataBound="GridView1_DataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select" Text="Select" OnClick="LinkButton2_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered"/>
            <asp:BoundField DataField="Supervisor_Name" HeaderText="Assigned Supervisor" ReadOnly="True" SortExpression="Supervisor_Name" />
            <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False" />
            <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" />
            <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" />
            <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject" />
            <asp:BoundField DataField="Counseling_Level" HeaderText="Corrective Action" SortExpression="Counseling_Level" />
            <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status"  Visible="False" />
        </Columns>

    <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
        <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
    <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
            <SelectedRowStyle BackColor="#FF6600" />
    </asp:GridView>

    <hr style="border-width: 3px; border-color: #000000" />
    <h3>Disciplinary Records</h3>
    <asp:TextBox ID="DARecords" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="GridView2_PageIndexChanging" OnDataBound="GridView2_DataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select" Text="Select" OnClick="LinkButton3_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered"/>
            <asp:BoundField DataField="Supervisor_Name" HeaderText="Assigned Supervisor" ReadOnly="True" SortExpression="Supervisor_Name" />
            <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False" />
            <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" />
            <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" />
            <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject" />
            <asp:BoundField DataField="Counseling_Level" HeaderText="Corrective Action" SortExpression="Counseling_Level" />
            <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status"  Visible="False" />
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

</asp:Content>

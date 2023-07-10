<%@ Page Title="Part-Time Dash" Language="C#" MasterPageFile="~/HumanResources/HRSite.Master" AutoEventWireup="true" CodeBehind="PartTimeDash.aspx.cs" Inherits="lewHRISlocal.HumanResources.PartTime.PartTimeDash" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2>Part-Time Records</h2>
    
    <asp:Button ID="btnBack" runat="server" Text="&laquo; Back" PostBackUrl="~/HumanResources/HRDash.aspx" CssClass="btn btn-secondary"/>
    <br />
    <br />

    <h3>New Counseling Submissions</h3>
    <asp:TextBox ID="txtNewRecord" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
    <asp:GridView ID="mydatagrid" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="mydatagrid_PageIndexChanging" OnDataBound="mydatagrid_DataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton1_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered"/>
            <asp:BoundField DataField="EE_Name" HeaderText="Employee Name" ReadOnly="True" SortExpression="EE_Name" />
            <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False" />
            <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" />
            <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" />
            <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject" />
            <asp:BoundField DataField="Counseling_Level" HeaderText="Level" SortExpression="Counseling_Level" />
            <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status" />
        </Columns>

    <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
        <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
    <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
            <SelectedRowStyle BackColor="#FF6600" />
    </asp:GridView>

    <hr style="border-width: 3px; border-color: #000000" />
    <h3>Open Counseling Submissions</h3>
    <asp:TextBox ID="txtReceivedRecord" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="GridView1_PageIndexChanging" OnDataBound="GridView1_DataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton2_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered"/>
            <asp:BoundField DataField="EE_Name" HeaderText="Employee Name" ReadOnly="True" SortExpression="EE_Name" />
            <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False" />
            <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" />
            <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" />
            <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject" />
            <asp:BoundField DataField="Counseling_Level" HeaderText="Level" SortExpression="Counseling_Level" />
            <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status" />
        </Columns>

    <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
        <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
    <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
            <SelectedRowStyle BackColor="#FF6600" />
    </asp:GridView>

    <hr style="border-width: 3px; border-color: #000000" />
    <h3>Closed Counselings</h3>
    <asp:TextBox ID="txtClosedCounseling" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="GridView2_PageIndexChanging" OnDataBound="GridView2_DataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton3_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered"/>
            <asp:BoundField DataField="EE_Name" HeaderText="Employee Name" ReadOnly="True" SortExpression="EE_Name" />
            <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False" />
            <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" />
            <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" />
            <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject" />
            <asp:BoundField DataField="Counseling_Level" HeaderText="Level" SortExpression="Counseling_Level" />
            <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status" />
        </Columns>

    <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
        <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
    <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
            <SelectedRowStyle BackColor="#FF6600" />
    </asp:GridView>

    <hr style="border-width: 3px; border-color: #000000" />
    <h3>Formal Disciplinary Actions Records</h3>
    <asp:TextBox ID="txtDisciplinaryRecord" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="GridView3_PageIndexChanging" OnDataBound="GridView3_DataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton4_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered"/>
            <asp:BoundField DataField="EE_Name" HeaderText="Employee Name" ReadOnly="True" SortExpression="EE_Name" />
            <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False" />
            <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" />
            <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" />
            <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject" />
            <asp:BoundField DataField="Counseling_Level" HeaderText="Level" SortExpression="Counseling_Level" />
            <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status" />
        </Columns>

    <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
        <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
    <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
            <SelectedRowStyle BackColor="#FF6600" />
    </asp:GridView>

    <hr style="border-width: 3px; border-color: #000000" />
    <h3>Closed Disciplinary Actions Records</h3>
    <asp:TextBox ID="txtClosedDisciplinaryRecord" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="GridView4_PageIndexChanging" OnDataBound="GridView4_DataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton4_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered"/>
            <asp:BoundField DataField="EE_Name" HeaderText="Employee Name" ReadOnly="True" SortExpression="EE_Name" />
            <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False" />
            <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" />
            <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" />
            <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject" />
            <asp:BoundField DataField="Counseling_Level" HeaderText="Level" SortExpression="Counseling_Level" />
            <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LEW_HRIS_LocalConnectionString %>" SelectCommand="SELECT [Date_Incident], [EE_Name], [Counseling_Category], [Counseling_SubCategory], [Counseling_Subject], [Counseling_Count], [EE_Status], [Sup_Status], [Counseling_ID], [Supervisor_Name], [Overall Status] FROM [View_1] WHERE [EE_Status] = 'EE Acknowledged' AND [Sup_Status] = 'Sup Finalized' AND [HR_Status] = 'HR Sent' AND [Employee_Status] = 'Probationary'"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LEW_HRIS_LocalConnectionString %>" SelectCommand="SELECT [Date_Incident], [EE_Name], [Counseling_Category], [Counseling_SubCategory], [Counseling_Subject], [Counseling_Count], [EE_Status], [Sup_Status], [Counseling_ID], [Supervisor_Name], [Overall Status] FROM [View_1] WHERE [EE_Status] = 'EE Acknowledged' AND [Sup_Status] = 'Sup Finalized' AND ([HR_Status] = 'HR Received' OR [HR_Status] = 'HR Processing') AND [Employee_Status] = 'Probationary'"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:LEW_HRIS_LocalConnectionString %>" SelectCommand="SELECT [Date_Incident], [EE_Name], [Counseling_Category], [Counseling_SubCategory], [Counseling_Subject], [Counseling_Count], [EE_Status], [Sup_Status], [Counseling_ID], [Supervisor_Name], [Overall Status] FROM [View_1] WHERE [EE_Status] = 'EE Acknowledged' AND [Sup_Status] = 'Sup Finalized' AND [HR_Status] = 'HR Complete' AND [Employee_Status] = 'Probationary'"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:LEW_HRIS_LocalConnectionString %>" SelectCommand="SELECT [Date_Incident], [EE_Name], [Counseling_Category], [Counseling_SubCategory], [Counseling_Subject], [Counseling_Count], [EE_Status], [Sup_Status], [Counseling_ID], [Disciplinary_ID], [Supervisor_Name], [Overall Status] FROM [View_3] WHERE [Employee_Status] = 'Full-Time'"></asp:SqlDataSource>
</asp:Content>

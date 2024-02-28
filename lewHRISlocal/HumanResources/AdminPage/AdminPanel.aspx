<%@ Page Title="HRM Dashboard" Language="C#" MasterPageFile="~/HumanResources/HRSite.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="lewHRISlocal.HumanResources.AdminPage.AdminPanel" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color: rgba(255, 255, 255, 0.6); padding: 10px;  border-radius: 10px;">
    <br />
    
        <h2><strong>Admin Panel</strong></h2>
        <asp:Label ID="Label1" runat="server" Text="Label" Font-Italic="True"></asp:Label>
        
    
    
    <br />
    <%--<asp:Button ID="btnBack" runat="server" Text="&laquo; Back" PostBackUrl="~/HumanResources/HRDash.aspx" CssClass="w3-btn w3-light-grey w3-ripple w3-round-large"/>--%>
    <br />
    <br />


    <div class="w3-row">
        <button id="btnCorrectiveActionMatrix" runat="server" onserverclick="btnCorrectiveActionMatrix_ServerClick" 
            class="w3-btn w3-mynavy w3-ripple w3-round-large" title="Update Corrective Action Matrix" 
            style="font-size: 14px;"><i class="material-symbols-outlined w3-xxlarge w3-center" 
                style="vertical-align: middle;">background_grid_small</i> 
            <strong>Corrective Action Matrix</strong></button> <!--  onserverclick="" -->
    </div>
    <br />
    <div class="w3-row">
        <button id="btnManuallyAddCA" runat="server" onserverclick="btnManuallyAddCA_ServerClick" 
            class="w3-btn w3-mynavy w3-ripple w3-round-large" title="Manually Add Corrective Action" 
            style="font-size: 14px;"><i class="material-symbols-outlined w3-xxlarge w3-center" 
                style="vertical-align: middle;">add</i> <strong>Add Corrective Action</strong></button> <!--  onserverclick="" -->
    </div>
    <br />
    <div class="w3-row">
        <button id="btnManageTeam" runat="server" onserverclick="btnManageTeam_ServerClick" 
            class="w3-btn w3-mynavy w3-ripple w3-round-large" title="Manage Team" 
            style="font-size: 14px;"><i class="material-symbols-outlined w3-xxlarge w3-center" 
                style="vertical-align: middle;">settings_accessibility</i> <strong>Manage Team</strong></button> <!--  onserverclick="" -->
    </div>
    <%--<p>
        <button id="Button1" runat="server"  class="w3-btn w3-blue w3-ripple w3-round-large" title="Manage employee record" style="font-size: 14px;"><i class="material-symbols-outlined w3-xxlarge w3-center" style="vertical-align: middle;">background_grid_small</i> <strong>Corrective Action Matrix</strong></button> <!--  onserverclick="" -->
    </p>--%>
    <%--<h3>New Disciplinary Action Reports</h3>
    <asp:TextBox ID="txtNewRecord" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
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
            <asp:BoundField DataField="Counseling_Count" HeaderText="Level" SortExpression="Counseling_Count"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
            <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
        </Columns>

    <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
        <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
    <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
            <SelectedRowStyle BackColor="#FF6600" />
    </asp:GridView>

    <hr style="border-width: 3px; border-color: #000000" />
    <h3>Open Disciplinary Action Reports</h3>
    <asp:TextBox ID="txtReceivedRecord" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="GridView1_PageIndexChanging" OnDataBound="GridView1_DataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton2_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered" HeaderStyle-CssClass="myheader" />
            <asp:BoundField DataField="EE_Name" HeaderText="EE Name" ReadOnly="True" SortExpression="EE_Name"  HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False"  HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
            <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
            <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject"   HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_Count" HeaderText="Level" SortExpression="Counseling_Count"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
            <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
        </Columns>

    <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
        <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
    <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
            <SelectedRowStyle BackColor="#FF6600" />
    </asp:GridView>

    <hr style="border-width: 3px; border-color: #000000" />
    <h3>Pending Disciplinary Action Reports</h3>
    <asp:TextBox ID="txtPendingCounseling" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="GridView2_PageIndexChanging" OnDataBound="GridView2_DataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton3_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered" HeaderStyle-CssClass="myheader" />
            <asp:BoundField DataField="EE_Name" HeaderText="EE Name" ReadOnly="True" SortExpression="EE_Name"  HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False"  HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
            <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
            <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject"   HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_Count" HeaderText="Level" SortExpression="Counseling_Count"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
            <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
        </Columns>

    <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
        <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
    <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
            <SelectedRowStyle BackColor="#FF6600" />
    </asp:GridView>

    <hr style="border-width: 3px; border-color: #000000" />
    <h3>Closed Disciplinary Action Reports</h3>
    <asp:TextBox ID="txtClosedRecord" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="GridView3_PageIndexChanging" OnDataBound="GridView3_DataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton4_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered" HeaderStyle-CssClass="myheader" />
            <asp:BoundField DataField="EE_Name" HeaderText="EE Name" ReadOnly="True" SortExpression="EE_Name"  HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False"  HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
            <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
            <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject"   HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_Count" HeaderText="Level" SortExpression="Counseling_Count"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
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
    <br />--%>
    </div>
</asp:Content>

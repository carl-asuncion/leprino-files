<%@ Page Title="HRM Dashboard" Language="C#" MasterPageFile="~/HumanResources/HRSite.Master" AutoEventWireup="true" CodeBehind="ManageTeam.aspx.cs" Inherits="lewHRISlocal.HumanResources.AdminPage.ManageTeam" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.min.js'></script>
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <div style="background-color: rgba(255, 255, 255, 0.6); padding: 10px;  border-radius: 10px;">
    <br />
    
        <h2><strong>Manage Team</strong></h2>
        <asp:Label ID="Label1" runat="server" Text="Label" Font-Italic="True"></asp:Label>
        
    
    
    <br />
        <asp:Button ID="btnBack" runat="server" Text="&laquo; Back" PostBackUrl="~/HumanResources/AdminPage/AdminPanel.aspx" CssClass="w3-btn w3-light-grey w3-ripple w3-round-large"/>
    <br />
    <br />
    <div class="w3-row-padding">
      <div class="w3-col s3"><asp:Button ID="btnModifyMembers" runat="server" Text="Modify Members" OnClick="btnModifyMembers_Click" CssClass="w3-btn w3-round-medium w3-green w3-text-black w3-left w3-cell"/> </div>
      <div class="w3-col s3"><asp:Button ID="btnModifyTeam" runat="server" Text="Modify Assignments" OnClick="btnModifyTeam_Click" CssClass="w3-btn w3-round-medium w3-green w3-text-black w3-left w3-cell"/> </div>
      <div class="w3-col s6"></div>
    </div>
    <div class="w3-row-padding">
        
    </div>
<br />  
    <div class="w3-row" id="User1" runat="server">
        <div class="w3-container w3-cell w3-cell-top" style="width: 150px;">
            <div>
                <img runat="server" src="/Images/asuncica.jpg" style="width: 150px;" class="w3-round-large" id="i1"/>
            </div>
        </div>
        <div class="w3-container w3-cell w3-cell-middle">
                <asp:Label ID="L1" runat="server" Text=" " Font-Italic="False" Font-Size="20px" Font-Bold="True" Font-Underline="true"></asp:Label>
            <br />
                <asp:Repeater ID="Rpt1" runat="server">
                    <ItemTemplate>
                        <%--<asp:Label ID="Label1" runat="server" Text='<%# Container.ItemIndex + 1 %>' Font-Size="10px"></asp:Label>--%>
                        <%--<asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("Title") %>'  Font-Bold="True" Font-Size="12px" BorderStyle="None" Font-Underline="false" CssClass="w3-hover-none"></asp:HyperLink> <!-- NavigateUrl='<%# "~/DisplayBlog.aspx?id=" + Eval("Blog_ID") %>' -->--%>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Department_Group") %>' Font-Italic="False" Font-Size="14px" Font-Bold="True"></asp:Label>
                        <%--<asp:Label ID="Label1" runat="server" Text='<%# Eval("Body") %>'></asp:Label>--%>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <br />
                    </SeparatorTemplate>
                </asp:Repeater>
        </div>
    </div>
    <br />
    <div class="w3-row" id="User2" runat="server">
        <div class="w3-container w3-cell w3-cell-top" style="width: 150px;">
            <div>
                <img runat="server" src="/Images/asuncica.jpg" style="width: 150px;" class="w3-round-large" id="i2"/>
            </div>
        </div>
        <div class="w3-container w3-cell w3-cell-middle">
                <asp:Label ID="L2" runat="server" Text=" " Font-Italic="False" Font-Size="20px" Font-Bold="True" Font-Underline="true"></asp:Label>
            <br />
                <asp:Repeater ID="Rpt2" runat="server">
                    <ItemTemplate>
                        <%--<asp:Label ID="Label1" runat="server" Text='<%# Container.ItemIndex + 1 %>' Font-Size="10px"></asp:Label>--%>
                        <%--<asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("Title") %>'  Font-Bold="True" Font-Size="12px" BorderStyle="None" Font-Underline="false" CssClass="w3-hover-none"></asp:HyperLink> <!-- NavigateUrl='<%# "~/DisplayBlog.aspx?id=" + Eval("Blog_ID") %>' -->--%>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Department_Group") %>' Font-Italic="False" Font-Size="14px" Font-Bold="True"></asp:Label>
                        <%--<asp:Label ID="Label1" runat="server" Text='<%# Eval("Body") %>'></asp:Label>--%>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <br />
                    </SeparatorTemplate>
                </asp:Repeater>
        </div>
    </div>
    <br />
    <div class="w3-row" id="User3" runat="server">
        <div class="w3-container w3-cell w3-cell-top" style="width: 150px;">
            <div>
                <img runat="server" src="/Images/asuncica.jpg" style="width: 150px;" class="w3-round-large" id="i3"/>
            </div>
        </div>
        <div class="w3-container w3-cell w3-cell-middle">
                <asp:Label ID="L3" runat="server" Text=" " Font-Italic="False" Font-Size="20px" Font-Bold="True" Font-Underline="true"></asp:Label>
            <br />
                <asp:Repeater ID="Rpt3" runat="server">
                    <ItemTemplate>
                        <%--<asp:Label ID="Label1" runat="server" Text='<%# Container.ItemIndex + 1 %>' Font-Size="10px"></asp:Label>--%>
                        <%--<asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("Title") %>'  Font-Bold="True" Font-Size="12px" BorderStyle="None" Font-Underline="false" CssClass="w3-hover-none"></asp:HyperLink> <!-- NavigateUrl='<%# "~/DisplayBlog.aspx?id=" + Eval("Blog_ID") %>' -->--%>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Department_Group") %>' Font-Italic="False" Font-Size="14px" Font-Bold="True"></asp:Label>
                        <%--<asp:Label ID="Label1" runat="server" Text='<%# Eval("Body") %>'></asp:Label>--%>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <br />
                    </SeparatorTemplate>
                </asp:Repeater>
        </div>
    </div>
    <br />
    <div class="w3-row" id="User4" runat="server">
        <div class="w3-container w3-cell w3-cell-top" style="width: 150px;">
            <div>
                <img runat="server" src="/Images/asuncica.jpg" style="width: 150px;" class="w3-round-large" id="i4"/>
            </div>
        </div>
        <div class="w3-container w3-cell w3-cell-middle">
                <asp:Label ID="L4" runat="server" Text=" " Font-Italic="False" Font-Size="20px" Font-Bold="True" Font-Underline="true"></asp:Label>
            <br />
                <asp:Repeater ID="Rpt4" runat="server">
                    <ItemTemplate>
                        <%--<asp:Label ID="Label1" runat="server" Text='<%# Container.ItemIndex + 1 %>' Font-Size="10px"></asp:Label>--%>
                        <%--<asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("Title") %>'  Font-Bold="True" Font-Size="12px" BorderStyle="None" Font-Underline="false" CssClass="w3-hover-none"></asp:HyperLink> <!-- NavigateUrl='<%# "~/DisplayBlog.aspx?id=" + Eval("Blog_ID") %>' -->--%>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Department_Group") %>' Font-Italic="False" Font-Size="14px" Font-Bold="True"></asp:Label>
                        <%--<asp:Label ID="Label1" runat="server" Text='<%# Eval("Body") %>'></asp:Label>--%>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <br />
                    </SeparatorTemplate>
                </asp:Repeater>
        </div>
    </div>
    <br />
    <div class="w3-row" id="User5" runat="server">
        <div class="w3-container w3-cell w3-cell-top" style="width: 150px;">
            <div>
                <img runat="server" src="/Images/asuncica.jpg" style="width: 150px;" class="w3-round-large" id="i5"/>
            </div>
        </div>
        <div class="w3-container w3-cell w3-cell-middle">
                <asp:Label ID="L5" runat="server" Text=" " Font-Italic="False" Font-Size="20px" Font-Bold="True" Font-Underline="true"></asp:Label>
            <br />
                <asp:Repeater ID="Rpt5" runat="server">
                    <ItemTemplate>
                        <%--<asp:Label ID="Label1" runat="server" Text='<%# Container.ItemIndex + 1 %>' Font-Size="10px"></asp:Label>--%>
                        <%--<asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("Title") %>'  Font-Bold="True" Font-Size="12px" BorderStyle="None" Font-Underline="false" CssClass="w3-hover-none"></asp:HyperLink> <!-- NavigateUrl='<%# "~/DisplayBlog.aspx?id=" + Eval("Blog_ID") %>' -->--%>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Department_Group") %>' Font-Italic="False" Font-Size="14px" Font-Bold="True"></asp:Label>
                        <%--<asp:Label ID="Label1" runat="server" Text='<%# Eval("Body") %>'></asp:Label>--%>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <br />
                    </SeparatorTemplate>
                </asp:Repeater>
        </div>
    </div>
    <br />
    <div class="w3-row" id="User6" runat="server">
        <div class="w3-container w3-cell w3-cell-top" style="width: 150px;">
            <div>
                <img runat="server" src="/Images/asuncica.jpg" style="width: 150px;" class="w3-round-large" id="i6"/>
            </div>
        </div>
        <div class="w3-container w3-cell w3-cell-middle">
                <asp:Label ID="L6" runat="server" Text=" " Font-Italic="False" Font-Size="20px" Font-Bold="True" Font-Underline="true"></asp:Label>
                <br />
                <asp:Repeater ID="Rpt6" runat="server">
                    <ItemTemplate>
                        <%--<asp:Label ID="Label1" runat="server" Text='<%# Container.ItemIndex + 1 %>' Font-Size="10px"></asp:Label>--%>
                        <%--<asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("Title") %>'  Font-Bold="True" Font-Size="12px" BorderStyle="None" Font-Underline="false" CssClass="w3-hover-none"></asp:HyperLink> <!-- NavigateUrl='<%# "~/DisplayBlog.aspx?id=" + Eval("Blog_ID") %>' -->--%>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Department_Group") %>' Font-Italic="False" Font-Size="14px" Font-Bold="True"></asp:Label>
                        <%--<asp:Label ID="Label1" runat="server" Text='<%# Eval("Body") %>'></asp:Label>--%>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <br />
                    </SeparatorTemplate>
                </asp:Repeater>
        </div>
    </div>

        <asp:ListBox ID="ListBox1" runat="server" Visible="false    "></asp:ListBox>
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
    <script type="text/javascript">
        // Modal Send Request
        function showMeAdd() {
            //document.getElementById("img01").src = element.src;
            document.getElementById("id02").style.display = "block";
            //var captionText = document.getElementById("caption");
            //captionText.innerHTML = element.alt;
        }
    </script>
</asp:Content>

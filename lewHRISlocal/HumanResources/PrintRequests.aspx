<%@ Page Title="Human Resources - Print Requests" Language="C#" MasterPageFile="~/HumanResources/HRSite.Master" AutoEventWireup="true" CodeBehind="PrintRequests.aspx.cs" Inherits="lewHRISlocal.HumanResources.PrintRequests" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', '');
            printWindow.document.write('<html><head><title>Print Completed Form</title><link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>');
            printWindow.document.write('</head><body style="font-family: Arial; font-size: 12px; background-image: url("http://10.40.80.28:150/lewHRISlocal/SupportDocs/CONFIDENTIAL_WM.png");">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');

            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            
            return false;
          
        }

        function PrintPanel2() {
            var panel = document.getElementById("<%=pnlContents2.ClientID %>");
            var printWindow = window.open('', '', '');
            printWindow.document.write('<html><head><title>Print Completed Form</title><link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>');
            printWindow.document.write('</head><body style="font-family: Arial; font-size: 12px; background-image: url("http://10.40.80.28:150/lewHRISlocal/SupportDocs/CONFIDENTIAL_WM.png");">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');

            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);

            return false;

        }
    </script>
    <div style="background-color: rgba(255, 255, 255, 0.6); padding: 10px;  border-radius: 10px;">
    <br />
    <h2>Print Requests</h2>
    <asp:Button ID="btnBack" runat="server" Text="&laquo; Back" PostBackUrl="~/HumanResources/HRDash.aspx" CssClass="w3-btn w3-light-grey w3-ripple w3-round-large"/>
    <br />
    <br />
    <h3>Counseling - New Requests</h3>
    <asp:TextBox ID="CounselingRecord" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
    <div class="w3-right">
        <asp:Button ID="Print" runat="server" Text="Print Selected Item/s" CssClass="w3-btn w3-mynavy w3-ripple w3-round-large" OnClick="Print_Click"/>
    <br />
    <br />
    </div>
        
        <asp:GridView ID="mydatagrid" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" 
            HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" 
            AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" 
            PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="mydatagrid_PageIndexChanging" 
            OnDataBound="mydatagrid_DataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:checkbox ID="chkRow" runat="server"></asp:checkbox>
                    <%--<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select" Text="Select" OnClick="LinkButton3_Click"></asp:LinkButton>--%>
                    <%--<span onclick="document.getElementById('id01').style.display='block';" class="w3-button w3-transparent w3-text-black w3-hover-none" style="font-size: 10px;">Request to Print</span>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton1_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="PrintRequest_ID" HeaderText="Print Request ID" ReadOnly="True" SortExpression="PrintRequest_ID" HeaderStyle-CssClass="myheader" />
            <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" ReadOnly="True" SortExpression="Counseling_ID"  HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Request_Date" HeaderText="Request Date" SortExpression="Request_Date" HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="EE_Name" HeaderText="Employee Name" SortExpression="EE_Name"/>
        </Columns>

    <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
        <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
    <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
            <SelectedRowStyle BackColor="#FF6600" />
    </asp:GridView>
    <br />

    <h3>Disciplinary Actions - New Requests</h3>
    <asp:TextBox ID="TextBox1" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
    <div class="w3-right">
        <asp:Button ID="PrintCA" runat="server" Text="Print Selected Item/s" CssClass="w3-btn w3-mynavy w3-ripple w3-round-large" OnClick="PrintCA_Click"/>
    <br />
    <br />
    </div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" 
            HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" 
            AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" 
            PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="GridView1_PageIndexChanging" 
            OnDataBound="GridView1_DataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:checkbox ID="chkRow1" runat="server"></asp:checkbox>
                    <%--<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select" Text="Select" OnClick="LinkButton3_Click"></asp:LinkButton>--%>
                    <%--<span onclick="document.getElementById('id01').style.display='block';" class="w3-button w3-transparent w3-text-black w3-hover-none" style="font-size: 10px;">Request to Print</span>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton12" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton12_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="PrintRequest_ID" HeaderText="Print Request ID" ReadOnly="True" SortExpression="PrintRequest_ID" HeaderStyle-CssClass="myheader" />
            <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" ReadOnly="True" SortExpression="Counseling_ID"  HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Request_Date" HeaderText="Request Date" SortExpression="Request_Date" HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="EE_Name" HeaderText="Employee Name" SortExpression="EE_Name"/>
        </Columns>

    <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
        <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
    <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
            <SelectedRowStyle BackColor="#FF6600" />
    </asp:GridView>
    <br />
<%--    <h3>Print Request History</h3>
    <asp:TextBox ID="PRHistory" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>--%>
    <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="GridView1_PageIndexChanging" OnDataBound="GridView1_DataBound">
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
    </asp:GridView>--%>
    <br />
    <br />
    <br />
    <br />
    </div>
    <asp:Panel ID="pnlContents" runat="server" style="font-family: Arial; font-size: 12px; display: none;">
        <div style=" background-image:url('http://10.40.80.28:150/lewHRISlocal/SupportDocs/CONFIDENTIAL_WM.png'); background-position: center; background-size: 100%; background-repeat: repeat-y;">
   
        <div style="text-align: center">
            <h5>LEPRINO FOODS COMPANY | LEMOORE WEST FACILITY</h5>
            <h1>COUNSELING FORM</h1>
        </div>
        <hr style="border-width: 1px; border-color: #000000" />
        <div>
            <asp:TextBox ID="txtCounselingID" runat="server" style="border:none;width:200px;" Visible="false"></asp:TextBox>
            <asp:Table ID="Table1" runat="server"  style="font-family: Arial; font-size: 14px">
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="Label51" runat="server" Text="Date & Time of Incident: " Font-Bold="True"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtDateIncident" runat="server" style="border:none;width:200px;"></asp:TextBox></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label52" runat="server" Text="Employee Name: " Font-Bold="True"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtEmployeeName" runat="server" style="border:none;width:200px;"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="Label1" runat="server" Text="Department: " Font-Bold="True" BackColor="Transparent"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtDepartment" runat="server" style="border:none;width:200px;"></asp:TextBox></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label2" runat="server" Text="Department Manager: " Font-Bold="True" Visible="false"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtManager" runat="server" style="border:none;width:200px;" Visible="false"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <hr style="border-width: 1px; border-color: #000000" />
        <div>
            <h4>SUBJECT OF COUNSELING</h4>
            <p><asp:TextBox ID="txtSubject" runat="server" style="border:none;width:200px;" BackColor="Transparent"></asp:TextBox></p>
            <p>
                <asp:TextBox ID="txtSupComments" runat="server" style="height:200px;width:100%; font-family: Arial; " ReadOnly="True" Rows="10" TextMode="MultiLine" BackColor="Transparent"></asp:TextBox>
            </p>
            <h5>This documented counseling may be subjected to progressive disciplinary action upon management review.</h5>
        </div>
        <hr style="border-width: 1px; border-color: #000000" />
        <div>
            <h4>EMPLOYEE COMMENTS</h4>
            <p>
                <asp:TextBox ID="txtEmployeeComments" runat="server" style="height:100px;width:100%;font-family: Arial;" ReadOnly="True" Rows="10" TextMode="MultiLine" BackColor="Transparent"></asp:TextBox>
            </p>
        </div>
        <hr style="border-width: 1px; border-color: #000000" />
        <div>
            <h4>FOLLOW-UP</h4>
            <p>
                <asp:TextBox ID="txtFollowUp" runat="server" style="height:100px;width:100%" ReadOnly="True" Rows="10" TextMode="MultiLine" BackColor="Transparent"></asp:TextBox>
            </p>
        </div>
        <hr style="border-width: 1px; border-color: #000000" />
        <div>
            <h5>By signing this document the employee is only agreeing that he/she was present at the discussion and the above incident was discussed. It does not necessarily mean that the employee is in agreement with the determination.</h5>
        </div>
        <asp:Table ID="Table5" runat="server"  style="font-family: Arial; font-size: 12px" Font-Bold="True" BackColor="Transparent">
            <asp:TableRow HorizontalAlign="Center" BackColor="Transparent"> 
                <asp:TableCell> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtEEAck" runat="server" style="border:none;width:400px;border-bottom: 1px solid black;text-align:center;" BackColor="Transparent"></asp:TextBox><%--<asp:TextBox ID="txtEEAckUser" runat="server" style="border:none;width:200px;border-bottom: 1px solid black"></asp:TextBox>--%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%--<asp:TextBox ID="txtEEAckUser" runat="server" style="border:none;width:200px;border-bottom: 1px solid black"></asp:TextBox>--%></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtOverallStatus" runat="server" style="border:none;width:200px;" Visible="False" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtEEAckDate" runat="server" style="border:none;width:200px;border-bottom: 1px solid black;text-align: center" BackColor="Transparent"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center" BackColor="Transparent">
                <asp:TableCell><asp:Label ID="Label25" runat="server" Text="Employee Name & Signature" Font-Bold="True" BackColor="Transparent"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label21" runat="server" style="border:none;width:200px;" Text="Suspension Dates: " Visible="False" BackColor="Transparent"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label23" runat="server" Text="Date" Font-Bold="True" BackColor="Transparent"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="LabelWhat" runat="server" Text="Suspension Dates: " Visible="False"  BackColor="Transparent"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label27" runat="server" Text="Suspension Dates: " Visible="False" BackColor="Transparent"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtSupFin" runat="server" style="border:none;width:400px;border-bottom: 1px solid black;text-align:center;" ForeColor="Black" BackColor="Transparent"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TableCell>
                <asp:TableCell><asp:TextBox ID="none" runat="server" style="border:none;width:200px;" Visible="false" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtSupFinDate" runat="server" style="border:none;width:200px;border-bottom: 1px solid black;text-align: center" ForeColor="Black" BackColor="Transparent"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell><asp:Label ID="Label28" runat="server" Text="Supervisor/Manager Name & Signature" Font-Bold="True" BackColor="Transparent"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label29" runat="server" Text="Suspension Dates: " Visible="False" BackColor="Transparent"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label30" runat="server" Text="Date" Font-Bold="True" BackColor="Transparent"></asp:Label></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />
        <br />
        <br />
        <footer runat="server" style="font-family: Arial; font-size:10px;position: fixed;">
            <asp:Table ID="Table6" runat="server" Width="100%"  style="font-family: Arial; font-size: 12px">
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="Label46" runat="server" Text="Printed on: "></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="PrintedOn" runat="server" Text="" Width="150px"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label47" runat="server" Text="Printed by: "></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="PrintedBy" runat="server" Text="" Width="150px"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label48" runat="server" Text="Leprino Foods Company | Lemoore West Human Resources Department"></asp:Label></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </footer>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlContents2" runat="server" style="font-family: Arial; font-size: 10px;  display: none;">
        <div style=" background-image:url('/lewHRISlocal/SupportDocs/CONFIDENTIAL_WM.png'); background-position: center; background-size: 100%; background-repeat: repeat-y;">
    
    
    
        <div style="text-align: center">
            <h5>LEPRINO FOODS COMPANY | LEMOORE WEST FACILITY</h5>
            <h2>DISCIPLINARY ACTION FORM</h2>
        </div>
        <hr style="border-width: 1px; border-color: #000000" />
        <div>
            <asp:Table ID="Table2" runat="server"  style="font-family: Arial; font-size: 10px">
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="Label3" runat="server" Text="Employee Name: " Font-Bold="True" Font-Size="10px"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtEmployeeName2" runat="server" style="border:none;width:200px;" ReadOnly="True" Enabled="true" Font-Size="10px"></asp:TextBox></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label4" runat="server" Text="ID Number: " Font-Bold="True" Font-Size="10px"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtEmployeeID2" runat="server" style="border:none;width:200px;" ReadOnly="True" Enabled="true" Font-Size="10px"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="Label5" runat="server" Text="Position: " Font-Bold="True" Font-Size="10px"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtPosition2" runat="server" style="border:none;width:200px;" ReadOnly="True" Enabled="true" Font-Size="10px"></asp:TextBox></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label6" runat="server" Text="Department: " Font-Bold="True" Font-Size="10px"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtDepartment2" runat="server" style="border:none;width:200px;" ReadOnly="True" Enabled="true" Font-Size="10px"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="Label7" runat="server" Text="Date & Time of Incident: " Font-Bold="True" Font-Size="10px"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtDateIncident2" runat="server" style="border:none;width:200px;" ReadOnly="True" Enabled="true" Font-Size="10px"></asp:TextBox></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label8" runat="server" Text="Disciplinary ID: " Visible="false"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtCounselingID2" runat="server" style="border:none;width:200px;" Visible="false" ReadOnly="True" Enabled="true"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <hr style="border-width: 1px; border-color: #000000" />
        <div>
            <h4>CURRENT DISCIPLINARY LEVEL</h4>
            <h5>Management reserves the right to use appropriate discipline given the circumstances, up to and including termination.</h5>
            <div>
                <asp:Table ID="Table3" runat="server"  style="font-family: Arial; font-size: 12px">
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label9" runat="server" Text="$1000 or more in damage: " Font-Bold="True" Font-Size="10px"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox52" runat="server" style="border:none;width:200px;" ReadOnly="True" Enabled="false" Font-Size="10px" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label10" runat="server" Text="ID Number: " Visible="false"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox62" runat="server" class="txtboxes" Visible="false" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label15" runat="server" Text="ID Number: " Visible="false"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox72" runat="server" class="txtboxes" Visible="false" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <asp:Table ID="Table4" runat="server" CellPadding="2" CellSpacing="1" GridLines="vertical" BorderStyle="Solid" BorderWidth="1px" style="font-family: Arial; font-size: 12px">
                    <asp:TableRow Font-Bold="True" HorizontalAlign="Center">
                        <asp:TableCell><asp:Label ID="Label11" runat="server" Text="Write-Up Level" Height="20px" Font-Size="10px"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label12" runat="server" Text="1st Level Write-Up" Font-Size="10px"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label13" runat="server" Text="2nd Level Write-Up" Font-Size="10px"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label14" runat="server" Text="3rd Level Write-Up *" Font-Size="10px"></asp:Label></asp:TableCell>
                        <asp:TableCell ID="C11"><asp:Label ID="Label16" runat="server" Text="4th Level Write-Up" Font-Size="10px"></asp:Label></asp:TableCell>
                        <asp:TableCell ID="C21"><asp:Label ID="Label17" runat="server" Text="5th Level Write-Up" Font-Size="10px"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Font-Bold="True" HorizontalAlign="Center" GridLines="horizontal" Class="BottomLine">
                        <asp:TableCell><asp:Label ID="Label20" runat="server" Text="" Height="20px" Font-Bold="True"></asp:Label></asp:TableCell>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell><asp:Label ID="probL3" runat="server" Text="(1-Day Susp)" Font-Size="10px"></asp:Label></asp:TableCell>
                        <asp:TableCell ID="C12"><asp:Label ID="Label50" runat="server" Text="(2-Day Susp)" Font-Size="10px"></asp:Label></asp:TableCell>
                        <asp:TableCell ID="C22"><asp:Label ID="Label18" runat="server" Text="(Termination)" Font-Size="10px"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Center"><asp:Label ID="Label19" runat="server" Text="Date and Reasons" Height="30px" Font-Bold="True" Font-Size="10px"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox82" runat="server" Rows="2" style="border:none;height:20px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox92" runat="server" Rows="2" style="border:none;height:20px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox102" runat="server" Rows="2" style="border:none;height:20px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                        <asp:TableCell ID="C13"><asp:TextBox ID="TextBox112" runat="server" Rows="2" style="border:none;height:20px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                        <asp:TableCell ID="C23"><asp:TextBox ID="TextBox122" runat="server" Rows="2" style="border:none;height:20px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Center"><asp:Label ID="Label22" runat="server" Text="for Previous Discipline" Height="40px" Font-Bold="True" Font-Size="10px"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox132" runat="server" Rows="2" style="border:none;height:30px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox142" runat="server" Rows="2" style="border:none;height:30px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox152" runat="server" Rows="2" style="border:none;height:30px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                        <asp:TableCell ID="C14"><asp:TextBox ID="TextBox162" runat="server" Rows="2" style="border:none;height:30px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                        <asp:TableCell ID="C24"><asp:TextBox ID="TextBox172" runat="server" Rows="2" style="border:none;height:30px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <asp:Table ID="Table7" runat="server"  style="font-family: Arial; font-size: 12px">
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label24" runat="server" Text="Suspension Dates: " Font-Size="10px" Font-Bold="True"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox182" runat="server" style="border:none;width:400px;" ReadOnly="True" Enabled="false" Font-Size="10px" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label26" runat="server" Text="ID Number: " Visible="false"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox192" runat="server" Visible="false" ReadOnly="True" Enabled="false" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label31" runat="server" Text="RTW: " style="border:none;width:200px;" Font-Size="10px" Font-Bold="True"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox202" runat="server" style="border:none;width:200px;" ReadOnly="True" Enabled="false" Font-Size="10px" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <h5>*Group Leaders are required to keep their performance write-up step below three (3). In the event a Group Leader accumulates three (3) or more performance steps they will be removed from their Group Leader role. </h5>
            </div>
        </div>
        <hr style="border-width: 1px; border-color: #000000" />
        <div>
            <h4>INCIDENT DESCRIPTION</h4>
            <p>
                <asp:TextBox ID="txtSubject2" runat="server" style="width:100%" ReadOnly="True" TextMode="SingleLine" Rows="1"  Font-Size="10px" BackColor="Transparent"></asp:TextBox>
                <asp:TextBox ID="txtSupComments2" runat="server" style="height:100px;width:100%; font-family: Arial" ReadOnly="True" Rows="10" TextMode="MultiLine" Font-Size="10px" BackColor="Transparent"></asp:TextBox>
            </p>
        </div>
        <hr style="border-width: 1px; border-color: #000000" />
        <div>
            <h4>EMPLOYEE COMMENTS</h4>
            <p>
                <asp:TextBox ID="txtEmployeeComments2" runat="server" style="height:50px;width:100%" ReadOnly="True" Rows="10" TextMode="MultiLine" Font-Size="10px" BackColor="Transparent"></asp:TextBox>
            </p>
        </div>
        <hr style="border-width: 1px; border-color: #000000" />
        <div>
            <h5>By signing this document the employee is only agreeing that he/she was present at the discussion and the above incident was discussed. It does not necessarily mean that the employee is in agreement with the determination.</h5>
        </div>
        <asp:Table ID="Table8" runat="server"  style="font-family: Arial; font-size: 10px">
            <asp:TableRow HorizontalAlign="Center"> 
                <asp:TableCell><asp:TextBox ID="txtEEAck2" runat="server" style="border:none;width:400px;border-bottom: 1px solid black; text-align: center;" ReadOnly="True" Enabled="false" Font-Size="10px"></asp:TextBox></asp:TableCell>
                <%--textbox below is just to check for status before printing--%>
                <asp:TableCell><asp:TextBox ID="txtOverallStatus2" runat="server" style="border:none;width:100px;" Visible="False" Font-Size="10px"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtEEAckDate2" runat="server" style="border:none;width:200px;border-bottom: 1px solid black; text-align: center;" ReadOnly="True" Enabled="false" Font-Size="10px"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell><asp:Label ID="Label32" runat="server" Text="Employee Signature" Font-Bold="True"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label33" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label34" runat="server" Text="Date" Font-Bold="True"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="Label35" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label36" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label37" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell><asp:TextBox ID="txtSup1Ack2" runat="server" style="border:none;width:400px;border-bottom: 1px solid black; text-align: center;" ReadOnly="True" Enabled="false" Font-Size="10px"></asp:TextBox></asp:TableCell>
                <%--textbox below is just to check for EMPLOYEE status before printing--%>
                <asp:TableCell><asp:TextBox ID="txtEmployeeStatus2" runat="server" style="border:none;width:100px;" Visible="false"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtSup1AckDate2" runat="server" style="border:none;width:200px;border-bottom: 1px solid black; text-align: center;" ReadOnly="True" Enabled="false" Font-Size="10px"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell><asp:Label ID="Label38" runat="server" Text="Supervisor/Manager Signature" Font-Bold="True"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label39" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label40" runat="server" Text="Date" Font-Bold="True"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="Label41" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label42" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label43" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell><asp:TextBox ID="txtSup2Ack2" runat="server" style="border:none;width:400px;border-bottom: 1px solid black; text-align: center;" ReadOnly="True" Enabled="false" Font-Size="10px"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBox292" runat="server" style="border:none;width:100px;" Visible="false"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtSup2AckDate2" runat="server" style="border:none;width:200px;border-bottom: 1px solid black; text-align: center;" ReadOnly="True" Enabled="false" Font-Size="10px"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell><asp:Label ID="Label44" runat="server" Text="Supervisor/Manager Signature (Optional)" Font-Bold="True"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label45" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label49" runat="server" Text="Date" Font-Bold="True"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="Label53" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label54" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label55" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell><asp:TextBox ID="txtHRAck2" runat="server" style="border:none;width:400px;border-bottom: 1px solid black; text-align: center;" ReadOnly="True" Enabled="false" Font-Size="10px"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBox322" runat="server" style="border:none;width:100px"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtHRAckDate2" runat="server" style="border:none;width:200px;border-bottom: 1px solid black; text-align: center;" ReadOnly="True" Enabled="false" Font-Size="10px"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell><asp:Label ID="Label56" runat="server" Text="Human Resources Signature" Font-Bold="True"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label57" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label58" runat="server" Text="Date" Font-Bold="True"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblGetReferenceID2" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="lblGetDisciplinaryCount2" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="lblGetStatus2" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
   
        <br />
        <footer runat="server" style="font-family: Arial; font-size:8px;position: fixed;">
            <asp:Table ID="Table9" runat="server" Width="100%"  style="font-family: Arial; font-size: 8px">
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="Label59" runat="server" Text="Printed on: " Width="50px"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="PrintedOn2" runat="server" Text="" Width="125px"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label60" runat="server" Text="Printed by: " Width="50px"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="PrintedBy2" runat="server" Text="" Width="150px"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label61" runat="server" Text="Leprino Foods Company | Lemoore West Human Resources Department" Width="300px"></asp:Label></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </footer>
        </div>
    </asp:Panel>
    
        <!-- Modal -->

    <div id="id02" class="w3-modal w3-round-medium" >
      <div class="w3-modal-content w3-card-4 w3-animate-top w3-round-medium">
        <header class="w3-container w3-display-container w3-center w3-text-white" style="background-color: #1f66c9;"> 
          <span onclick="document.getElementById('id02').style.display='none'" class="w3-button w3-display-topright w3-hover-white myBack"><i class="fa fa-remove"></i></span>
          <%--<h4><strong>Leprino Foods Company, Lemoore West</strong></h4>--%>
          <h6>Print Confirmationn</h6>
        </header>
        <div class="w3-container">
            <br />
            <p>Did the document/s print successfully? </p>
            <br />
            <div class="w3-center">
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" CssClass="w3-btn w3-blue w3-round-medium w3-center" Font-Underline="False"><i class="material-symbols-outlined" style="vertical-align: middle;">done_all</i> Completed</asp:LinkButton>
                <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" CssClass="w3-btn w3-blue w3-round-medium w3-center" Font-Underline="False"><i class="material-symbols-outlined" style="vertical-align: middle;">tab_close</i> Cancel</asp:LinkButton>
            </div>
            <br />
        </div>
        <footer class="w3-container  w3-center w3-text-white myBack" style="padding: 5px; background-color: #1f66c9;">
          <p style="font-size: 10px;">Call your local HR office for any questions and/or concerns.</p>
        </footer>
      </div>
    </div>


        <!-- Modal -->

        <div id="id03" class="w3-modal w3-round-medium" >
          <div class="w3-modal-content w3-card-4 w3-animate-top w3-round-medium">
            <header class="w3-container w3-display-container w3-center w3-text-white" style="background-color: #1f66c9;"> 
              <span onclick="document.getElementById('id03').style.display='none'" class="w3-button w3-display-topright w3-hover-white myBack"><i class="fa fa-remove"></i></span>
              <%--<h4><strong>Leprino Foods Company, Lemoore West</strong></h4>--%>
              <h6>Print Confirmationn</h6>
            </header>
            <div class="w3-container">
                <br />
                <p>Did the document/s print successfully? </p>
                <br />
                <div class="w3-center">
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CssClass="w3-btn w3-blue w3-round-medium w3-center" Font-Underline="False"><i class="material-symbols-outlined" style="vertical-align: middle;">done_all</i> Completed</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click" CssClass="w3-btn w3-blue w3-round-medium w3-center" Font-Underline="False"><i class="material-symbols-outlined" style="vertical-align: middle;">tab_close</i> Cancel</asp:LinkButton>
                </div>
                <br />
            </div>
            <footer class="w3-container  w3-center w3-text-white myBack" style="padding: 5px; background-color: #1f66c9;">
              <p style="font-size: 10px;">Call your local HR office for any questions and/or concerns.</p>
            </footer>
          </div>
        </div>
    <script>
        // Modal Send Request
        function showMeModal2() {
            //document.getElementById("img01").src = element.src;
            document.getElementById("id02").style.display = "block";
            return false;
            //var captionText = document.getElementById("caption");
            //captionText.innerHTML = element.alt;
        }

        // Modal Send Request
        function showMeModal3() {
            //document.getElementById("img01").src = element.src;
            document.getElementById("id03").style.display = "block";
            return false;
            //var captionText = document.getElementById("caption");
            //captionText.innerHTML = element.alt;
        }


        // Modal Send Request
        function hideMeModal2() {
            //document.getElementById("img01").src = element.src;
            document.getElementById("id02").style.display = "none";
            return false;
            //var captionText = document.getElementById("caption");
            //captionText.innerHTML = element.alt;
        }

        // Modal Send Request
        function hideMeModal3() {
            //document.getElementById("img01").src = element.src;
            document.getElementById("id03").style.display = "none";
            return false;
            //var captionText = document.getElementById("caption");
            //captionText.innerHTML = element.alt;
        }
    </script>
</asp:Content>

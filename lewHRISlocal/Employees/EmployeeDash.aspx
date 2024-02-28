<%@ Page Title="Employee Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeDash.aspx.cs" Inherits="lewHRISlocal.Employees.EmployeeDash" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .divider {
            width:5px;
            height:auto;
            display:inline-block;
        }

        .myHover {
            background-color: black;
            color: white;
        }

        .myHover:hover {
            background-color: #1f66c9;
            color: black;
        }

        .myBack {
            background-color: #1f66c9;
            /*color: black;*/
        }

        .w3-border-myBlue,.w3-hover-border-myBlue:hover{border-color:#1f66c9!important}

        .w3-myBlue,.w3-hover-myBlue:hover{color:white!important;background-color:#1f66c9!important}

        .notification {
          background-color: transparent;
          color: black;
          text-decoration: none;
          position: relative;
          display: inline-block;
          border-radius: 2px;
          margin-right: 20px;
        }

        .notification:hover {
          background: transparent;
          cursor: pointer;
        }

        .notification .badge {
            position: absolute;
              top: -10px;
              right: -10px;
              padding: 5px 10px;
              border-radius: 50%;
              background: #1f66c9;
              color: white;
              box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19)
        }
    </style>
    <script src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.min.js'></script>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@20..48,100..700,0..1,-50..200" />

    <div style="background-color: rgba(255, 255, 255, 0.6); padding: 10px;  border-radius: 10px;">
    
    <br />
    <h2><strong>Employee Dashboard</strong></h2>
    <asp:Label ID="WelcomeLabel" runat="server" Text="Label" Font-Italic="True"></asp:Label>

    <asp:LinkButton ID="PrintReq" runat="server" CssClass="notification w3-right" OnClick="PrintReq_Click"><i class="material-symbols-outlined w3-xxlarge" style="vertical-align: middle;">print_connect</i><span class="badge" id="printBadge"><asp:Label ID="txtPrintReady" runat="server" Text=""></asp:Label></span></asp:LinkButton>

    
    <br />
    <br />
    <asp:Button ID="btnBack" runat="server" Text="&laquo; Back" PostBackUrl="~/Default.aspx" CssClass="w3-btn w3-light-grey w3-ripple w3-round-large"/>
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
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CausesValidation="False">Request to Print</asp:LinkButton>
                    <%--<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select" Text="Request to Print" OnClick="LinkButton2_Click"></asp:LinkButton>--%>
                    <%--<span onclick="document.getElementById('id01').style.display='block';" class="w3-button w3-transparent w3-text-black w3-hover-none" style="font-size: 10px;">Request to Print</span>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered" HeaderStyle-CssClass="myheader" />
            <asp:BoundField DataField="Supervisor_Name" HeaderText="Supervisor Name" ReadOnly="True" SortExpression="Supervisor_Name"  HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False"  HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs" Visible="False" />
            <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs" Visible="False" />
            <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject"   HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_Level" HeaderText="Level" SortExpression="Counseling_Level"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs" Visible="False" />
            <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs" Visible="False" />
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
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click1" CausesValidation="False">Request to Print</asp:LinkButton>
                    <%--<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select" Text="Select" OnClick="LinkButton3_Click"></asp:LinkButton>--%>
                    <%--<span onclick="document.getElementById('id01').style.display='block';" class="w3-button w3-transparent w3-text-black w3-hover-none" style="font-size: 10px;">Request to Print</span>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered" HeaderStyle-CssClass="myheader" />
            <asp:BoundField DataField="Supervisor_Name" HeaderText="Supervisor Name" ReadOnly="True" SortExpression="Supervisor_Name"  HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False"  HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs" Visible="False" />
            <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs" Visible="False" />
            <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject"   HeaderStyle-CssClass="myheader"/>
            <asp:BoundField DataField="Counseling_Level" HeaderText="Level" SortExpression="Counseling_Level"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs" Visible="False" />
            <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs" Visible="False" />
        </Columns>

    <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
        <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
    <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
            <SelectedRowStyle BackColor="#FF6600" />
    </asp:GridView>

    <!-- Modal -->
    
    <div id="id01" class="w3-modal w3-round-medium" >
      <div class="w3-modal-content w3-card-4 w3-animate-top w3-round-medium">
        <header class="w3-container w3-display-container w3-center w3-text-white" style="background-color: #1f66c9;"> 
          <span onclick="document.getElementById('id01').style.display='none'" class="w3-button w3-display-topright w3-hover-white myBack"><i class="fa fa-remove"></i></span>
          <h4><strong>Leprino Foods Company, Lemoore West</strong></h4>
          <h6>Request to Print Employee Record</h6>
        </header>
        <div class="w3-container">
            <br />
            <p>A request will be sent to Human Resources department of a request to print the following report:</p>
            <table style="width: 100%;">
                <tr>
                    <td><strong>Counseling ID:  </strong></td>
                    <td>  <asp:TextBox ID="TextBox3" runat="server" ReadOnly="true" BorderStyle="None" Width="100%" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Incident Date:  </strong></td>
                    <td>  <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"  ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Subject:  </strong></td>
                    <td>  <asp:TextBox ID="TextBox2" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"  ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><strong>Print Request Reference #:  </strong></td>
                    <td>  <asp:TextBox ID="printRequest_ID" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"  ></asp:TextBox></td>
                </tr>
            </table>
            <br />
            <br />
            <div class="w3-center">
                <asp:LinkButton ID="sentPrintReq" runat="server" OnClick="sentPrintReq_Click" CssClass="w3-btn w3-blue w3-round-medium w3-center" Font-Underline="False"><i class="material-symbols-outlined" style="vertical-align: middle;">outgoing_mail</i> Send Request</asp:LinkButton>
            </div>
            <br />
        </div>
        <footer class="w3-container  w3-center w3-text-white myBack" style="padding: 5px;">
          <p style="font-size: 10px;">You will receive an email confirmation regarding your request. Thank you.<br />
                                    Call your local HR office for any questions and/or concerns.</p>
        </footer>
      </div>
    </div>
   
    <!-- Modal -->

    <div id="id02" class="w3-modal w3-round-medium" >
      <div class="w3-modal-content w3-card-4 w3-animate-top w3-round-medium">
        <header class="w3-container w3-display-container w3-center w3-text-white" style="background-color: #1f66c9;"> 
          <span onclick="document.getElementById('id02').style.display='none'" class="w3-button w3-display-topright w3-hover-white myBack"><i class="fa fa-remove"></i></span>
          <h4><strong>Leprino Foods Company, Lemoore West</strong></h4>
          <h6>Ready for Pick Up</h6>
        </header>
        <div class="w3-container">
            <br />
            <p>The following requests have been completed and ready for pick up.</p>
                <asp:GridView ID="readyPrint" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="PrintRequest_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="readyPrint_PageIndexChanging" OnDataBound="readyPrint_DataBound">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:checkbox ID="cbSelect" runat="server"></asp:checkbox>
                                <%--<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select" Text="Select" OnClick="LinkButton3_Click"></asp:LinkButton>--%>
                                <%--<span onclick="document.getElementById('id01').style.display='block';" class="w3-button w3-transparent w3-text-black w3-hover-none" style="font-size: 10px;">Request to Print</span>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PrintRequest_ID" HeaderText="Print Request ID" SortExpression="PrintRequest_ID" HeaderStyle-CssClass="myheader"/>
                        <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling_ID" SortExpression="Counseling_ID" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs" />
                        <asp:BoundField DataField="Incident_Date" HeaderText="Incident Date" SortExpression="Incident_Date" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs" />
                    </Columns>

                <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
                    <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
                <RowStyle CssClass="rowsModal" Font-Size="12px"></RowStyle>
                        <SelectedRowStyle BackColor="#FF6600" />
                </asp:GridView>
            <br />
            <br />
            <%--<div class="w3-center">
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="sentPrintReq_Click" CssClass="w3-btn w3-blue w3-round-medium w3-center" Font-Underline="False"><i class="material-symbols-outlined" style="vertical-align: middle;">outgoing_mail</i> Send Request</asp:LinkButton>
            </div>--%>
            <br />
        </div>
        <footer class="w3-container  w3-center w3-text-white myBack" style="padding: 5px;">
          <p style="font-size: 10px;">Call your local HR office for any questions and/or concerns.</p>
        </footer>
      </div>
    </div>


    <!-- Modal -->

    <div id="id03" class="w3-modal w3-round-medium" >
      <div class="w3-modal-content w3-card-4 w3-animate-top w3-round-medium">
        <header class="w3-container w3-display-container w3-center w3-text-white" style="background-color: #1f66c9;"> 
          <span onclick="document.getElementById('id03').style.display='none'" class="w3-button w3-display-topright w3-hover-white myBack"><i class="fa fa-remove"></i></span>
          <h4><strong>Leprino Foods Company, Lemoore West</strong></h4>
          <h6>Request to Print Employee Record</h6>
        </header>
        <div class="w3-container">
            <br />
            <p>A request will be sent to Human Resources department of a request to print the following report:</p>
            <table style="width: 100%;">
                <tr>
                    <td><strong>Counseling ID:  </strong></td>
                    <td>  <asp:TextBox ID="TextBox4" runat="server" ReadOnly="true" BorderStyle="None" Width="100%" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Incident Date:  </strong></td>
                    <td>  <asp:TextBox ID="TextBox5" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"  ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Subject:  </strong></td>
                    <td>  <asp:TextBox ID="TextBox6" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"  ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><strong>Print Request Reference #:  </strong></td>
                    <td>  <asp:TextBox ID="TextBox7" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"  ></asp:TextBox></td>
                </tr>
            </table>
            <br />
            <br />
            <div class="w3-center">
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" CssClass="w3-btn w3-blue w3-round-medium w3-center" Font-Underline="False"><i class="material-symbols-outlined" style="vertical-align: middle;">outgoing_mail</i> Send Request</asp:LinkButton>
            </div>
            <br />
        </div>
        <footer class="w3-container  w3-center w3-text-white myBack" style="padding: 5px;">
          <p style="font-size: 10px;">You will receive an email confirmation regarding your request. Thank you.<br />
                                    Call your local HR office for any questions and/or concerns.</p>
        </footer>
      </div>
    </div>
<br />
<br />
<br />
<br />
</div>
    <script>
        // Show/Hide Badge Based on Status
        function hideBadge() {
            //alert("hello hide");
            $("#printBadge").hide();
        }

        function showBadge() {
            //alert("hello show");
            $("#printBadge").show();
        }
        
        // Modal Send Request
        function showMeModal() {
            //document.getElementById("img01").src = element.src;
            document.getElementById("id01").style.display = "block";
            return false;
            //var captionText = document.getElementById("caption");
            //captionText.innerHTML = element.alt;
        }

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


        function onClick(element) {
            document.getElementById("img01").src = element.src;
            document.getElementById("modal01").style.display = "block";
            var captionText = document.getElementById("caption");
            captionText.innerHTML = element.alt;

        }
    </script>
</asp:Content>

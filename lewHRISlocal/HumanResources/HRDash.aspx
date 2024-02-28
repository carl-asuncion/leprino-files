<%@ Page Title="Human Resources - Dashboard" Language="C#" MasterPageFile="~/HumanResources/HRSite.Master" AutoEventWireup="true" CodeBehind="HRDash.aspx.cs" Inherits="lewHRISlocal.HumanResources.HRDash" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.3/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
  <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
  
  
  <style>

    /* Set height of the grid so .sidenav can be 100% (adjust as needed) */
    .row.content {top: 50px;height: 550px}
    /*.well {
        top: 50px;
        min-height:20px;
        padding:19px;
        margin-bottom:20px;
        background-color: rgba(255, 179, 128, 0.6);
        border-radius: 15px;
        border: none;
        -webkit-box-shadow:inset 0 1px 1px rgba(0,0,0,.05);
        box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    }

*/
    .well 
        {
            top: 50px;
            min-height:20px;
            padding:19px;
            margin-bottom:20px;
            background-color: rgba(0, 51, 102, 0.75);
            color: white;
            border: none;
            border-radius:10px;
            -webkit-box-shadow:inset 0 1px 1px rgb(0,0,0);
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
            overflow: hidden;
        }
    .well2 
    {
        top: 50px;
        min-height:20px;
        padding:19px;
        margin-bottom:20px;
        background-color: rgba(255, 255, 255, 0.75);
        color: black;
        border: none;
        border-radius:10px;
        -webkit-box-shadow:inset 0 1px 1px rgb(0,0,0);
        box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    }


    /* On small screens, set height to 'auto' for the grid */
    @media screen and (max-width: 767px) {
      .row.content {height: auto;} 
    }

    .notification {
          background-color: transparent;
          color: white;
          text-decoration: none;
          position: relative;
          display: inline-block;
          border-radius: 2px;
          /*margin-right: 20px;*/
        }

        .notification:hover {
          background: transparent;
          cursor: pointer;
        }

        .notification .badge {
            position: absolute;
              top: 0px;
              right: 0px;
              padding: 5px 10px;
              border-radius: 50%;
              background: #1f66c9;
              color: white;
        }
  </style>
    <style type="text/css">  
        .ui-progressbar  
        {  
            position: relative;  
        }  
        .progress-label  
        {  
            position: absolute;  
            left: 50%;  
            /*font-weight: bold;  
            text-shadow: 1px 1px 0 #fff; */ 
            color: transparent;
        }  
        /*body  
        {  
            font-family: Arial;  
            font-size: 10pt;  
        }  */
    </style>  

  <br />    
  <div class="col-sm-12">
      <div class="well w3-container">
        <div class="w3-left">
            <h2><strong>Human Resources Dashboard</strong></h2>
            <asp:Label ID="WelcomeLabel" runat="server" Text="Label" Font-Italic="True"></asp:Label>
            <p></p>
        </div>
        <div class="w3-right">
            <asp:LinkButton ID="PrintReq" runat="server" CssClass="notification w3-right" OnClick="PrintReq_Click" ToolTip="Go to Print Request"><i class="material-symbols-outlined w3-xxlarge" style="vertical-align: middle;">print_connect</i><span class="badge" id="printBadge"><asp:Label ID="txtPrintReady" runat="server" Text=""></asp:Label></span></asp:LinkButton>
        </div>
      </div>
      <div class="row">
        <div class="col-sm-4">
          <div class="well2">
            <h6><strong>Counselings for Review</strong></h6>
            <p style="text-align: center;width: 100%; height: 200px" id="piechart4"></p>
          </div>
        </div>
        <div class="col-sm-4">
          <div class="well2">
            <h6><strong>Issued Counselings</strong></h6>
            <p style="text-align: center;width: 100%; height: 200px" id="piechart"></p>
            
          </div>
        </div>
        <%--<div class="col-sm-4">
          <div class="well2">
            <h6><strong>Issued Counselings</strong></h6>
            <p style="text-align: center;width: 100%; height: 200px" id="piechart2"></p>
          </div>
        </div>--%>
        <div class="col-sm-4">
          <div class="well2">
            <h6><strong>Initiated Disciplinary Actions</strong></h6>
            <p style="text-align: center;width: 100%; height: 200px" id="piechart3"></p>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-sm-6">
          <div class="well2">
            <h5><strong>Counselings FYTD</strong></h5>
            <h6>Incident Count per Month</h6>
            <div id="chart_div"></div>
            <p style="text-align: center"><asp:Textbox ID="numCounselingsYTD" runat="server" style="font-size: 40px;font-weight: bolder;width:100%; text-align: right" BackColor="Transparent" BorderStyle="None" ReadOnly="True" Enabled="false"></asp:Textbox></p>
          </div>
        </div>
        <div class="col-sm-6">
          <div class="well2">
            <h5><strong>Disciplinary Actions FYTD</strong></h5>
            <h6>Incident Count per Month</h6>
            <div id="chart_div1"></div>
            <p style="text-align: center"><asp:Textbox ID="numDAYTD" runat="server" style="font-size: 40px;font-weight: bolder;width:100%; text-align: right" BackColor="Transparent" BorderStyle="None" ReadOnly="True" Enabled="false"></asp:Textbox></p>
          </div>
        </div>
      </div>
      <div class="row">
          <div class="col-sm-6">
            <div class="well2">
              <h5><strong>Open Counselings Tracker</strong></h5>
              <asp:GridView ID="mydatagrid" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" 
                  HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" 
                  AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" 
                  PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="mydatagrid_PageIndexChanging" 
                  OnDataBound="mydatagrid_DataBound" BorderStyle="None">
                <Columns>
                    <asp:TemplateField ShowHeader="False" ControlStyle-CssClass="w3-border-0" ItemStyle-CssClass="w3-border-0">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton1_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" HeaderStyle-CssClass="myheader" ItemStyle-Width="10%" ItemStyle-CssClass="w3-border-0"/>
                    <asp:BoundField DataField="EE_Name" HeaderText="Employee Name" ReadOnly="True" SortExpression="EE_Name"  HeaderStyle-CssClass="myheader" ItemStyle-Width="25%" ItemStyle-CssClass="w3-border-0"/>

                    <asp:TemplateField HeaderText="Currently With" ItemStyle-VerticalAlign="Bottom" ItemStyle-CssClass="w3-bar w3-border-0" >
                        <ItemTemplate>
                                    <div class="progress w3-left" style="width: 70%">
                                      <div class="progress-label"><%# Eval("Percentage") %></div>
                                    </div>
                                    <div style="width: 20%; text-align: right;" class="w3-right">
                                        <%--<strong>&nbsp;<%# Eval("Current Department") %></strong></div>--%>
                                        <strong>&nbsp;<%# Eval("Current Department") %></strong></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>



            <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
                <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" BorderStyle="None"/>
            <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
                    <SelectedRowStyle BackColor="#FF6600" />
            </asp:GridView>  
            </div>
          </div>
          <div class="col-sm-6">
            <div class="well2">
              <h5><strong>Open Disciplinary Actions Tracker</strong></h5>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="GridView1_PageIndexChanging" OnDataBound="GridView1_DataBound" BorderStyle="None">
                    <Columns>
                        <asp:TemplateField ShowHeader="False" ControlStyle-CssClass="w3-border-0" ItemStyle-CssClass="w3-border-0">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select" Text="View" OnClick="LinkButton2_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" HeaderStyle-CssClass="myheader" ItemStyle-Width="10%" ItemStyle-CssClass="w3-border-0"/>
                        <asp:BoundField DataField="EE_Name" HeaderText="Employee Name" ReadOnly="True" SortExpression="EE_Name"  HeaderStyle-CssClass="myheader" ItemStyle-Width="25%" ItemStyle-CssClass="w3-border-0"/>

                        <asp:TemplateField HeaderText="Currently With" ItemStyle-VerticalAlign="Bottom" ItemStyle-CssClass="w3-bar w3-border-0" >
                            <ItemTemplate>
                                        <div class="progress w3-left" style="width: 70%">
                                          <div class="progress-label"><%# Eval("Percentage") %></div>
                                        </div>
                                        <div style="width: 20%; text-align: right;" class="w3-right">
                                            <strong>&nbsp;<%# Eval("Current Department") %></strong></div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>



                <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
                    <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" BorderStyle="None"/>
                <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
                        <SelectedRowStyle BackColor="#FF6600" />
                </asp:GridView> 
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-sm-12">
            <div class="well2">
              <h5><strong>Open Cases per Department</strong></h5>
              <h6>Open Cases Count</h6>
              <div style="text-align: right;"><asp:LinkButton ID="LinkButton1"  class="btn btn-primary" runat="server" OnClick="LinkButton1_Click1"><i class="fa fa-mail-forward"></i> Send Reminder to Department</asp:LinkButton></div>
              <div id="chart_div3"></div>
              <p style="text-align: center"><asp:Textbox ID="openCasesTotal" runat="server" style="font-size: 40px;font-weight: bolder;width:100%; text-align: right" BackColor="Transparent" BorderStyle="None" ReadOnly="True" Enabled="false"></asp:Textbox></p>
            </div>
          </div>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
   
    <!-- Modal -->

    <div id="id02" class="w3-modal w3-round-medium" >
      <div class="w3-modal-content w3-card-4 w3-animate-top w3-round-medium">
        <header class="w3-container w3-display-container w3-center w3-text-white" style="background-color: #1f66c9;"> 
          <span onclick="document.getElementById('id02').style.display='none'" class="w3-button w3-display-topright w3-hover-white myBack"><i class="fa fa-remove"></i></span>
          <h4><strong>Leprino Foods Company, Lemoore West</strong></h4>
          <h6>New Request to Print</h6>
        </header>
        <div class="w3-container">
            <br />
            <p>New requests:</p>
                <asp:GridView ID="readyPrint" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="PrintRequest_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="readyPrint_PageIndexChanging" OnDataBound="readyPrint_DataBound">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:checkbox ID="cbSelect" runat="server"></asp:checkbox>
                                <%--<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select" Text="Select" OnClick="LinkButton3_Click"></asp:LinkButton>--%>
                                <%--<span onclick="document.getElementById('id01').style.display='block';" class="w3-button w3-transparent w3-text-black w3-hover-none" style="font-size: 10px;">Request to Print</span>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PrintRequest_ID" HeaderText="Counseling ID" SortExpression="PrintRequest_ID" HeaderStyle-CssClass="myheader"/>
                        <asp:BoundField DataField="Counseling_ID" HeaderText="Category" SortExpression="Counseling_ID" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs" />
                        <asp:BoundField DataField="Request_Date" HeaderText="Sub-Category" SortExpression="Request_Date" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs" />
                    </Columns>

                <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" ></PagerSettings>
                    <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
                <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
                        <SelectedRowStyle BackColor="#FF6600" />
                </asp:GridView>
            <br />
            <br />
            <div class="w3-center">
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="sentPrintReq_Click" CssClass="w3-btn w3-blue w3-round-medium w3-center" Font-Underline="False"><i class="material-symbols-outlined" style="vertical-align: middle;">close</i> Close Request</asp:LinkButton>
            </div>
            <br />
        </div>
        <footer class="w3-container  w3-center w3-text-white myBack" style="padding: 5px;">
          <p style="font-size: 10px;">Call your local HR office for any questions and/or concerns.</p>
        </footer>
      </div>
    </div>
        <!-- Modal -- NEW TONER -->
    <div id="sendAlert" class="w3-modal" style="z-index: 9999;">
      <div class="w3-modal-content w3-card-4 w3-animate-top">
        <header class="w3-container w3-blue w3-display-container w3-center"> 
          <span onclick="document.getElementById('sendAlert').style.display='none'" class="w3-button w3-blue w3-display-topright"><i class="fa fa-remove"></i></span>
          <h4 style="color:white;"><strong>Send Alert to Department</strong></h4>
          <%--<h6>Working 24/7 to support LFC Lemoore West Plant <i class="fa fa-smile-o"></i></h6>--%>
        </header>
        <div class="w3-container w3-center" style="align-content: center; align-items: center; text-align: center;">
          <br />  
          <div style="align-content: center; align-items: center; text-align: center;">
 
                <div class="w3-container w3-center w3-centered" style="width: 100%; margin: auto;">
                  <%--<asp:Label ID="Label1" runat="server" Text="Label" style="color: red; font-style: italic; font-size: 10px;"></asp:Label><br />--%>
                  <label for="txtHardwareName"><b>Choose Department</b></label>
                    <asp:DropDownList ID="departmentList" runat="server" CssClass="w3-select  w3-round">
                        <%--<asp:ListItem Value="attendancenotificationsaccounting@leprinofoods.com">Admin Accounting</asp:ListItem>--%>
                        <asp:ListItem Value="Block">Block</asp:ListItem>
                        <asp:ListItem Value="Cheese Line 1">Cheese Line 1</asp:ListItem>
                        <asp:ListItem Value="Cheese Line 2">Cheese Line 2</asp:ListItem>
                        <asp:ListItem Value="Cheese Line 3">Cheese Line 3</asp:ListItem>
                        <asp:ListItem Value="Processing Line 2">Processing Line 2</asp:ListItem>
                        <asp:ListItem Value="Processing Line 3">Processing Line 3</asp:ListItem>
                        <asp:ListItem Value="Processing">Processing Line 4</asp:ListItem>
                        <asp:ListItem Value="Warehouse">Warehouse</asp:ListItem>
                        <asp:ListItem Value="Whey">Whey</asp:ListItem>
                        <asp:ListItem Value="Maintenance">Maintenance</asp:ListItem>
                        <asp:ListItem Value="Engineering">Engineering</asp:ListItem>
                        <asp:ListItem Value="QE">QE</asp:ListItem>
                        <%--<asp:ListItem Value="attendancenotificationshr@leprinofoods.com">Admin</asp:ListItem>--%>
                    </asp:DropDownList>

                    <br /> 
                  <asp:Button ID="btnSendAlert" runat="server" Text="Send Alert" CssClass="w3-btn w3-blue w3-text-white" OnClick="btnSendAlert_Click"/> 
                </div>

          </div>
          <br /> 
        </div>
        <footer class="w3-container w3-blue w3-center" style="padding: 5px;">
          <p style="font-size: 10px;color: white;">Call phone extension 7378 or 7352 or go to radio Channel 10 for PLC for immediate support.</p>
        </footer>
      </div>
    </div>
    <asp:TextBox ID="counselingCount" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="disciplinaryCount" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="openCasesCount" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="subGroup" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="listofEmails" runat="server" Visible="false"></asp:TextBox>
 

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

            // Modal New Notification
            function showMeModal2() {
                //document.getElementById("img01").src = element.src;
                document.getElementById("id02").style.display = "block";
                return false;
                //var captionText = document.getElementById("caption");
                //captionText.innerHTML = element.alt;
            }
                
            //New Counseling
            $.ajax({
                    type: "POST",
                    url: "HRDash.aspx/GetJsonNewCounseling",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        // Load Google's charting functions
                        google.charts.load('current', { 'packages': ['corechart'] });
                        google.charts.setOnLoadCallback(drawChart);

                        const json = JSON.parse(response.d);

                        
                        function drawChart() {
                            // Set the columns for the Google Chart in the first line of the array
                            // Set the columns for the Google Chart in the first line of the array
                            var condArray = [['EmpStatus', 'Count']];
                            // Loop through the JSON array, set up the value pair & push to the end of condArray
                            for (i = 0; i < json.length; i++) {
                                condArray.push([json[i].EmpStatus, json[i].Count]);
                            }

                            // Set the Google Chart options (title, width, height, and colors can be set)
                            var options = {
                                backgroundColor: 'transparent',
                                pieHole: 0.5,
                                is3D: 'true',
                                chartArea: {
                                    left: 10,
                                    top: 10,
                                    right: 10,
                                    bottom: 10
                                },
                                legend: 'none',
                                pieSliceTextStyle: {
                                    color: 'white'
                                },
                                pieSliceText: 'value'
                            };

                            // Convert condArray into the DataTable that Google Charts needs and put it in a var
                            var data = google.visualization.arrayToDataTable(condArray)

                            // Display chart inside of the empty div element using the DataTable and Options set
                            var chart = new google.visualization.PieChart(document.getElementById('piechart'));
                            chart.draw(data, options);

                            function selectHandler() {
                                var selectedItem = chart.getSelection()[0];
                                if (selectedItem) {
                                    var topping = data.getValue(selectedItem.row, 0);
                                    //alert('The user selected ' + topping);
                                    //window.location.replace('http://10.40.80.28:150/lewHRISlocal/HumanResources/DashboardResult.aspx?empName=' + topping);
                                    window.location.replace('DashboardResult.aspx?empName=' + topping);
                                }
                            }

                            google.visualization.events.addListener(chart, 'select', selectHandler); 
                        }

                    },
                    error: function (response) {
                        //alert(response.d);
                    }
                });

            //Open Counseling
            $.ajax({
                    type: "POST",
                    url: "HRDash.aspx/GetJsonOpenCounseling",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        // Load Google's charting functions
                        google.charts.load('current', { 'packages': ['corechart'] });
                        google.charts.setOnLoadCallback(drawChart);

                        const json = JSON.parse(response.d);

                    
                        function drawChart() {
                            //alert(json + ' inside drawChart function');
                            // Set the columns for the Google Chart in the first line of the array
                            // Set the columns for the Google Chart in the first line of the array
                            var condArray = [['EmpStatus', 'Count']];
                            // Loop through the JSON array, set up the value pair & push to the end of condArray
                            for (i = 0; i < json.length; i++) {
                                condArray.push([json[i].EmpStatus, json[i].Count]);
                            }

                            // Set the Google Chart options (title, width, height, and colors can be set)
                            var options = {
                                backgroundColor: 'transparent',
                                pieHole: 0.5,
                                is3D: 'true',
                                chartArea: {
                                    left: 10,
                                    top: 10,
                                    right: 10,
                                    bottom: 10
                                },
                                legend: 'none',
                                pieSliceTextStyle: {
                                    color: 'white'
                                },
                                pieSliceText: 'value'
                            };

                            // Convert condArray into the DataTable that Google Charts needs and put it in a var
                            var data = google.visualization.arrayToDataTable(condArray)

                            // Display chart inside of the empty div element using the DataTable and Options set
                            var chart = new google.visualization.PieChart(document.getElementById('piechart2'));
                            chart.draw(data, options);

                            function selectHandler() {
                                var selectedItem = chart.getSelection()[0];
                                if (selectedItem) {
                                    var topping = data.getValue(selectedItem.row, 0);
                                    //alert('The user selected ' + topping);
                                    window.location. replace('DashboardResultOpen.aspx?empName=' + topping);
                                }
                            }

                            google.visualization.events.addListener(chart, 'select', selectHandler);
                        }

                    },
                    error: function (response) {
                        //alert(response.d);
                    }
                });

            //Disciplinary Actions
            $.ajax({
                type: "POST",
                url: "HRDash.aspx/GetJsonInitiated",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // Load Google's charting functions
                    google.charts.load('current', { 'packages': ['corechart'] });
                    google.charts.setOnLoadCallback(drawChart);

                    const json = JSON.parse(response.d);

                    function drawChart() {
                        // Set the columns for the Google Chart in the first line of the array
                        // Set the columns for the Google Chart in the first line of the array
                        var condArray = [['EmpStatus', 'Count']];
                        // Loop through the JSON array, set up the value pair & push to the end of condArray
                        for (i = 0; i < json.length; i++) {
                            condArray.push([json[i].EmpStatus, json[i].Count]);
                        }

                        // Set the Google Chart options (title, width, height, and colors can be set)
                        var options = {
                            backgroundColor: 'transparent',
                            pieHole: 0.5,
                            is3D: 'true',
                            chartArea: {
                                left: 10,
                                top: 10,
                                right: 10,
                                bottom: 10
                            },
                            legend: 'none',
                            pieSliceTextStyle: {
                                color: 'white'
                            },
                            pieSliceText: 'value'
                        };

                        // Convert condArray into the DataTable that Google Charts needs and put it in a var
                        var data = google.visualization.arrayToDataTable(condArray)

                        // Display chart inside of the empty div element using the DataTable and Options set
                        var chart = new google.visualization.PieChart(document.getElementById('piechart3'));
                        chart.draw(data, options);

                        function selectHandler() {
                            var selectedItem = chart.getSelection()[0];
                            if (selectedItem) {
                                var topping = data.getValue(selectedItem.row, 0);
                                //alert('The user selected ' + topping);
                                window.location.replace('DashboardResultDA.aspx?empName=' + topping);
                            }
                        }

                        google.visualization.events.addListener(chart, 'select', selectHandler);
                    }

                },
                error: function (response) {
                    //alert(response.d);
                }
            });

            //Review
            $.ajax({
                type: "POST",
                url: "HRDash.aspx/GetJsonReview",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // Load Google's charting functions
                    google.charts.load('current', { 'packages': ['corechart'] });
                    google.charts.setOnLoadCallback(drawChart);

                    const json = JSON.parse(response.d);

                    function drawChart() {
                        // Set the columns for the Google Chart in the first line of the array
                        // Set the columns for the Google Chart in the first line of the array
                        var condArray = [['EmpStatus', 'Count']];
                        // Loop through the JSON array, set up the value pair & push to the end of condArray
                        for (i = 0; i < json.length; i++) {
                            condArray.push([json[i].EmpStatus, json[i].Count]);
                        }

                        // Set the Google Chart options (title, width, height, and colors can be set)
                        var options = {
                            backgroundColor: 'transparent',
                            pieHole: 0.5,
                            is3D: 'true',
                            chartArea: {
                                left: 10,
                                top: 10,
                                right: 10,
                                bottom: 10
                            },
                            legend: 'none',
                            pieSliceTextStyle: {
                                color: 'white'
                            },
                            pieSliceText: 'value',
                            colors: ['#e0440e', '#e6693e', '#ec8f6e', '#f3b49f', '#f6c7b6']
                        };

                        // Convert condArray into the DataTable that Google Charts needs and put it in a var
                        var data = google.visualization.arrayToDataTable(condArray)

                        // Display chart inside of the empty div element using the DataTable and Options set
                        var chart = new google.visualization.PieChart(document.getElementById('piechart4'));
                        chart.draw(data, options);

                        function selectHandler() {
                            var selectedItem = chart.getSelection()[0];
                            if (selectedItem) {
                                var topping = data.getValue(selectedItem.row, 0);
                                //alert('The user selected ' + topping);
                                //window.location.replace('http://10.40.80.28:150/lewHRISlocal/HumanResources/DashboardResultReview.aspx?empName=' + topping);
                                window.location.replace('DashboardResultReview.aspx?empName=' + topping);
                            }
                        }

                        google.visualization.events.addListener(chart, 'select', selectHandler);
                    }

                },
                error: function (response) {
                    //alert(response.d);
                }
            });

            //Trendline Counseling
            $.ajax({
                type: "POST",
                url: "HRDash.aspx/GetTrendCounseling",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // Load Google's charting functions
                    //google.charts.load('current', { 'packages': ['corechart', 'line'] });
                    google.charts.load('current', { 'packages': ['bar'] });
                    google.charts.setOnLoadCallback(drawChart);


                    const json = JSON.parse(response.d);

                    function drawChart() {
                        // Set the columns for the Google Chart in the first line of the array
                        // Set the columns for the Google Chart in the first line of the array
                        var condArray = [['DateEntered', 'Monthly Count']];
                        // Loop through the JSON array, set up the value pair & push to the end of condArray
                        for (i = 0; i < json.length; i++) {
                            condArray.push([json[i].DateEntered, json[i].DailyCount]);
                        };

                        // Set the Google Chart options (title, width, height, and colors can be set)
                        var options = {
                            //backgroundColor: 'transparent',
                            //chartArea: {
                            //    left: 10,
                            //    top: 10,
                            //    right: 10,
                            //    bottom: 10
                            //},
                            //legend: 'none',
                            //is3D: 'true',
                            //hAxis: {
                            //    title: 'Date Entered',
                            //    gridlines: {
                            //        color: 'transparent'

                            //    },
                            //    baselineColor: 'transparent'
                            //},
                            //vAxis: {
                            //    title: 'Daily Count',
                            //    gridlines: {
                            //        color: 'transparent'
                            //    },
                            //    baselineColor: 'transparent'
                            //},
                            //curveType: 'function',
                            //colors: ['#e0440e', '#e6693e', '#ec8f6e', '#f3b49f', '#f6c7b6']
                           backgroundColor: 'transparent',
                            chart: {
                                //title: 'Disciplinary Actions FYTD',
                                //subtitle: 'Counts per Month',
                            },
                            bars: 'vertical',
                            legend: { position: 'none' },
                            hAxis: {
                                title: 'Month'
                            },
                            height: 400,
                            chartArea: {
                                backgroundColor: {
                                    fill: '#FFFFFF',
                                    fillOpacity: 0.1
                                },
                            },
                            colors: ['#1b9e77', '#d95f02', '#7570b3']
                        };

                        // Convert condArray into the DataTable that Google Charts needs and put it in a var
                        var data = google.visualization.arrayToDataTable(condArray)

                        // Display chart inside of the empty div element using the DataTable and Options set
                        //var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
                        //chart.draw(data, options);
                        var chart = new google.charts.Bar(document.getElementById('chart_div'));

                        chart.draw(data, google.charts.Bar.convertOptions(options));

                        //function selectHandler() {
                        //    var selectedItem = chart.getSelection()[0];
                        //    if (selectedItem) {
                        //        var topping = data.getValue(selectedItem.row, 0);
                        //        //alert('The user selected ' + topping);
                        //        window.location.replace('http://10.40.80.28:150/lewHRISlocal/HumanResources/DashboardResultDA.aspx?empName=' + topping);
                        //    }
                        //}

                        //google.visualization.events.addListener(chart, 'select', selectHandler);
                    }

                },
                error: function (response) {
                    //alert(response.d);
                }
            });

            //Trendline Disciplinary
            $.ajax({
                type: "POST",
                url: "HRDash.aspx/GetTrendDisciplinary",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // Load Google's charting functions
                    //google.charts.load('current', { 'packages': ['corechart', 'line'] });
                    google.charts.load('current', { 'packages': ['bar'] });
                    google.charts.setOnLoadCallback(drawChart);


                    const json = JSON.parse(response.d);

                    function drawChart() {
                        // Set the columns for the Google Chart in the first line of the array
                        // Set the columns for the Google Chart in the first line of the array
                        var condArray = [['DateEntered', 'Monthly Count']];
                        // Loop through the JSON array, set up the value pair & push to the end of condArray
                        for (i = 0; i < json.length; i++) {
                            condArray.push([json[i].DateEntered, json[i].DailyCount]);
                        };

                        // Set the Google Chart options (title, width, height, and colors can be set)
                        var options = {
                            //backgroundColor: 'transparent',
                            //chartArea: {
                            //    left: 10,
                            //    top: 10,
                            //    right: 10,
                            //    bottom: 10
                            //},
                            //legend: 'none',
                            //hAxis: {
                            //    title: 'Date Entered',
                            //    gridlines: {
                            //        color: 'transparent'

                            //    },
                            //    baselineColor: 'transparent'
                            //},
                            //vAxis: {
                            //    title: 'Daily Count',
                            //    gridlines: {
                            //        color: 'transparent'
                            //    },
                            //    baselineColor: 'transparent'
                            //},
                            //curveType: 'function',
                            //colors: ['#e0440e', '#e6693e', '#ec8f6e', '#f3b49f', '#f6c7b6']
                            backgroundColor: 'transparent',
                            chart: {
                                //title: 'Disciplinary Actions FYTD',
                                //subtitle: 'Counts per Month',
                            },
                            bars: 'vertical',
                            legend: { position: 'none' },
                            hAxis: {
                                title: 'Month'
                            },
                            height: 400,
                            chartArea: {
                                backgroundColor: {
                                    fill: '#FFFFFF',
                                    fillOpacity: 0.1
                                },
                            },
                            colors: ['#1b9e77', '#d95f02', '#7570b3']
                        };

                        // Convert condArray into the DataTable that Google Charts needs and put it in a var
                        var data = google.visualization.arrayToDataTable(condArray)

                        // Display chart inside of the empty div element using the DataTable and Options set
                        //var chart = new google.visualization.LineChart(document.getElementById('chart_div1'));
                        //chart.draw(data, options);
                        var chart = new google.charts.Bar(document.getElementById('chart_div1'));

                        chart.draw(data, google.charts.Bar.convertOptions(options));

                        //function selectHandler() {
                        //    var selectedItem = chart.getSelection()[0];
                        //    if (selectedItem) {
                        //        var topping = data.getValue(selectedItem.row, 0);
                        //        //alert('The user selected ' + topping);
                        //        window.location.replace('http://10.40.80.28:150/lewHRISlocal/HumanResources/DashboardResultDA.aspx?empName=' + topping);
                        //    }
                        //}

                        //google.visualization.events.addListener(chart, 'select', selectHandler);
                    }

                },
                error: function (response) {
                    //alert(response.d);
                }
            });

            //OpenCases 
            $.ajax({
                type: "POST",
                url: "HRDash.aspx/GetOpenCases",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // Load Google's charting functions
                    //google.charts.load('current', { 'packages': ['corechart', 'line'] }); -- LINE CHART
                    google.charts.load('current', { 'packages': ['bar'] });
                    google.charts.setOnLoadCallback(drawChart);


                    const json = JSON.parse(response.d);

                    function drawChart() {
                        // Set the columns for the Google Chart in the first line of the array
                        // Set the columns for the Google Chart in the first line of the array
                        var condArray = [['DateEntered', 'Counseling Count', 'Disciplinary Count']];
                        // Loop through the JSON array, set up the value pair & push to the end of condArray
                        for (i = 0; i < json.length; i++) {
                            condArray.push([json[i].DateEntered, json[i].DailyCount, json[i].DailyCount2]);
                        };

                        // Set the Google Chart options (title, width, height, and colors can be set)
                        var options = {
                            //backgroundColor: 'transparent',
                            //chartArea: {
                            //    left: 10,
                            //    top: 10,
                            //    right: 10,
                            //    bottom: 10
                            //},
                            //legend: 'none',
                            //hAxis: {
                            //    title: 'Date Entered',
                            //    gridlines: {
                            //        color: 'transparent'

                            //    },
                            //    baselineColor: 'transparent'
                            //},
                            //vAxis: {
                            //    title: 'Daily Count',
                            //    gridlines: {
                            //        color: 'transparent'
                            //    },
                            //    baselineColor: 'transparent'
                            //},
                            //curveType: 'function',
                            //colors: ['#e0440e', '#e6693e', '#ec8f6e', '#f3b49f', '#f6c7b6']
                            backgroundColor: 'transparent',
                            chart: {
                                //title: 'Disciplinary Actions FYTD',
                                //subtitle: 'Counts per Month',
                            },
                            bars: 'vertical',
                            legend: { position: 'none' },
                            hAxis: {
                                title: 'Department'
                            },
                            height: 400,
                            chartArea: {
                                backgroundColor: {
                                    fill: '#FFFFFF',
                                    fillOpacity: 0.1
                                },
                            },
                            colors: ['#1b9e77', '#d95f02', '#7570b3']
                        };

                        // Convert condArray into the DataTable that Google Charts needs and put it in a var
                        var data = google.visualization.arrayToDataTable(condArray)

                        // Display chart inside of the empty div element using the DataTable and Options set
                        //var chart = new google.visualization.LineChart(document.getElementById('chart_div1'));
                        //chart.draw(data, options);
                        var chart = new google.charts.Bar(document.getElementById('chart_div3'));

                        chart.draw(data, google.charts.Bar.convertOptions(options));

                        //function selectHandler() {
                        //    var selectedItem = chart.getSelection()[0];
                        //    if (selectedItem) {
                        //        var topping = data.getValue(selectedItem.row, 0);
                        //        //alert('The user selected ' + topping);
                        //        window.location.replace('http://10.40.80.28:150/lewHRISlocal/HumanResources/DashboardResultDA.aspx?empName=' + topping);
                        //    }
                        //}

                        //google.visualization.events.addListener(chart, 'select', selectHandler);
                    }

                },
                error: function (response) {
                    //alert(response.d);
                }
            });

        </script>



    <script type="text/javascript">  
        var myval = document.getElementsByClassName('.progress-label').text;

        $(function () {
            $(".progress").each(function () {
                $(this).progressbar({
                    value: parseInt($(this).find('.progress-label').text())  
                });
            });
        });


        function showAlert() {
            document.getElementById('sendAlert').style.display = 'block';
            return false;
        }
    </script>  
</asp:Content>

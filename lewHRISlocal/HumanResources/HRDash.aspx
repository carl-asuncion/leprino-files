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
    .well {
        top: 50px;
        min-height:20px;
        padding:19px;
        margin-bottom:20px;
        background-color: #ffb380;
        border-radius: 15px;
        border: none;
        -webkit-box-shadow:inset 0 1px 1px rgba(0,0,0,.05);
        box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    }

    .well2 {
        top: 50px;
        min-height:20px;
        padding:19px;
        margin-bottom:20px;
        background-color: #ffb380;        
        border-radius: 15px;
        border: none;
        -webkit-box-shadow:inset 0 1px 1px rgba(0,0,0,.05);
        box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    }
    

    /* On small screens, set height to 'auto' for the grid */
    @media screen and (max-width: 767px) {
      .row.content {height: auto;} 
    }
  </style>


  <br />
  <div class="col-sm-12">
      <div class="well">
        <h2><strong>Human Resources Dashboard</strong></h2>
        <asp:Label ID="WelcomeLabel" runat="server" Text="Label" Font-Italic="True"></asp:Label>
        <p></p>
      </div>
      <div class="row">
        <div class="col-sm-3">
          <div class="well2">
            <h6><strong>Counselings for Review</strong></h6>
            <p style="text-align: center;width: 100%; height: 200px" id="piechart4"></p>
            
          </div>
        </div>
        <div class="col-sm-3">
          <div class="well2">
            <h6><strong>New Counselings</strong></h6>
            <p style="text-align: center;width: 100%; height: 200px" id="piechart"></p>
            
          </div>
        </div>
        <div class="col-sm-3">
          <div class="well2">
            <h6><strong>Open Counselings</strong></h6>
            <p style="text-align: center;width: 100%; height: 200px" id="piechart2"></p>
          </div>
        </div>
        <div class="col-sm-3">
          <div class="well2">
            <h6><strong>Initiated Disciplinary Actions</strong></h6>
            <p style="text-align: center;width: 100%; height: 200px" id="piechart3"></p>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-sm-6">
          <div class="well2">
            <h5><strong>Counselings YTD</strong></h5>
            <div id="chart_div"></div>
            <p style="text-align: center"><asp:Textbox ID="numCounselingsYTD" runat="server" style="font-size: 40px;font-weight: bolder;width:100%; text-align: right" BackColor="Transparent" BorderStyle="None" ReadOnly="True" Enabled="false"></asp:Textbox></p>
          </div>
        </div>
        <div class="col-sm-6">
          <div class="well2">
            <h5><strong>Disciplinary Actions YTD</strong></h5>
            <div id="chart_div1"></div>
            <p style="text-align: center"><asp:Textbox ID="numDAYTD" runat="server" style="font-size: 40px;font-weight: bolder;width:100%; text-align: right" BackColor="Transparent" BorderStyle="None" ReadOnly="True" Enabled="false"></asp:Textbox></p>
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
   


        <script>
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
                                chartArea: {
                                    left: 10,
                                    top: 10,
                                    right: 10,
                                    bottom: 10
                                },
                                legend: 'none',
                                pieSliceTextStyle: {
                                    color: 'black'
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
                                    window.location.replace('http://10.40.80.28:150/lewHRISlocal/HumanResources/DashboardResult.aspx?empName=' + topping);
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
                                chartArea: {
                                    left: 10,
                                    top: 10,
                                    right: 10,
                                    bottom: 10
                                },
                                legend: 'none',
                                pieSliceTextStyle: {
                                    color: 'black'
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
                                    window.location.replace('http://10.40.80.28:150/lewHRISlocal/HumanResources/DashboardResultOpen.aspx?empName=' + topping);
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
                            chartArea: {
                                left: 10,
                                top: 10,
                                right: 10,
                                bottom: 10
                            },
                            legend: 'none',
                            pieSliceTextStyle: {
                                color: 'black'
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
                                window.location.replace('http://10.40.80.28:150/lewHRISlocal/HumanResources/DashboardResultDA.aspx?empName=' + topping);
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
                            chartArea: {
                                left: 10,
                                top: 10,
                                right: 10,
                                bottom: 10
                            },
                            legend: 'none',
                            pieSliceTextStyle: {
                                color: 'black'
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
                                window.location.replace('http://10.40.80.28:150/lewHRISlocal/HumanResources/DashboardResultReview.aspx?empName=' + topping);
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
                    google.charts.load('current', { 'packages': ['corechart', 'line'] });
                    google.charts.setOnLoadCallback(drawChart);


                    const json = JSON.parse(response.d);

                    function drawChart() {
                        // Set the columns for the Google Chart in the first line of the array
                        // Set the columns for the Google Chart in the first line of the array
                        var condArray = [['DateEntered', 'DailyCount']];
                        // Loop through the JSON array, set up the value pair & push to the end of condArray
                        for (i = 0; i < json.length; i++) {
                            condArray.push([json[i].DateEntered, json[i].DailyCount]);
                        };

                        // Set the Google Chart options (title, width, height, and colors can be set)
                        var options = {
                            backgroundColor: 'transparent',
                            chartArea: {
                                left: 10,
                                top: 10,
                                right: 10,
                                bottom: 10
                            },
                            legend: 'none',
                            hAxis: {
                                title: 'Date Entered',
                                gridlines: {
                                    color: 'transparent'

                                },
                                baselineColor: 'transparent'
                            },
                            vAxis: {
                                title: 'Daily Count',
                                gridlines: {
                                    color: 'transparent'
                                },
                                baselineColor: 'transparent'
                            },
                            curveType: 'function'
                           
                        };

                        // Convert condArray into the DataTable that Google Charts needs and put it in a var
                        var data = google.visualization.arrayToDataTable(condArray)

                        // Display chart inside of the empty div element using the DataTable and Options set
                        var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
                        chart.draw(data, options);

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
                    google.charts.load('current', { 'packages': ['corechart', 'line'] });
                    google.charts.setOnLoadCallback(drawChart);


                    const json = JSON.parse(response.d);

                    function drawChart() {
                        // Set the columns for the Google Chart in the first line of the array
                        // Set the columns for the Google Chart in the first line of the array
                        var condArray = [['DateEntered', 'DailyCount']];
                        // Loop through the JSON array, set up the value pair & push to the end of condArray
                        for (i = 0; i < json.length; i++) {
                            condArray.push([json[i].DateEntered, json[i].DailyCount]);
                        };

                        // Set the Google Chart options (title, width, height, and colors can be set)
                        var options = {
                            backgroundColor: 'transparent',
                            chartArea: {
                                left: 10,
                                top: 10,
                                right: 10,
                                bottom: 10
                            },
                            legend: 'none',
                            hAxis: {
                                title: 'Date Entered',
                                gridlines: {
                                    color: 'transparent'

                                },
                                baselineColor: 'transparent'
                            },
                            vAxis: {
                                title: 'Daily Count',
                                gridlines: {
                                    color: 'transparent'
                                },
                                baselineColor: 'transparent'
                            },
                            curveType: 'function'

                        };

                        // Convert condArray into the DataTable that Google Charts needs and put it in a var
                        var data = google.visualization.arrayToDataTable(condArray)

                        // Display chart inside of the empty div element using the DataTable and Options set
                        var chart = new google.visualization.LineChart(document.getElementById('chart_div1'));
                        chart.draw(data, options);

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
</asp:Content>

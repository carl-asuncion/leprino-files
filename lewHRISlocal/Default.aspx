<%@ Page Title="LEW HRIS CAS Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="lewHRISlocal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        /* Full height image header */
        .bgimg-1 {
          background-position: center;
          background-size: cover;
          background-image: url("/Images/hrwallpaper3.jpg");
          min-height: 100%;
        }

        .well 
        {
            top: 50px;
            min-height:20px;
            padding:19px;
            margin-bottom:20px;
            background-color: rgba(0, 51, 102, 0.6);
            color: white;
            border: none;
            border-radius:4px;
            -webkit-box-shadow:inset 0 1px 1px rgb(0,0,0);
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
        }

         .wellsec {
            top: 50px;
            min-height:20px;
            padding:19px;
            margin-bottom:20px;
            background-color: rgba(51, 153, 255, 0.6);
            color: black;
            border: none;
            border-radius:4px;
            -webkit-box-shadow:inset 0 1px 1px rgb(0,0,0);
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
        }

         .wellbody {
            top: 50px;
            padding:19px;
            margin-bottom:20px;
            background-color: rgba(255, 255, 255, 0.6);
            color: black;
            border: none;
            border-radius:4px;
            -webkit-box-shadow:inset 0 1px 1px rgb(0,0,0);
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
        }

        /* Center the loader */
        #loader {
          position: absolute;
          left: 50%;
          top: 50%;
          z-index: 1;
          width: 120px;
          height: 120px;
          margin: -76px 0 0 -76px;
          border: 16px solid #f3f3f3;
          border-radius: 50%;
          border-top: 16px solid black;
          border-right: 16px solid #003366;
          border-left: 16px solid #ff6600;
          border-bottom: 16px solid #ff9933;
          -webkit-animation: spin 2s linear infinite;
          animation: spin 2s linear infinite;
        }

        @-webkit-keyframes spin {
            0% { -webkit-transform: rotate(0deg); }
            100% { -webkit-transform: rotate(360deg); }
        }

        @keyframes spin {
            0% { transform: rotate(0deg); }
            100% { transform: rotate(360deg); }
        }

        /* Add animation to "page content" */
        .animate-bottom 
        {
            position: relative;
            -webkit-animation-name: animatebottom;
            -webkit-animation-duration: 1s;
            animation-name: animatebottom;
            animation-duration: 1s
        }

        @-webkit-keyframes animatebottom {
            from { bottom:-100px; opacity:0 } 
            to { bottom:0px; opacity:1 }
        }

        @keyframes animatebottom { 
            from{ bottom:-100px; opacity:0 } 
            to{ bottom:0; opacity:1 }
        }

        #myDiv 
        {
            display: none;
            text-align: center;
        }


    /*the container must be positioned relative:*/
        .autocomplete {
          position: relative;
          display: inline-block;
        }

        input {
          border: 1px solid transparent;
          background-color: #f1f1f1;
          padding: 10px;
          font-size: 16px;
        }

        input[type=text] {
          background-color: #f1f1f1;
          width: 100%;
        }

        /*input[type=submit] {
          background-color: DodgerBlue;
          color: #fff;
          cursor: pointer;
        }*/

        .autocomplete-items {
          position: absolute;
          border: 1px solid #d4d4d4;
          border-bottom: none;
          border-top: none;
          z-index: 99;
          /*position the autocomplete items to be the same width as the container:*/
          top: 100%;
          left: 0;
          right: 0;
        }

        .autocomplete-items div {
          padding: 10px;
          cursor: pointer;
          background-color: #fff; 
          border-bottom: 1px solid #d4d4d4; 
        }

        /*when hovering an item:*/
        .autocomplete-items div:hover {
          background-color: #e9e9e9; 
        }

        /*when navigating through the items using the arrow keys:*/
        .autocomplete-active {
          background-color: DodgerBlue !important; 
          color: #ffffff; 
        }
    </style>
    <link rel="stylesheet" href="/Content/w3.css">
    <link rel="stylesheet" href="/Content/Site.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@20..48,100..700,0..1,-50..200" />
    <script src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.min.js'></script>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@20..48,100..700,0..1,-50..200" />
    <div>
        <br />
        <div id="loader" style="display:none"></div>
        <%--<div id="loader"></div>--%>

        <div id="myDiv1">
            <div class="well">
                <div style="align-content: center; align-items: center; text-align: center"><asp:Image ID="Image1" runat="server" ImageUrl="/Images/Leprino_Foods_White.png" Width="25%" /></div>
                <div style="align-content: center; align-items: center; text-align: center"><h2><strong>HRIS - Corrective Action System</strong></h2></div>
                <div style="align-content: center; align-items: center; text-align: center"><p class="lead">Welcome to LFC - Lemoore West's new Corrective Action System</p></div>
            </div>

            <div class="wellsec">
                <div class="row">
                    <div class="col-md-4">
                        <p>
                            <button id="btnHumanResources" runat="server"  class="w3-btn w3-blue w3-ripple w3-round-large" onserverclick="btnHumanResources_Click" title="Manage employee record"><i class="material-symbols-outlined w3-jumbo w3-center">admin_panel_settings</i></button>
                        </p>
                        <h3><strong>Human Resources</strong></h3>
                        <p>To manage open counseling and disciplinary actions.</p>
                    </div>
                    <div class="col-md-4">
                        <p>
                            <button id="btnSupervisor" runat="server"  class="w3-btn w3-blue w3-ripple w3-round-large" onserverclick="btnSupervisor_Click" title="Create new report and manage existing ones"><i class="material-symbols-outlined w3-jumbo w3-center">supervisor_account</i></button>
                        </p>
                        <h3><strong>Supervisors</strong></h3>
                        <p>To submit new counseling forms and send reviewed counseling reports to HR.</p>
                    </div>
                    <div class="col-md-4">
                        <p>
                            <button id="btnEmployees" runat="server" onserverclick="btnEmployees_Click" class="w3-btn w3-blue w3-ripple w3-round-large" title="Request for report copy"><i class="material-symbols-outlined w3-jumbo w3-center">person</i></button>
                        </p>
                        <h3><strong>Employees</strong></h3>
                        <p>To review current counseling reports and history.</p>
                    </div>
                    <!--div class="col-md-4">
                        <h2></h2>
                        <p>Column 3 details here.</p>
                        <p>
                            <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Button 3 under a p-tag &raquo;</a>
                        </p>
                    </div-->
                </div>
            </div>
        </div>
        <div class="wellbody">
            <div class="row">
                <div class="col-md-8">
                    <h4><strong>Updates</strong></h4>
                    <hr style="border-width: 1px; border-color: #000000" />
                    <div>
                        <asp:Repeater ID="rptPages" runat="server">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Container.ItemIndex + 1 %>' Font-Size="10px"></asp:Label>
                                <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("Title") %>' NavigateUrl='<%# "~/DisplayBlog.aspx?id=" + Eval("Blog_ID") %>' Font-Bold="True" Font-Size="12px" BorderStyle="None" Font-Underline="false" CssClass="w3-hover-none"></asp:HyperLink>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Date_Entered") %>' Font-Italic="True" Font-Size="10px"></asp:Label>
                                <%--<asp:Label ID="Label1" runat="server" Text='<%# Eval("Body") %>'></asp:Label>--%>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <br />
                            </SeparatorTemplate>
                        </asp:Repeater>
                    </div>
                    <br />
                </div>
                
                <div class="col-md-4">
                    <h4><strong>Other Links</strong></h4>
                    <hr style="border-width: 1px; border-color: #000000" />
                    <div>
                        <h6><a href="http://lewvsql02.leprino.local" class="w3-hover-none" target="_blank" rel="noopener noreferrer"><strong>Plant Systems West Website</strong></a></h6>
                        <div>
                            <p style="font-size: 12px;">
                                <strong>CHECK IT OUT!</strong> - 
                                Need a form for ISS requests, PCR requests and/or radio repair/requests? Want to know how Process Change works?
                                Visit the website link.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <br />
        <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>  

        <form autocomplete="off" action="/action_page.php">
          <div class="autocomplete" style="width:300px;">
            <input id="myInput" type="text" name="myCountry" placeholder="Country">
          </div>
          <input type="submit">
        </form>--%>
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
    <br />
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
   
</asp:Content>
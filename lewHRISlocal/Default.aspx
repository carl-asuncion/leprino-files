<%@ Page Title="LEW HRIS CAS Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="lewHRISlocal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .well {
            top: 50px;
            min-height:20px;
            padding:19px;
            margin-bottom:20px;
            background-color: #003366;
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
            border-top: 16px solid #003366;
            border-right: 16px solid #ff9933;
            border-bottom: 16px solid #ff6600;
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
    </style>
    <link rel="stylesheet" href="/Content/w3.css">
    <link rel="stylesheet" href="/Content/Site.css">
    
    <div>
        <br />
        <div id="loader" style="display:none"></div>
        <%--<div id="loader"></div>--%>
        <div id="myDiv1">
            <div class="well">
                <div style="align-content: center; align-items: center; text-align: center"><asp:Image ID="Image1" runat="server" ImageUrl="http://10.40.80.28:150/lewHRISlocal/Leprino_Foods_White.png" Width="25%" /></div>
                <div style="align-content: center; align-items: center; text-align: center"><h1><strong>HRIS - Corrective Action System</strong></h1></div>
                <div style="align-content: center; align-items: center; text-align: center"><p class="lead">Welcome to LFC - Lemoore West's new Corrective Action System</p></div>
            </div>

            <div class="wellsec">
                <div class="row">
                    <div class="col-md-4">
                        <h2><strong>Human Resources</strong></h2>
                        <p>To manage open counseling and disciplinary actions.</p>
                        <p>
                            <%--<asp:Button ID="btnHumanResources" runat="server" Text="Human Resources &raquo;" CssClass="btn btn-primary" OnClick="btnHumanResources_Click"/>--%>
                            <asp:Button ID="btnHumanResources" runat="server" Text="Human Resources &raquo;" CssClass="w3-btn w3-blue w3-ripple w3-round-large" OnClick="btnHumanResources_Click"/>
                        </p>
                    </div>
                    <div class="col-md-4">
                        <h2><strong>Supervisors</strong></h2>
                        <p>To submit new counseling forms and send reviewed counseling reports to HR.</p>
                        <p>
                            <asp:Button ID="btnSupervisor" runat="server" Text="Supervisors &raquo;" CssClass="w3-btn w3-blue w3-ripple w3-round-large" OnClick="btnSupervisor_Click"/>
                            <%--<asp:Button ID="btnSupervisor" runat="server" Text="Supervisors &raquo;" CssClass="btn btn-primary" OnClientClick="lol()" />--%>
                            <%--<asp:Button ID="btnTest" runat="server" Text="Supervisors &raquo;" CssClass="btn btn-primary" OnClientClick="confirmDelete()"/>--%>
                        </p>
                    </div>
                    <div class="col-md-4">
                        <h2><strong>Employees</strong></h2>
                        <p>To review current counseling reports and history.</p>
                        <p>
                            <asp:Button ID="btnEmployees" runat="server" Text="Employees &raquo;" CssClass="w3-btn w3-blue w3-ripple w3-round-large" OnClick="btnEmployees_Click"/>
                            <%--<a class="btn btn-primary" href="Employees/EmployeeDash">Employees &raquo;</a>--%>
                        </p>
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
                    <h3><strong>Updates</strong></h3>
                    <hr style="border-width: 1px; border-color: #000000" />
                    <div>
                        <asp:Repeater ID="rptPages" runat="server">
                            <ItemTemplate>
                                <%# Container.ItemIndex + 1 %>
                                <asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("Title") %>' NavigateUrl='<%# "~/DisplayBlog.aspx?id=" + Eval("Blog_ID") %>' Font-Bold="True"></asp:HyperLink>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Date_Entered") %>' Font-Italic="True" Font-Size="Smaller"></asp:Label>
                                <%--<asp:Label ID="Label1" runat="server" Text='<%# Eval("Body") %>'></asp:Label>--%>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <br />
                            </SeparatorTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="col-md-4">
                    <h3><strong>Other Links</strong></h3>
                    <hr style="border-width: 1px; border-color: #000000" />
                    <div>
                        <h6><a><strong>Online ISS Requests (Currently Unavailable)</strong></a></h6>
                        <div>
                            <p>
                                &nbsp;&nbsp;&nbsp;<strong>COMING SOON</strong> - ISS Requests will now soon be available online!&nbsp;&nbsp;&nbsp;More details coming soon!
                            </p>
                        </div>
                    </div>
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
    <br />
    <br />
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <%--<script>
        function lol() {
            document.getElementsById('loader').style.display = 'block';
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "onclick", "javascript:window.open( 'Supervisors/SupervisorDash.aspx');", true);
            window.location.href = "Supervisors/SupervisorDash.aspx";
        }
    </script>--%>
    <%--<script>
        function confirmDelete() {
            if (confirm("Are you sure you want to delete")) {
                alert('hello');
                
            }
            else {
                alert('Bye');
            }
        }
    </script>--%>
</asp:Content>

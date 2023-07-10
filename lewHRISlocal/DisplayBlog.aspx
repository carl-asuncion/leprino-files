<%@ Page Title="LEW HRIS CAS Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayBlog.aspx.cs" Inherits="lewHRISlocal.DisplayBlog" %>

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
    <div>
        <br />
        <div id="loader" style="display:none"></div>
        <%--<div id="loader"></div>--%>
        <div id="myDiv1">
            <div class="well">
               <div style="align-content: center; align-items: center; text-align: center"><h2><strong>HRIS - Corrective Action System Update</strong></h2></div>
            </div>
        </div>
        <div class="wellbody">
            <h3><asp:Label ID="lblTitle" runat="server" Font-Bold="True" /></h3>
            <h6><asp:Label ID="lblDate" runat="server" Font-Italic="True" /></h6>
            <hr />
            <asp:Label ID="lblBody" runat="server" BackColor="Transparent" />
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

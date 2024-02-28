<%@ Page Title="Forward Case" Language="C#" MasterPageFile="~/HumanResources/HRSite.Master" AutoEventWireup="true" CodeBehind="InitializeDA.aspx.cs" Inherits="lewHRISlocal.HumanResources.InitializeDA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>  

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <div style="background-color: rgba(255, 255, 255, 0.6); padding: 10px;  border-radius: 10px;">
    <div>
    <br />
        <h1>Initialize Disciplinary Action</h1>
        <p>
                <asp:Table ID="Table1" runat="server" Width="100%">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button ID="Button1" runat="server" Text="&laquo; Back" class="w3-btn w3-light-grey w3-ripple w3-round-large" OnClientClick="JavaScript:window.history.back(1); return false;"/>
                            <%--<asp:Button ID="Button2" runat="server" Text="Edit &raquo;" class="btn btn-default" OnClick="btnUpdate_Click"/>
                            <asp:Label ID="LabelAccess" runat="server" Text="Label" Font-Italic="True"></asp:Label>--%>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Right">
                            <%--<asp:LinkButton ID="LinkButton1"  class="btn btn-primary" runat="server" OnClick="LinkButton1_Click"><i class="fa fa-download"></i> Print View</asp:LinkButton>--%>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </p>
        
        <div class="row  form-inline" style="font-family: Arial;">  
            <div class="col-md-5">
                <asp:Label ID="Label1" runat="server" style="font-weight: bold" Text="Counseling ID: "></asp:Label>
                <asp:TextBox ID="txtCounselingID" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label28" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox6" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div> 
            <div class="col-md-5">
                <asp:Label ID="Label29" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="txtNewStatus" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div>
            <div class="col-md-1">

            </div>
        </div>
        <div class="row form-inline" style="font-family: Arial;">  
            <div class="col-md-5">
                <asp:Label ID="Label12" runat="server" style="font-weight: bold" Text="Incident Date: "></asp:Label>
                <asp:TextBox ID="txtDateIncident" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label31" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div> 
            <div class="col-md-5">
                <asp:Label ID="Label2" runat="server" style="font-weight: bold" Text="Date Entered: "></asp:Label>
                <asp:TextBox ID="txtDateEntered" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">

            </div>
        </div>
        <div class="row" style="font-family: Arial;">  
            <div class="col-md-5">
                <asp:Label ID="Label3" runat="server" style="font-weight: bold" Text="Employee ID: "></asp:Label>
                <asp:TextBox ID="txtEmpID" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label33" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox5" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div> 
            <div class="col-md-5">
                <asp:Label ID="Label4" runat="server" style="font-weight: bold" Text="Employee Name: "></asp:Label>
                <asp:TextBox ID="txtEmployeeName" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">

            </div>
        </div>
        <div class="row" style="font-family: Arial;">  
            <div class="col-md-5">
                <asp:Label ID="Label30" runat="server" style="font-weight: bold" Text="Position: "></asp:Label>
                <asp:TextBox ID="txtPosition" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label32" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div> 
            <div class="col-md-5">
                <asp:Label ID="Label7" runat="server" style="font-weight: bold" Text="Department: "></asp:Label>
                <asp:TextBox ID="txtDepartment" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">

            </div>
        </div>
        <div class="row" style="font-family: Arial;">  
            <div class="col-md-5">
                <asp:Label ID="Label13" runat="server" style="font-weight: bold" Text="Employee Status: "></asp:Label>
                    <asp:TextBox ID="txtEEStatus" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label35" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                    <asp:TextBox ID="txtSupervisor" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div>
            <div class="col-md-5">
                <asp:Label ID="Label36" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                    <asp:TextBox ID="TextBox10" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div>
            <div class="col-md-1">
            
            </div>
        </div> 
        <div class="row" style="font-family: Arial;">  
            <div class="col-md-5">
                <asp:Label ID="Label9" runat="server" style="font-weight: bold" Text="Category: "></asp:Label>
                <asp:TextBox ID="txtCategory" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label37" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="txtEmployeeSigned" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div>
            <div class="col-md-5">
                <asp:Label ID="Label10" runat="server" style="font-weight: bold" Text="Counseling Level: "></asp:Label>
                <%--<asp:TextBox ID="txtLevel" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>--%>
                <asp:DropDownList ID="ddLevel" runat="server" CssClass="w3-select  w3-round">
                    <asp:ListItem>Counseling</asp:ListItem>
                    <asp:ListItem>Level 1</asp:ListItem>
                    <asp:ListItem>Level 2</asp:ListItem>
                    <asp:ListItem>Level 3</asp:ListItem>
                    <asp:ListItem>Level 4</asp:ListItem>
                    <asp:ListItem>Termination</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-1">
            
            </div>
        </div> 
        <div class="row" style="font-family: Arial;">  
            <div class="col-md-5">
                <asp:Label ID="Label11" runat="server" style="font-weight: bold" Text="Sub-Category: "></asp:Label>
                <asp:TextBox ID="txtSubCategory" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" Width="100%" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label40" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="txtEmployeeUserName" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div>
            <div class="col-md-5">
                <asp:Label ID="Label14" runat="server" style="font-weight: bold" Text="Overall Status: "></asp:Label>
                <asp:TextBox ID="txtOverallStatus" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" Width="100%" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-md-1">
            
            </div>
        </div>
   
    </div>
    <hr style="border-width: 3px; border-color: #000000" />

    
            <h3>Incident Details</h3>
            <p><asp:Label ID="Label5" runat="server" Text="Subject: ">
            </asp:Label>
            <asp:TextBox ID="txtSubject" runat="server" Width="100%" CssClass="w3-input w3-border w3-round"></asp:TextBox></p>
            <p><asp:Label ID="Label6" runat="server" Text="Incident Description: ">
            </asp:Label><br /><asp:TextBox ID="txtSupComments" runat="server" TextMode="MultiLine" Rows="10" Width="100%" CssClass="w3-input w3-border w3-round"></asp:TextBox></p>
            

            <h3>Employee Comments</h3>
            <p><asp:Label ID="Label8" runat="server" Text="Employee Comments: ">
            </asp:Label><br /><asp:TextBox ID="txtEmployeeComments" runat="server" TextMode="MultiLine" Rows="10" Width="100%" CssClass="w3-input w3-border w3-round"></asp:TextBox></p>

            <p><asp:Label ID="Label15" runat="server" Text="Supervisor Comments: ">
            </asp:Label><br /><asp:TextBox ID="txtFollowUp" runat="server" TextMode="MultiLine" Rows="5" Width="100%" CssClass="w3-input w3-border w3-round"></asp:TextBox></p>
    <hr style="border-width: 3px; border-color: #000000" />
            <h3>Forward Case to Generalist/Manager </h3>
            <asp:Label ID="Label27" runat="server" Text="Forward Case to : "><br />
            </asp:Label>
            <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Width="400px" Rows="10"></asp:ListBox><br />
            <%--<asp:Button ID="Button7" runat="server" Text="Send Correspondence" OnClick="Button7_Click" CssClass="w3-btn w3-blue w3-ripple w3-round-large" Visible="False"/>--%>
<%--                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" DataSourceID="SqlDataSource1" DataTextField="HRM_Name" DataValueField="HRM_Email_Address" OnTextChanged="DropDownList1_TextChanged" AutoPostBack="True"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LEW_HRIS_LocalConnectionString %>" SelectCommand="SELECT [HRM_Name], [HRM_Email_Address] FROM [HRMList]"></asp:SqlDataSource>
                <asp:TextBox ID="txtHRMEmail" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True" Width="300px"></asp:TextBox>--%>
           
            <%--<p><asp:Label ID="Label14" runat="server" Text="Supervisor Comments: " Visible="false">
            </asp:Label><asp:TextBox ID="txtFollowUp" runat="server" TextMode="MultiLine" Rows="5" Width="100%" ReadOnly="True" Visible="false"></asp:TextBox></p>--%>
    <hr style="border-width: 3px; border-color: #000000" />
    <p>Initializing Disciplinary Action will notify supervisor and HR Manager/Generalist regarding the reported counseling case.</p>
    <asp:LinkButton ID="btnInitialize" runat="server" class="w3-btn w3-green w3-ripple w3-round-large" OnClick="btnInitialize_Click" Font-Underline="false"><i class="fa fa-folder"></i> Initialize Disciplinary Action &raquo; Department </asp:LinkButton>
    <br />
    <%--<asp:LinkButton ID="btnToGeneralist" runat="server" class="w3-btn w3-green w3-ripple w3-round-large" OnClick="btnToGeneralist_Click" Font-Underline="false"><i class="fa fa-folder"></i> Initialize Disciplinary Action &raquo; Generalist </asp:LinkButton>--%>
    <br />
    <%--<div class="row">
            <div class="col-md-6">
                <asp:Label ID="Label19" runat="server" style="font-weight: bold" Text="Employee Counseling Signed: " Visible="false">
               </asp:Label><asp:TextBox ID="txtEEAck" runat="server" BackColor="#FFFFFF" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True" Visible="false"></asp:TextBox><br />
               <asp:Label ID="Label15" runat="server" style="font-weight: bold" Text="Employee Disciplinary Signed: " Visible="false">
               </asp:Label><asp:TextBox ID="txtEESigned" runat="server" BackColor="#FFFFFF" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True" Visible="false"></asp:TextBox><br />
                <asp:Label ID="Label24" runat="server" style="font-weight: bold" Text="Supervisor Counseling Signed: " Visible="false">
               </asp:Label><asp:TextBox ID="txtSupFin" runat="server" BackColor="#FFFFFF" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True" Visible="false"></asp:TextBox><br />
               <asp:Label ID="Label16" runat="server" style="font-weight: bold" Text="Supervisor Disciplinary Signed: " Visible="false">
               </asp:Label><asp:TextBox ID="txtSupSigned" runat="server" BackColor="#FFFFFF" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True" Visible="false"></asp:TextBox><br />
               <asp:Label ID="Label17" runat="server" style="font-weight: bold" Text="HR Clerk Signed: " Visible="false">
               </asp:Label><asp:TextBox ID="txtHRCSigned" runat="server" BackColor="#FFFFFF" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True" Visible="false"></asp:TextBox><br />
               <asp:Label ID="Label18" runat="server" style="font-weight: bold" Text="HR Manager Signed: " Visible="false">
               </asp:Label><asp:TextBox ID="txtHRMSigned" runat="server" BackColor="#FFFFFF" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True" Visible="false"></asp:TextBox><br />
            </div>
            <div class="col-md-6">
               <asp:Label ID="Label20" runat="server" style="font-weight: bold" Text="Date: " Visible="false">
               </asp:Label><asp:TextBox ID="txtEEAckDate" runat="server" BackColor="#FFFFFF" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True" Visible="false"></asp:TextBox><br />
               <asp:Label ID="Label25" runat="server" style="font-weight: bold" Text="Date: " Visible="false">
               </asp:Label><asp:TextBox ID="txtEEDate" runat="server" BackColor="#FFFFFF" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True" Visible="false"></asp:TextBox><br />
               <asp:Label ID="Label21" runat="server" style="font-weight: bold" Text="Date: " Visible="false">
               </asp:Label><asp:TextBox ID="txtSupFinDate" runat="server" BackColor="#FFFFFF" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True" Visible="false"></asp:TextBox><br />
               <asp:Label ID="Label26" runat="server" style="font-weight: bold" Text="Date: " Visible="false">
               </asp:Label><asp:TextBox ID="txtSupDate" runat="server" BackColor="#FFFFFF" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True" Visible="false"></asp:TextBox><br />
               <asp:Label ID="Label22" runat="server" style="font-weight: bold" Text="Date: " Visible="false">
               </asp:Label><asp:TextBox ID="txtHRCDate" runat="server" BackColor="#FFFFFF" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True" Visible="false"></asp:TextBox><br />
               <asp:Label ID="Label23" runat="server" style="font-weight: bold" Text="Date: " Visible="false">
               </asp:Label><asp:TextBox ID="txtHRMDate" runat="server" BackColor="#FFFFFF" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True" Visible="false"></asp:TextBox><br />  
            </div>
    </div>     --%>
    <br />
    <br />
    <br />
    <br />
        <asp:TextBox ID="txtAssignedGeneralist" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" Width="100%" ReadOnly="True" Visible="false"></asp:TextBox>

    </div>
    <asp:TextBox ID="currentLevel" runat="server" Visible="false"></asp:TextBox>
</asp:Content>

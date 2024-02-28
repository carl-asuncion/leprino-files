<%@ Page Title="Edit Counseling" Language="C#" MasterPageFile="~/HumanResources/HRSite.Master" AutoEventWireup="true" CodeBehind="EditCounseling.aspx.cs" Inherits="lewHRISlocal.HumanResources.EditCounseling" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>  

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <div style="background-color: rgba(255, 255, 255, 0.6); padding: 10px;  border-radius: 10px;">
    
    <div>
    <br />
        <h1>Counseling Record</h1>
            <p>
                <asp:Table ID="Table1" runat="server" Width="100%">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button ID="Button3" runat="server" Text="&laquo; Back" class="w3-btn w3-light-grey w3-ripple w3-round-large" OnClientClick="JavaScript:window.history.back(1); return false;"/>
                            <%--<asp:Button ID="Button2" runat="server" Text="Edit &raquo;" class="btn btn-default" OnClick="btnUpdate_Click"/>--%>
                            <%--<asp:Label ID="LabelAccess" runat="server" Text="Label" Font-Italic="True"></asp:Label>--%>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Right">
                            <%--<asp:LinkButton ID="LinkButton1"  class="btn btn-primary" runat="server" OnClick="LinkButton1_Click"><i class="fa fa-download"></i> Print View</asp:LinkButton>--%>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </p>
            
        <div class="row  form-inline" style="font-family: Arial;">  
            <div class="col-md-5">
                <asp:Label ID="Label27" runat="server" style="font-weight: bold" Text="Counseling ID: "></asp:Label>
                <asp:TextBox ID="txtCounselingID" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label28" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox6" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div> 
            <div class="col-md-5">
                <asp:Label ID="Label29" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="txtSupEmail" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div>
            <div class="col-md-1">

            </div>
        </div>
        <div class="row form-inline" style="font-family: Arial;">  
            <div class="col-md-5">
                <asp:Label ID="Label12" runat="server" style="font-weight: bold" Text="Incident Date: "></asp:Label>
                <%--<asp:TextBox ID="txtDateIncident" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>--%>
                <div style="width: 100%">
                    <asp:TextBox ID="txtDateToday" runat="server" CssClass="w3-datetime w3-border w3-round" Height="36px" Width="120px"></asp:TextBox>
                    <asp:TextBox ID="txtTime" runat="server" CssClass="w3-datetime w3-border w3-round" Height="36px" Width="120px"></asp:TextBox>
                </div>
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
                <asp:Label ID="Label1" runat="server" style="font-weight: bold" Text="Employee Name: "></asp:Label>
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
                <asp:TextBox ID="txtSupervisor" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div> 
            <div class="col-md-5">
                <asp:Label ID="Label4" runat="server" style="font-weight: bold" Text="Department: "></asp:Label>
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
                    <asp:TextBox ID="TextBox1" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
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
                <asp:Label ID="Label7" runat="server" style="font-weight: bold" Text="Category: "></asp:Label>
                <%--<asp:TextBox ID="txtCategory" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>--%>
                <asp:DropDownList ID="txtCategory" runat="server" DataSourceID="HRIS" DataTextField="Category" DataValueField="Category" 
                    AutoPostBack="True" CssClass="w3-select  w3-round" Height="36px" Width="100%" OnTextChanged="DropDownList1_TextChanged"></asp:DropDownList>            
                <asp:SqlDataSource ID="HRIS" runat="server" ConnectionString="<%$ ConnectionStrings:LEW_HRIS_LocalConnectionString %>" SelectCommand="SELECT [Category] FROM [CategoryList]"></asp:SqlDataSource>
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
                <asp:Label ID="Label9" runat="server" style="font-weight: bold" Text="Sub-Category: "></asp:Label>
                <asp:TextBox ID="txtSubCategory" runat="server" CssClass="w3-input w3-border w3-round" Font-Size="Small" Width="100%"></asp:TextBox>
                <asp:DropDownList ID="ddSubCategory" runat="server"  CssClass="w3-select  w3-round" Height="36px" Width="100%" AutoPostBack="True" OnTextChanged="ddSubCategory_TextChanged" ></asp:DropDownList>
               <%-- <asp:DropDownList ID="myCategory" runat="server" DataSourceID="SqlDataSource1" DataTextField="Category" DataValueField="Category" Height="36px" Width="100%" OnTextChanged="CategoryList_TextChanged" AutoPostBack="True" CssClass="w3-select  w3-round">
                <asp:ListItem Selected="True">--Select a category--</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LEW_HRIS_LocalConnectionString %>" SelectCommand="SELECT [Category] FROM [CategoryList]" ></asp:SqlDataSource>
			--%></div>
            <div class="col-md-1">
                <asp:Label ID="Label40" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="txtEmployeeUserName" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div>
            <div class="col-md-5">
                <asp:Label ID="Label11" runat="server" style="font-weight: bold" Text="Overall Status: "></asp:Label>
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
            </asp:Label><br /><asp:TextBox ID="txtEmployeeComments" runat="server" TextMode="MultiLine" Rows="10" Width="100%" CssClass="w3-input w3-border w3-round" ReadOnly="true"></asp:TextBox></p>

            <p><asp:Label ID="Label14" runat="server" Text="Supervisor Comments: ">
            </asp:Label><br /><asp:TextBox ID="txtFollowUp" runat="server" TextMode="MultiLine" Rows="5" Width="100%" CssClass="w3-input w3-border w3-round" ReadOnly="true"></asp:TextBox></p>
    <hr style="border-width: 3px; border-color: #000000" />
    <div>
        <%--<asp:Label ID="Label15" runat="server">• <i>Acknowledge</i> to update record as "received."</asp:Label><br />--%>
        <asp:Label ID="Label18" runat="server">• <i>Process as Counseling</i> to move on to one-on-one with employee. "</asp:Label><br />
        <%--<asp:Label ID="Label20" runat="server">• <i>Revise</i> to send back to supervisor for revision."</asp:Label><br />--%>
        <asp:Label ID="Label16" runat="server">• <i>Close Case</i> to update case as "closed."</asp:Label><br />
        <asp:Label ID="Label19" runat="server">• <i>Dismiss</i> to void reported case."</asp:Label><br />
        <asp:Label ID="Label17" runat="server">• <i>Initialize Disciplinary Action</i> to forward case to a HR Generalist to start a formal disciplinary action.</asp:Label>
    </div>
    <hr style="border-width: 3px; border-color: #000000" />
        <div class="row">
            <div class="col-sm-3">
                <asp:LinkButton ID="btnApprove" runat="server" class="w3-btn w3-green w3-ripple w3-round-large w3-block" Font-Underline="false" OnClick="btnApprove_Click"><i class="fa fa-check"></i> Process as Counseling</asp:LinkButton>
            </div>        
                <%--<asp:LinkButton ID="btnRevise" runat="server" class="btn btn-primary" OnClick="btnRevise_Click"><i class="fa fa-pencil"></i> Revise</asp:LinkButton>--%>
                <%--<asp:LinkButton ID="btnAck" runat="server" class="w3-btn w3-green w3-ripple w3-round-large" Font-Underline="false" OnClick="btnAck_Click" Visible="false" ><i class="fa fa-check"></i> Process as Counseling</asp:LinkButton>--%>
            <div class="col-sm-3">         
                <asp:LinkButton ID="btnClose" runat="server" class="w3-btn w3-green w3-ripple w3-round-large w3-block" Font-Underline="false" OnClick="btnClose_Click" ><i class="fa fa-close"></i> Close Case</asp:LinkButton>
            </div>   
            <div class="col-sm-3">
                <asp:LinkButton ID="btnDismiss" runat="server" class="w3-btn w3-green w3-ripple w3-round-large w3-block" Font-Underline="false" OnClick="btnDismiss_Click" ><i class="fa fa-ban"></i> Dismiss Case</asp:LinkButton>
            </div>
            <div class="col-lg-3">
                <asp:LinkButton ID="btnInitialize" runat="server" class="w3-btn w3-green w3-ripple w3-round-large w3-block" Font-Underline="false" OnClick="btnInitialize_Click" ><i class="fa fa-folder"></i> Initialize Disciplinary Action</asp:LinkButton>
            </div>
        </div>
        <div class="row">
            <asp:Label ID="pagelabel" runat="server" Font-Italic="True"></asp:Label>
        </div>
    <asp:ListBox ID="ListBox1" runat="server" Visible="False"></asp:ListBox>
    <br />
    <br />
    <br />
    </div>
    <asp:TextBox ID="currentLevel" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="currentSubCategory" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="counselingCount" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="disciplinaryCount" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="openCasesCount" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="subGroup" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="listofEmails" runat="server" Visible="false"></asp:TextBox>


    <script type="text/javascript">
        function showAlert() {
            document.getElementById('sendAlert').style.display = 'block';
            return false;
        }

        <%--function showValue() {
            var labcost = document.getElementById('<%= departmentList.ClientID %>').innerHTML;
            alert(labcost);
            return false;
        }--%>
    </script>
</asp:Content>

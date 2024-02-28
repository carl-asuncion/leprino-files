<%@ Page Title="Disciplinary Detail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisciplinaryDetail.aspx.cs" Inherits="lewHRISlocal.Supervisors.DisciplinaryDetail" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color: rgba(255, 255, 255, 0.6); padding: 10px; border-radius: 10px; ">
    <div>
    <br />
        <h1>Disciplinary Record</h1>
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
                <asp:Label ID="Label26" runat="server" style="font-weight: bold" Text="Disciplinary ID: "></asp:Label>
                <asp:TextBox ID="txtDisciplinaryID" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label34" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox4" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div> 
            <div class="col-md-5">
                <asp:Label ID="Label38" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox7" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div>
            <div class="col-md-1">

            </div>
        </div>
        <div class="row  form-inline" style="font-family: Arial;">  
            <div class="col-md-5">
                <asp:Label ID="Label1" runat="server" style="font-weight: bold" Text="Counseling ID: "></asp:Label>
                <asp:TextBox ID="txtCounselingID" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label23" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox6" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div> 
            <div class="col-md-5">
                <asp:Label ID="Label24" runat="server" Text="ID Number: " Visible="false"></asp:Label>
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
                <asp:Label ID="Label2" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div> 
            <div class="col-md-5">
                <asp:Label ID="Label3" runat="server" style="font-weight: bold" Text="Date Entered: "></asp:Label>
                <asp:TextBox ID="txtDateEntered" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">

            </div>
        </div>
        <div class="row" style="font-family: Arial;">  
            <div class="col-md-5">
                <asp:Label ID="Label4" runat="server" style="font-weight: bold" Text="Employee ID: "></asp:Label>
                <asp:TextBox ID="txtEmpID" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label33" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox5" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div> 
            <div class="col-md-5">
                <asp:Label ID="Label7" runat="server" style="font-weight: bold" Text="Employee Name: "></asp:Label>
                <asp:TextBox ID="txtEmployeeName" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">

            </div>
        </div>
        <div class="row" style="font-family: Arial;">  
            <div class="col-md-5">
                <asp:Label ID="Label9" runat="server" style="font-weight: bold" Text="Position: "></asp:Label>
                <asp:TextBox ID="txtPosition" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label32" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div> 
            <div class="col-md-5">
                <asp:Label ID="Label22" runat="server" style="font-weight: bold" Text="Department: "></asp:Label>
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
                <asp:Label ID="Label10" runat="server" style="font-weight: bold" Text="Category: "></asp:Label>
                <asp:TextBox ID="txtCategory" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label37" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="txtEmployeeSigned" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div>
            <div class="col-md-5">
                <asp:Label ID="Label11" runat="server" style="font-weight: bold" Text="Counseling Level: "></asp:Label>
                <asp:TextBox ID="txtLevel" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
            
            </div>
        </div> 

        <div class="row" style="font-family: Arial;">  
            <div class="col-md-5">
                <asp:Label ID="Label21" runat="server" style="font-weight: bold" Text="Sub-Category: "></asp:Label>
                <asp:TextBox ID="txtSubCategory" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" Width="100%" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label40" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="txtEmployeeUserName" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div>
            <div class="col-md-5">
                <asp:Label ID="Label25" runat="server" style="font-weight: bold" Text="Overall Status: "></asp:Label>
                <asp:TextBox ID="txtOverallStatus" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" Width="100%" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-md-1">
            
            </div>
        </div> 
        
   
    </div>
    <hr style="border-width: 3px; border-color: #000000" />
            <h3>Current Disciplinary Level: </h3>
            <p><asp:Label ID="Label27" runat="server" style="font-size: 10px" Text="Management reserves the right to use appropriate discipline given the circumstances, up to and including termination."></asp:Label></p>
            <p><asp:Label ID="Label28" runat="server" style="font-weight: bold" Text="$1000 or More In Damage Assessed? "></asp:Label><asp:TextBox ID="txtDamageValue" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" Width="300px" ReadOnly="True"></asp:TextBox></p>
            <p><asp:Label ID="Label29" runat="server" style="font-weight: bold" Text="Disciplinary Count: "></asp:Label><asp:TextBox ID="txtCounselingCount" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" Width="300px" ReadOnly="True"></asp:TextBox></p>
            <p><asp:Label ID="Label30" runat="server" style="font-weight: bold" Text="Suspension Date/s: "></asp:Label><asp:TextBox ID="txtSuspensionDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" Width="300px" ReadOnly="True"></asp:TextBox></p>
            <p><asp:Label ID="Label31" runat="server" style="font-weight: bold" Text="RTW: "></asp:Label><asp:TextBox ID="txtRTW" runat="server"  BackColor="Transparent" BorderStyle="None" Font-Size="Small" Width="300px" ReadOnly="True"></asp:TextBox></p>
    <hr style="border-width: 3px; border-color: #000000" />

    
            <h3>Incident Details</h3>
            <p><asp:Label ID="Label5" runat="server" Text="Subject: ">
            </asp:Label>
            <asp:TextBox ID="txtSubject" runat="server" Width="100%"></asp:TextBox></p>
            <p><asp:Label ID="Label6" runat="server" Text="Incident Description: ">
            </asp:Label><br /><asp:TextBox ID="txtSupComments" runat="server" TextMode="MultiLine" Rows="10" Width="100%" ReadOnly="True"></asp:TextBox></p>
            
    <hr style="border-width: 3px; border-color: #000000" />
            <h3>Employee Comments</h3>
            <p><asp:Label ID="Label8" runat="server" Text="Employee Comments: ">
            </asp:Label><br /><asp:TextBox ID="txtEmployeeComments" runat="server" TextMode="MultiLine" Rows="10" Width="100%" ReadOnly="False"></asp:TextBox></p>

           
    <asp:Button ID="btnEmployeeSign" runat="server" Text="Authenticate Employee &raquo;" class="w3-btn w3-red w3-ripple w3-round-large" OnClick="btnEmployeeSign_Click"/>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnAuthenticate">
        <div>
            <asp:Label ID="Label16" runat="server" Text="Employee Username: " style="font-weight: bold"></asp:Label><asp:TextBox ID="txtUserName" runat="server" CssClass="w3-bar-item w3-input w3-border w3-round" autocomplete="off"></asp:TextBox>
            <asp:Label ID="Label15" runat="server" Text="Employee Password: " style="font-weight: bold"></asp:Label><asp:TextBox ID="txtPassWord" runat="server" TextMode="Password" CssClass="w3-bar-item w3-input w3-border w3-round" autocomplete="off"></asp:TextBox>
            <br />
            <asp:Button ID="btnAuthenticate" runat="server" Text="Authenticate" class="w3-btn w3-green w3-ripple w3-round-large" OnClick="btnAuthenticate_Click"/>
        </div>
    </asp:Panel>
    <asp:Label ID="Authenticated" runat="server" Text="Label" Visible="false" Font-Italic="true" ForeColor="Red"></asp:Label>
    <asp:Label ID="Label17" runat="server" Text="<br />By clicking the Acknowledge/Refuse button, the employee is agreeing that he/she was informed of an area that requires immediate improvement. This correspondence will be kept on file as documentation of the discussion.<br />"></asp:Label>
    <asp:Label ID="Label19" runat="server" Text="Employee Acknowledged/Refused to Acknowledge corrective action." BorderStyle="None" Font-Italic="True"></asp:Label>
    <div>
        <asp:Button ID="btnReject" runat="server" Text="Refuse to Acknowledge &raquo;" class="w3-btn w3-deep-orange w3-ripple w3-round-large" OnClick="btnReject_Click" BackColor="#FF3300"/>
        &nbsp&nbsp
        <asp:Button ID="btnUpdate" runat="server" Text="Acknowledge &raquo;" class="w3-btn w3-green w3-ripple w3-round-large" OnClick="btnUpdate_Click" BackColor="#339966" />
    </div>
    
    <hr style="border-width: 3px; border-color: #000000" />
        <p><asp:Label ID="Label14" runat="server" Text="Supervisor Comments: ">
        </asp:Label><br /><asp:TextBox ID="txtFollowUp" runat="server" TextMode="MultiLine" Rows="5" Width="100%"></asp:TextBox></p>


        <asp:Label ID="Label20" runat="server" Text="Supervisor Acknowledged corrective action.<br />" Font-Italic="True"></asp:Label>
        <asp:Label ID="ackstatement" runat="server" Text="By clicking the 'Acknowledge' button, the supervisor is agreeing that he/she has informed the employee mentioned above of the disciplinary action initiated by the HR Department. This correspondence will be kept on file as documentation of the discussion."></asp:Label>    
        <asp:TextBox ID="timedateAck" runat="server" TextMode="SingleLine" Width="100%" Enabled="false" ReadOnly="true" Font-Italic="True"></asp:TextBox><br />
        <asp:Button ID="btnSubmit" runat="server" Text="Acknowledge &raquo;" class="w3-btn w3-green w3-ripple w3-round-large" OnClick="btnSubmit_Click" BackColor="#339966" />
        <div>
            <asp:Label ID="Label18" runat="server" Text="<br />Select who to forward corrective action to: <br />" Font-Bold="True"></asp:Label>
            <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple"></asp:ListBox><br />
            <asp:Button ID="Button2" runat="server" Text="Send Correspondence" OnClick="Button2_Click" CssClass="w3-btn w3-light-grey w3-ripple w3-round-large"/>
        </div>
    

    <hr style="border-width: 3px; border-color: #000000" />

    <%--<div>
        By clicking the "Refuse to Acknowledge" button, the employee is only refusing to acknowledge the disciplinary action initiated by the HR Department. This correspondence will still be sent to HR and will be kept on file as documentation of the discussion.
    </div><br />
    <asp:TextBox ID="TextBox1" runat="server" TextMode="SingleLine" Width="100%" Enabled="false" ReadOnly="true" Font-Italic="True"></asp:TextBox><br /><br />
            <p>
                <!--a class="btn btn-default" href="/Supervisors/SupervisorDash">Update &raquo;</a-->
                <asp:Button ID="btnReject" runat="server" Text="Refuse to Acknowledge &raquo;" class="btn btn-default" OnClick="btnReject_Click" BackColor="#FF3300"/>
            </p>--%>
    <br />
    <br />
    <br />
    <br />
    </div>
</asp:Content>

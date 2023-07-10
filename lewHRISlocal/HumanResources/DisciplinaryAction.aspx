<%@ Page Title="Disciplinary Detail" Language="C#" MasterPageFile="~/HumanResources/HRSite.Master" AutoEventWireup="true" CodeBehind="DisciplinaryAction.aspx.cs" Inherits="lewHRISlocal.HumanResources.DisciplinaryAction" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <div>
    <br />
        <h1>Disciplinary Action Record</h1>
            <p>
                <asp:Button ID="Button1" runat="server" Text="&laquo; Back" class="w3-btn w3-light-grey w3-ripple w3-round-large" OnClientClick="JavaScript:window.history.back(1); return false;"/>
                <%--<asp:Label ID="LabelAccess" runat="server" Text="Label" Font-Italic="True"></asp:Label>--%>
            </p>
        <asp:Table ID="Table2" runat="server" Width="100%">
            <asp:TableRow>
                <asp:TableCell Width="150px"><asp:Label ID="Label43" runat="server" style="font-weight: bold" Text="Disciplinary ID: "></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtDisciplinaryID" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label44" runat="server" Text="ID Number: " Visible="false"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBox4" runat="server" class="txtboxes" Visible="false"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label45" runat="server" Text="ID Number: " Visible="false"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBox8" runat="server" class="txtboxes" Visible="false"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="150px"><asp:Label ID="Label1" runat="server" style="font-weight: bold" Text="Counseling ID: "></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtCounselingID" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label2" runat="server" Text="ID Number: " Visible="false"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBox6" runat="server" class="txtboxes" Visible="false"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label3" runat="server" Text="ID Number: " Visible="false"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBox7" runat="server" class="txtboxes" Visible="false"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="150px"><asp:Label ID="Label12" runat="server" style="font-weight: bold" Text="Incident Date: "></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtDateIncident" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label4" runat="server" Text="ID Number: " Visible="false"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBox2" runat="server" class="txtboxes" Visible="false"></asp:TextBox></asp:TableCell>
                <asp:TableCell Width="150px"><asp:Label ID="Label7" runat="server" style="font-weight: bold" Text="Date Entered: "></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtDateEntered" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="150px"><asp:Label ID="Label9" runat="server" style="font-weight: bold" Text="Employee ID: "></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtEmpID" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label33" runat="server" Text="ID Number: " Visible="false"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBox5" runat="server" class="txtboxes" Visible="false"></asp:TextBox></asp:TableCell>
                <asp:TableCell Width="150px"><asp:Label ID="Label10" runat="server" style="font-weight: bold" Text="Employee Name: "></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtEmployeeName" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="150px"><asp:Label ID="Label11" runat="server" style="font-weight: bold" Text="Position: "></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtPosition" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label32" runat="server" Text="ID Number: " Visible="false"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBox3" runat="server" class="txtboxes" Visible="false"></asp:TextBox></asp:TableCell>
                <asp:TableCell Width="150px"><asp:Label ID="Label13" runat="server" style="font-weight: bold" Text="Department: "></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtDepartment" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="150px"><asp:Label ID="Label34" runat="server" style="font-weight: bold" Text="Employee Status: "></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtEEStatus" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label35" runat="server" Text="ID Number: " Visible="false"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBox9" runat="server" class="txtboxes" Visible="false"></asp:TextBox></asp:TableCell>
                <asp:TableCell Width="150px"><asp:Label ID="Label36" runat="server" Text="ID Number: " Visible="false"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBox10" runat="server" class="txtboxes" Visible="false"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="150px"><asp:Label ID="Label37" runat="server" style="font-weight: bold" Text="Category: "></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtCategory" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label38" runat="server" Text="ID Number: " Visible="false"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBox11" runat="server" class="txtboxes" Visible="false"></asp:TextBox></asp:TableCell>
                <asp:TableCell Width="150px"><asp:Label ID="Label39" runat="server" style="font-weight: bold" Text="Counseling Level: "></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtLevel" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="150px"><asp:Label ID="Label40" runat="server" style="font-weight: bold" Text="Sub-Category: "></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtSubCategory" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" Width="100%" ReadOnly="True"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:Label ID="Label41" runat="server" Text="ID Number: " Visible="false"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtSupervisor" runat="server" class="txtboxes" Visible="false"></asp:TextBox></asp:TableCell>
                <asp:TableCell Width="150px"><asp:Label ID="Label42" runat="server" style="font-weight: bold" Text="Overall Status: "></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtOverallStatus" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" Width="100%" ReadOnly="True"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
   
    </div>
    <hr style="border-width: 3px; border-color: #000000" />
            <h3>Current Disciplinary Level: </h3>
            <p><asp:Label ID="Label27" runat="server" style="font-size: 10px" Text="Management reserves the right to use appropriate discipline given the circumstances, up to and including termination."></asp:Label></p>
            <p><asp:Label ID="Label28" runat="server" style="font-weight: bold" Text="$1000 or More In Damage Assessed? "></asp:Label><asp:TextBox ID="txtDamageValue" runat="server" Width="100px" Font-Names="Calibri" Font-Size="Medium"></asp:TextBox></p>
            <p><asp:Label ID="Label29" runat="server" style="font-weight: bold" Text="Disciplinary Count: "></asp:Label><asp:TextBox ID="txtCounselingCount" runat="server" Width="300px" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox></p>
            <p><asp:Label ID="Label30" runat="server" style="font-weight: bold" Text="Suspension Date/s: "></asp:Label><asp:TextBox ID="txtSuspensionDate" runat="server" Width="300px" Font-Names="Calibri" Font-Size="Medium" TextMode="Date"></asp:TextBox></p>
            <p><asp:Label ID="Label31" runat="server" style="font-weight: bold" Text="RTW: "></asp:Label><asp:TextBox ID="txtRTW" runat="server" Width="300px" Font-Names="Calibri" Font-Size="Medium" TextMode="Date"></asp:TextBox></p>
    <hr style="border-width: 3px; border-color: #000000" />

    
            <h3>Incident Details</h3>
            <p><asp:Label ID="Label5" runat="server" Text="Subject: "> </asp:Label>
            <asp:TextBox ID="txtSubject" runat="server" Width="100%"></asp:TextBox></p>
            <p><asp:Label ID="Label6" runat="server" Text="Incident Description: "> </asp:Label><br /><asp:TextBox ID="txtSupComments" runat="server" TextMode="MultiLine" Rows="10" Width="100%" ReadOnly="True"></asp:TextBox></p>
            

            <h3>Employee Comments</h3>
            <p><asp:Label ID="Label8" runat="server" Text="Employee Comments: "> </asp:Label><br /><asp:TextBox ID="txtEmployeeComments" runat="server" TextMode="MultiLine" Rows="10" Width="100%" ReadOnly="True"></asp:TextBox></p>

            <p><asp:Label ID="Label14" runat="server" Text="Supervisor Comments: "> </asp:Label><br /><asp:TextBox ID="txtFollowUp" runat="server" TextMode="MultiLine" Rows="5" Width="100%" ReadOnly="True"></asp:TextBox></p>
    <hr style="border-width: 3px; border-color: #000000" />
    <br />
    <div class="row">
            <div class="col-md-6">
                <asp:Label ID="Label19" runat="server" style="font-weight: bold" Text="Employee Counseling Signed: "> </asp:Label><asp:TextBox ID="txtEEAck" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label15" runat="server" style="font-weight: bold" Text="Employee Disciplinary Signed: "> </asp:Label><asp:TextBox ID="txtEESigned" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
                <asp:Label ID="Label24" runat="server" style="font-weight: bold" Text="Supervisor Counseling Signed: "> </asp:Label><asp:TextBox ID="txtSupFin" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label16" runat="server" style="font-weight: bold" Text="Supervisor Disciplinary Signed: "> </asp:Label><asp:TextBox ID="txtSupSigned" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label17" runat="server" style="font-weight: bold" Text="HR Clerk Signed: "> </asp:Label><asp:TextBox ID="txtHRCSigned" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label18" runat="server" style="font-weight: bold" Text="HR Manager Signed: "> </asp:Label><asp:TextBox ID="txtHRMSigned" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
            </div>
            <div class="col-md-6">
               <asp:Label ID="Label20" runat="server" style="font-weight: bold" Text="Date: "> </asp:Label><asp:TextBox ID="txtEEAckDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label25" runat="server" style="font-weight: bold" Text="Date: "> </asp:Label><asp:TextBox ID="txtEEDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label21" runat="server" style="font-weight: bold" Text="Date: "> </asp:Label><asp:TextBox ID="txtSupFinDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label26" runat="server" style="font-weight: bold" Text="Date: "> </asp:Label><asp:TextBox ID="txtSupDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label22" runat="server" style="font-weight: bold" Text="Date: "> </asp:Label><asp:TextBox ID="txtHRCDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label23" runat="server" style="font-weight: bold" Text="Date: "> </asp:Label><asp:TextBox ID="txtHRMDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />  
            </div>
    </div>     
    <br />
    <hr style="border-width: 3px; border-color: #000000" />
        <asp:Label ID="Label49" runat="server" Text="Meeting Details <br />" Font-Size="Larger" ></asp:Label>
        <asp:Label ID="Label50" runat="server" Text="Label<br />" Font-Size="Larger" ></asp:Label>
            <asp:Label ID="Label46" runat="server" style="font-weight: bold;" Text="Select all supervisor(s) and/or managers to invite: <br />"></asp:Label>
            &emsp;<asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="10" Width="25%"></asp:ListBox>
            <asp:Label ID="Label47" runat="server" style="font-weight: bold" Text="<br />Start Date/Time: "></asp:Label>&ensp;
            <asp:TextBox ID="txtStartDate" runat="server" Width="131px" TextMode="Date"></asp:TextBox> <asp:TextBox ID="txtStartTime" runat="server" Width="131px" TextMode="Time"></asp:TextBox>
            <asp:Label ID="Label48" runat="server" style="font-weight: bold" Text="<br />End Date/Time: "></asp:Label>&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEndDate" runat="server" Width="131px" TextMode="Date"></asp:TextBox> <asp:TextBox ID="txtEndTime" runat="server" Width="131px" TextMode="Time"></asp:TextBox>

    <hr style="border-width: 3px; border-color: #000000" />
        <div class="row">
            <div class="col-lg-12">
                <%--<asp:LinkButton ID="btnScheduleMeeting" runat="server" class="btn btn-primary" OnClientClick="TriggerOutlook()"><i class="fa fa-calendar"></i> Schedule Meeting</asp:LinkButton>--%>
                <%--<asp:LinkButton ID="btnScheduleMeeting" runat="server" class="btn btn-primary" OnClick="btnScheduleMeeting_Click"><i class="fa fa-calendar"></i> Schedule Meeting</asp:LinkButton>--%>
                <asp:LinkButton ID="btnSendtoDeptwInvite" runat="server" class="w3-btn w3-green w3-ripple w3-round-large" OnClick="btnSendtoDeptwInvite_Click" ><i class="fa fa-mail-forward"></i> Approved - Send to Department</asp:LinkButton>
                <%--<asp:LinkButton ID="btnSendtoDept" runat="server" class="btn btn-primary" OnClick="btnSendtoDept_Click" ><i class="fa fa-mail-forward"></i> Approved - Send to Department</asp:LinkButton>--%>
                <asp:LinkButton ID="btnClose" runat="server" class="w3-btn w3-green w3-ripple w3-round-large" OnClick="btnClose_Click" ><i class="fa fa-check"></i> Finalize Diciplinary Action</asp:LinkButton>
                <asp:Label ID="LabelAccess" runat="server" Font-Italic="True"></asp:Label>
                <asp:Label ID="pagelabel" runat="server" Font-Italic="True"></asp:Label>
            </div>
        </div>
    <br />
    <br />
    <br />
    <%--<script type="text/javascript">
        function TriggerOutlook() {
            alert("Hello");
            //var body = escape(window.document.title + String.fromCharCode(13) + window.location.href);

            //var subject = "Take a look at this cool code snippet from CodeDigest.Com!!";

            //window.location.href = "file:///C:\Program Files\Microsoft Office\root\Office16\OUTLOOK.EXE"";
            //window.open('file:\\C:\Program Files\Microsoft Office\root\Office16\OUTLOOK.EXE');
            window.open("https://outlook.office.com/calendar/view/month",);
            alert("Hello again");
        }
    </script>--%>
</asp:Content>

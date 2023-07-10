<%@ Page Title="Disciplinary Detail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisciplinaryDetail.aspx.cs" Inherits="lewHRISlocal.Employees.DisciplinaryDetail" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <br />
        <h1>Disciplinary Record</h1>
            <p>
                <asp:Table ID="Table1" runat="server" Width="100%">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button ID="Button1" runat="server" Text="&laquo; Back" class="btn btn-secondary" OnClientClick="JavaScript:window.history.back(1); return false;"/>
                            <%--<asp:Button ID="Button2" runat="server" Text="Edit &raquo;" class="btn btn-default" OnClick="btnUpdate_Click"/>
                            <asp:Label ID="LabelAccess" runat="server" Text="Label" Font-Italic="True"></asp:Label>--%>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Right">
                            <%--<asp:LinkButton ID="LinkButton1"  class="btn btn-primary" runat="server" OnClick="LinkButton1_Click"><i class="fa fa-download"></i> Print View</asp:LinkButton>--%>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
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
                <asp:TableCell><asp:TextBox ID="TextBox14" runat="server" class="txtboxes" Visible="false"></asp:TextBox></asp:TableCell>
                <asp:TableCell Width="150px"><asp:Label ID="Label42" runat="server" style="font-weight: bold" Text="Overall Status: "></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtOverallStatus" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" Width="100%" ReadOnly="True"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
   
    </div>
    <hr style="border-width: 3px; border-color: #000000" />
            <h3>Current Disciplinary Level: </h3>
            <p><asp:Label ID="Label27" runat="server" style="font-size: 10px" Text="Management reserves the right to use appropriate discipline given the circumstances, up to and including termination."></asp:Label></p>
            <p><asp:Label ID="Label28" runat="server" style="font-weight: bold" Text="$1000 or More In Damage Assessed? "></asp:Label><asp:TextBox ID="txtDamageValue" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" Width="300px" ReadOnly="True"></asp:TextBox></p>
            <p><asp:Label ID="Label29" runat="server" style="font-weight: bold" Text="Disciplinary Count: "></asp:Label><asp:TextBox ID="txtCounselingCount" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" Width="300px" ReadOnly="True"></asp:TextBox></p>
            <p><asp:Label ID="Label30" runat="server" style="font-weight: bold" Text="Suspension Date/s: "></asp:Label><asp:TextBox ID="txtSuspensionDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" Width="300px" ReadOnly="True"></asp:TextBox></p>
            <p><asp:Label ID="Label31" runat="server" style="font-weight: bold" Text="RTW: "></asp:Label><asp:TextBox ID="txtRTW" runat="server"  BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" Width="300px" ReadOnly="True"></asp:TextBox></p>
    <hr style="border-width: 3px; border-color: #000000" />

    
            <h3>Incident Details</h3>
            <p><asp:Label ID="Label5" runat="server" Text="Subject: ">
            </asp:Label>
            <asp:TextBox ID="txtSubject" runat="server" Width="100%"></asp:TextBox></p>
            <p><asp:Label ID="Label6" runat="server" Text="Incident Description: ">
            </asp:Label><br /><asp:TextBox ID="txtSupComments" runat="server" TextMode="MultiLine" Rows="10" Width="100%" ReadOnly="True"></asp:TextBox></p>
            

            <h3>Employee Comments</h3>
            <p><asp:Label ID="Label8" runat="server" Text="Employee Comments: ">
            </asp:Label><br /><asp:TextBox ID="txtEmployeeComments" runat="server" TextMode="MultiLine" Rows="10" Width="100%" ReadOnly="True"></asp:TextBox></p>

            <p><asp:Label ID="Label14" runat="server" Text="Supervisor Comments: ">
            </asp:Label><br /><asp:TextBox ID="txtFollowUp" runat="server" TextMode="MultiLine" Rows="5" Width="100%" ReadOnly="True"></asp:TextBox></p>
    <hr style="border-width: 3px; border-color: #000000" />
    <br />
    <%--<div class="row">
            <div class="col-md-6">
                <asp:Label ID="Label19" runat="server" style="font-weight: bold" Text="Employee Counseling Signed: ">
               </asp:Label><asp:TextBox ID="txtEEAck" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label15" runat="server" style="font-weight: bold" Text="Employee Disciplinary Signed: ">
               </asp:Label><asp:TextBox ID="txtEESigned" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
                <asp:Label ID="Label24" runat="server" style="font-weight: bold" Text="Supervisor Counseling Signed: ">
               </asp:Label><asp:TextBox ID="txtSupFin" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label16" runat="server" style="font-weight: bold" Text="Supervisor Disciplinary Signed: ">
               </asp:Label><asp:TextBox ID="txtSupSigned" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label17" runat="server" style="font-weight: bold" Text="HR Clerk Signed: ">
               </asp:Label><asp:TextBox ID="txtHRCSigned" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label18" runat="server" style="font-weight: bold" Text="HR Manager Signed: ">
               </asp:Label><asp:TextBox ID="txtHRMSigned" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
            </div>
            <div class="col-md-6">
               <asp:Label ID="Label20" runat="server" style="font-weight: bold" Text="Date: ">
               </asp:Label><asp:TextBox ID="txtEEAckDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label25" runat="server" style="font-weight: bold" Text="Date: ">
               </asp:Label><asp:TextBox ID="txtEEDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label21" runat="server" style="font-weight: bold" Text="Date: ">
               </asp:Label><asp:TextBox ID="txtSupFinDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label26" runat="server" style="font-weight: bold" Text="Date: ">
               </asp:Label><asp:TextBox ID="txtSupDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label22" runat="server" style="font-weight: bold" Text="Date: ">
               </asp:Label><asp:TextBox ID="txtHRCDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label23" runat="server" style="font-weight: bold" Text="Date: ">
               </asp:Label><asp:TextBox ID="txtHRMDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Names="Calibri" Font-Size="Medium" Enabled="False" ReadOnly="True"></asp:TextBox><br />  
            </div>
    </div>   --%>
    <div>
        By clicking the "Acknowledge" button, the employee is agreeing that he/she was informed of the disciplinary action initiated by the HR Department. This correspondence will be kept on file as documentation of the discussion.
    </div>
    <br />
    <asp:TextBox ID="timedateAck" runat="server" TextMode="SingleLine" Width="100%" Enabled="false" ReadOnly="true" Font-Italic="True"></asp:TextBox><br /><br />
            <p>
                <!--a class="btn btn-default" href="/Supervisors/SupervisorDash">Update &raquo;</a-->
                <asp:Button ID="btnUpdate" runat="server" Text="Acknowledge &raquo;" class="btn btn-default" OnClick="btnAck_Click" BackColor="#339966" />
            </p>
    <hr style="border-width: 3px; border-color: #000000" />
    <div>
        By clicking the "Refuse to Acknowledge" button, the employee is refusing to acknowledge the disciplinary action initiated by the HR Department. This correspondence will still be sent to HR and will be kept on file as documentation of the discussion.
    </div><br />
    <asp:TextBox ID="TextBox1" runat="server" TextMode="SingleLine" Width="100%" Enabled="false" ReadOnly="true" Font-Italic="True"></asp:TextBox><br /><br />
            <p>
                <!--a class="btn btn-default" href="/Supervisors/SupervisorDash">Update &raquo;</a-->
                <asp:Button ID="btnReject" runat="server" Text="Refuse to Acknowledge &raquo;" class="btn btn-default" OnClick="btnReject_Click" BackColor="#FF3300"/>
            </p>
    <br />
    <br />
    <br />
    <br />
</asp:Content>

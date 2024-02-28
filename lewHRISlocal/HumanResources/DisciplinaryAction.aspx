<%@ Page Title="Disciplinary Detail" Language="C#" MasterPageFile="~/HumanResources/HRSite.Master" AutoEventWireup="true" CodeBehind="DisciplinaryAction.aspx.cs" Inherits="lewHRISlocal.HumanResources.DisciplinaryAction" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <script src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.min.js'></script>
        <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
        <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <div style="background-color: rgba(255, 255, 255, 0.6); padding: 10px;  border-radius: 10px;">
    <div>
    <br />
        <h1>Disciplinary Action Record</h1>
            <p>
                <asp:Table ID="Table1" runat="server" Width="100%">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Button ID="Button1" runat="server" Text="&laquo; Back" class="w3-btn w3-light-grey w3-ripple w3-round-large" OnClientClick="JavaScript:window.history.back(1); return false;"/>                            <%--<asp:Button ID="Button2" runat="server" Text="Edit &raquo;" class="btn btn-default" OnClick="btnUpdate_Click"/>
                            <asp:Label ID="LabelAccess" runat="server" Text="Label" Font-Italic="True"></asp:Label>--%>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:LinkButton ID="Save"  class="w3-btn w3-green w3-ripple w3-round-large" Font-Underline="false" runat="server" OnClick="Save_Click"><i class="fa fa-save"></i> Save</asp:LinkButton>
                            &emsp;
                            <span id="Withdraw" class="w3-btn w3-red w3-ripple w3-round-large" onclick="showMeAdd()"><i class="fa fa-close"></i> Withdraw</span>
                            <%--<asp:LinkButton ID="Withdraw" class="w3-btn w3-red w3-ripple w3-round-large" Font-Underline="false" runat="server" OnClientClick="showMeAdd()"><i class="fa fa-close"></i> Withdraw</asp:LinkButton>--%>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </p>
            <p>
                
                <%--<asp:Label ID="LabelAccess" runat="server" Text="Label" Font-Italic="True"></asp:Label>--%>
            </p>
        <div class="row  form-inline" style="font-family: Arial;">  
            <div class="col-md-5">
                <asp:Label ID="Label43" runat="server" style="font-weight: bold" Text="Disciplinary ID: "></asp:Label>
                <asp:TextBox ID="txtDisciplinaryID" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                
            </div> 
            <div class="col-md-5">
                
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
                <asp:Label ID="Label2" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox6" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div> 
            <div class="col-md-5">
                <asp:Label ID="Label3" runat="server" Text="ID Number: " Visible="false"></asp:Label>
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
                <asp:Label ID="Label4" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div> 
            <div class="col-md-5">
                <asp:Label ID="Label7" runat="server" style="font-weight: bold" Text="Date Entered: "></asp:Label>
                <asp:TextBox ID="txtDateEntered" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">

            </div>
        </div>
        <div class="row" style="font-family: Arial;">  
            <div class="col-md-5">
                <asp:Label ID="Label9" runat="server" style="font-weight: bold" Text="Employee ID: "></asp:Label>
                <asp:TextBox ID="txtEmpID" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label33" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox5" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div> 
            <div class="col-md-5">
                <asp:Label ID="Label10" runat="server" style="font-weight: bold" Text="Employee Name: "></asp:Label>
                <asp:TextBox ID="txtEmployeeName" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">

            </div>
        </div>
        <div class="row" style="font-family: Arial;">  
            <div class="col-md-5">
                <asp:Label ID="Label11" runat="server" style="font-weight: bold" Text="Position: "></asp:Label>
                <asp:TextBox ID="txtPosition" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label32" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div> 
            <div class="col-md-5">
                <asp:Label ID="Label13" runat="server" style="font-weight: bold" Text="Department: "></asp:Label>
                <asp:TextBox ID="txtDepartment" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">

            </div>
        </div>
        <div class="row" style="font-family: Arial;">  
            <div class="col-md-5">
                <asp:Label ID="Label34" runat="server" style="font-weight: bold" Text="Employee Status: "></asp:Label>
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
                <asp:Label ID="Label37" runat="server" style="font-weight: bold" Text="Category: "></asp:Label>
                <asp:TextBox ID="txtCategory" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label38" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="txtEmployeeSigned" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div>
            <div class="col-md-5">
                <asp:Label ID="Label39" runat="server" style="font-weight: bold" Text="Counseling Level: "></asp:Label>
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
                <asp:Label ID="Label40" runat="server" style="font-weight: bold" Text="Sub-Category: "></asp:Label>
                <asp:TextBox ID="txtSubCategory" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" Width="100%" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-md-1">
                <asp:Label ID="Label41" runat="server" Text="ID Number: " Visible="false"></asp:Label>
                <asp:TextBox ID="txtEmployeeUserName" runat="server" class="txtboxes" Visible="false"></asp:TextBox>
            </div>
            <div class="col-md-5">
                <asp:Label ID="Label42" runat="server" style="font-weight: bold" Text="Overall Status: "></asp:Label>
                <asp:TextBox ID="txtOverallStatus" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" Width="100%" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-md-1">
            
            </div>
        </div> 
   
    </div>
   
    <hr style="border-width: 3px; border-color: #000000" />
            <h3>Current Disciplinary Level: </h3>
            <p><asp:Label ID="Label27" runat="server" style="font-size: 10px" Text="Management reserves the right to use appropriate discipline given the circumstances, up to and including termination."></asp:Label></p>
            <p><asp:Label ID="Label28" runat="server" style="font-weight: bold" Text="$1000 or More In Damage Assessed? "></asp:Label><asp:TextBox ID="txtDamageValue" runat="server" Font-Size="Small" Width="300px" CssClass="w3-input w3-border w3-round" ></asp:TextBox></p>
            <p><asp:Label ID="Label29" runat="server" style="font-weight: bold" Text="Disciplinary Count: "></asp:Label><asp:TextBox ID="txtCounselingCount" runat="server" Font-Size="Small" Width="300px" CssClass="w3-input w3-border w3-round" OnTextChanged="txtCounselingCount_TextChanged" AutoPostBack="True" ></asp:TextBox></p>
            <p><asp:Label ID="Label30" runat="server" style="font-weight: bold" Text="Suspension Date/s: "></asp:Label>
                <asp:TextBox ID="txtSuspensionDate" runat="server" Font-Size="Small" Width="300px" TextMode="Date" CssClass="w3-datetime w3-border w3-round" ></asp:TextBox>
                <asp:TextBox ID="txtSuspensionDate2" runat="server" Font-Size="Small" Width="300px" TextMode="Date" CssClass="w3-datetime w3-border w3-round" ></asp:TextBox>
                <asp:TextBox ID="txtSuspensionDate3" runat="server" Font-Size="Small" Width="300px" TextMode="Date" CssClass="w3-datetime w3-border w3-round" ></asp:TextBox>

            </p>
            <p><asp:Label ID="Label31" runat="server" style="font-weight: bold" Text="RTW: "></asp:Label>
                <asp:TextBox ID="txtRTW" runat="server" Font-Size="Small" Width="300px" TextMode="Date" CssClass="w3-datetime w3-border w3-round" ></asp:TextBox>
                <asp:TextBox ID="txtRTW2" runat="server" Font-Size="Small" Width="300px" TextMode="Date" CssClass="w3-datetime w3-border w3-round" ></asp:TextBox>
                <asp:TextBox ID="txtRTW3" runat="server" Font-Size="Small" Width="300px" TextMode="Date" CssClass="w3-datetime w3-border w3-round" ></asp:TextBox>

            </p>
    <hr style="border-width: 3px; border-color: #000000" />

    
            <h3>Incident Details</h3>
            <p><asp:Label ID="Label5" runat="server" Text="Subject: "> </asp:Label>
            <asp:TextBox ID="txtSubject" runat="server" Width="100%"></asp:TextBox></p>
            <p><asp:Label ID="Label6" runat="server" Text="Incident Description: "> </asp:Label><br /><asp:TextBox ID="txtSupComments" runat="server" TextMode="MultiLine" Rows="10" Width="100%" CssClass="w3-input w3-border w3-round"></asp:TextBox></p>
            

            <h3>Employee Comments</h3>
            <p><asp:Label ID="Label8" runat="server" Text="Employee Comments: "> </asp:Label><br /><asp:TextBox ID="txtEmployeeComments" runat="server" TextMode="MultiLine" Rows="10" Width="100%" CssClass="w3-input w3-border w3-round"></asp:TextBox></p>

            <p><asp:Label ID="Label14" runat="server" Text="Supervisor Comments: "> </asp:Label><br /><asp:TextBox ID="txtFollowUp" runat="server" TextMode="MultiLine" Rows="5" Width="100%" CssClass="w3-input w3-border w3-round"></asp:TextBox></p>
    <hr style="border-width: 3px; border-color: #000000" />
    <br />
    <div class="row" style="display: flex; align-items: flex-start;">
            <div class="col-md-6">
               <asp:Label ID="Label19" runat="server" style="font-weight: bold" Text="Employee Counseling Signed: "></asp:Label>
               <asp:TextBox ID="txtEEAck" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label20" runat="server" style="font-weight: bold" Text="Date: "></asp:Label>
               <asp:TextBox ID="txtEEAckDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox><br />
               <br /> 
               <asp:Label ID="Label15" runat="server" style="font-weight: bold" Text="Employee Disciplinary Signed: "></asp:Label>
               <asp:TextBox ID="txtEESigned" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label25" runat="server" style="font-weight: bold" Text="Date: "></asp:Label>
               <asp:TextBox ID="txtEEDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox><br />
               <br /> 
               <asp:Label ID="Label17" runat="server" style="font-weight: bold" Text="HR Clerk Signed: "></asp:Label>
               <asp:TextBox ID="txtHRCSigned" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label22" runat="server" style="font-weight: bold" Text="Date: "></asp:Label>
               <asp:TextBox ID="txtHRCDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox><br />
               <br />
            </div>
            <div class="col-md-6">
               <asp:Label ID="Label24" runat="server" style="font-weight: bold" Text="Supervisor Counseling Signed: "></asp:Label>
               <asp:TextBox ID="txtSupFin" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label21" runat="server" style="font-weight: bold" Text="Date: "></asp:Label>
               <asp:TextBox ID="txtSupFinDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox><br />
               <br />
               <asp:Label ID="Label16" runat="server" style="font-weight: bold" Text="Supervisor Disciplinary Signed: "></asp:Label>
               <asp:TextBox ID="txtSupSigned" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label26" runat="server" style="font-weight: bold" Text="Date: "></asp:Label>
               <asp:TextBox ID="txtSupDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox><br />
               <br />
               <asp:Label ID="Label18" runat="server" style="font-weight: bold" Text="HR Manager Signed: "></asp:Label>
               <asp:TextBox ID="txtHRMSigned" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True"></asp:TextBox><br />
               <asp:Label ID="Label23" runat="server" style="font-weight: bold" Text="Date: "></asp:Label>
               <asp:TextBox ID="txtHRMDate" runat="server" BackColor="Transparent" BorderStyle="None" Font-Size="Small" ReadOnly="True" Width="100%"></asp:TextBox><br />
            </div>
    </div>     
    <br />
    <hr style="border-width: 3px; border-color: #000000" />
        <div id="invitePanel" runat="server">
            <asp:Label ID="Label49" runat="server" Text="Meeting Details <br />" Font-Size="Larger" ></asp:Label>
            <asp:Label ID="Label50" runat="server" Text="Label<br />" Font-Size="Larger" ></asp:Label>
            <asp:Label ID="Label46" runat="server" style="font-weight: bold;" Text="Select all supervisor(s) and/or managers to invite: <br />"></asp:Label>
                &emsp;<asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="10" Width="25%" CssClass="w3-input w3-border w3-round"></asp:ListBox>
                <asp:Label ID="Label47" runat="server" style="font-weight: bold" Text="<br />Start Date/Time: "></asp:Label>&ensp;
                <asp:TextBox ID="txtStartDate" runat="server" Width="131px" TextMode="Date" CssClass="w3-datetime w3-border w3-round" ></asp:TextBox> <asp:TextBox ID="txtStartTime" runat="server" Width="131px" TextMode="Time" CssClass="w3-datetime w3-border w3-round" ></asp:TextBox>
                <asp:Label ID="Label48" runat="server" style="font-weight: bold" Text="<br />End Date/Time: "></asp:Label>&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtEndDate" runat="server" Width="131px" TextMode="Date" CssClass="w3-datetime w3-border w3-round" ></asp:TextBox> <asp:TextBox ID="txtEndTime" runat="server" Width="131px" TextMode="Time" CssClass="w3-datetime w3-border w3-round" ></asp:TextBox>

        </div>
    <hr style="border-width: 3px; border-color: #000000" />
        <div class="row">
            <div class="col-lg-6">
                <%--<asp:LinkButton ID="btnScheduleMeeting" runat="server" class="btn btn-primary" OnClientClick="TriggerOutlook()"><i class="fa fa-calendar"></i> Schedule Meeting</asp:LinkButton>--%>
                <%--<asp:LinkButton ID="btnScheduleMeeting" runat="server" class="btn btn-primary" OnClick="btnScheduleMeeting_Click"><i class="fa fa-calendar"></i> Schedule Meeting</asp:LinkButton>--%>
                <asp:LinkButton ID="btnSendtoDeptwInvite" runat="server" class="w3-btn w3-green w3-ripple w3-round-large w3-block" OnClick="btnSendtoDeptwInvite_Click" Font-Underline="false" ><i class="fa fa-mail-forward"></i> Approved - Send to Department</asp:LinkButton>
                <%--<asp:LinkButton ID="btnSendtoDept" runat="server" class="btn btn-primary" OnClick="btnSendtoDept_Click" ><i class="fa fa-mail-forward"></i> Approved - Send to Department</asp:LinkButton>--%>
            </div>
            <div class="col-lg-6">
                <asp:LinkButton ID="btnClose" runat="server" class="w3-btn w3-green w3-ripple w3-round-large w3-block" OnClick="btnClose_Click" Font-Underline="false"  ><i class="fa fa-check"></i> Finalize Diciplinary Action</asp:LinkButton>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
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
    </div>
    <asp:TextBox ID="currentLevel" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="subGroup" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="listofEmails" runat="server" Visible="false"></asp:TextBox>
    <!-- Modal -->

    <div id="id02" class="w3-modal w3-round-medium" >
      <div class="w3-modal-content w3-card-4 w3-animate-top w3-round-medium">
        <header class="w3-container w3-display-container w3-center w3-text-white" style="background-color: #1f66c9;"> 
          <span onclick="document.getElementById('id02').style.display='none'" class="w3-button w3-display-topright w3-hover-white myBack"><i class="fa fa-remove"></i></span>
          <%--<h4><strong>Leprino Foods Company, Lemoore West</strong></h4>--%>
          <h6>Withdraw Case</h6>
        </header>
        <div class="w3-container">
            <br />
            <p>Select reason for withdrawing case:</p>
            <br />
            <div class="w3-container w3-center w3-centered" style="width: 100%; margin: auto;">
              <%--<label for="uname"><b>Full Name: </b></label>--%>
                <asp:DropDownList ID="withdrawReason" runat="server" CssClass="w3-select  w3-round">
                    <asp:ListItem>Employee Status Withdrawn</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
                <br /> 
              <asp:Button ID="mybutton" runat="server" Text="Withdraw Case" CssClass="w3-btn w3-orange" OnClick="Withdraw_Click"/>  <%--OnClick="mybutton_Click" --%>
            </div>
            <br />
        </div>
        <footer class="w3-container  w3-center w3-text-white myBack" style="padding: 5px; background-color: #1f66c9;">
          <%--<p style="font-size: 10px;">Call your local HR office for any questions and/or concerns.</p>--%>
        </footer>
      </div>
    </div>

    <script type="text/javascript">
        function reloadInvite() {
            //var panel = document.getElementById("<%=invitePanel.ClientID %>");
            windows.location.reload();
            return false;
        }
        function showMeAdd() {
            //document.getElementById("img01").src = element.src;
            document.getElementById("id02").style.display = "block";
            return false;
            //var captionText = document.getElementById("caption");
            //captionText.innerHTML = element.alt;
        }
    </script>
</asp:Content>

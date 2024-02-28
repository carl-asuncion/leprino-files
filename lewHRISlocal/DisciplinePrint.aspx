<%@ Page Title="Discipline Action Form" Language="C#" AutoEventWireup="true" CodeBehind="DisciplinePrint.aspx.cs" Inherits="lewHRISlocal.DisciplinePrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>Print Completed Form</title><link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>');
            printWindow.document.write('</head><body style="font-family: Arial; font-size: 10px; background-image: url("http://10.40.80.28:150/lewHRISlocal/SupportDocs/CONFIDENTIAL_WM.png");">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
</head>
<body>
    <style>
        .myBtn {
            float: right;
            background-color: cornflowerblue;
            font-family: Arial;
            margin-bottom: 0;
            font-weight: normal;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            -ms-touch-action: manipulation;
            touch-action: manipulation;
            cursor: pointer;
            background-image: none;
            border: 1px solid transparent;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            border-radius: 4px;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
        }

        .myBtn:hover {
            color: #fff;
            background-color: #286090;
            border-color: #204d74;
        }

        #BottomLine{
            border-bottom: 1px solid black;
        }

    </style>
    <form id="form1" runat="server" style="font-family: Arial; font-size: 10px">
        <asp:LinkButton ID="LinkButton1" class="myBtn"  runat="server"  onclientclick = "return PrintPanel();" style="font-family: Arial; font-size: 11px"><i class="fa fa-download"></i> Download/Print</asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" class="myBtn"  runat="server"  onclientclick = "JavaScript:window.history.back(1); return false;" style="font-family: Arial; font-size: 11px">Close</asp:LinkButton>
        <%--<asp:LinkButton id="btnDownload" class="myBtn" runat="server" Text="Download"  OnClientClick = "return PrintPanel();"><i class="fa fa-download"></i></asp:LinkButton>--%>
        <asp:Panel ID="pnlContents" runat="server" style="font-family: Arial; font-size: 10px">
            <div style=" background-image:url('/lewHRISlocal/SupportDocs/CONFIDENTIAL_WM.png'); background-position: center; background-size: 100%; background-repeat: repeat-y;">
            
            
            
            <div style="text-align: center">
                <h5>LEPRINO FOODS COMPANY | LEMOORE WEST FACILITY</h5>
                <h2>DISCIPLINE ACTION FORM</h2>
            </div>
            <hr style="border-width: 1px; border-color: #000000" />
            <div>
                <asp:Table ID="Table1" runat="server"  style="font-family: Arial; font-size: 10px">
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label1" runat="server" Text="Employee Name: " Font-Bold="True" Font-Size="10px"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtEmployeeName" runat="server" style="border:none;width:200px;" ReadOnly="True" Enabled="true" Font-Size="10px"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label2" runat="server" Text="ID Number: " Font-Bold="True" Font-Size="10px"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtEmployeeID" runat="server" style="border:none;width:200px;" ReadOnly="True" Enabled="true" Font-Size="10px"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label3" runat="server" Text="Position: " Font-Bold="True" Font-Size="10px"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtPosition" runat="server" style="border:none;width:200px;" ReadOnly="True" Enabled="true" Font-Size="10px"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label4" runat="server" Text="Department: " Font-Bold="True" Font-Size="10px"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtDepartment" runat="server" style="border:none;width:200px;" ReadOnly="True" Enabled="true" Font-Size="10px"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label5" runat="server" Text="Date & Time of Incident: " Font-Bold="True" Font-Size="10px"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtDateIncident" runat="server" style="border:none;width:200px;" ReadOnly="True" Enabled="true" Font-Size="10px"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label6" runat="server" Text="Disciplinary ID: " Visible="false"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtCounselingID" runat="server" style="border:none;width:200px;" Visible="false" ReadOnly="True" Enabled="true"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <hr style="border-width: 1px; border-color: #000000" />
            <div>
                <h4>CURRENT DISCIPLINARY LEVEL</h4>
                <h5>Management reserves the right to use appropriate discipline given the circumstances, up to and including termination.</h5>
                <div>
                    <asp:Table ID="Table2" runat="server"  style="font-family: Arial; font-size: 12px">
                        <asp:TableRow>
                            <asp:TableCell><asp:Label ID="Label7" runat="server" Text="$1000 or more in damage: " Font-Bold="True" Font-Size="10px"></asp:Label></asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="TextBox5" runat="server" style="border:none;width:200px;" ReadOnly="True" Enabled="false" Font-Size="10px"></asp:TextBox></asp:TableCell>
                            <asp:TableCell><asp:Label ID="Label8" runat="server" Text="ID Number: " Visible="false"></asp:Label></asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="TextBox6" runat="server" class="txtboxes" Visible="false"></asp:TextBox></asp:TableCell>
                            <asp:TableCell><asp:Label ID="Label15" runat="server" Text="ID Number: " Visible="false"></asp:Label></asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="TextBox7" runat="server" class="txtboxes" Visible="false"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <asp:Table ID="Table3" runat="server" CellPadding="2" CellSpacing="1" GridLines="vertical" BorderStyle="Solid" BorderWidth="1px" style="font-family: Arial; font-size: 12px">
                        <asp:TableRow Font-Bold="True" HorizontalAlign="Center">
                            <asp:TableCell><asp:Label ID="Label9" runat="server" Text="Write-Up Level" Height="20px" Font-Size="10px"></asp:Label></asp:TableCell>
                            <asp:TableCell><asp:Label ID="Label10" runat="server" Text="1st Level Write-Up" Font-Size="10px"></asp:Label></asp:TableCell>
                            <asp:TableCell><asp:Label ID="Label13" runat="server" Text="2nd Level Write-Up" Font-Size="10px"></asp:Label></asp:TableCell>
                            <asp:TableCell><asp:Label ID="Label14" runat="server" Text="3rd Level Write-Up *" Font-Size="10px"></asp:Label></asp:TableCell>
                            <asp:TableCell ID="C11"><asp:Label ID="Label16" runat="server" Text="4th Level Write-Up" Font-Size="10px"></asp:Label></asp:TableCell>
                            <asp:TableCell ID="C21"><asp:Label ID="Label17" runat="server" Text="5th Level Write-Up" Font-Size="10px"></asp:Label></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow Font-Bold="True" HorizontalAlign="Center" GridLines="horizontal" Class="BottomLine">
                            <asp:TableCell><asp:Label ID="Label20" runat="server" Text="" Height="20px" Font-Bold="True"></asp:Label></asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                            <asp:TableCell><asp:Label ID="probL3" runat="server" Text="(1-Day Susp)" Font-Size="10px"></asp:Label></asp:TableCell>
                            <asp:TableCell ID="C12"><asp:Label ID="Label50" runat="server" Text="(2-Day Susp)" Font-Size="10px"></asp:Label></asp:TableCell>
                            <asp:TableCell ID="C22"><asp:Label ID="Label51" runat="server" Text="(Termination)" Font-Size="10px"></asp:Label></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="Label11" runat="server" Text="Date and Reasons" Height="30px" Font-Bold="True" Font-Size="10px"></asp:Label></asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="TextBox8" runat="server" Rows="2" style="border:none;height:20px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="TextBox9" runat="server" Rows="2" style="border:none;height:20px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="TextBox10" runat="server" Rows="2" style="border:none;height:20px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                            <asp:TableCell ID="C13"><asp:TextBox ID="TextBox11" runat="server" Rows="2" style="border:none;height:20px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                            <asp:TableCell ID="C23"><asp:TextBox ID="TextBox12" runat="server" Rows="2" style="border:none;height:20px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="Label22" runat="server" Text="for Previous Discipline" Height="40px" Font-Bold="True" Font-Size="10px"></asp:Label></asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="TextBox13" runat="server" Rows="2" style="border:none;height:30px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="TextBox14" runat="server" Rows="2" style="border:none;height:30px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="TextBox15" runat="server" Rows="2" style="border:none;height:30px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                            <asp:TableCell ID="C14"><asp:TextBox ID="TextBox16" runat="server" Rows="2" style="border:none;height:30px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                            <asp:TableCell ID="C24"><asp:TextBox ID="TextBox17" runat="server" Rows="2" style="border:none;height:30px;" ReadOnly="True" Enabled="true" Font-Size="10px" TextMode="SingleLine" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <asp:Table ID="Table4" runat="server"  style="font-family: Arial; font-size: 12px">
                        <asp:TableRow>
                            <asp:TableCell><asp:Label ID="Label12" runat="server" Text="Suspension Dates: " Font-Size="10px" Font-Bold="True"></asp:Label></asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="TextBox18" runat="server" style="border:none;width:400px;" ReadOnly="True" Enabled="false" Font-Size="10px" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                            <asp:TableCell><asp:Label ID="Label18" runat="server" Text="ID Number: " Visible="false"></asp:Label></asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="TextBox19" runat="server" Visible="false" ReadOnly="True" Enabled="false" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                            <asp:TableCell><asp:Label ID="Label19" runat="server" Text="RTW: " style="border:none;width:200px;" Font-Size="10px" Font-Bold="True"></asp:Label></asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="TextBox20" runat="server" style="border:none;width:200px;" ReadOnly="True" Enabled="false" Font-Size="10px" BackColor="Transparent"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <h5>*Group Leaders are required to keep their performance write-up step below three (3). In the event a Group Leader accumulates three (3) or more performance steps they will be removed from their Group Leader role. </h5>
                </div>
            </div>
            <hr style="border-width: 1px; border-color: #000000" />
            <div>
                <h4>INCIDENT DESCRIPTION</h4>
                <p>
                    <asp:TextBox ID="txtSubject" runat="server" style="width:100%" ReadOnly="True" TextMode="SingleLine" Rows="1"  Font-Size="10px" BackColor="Transparent"></asp:TextBox>
                    <asp:TextBox ID="txtSupComments" runat="server" style="height:200px;width:100%; font-family: Arial" ReadOnly="True" Rows="10" TextMode="MultiLine" Font-Size="9.5px" BackColor="Transparent"></asp:TextBox>
                </p>
            </div>
            <hr style="border-width: 1px; border-color: #000000" />
            <div>
                <h4>EMPLOYEE COMMENTS</h4>
                <p>
                    <asp:TextBox ID="txtEmployeeComments" runat="server" style="height:50px;width:100%" ReadOnly="True" Rows="10" TextMode="MultiLine" Font-Size="10px" BackColor="Transparent"></asp:TextBox>
                </p>
            </div>
            <hr style="border-width: 1px; border-color: #000000" />
            <div>
                <h5>By signing this document the employee is only agreeing that he/she was present at the discussion and the above incident was discussed. It does not necessarily mean that the employee is in agreement with the determination.</h5>
            </div>
            <asp:Table ID="Table5" runat="server"  style="font-family: Arial; font-size: 10px">
                <asp:TableRow HorizontalAlign="Center"> 
                    <asp:TableCell><asp:TextBox ID="txtEEAck" runat="server" style="border:none;width:400px;border-bottom: 1px solid black; text-align: center;" ReadOnly="True" Enabled="false" Font-Size="10px"></asp:TextBox></asp:TableCell>
                    <%--textbox below is just to check for status before printing--%>
                    <asp:TableCell><asp:TextBox ID="txtOverallStatus" runat="server" style="border:none;width:100px;" Visible="False" Font-Size="10px"></asp:TextBox></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtEEAckDate" runat="server" style="border:none;width:200px;border-bottom: 1px solid black; text-align: center;" ReadOnly="True" Enabled="false" Font-Size="10px"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell><asp:Label ID="Label25" runat="server" Text="Employee Signature" Font-Bold="True"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label21" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label23" runat="server" Text="Date" Font-Bold="True"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="Label24" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label26" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label27" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell><asp:TextBox ID="txtSup1Ack" runat="server" style="border:none;width:400px;border-bottom: 1px solid black; text-align: center;" ReadOnly="True" Enabled="false" Font-Size="10px"></asp:TextBox></asp:TableCell>
                    <%--textbox below is just to check for EMPLOYEE status before printing--%>
                    <asp:TableCell><asp:TextBox ID="txtEmployeeStatus" runat="server" style="border:none;width:100px;" Visible="false"></asp:TextBox></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtSup1AckDate" runat="server" style="border:none;width:200px;border-bottom: 1px solid black; text-align: center;" ReadOnly="True" Enabled="false" Font-Size="10px"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell><asp:Label ID="Label28" runat="server" Text="Supervisor/Manager Signature" Font-Bold="True"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label29" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label30" runat="server" Text="Date" Font-Bold="True"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="Label31" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label32" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label33" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell><asp:TextBox ID="txtSup2Ack" runat="server" style="border:none;width:400px;border-bottom: 1px solid black; text-align: center;" ReadOnly="True" Enabled="false" Font-Size="10px"></asp:TextBox></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="TextBox29" runat="server" style="border:none;width:100px;" Visible="false"></asp:TextBox></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtSup2AckDate" runat="server" style="border:none;width:200px;border-bottom: 1px solid black; text-align: center;" ReadOnly="True" Enabled="false" Font-Size="10px"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell><asp:Label ID="Label34" runat="server" Text="Supervisor/Manager Signature (Optional)" Font-Bold="True"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label35" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label36" runat="server" Text="Date" Font-Bold="True"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="Label37" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label38" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label39" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell><asp:TextBox ID="txtHRAck" runat="server" style="border:none;width:400px;border-bottom: 1px solid black; text-align: center;" ReadOnly="True" Enabled="false" Font-Size="10px"></asp:TextBox></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="TextBox32" runat="server" style="border:none;width:100px"></asp:TextBox></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtHRAckDate" runat="server" style="border:none;width:200px;border-bottom: 1px solid black; text-align: center;" ReadOnly="True" Enabled="false" Font-Size="10px"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell><asp:Label ID="Label40" runat="server" Text="Human Resources Signature" Font-Bold="True"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label41" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label42" runat="server" Text="Date" Font-Bold="True"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="lblGetReferenceID" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="lblGetDisciplinaryCount" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="lblGetStatus" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
           
            <br />
            <footer runat="server" style="font-family: Arial; font-size:8px;position: fixed;">
                <asp:Table ID="Table6" runat="server" Width="100%"  style="font-family: Arial; font-size: 8px">
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label46" runat="server" Text="Printed on: " Width="50px"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="PrintedOn" runat="server" Text="" Width="125px"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label47" runat="server" Text="Printed by: " Width="50px"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="PrintedBy" runat="server" Text="" Width="150px"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label48" runat="server" Text="Leprino Foods Company | Lemoore West Human Resources Department" Width="300px"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </footer>
            </div>
        </asp:Panel>
    </form>
</body>
</html>

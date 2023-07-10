<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CounselingPrint.aspx.cs" Inherits="lewHRISlocal.CounselingPrint" %>

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
            printWindow.document.write('</head><body style="font-family: Arial; font-size: 12px">');
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
    <form id="form1" runat="server" style="font-family: Arial; font-size: 12px">
        <asp:LinkButton ID="LinkButton1" class="myBtn"  runat="server"  onclientclick = "return PrintPanel();" style="font-family: Arial; font-size: 11px"><i class="fa fa-download"></i> Download/Print</asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" class="myBtn"  runat="server"  onclientclick = "JavaScript:window.history.back(1); return false;" style="font-family: Arial; font-size: 11px">Close</asp:LinkButton>
        <%--<asp:LinkButton id="btnDownload" class="myBtn" runat="server" Text="Download"  OnClientClick = "return PrintPanel();"><i class="fa fa-download"></i></asp:LinkButton>--%>
        <asp:Panel ID="pnlContents" runat="server" style="font-family: Arial; font-size: 12px">
            <div style="text-align: center">
                <h5>LEPRINO FOODS COMPANY | LEMOORE WEST FACILITY</h5>
                <h1>COUNSELING FORM</h1>
            </div>
            <hr style="border-width: 1px; border-color: #000000" />
            <div>
                <asp:TextBox ID="txtCounselingID" runat="server" style="border:none;width:200px;" Visible="false"></asp:TextBox>
                <asp:Table ID="Table1" runat="server"  style="font-family: Arial; font-size: 14px">
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label51" runat="server" Text="Date & Time of Incident: " Font-Bold="True"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtDateIncident" runat="server" style="border:none;width:200px;"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label52" runat="server" Text="Employee Name: " Font-Bold="True"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtEmployeeName" runat="server" style="border:none;width:200px;"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label1" runat="server" Text="Department: " Font-Bold="True"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtDepartment" runat="server" style="border:none;width:200px;"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label2" runat="server" Text="Department Manager: " Font-Bold="True" Visible="false"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtManager" runat="server" style="border:none;width:200px;" Visible="false"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <hr style="border-width: 1px; border-color: #000000" />
            <div>
                <h4>SUBJECT OF COUNSELING</h4>
                <p><asp:TextBox ID="txtSubject" runat="server" style="border:none;width:200px;"></asp:TextBox></p>
                <p>
                    <asp:TextBox ID="txtSupComments" runat="server" style="height:200px;width:100%; font-family: Arial; " ReadOnly="True" Rows="10" TextMode="MultiLine"></asp:TextBox>
                </p>
                <h5>This documented counseling may be subjected to progressive disciplinary action upon management review.</h5>
            </div>
            <hr style="border-width: 1px; border-color: #000000" />
            <div>
                <h4>EMPLOYEE COMMENTS</h4>
                <p>
                    <asp:TextBox ID="txtEmployeeComments" runat="server" style="height:100px;width:100%;font-family: Arial;" ReadOnly="True" Rows="10" TextMode="MultiLine"></asp:TextBox>
                </p>
            </div>
            <hr style="border-width: 1px; border-color: #000000" />
            <div>
                <h4>FOLLOW-UP</h4>
                <p>
                    <asp:TextBox ID="txtFollowUp" runat="server" style="height:100px;width:100%" ReadOnly="True" Rows="10" TextMode="MultiLine"></asp:TextBox>
                </p>
            </div>
            <hr style="border-width: 1px; border-color: #000000" />
            <div>
                <h5>By signing this document the employee is only agreeing that he/she was present at the discussion and the above incident was discussed. It does not necessarily mean that the employee is in agreement with the determination.</h5>
            </div>
            <asp:Table ID="Table5" runat="server"  style="font-family: Arial; font-size: 12px" Font-Bold="True">
                <asp:TableRow HorizontalAlign="Center"> 
                    <asp:TableCell>
                        <asp:TextBox ID="txtEEAck" runat="server" style="border:none;width:400px;border-bottom: 1px solid black;text-align:center;"></asp:TextBox>
                        <%--<asp:TextBox ID="txtEEAckUser" runat="server" style="border:none;width:200px;border-bottom: 1px solid black"></asp:TextBox>--%>
                    </asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtOverallStatus" runat="server" style="border:none;width:200px;" Visible="False"></asp:TextBox></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtEEAckDate" runat="server" style="border:none;width:200px;border-bottom: 1px solid black;text-align: center"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell><asp:Label ID="Label25" runat="server" Text="Employee Name & Signature" Font-Bold="True"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label21" runat="server" style="border:none;width:200px;" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label23" runat="server" Text="Date" Font-Bold="True"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Label ID="LabelWhat" runat="server" Text="Suspension Dates: " Visible="False" ></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label27" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell>
                        <asp:TextBox ID="txtSupFin" runat="server" style="border:none;width:400px;border-bottom: 1px solid black;text-align:center;" ForeColor="Black"></asp:TextBox>
                        <%--<asp:TextBox ID="txtSupUserName" runat="server" style="border:none;width:200px;border-bottom: 1px solid black" ForeColor="Black"></asp:TextBox>--%>
                    </asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="none" runat="server" style="border:none;width:200px;" Visible="false">></asp:TextBox></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtSupFinDate" runat="server" style="border:none;width:200px;border-bottom: 1px solid black;text-align: center" ForeColor="Black"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                    <asp:TableCell><asp:Label ID="Label28" runat="server" Text="Supervisor/Manager Name & Signature" Font-Bold="True"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label29" runat="server" Text="Suspension Dates: " Visible="False"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:Label ID="Label30" runat="server" Text="Date" Font-Bold="True"></asp:Label></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <br />
            <br />
            <br />
            <footer runat="server" style="font-family: Arial; font-size:10px;position: fixed;">
                <asp:Table ID="Table6" runat="server" Width="100%"  style="font-family: Arial; font-size: 12px">
                    <asp:TableRow>
                        <asp:TableCell><asp:Label ID="Label46" runat="server" Text="Printed on: "></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="PrintedOn" runat="server" Text="" Width="150px"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label47" runat="server" Text="Printed by: "></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="PrintedBy" runat="server" Text="" Width="150px"></asp:Label></asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label48" runat="server" Text="Leprino Foods Company | Lemoore West Human Resources Department"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </footer>
        </asp:Panel>
    </form>
</body>
</html>

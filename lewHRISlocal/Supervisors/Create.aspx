<%@ Page Title="Create" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="lewHRISlocal.Supervisors.Create" Debug="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Panel ID="Panel1" runat="server">
    <br />
    <h3><strong>New Counseling</strong></h3>
    <br />
    <p>
        <asp:Table ID="Table1" runat="server" Width="100%">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnBack" runat="server" Text="&laquo; Cancel" CssClass="w3-btn w3-light-grey w3-ripple w3-round-large" OnClientClick="JavaScript:window.history.back(1); return false;"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </p>
    <br />
    <div>   
            <p>
                <a id="userEmail"><asp:TextBox ID="txtUserEmail" runat="server" Width="300px" BackColor="Transparent" BorderStyle="None" ReadOnly="True" Enabled="false"></asp:TextBox></a>
            </p>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Incident Date: " Font-Bold="True"></asp:Label> 
                <asp:TextBox ID="txtDateToday" runat="server" Width="131px" TextMode="Date"></asp:TextBox> <asp:TextBox ID="txtTime" runat="server" Width="131px" TextMode="Time"></asp:TextBox>
                <%--Field Validator--%>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter the incident date." ControlToValidate="txtDateToday" ForeColor="Red" Font-Italic="True" Font-Size="Small"></asp:RequiredFieldValidator>--%>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter the incident time." ControlToValidate="txtTime" ForeColor="Red" Font-Italic="True" Font-Size="Small"></asp:RequiredFieldValidator>--%>
            </p>

            <br />
            <br />
            <div class="row">
                <div class="col-md-6">
                    <asp:Label ID="Label2" runat="server" Text="Employee Search: " Font-Bold="True"></asp:Label>  
                    <%--<asp:TextBox ID="txtEmpID" runat="server" ></asp:TextBox>--%>
                    <asp:DropDownList ID="EmpID" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="Column1" DataValueField="EE" Height="25px" placeholder="Search..."></asp:DropDownList>
                    <%--<ajaxToolkit:ModalPopupExtender ID="EmpID_ModalPopupExtender" runat="server" BehaviorID="EmpID_ModalPopupExtender" DynamicServicePath="Create.aspx.cs" TargetControlID="EmpID" DynamicServiceMethod="VoidRecord">
                    </ajaxToolkit:ModalPopupExtender>--%>
                    <ajaxToolkit:ListSearchExtender ID="EmpID_ListSearchExtender" runat="server" BehaviorID="EmpID_ListSearchExtender" TargetControlID="EmpID" IsSorted="True" QueryPattern="Contains" PromptCssClass="mySearch">
                    </ajaxToolkit:ListSearchExtender>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LEW_HRIS_LocalConnectionString %>" SelectCommand="SELECT ([First_Name] + ' ' +  [Last_Name]), [EE] FROM [MasterList] WHERE [CS_Status] NOT IN ('Withdrawn') ORDER BY [First_Name], [Last_Name]"></asp:SqlDataSource>
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Get Info" Width="90px" CssClass="w3-btn w3-light-grey w3-ripple w3-round-large"/>
                </div>
                <div class="col-md-6">
                    <asp:Label ID="Label3" runat="server" Text="Reference Incident (if applicable): " Font-Bold="True"></asp:Label>  
                    <asp:DropDownList ID="myReference" runat="server" Width="300px" Height="25px" OnTextChanged="myReference_TextChanged" AutoPostBack="True" placeholder="Select reference..."></asp:DropDownList>
                </div>
                <br />
                    
            </div>
            <br />
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Label ID="Label4" runat="server" Text="Employee Name: " Font-Bold="True"></asp:Label><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Employee Name Required." ControlToValidate="txtEmpName" ForeColor="Red" Font-Italic="True" Font-Size="Small"></asp:RequiredFieldValidator>--%>
            <asp:TextBox ID="txtEmpName" runat="server" Width="100%" ReadOnly="true" Enabled="false" AutoPostBack="True"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:Label ID="Label5" runat="server" Text="Department: " Font-Bold="True"></asp:Label>
            <asp:TextBox ID="txtDepartment" runat="server" Width="100%" ReadOnly="true" Enabled="false"></asp:TextBox>
        </div>
         <div class="col-md-4">
            <asp:Label ID="Label6" runat="server" Text="Email Address: " Font-Bold="True"></asp:Label>
            <asp:TextBox ID="txtEmpEmail" runat="server" Width="100%" ReadOnly="true" Enabled="false" AutoPostBack="True"></asp:TextBox>
        </div>
        <br />
    </div>
    <div>
	
		<div class="row">
			<div class="col-md-4">
                <asp:Label ID="Label7" runat="server" Text="Category: " Font-Bold="True"></asp:Label>
                <asp:DropDownList ID="myCategory" runat="server" DataSourceID="SqlDataSource1" DataTextField="Category" DataValueField="Category" Height="25px" Width="100%" OnTextChanged="CategoryList_TextChanged" AutoPostBack="True">
				<asp:ListItem Selected="True">--Select a category--</asp:ListItem>
				</asp:DropDownList>
				<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LEW_HRIS_LocalConnectionString %>" SelectCommand="SELECT [Category] FROM [CategoryList]" ></asp:SqlDataSource>
			</div>
			<div class="col-md-4">
                <asp:Label ID="Label8" runat="server" Text="Sub-Category: " Font-Bold="True"></asp:Label>
                <asp:DropDownList ID="mySubcategory" runat="server" Height="25px" Width="100%" OnTextChanged="SubCategoryList_TextChanged" AutoPostBack="True">
				</asp:DropDownList>
			</div>
			<div class="col-md-4">
                <asp:Label ID="Label9" runat="server" Text="Corrective Action: " Font-Bold="True"></asp:Label>
                <asp:TextBox ID="txtLevel" runat="server" Width="100%" AutoPostBack="True"></asp:TextBox>
			</div>
			<br />
		</div>
        <hr style="border-width: 3px; border-color: #000000" />

        <div style="column-width: auto" class="yourclass">            
        </div>
        <style>.myContent { min-width: 100% }
            .auto-style1 {
                margin-left: 140px;
            }
        </style>
        <div CssStyle="myContent">
            <asp:Label ID="Label10" runat="server" Text="Subject: " Font-Bold="True"></asp:Label>
            <br />
            <div>
                <asp:TextBox ID="txtSubject" runat="server" Width="100%"></asp:TextBox>
            </div>
            <br />
            <asp:Label ID="Label11" runat="server" Text="Incident Description: " Font-Bold="True"></asp:Label>
            <br />
            <div>
                <asp:TextBox ID="txtNotes" runat="server" Height="117px"  TextMode="MultiLine" Width="100%"></asp:TextBox>
            </div>
        </div>
        <hr style="border-width: 3px; border-color: #000000" />
        <div>
            <asp:Label ID="Label12" runat="server" Text="Supporting Documents (optional): " Font-Bold="True" Font-Size="Small"></asp:Label>
            <asp:FileUpload ID="addFile" runat="server" AllowMultiple="True" CssClass="w3-btn w3-light-grey w3-ripple w3-round-large" /><br />
            <p>
                <asp:Button ID="btnUpload" runat="server" Text="Upload File"  CssClass="w3-btn w3-light-blue w3-ripple w3-round-large" OnClick="btnUpload_Click"/>
            </p>
            <p>
                <asp:Label ID="listOfuploadedFiles" runat="server" Text="" Font-Size="11px"></asp:Label>
                <asp:Label ID="finalRun" runat="server"  Font-Size="11px" Font-Bold="True" ></asp:Label>
                <asp:Label ID="countFiles" runat="server" Text="" Visible="false"></asp:Label>
            </p>
        </div>

        <hr style="border-width: 3px; border-color: #000000" />
        <div>
            By clicking the "Submit Form" button, the supervisor is forwarding this to above mentioned employee of an area that requires immediate improvement. Employee acknowledgement is required before it is submitted to HR. This correspondence will be kept on file as documentation of the discussion.
        </div>
        <br />
        <asp:TextBox ID="timedateAck" runat="server" TextMode="SingleLine" Width="100%" Enabled="false" ReadOnly="true" Font-Italic="True"></asp:TextBox><br /><br />
        <p>
             <asp:Button ID="btnSubmitForm" runat="server" class="w3-btn w3-blue w3-ripple w3-round-large" style="margin-bottom: 0; width: 150px;" Text="Submit Form" OnClick="btnSubmitForm_Click" BackColor="#339966" Width="150px" />
        </p>
    </div>
    <br />
    <br />
    <br />
    <br />
    </asp:Panel>
    <style>
        #mySearch {
          width: 100%;
          font-size: 18px;
          padding: 11px;
          border: 1px solid #ddd;
        }

    </style>
</asp:Content>

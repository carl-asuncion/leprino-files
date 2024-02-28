<%@ Page Title="HRM Dashboard" Language="C#" MasterPageFile="~/HumanResources/HRSite.Master" AutoEventWireup="true" CodeBehind="AddTeamMember.aspx.cs" Inherits="lewHRISlocal.HumanResources.AdminPage.AddTeamMember" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.min.js'></script>
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <div style="background-color: rgba(255, 255, 255, 0.6); padding: 10px;  border-radius: 10px;">
    <br />
        <h2><strong>Modify Team Members</strong></h2>
        <asp:Label ID="Label1" runat="server" Text="Label" Font-Italic="True"></asp:Label>
    <br />
    <br />
    <br />
        <asp:Button ID="btnBack" runat="server" Text="&laquo; Back" PostBackUrl="~/HumanResources/AdminPage/ManageTeam.aspx" CssClass="w3-btn w3-light-grey w3-ripple w3-round-large"/>
    <br />
    <br />
    </div>
    <br />
    <div style="background-color: rgba(255, 255, 255, 0.6); padding: 10px;  border-radius: 10px;">
    <br />
        <div class="w3-row-padding">
          <div class="w3-col s3"><span id="btnAdd" class="w3-btn w3-round-medium w3-green w3-text-black w3-left w3-cell" onclick="showMeAdd()">Add Member</span> </div>
          <div class="w3-col s3"> </div>
          <div class="w3-col s6"></div>
        </div>
          <br />
          <asp:GridView ID="mydatagrid" runat="server" AutoGenerateColumns="False" 
              dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" 
              RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Assigned_User_ID" 
              AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" 
              PagerSettings-Mode="NumericFirstLast" Font-Size="11px" 
              OnPageIndexChanging="mydatagrid_PageIndexChanging" 
              OnDataBound="mydatagrid_DataBound" 
              OnRowCancelingEdit="mydatagrid_RowCancelingEdit"  
              OnRowEditing="mydatagrid_RowEditing" OnRowDeleting="mydatagrid_RowDeleting"
              OnRowUpdating="mydatagrid_RowUpdating" Width="75%">  
            <Columns>
                <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" CssClass="w3-btn w3-small w3-blue"/>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update" CssClass="w3-btn w3-small w3-green"/>  
                        <asp:Button ID="btn_Delete" runat="server" Text="Delete" CommandName="Delete" CssClass="w3-btn w3-small w3-red"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="w3-btn w3-small w3-gray"/>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="ID" Visible="false">  
                    <ItemTemplate>  
                        <asp:Label ID="Assigned_User_ID" runat="server" Text='<%#Eval("Assigned_User_ID") %>' BackColor="Transparent"></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Full Name"  HeaderStyle-CssClass="myheader">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Ticket" runat="server" Text='<%#Eval("Assigned_Name") %>' BackColor="Transparent"></asp:Label>  
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox ID="txt_Remarks1" runat="server" Text='<%# Eval("Assigned_Name") %>' ForeColor="Black" CssClass="w3-input w3-sand w3-round"></asp:TextBox>
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UserName"  HeaderStyle-CssClass="myheader">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Ticket1" runat="server" Text='<%#Eval("Assigned_UserName") %>' BackColor="Transparent"></asp:Label>  
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox ID="txt_Remarks2" runat="server" Text='<%# Eval("Assigned_UserName") %>' ForeColor="Black" CssClass="w3-input w3-sand w3-round"></asp:TextBox>
                    </EditItemTemplate>  
                </asp:TemplateField>
            </Columns>



        <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
            <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
        <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
                <SelectedRowStyle BackColor="#FF6600" />
        </asp:GridView>
    </div>
<!-- Modal -->

    <div id="id02" class="w3-modal w3-round-medium" >
      <div class="w3-modal-content w3-card-4 w3-animate-top w3-round-medium">
        <header class="w3-container w3-display-container w3-center w3-text-white" style="background-color: #1f66c9;"> 
          <span onclick="document.getElementById('id02').style.display='none'" class="w3-button w3-display-topright w3-hover-white myBack"><i class="fa fa-remove"></i></span>
          <%--<h4><strong>Leprino Foods Company, Lemoore West</strong></h4>--%>
          <h6>Print Confirmationn</h6>
        </header>
        <div class="w3-container">
            <br />
            <p>Enter employee's full name and username as it appears in SAP:</p>
            <br />
            <div class="w3-container w3-center w3-centered" style="width: 100%; margin: auto;">
              <label for="uname"><b>Full Name: </b></label>
              <asp:TextBox ID="uName" runat="server" placeholder="Enter Full Name" CssClass="w3-input w3-sand w3-round"></asp:TextBox>

              <label for="psw"><b>Username: </b></label>
              <asp:TextBox ID="uUname" runat="server" placeholder="Enter Username" CssClass="w3-input w3-sand w3-round"></asp:TextBox>
              <br /> 
              <asp:Button ID="mybutton" runat="server" Text="Add User" CssClass="w3-btn w3-orange" OnClick="mybutton_Click"/>  <%--OnClick="mybutton_Click" --%>
            </div>
            <br />
        </div>
        <footer class="w3-container  w3-center w3-text-white myBack" style="padding: 5px; background-color: #1f66c9;">
          <%--<p style="font-size: 10px;">Call your local HR office for any questions and/or concerns.</p>--%>
        </footer>
      </div>
    </div>
 
    
    <script>
        // Modal Send Request
        function showMeAdd() {
            //document.getElementById("img01").src = element.src;
            document.getElementById("id02").style.display = "block";
            return false;
            //var captionText = document.getElementById("caption");
            //captionText.innerHTML = element.alt;
        }
    </script>
</asp:Content>

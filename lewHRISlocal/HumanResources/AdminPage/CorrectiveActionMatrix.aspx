<%@ Page Title="HRM Dashboard" Language="C#" MasterPageFile="~/HumanResources/HRSite.Master" AutoEventWireup="true" CodeBehind="CorrectiveActionMatrix.aspx.cs" Inherits="lewHRISlocal.HumanResources.AdminPage.CorrectiveActionMatrix" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color: rgba(255, 255, 255, 0.6); padding: 10px;  border-radius: 10px;">
    <br />
        <h2><strong>Corrective Action Matrix</strong></h2>
        <asp:Label ID="Label1" runat="server" Text="Label" Font-Italic="True"></asp:Label>
    <br />
    <br />
    <br />
        <asp:Button ID="btnBack" runat="server" Text="&laquo; Back" PostBackUrl="~/HumanResources/AdminPage/AdminPanel.aspx" CssClass="w3-btn w3-light-grey w3-ripple w3-round-large"/>
    <br />
    <br />
    </div>
    <br />
    <div style="background-color: rgba(255, 255, 255, 0.6); padding: 10px;  border-radius: 10px;">
    <br />
        <div class="w3-cell-row">
            <asp:Label runat="server" Text="Filter: " Font-Bold="true" CssClass="w3-cell" Width="10%"/>
            <asp:DropDownList runat="server" AutoPostBack="true" ID="CategoryName"  CssClass="w3-input w3-sand w3-cell w3-round-medium" Width="25%">
                <asp:ListItem Text="All" Value="" />
                <asp:ListItem Text="Punch Policy" />
                <asp:ListItem Text="Job Performance" />
                <asp:ListItem Text="Safety" />
                <asp:ListItem Text="Behavior" />
            </asp:DropDownList>
            
            <asp:Button ID="btn1" runat="server" Text="Filter" OnClick="btn1_Click" CssClass="w3-btn w3-round-medium w3-mynavy w3-text-white w3-right w3-cell"/> 
        </div>
        <br />
        <div class="w3-cell-row">
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="w3-btn w3-round-medium w3-green w3-text-black w3-left w3-cell"/> 
        </div>
          <br />
          <asp:GridView ID="mydatagrid" runat="server" AutoGenerateColumns="False" 
              dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" 
              RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="SubCategory_ID" 
              AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" 
              PagerSettings-Mode="NumericFirstLast" Font-Size="11px" 
              OnPageIndexChanging="mydatagrid_PageIndexChanging" 
              OnDataBound="mydatagrid_DataBound" 
              OnRowCancelingEdit="mydatagrid_RowCancelingEdit"  
              OnRowEditing="mydatagrid_RowEditing" 
              OnRowUpdating="mydatagrid_RowUpdating">  
            <Columns>
                <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" CssClass="w3-btn w3-small w3-blue"/>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update" CssClass="w3-btn w3-small w3-green"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="w3-btn w3-small w3-red"/>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="ID" Visible="false">  
                    <ItemTemplate>  
                        <asp:Label ID="SubCategory_ID" runat="server" Text='<%#Eval("SubCategory_ID") %>' BackColor="Transparent"></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:BoundField DataField="Level" HeaderText="Level" ReadOnly="True" HeaderStyle-CssClass="myheader"/>
                <asp:BoundField DataField="Category" HeaderText="Category" ReadOnly="True" HeaderStyle-CssClass="myheader" />
                <asp:BoundField DataField="Sub_Category" HeaderText="Sub ID" ReadOnly="True" HeaderStyle-CssClass="myheader"/>
                <asp:TemplateField HeaderText="Sub Category"  HeaderStyle-CssClass="myheader">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Ticket" runat="server" Text='<%#Eval("SubCategory") %>' BackColor="Transparent"></asp:Label>  
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_Ticket" runat="server" Text='<%# Eval("SubCategory") %>' ForeColor="Black" CssClass="w3-input w3-sand w3-round"></asp:TextBox>
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

        <div id="id01" class="w3-modal w3-round-medium" >
          <div class="w3-modal-content w3-card-4 w3-animate-top w3-round-medium">
            <header class="w3-container w3-display-container w3-center w3-text-white" style="background-color: #1f66c9;"> 
              <span onclick="document.getElementById('id01').style.display='none'" class="w3-button w3-display-topright w3-hover-white myBack"><i class="fa fa-remove"></i></span>
              <h4><strong>Add Corrective Action Guide</strong></h4>
            </header>
            <div class="w3-container">
                <br />
                <p>Fill out the following details: </p>
                <table style="width: 100%;">
                    <tr>
                        <td><strong>Level:  </strong></td>
                        <td>
                            <asp:DropDownList runat="server" AutoPostBack="false" ID="DropDownList2"  CssClass="w3-input w3-sand w3-cell w3-round-medium" Width="25%">
                                <asp:ListItem Text="Counseling" Value="" />
                                <asp:ListItem Text="Level 1" />
                                <asp:ListItem Text="Level 2" />
                                <asp:ListItem Text="Level 3" />
                                <asp:ListItem Text="Termination" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>Category:  </strong></td>
                        <td>
                            <asp:DropDownList runat="server" AutoPostBack="false" ID="DropDownList1"  CssClass="w3-input w3-sand w3-cell w3-round-medium" Width="25%">
                                <asp:ListItem Text="All" Value="" />
                                <asp:ListItem Text="Punch Policy" />
                                <asp:ListItem Text="Job Performance" />
                                <asp:ListItem Text="Safety" />
                                <asp:ListItem Text="Behavior" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>Sub Category:  </strong></td>
                        <td>  <asp:TextBox ID="TextBox2" runat="server" BorderStyle="None" Width="100%" CssClass="w3-input w3-sand w3-round-medium"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
<%--                        <td><strong>Print Request Reference #:  </strong></td>
                        <td>  <asp:TextBox ID="printRequest_ID" runat="server" ReadOnly="true" BorderStyle="None" Width="100%"  ></asp:TextBox></td>--%>
                    </tr>
                </table>
                <br />
                <br />
                <div class="w3-center">
                    <asp:LinkButton ID="btnAddDetails" runat="server" OnClick="btnAddDetails_Click" CssClass="w3-btn w3-blue w3-round-medium w3-center" Font-Underline="False"><i class="material-symbols-outlined" style="vertical-align: middle;">note_add</i> Add to Corrective Action Matrix</asp:LinkButton>
                </div>
                <br />
            </div>
            <footer class="w3-container  w3-center w3-text-white myBack" style="padding: 5px;">
              <p style="font-size: 10px;"></p>
            </footer>
          </div>
        </div>
    <asp:TextBox ID="MaxSubCategory" runat="server"></asp:TextBox>
    <script>
        // Modal Send Request
        function showMeAdd() {
            //document.getElementById("img01").src = element.src;
            document.getElementById("id01").style.display = "block";
            return false;
            //var captionText = document.getElementById("caption");
            //captionText.innerHTML = element.alt;
        }
    </script>
</asp:Content>

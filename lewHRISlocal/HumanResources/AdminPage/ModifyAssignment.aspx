<%@ Page Title="HRM Dashboard" Language="C#" MasterPageFile="~/HumanResources/HRSite.Master" AutoEventWireup="true" CodeBehind="ModifyAssignment.aspx.cs" Inherits="lewHRISlocal.HumanResources.AdminPage.ModifyAssignment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color: rgba(255, 255, 255, 0.6); padding: 10px;  border-radius: 10px;">
    <br />
        <h2><strong>Modify Department Assignment</strong></h2>
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
        <%--<div class="w3-cell-row">
            <asp:Label runat="server" Text="Filter: " Font-Bold="true" CssClass="w3-cell" Width="10%"/>
            <asp:DropDownList runat="server" AutoPostBack="true" ID="CategoryName"  CssClass="w3-input w3-sand w3-cell w3-round-medium" Width="25%">
                <asp:ListItem Text="All" Value="" />
                <asp:ListItem Text="Punch Policy" />
                <asp:ListItem Text="Job Performance" />
                <asp:ListItem Text="Safety" />
                <asp:ListItem Text="Behavior" />
            </asp:DropDownList>
            
            <asp:Button ID="btn1" runat="server" Text="Filter" OnClick="btn1_Click" CssClass="w3-btn w3-round-medium w3-mynavy w3-text-white w3-right w3-cell"/> 
        </div>--%>
        <%--<br />
        <div class="w3-cell-row">
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="w3-btn w3-round-medium w3-green w3-text-black w3-left w3-cell"/> 
        </div>--%>
          <br />
          <asp:GridView ID="mydatagrid" runat="server" AutoGenerateColumns="False" 
              dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" 
              RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Department_Group_ID" 
              AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" 
              PagerSettings-Mode="NumericFirstLast" Font-Size="11px" 
              OnPageIndexChanging="mydatagrid_PageIndexChanging" 
              OnDataBound="mydatagrid_DataBound" 
              OnRowCancelingEdit="mydatagrid_RowCancelingEdit"  
              OnRowEditing="mydatagrid_RowEditing" 
              OnRowUpdating="mydatagrid_RowUpdating" Width="75%">  
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
                        <asp:Label ID="Department_Group_ID" runat="server" Text='<%#Eval("Department_Group_ID") %>' BackColor="Transparent"></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:BoundField DataField="Department_Group" HeaderText="Department" ReadOnly="True" HeaderStyle-CssClass="myheader"/>
                <asp:TemplateField HeaderText="Assigned to"  HeaderStyle-CssClass="myheader">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Ticket" runat="server" Text='<%#Eval("Assigned_Name") %>' BackColor="Transparent"></asp:Label>  
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:DropDownList ID="txtUser" runat="server" CssClass="w3-input w3-sand w3-cell w3-round-medium" Width="50%" AutoPostBack="True"  DataSourceID="SqlDataSource1"
                            DataTextField="Assigned_Name" DataValueField="Assigned_User_ID" AppendDataBoundItems="true">
                            <asp:ListItem Text="Please select" Value="" />
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LEW_HRIS_LocalConnectionString %>"
                            SelectCommand="SELECT [Assigned_User_ID], [Assigned_Name] FROM dbo.HRGeneralistGroup;">
                        </asp:SqlDataSource>
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

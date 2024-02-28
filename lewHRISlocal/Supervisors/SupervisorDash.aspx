<%@ Page Title="Supervisor Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupervisorDash.aspx.cs" Inherits="lewHRISlocal.Supervisors.SupervisorDash" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color: rgba(255, 255, 255, 0.6); padding: 10px; border-radius: 10px;">
    
        <script src="scripts/jquery.responsivetable.min.js"></script> 
        <script type="text/javascript">
            $(document).ready(function() {
                // Default settings
                $('.mydatagrid').responsiveTable({
                    staticColumns: 2, 
                    scrollRight: true, 
                    scrollHintEnabled: true, 
                    scrollHintDuration: 2000
                });
            });  
        </script>
        
        <br />
        <h2><strong>Supervisor Dashboard</strong></h2>
        <p>
            <asp:Label ID="WelcomeLabel" runat="server" Text="Label" Font-Italic="True"></asp:Label>
            <asp:Label ID="Department" runat="server" Text="Label" Font-Italic="True" Visible="false"></asp:Label>
        </p>
        <br />
    
        <p>
            <asp:Button ID="btnBack" runat="server" Text="&laquo; Back" PostBackUrl="~/Default.aspx" CssClass="w3-btn w3-light-grey w3-ripple w3-round-large" />
            <asp:Button ID="btnNewRecord" runat="server" Text="New Counseling" PostBackUrl="~/Supervisors/Create.aspx" CssClass="w3-btn w3-green w3-ripple w3-round-large"/>
        </p>
        <p>
            <asp:Panel ID="Panel1" runat="server" DefaultButton="Button2">
                <asp:Label ID="Label2" runat="server" Text="Employee Search: " Font-Bold="True"></asp:Label> 
                <br />
                   <div class="w3-row w3-bar w3-padding-small">
                        <input id="myInput" type="text" name="myCountry" placeholder="Search employee name..." class="w3-bar-item w3-input w3-border w3-round" style="height: 36px; width: 50%;">
                        <%--</div>--%>
                        <%--<a id="btnSearch" runat="server" onclick="btnSearch_Click" class="w3-bar-item w3-btn w3-blue w3-ripple w3-round" style="height: 36px; width: 20%;"><i class="fa fa-search"></i></a>--%>
                        <asp:Button ID="Button2" runat="server" OnClick="btnSearch_Click" Text="Search" CssClass="w3-bar-item w3-btn w3-blue w3-ripple w3-round" style="height: 36px; width: 20%; margin-left: 2em;"/>
                        <asp:Button ID="Reset" runat="server" OnClick="Reset_Click" Text="Reset" CssClass="w3-bar-item w3-btn w3-blue w3-ripple w3-round" style="height: 36px; width: 15%; margin-left: 2em;"/>
                        <%--<button id="Button3" runat="server" onclick="btnSearch_Click" class="w3-btn w3-light-grey w3-ripple w3-round-large"><i class="fa fa-search"></i></button>--%>
                  </div>  
                <asp:TextBox ID="searchName" runat="server" Visible="false"></asp:TextBox>
            </asp:Panel>
        </p>
        <br />
        <h3>COUNSELING - Issue to Employee</h3>
        <asp:TextBox ID="NeedAttn" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
        <asp:GridView ID="mydatagrid" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="mydatagrid_PageIndexChanging" OnDataBound="mydatagrid_DataBound">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select" OnClick="LinkButton1_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered" HeaderStyle-CssClass="myheader" />
                <asp:BoundField DataField="EE_Name" HeaderText="Employee Name" ReadOnly="True" SortExpression="EE_Name"  HeaderStyle-CssClass="myheader"/>
                <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False"  HeaderStyle-CssClass="myheader"/>
                <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
                <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
                <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject"   HeaderStyle-CssClass="myheader"/>
                <asp:BoundField DataField="Counseling_Level" HeaderText="Level" SortExpression="Counseling_Level"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
                <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
            </Columns>



        <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
            <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
        <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
                <SelectedRowStyle BackColor="#FF6600" />
        </asp:GridView>

        <hr style="border-width: 3px; border-color: #000000" />
        <h3>DISCIPLINARY - Issue to Employee</h3>
        <asp:TextBox ID="txtReqAckDA" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="GridView3_PageIndexChanging" OnDataBound="GridView3_DataBound">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Select" Text="Select" OnClick="LinkButton4_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered" HeaderStyle-CssClass="myheader" />
                <asp:BoundField DataField="EE_Name" HeaderText="Employee Name" ReadOnly="True" SortExpression="EE_Name"  HeaderStyle-CssClass="myheader"/>
                <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False"  HeaderStyle-CssClass="myheader"/>
                <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
                <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
                <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject"   HeaderStyle-CssClass="myheader"/>
                <asp:BoundField DataField="Counseling_Level" HeaderText="Level" SortExpression="Counseling_Level"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
                <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
            </Columns>



        <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
            <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
        <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
                <SelectedRowStyle BackColor="#FF6600" />
        </asp:GridView>

        <hr style="border-width: 3px; border-color: #000000" />
        <h3>Recent Submissions</h3>
        <asp:TextBox ID="RecentSubs" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="GridView1_PageIndexChanging" OnDataBound="GridView1_DataBound">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select" Text="Select" OnClick="LinkButton2_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered" HeaderStyle-CssClass="myheader" />
                <asp:BoundField DataField="EE_Name" HeaderText="Employee Name" ReadOnly="True" SortExpression="EE_Name"  HeaderStyle-CssClass="myheader"/>
                <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False"  HeaderStyle-CssClass="myheader"/>
                <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
                <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
                <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject"   HeaderStyle-CssClass="myheader"/>
                <asp:BoundField DataField="Counseling_Level" HeaderText="Level" SortExpression="Counseling_Level"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
                <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
            </Columns>



        <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
            <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
        <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
                <SelectedRowStyle BackColor="#FF6600" />
        </asp:GridView>

        <hr style="border-width: 3px; border-color: #000000" />
        <h3>Closed Incidents</h3>
        <asp:TextBox ID="HRReview" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="GridView2_PageIndexChanging" OnDataBound="GridView2_DataBound">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select" Text="Select" OnClick="LinkButton3_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Date_Incident" HeaderText="Incident Date" ReadOnly="True" SortExpression="Date_Entered" HeaderStyle-CssClass="myheader" />
                <asp:BoundField DataField="EE_Name" HeaderText="Employee Name" ReadOnly="True" SortExpression="EE_Name"  HeaderStyle-CssClass="myheader"/>
                <asp:BoundField DataField="Counseling_ID" HeaderText="Counseling ID" SortExpression="Counseling_ID" Visible="False"  HeaderStyle-CssClass="myheader"/>
                <asp:BoundField DataField="Counseling_Category" HeaderText="Category" SortExpression="Counseling_Category" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
                <asp:BoundField DataField="Counseling_SubCategory" HeaderText="Sub-Category" SortExpression="Counseling_SubCategory" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
                <asp:BoundField DataField="Counseling_Subject" HeaderText="Subject" SortExpression="Counseling_Subject"   HeaderStyle-CssClass="myheader"/>
                <asp:BoundField DataField="Counseling_Level" HeaderText="Level" SortExpression="Counseling_Level"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
                <asp:BoundField DataField="Overall Status" HeaderText="Overall Status" SortExpression="Overall Status"  ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="myheader hidden-xs"/>
            </Columns>

        <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
            <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />
        <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
                <SelectedRowStyle BackColor="#FF6600" />
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <asp:TextBox ID="AllHRISGroup" runat="server" Visible="false"></asp:TextBox>
    </div>
    <%--<script>
        function autocomplete(inp, arr) {
            /*the autocomplete function takes two arguments,
            the text field element and an array of possible autocompleted values:*/
            var currentFocus;
            /*execute a function when someone writes in the text field:*/
            inp.addEventListener("input", function (e) {
                var a, b, i, val = this.value;
                /*close any already open lists of autocompleted values*/
                closeAllLists();
                if (!val) { return false; }
                currentFocus = -1;
                /*create a DIV element that will contain the items (values):*/
                a = document.createElement("DIV");
                a.setAttribute("id", this.id + "autocomplete-list");
                a.setAttribute("class", "autocomplete-items");
                /*append the DIV element as a child of the autocomplete container:*/
                this.parentNode.appendChild(a);
                /*for each item in the array...*/
                for (i = 0; i < arr.length; i++) {
                    /*check if the item starts with the same letters as the text field value:*/
                    if (arr[i].substr(0, val.length).toUpperCase() == val.toUpperCase()) {
                        /*create a DIV element for each matching element:*/
                        b = document.createElement("DIV");
                        /*make the matching letters bold:*/
                        b.innerHTML = "<strong>" + arr[i].substr(0, val.length) + "</strong>";
                        b.innerHTML += arr[i].substr(val.length);
                        /*insert a input field that will hold the current array item's value:*/
                        b.innerHTML += "<input type='hidden' value='" + arr[i] + "'>";
                        /*execute a function when someone clicks on the item value (DIV element):*/
                        b.addEventListener("click", function (e) {
                            /*insert the value for the autocomplete text field:*/
                            inp.value = this.getElementsByTagName("input")[0].value;
                            /*close the list of autocompleted values,
                            (or any other open lists of autocompleted values:*/
                            closeAllLists();
                        });
                        a.appendChild(b);
                    }
                }
            });
            /*execute a function presses a key on the keyboard:*/
            inp.addEventListener("keydown", function (e) {
                var x = document.getElementById(this.id + "autocomplete-list");
                if (x) x = x.getElementsByTagName("div");
                if (e.keyCode == 40) {
                    /*If the arrow DOWN key is pressed,
                    increase the currentFocus variable:*/
                    currentFocus++;
                    /*and and make the current item more visible:*/
                    addActive(x);
                } else if (e.keyCode == 38) { //up
                    /*If the arrow UP key is pressed,
                    decrease the currentFocus variable:*/
                    currentFocus--;
                    /*and and make the current item more visible:*/
                    addActive(x);
                } else if (e.keyCode == 13) {
                    /*If the ENTER key is pressed, prevent the form from being submitted,*/
                    e.preventDefault();
                    if (currentFocus > -1) {
                        /*and simulate a click on the "active" item:*/
                        if (x) x[currentFocus].click();
                    }
                }
            });
            function addActive(x) {
                /*a function to classify an item as "active":*/
                if (!x) return false;
                /*start by removing the "active" class on all items:*/
                removeActive(x);
                if (currentFocus >= x.length) currentFocus = 0;
                if (currentFocus < 0) currentFocus = (x.length - 1);
                /*add class "autocomplete-active":*/
                x[currentFocus].classList.add("autocomplete-active");
            }
            function removeActive(x) {
                /*a function to remove the "active" class from all autocomplete items:*/
                for (var i = 0; i < x.length; i++) {
                    x[i].classList.remove("autocomplete-active");
                }
            }
            function closeAllLists(elmnt) {
                /*close all autocomplete lists in the document,
                except the one passed as an argument:*/
                var x = document.getElementsByClassName("autocomplete-items");
                for (var i = 0; i < x.length; i++) {
                    if (elmnt != x[i] && elmnt != inp) {
                        x[i].parentNode.removeChild(x[i]);
                    }
                }
            }
            /*execute a function when someone clicks in the document:*/
            document.addEventListener("click", function (e) {
                closeAllLists(e.target);
            });
        }

        $.ajax({
            type: "POST",
            url: "SupervisorDash.aspx/GetEmployee",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {


                autocomplete(document.getElementById("myInput"), response.d);
            },
            error: function (response) {
                alert("error" + response.d);
            }
        });
    </script>--%>
</asp:Content>

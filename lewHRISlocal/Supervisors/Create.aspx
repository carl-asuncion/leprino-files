<%@ Page Title="Create" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="lewHRISlocal.Supervisors.Create" Debug="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color: rgba(255, 255, 255, 0.6); padding: 10px;  border-radius: 10px;">
    <style>
        /*the container must be positioned relative:*/
        .autocomplete {
          position: relative;
          display: inline-block;
        }

        input {
          border: 1px solid transparent;
          background-color: #f1f1f1;
          padding: 10px;
          font-size: 16px;
        }

        input[type=text] {
          background-color: #f1f1f1;
          width: 100%;
        }

        /*input[type=submit] {
          background-color: DodgerBlue;
          color: #fff;
          cursor: pointer;
        }*/

        .autocomplete-items {
          position: absolute;
          border: 1px solid #d4d4d4;
          border-bottom: none;
          border-top: none;
          z-index: 99;
          /*position the autocomplete items to be the same width as the container:*/
          top: 100%;
          left: 0;
          right: 0;
        }

        .autocomplete-items div {
          padding: 10px;
          cursor: pointer;
          background-color: #fff; 
          border-bottom: 1px solid #d4d4d4; 
        }

        /*when hovering an item:*/
        .autocomplete-items div:hover {
          background-color: #e9e9e9; 
        }

        /*when navigating through the items using the arrow keys:*/
        .autocomplete-active 
        {
          background-color: DodgerBlue !important; 
          color: #ffffff; 
        }
    </style>
    <link rel="stylesheet" href="/Content/w3.css">
    <link rel="stylesheet" href="/Content/Site.css">
    <script src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.2.min.js'></script>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    
    <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="Label13" runat="server" Height="36px" Width="100%" BackColor="Red" BorderStyle="None" Font-Italic="True" ForeColor="White" CssClass="w3-center w3-padding w3-errorvalidation"></asp:Label>
    <br />
    <h3><strong>New Counseling</strong></h3>
    <br />
    <p>
        <asp:Table ID="Table1" runat="server" Width="100%">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnBack" runat="server" Text="&laquo; Back" CssClass="w3-btn w3-light-grey w3-ripple w3-round-large" OnClientClick="JavaScript:window.history.back(-1); return false;"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </p>
    <br />
        <div class="row">
            <div class="col-lg-12">
                <asp:Label ID="txtUserEmail" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>
                <asp:Label ID="txtCurrentTicketID" runat="server" Font-Bold="True" Font-Italic="True" Visible="false"></asp:Label>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="Label1" runat="server" Text="Incident Date & Time: " Font-Bold="True"></asp:Label>  
                <br />
                <div style="width: 100%">
                    <asp:TextBox ID="txtDateToday" runat="server" TextMode="Date" CssClass="w3-datetime w3-border w3-round" Height="36px" Width="120px"></asp:TextBox>
                    <asp:TextBox ID="txtTime" runat="server" TextMode="Time" CssClass="w3-datetime w3-border w3-round" Height="36px" Width="120px"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
            </div>
        </div>
        <br />
        <br />
        <div class="row">  
            <div class="col-md-6">
                <asp:Label ID="Label2" runat="server" Text="Employee Search: " Font-Bold="True"></asp:Label> 
                <br />
                    <form autocomplete="off" action="/action_page.php">
                        <div class="autocomplete" style="width: 75%;">
                            <input id="myInput" type="text" name="myCountry" placeholder="Search employee name, employee number or username ..." class="w3-bar-item w3-input w3-border w3-round" style="height: 36px; width: 100%;">
                            
                        </div>
                        <%--<a id="btnSearch" runat="server" onclick="btnSearch_Click" class="w3-bar-item w3-btn w3-blue w3-ripple w3-round" style="height: 36px; width: 20%;"><i class="fa fa-search"></i></a>--%>
                        <asp:Button ID="Button2" runat="server" OnClick="btnSearch_Click" Text="&#128269;" CssClass="w3-bar-item w3-btn w3-blue w3-ripple w3-round" style="height: 36px; width: 20%;"/>
                        <%--<button id="Button3" runat="server" onclick="btnSearch_Click" class="w3-btn w3-light-grey w3-ripple w3-round-large"><i class="fa fa-search"></i></button>--%>
                    </form>  
                    <asp:Label ID="txtEmpID" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
                  
            <div class="col-md-6">
                <asp:Label ID="Label3" runat="server" Text="Reference Incident (if applicable): " Font-Bold="True"></asp:Label><br />
                <asp:DropDownList ID="myReference" runat="server" Width="100%" Height="36px" OnTextChanged="myReference_TextChanged" AutoPostBack="True" CssClass="w3-datetime w3-border w3-round"></asp:DropDownList>
            </div>
        </div>

        <br />

    <div class="row">
        <div class="col-md-4">
            <asp:Label ID="Label4" runat="server" Text="Employee Name: " Font-Bold="True"></asp:Label><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Employee Name Required." ControlToValidate="txtEmpName" ForeColor="Red" Font-Italic="True" Font-Size="Small"></asp:RequiredFieldValidator>--%>
            <asp:TextBox ID="txtEmpName" runat="server" Width="100%" ReadOnly="true" Enabled="false" AutoPostBack="True" CssClass="w3-input w3-border w3-round"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <asp:Label ID="Label5" runat="server" Text="Department: " Font-Bold="True"></asp:Label>
            <asp:TextBox ID="txtDepartment" runat="server" Width="100%" ReadOnly="true" Enabled="false" CssClass="w3-input w3-border w3-round"></asp:TextBox>
        </div>
         <div class="col-md-4">
            <asp:Label ID="Label6" runat="server" Text="Email Address: " Font-Bold="True"></asp:Label>
            <asp:TextBox ID="txtEmpEmail" runat="server" Width="100%" ReadOnly="true" Enabled="false" AutoPostBack="True" CssClass="w3-input w3-border w3-round"></asp:TextBox>
        </div>
        <br />
    </div>
    <div>
	
		<div class="row">
			<div class="col-md-4">
                <asp:Label ID="Label7" runat="server" Text="Category: " Font-Bold="True"></asp:Label>
                <asp:DropDownList ID="myCategory" runat="server" DataSourceID="SqlDataSource1" DataTextField="Category" DataValueField="Category" Height="36px" Width="100%" OnTextChanged="CategoryList_TextChanged" AutoPostBack="True" CssClass="w3-select  w3-round">
				<asp:ListItem Selected="True">--Select a category--</asp:ListItem>
				</asp:DropDownList>
				<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LEW_HRIS_LocalConnectionString %>" SelectCommand="SELECT [Category] FROM [CategoryList]" ></asp:SqlDataSource>
			</div>
			<div class="col-md-4">
                <asp:Label ID="Label8" runat="server" Text="Sub-Category: " Font-Bold="True"></asp:Label>
                <asp:DropDownList ID="mySubcategory" runat="server" Height="36px" Width="100%" OnTextChanged="SubCategoryList_TextChanged" AutoPostBack="True" CssClass="w3-select  w3-round">
				</asp:DropDownList>
			</div>
			<div class="col-md-4">
                <asp:Label ID="Label9" runat="server" Text="Corrective Action: " Font-Bold="True"></asp:Label>
                <asp:TextBox ID="txtLevel" runat="server" Width="100%" AutoPostBack="True" CssClass="w3-input w3-border w3-round" ReadOnly="True"></asp:TextBox>
			    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="w3-select  w3-round">
                    <asp:ListItem>Counseling</asp:ListItem>
                    <asp:ListItem>Level 1</asp:ListItem>
                    <asp:ListItem>Level 2</asp:ListItem>
                    <asp:ListItem>Level 3</asp:ListItem>
                    <asp:ListItem>Level 4</asp:ListItem>
                    <asp:ListItem>Termination</asp:ListItem>
                </asp:DropDownList>
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
                <asp:TextBox ID="txtSubject" runat="server" Width="100%" TextMode="SingleLine" CssClass="w3-input w3-border w3-round"></asp:TextBox>
            </div>
            <br />
            <asp:Label ID="Label11" runat="server" Text="Incident Description: *modify description as necessary" Font-Bold="True"></asp:Label>
            <br />
            <div>
                <asp:TextBox ID="txtNotes" runat="server" Height="117px"  TextMode="MultiLine" Width="100%" CssClass="w3-input w3-border w3-round"></asp:TextBox>
            </div>
        </div>
        <hr style="border-width: 3px; border-color: #000000" />
        <div>
            <asp:Label ID="Label12" runat="server" Text="Supporting Documents (optional): " Font-Bold="True" Font-Size="Small"></asp:Label>
            <asp:FileUpload ID="addFile" runat="server" AllowMultiple="True" CssClass="w3-btn w3-transparent w3-border-0 w3-ripple w3-round-large" /><br />
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
        </div>
    <asp:TextBox ID="generalist" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="maindepartment" runat="server" Visible="false"></asp:TextBox>

    <style>
        #mySearch {
          width: 100%;
          font-size: 18px;
          padding: 11px;
          border: 1px solid #ddd;
        }
        .auto-style2 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 50%;
            left: 1px;
            top: 1px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>




    <script>
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
            url: "Create.aspx/GetEmployee",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {


                autocomplete(document.getElementById("myInput"), response.d);
            },
            error: function (response) {
                alert("error" + response.d);
            }
        });

        ///*initiate the autocomplete function on the "myInput" element, and pass along the countries array as possible autocomplete values:*/
        //autocomplete(document.getElementById("myInput"), countries);
    </script>

</asp:Content>

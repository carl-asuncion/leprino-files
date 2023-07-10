<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="lewHRISlocal.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1">
<style>
body {font-family: Arial, Helvetica, sans-serif; }
form {border: 3px solid #f1f1f1; max-width: 500px; margin: auto; background-color: transparent;}

input[type=text], input[type=password] {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  box-sizing: border-box;
}

#mybutton {
  background-color: #04AA6D;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
}

button {
  background-color: #04AA6D;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
}

button:hover {
  opacity: 0.8;
}

.cancelbtn {
  width: auto;
  padding: 10px 18px;
  background-color: #003366;
}

.imgcontainer {
  text-align: center;
  margin: 24px 0 12px 0;
}

img.avatar {
  width: 40%;
  border-radius: 1px;
}

.container {
  padding: 16px;
}

span.psw {
  float: right;
  padding-top: 16px;
}

/* Change styles for span and cancel button on extra small screens */
@media screen and (max-width: 300px) {
  span.psw {
     display: block;
     float: none;
  }
  .cancelbtn {
     width: 100%;
  }
}
/*div.polaroid {
  width: 80%;
  background-color: white;
  box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
}


img {width: 100%}

div.container {
  text-align: center;
  padding: 10px 20px;
}
*/
</style>
</head>
<body>


     
<form style="box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);" runat="server">
  <h2 style="text-align: center">Login Form</h2>
  <div class="imgcontainer">
    <img src="http://10.40.80.28:150/lewHRISlocal/Leprino_Foods_Black.png" style="box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19); height: 50%; width: 50%;">
  </div>

  <div class="container">
    <asp:Label ID="Label1" runat="server" Text="Label" style="color: red; font-style: italic; font-size: 10px;"></asp:Label><br />
    <label for="uname"><b>Username</b></label>
    <asp:TextBox ID="uName" runat="server" placeholder="Enter Username"></asp:TextBox>
    <%--<input id="uName" type="text" placeholder="Enter Username" name="uname" required>--%>

    <label for="psw"><b>Password</b></label>
    <asp:TextBox ID="uPassword" runat="server" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
    <%--<input id="uPassword"type="password" placeholder="Enter Password" name="psw" required>--%>
        
    <%--<button type="submit" >Login</button>--%>
    <asp:Button ID="mybutton" runat="server" Text="Login" OnClick="mybutton_Click" />
    <%--<label>
      <input type="checkbox" checked="checked" name="remember"> Remember me
    </label>--%>
  </div>

  <div class="container" style="background-color:#f1f1f1">
    <button type="button" class="cancelbtn">Cancel</button>
    <%--<span class="psw">Forgot <a href="#">password?</a></span>--%>
  </div>
</form>

</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnauthorizedAccess.aspx.cs" Inherits="lewHRISlocal.UnauthorizedAccess" %>

<!DOCTYPE html>
<html>
<head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1">
<style>
body {font-family: Arial, Helvetica, sans-serif; 
      background: url('http://10.40.80.28:150/lewHRISlocal/Leprino_Foods_Only_Washed_2.png');
    background-position: center;
    background-position-y: 0px;
    background-repeat: no-repeat;
    background-attachment: fixed;
    background-size: cover;
    padding-top: 100px;
}
form {border: 3px solid #f1f1f1; max-width: 500px; margin: auto;}

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


     
<form style="box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19); background: white; border-color: transparent; padding: 20px;" runat="server">
  <h2 style="text-align: center">Unauthorized Session</h2>
  <div class="imgcontainer">
    <img src="/Images/Leprino_Foods_Black.png" style="box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19); height: 25%; width: 25%;">
  </div>
  <h5 style="text-align: center">Credentials were either not provided or incorrect credentials were entered.<br />For assistance, please contact your local HR or IT department.<br />Close and reopen browser to try again.</h5>
</form>

</body>
    <script type="text/javascript">
        var t;
        window.onload = resetTimer;
        document.onmousemove = resetTimer;
        document.onkeypress = resetTimer;

        function logout() {

            try {
                document.execCommand("ClearAuthenticationCache");
                window.location.href = window.location.protocol.replace(/\:/g, '') + "://" + window.location.host + "/_layouts/customlogin14.aspx";
                alert('hello');
            }
            catch (e) { }


        }

        function resetTimer() {
            window.clearTimeout(t);
            t = window.setTimeout(logout, 900000);
        }
    </script>
</html
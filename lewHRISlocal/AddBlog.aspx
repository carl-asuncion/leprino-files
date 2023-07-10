<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBlog.aspx.cs" Inherits="lewHRISlocal.AddBlog" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 19px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    Title:
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" Width = "550" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Body:
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="Submit" />
                </td>
            </tr>
        </table>
        <%--<script type="text/javascript" src="//tinymce.cachefly.net/4.0/tinymce.min.js"></script>--%>
        <script src="https://cdn.tiny.cloud/1/no-api-key/tinymce/5/tinymce.min.js" referrerpolicy="origin"></script>
        <script type="text/javascript">
            tinymce.init({ selector: 'textarea' });
        </script>
    </form>
</body>
</html>

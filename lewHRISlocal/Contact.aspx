<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="lewHRISlocal.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><strong><%: Title %></strong></h2>
    <br />
    <div><asp:Image ID="Image1" runat="server" ImageUrl="http://10.40.80.28:150/lewHRISlocal/Leprino_Foods_Black.png" Width="25%" /></div>
    <h4><strong>Lemoore West | ISS Department</strong></h4>
    <address style="font-size: 12px;">
        Leprino Foods Company - Lemoore West<br />
        351 Belle Haven Dr<br />
        Lemoore, CA 93245<br />
        <abbr title="Phone">P:</abbr>
        559.925.7545
    </address>

    <%--<asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>--%>

    <address>
        <strong>Support: </strong><a href="mailto:plantsystemswest@leprinofoods.onmicrosoft.com@leprinofoods.com"><strong>Plant Systems West</strong></a><br />
        <br />
       
    </address>



</asp:Content>

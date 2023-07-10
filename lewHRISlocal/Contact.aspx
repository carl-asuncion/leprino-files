<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="lewHRISlocal.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Lemoore West | ISS Department</h3>
    <address>
        Leprino Foods Company - Lemoore West<br />
        351 Belle Haven Dr<br />
        Lemoore, CA 93245<br />
        <abbr title="Phone">P:</abbr>
        559.925.7545
    </address>

    <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>

    <address>
        <strong>Support: </strong><a href="mailto:plantsystemswest@leprinofoods.onmicrosoft.com@leprinofoods.com"><strong>Plant Systems West</strong></a><br />
        <br />
       
    </address>
</asp:Content>

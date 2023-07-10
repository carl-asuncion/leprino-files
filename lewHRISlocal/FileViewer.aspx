<%@ Page Title="Human Resources - File Viewer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FileViewer.aspx.cs" Inherits="lewHRISlocal.FileViewer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" Visible="False">


    <br />
    <h2>Files Available</h2>
    <asp:Label ID="Label1" runat="server" Text="" Font-Italic="True"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnBack" runat="server" Text="&laquo; Back" OnClientClick="JavaScript:window.history.back(1); return false;" CssClass="btn btn-secondary"/>
    <br />
    <asp:TextBox ID="FilesAvailable" runat="server" TextMode="SingleLine" Width="100%" ReadOnly="true" Font-Italic="True" BorderStyle="None" BackColor="Transparent"></asp:TextBox>
    <%--<asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="False" dPagerStyle-CssClass="pager" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" CssClass="mydatagrid" DataKeyNames="Counseling_ID" AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-Mode="NumericFirstLast" Font-Size="11px" OnPageIndexChanging="GridView11_PageIndexChanging">--%>
    <div style="align-content:center">
        <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="myheader" RowStyle-CssClass="rows" Width="50%"  Font-Size="11px"  EmptyDataText = "No files uploaded">
            <Columns>
                <asp:BoundField DataField="Text" HeaderText="File Name" />
                <%--<asp:BoundField DataField="Text" HeaderText="File Name" />--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDownload" Text = "Download" runat="server" OnClick = "DownloadFile"  CommandArgument = '<%# Eval("Value") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID = "lnkDelete" Text = "Delete" runat = "server" OnClick = "DeleteFile"  CommandArgument = '<%# Eval("Value") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <HeaderStyle CssClass="myheader" Font-Size="12px"></HeaderStyle>
            <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"></PagerSettings>
                <PagerStyle BackColor="#FF9933" Font-Size="10px" Height="10px" />--%>
            <RowStyle CssClass="rows" Font-Size="12px"></RowStyle>
                    <SelectedRowStyle BackColor="#FF6600" />
        </asp:GridView>
    </div>
    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
    <br />
    <br />
    <br />
</asp:Content>

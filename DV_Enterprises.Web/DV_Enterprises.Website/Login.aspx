<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="LoginPage" Title="Login &mdash; Smart Greenhouse Solutions Administration" %>

<%@ MasterType VirtualPath="~/Template.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title">Login</h2>
    <asp:Table ID="Table1" runat="server" Height="77px" Width="229px">
        <asp:TableRow>
            <asp:TableCell>
                Username:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="UsernameTextBox" runat="server" />
                <br />
                <asp:RegularExpressionValidator ID="UsernameREV" runat="server" ErrorMessage="Characters A-Z only." ValidationExpression="^[a-zA-Z''-'\s]{1,50}$" ControlToValidate="UsernameTextBox" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                Password:
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" />
                <br />
<%--                <asp:RegularExpressionValidator ID="PasswordREV" runat="server" ErrorMessage="Improper Password" ControlToValidate="PasswordTextBox" />--%>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                <br />
                <asp:Button ID="LoginButton" runat="server" Text="Login" onclick="LoginButton_Click" />&nbsp;&nbsp;
                <asp:Button ID="CancelButton" runat="server" Text="Cancel" onclick="CancelButton_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    
<%--    <asp:Login ID="login" runat="server" OnLoggingIn="login_LoggingIn">
    </asp:Login>--%>

</asp:Content>
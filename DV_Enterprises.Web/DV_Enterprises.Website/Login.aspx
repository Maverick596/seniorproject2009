<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="LoginPage" Title="Login &mdash; Smart Greenhouse Solutions Administration" %>

<%@ MasterType VirtualPath="~/Template.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title">Login</h2>
    <asp:Login ID="Login" runat="server" onloggedin="Login_LoggedIn">
    </asp:Login>
</asp:Content>
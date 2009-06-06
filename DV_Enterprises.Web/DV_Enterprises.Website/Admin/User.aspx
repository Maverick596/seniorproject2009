<%@ Page Title="User Details" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="Admin_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title grid_16"><asp:Label ID="lblName" runat="server"></asp:Label></h2>
    <dl class="table_display grid_8 clearfix">
        <h3 class="title">Details</h3>
        <dt>User name:</dt>
        <dd><asp:Label ID="lblUserName" runat="server" /></dd>
        <dt>Email:</dt>
        <dd><asp:Label ID="lblEmail" runat="server" /></dd>
        <dt>Address:</dt>
        <dd><asp:Label ID="lblFullAddress" runat="server" /></dd>
        <dt>Phone:</dt>
        <dd><asp:Label ID="lblPhone" runat="server" /></dd>
        <dt>Roles:</dt>
        <dd><asp:Label ID="lblRoles" runat="server" /></dd>
    </dl>
    <div class="grid_16">
        <h3 class="title">Greenhouses</h3>
    </div>
</asp:Content>


<%@ Page Title="User Details" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="Admin_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title"><asp:Label ID="lblName" runat="server"></asp:Label></h2>
    <dl>
        <h3 class="title">Details</h3>
        <dt><strong>User name: </strong><asp:Label ID="lblUserName" runat="server"></asp:Label></dt>
                            <dd></dd>
        <dt><strong>Email:<asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></strong></dt>
        <dd></dd>
        <dt><strong>Address: <asp:Label ID="lblFullAddress" runat="server" Text="Label"></asp:Label></strong></dt>
        <dd></dd>
        <dt><strong>Phone: <asp:Label ID="lblPhone" runat="server" Text="Label"></asp:Label></strong></dt>
        <dd></dd>
    </dl>
    <div>
        <h3 class="title">Roles:
            <asp:Label ID="lblRoles" runat="server" Text="Label"></asp:Label>
                            </h3>
    </div>
    <div>
        <h3 class="title">Greenhouses</h3>
                            <p class="title">
    </div>
    <div>
        <h3 class="title">Presets</h3>
    </div>
</asp:Content>


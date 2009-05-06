<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="ViewProduct.aspx.cs" Inherits="Products.ViewProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title">
        <asp:Label ID="lblName" runat="server"></asp:Label>
    </h2>
    <asp:Label ID="lblPrice" runat="server"></asp:Label>
    <asp:Label ID="lblDescription" runat="server"></asp:Label>
    <asp:CheckBox ID="cboActive" runat="server" />
</asp:Content>


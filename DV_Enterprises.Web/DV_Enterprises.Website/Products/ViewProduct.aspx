<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="ViewProduct.aspx.cs" Inherits="Products.ViewProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title">
        <asp:Label ID="lblName" runat="server"></asp:Label>
    </h2>
    <asp:Image ID="ImgProduct" runat="server" CssClass="grid_3 alpha" ImageUrl="" />
    <asp:Label ID="lblDescription" runat="server" />
    <br /><br />
    <asp:Label ID="lblPrice" runat="server" />
</asp:Content>


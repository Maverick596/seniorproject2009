<%@ Page Title="Products &mdash; Smart Greenhouse Solutions" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Products.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title">Products</h2>
    <asp:ListView ID="lvProducts" runat="server">
        <LayoutTemplate>
            <ul class="product">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
            </ul>
        </LayoutTemplate>
        
        <ItemTemplate>
            <li>
                <asp:Label ID="lblName" runat="server" Text='<%# ((DV_Enterprises.Web.Domain.Product)Container.DataItem).Name %>' ></asp:Label>
            </li>
        </ItemTemplate>
        
        <EmptyDataTemplate>
        
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>


<%@ Page Title="Products &mdash; Smart Greenhouse Solutions" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Products.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title grid_16">Featured Products</h2>
    
    <p class="grid_16">Smart Greenhouse Solutions is a company that is devoted to providing the most innovative products to small family farmers. SGS is proud to introduce the SGS Green Thumb Modular Greenhouse monitoring system. Not only are our products manufactured with the smallest carbon footprint possible, but they are made from <span class="green">green</span> materials.</p>
    
    <asp:ListView ID="lvProducts" runat="server" style="text-align: center">
        <LayoutTemplate>
            <ul class="products">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
        </LayoutTemplate>
        
        <ItemTemplate>
            <li class="product grid_16">
                <asp:Image ID="Image2" CssClass="grid_3 alpha" runat="server" ImageUrl="<%# ((DV_Enterprises.Web.Data.Domain.Product)Container.DataItem).Image %>" />
                <h3 class="title gird_12 omega"><asp:Label ID="Label1" runat="server" Font-Bold="true" Text='<%# ((DV_Enterprises.Web.Data.Domain.Product)Container.DataItem).Name %>' /></h3>
                <p class="grid_12 omega"><asp:Label ID="Label2" runat="server" Text='<%# ((DV_Enterprises.Web.Data.Domain.Product)Container.DataItem).Description %>' /></p>
            </li>
        </ItemTemplate>
        
        <EmptyDataTemplate>
            <p class="grid_16">No products found.</p>
        </EmptyDataTemplate>
    </asp:ListView>
    
    <p class="grid_16">Smart Greenhouse Solutions is committed to providing the best quality products to help you enhance your growing. We back our products with an unbeatable 3 year warranty and a 24 hr customer service help line.</p>
    
</asp:Content>


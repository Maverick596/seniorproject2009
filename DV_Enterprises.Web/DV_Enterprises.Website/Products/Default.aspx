<%@ Page Title="Products &mdash; Smart Greenhouse Solutions" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Products.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title">Product Line</h2>
    <p>
    Smart Greenhouse Solutions is a company that is devoted to providing the most innovative products to small family farmers. 
    SGS is proud to introduce the SGS Green Thumb Modular Greenhouse monitoring system. Not only are our products manufactured with the smallest carbon footprint possible, 
    but they are made from “green” materials.
    <br />
    <br /> 
    Smart Greenhouse Solutions is committed to providing the best quality products to help you enhance your growing. 
    We back our products with an unbeatable 3 year warranty and a 24 hr customer service help line.
    </p>
    <p>
    Now Available:
    </p>
    <asp:ListView ID="lvProducts" runat="server" style="text-align: center">
        <LayoutTemplate>
            <ul class="products">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
        </LayoutTemplate>
        
        <ItemTemplate>
<%--            <li>
                <asp:Label ID="lblName" runat="server" Text='<%# ((DV_Enterprises.Web.Data.Domain.Product)Container.DataItem).Name %>' />
                </li>--%>
            <table cellpadding="3" cellspacing="3">
                <tr>
                    <td colspan="2" valign="top" style="text-align:left; vertical-align:top">
                        <asp:Label ID="lblProductName" runat="server" Font-Bold="true" Text='<%# ((DV_Enterprises.Web.Data.Domain.Product)Container.DataItem).Name %>' />
                        <br />
                    </td>
                </tr>
                <tr valign="top">
                    <td style="text-align:left; vertical-align:top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/noImage.png" />
                    </td>
                    <td style="text-align:left; vertical-align:top">
                        <asp:Label ID="lblProductDescription" runat="server" Text='<%# ((DV_Enterprises.Web.Data.Domain.Product)Container.DataItem).Description %>' />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        
        <EmptyDataTemplate>
        No products found.
        </EmptyDataTemplate>
    </asp:ListView>
    
</asp:Content>


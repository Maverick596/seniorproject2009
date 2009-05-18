<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="ViewGreenhouse.aspx.cs" Inherits="Greenhouses.ViewGreenhouse" %>
<%@ Import Namespace="DV_Enterprises.Web.Data.Domain"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title">View Greenhouse</h2>
    <h3 class="title">Location</h3>
    <asp:Label ID="lblAddress" runat="server" />
    
    <h3 class="title">Sections</h3>
    <asp:ListView ID="lvSections" runat="server">
        <LayoutTemplate>
            <ul class="sections">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
        </LayoutTemplate>
        
        <ItemTemplate>
            <li>
                <asp:Label ID="lblName" runat="server" Text='<%# ((Section)Container.DataItem).Name %>' />
            </li>
        </ItemTemplate>
        
        <EmptyDataTemplate>
        
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>


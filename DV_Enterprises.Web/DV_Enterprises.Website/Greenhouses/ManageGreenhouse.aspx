<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="ManageGreenhouse.aspx.cs" Inherits="Greenhouses_ManageGreenhouse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="text-align:center">
    <h2 class="title">Select a Section:</h2>
    <asp:ListView ID="lvGreenhouses" runat="server">
        <LayoutTemplate>
            <ul class="greenhouses">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
            </ul>
        </LayoutTemplate>
        
        <ItemTemplate>
            <li>
                <asp:Label ID="lblName" runat="server" Text='<%# ((DV_Enterprises.Web.Data.Domain.Greenhouse)Container.DataItem).Sections %>' ></asp:Label>
            </li>
        </ItemTemplate>
        
        <EmptyDataTemplate>
        
        </EmptyDataTemplate>
    </asp:ListView>
  </div>
</asp:Content>


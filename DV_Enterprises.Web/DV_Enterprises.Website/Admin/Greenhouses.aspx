<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Greenhouses.aspx.cs" Inherits="Admin_Greenhouses" Title="Greenhouses &mdash; Smart GreenHouse Solutions Administration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HyperLink ID="lnkAddNewGreenhouse" runat="server" NavigateUrl="~/Admin/AddEditGreenhouse.aspx">Add New Greenhouse</asp:HyperLink>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Customer_Default" Title="Customer Home Page! &mdash; Smart Greenhouse Solutions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title">Customer Home Page!</h2>
    
    <asp:HyperLink ID="lnkEditAccount" runat="server" Text="Edit Account" NavigateUrl="~/Account/Edit.aspx"></asp:HyperLink>
    
<br />
<br />
<br />
    
</asp:Content>


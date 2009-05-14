<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Customer_Default" Title="Customer Home Page! &mdash; Smart Greenhouse Solutions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title">Customer Home Page!</h2>
    
    <asp:HyperLink ID="lnkEditAccount" runat="server" Text="Edit Account" NavigateUrl="~/Account/Edit.aspx"></asp:HyperLink>
    
    <br />
    <br />
    Account Information<br />
<br />
    First Name :
    <asp:Label ID="FirstNameLBL" runat="server" Text="Label"></asp:Label>
    <br />
    Last Name :
    <asp:Label ID="LastNameLBL" runat="server" Text="Label"></asp:Label>
    <br />
    Email Add&nbsp; :
    <asp:Label ID="EmailLBL" runat="server" Text="Label"></asp:Label>
    <br />
    Phone Num:
    <asp:Label ID="phoneLBL" runat="server" Text="Label"></asp:Label>
    <br />
    Address&nbsp;&nbsp;&nbsp;&nbsp; :
    <asp:Label ID="AddressLBL" runat="server" Text="Label"></asp:Label>
    <br />
    City&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
    <asp:Label ID="CityLBL" runat="server" Text="Label"></asp:Label>
    <br />
    State&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:Label 
        ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    Zip Code&nbsp;&nbsp;&nbsp; :
    <asp:Label ID="ZipCodeLBL" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <br />
    Select Your Greenhouse
    <br />
    <img id="GHimage" alt="" src="../Images/greenhouse.png" 
        style="width: 121px; height: 147px" />
    
</asp:Content>


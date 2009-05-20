<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" Title="Smart GreenHouse Solutions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Image ID="imgPhoto" runat="server" ImageUrl="~/images/photo.png" CssClass="grid_6" />
    <ul class="grid_10 why">
        <h2 class="title">Why Choose Smart Greenhouse Solutions?</h2>
        <li>Automated lighting control</li>
        <li>Automated temperature control</li>
        <li>Easy web access</li>
        <li>24 hour customer service</li>
        <li>Ability to add onto any SGS module</li>
        <li>3 year warranty</li>
    </ul>
    <ul class="grid_16 features">
        <h2 class="title">SGS Green Thumb Modules provide:</h2>
        <li>Maximum Reliability</li>
        <li>Easy controls</li>
        <li>Ease of installation</li>
        <li>Easy integration with existing Greenhouse control units</li>
        <li>Savings in up to 30% on Energy Bills</li>
    </ul>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Customer_Default" Title="Customer Home Page! &mdash; Smart Greenhouse Solutions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title">Home Page!</h2>
    
    <asp:HyperLink ID="lnkEditAccount" runat="server" Text="Edit Account" NavigateUrl="~/Account/Edit.aspx"></asp:HyperLink>
    <br />
    <h3 class="title"> 
    <br />Account Information<br />
    </h3>
    <h4 class="title">
    <br />Personal Information<br />
    <asp:Label ID="Label2" runat="server" Text="First Name: " Width="150px" />
    <asp:Label ID="FirstNameLBL" runat="server" Width="200px" />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Last Name: " Width="150px" />
    <asp:Label ID="LastNameLBL" runat="server" Width="200px" />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Email Address: " Width="150px" />
    <asp:Label ID="EmailLBL" runat="server" Width="200px" />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Phone: " Width="150px" />
    <asp:Label ID="phoneLBL" runat="server" Width="200px" />
    <br />
    <br />Address Information<br />
    <asp:Label ID="Label6" runat="server" Text="Address: " Width="150px" />
    <asp:Label ID="AddressLBL" runat="server" Width="200px" />
    <br />
    <asp:Label ID="Label7" runat="server" Text="City: " Width="150px" />
    <asp:Label ID="CityLBL" runat="server" Width="200px" />
    <br />
    <asp:Label ID="Label8" runat="server" Text="State: " Width="150px" />
    <asp:Label ID="StateLBL" runat="server" Width="200px" />
    <br />
    <asp:Label ID="Label9" runat="server" Text="ZipCoode: " Width="150px" />
    <asp:Label ID="ZipCodeLBL" runat="server" Width="200px" />
    </h4>
    <br />
<%--    <br />
    <br />
    Go to my Greenhouses
    <br />
    <asp:ImageButton ID="imgbGreenhouses" runat="server" 
        ImageUrl="~/images/greenhouse.png" width="121px" height="147px" 
        onclick="imgbGreenhouses_Click"  />--%>
<%--    <img id="GHimage" alt="" src="../images/greenhouse.png" style="width: 121px; height: 147px" />--%>
    
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Customer_Default" Title="Customer Home Page! &mdash; Smart Greenhouse Solutions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title">Customer Home Page!</h2>
    <br />
    <table style="width:300px">
        <tr>
            <td colspan="2">
                <h3 class="title">Account Information</h3>
                <asp:HyperLink ID="lnkEditAccount" runat="server" Text="Edit Account" NavigateUrl="~/Account/Edit.aspx" />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <h4 class="title">Personal Information</h4>
            </td>
        </tr>
        <tr>
            <td style="width:80px">
            First Name:
            </td>
            <td style="width:220px">
                <asp:Label ID="lblFirstName" runat="server" Text="" />
            </td>
        </tr>
        <tr>
            <td>
            Last Name:
            </td>
            <td>
                <asp:Label ID="lblLastName" runat="server" Text="" />
            </td>
        </tr>
        <tr>
            <td>
            Email:
            </td>
            <td>
                <asp:Label ID="lblEmail" runat="server" Text="" />
            </td>
        </tr>
        <tr>
            <td>
            Phone:
            </td>
            <td>
                <asp:Label ID="lblPhone" runat="server" Text="" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                <h4 class="title">Address Information</h4>
            </td>
        </tr>
        <tr>
            <td>
            Address:
            </td>
            <td>
                <asp:Label ID="lblAddress" runat="server" Text="" />
            </td>
        </tr>
        <tr>
            <td>
            City:
            </td>
            <td>
                <asp:Label ID="lblCity" runat="server" Text="" />
            </td>
        </tr>
        <tr>
            <td>
            State:
            </td>
            <td>
                <asp:Label ID="lblState" runat="server" Text="" />
            </td>
        </tr>
        <tr>
            <td>
            Zipcode:
            </td>
            <td>
                <asp:Label ID="lblZipCode" runat="server" Text="" />
            </td>
        </tr>
    </table>
<br />
<br />
<br />
    
</asp:Content>


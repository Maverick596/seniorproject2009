<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="ManageProduct.aspx.cs" Inherits="Products.ManageProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset>
        <legend>Wow</legend>
        <ol>
            <li>
                <label for="name">Name:</label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </li>
            <li>
                <label for="description">Description:</label>
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            </li>
            <li>
                <label for="price">Price:</label>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            </li>
            <li>
                <label for="isActive">Active?:</label>
                <asp:CheckBox ID="cboIsActive" runat="server" />
            </li>
        </ol>
        <asp:Literal ID="litProductId" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="litTimestamp" runat="server" Visible="false"></asp:Literal>
    </fieldset>
    <fieldset class="buttons">
        <asp:Button ID="butSubmit" runat="server" Text="Save" onclick="butSubmit_Click" />
    </fieldset>
</asp:Content>


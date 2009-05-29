<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="ManageProduct.aspx.cs" Inherits="Products.ManageProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset class="grid_16">
        <legend>Product Information</legend>
        <ol>
            <li>
                <asp:Label ID="lblName" runat="server" Text="Name:" Width="100px" />
                <asp:TextBox ID="txtName" runat="server" Width="250px" />
            </li>
            <li>
                <asp:Label ID="lblDescription" runat="server" Text="Description" Width="100px" />
                <asp:TextBox ID="txtDescription" runat="server" Width="250px" Height="60px" TextMode="MultiLine" Wrap="true" />
            </li>
            <li>
                <asp:Label ID="lblPrice" runat="server" Text="Price: " Width="100px" />
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator
                    ID="revPrice" runat="server" ErrorMessage="ERROR: Price must be a numeric, decimal value" ControlToValidate="txtPrice" ValidationExpression="^\d*\.?\d*" />
            </li>
            <li>
                <asp:Label ID="lblImage" runat="server" Text="Image Path?:" Width="100px" />
                <asp:TextBox ID="txtImage" runat="server" Width="250px" />
            </li>
            <li>
                <asp:Label ID="lblActive" runat="server" Text="Active?:" Width="100px" />
                <asp:CheckBox ID="cboIsActive" runat="server" Text="" />
            </li>
        </ol>
        <asp:Literal ID="litProductId" runat="server" Visible="false"></asp:Literal>
        <asp:Literal ID="litTimestamp" runat="server" Visible="false"></asp:Literal>
    </fieldset>
    <fieldset class="buttons">
        <asp:Button ID="butSubmit" runat="server" Text="Save" onclick="butSubmit_Click" />
    </fieldset>
</asp:Content>


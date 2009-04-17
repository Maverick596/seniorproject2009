<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="PurchaseForm.aspx.cs" Inherits="Admin_PurchaseForm" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Purchase Form</p>
    <p>
        <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="TbName" runat="server"></asp:TextBox>
    </p>
<p>
        <asp:Label ID="LblUserName" runat="server" Text="Username:"></asp:Label>
&nbsp;<asp:TextBox ID="TbUserName" runat="server"></asp:TextBox>
    </p>
<p>
        <asp:Label ID="LblAddress" runat="server" Text="Address: "></asp:Label>
        <asp:TextBox ID="TbAddress" runat="server"></asp:TextBox>
    </p>
<p>
        <asp:Label ID="LblGreenhouse" runat="server" Text="Greenhouse Size"></asp:Label>
&nbsp;&nbsp;
        <asp:Label ID="lblGreehouseWidth" runat="server" Text="Width: "></asp:Label>
        <asp:TextBox ID="TbGreenhouse" runat="server" MaxLength="10" Width="75px"></asp:TextBox>
&nbsp;
        <asp:Label ID="lblGreenhouseLength" runat="server" Text="Length : "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server" MaxLength="10"></asp:TextBox>
&nbsp;
        <asp:Label ID="LblGreenhouseHeight" runat="server" Text="Height : "></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" MaxLength="10"></asp:TextBox>
    </p>
<p>
        <asp:Label ID="LblSection" runat="server" Text="Section Section"></asp:Label>
&nbsp;
        <asp:Label ID="LblSectionWidth" runat="server" Text="Width: "></asp:Label>
        <asp:TextBox ID="TbGreenhouse0" runat="server" MaxLength="10" Width="75px"></asp:TextBox>
&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Length : "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;
        <asp:Label ID="Label4" runat="server" Text="Height : "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    </p>
<p>
        <asp:Label ID="LblGrrenSize" runat="server" Text="Green House Size"></asp:Label>
&nbsp;
        <asp:Label ID="Lbl" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TbGreenhouse1" runat="server" MaxLength="10" Width="75px"></asp:TextBox>
&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        :
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
&nbsp;
        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
        :
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    </p>
<p>
        <asp:Button ID="SubmitPurchaseForm" runat="server" Text="Submit" />
    </p>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="AddCrop.aspx.cs" Inherits="Greenhouses_AddCrop" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Preset Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtCropName" runat="server"></asp:TextBox>
&nbsp;<br />
    <asp:Label ID="Label2" runat="server" Text="Ideal Temperature"></asp:Label>
&nbsp;&nbsp;
    <asp:TextBox ID="txtIdealTemp" runat="server"></asp:TextBox>
&nbsp;<br />
    <asp:Label ID="Label3" runat="server" Text="Temperature Range"></asp:Label>
&nbsp;
    <asp:TextBox ID="txtTempRange" runat="server"></asp:TextBox>
&nbsp;<br />
    <asp:Label ID="Label4" runat="server" Text="Ideal Light Intensity"></asp:Label>
&nbsp;
    <asp:TextBox ID="txtLightIntensity" runat="server" 
       ></asp:TextBox>
&nbsp;<br />
    <asp:Label ID="Label5" runat="server" Text="Light Intesity Range"></asp:Label>
&nbsp;
    <asp:TextBox ID="txtLightRange" runat="server" 
       ></asp:TextBox>
&nbsp;<br />
    <asp:Label ID="Label6" runat="server" Text="Ideal Humidity"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtHumidity" runat="server"></asp:TextBox>
&nbsp;<br />
    <asp:Label ID="Label7" runat="server" Text="Humidiy Range"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtHumidityRange" runat="server"></asp:TextBox>
&nbsp;<br />
    <br />
    <asp:Button ID="btnSave" runat="server" BorderStyle="Inset" Height="18px" 
        onclick="btnSave_Click" Text="Save Preset" Width="106px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" BorderStyle="Inset" Height="18px" 
        Text="Cancel" Width="67px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
</asp:Content>


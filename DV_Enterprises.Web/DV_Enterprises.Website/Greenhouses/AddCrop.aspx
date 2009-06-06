<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="AddCrop.aspx.cs" Inherits="Greenhouses_AddCrop" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="grid_16">
   <h2 class ="logo">
    <asp:Label ID="Label1" runat="server" Text="Preset Name" Width="220px"></asp:Label>

    <asp:TextBox ID="txtCropName" runat="server" ></asp:TextBox>
<br />
    <asp:Label ID="Label2" runat="server" Text="Ideal Temperature" Width="220px"></asp:Label>

    <asp:TextBox ID="txtIdealTemp" runat="server"></asp:TextBox>
<br />
    <asp:Label ID="Label3" runat="server" Text="Temperature Threshold" Width="220px"></asp:Label>

    <asp:TextBox ID="txtTempRange" runat="server"></asp:TextBox>
<br />
    <asp:Label ID="Label4" runat="server" Text="Ideal Light Intensity" Width="220px"></asp:Label>

    <asp:TextBox ID="txtLightIntensity" runat="server" 
       ></asp:TextBox>
<br />
    <asp:Label ID="Label5" runat="server" Text="Light Intensity Threshold" 
           Width="220px"></asp:Label>

    <asp:TextBox ID="txtLightRange" runat="server" 
       ></asp:TextBox>
<br />
    <asp:Label ID="Label6" runat="server" Text="Ideal Humidity" Width="220px"></asp:Label>

    <asp:TextBox ID="txtHumidity" runat="server"></asp:TextBox>
<br />
    <asp:Label ID="Label7" runat="server" Text="Humidiy Threshold" Width="220px"></asp:Label>

    <asp:TextBox ID="txtHumidityRange" runat="server"></asp:TextBox>
<br />
         <asp:Label ID="Label8" runat="server" Text="Ideal Water Level" Width="220px"></asp:Label>
         <asp:TextBox ID="txtWaterLevel" runat="server"></asp:TextBox>
<br />
         <asp:Label ID="Label9" runat="server" Text="Water Level Threshold" Width="220px"></asp:Label>
         <asp:TextBox ID="txtWaterThreshold" runat="server"></asp:TextBox>
<br />
    <br />
    <asp:Button ID="btnSave" runat="server" Height="21px" 
        onclick="btnSave_Click" Text="Save Preset" Width="106px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Height="21px" 
        Text="Cancel" Width="67px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
</h2>
</div>
</asp:Content>


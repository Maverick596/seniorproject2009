<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="NewSection.aspx.cs" Inherits="Greenhouses_NewSection" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Section Name"></asp:Label>
&nbsp;&nbsp;<asp:TextBox ID="txtSectionName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Preset Name"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlCropName" runat="server" 
        DataSourceID="LinqDataSource1" DataTextField="Name" 
        DataValueField="CropID" AutoPostBack="True"> </asp:DropDownList>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="DV_Enterprises.Web.Data.DataAccess.SqlRepository.DataContext" 
        TableName="Presets" Select="new (Name, PresetID)">
    </asp:LinqDataSource>
    
    <br />

    <asp:Label ID="Label2" runat="server" Text="Ideal Temperature"></asp:Label>
    <asp:DropDownList ID="ddlTemp" runat="server" 
         DataTextField="IdealTemperature" 
        DataValueField="IdealTemperature" DataSourceID="LinqDataSource1">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Temperature Threshold"></asp:Label>
&nbsp;
    <asp:DropDownList ID="ddlTempThreshold" runat="server" 
        DataSourceID="LinqDataSource1" DataTextField="TemperatureThreshold" DataValueField="TemperatureThreshold" 
       >
    </asp:DropDownList>
&nbsp;<br />
    <asp:Label ID="Label4" runat="server" Text="Ideal Light Intensity"></asp:Label>
&nbsp;
    <asp:DropDownList ID="ddlLight" runat="server" DataSourceID="LinqDataSource1" 
        DataTextField="IdealLightIntensity" DataValueField="IdealLightIntensity" 
        >
    </asp:DropDownList>
&nbsp;<br />
    <asp:Label ID="Label5" runat="server" Text="Light Intiensity Threshold"></asp:Label>
&nbsp;
    <asp:DropDownList ID="ddlLightThreshold" runat="server" 
        DataSourceID="LinqDataSource1" DataTextField="LightIntensityTreshold" 
        DataValueField="LightIntensityTreshold">
    </asp:DropDownList>
&nbsp;<br />
    <asp:Label ID="Label6" runat="server" Text="Ideal Humidity"></asp:Label>
&nbsp;
    <asp:DropDownList ID="ddlHumidity" runat="server" 
        DataSourceID="LinqDataSource1" DataTextField="IdealHumidity" DataValueField="IdealHumidity" 
       >
    </asp:DropDownList>
&nbsp;<br />
    <asp:Label ID="Label7" runat="server" Text="Humidity Threshold"></asp:Label>
&nbsp;
    <asp:DropDownList ID="ddlHumidityThreshold" runat="server" 
        DataSourceID="LinqDataSource1" DataTextField="HumidityThreshold" 
        DataValueField="HumidityThreshold" Height="16px">
    </asp:DropDownList>
&nbsp;<br />
&nbsp;<asp:Button ID="btnSave" runat="server" Text="Save Section" 
        BorderStyle="Double" Height="19px" onclick="btnSave_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server"  Text="Cancel" BorderStyle="Double" 
        Height="18px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

    </asp:Content>


<%@ Page Title="{customer} &mdash; Greenhouse &mdash; Smart Greenhouse Solutions" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Greenhouse.aspx.cs" Inherits="Account_Greenhouse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="lnqSections">
        <HeaderTemplate>
            <h2 class=title">Greenhouse</h2>
        </HeaderTemplate>
        <ItemTemplate>
            
        </ItemTemplate>
        <FooterTemplate>
            <a href="#">edit</a>
            <a href="#">delete</a>
        </FooterTemplate>
    </asp:Repeater>
    <asp:LinqDataSource ID="lnqSections" runat="server" 
        ContextTypeName="DV_Enterprises.Web.DAL.DataContext" TableName="Sections" 
        Where="GreenhouseId == @GreenhouseId" EnableDelete="True" 
    EnableInsert="True" EnableUpdate="True">
        <WhereParameters>
            <asp:QueryStringParameter Name="GreenhouseId" QueryStringField="g" 
                Type="Int32" />
        </WhereParameters>
    </asp:LinqDataSource>
</asp:Content>


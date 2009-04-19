<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Greenhouses.aspx.cs" Inherits="Account_Greenhouses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title">Greenhouses</h2>
    <h3>This page should only list the users greenhouses but thats for later</h3>
    <asp:DataList ID="dalGreenhouses" runat="server" DataKeyField="GreenhouseId" 
        DataSourceID="lnqGreenhouses">
        <ItemTemplate>
            <h3 class="title">Greenhouse <%# Eval("GreenhouseId") %></h3>
            <a href="#">Details</a> |
            <a href="#">Edit</a> |
            <a href="#">Delete</a>
            <div>
                length <%# Eval("Length") %>, width <%# Eval("Width") %>, height <%# Eval("Height") %>
            </div>
          <%--LocationId:
            <asp:Label ID="LocationIdLabel" runat="server" 
                Text='<%# Eval("LocationId") %>' />
            <br />
            Sections:
            <asp:Label ID="SectionsLabel" runat="server" Text='<%# Eval("Sections") %>' />
            <br />
            Location:
            <asp:Label ID="LocationLabel" runat="server" Text='<%# Eval("Location") %>' />
            <br />
            <br />--%>
        </ItemTemplate>
    </asp:DataList>
    <asp:LinqDataSource ID="lnqGreenhouses" runat="server" 
        ContextTypeName="DV_Enterprises.Web.DAL.DataContext" 
        TableName="Greenhouses" EnableDelete="True" EnableInsert="True" 
        EnableUpdate="True">
    </asp:LinqDataSource>
</asp:Content>


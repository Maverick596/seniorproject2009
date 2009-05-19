<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="ViewGreenhouse.aspx.cs" Inherits="Greenhouses.ViewGreenhouse" %>
<%@ Import Namespace="DV_Enterprises.Web.Data.Domain"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title">Viewing Greenhouse: <asp:Label ID="lblGreenhouseID" runat="server" Text="" /></h2>
    <h3 class="title">Location</h3>
    <asp:Label ID="lblAddress" runat="server" />
    
    <br />
    <div style="text-align:center">
    <table style="width:600px; text-align:center" >
        <tr>
            <td colspan="2" align="center">
                <h3 class="title">Section:</h3>
            </td>
        </tr>
        <tr>
            <td style="text-align:left; width:300px">
                <asp:Button ID="btnNewSection" runat="server" Text="New Section" 
                    onclick="btnNewSection_Click" />
            </td>
            <td style="text-align:right; width:300px">
                <asp:Button ID="btnManageGreenhouse" runat="server" Text="Manage Greenhouse" 
                    onclick="btnManageGreenhouse_Click" />
            </td>
        </tr>
    </table>
    </div>
    <br />
    
    
    <asp:ListView ID="lvSections" runat="server">
        <LayoutTemplate>
            <ul class="sections">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
        </LayoutTemplate>
        
        <ItemTemplate>
            <li>
                <asp:Label ID="lblName" runat="server" Text='<%# ((Section)Container.DataItem).Name %>' />
            </li>
        </ItemTemplate>
        
        <EmptyDataTemplate>
        
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
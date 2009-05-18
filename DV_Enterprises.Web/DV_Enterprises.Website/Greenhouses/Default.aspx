<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Greenhouses.Default" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<div style="text-align:center">--%>

<table>
<tr>
    <td>
    <h2 class="title">Select a Greenhouse:</h2>
    <asp:Repeater runat="server" ID="rptGreenHouses">
    <HeaderTemplate>
        <table>
            <tr>        
    </HeaderTemplate>
    
    <ItemTemplate>
        <td>
           <asp:Image runat="server" ID="imageGreenHouse" ImageUrl="~/images/greenhouse.png" width="121px" height="147px" />
           <br />
           <asp:Button ID="btnSelectGreenhouse" runat="server" Text='<%# "Greenhouse:" + Eval("ID") %>' width="121px" OnClick="btnSelectGreenhouse_Click" />
        </td>
    </ItemTemplate>
    
    <FooterTemplate>
            </tr>
        </table>
    </FooterTemplate>
    </asp:Repeater>
        </td>
    
    </tr>
    <tr>
        <td align="left">
            <br />
            <asp:Button ID="btnNewGreenhouse" runat="server" Text="New Greenhouse" onclick="btnNewGreenhouse_Click" />
        </td>
    </tr>
</table>
<%--</div>--%>





<%--    <asp:ListView ID="lvGreenhouses" runat="server">
        <LayoutTemplate>
            <ul class="greenhouses">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
            </ul>
        </LayoutTemplate>
        
        <ItemTemplate>
            <li>
                <asp:Label ID="lblName" runat="server" Text='<%# ((DV_Enterprises.Web.Data.Domain.Greenhouse)Container.DataItem).Sections %>' ></asp:Label>
            </li>
        </ItemTemplate>
        
        <EmptyDataTemplate>
        
        </EmptyDataTemplate>
    </asp:ListView>--%>
</asp:Content>


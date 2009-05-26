<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Greenhouses.Default" EnableEventValidation="false" %>
<%@ Import Namespace="DV_Enterprises.Web.Data.Domain"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<div style="text-align:center">--%>

<%--<table>
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
</table>--%>
<%--</div>--%>





    <asp:ListView ID="lvGreenhouses" runat="server" 
        onitemdatabound="lvGreenhouses_ItemDataBound">
        <LayoutTemplate>
            <ul class="greenhouses grid_16">
                <h2 class="title">Greenhouses</h2>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
            </ul>
            <div>
                <asp:Button ID="btnNewGreenhouse" runat="server" Text="New Greenhouse" onclick="btnNewGreenhouse_Click" />
            </div>
        </LayoutTemplate>
        
        <ItemTemplate>
            <li>
                <asp:Image runat="server" ID="imageGreenHouse" ImageUrl="~/images/greenhouse.png" width="121px" height="147px" />
                <h2 class="title"><asp:HyperLink ID="linkGreenhouseName" runat="server" Text='<%# ((Greenhouse)Container.DataItem).ToString() %>' /></h2>
                <asp:LinkButton ID="lbView" runat="server" Text='View' OnClick="lbView_Click"/>
                <asp:Literal ID="litGreenhouseId" runat="server" Visible="false" Text='<%# ((Greenhouse)Container.DataItem).ID %>' />
            </li>
        </ItemTemplate>
        
        <EmptyDataTemplate>
            <p>No greenhouses found.</p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>


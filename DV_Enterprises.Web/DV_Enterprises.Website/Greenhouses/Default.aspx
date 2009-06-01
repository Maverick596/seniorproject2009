<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Greenhouses.Default" EnableEventValidation="false" %>
<%@ Import Namespace="DV_Enterprises.Web.Data.Domain"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ListView ID="lvGreenhouses" runat="server" 
        onitemdatabound="lvGreenhouses_ItemDataBound">
        <LayoutTemplate>
            <ul class="greenhouses grid_16">
                <h2 class="title">Greenhouses</h2>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
            </ul>
            <div>
                <asp:LinkButton ID="btnNewGreenhouse" runat="server" Text="New Greenhouse" onclick="btnNewGreenhouse_Click" />
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
            <div>
                <asp:LinkButton ID="btnNewGreenhouse" runat="server" Text="New Greenhouse" onclick="btnNewGreenhouse_Click" />
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>


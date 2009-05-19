<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="ViewGreenhouse.aspx.cs" Inherits="Greenhouses.ViewGreenhouse" %>
<%@ Import Namespace="DV_Enterprises.Web.Data.Domain"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3 class="title">Location</h3>
    <asp:Label ID="lblAddress" runat="server" />
    
    <br />
    <div style="text-align:center">
    <h2 class="title">Viewing Greenhouse: <asp:Label ID="lblGreenhouseID" runat="server" Text="" /></h2>
        <asp:Repeater ID="rptSections" runat="server" DataSourceID="SqlDataSource" 
            onitemdatabound="rptSections_ItemDataBound">
            <HeaderTemplate>
                <table style="width:600px; text-align:center" >
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td colspan="3">
                        <h3 class="title">Section:</h3>
                    </td>
                </tr>
                <tr>
                    <td style="width:200px; text-align:left">
                        <asp:Label ID="lblSectionName" runat="server" Text='<%# "Name: " + DataBinder.Eval(Container.DataItem, "Name") %>' />
                    </td>
                    <td style="width:200px; text-align:center">
                        <asp:Label ID="lblCrop" runat="server" Text='<%# "Crop: " + DataBinder.Eval(Container.DataItem, "Crop") %>' />
                    </td>
                    <td style="width:200px; text-align:right">
                        <asp:LinkButton ID="lnkBtnEditSection" runat="server" Text="Edit" ForeColor="Blue" Font-Underline="true" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "SectionID") %>' OnClick="lnkBtnEditSection_Click"  />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <table style="width:600px; text-align:center">
        <tr>
            <td style="text-align:left; width:300px">
                <asp:Button ID="btnNewSection" runat="server" Text="New Section" OnClick="btnNewSection_Click" />
            </td>
            
            <td style="text-align:right; width:300px">
                <asp:Button ID="btnManageGreenhouse" runat="server" Text="Manage Greenhouse" OnClick="btnManageGreenhouse_Click" />
            </td>
        </tr>
    </table>
    </div>
    
    <br />
    
<%--    <asp:ListView ID="lvSections" runat="server">
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
    </asp:ListView>--%>
    
    <asp:LinqDataSource ID="LinqDataSource" runat="server" 
            ContextTypeName="DV_Enterprises.Web.Data.DataAccess.SqlRepository.DataContext" 
            Select="new (SectionID, Name, Crop)" TableName="Sections" 
            Where="GreenhouseID == @GreenhouseID">
                <WhereParameters>
                    <asp:SessionParameter Name="GreenhouseID" SessionField="GreenhouseID" 
                        Type="Int32" />
                </WhereParameters>
        </asp:LinqDataSource>
        
    <asp:SqlDataSource ID="SqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ASPNETDBConnectionString %>"
        SelectCommand="SELECT S.Name AS Name, C.Name AS Crop, S.SectionID FROM [dvent_Section] S INNER JOIN [dvent_Crop] C ON S.CropID = C.CropID WHERE ([GreenhouseID] = @GreenhouseID)">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="&quot;&quot;" Name="GreenhouseID" 
                SessionField="GreenhouseID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
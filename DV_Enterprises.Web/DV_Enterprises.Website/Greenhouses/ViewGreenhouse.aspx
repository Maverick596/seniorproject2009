<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="ViewGreenhouse.aspx.cs" Inherits="Greenhouses.ViewGreenhouse" %>
<%@ Import Namespace="DV_Enterprises.Web.Data.Domain"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--    <h3 class="title">Location</h3>
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
                        <asp:Label ID="lblCrop" runat="server" Text='<%# "Preset: " + DataBinder.Eval(Container.DataItem, "Preset") %>' />
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
    
    <asp:LinqDataSource ID="LinqDataSource" runat="server" 
            
        ContextTypeName="DV_Enterprises.Web.Data.DataAccess.SqlRepository.DataContext" TableName="Addresses" 
            Where="GreenhouseID == @GreenhouseID">
                <WhereParameters>
                    <asp:SessionParameter Name="GreenhouseID" SessionField="GreenhouseID" 
                        Type="Int32" />
                </WhereParameters>
        </asp:LinqDataSource>
        
    <asp:SqlDataSource ID="SqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
        SelectCommand="SELECT * FROM [dvent_Section]">
    </asp:SqlDataSource>--%>
    
    <h2 class="title"><asp:Label ID="lblGreenhouseTitle" runat="server"></asp:Label></h2>
    <div>
        This is the greenhouse address.
    </div>

    <asp:ListView ID="lvSections" runat="server" 
        onitemediting="lvSections_ItemEditing" 
        onitemcanceling="lvSections_ItemCanceling" 
        onitemcommand="lvSections_ItemCommand" onitemdeleting="lvSections_ItemDeleting" 
        onitemupdating="lvSections_ItemUpdating">
        <LayoutTemplate>
            <ul class="sections">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
            <asp:LinkButton ID="lbNewSection" runat="server" Text="New Section" OnClick="lbNewSection_Click" />
        </LayoutTemplate>
        
        <ItemTemplate>
            <li>
                <h3 class="title">
                    <asp:Label ID="lblSectionName" runat="server" Text="<%# ((Section)Container.DataItem).Name %>" />
                    <span><asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" Text="(edit)" /></span>
                </h3>
                <div>Current Readings. This is not done yet.</div>
                <div>
                    <h4 class="title">Settings</h4>
                    <dl>
                        <dt>Preset:</dt>
                        <dd><asp:Label ID="lblSectionPreset" runat="server" Text="<%# ((Section)Container.DataItem).PresetID %>" /></dd>
                        <dt>Ideal Tempeture:</dt>
                        <dd><asp:Label ID="lblSectionIdealTempeture" runat="server" Text="<%# ((Section)Container.DataItem).IdealTemperture %>" /></dd>
                        <dt>Tempeture Threshold:</dt>
                        <dd><asp:Label ID="lblTempretureThreshold" runat="server" Text="<%# ((Section)Container.DataItem).TempertureTreshold %>" /></dd>
                        <dt>Ideal Lighting:</dt>
                        <dd><asp:Label ID="lblIdealLighting" runat="server" Text="<%# ((Section)Container.DataItem).IdealLightIntensity %>" /></dd>
                        <dt>Lighting Threshold:</dt>
                        <dd><asp:Label ID="lblLightingThreshold" runat="server" Text="<%# ((Section)Container.DataItem).LightIntensityTreshold %>" /></dd>
                        <dt>Ideal Humidity:</dt>
                        <dd><asp:Label ID="lblIdealHumidity" runat="server" Text="<%# ((Section)Container.DataItem).IdealHumidity %>" /></dd>
                        <dt>Humidity Threshold:</dt>
                        <dd><asp:Label ID="lblHumanityThreshold" runat="server" Text="<%# ((Section)Container.DataItem).HumidityTreshold %>" /></dd>
                    </dl>
                    
                </div>
            </li>
            <h4>Schedule</h4>
        </ItemTemplate>
        
        <EditItemTemplate>
            <strong>This is editing form for <asp:Label ID="lblSectionName" runat="server" Text="<%# ((Section)Container.DataItem).Name %>" /></strong>
            <asp:LinkButton ID="lbUpdate" CommandName="Update" runat="server" Text="Save" />
            <asp:LinkButton ID="lbCancel" CommandName="Cancel" runat="server" Text="Cancel" />
        </EditItemTemplate>
        
        <InsertItemTemplate>
            <strong>This is for new sections.</strong>
            <asp:LinkButton ID="lbInsert" CommandName="Insert" runat="server" Text="Save"/>
            <asp:LinkButton ID="lbCancel" CommandName="Cancel" runat="server" Text="Cancel" />
        </InsertItemTemplate>
        
        <EmptyDataTemplate>
            <p>No sections found.</p>
            <asp:LinkButton ID="lbNewSection2" runat="server" Text="New Section" OnClick="lbNewSection_Click" />
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
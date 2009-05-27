<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="ViewGreenhouse.aspx.cs" Inherits="Greenhouses.ViewGreenhouse" %>
<%@ Import Namespace="DV_Enterprises.Web.Data.Domain"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title"><asp:Label ID="lblGreenhouseTitle" runat="server"></asp:Label></h2>
    <div>
        This is the greenhouse address.
    </div>

    <asp:ListView ID="lvSections" runat="server" 
        onitemediting="lvSections_ItemEditing"
        onitemcanceling="lvSections_ItemCanceling"
        onitemcommand="lvSections_ItemCommand"
        onitemdeleting="lvSections_ItemDeleting"
        onitemupdating="lvSections_ItemUpdating"
        OnItemInserting="lvSections_ItemInserting">
        
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
                        <dd><asp:Label ID="lblSectionIdealTempeture" runat="server" Text="<%# ((Section)Container.DataItem).IdealTemperature %>" /></dd>
                        <dt>Tempeture Threshold:</dt>
                        <dd><asp:Label ID="lblTempretureThreshold" runat="server" Text="<%# ((Section)Container.DataItem).TemperatureTreshold %>" /></dd>
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
            <div class="form">
                <asp:Literal ID="litUserID" runat="server" Visible="true" Text="<%# ((Section)Container.DataItem).UserID %>" />
                <asp:Literal ID="litSectionID" runat="server" Visible="true" Text="<%# ((Section)Container.DataItem).ID %>" />
                <fieldset>
                    <legend>Basic Settings</legend>
                    <ol>
                        <li>
                            <asp:TextBox ID="tbxName" runat="server" Text="<%# ((Section)Container.DataItem).Name %>" />
                        </li>
                        <li>
                            <label>Preset:</label>
                            <asp:DropDownList ID="ddlPreset" runat="server" />
                        </li>
                    </ol>
                </fieldset>
                <fieldset>
                    <legend>Temeperature</legend>
                    <ol>
                        <li>
                            <asp:CheckBox ID="cboIsTemperatureActivated" runat="server" Checked="<%# ((Section)Container.DataItem).IsTemperatureActivated %>" Text="Is temperature activated" />
                        </li>
                        <li>
                            <label>Ideal temperature:</label>
                            <asp:TextBox ID="tbxIdealTemperature" runat="server" Text="<%# ((Section)Container.DataItem).IdealTemperature %>" />
                        </li>
                        <li>
                            <label>Temperature threshold:</label>
                            <asp:TextBox ID="tbxTemperatureTreshold" runat="server" Text="<%# ((Section)Container.DataItem).TemperatureTreshold %>" />
                        </li>
                    </ol>
                </fieldset>
                <fieldset>
                    <legend>Lighting</legend>
                    <ol>
                        <li>
                            <asp:CheckBox ID="cboIsLightActivated" runat="server" Checked="<%# ((Section)Container.DataItem).IsLightActivated %>" Text="Is light intensity activated" />
                        </li>
                        <li>
                            <label>Ideal light intensity:</label>
                            <asp:TextBox ID="tbxIdealLightIntensity" runat="server" Text="<%# ((Section)Container.DataItem).IdealLightIntensity %>" />
                        </li>
                        <li>
                            <label>Light intensity threshold:</label>
                            <asp:TextBox ID="tbxLightIntensityTreshold" runat="server" Text="<%# ((Section)Container.DataItem).LightIntensityTreshold %>" />
                        </li>
                    </ol>
                </fieldset>
                <fieldset>
                    <legend>Humidity</legend>
                    <ol>
                        <li>
                            <asp:CheckBox ID="cboIsHumidityActivated" runat="server" Checked="<%# ((Section)Container.DataItem).IsHumidityActivated %>" Text="Is Temperature Activated" />
                        </li>
                        <li>
                            <label>Ideal humidity:</label>
                            <asp:TextBox ID="tbxIdealHumidity" runat="server" Text="<%# ((Section)Container.DataItem).IdealHumidity %>" />
                        </li>
                        <li>
                            <label>Humidity threshold:</label>
                            <asp:TextBox ID="tbxHumidityTreshold" runat="server" Text="<%# ((Section)Container.DataItem).HumidityTreshold %>" />
                        </li>
                    </ol>
                </fieldset>
                <fieldset class="buttons">
                    <ol>
                        <li><asp:LinkButton ID="lbUpdate" CommandName="Update" runat="server" Text="Save" /></li>
                        <li><asp:LinkButton ID="lbCancel" CommandName="Cancel" runat="server" Text="Cancel" /></li>
                    </ol>
                </fieldset>
            </div>
        </EditItemTemplate>
        
        <InsertItemTemplate>
            <div class="form">
                <fieldset>
                    <legend>Basic Settings</legend>
                    <ol>
                        <li>
                            <asp:TextBox ID="tbxName" runat="server" />
                        </li>
                        <li>
                            <label>Preset:</label>
                            <asp:DropDownList ID="ddlPreset" runat="server" />
                        </li>
                    </ol>
                </fieldset>
                <fieldset>
                    <legend>Temeperature</legend>
                    <ol>
                        <li>
                            <asp:CheckBox ID="cboIsTemperatureActivated" runat="server" Text="Is temperature activated" />
                        </li>
                        <li>
                            <label>Ideal temperature:</label>
                            <asp:TextBox ID="tbxIdealTemperature" runat="server" />
                        </li>
                        <li>
                            <label>Temperature threshold:</label>
                            <asp:TextBox ID="tbxTemperatureTreshold" runat="server" />
                        </li>
                    </ol>
                </fieldset>
                <fieldset>
                    <legend>Lighting</legend>
                    <ol>
                        <li>
                            <asp:CheckBox ID="cboIsLightActivated" runat="server" Text="Is light intensity activated" />
                        </li>
                        <li>
                            <label>Ideal light intensity:</label>
                            <asp:TextBox ID="tbxIdealLightIntensity" runat="server" />
                        </li>
                        <li>
                            <label>Light intensity threshold:</label>
                            <asp:TextBox ID="tbxLightIntensityTreshold" runat="server" />
                        </li>
                    </ol>
                </fieldset>
                <fieldset>
                    <legend>Humidity</legend>
                    <ol>
                        <li>
                            <asp:CheckBox ID="cboIsHumidityActivated" runat="server" Text="Is Temperature Activated" />
                        </li>
                        <li>
                            <label>Ideal humidity:</label>
                            <asp:TextBox ID="tbxIdealHumidity" runat="server" />
                        </li>
                        <li>
                            <label>Humidity threshold:</label>
                            <asp:TextBox ID="tbxHumidityTreshold" runat="server" />
                        </li>
                    </ol>
                </fieldset>
                <fieldset class="buttons">
                    <ol>
                        <li><asp:LinkButton ID="lbInsert" CommandName="Insert" runat="server" Text="Save" /></li>
                        <li><asp:LinkButton ID="lbCancel" CommandName="Cancel" runat="server" Text="Cancel" /></li>
                    </ol>
                </fieldset>
            </div>
        </InsertItemTemplate>
        
        <EmptyDataTemplate>
            <p>No sections found.</p>
            <asp:LinkButton ID="lbNewSection2" runat="server" Text="New Section" OnClick="lbNewSection_Click" />
        </EmptyDataTemplate>
        
    </asp:ListView>
</asp:Content>
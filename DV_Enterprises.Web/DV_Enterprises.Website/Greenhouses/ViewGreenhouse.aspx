<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="ViewGreenhouse.aspx.cs" Inherits="Greenhouses.ViewGreenhouse" %>
<%@ Register Src="~/Controls/TaskList.ascx" TagName="TaskList" TagPrefix="dvent" %>
<%@ Import Namespace="DV_Enterprises.Web.Data.Domain"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h2 class="title grid_16">
            <asp:Literal ID="litGreenhouseTitle" runat="server" />
            <span><asp:LinkButton ID="linkEdit" runat="server" Text="(edit)" onclick="linkEdit_Click" /></span>
        </h2>
        <address class="greenhouse grid_16">
            <asp:Literal ID="litStreetAddress1" runat="server" /><br />
            <asp:Literal ID="litStreetAddress2" runat="server" /><asp:Literal ID="litStreetAddress2BR" runat="server" Text="<br />" />
            <asp:Literal ID="litCity" runat="server" />, <asp:Literal ID="litState" runat="server" /> <asp:Literal ID="litZip" runat="server" />
        </address>
        
        <asp:ListView ID="lvSections" runat="server" 
            onitemediting="lvSections_ItemEditing"
            onitemcanceling="lvSections_ItemCanceling"
            onitemcommand="lvSections_ItemCommand"
            onitemdeleting="lvSections_ItemDeleting"
            onitemupdating="lvSections_ItemUpdating"
            OnItemInserting="lvSections_ItemInserting"
            OnItemDataBound="lvSections_ItemDataBound">
            
            <LayoutTemplate>
                <ul class="sections grid_16">
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    <asp:LinkButton ID="lbNewSection" runat="server" Text="New Section" OnClick="lbNewSection_Click" />
                </ul>
            </LayoutTemplate>
            
            <ItemTemplate>
                <li class="section clearfix grid_16 alpha omega">
                    <asp:Literal ID="litSectionID" runat="server" Visible="false" Text="<%# ((Section)Container.DataItem).ID %>" />
                    <h3>
                        <asp:Label ID="lblSectionName" runat="server" Text="<%# ((Section)Container.DataItem).Name %>" />
                    </h3>
                    <dl class="table_display grid_4 alpha">
                        <h4 class="title">
                            Settings
                            <span><asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" Text="(edit)" /></span>
                            <span><asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete" Text="(delete)" /></span>
                        </h4>
                        <dt>Preset:</dt>
                        <dd><asp:Label ID="lblSectionPreset" runat="server" Text="<%# ((Section)Container.DataItem).PresetID %>" /></dd>
                        <dt>Ideal Temperature :</dt>
                        <dd><asp:Label ID="lblSectionIdealTempeture" runat="server" Text="<%# ((Section)Container.DataItem).IdealTemperature %>" /></dd>
                        <dt>Temperature  Threshold:</dt>
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
                    <div class="grid_4"><dvent:TaskList ID="tlstTemperature" runat="server" TaskName="Temperature" /></div>
                    <div class="grid_4"><dvent:TaskList ID="tlstLightIntensity" runat="server" TaskName="Light Intensity" /></div>
                    <div class="grid_4 omega"><dvent:TaskList ID="tlstHumidity" runat="server" TaskName="Humidity" /></div>
                </li>
            </ItemTemplate>
            
            <EditItemTemplate>
                <div class="form">
                    <asp:Literal ID="litUserID" runat="server" Visible="false" Text="<%# ((Section)Container.DataItem).UserID %>" />
                    <asp:Literal ID="litSectionID" runat="server" Visible="false" Text="<%# ((Section)Container.DataItem).ID %>" />
                    <fieldset class="grid_8 alpha">
                        <legend><span>Basic Settings</span></legend>
                        <ol>
                            <li>
                                <asp:Label ID="lblName" runat="server" Text="Name:" AssociatedControlID="tbxName" />
                                <asp:TextBox ID="tbxName" runat="server" Text="<%# ((Section)Container.DataItem).Name %>" />
                                <p class="inline-hints"></p>
                            </li>
                            <li>
                                <asp:Label ID="lblPreset" runat="server" Text="Preset:" AssociatedControlID="tbxName" />
                                <asp:DropDownList ID="ddlPreset" runat="server" AutoPostBack="true" />
                                <p class="inline-hints">A set of default setting for this section</p>
                            </li>
                        </ol>
                    </fieldset>
                    <fieldset class="grid_8 omega">
                        <legend>Temeperature Module</legend>
                        <ol>
                            <li>
                                <asp:Label ID="lblIsTemperatureActivated" runat="server" Text="Activated?" AssociatedControlID="cboIsTemperatureActivated" />
                                <asp:CheckBox ID="cboIsTemperatureActivated" runat="server" Checked="<%# ((Section)Container.DataItem).IsTemperatureActivated %>" />
                                <p class="inline-hints">Is the temperature module activated</p>
                            </li>
                            <li>
                                <asp:Label ID="IdealTemperature" runat="server" Text="Ideal:" AssociatedControlID="cboIsTemperatureActivated" />
                                <asp:TextBox ID="tbxIdealTemperature" runat="server" MaxLength="3" Text="<%# ((Section)Container.DataItem).IdealTemperature %>" ValidationGroup="update" />
                                <p class="inline-hints">This section's ideal temperature</p>
                                <asp:RegularExpressionValidator ID="revIdealTemperature" runat="server" ErrorMessage="Ideal temperature must be a number with 1 to 3 digits" ControlToValidate="tbxIdealTemperature" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="update" />
                            </li>
                            <li>
                                <asp:Label ID="lblTemperatureTreshold" runat="server" Text="Threshold:" AssociatedControlID="tbxTemperatureTreshold" />
                                <asp:TextBox ID="tbxTemperatureTreshold" runat="server" MaxLength="3" Text="<%# ((Section)Container.DataItem).TemperatureTreshold %>" ValidationGroup="update" />
                                <p class="inline-hints">This section's temperature threshold.</p>
                                <asp:RegularExpressionValidator ID="revTemperatureTreshold" runat="server" ErrorMessage="Temperature threshold must be a number with 1 to 3 digits ControlToValidate="tbxTemperatureTreshold" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="update" />
                            </li>
                        </ol>
                    </fieldset>
                    <fieldset class="grid_8 alpha">
                        <legend>Lighting Module</legend>
                        <ol>
                            <li>
                                <asp:Label ID="lblIsLightActivated" runat="server" Text="Activated?" AssociatedControlID="cboIsLightActivated" />
                                <asp:CheckBox ID="cboIsLightActivated" runat="server" Checked="<%# ((Section)Container.DataItem).IsLightActivated %>" />
                                <p class="inline-hints">Is the lighting module activated</p>
                            </li>
                            <li>
                                <asp:Label ID="lblIdealLightIntensity" runat="server" Text="Ideal:" AssociatedControlID="tbxIdealLightIntensity" />
                                <asp:TextBox ID="tbxIdealLightIntensity" runat="server" MaxLength="3" Text="<%# ((Section)Container.DataItem).IdealLightIntensity %>" ValidationGroup="update" />
                                <p class="inline-hints">This section's ideal light intensity</p>
                                <asp:RegularExpressionValidator ID="revIdealLightIntensity" runat="server" ErrorMessage="Ideal light intensity must be a number with 1 to 3 digits" ControlToValidate="tbxIdealLightIntensity" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="update" />
                            </li>
                            <li>
                                <asp:Label ID="lblLightIntensityTreshold" runat="server" Text="Threshold:" AssociatedControlID="tbxLightIntensityTreshold" />
                                <asp:TextBox ID="tbxLightIntensityTreshold" runat="server" MaxLength="3" Text="<%# ((Section)Container.DataItem).LightIntensityTreshold %>" ValidationGroup="update" />
                                <p class="inline-hints">This section's light intensity threshold.</p>
                                <asp:RegularExpressionValidator ID="revLightIntensityTreshold" runat="server" ErrorMessage="Light intensity threshold must be a number with 1 to 3 digits" ControlToValidate="tbxLightIntensityTreshold" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="update" />
                            </li>
                        </ol>
                    </fieldset>
                    <fieldset class="grid_8 omega">
                        <legend>Humidity Module</legend>
                        <ol>
                            <li>
                                <asp:Label ID="lblIsHumidityActivated" runat="server" Text="Activated?" AssociatedControlID="tbxIdealHumidity" />
                                <asp:CheckBox ID="cboIsHumidityActivated" runat="server" Checked="<%# ((Section)Container.DataItem).IsHumidityActivated %>" />
                                <p class="inline-hints">Is Humidity Activated</p>
                            </li>
                            <li>
                                <asp:Label ID="lblIdealHumidity" runat="server" Text="Ideal:" AssociatedControlID="tbxIdealLightIntensity" />
                                <asp:TextBox ID="tbxIdealHumidity" runat="server" MaxLength="3" Text="<%# ((Section)Container.DataItem).IdealHumidity %>" ValidationGroup="update" />
                                <p class="inline-hints">This section's ideal humidity</p>
                                <asp:RegularExpressionValidator ID="revtbxIdealHumidity" runat="server" ErrorMessage="Ideal humidity must be a number with 1 to 3 digits" ControlToValidate="tbxIdealHumidity" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="update" />
                            </li>
                            <li>
                                <asp:Label ID="lblHumidityTreshold" runat="server" Text="Threshold:" AssociatedControlID="tbxHumidityTreshold" />
                                <asp:TextBox ID="tbxHumidityTreshold" runat="server" MaxLength="3" Text="<%# ((Section)Container.DataItem).HumidityTreshold %>" ValidationGroup="update" />
                                <p class="inline-hints">This section's humidity threshold.</p>
                                <asp:RegularExpressionValidator ID="revHumidityTreshold" runat="server" ErrorMessage="humidity threshold must be a number with 1 to 3 digits" ControlToValidate="tbxHumidityTreshold" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="update" />
                            </li>
                        </ol>
                    </fieldset>
                    <fieldset class="buttons grid_16">
                        <ol>
                            <li><asp:Button ID="lbUpdate" CommandName="Update" runat="server" Text="Save" ValidationGroup="update" /></li>
                            <li><asp:LinkButton ID="lbCancel" CommandName="Cancel" runat="server" Text="Cancel" CausesValidation="false" /></li>
                        </ol>
                    </fieldset>
                </div>
            </EditItemTemplate>
            
            <InsertItemTemplate>
                <div class="form">
                    <fieldset class="grid_8 alpha">
                        <legend>Basic Settings</legend>
                        <ol>
                            <li>
                                <asp:Label ID="lblName" runat="server" Text="Name:" AssociatedControlID="tbxName" />
                                <asp:TextBox ID="tbxName" runat="server" />
                                <p class="inline-hints"></p>
                            </li>
                            <li>
                                <asp:Label ID="lblPreset" runat="server" Text="Preset:" AssociatedControlID="tbxName" />
                                <asp:DropDownList ID="ddlPreset" runat="server" AutoPostBack="true" />
                                <p class="inline-hints">A set of default setting for this section</p>
                            </li>
                        </ol>
                    </fieldset>
                    <fieldset class="grid_8 omega">
                        <legend>Temeperature Module</legend>
                        <ol>
                            <li>
                                <asp:Label ID="lblIsTemperatureActivated" runat="server" Text="Activated?" AssociatedControlID="cboIsTemperatureActivated" />
                                <asp:CheckBox ID="cboIsTemperatureActivated" runat="server" />
                                <p class="inline-hints">Is the temperature module activated</p>
                            </li>
                            <li>
                                <asp:Label ID="IdealTemperature" runat="server" Text="Ideal:" AssociatedControlID="cboIsTemperatureActivated" />
                                <asp:TextBox ID="tbxIdealTemperature" runat="server" MaxLength="3" ValidationGroup="add" />
                                <p class="inline-hints">This section's ideal temperature</p>
                                <asp:RegularExpressionValidator ID="revIdealTemperature" runat="server" ErrorMessage="Ideal temperature must be a number with 1 to 3 digits" ControlToValidate="tbxIdealTemperature" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="add" />
                            </li>
                            <li>
                                <asp:Label ID="lblTemperatureTreshold" runat="server" Text="Threshold:" AssociatedControlID="tbxTemperatureTreshold" />
                                <asp:TextBox ID="tbxTemperatureTreshold" runat="server" MaxLength="3" ValidationGroup="add" />
                                <p class="inline-hints">This section's temperature threshold.</p>
                                <asp:RegularExpressionValidator ID="revTemperatureTreshold" runat="server" ErrorMessage="Temperature threshold must be a number with 1 to 3 digits ControlToValidate="tbxTemperatureTreshold" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="add" />
                            </li>
                        </ol>
                    </fieldset>
                    <fieldset class="grid_8 alpha">
                        <legend>Lighting Module</legend>
                        <ol>
                            <li>
                                <asp:Label ID="lblIsLightActivated" runat="server" Text="Activated?" AssociatedControlID="cboIsLightActivated" />
                                <asp:CheckBox ID="cboIsLightActivated" runat="server" />
                                <p class="inline-hints">Is the lighting module activated</p>
                            </li>
                            <li>
                                <asp:Label ID="lblIdealLightIntensity" runat="server" Text="Ideal:" AssociatedControlID="tbxIdealLightIntensity" />
                                <asp:TextBox ID="tbxIdealLightIntensity" runat="server" MaxLength="3" ValidationGroup="add" />
                                <p class="inline-hints">This section's ideal light intensity</p>
                                <asp:RegularExpressionValidator ID="revIdealLightIntensity" runat="server" ErrorMessage="Ideal light intensity must be a number with 1 to 3 digits" ControlToValidate="tbxIdealLightIntensity" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="add" />
                            </li>
                            <li>
                                <asp:Label ID="lblLightIntensityTreshold" runat="server" Text="Threshold:" AssociatedControlID="tbxLightIntensityTreshold" />
                                <asp:TextBox ID="tbxLightIntensityTreshold" runat="server" MaxLength="3" ValidationGroup="add" />
                                <p class="inline-hints">This section's light intensity threshold.</p>
                                <asp:RegularExpressionValidator ID="revLightIntensityTreshold" runat="server" ErrorMessage="Light intensity threshold must be a number with 1 to 3 digits" ControlToValidate="tbxLightIntensityTreshold" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="add" />
                            </li>
                        </ol>
                    </fieldset>
                    <fieldset class="grid_8 omega">
                        <legend>Humidity Module</legend>
                        <ol>
                            <li>
                                <asp:Label ID="lblIsHumidityActivated" runat="server" Text="Activated?" AssociatedControlID="tbxIdealHumidity" />
                                <asp:CheckBox ID="cboIsHumidityActivated" runat="server" />
                                <p class="inline-hints">Is Humidity Activated</p>
                            </li>
                            <li>
                                <asp:Label ID="lblIdealHumidity" runat="server" Text="Ideal:" AssociatedControlID="tbxIdealLightIntensity" />
                                <asp:TextBox ID="tbxIdealHumidity" runat="server" MaxLength="3" ValidationGroup="add" />
                                <p class="inline-hints">This section's ideal humidity</p>
                                <asp:RegularExpressionValidator ID="revtbxIdealHumidity" runat="server" ErrorMessage="Ideal humidity must be a number with 1 to 3 digits" ControlToValidate="tbxIdealHumidity" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="add" />
                            </li>
                            <li>
                                <asp:Label ID="lblHumidityTreshold" runat="server" Text="Threshold:" AssociatedControlID="tbxHumidityTreshold" />
                                <asp:TextBox ID="tbxHumidityTreshold" runat="server" MaxLength="3" ValidationGroup="add" />
                                <p class="inline-hints">This section's humidity threshold.</p>
                                <asp:RegularExpressionValidator ID="revHumidityTreshold" runat="server" ErrorMessage="humidity threshold must be a number with 1 to 3 digits" ControlToValidate="tbxHumidityTreshold" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="add" />
                            </li>
                        </ol>
                    </fieldset>
                    <fieldset class="buttons grid_16">
                        <ol>
                            <li><asp:Button ID="lbInsert" CommandName="Insert" runat="server" Text="Save" ValidationGroup="add" /></li>
                            <li><asp:LinkButton ID="lbCancel" CommandName="Cancel" runat="server" Text="Cancel" CausesValidation="false" /></li>
                        </ol>
                    </fieldset>
                </div>
            </InsertItemTemplate>
            
            <EmptyDataTemplate>
                <div class="grid_16">
                    <p>No sections found.</p>
                    <asp:LinkButton ID="lbNewSection2" runat="server" Text="New Section" OnClick="lbNewSection_Click" />
                </div>
            </EmptyDataTemplate>
            
        </asp:ListView>
</asp:Content>
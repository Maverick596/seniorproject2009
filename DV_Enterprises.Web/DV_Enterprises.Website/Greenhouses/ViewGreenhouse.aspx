<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="ViewGreenhouse.aspx.cs" Inherits="Greenhouses.ViewGreenhouse" %>
<%@ Register Src="~/Controls/TaskList.ascx" TagName="TaskList" TagPrefix="dvent" %>
<%@ Import Namespace="DV_Enterprises.Web.Data.Domain"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="grid_16">
        <h2 class="title">
            <asp:Literal ID="litGreenhouseTitle" runat="server" />
            <span><asp:LinkButton ID="linkEdit" runat="server" Text="(edit)" onclick="linkEdit_Click" /></span>
            <span><asp:LinkButton ID="lbNewSection" runat="server" Text="(new section)" OnClick="lbNewSection_Click" /></span>
        </h2>
        
        <asp:Panel ID="pnlGreenhouseAddress" runat="server">
            <address class="greenhouse">
                <asp:Literal ID="litStreetAddress1" runat="server" /><br />
                <asp:Literal ID="litStreetAddress2" runat="server" /><asp:Literal ID="litStreetAddress2BR" runat="server" Text="<br />" />
                <asp:Literal ID="litCity" runat="server" />, <asp:Literal ID="litState" runat="server" /> 
                <asp:Literal ID="litCountry" runat="server"></asp:Literal> <asp:Literal ID="litZip" runat="server" />
            </address>
        </asp:Panel>
        
        <asp:Panel ID="pnlUsers" runat="server" Visible="false">
            <asp:ListView ID="lvUsers" runat="server"
                onitemcommand="lvUsers_ItemCommand" 
                onitemdeleting="lvUsers_ItemDeleting">
                <LayoutTemplate>
                    <h3 class="title">Users</h3>
                    <ul>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                    </ul>
                </LayoutTemplate>
                
                <ItemTemplate>
                    <li>
                        <asp:Literal ID="litUsername" runat="server" Text="<%# ((GreenhouseUser)Container.DataItem).Username %>" />
                        <span><asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete" Text="(remove)" /></span>
                    </li>
                </ItemTemplate>
            </asp:ListView>
            <div class="form">
                <fieldset>
                    <asp:DropDownList ID="ddlUsers" runat="server">
                    </asp:DropDownList>
                    <asp:Button ID="butAddUsers" runat="server" Text="Add new user to greenhouse" 
                        onclick="butAddUsers_Click" />
                </fieldset>
            </div>
        </asp:Panel>
        
        <asp:Panel ID="pnlEditGreenhouse" runat="server" Visible="false" CssClass="form">
            <fieldset>
                <legend>Address</legend>
                <ol>
                    <li>
                        <asp:Label ID="lblSteetAddress1" runat="server" Text="Street Address:" AssociatedControlID="tbxSteetAddress1" />
                        <asp:TextBox ID="tbxSteetAddress1" runat="server" /><br />
                        <asp:TextBox ID="tbxSteetAddress2" runat="server" />
                        <p class="inline-hints"></p>
                        <asp:RequiredFieldValidator ID="rfvSteetAddress1" runat="server" ErrorMessage="Address requires a street address" ControlToValidate="tbxSteetAddress1" Display="Dynamic" CssClass="inline-errors" />
                    </li>
                    <li>
                        <asp:Label ID="lblCity" runat="server" Text="City" AssociatedControlID="tbxCity" />
                        <asp:TextBox ID="tbxCity" runat="server" />
                        <p class="inline-hints"></p>
                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Address requires a city." ControlToValidate="tbxCity" Display="Dynamic" CssClass="inline-errors" />
                <asp:RegularExpressionValidator ID="revCity" runat="server" ErrorMessage="Address requires a valid city." ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ControlToValidate="tbxCity" Display="Dynamic" CssClass="inline-errors" />
                    </li>
                    <li>
                        <asp:Label ID="lblState" runat="server" Text="State:" AssociatedControlID="tbxState" />
                        <asp:TextBox ID="tbxState" runat="server" />
                        <p class="inline-hints"></p>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ForeColor="Red" ErrorMessage="Address requires a state." ControlToValidate="tbxState" Display="Dynamic" CssClass="inline-errors" />
                <asp:RegularExpressionValidator ID="revState" runat="server" ErrorMessage="Address requires a valid state." ValidationExpression="^[A-Z]{2}$" ControlToValidate="tbxState" Display="Dynamic" CssClass="inline-errors" />
                    </li>
                    <li>
                        <asp:Label ID="lblZipCode" runat="server" Text="Zip code:" AssociatedControlID="tbxZipCode" />
                        <asp:TextBox ID="tbxZipCode" runat="server" />
                        <p class="inline-hints"></p>
                        <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ForeColor="Red" ErrorMessage="Address requires zip code." ControlToValidate="tbxZipCode" Display="Dynamic" CssClass="inline-errors" />
                <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="Address zip code Field must be a 5 digit number." ControlToValidate="tbxZipCode" ValidationExpression="^\d{5}$" Display="Dynamic" CssClass="inline-errors" />
                    </li>
                    <li>
                        <asp:Label ID="lblCountry" runat="server" Text="Country:" AssociatedControlID="tbxCountry" />
                        <asp:TextBox ID="tbxCountry" runat="server" MaxLength=3 />
                        <p class="inline-hints"></p>
                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="* Field Required" ControlToValidate="tbxCountry" Display="Dynamic" CssClass="inline-errors" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="ERROR: Field must be a valid country." ValidationExpression="^[A-Z]{3}$" ControlToValidate="tbxCountry" Display="Dynamic" CssClass="inline-errors" />
                    </li>
                    <li>
                        <asp:Label ID="lblIsDefault" runat="server" Text="Default:" AssociatedControlID="cboIsDefault" />
                        <asp:CheckBox ID="cboIsDefault" runat="server" />
                        <p class="inline-hints"></p>
                    </li>
                </ol>
            </fieldset>
            <fieldset class="buttons">
                <ol>
                    <li>
                        <asp:Button ID="butUpdateGreenhouse" runat="server" Text="Save" onclick="butUpdateGreenhouse_Click" />
                    </li>
                    <li>
                        <asp:LinkButton ID="linkCancelUpdateGreenhouse" runat="server" Text="Cancel" CausesValidation="false" onclick="linkCancelUpdateGreenhouse_Click" />
                    </li>
                </ol>
            </fieldset>
        </asp:Panel>
    </div>
        
    <asp:ListView ID="lvSections" runat="server" 
        onitemediting="lvSections_ItemEditing"
        onitemcanceling="lvSections_ItemCanceling"
        onitemcommand="lvSections_ItemCommand"
        onitemdeleting="lvSections_ItemDeleting"
        onitemupdating="lvSections_ItemUpdating"
        OnItemInserting="lvSections_ItemInserting"
        OnItemDataBound="lvSections_ItemDataBound" 
        onselectedindexchanged="lvSections_SelectedIndexChanged">
        
        <LayoutTemplate>
            <ul class="sections">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
        </LayoutTemplate>
        
        <ItemTemplate>
            <li class="section clearfix">
                <asp:Literal ID="litSectionID" runat="server" Visible="false" Text="<%# ((Section)Container.DataItem).ID %>" />
                <h3 class="grid_16 title">
                    <asp:Literal ID="litSectionName" runat="server"
                        Text="<%# ((Section)Container.DataItem).Name != string.Empty
                            ? ((Section)Container.DataItem).Name
                            : ((Section)Container.DataItem).ToString() %>" />
                    <span><asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" Text="(edit)" /></span>
                    <span><asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete" Text="(delete)" /></span>
                </h3>
                
                <asp:Literal ID="litIsTemperatureActivated" runat="server" Visible="false" Text="<%# ((Section)Container.DataItem).IsTemperatureActivated %>" />
                <asp:Literal ID="litIsLightActivated" runat="server" Visible="false" Text="<%# ((Section)Container.DataItem).IsLightActivated %>" />
                <asp:Literal ID="litIsHumidityActivated" runat="server" Visible="false" Text="<%# ((Section)Container.DataItem).IsHumidityActivated %>" />
                <asp:Literal ID="litIsWaterLevelActivated" runat="server" Visible="false" Text="<%# ((Section)Container.DataItem).IsWaterLevelActivated %>" />
                
                <div class="grid_16">
                    <dl class="table_display grid_4 alpha omega">
                        <asp:Panel ID="pnlOwner" runat="server" Visible="false">
                            <dt>User:</dt>
                            <dd><asp:Literal ID="litUser" runat="server" Text="<%# ((Section)Container.DataItem).Username %>" /></dd>
                        </asp:Panel>
                        <dt>Preset:</dt>
                        <dd><asp:Literal ID="litSectionPreset" runat="server" Text="<%# ((Section)Container.DataItem).Preset.Name %>" /></dd>
                    </dl>
                </div>
                <div class="modules container_12">
                    <asp:Panel ID="pnlTemperature" runat="server" CssClass="grid_12">
                        <h4 class="title">Temperature Control</h4>
                        <dl class="table_display clearfix grid_4 alpha">
                            <h5 class="title">Basic Settings</h5>
                            <dt>Ideal Temperature :</dt>
                            <dd>
                                <asp:Literal ID="litSectionIdealTempeture" runat="server" 
                                    Text="<%#((Section)Container.DataItem).IdealTemperature != null 
                                        ? ((Section)Container.DataItem).IdealTemperature.ToString() 
                                        : PresetValue(((Section)Container.DataItem).Preset.IdealTemperature)%>" />
                            </dd>
                            <dt>Temp Threshold:</dt>
                            <dd>
                                <asp:Literal ID="litTempretureThreshold" runat="server" 
                                    Text="<%# ((Section)Container.DataItem).TemperatureThreshold != null 
                                        ? ((Section)Container.DataItem).TemperatureThreshold.ToString()
                                        : PresetValue(((Section)Container.DataItem).Preset.TemperatureThreshold) %>" />
                            </dd>
                        </dl>
                        <div class="grid_4">
                            <dvent:TaskList ID="tlstHeating" runat="server" Type="Heating" SectionID="<%# ((Section)Container.DataItem).ID %>" />
                        </div>
                        <div class="grid_4 omega">
                            <dvent:TaskList ID="tlstCooling" runat="server" Type="Cooling" SectionID="<%# ((Section)Container.DataItem).ID %>" />
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlLighting" runat="server" CssClass="grid_16">
                        <h4 class="title">Lighting Control</h4>
                        <dl class="table_display clearfix grid_4 alpha">
                            <h5 class="title">Basic Settings</h5>
                            <dt>Ideal Lighting:</dt>
                            <dd>
                                <asp:Literal ID="litIdealLighting" runat="server" 
                                    Text="<%# ((Section)Container.DataItem).IdealLightIntensity != null
                                        ? ((Section)Container.DataItem).IdealLightIntensity.ToString()
                                        : PresetValue(((Section)Container.DataItem).Preset.IdealLightIntensity) %>" />
                            </dd>
                            <dt>Lighting Threshold:</dt>
                            <dd>
                                <asp:Literal ID="litLightingThreshold" runat="server"
                                    Text="<%# ((Section)Container.DataItem).LightIntensityThreshold != null
                                        ? ((Section)Container.DataItem).LightIntensityThreshold.ToString()
                                        : PresetValue(((Section)Container.DataItem).Preset.LightIntensityThreshold) %>" />
                            </dd>
                        </dl>
                        <div class="grid_4">
                            <dvent:TaskList ID="tlstLighting" runat="server" Type="Lighting" SectionID="<%# ((Section)Container.DataItem).ID %>" />
                        </div>
                        <div class="grid_4 omega">
                            <dvent:TaskList ID="tlstOverrideLighting" runat="server" Type="OverrideLighting" SectionID="<%# ((Section)Container.DataItem).ID %>" />
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlHumidity" runat="server" CssClass="grid_16">
                        <h4 class="title">Humidity Control</h4>
                        <dl class="table_display clearfix grid_4 alpha">
                            <h5 class="title">Basic Settings</h5>
                            <dt>Ideal Humidity:</dt>
                            <dd>
                                <asp:Literal ID="litIdealHumidity" runat="server"
                                    Text="<%# ((Section)Container.DataItem).IdealHumidity != null
                                        ? ((Section)Container.DataItem).IdealHumidity.ToString()
                                        : PresetValue(((Section)Container.DataItem).Preset.IdealHumidity)  %>" />
                            </dd>
                            <dt>Humidity Threshold:</dt>
                            <dd>
                                <asp:Literal ID="litHumanityThreshold" runat="server"
                                    Text="<%# ((Section)Container.DataItem).HumidityThreshold != null
                                    ? ((Section)Container.DataItem).HumidityThreshold.ToString()
                                    : PresetValue(((Section)Container.DataItem).Preset.HumidityThreshold) %>" />
                            </dd>
                        </dl>
                        <div class="grid_4">
                            <dvent:TaskList ID="tlstHumidifying" runat="server" Type="Humidifying" SectionID="<%# ((Section)Container.DataItem).ID %>" />
                        </div>
                        <div class="grid_4 omega">
                            <dvent:TaskList ID="tlsDehumidifying" runat="server" Type="Dehumidifying" SectionID="<%# ((Section)Container.DataItem).ID %>" />
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlWaterLevel" runat="server" CssClass="grid_16">
                        <h4 class="title">Watering Control</h4>
                        <dl class="table_display clearfix grid_4 alpha">
                            <h5 class="title">Basic Settings</h5>
                            <dt>Ideal Watering Level:</dt>
                            <dd>
                                <asp:Literal ID="Literal1" runat="server"
                                    Text="<%# ((Section)Container.DataItem).IdealWaterLevel != null
                                        ? ((Section)Container.DataItem).IdealWaterLevel.ToString()
                                        : PresetValue(((Section)Container.DataItem).Preset.IdealWaterLevel)  %>" />
                            </dd>
                            <dt>Water Level Threshold:</dt>
                            <dd>
                                <asp:Literal ID="Literal2" runat="server"
                                    Text="<%# ((Section)Container.DataItem).WaterLevelThreshold != null
                                    ? ((Section)Container.DataItem).WaterLevelThreshold.ToString()
                                    : PresetValue(((Section)Container.DataItem).Preset.WaterLevelThreshold) %>" />
                            </dd>
                        </dl>
                        <div class="grid_4">
                            <dvent:TaskList ID="tlsWatering" runat="server" Type="Watering" SectionID="<%# ((Section)Container.DataItem).ID %>" />
                        </div>
                        <div class="grid_4 omega">
                            <dvent:TaskList ID="tlsNoWatering" runat="server" Type="NoWatering" SectionID="<%# ((Section)Container.DataItem).ID %>" />
                        </div>
                    </asp:Panel>
                    <asp:Label ID="lblNoModules" runat="server" Visible="false" Text="There are currently no modules in this section" CssClass="title no_modules grid_12" />
                </div>
            </li>
        </ItemTemplate>
        
        <EditItemTemplate>
            <div class="form">
                <asp:Literal ID="litUserID" runat="server" Visible="false" Text="<%# ((Section)Container.DataItem).UserID %>" />
                <asp:Literal ID="litSectionID" runat="server" Visible="false" Text="<%# ((Section)Container.DataItem).ID %>" />
                <asp:Literal ID="litPresetID" runat="server" Visible="false" Text="<%# ((Section)Container.DataItem).PresetID %>" />
                <fieldset class="grid_8">
                    <legend><span>Basic Settings</span></legend>
                    <ol>
                        <li>
                            <asp:Label ID="lblName" runat="server" Text="Name:" AssociatedControlID="tbxName" />
                            <asp:TextBox ID="tbxName" runat="server" Text="<%# ((Section)Container.DataItem).Name %>" />
                            <p class="inline-hints"></p>
                        </li>
                        <li>
                            <asp:Label ID="lblPreset" runat="server" Text="Preset:" AssociatedControlID="ddlPreset" />
                            <asp:DropDownList ID="ddlPreset" runat="server" AutoPostBack="true" />
                            <p class="inline-hints">A set of default setting for this section</p>
                        </li>
                        <asp:Panel ID="pnlOwner" runat="server" Visible="false">
                            <li>
                                <asp:Label ID="lblOwner" runat="server" Text="Owner:" AssociatedControlID="ddlOwner" />
                                <asp:DropDownList ID="ddlOwner" runat="server" AutoPostBack="true" />
                                <p class="inline-hints">Owner for this section</p>
                            </li>
                        </asp:Panel>
                    </ol>
                </fieldset>
                <fieldset class="grid_8">
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
                            <p class="inline-hints">This section&#39;s ideal temperature</p>
                            <asp:RegularExpressionValidator ID="revIdealTemperature" runat="server" ErrorMessage="Ideal temperature must be a number with 1 to 3 digits" ControlToValidate="tbxIdealTemperature" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="update" />
                        </li>
                        <li>
                            <asp:Label ID="lblTemperatureTreshold" runat="server" Text="Threshold:" AssociatedControlID="tbxTemperatureTreshold" />
                            <asp:TextBox ID="tbxTemperatureTreshold" runat="server" MaxLength="3" Text="<%# ((Section)Container.DataItem).TemperatureThreshold %>" ValidationGroup="update" />
                            <p class="inline-hints">This section&#39;s temperature threshold.</p>
                            <asp:RegularExpressionValidator ID="revTemperatureTreshold" runat="server" ErrorMessage="Temperature threshold must be a number with 1 to 3 digits ControlToValidate="tbxTemperatureTreshold" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="update" />
                        </li>
                    </ol>
                </fieldset>
                <fieldset class="grid_8">
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
                            <p class="inline-hints">This section&#39;s ideal light intensity</p>
                            <asp:RegularExpressionValidator ID="revIdealLightIntensity" runat="server" ErrorMessage="Ideal light intensity must be a number with 1 to 3 digits" ControlToValidate="tbxIdealLightIntensity" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="update" />
                        </li>
                        <li>
                            <asp:Label ID="lblLightIntensityTreshold" runat="server" Text="Threshold:" AssociatedControlID="tbxLightIntensityTreshold" />
                            <asp:TextBox ID="tbxLightIntensityTreshold" runat="server" MaxLength="3" Text="<%# ((Section)Container.DataItem).LightIntensityThreshold %>" ValidationGroup="update" />
                            <p class="inline-hints">This section&#39;s light intensity threshold.</p>
                            <asp:RegularExpressionValidator ID="revLightIntensityTreshold" runat="server" ErrorMessage="Light intensity threshold must be a number with 1 to 3 digits" ControlToValidate="tbxLightIntensityTreshold" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="update" />
                        </li>
                    </ol>
                </fieldset>
                <fieldset class="grid_8">
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
                            <p class="inline-hints">This section&#39;s ideal humidity</p>
                            <asp:RegularExpressionValidator ID="revtbxIdealHumidity" runat="server" ErrorMessage="Ideal humidity must be a number with 1 to 3 digits" ControlToValidate="tbxIdealHumidity" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="update" />
                        </li>
                        <li>
                            <asp:Label ID="lblHumidityTreshold" runat="server" Text="Threshold:" AssociatedControlID="tbxHumidityTreshold" />
                            <asp:TextBox ID="tbxHumidityTreshold" runat="server" MaxLength="3" Text="<%# ((Section)Container.DataItem).HumidityThreshold %>" ValidationGroup="update" />
                            <p class="inline-hints">This section&#39;s humidity threshold.</p>
                            <asp:RegularExpressionValidator ID="revHumidityTreshold" runat="server" ErrorMessage="humidity threshold must be a number with 1 to 3 digits" ControlToValidate="tbxHumidityTreshold" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="update" />
                        </li>
                    </ol>
                </fieldset>
                <fieldset class="grid_8">
                    <legend>Water Level Module</legend>
                    <ol>
                        <li>
                            <asp:Label ID="lblIsWaterLevelActivated" runat="server" Text="Activated?" AssociatedControlID="cboIsWaterLevelActivated" />
                            <asp:CheckBox ID="cboIsWaterLevelActivated" runat="server" Checked="<%# ((Section)Container.DataItem).IsWaterLevelActivated %>" />
                            <p class="inline-hints">Is Watering Activated</p>
                        </li>
                        <li>
                            <asp:Label ID="lblIdealWaterLevel" runat="server" Text="Ideal:" AssociatedControlID="tbxIdealWaterLevel" />
                            <asp:TextBox ID="tbxIdealWaterLevel" runat="server" MaxLength="3" Text="<%# ((Section)Container.DataItem).IdealWaterLevel %>" ValidationGroup="update" />
                            <p class="inline-hints">This section&#39;s ideal water level</p>
                            <asp:RegularExpressionValidator ID="revIdealWaterLevel" runat="server" ErrorMessage="Ideal water level must be a number with 1 to 3 digits" ControlToValidate="tbxIdealWaterLevel" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="update" />
                        </li>
                        <li>
                            <asp:Label ID="lblWaterLevelThreshold" runat="server" Text="Threshold:" AssociatedControlID="tbxWaterLevelThreshold" />
                            <asp:TextBox ID="tbxWaterLevelThreshold" runat="server" MaxLength="3" Text="<%# ((Section)Container.DataItem).WaterLevelThreshold %>" ValidationGroup="update" />
                            <p class="inline-hints">This section&#39;s water level threshold.</p>
                            <asp:RegularExpressionValidator ID="revWaterLevelThreshold" runat="server" ErrorMessage="Water level threshold must be a number with 1 to 3 digits" ControlToValidate="tbxWaterLevelThreshold" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="update" />
                        </li>
                    </ol>
                </fieldset>
                <fieldset class="buttons grid_16">
                    <ol>
                        <li><asp:Button ID="lbUpdate" CommandName="Update" runat="server" Text="Save" ValidationGroup="update" /></li>
                        <li><asp:LinkButton ID="lbCancel" CommandName="Cancel" runat="server" Text="Cancel" CausesValidation="false" />
                        
                        </li>
                    </ol>
                </fieldset>
            </div>
        </EditItemTemplate>
        
        <InsertItemTemplate>
            <div class="form">
                <fieldset class="grid_8">
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
                        <asp:Panel ID="pnlOwner" runat="server" Visible="false">
                            <li>
                                <asp:Label ID="lblOwner" runat="server" Text="Owner:" AssociatedControlID="ddlOwner" />
                                <asp:DropDownList ID="ddlOwner" runat="server" AutoPostBack="true" />
                                <p class="inline-hints">Owner for this section</p>
                            </li>
                        </asp:Panel>
                    </ol>
                </fieldset>
                <fieldset class="grid_8">
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
                            <p class="inline-hints">This section&#39;s ideal temperature</p>
                            <asp:RegularExpressionValidator ID="revIdealTemperature" runat="server" ErrorMessage="Ideal temperature must be a number with 1 to 3 digits" ControlToValidate="tbxIdealTemperature" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="add" />
                        </li>
                        <li>
                            <asp:Label ID="lblTemperatureTreshold" runat="server" Text="Threshold:" AssociatedControlID="tbxTemperatureTreshold" />
                            <asp:TextBox ID="tbxTemperatureTreshold" runat="server" MaxLength="3" ValidationGroup="add" />
                            <p class="inline-hints">This section&#39;s temperature threshold.</p>
                            <asp:RegularExpressionValidator ID="revTemperatureTreshold" runat="server" ErrorMessage="Temperature threshold must be a number with 1 to 3 digits ControlToValidate="tbxTemperatureTreshold" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="add" />
                        </li>
                    </ol>
                </fieldset>
                <fieldset class="grid_8">
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
                            <p class="inline-hints">This section&#39;s ideal light intensity</p>
                            <asp:RegularExpressionValidator ID="revIdealLightIntensity" runat="server" ErrorMessage="Ideal light intensity must be a number with 1 to 3 digits" ControlToValidate="tbxIdealLightIntensity" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="add" />
                        </li>
                        <li>
                            <asp:Label ID="lblLightIntensityTreshold" runat="server" Text="Threshold:" AssociatedControlID="tbxLightIntensityTreshold" />
                            <asp:TextBox ID="tbxLightIntensityTreshold" runat="server" MaxLength="3" ValidationGroup="add" />
                            <p class="inline-hints">This section&#39;s light intensity threshold.</p>
                            <asp:RegularExpressionValidator ID="revLightIntensityTreshold" runat="server" ErrorMessage="Light intensity threshold must be a number with 1 to 3 digits" ControlToValidate="tbxLightIntensityTreshold" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="add" />
                        </li>
                    </ol>
                </fieldset>
                <fieldset class="grid_8">
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
                            <p class="inline-hints">This section&#39;s ideal humidity</p>
                            <asp:RegularExpressionValidator ID="revtbxIdealHumidity" runat="server" ErrorMessage="Ideal humidity must be a number with 1 to 3 digits" ControlToValidate="tbxIdealHumidity" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="add" />
                        </li>
                        <li>
                            <asp:Label ID="lblHumidityTreshold" runat="server" Text="Threshold:" AssociatedControlID="tbxHumidityTreshold" />
                            <asp:TextBox ID="tbxHumidityTreshold" runat="server" MaxLength="3" ValidationGroup="add" />
                            <p class="inline-hints">This section&#39;s humidity threshold.</p>
                            <asp:RegularExpressionValidator ID="revHumidityTreshold" runat="server" ErrorMessage="humidity threshold must be a number with 1 to 3 digits" ControlToValidate="tbxHumidityTreshold" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="add" />
                        </li>
                    </ol>
                </fieldset>
                <fieldset class="grid_8">
                    <legend>Water Level Module</legend>
                    <ol>
                        <li>
                            <asp:Label ID="lblIsWaterLevelActivated" runat="server" Text="Activated?" AssociatedControlID="cboIsWaterLevelActivated" />
                            <asp:CheckBox ID="cboIsWaterLevelActivated" runat="server" />
                            <p class="inline-hints">Is WaterLevel Activated</p>
                        </li>
                        <li>
                            <asp:Label ID="lblIdealWaterLevel" runat="server" Text="Ideal:" AssociatedControlID="tbxIdealWaterLevel" />
                            <asp:TextBox ID="tbxIdealWaterLevel" runat="server" MaxLength="3" ValidationGroup="add" />
                            <p class="inline-hints">This section&#39;s ideal water level</p>
                            <asp:RegularExpressionValidator ID="revIdealWaterLevel" runat="server" ErrorMessage="Ideal water level must be a number with 1 to 3 digits" ControlToValidate="tbxIdealWaterLevel" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="add" />
                        </li>
                        <li>
                            <asp:Label ID="lblWaterLevelThreshold" runat="server" Text="Threshold:" AssociatedControlID="tbxWaterLevelThreshold" />
                            <asp:TextBox ID="tbxWaterLevelThreshold" runat="server" MaxLength="3" ValidationGroup="add" />
                            <p class="inline-hints">This section&#39;s water level threshold.</p>
                            <asp:RegularExpressionValidator ID="revWaterLevelThreshold" runat="server" ErrorMessage="humidity threshold must be a number with 1 to 3 digits" ControlToValidate="tbxWaterLevelThreshold" ValidationExpression="^[0-9]+$" Display="Dynamic" class="inline-errors" ValidationGroup="add" />
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
            <p class="grid_16">No sections found.</p>
        </EmptyDataTemplate>
        
    </asp:ListView>
</asp:Content>
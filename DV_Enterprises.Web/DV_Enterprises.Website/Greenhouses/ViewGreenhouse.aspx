<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="ViewGreenhouse.aspx.cs" Inherits="Greenhouses.ViewGreenhouse" %>
<%@ Import Namespace="DV_Enterprises.Web.Data.Domain"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title"><asp:Label ID="lblGreenhouseTitle" runat="server" CssClass="title" /></h2>
    <asp:LinkButton ID="lbManage" runat="server" Text="Manage" 
        onclick="lbManage_Click" />
        <br />
        
    <div>
        <br />
        <h3 class="title">Address:</h3>
        <asp:Label ID="lblAddress" runat="server" Text="" /> 
    </div>

    <asp:ListView ID="lvSections" runat="server" 
        onitemediting="lvSections_ItemEditing"
        onitemcanceling="lvSections_ItemCanceling"
        onitemcommand="lvSections_ItemCommand"
        onitemdeleting="lvSections_ItemDeleting"
        onitemupdating="lvSections_ItemUpdating"
        OnItemInserting="lvSections_ItemInserting"
        OnItemDataBound="lvSections_ItemDataBound">
        
        <LayoutTemplate>
            <ul class="sections">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
            <asp:LinkButton ID="lbNewSection" runat="server" Text="New Section" OnClick="lbNewSection_Click" />
        </LayoutTemplate>
        
        <ItemTemplate>
            <li>
                <asp:Literal ID="litSectionID" runat="server" Visible="false" Text="<%# ((Section)Container.DataItem).ID %>" />
                <h3 class="title">
                    <asp:Label ID="lblSectionName" runat="server" Text="<%# ((Section)Container.DataItem).Name %>" />
                    <span><asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" Text="(edit)" /></span>
                    <span><asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete" Text="(delete)" /></span>
                </h3>
                <div>
                    <br />
                    <h4 class="title">Settings</h4>
                    <dl>
                        <dt>Preset:</dt>
                        <dd><asp:Label ID="lblSectionPreset" runat="server" Text="<%# ((Section)Container.DataItem).PresetID %>" /></dd>
                        <dt>Ideal Tempeture:</dt>
                        <dd><asp:Label ID="lblSectionIdealTempeture" runat="server" Text="<%# ((Section)Container.DataItem).IdealTemperature %>" /></dd>
                        <dt>Tempeture Threshold:</dt>
                        <dd><asp:Label ID="lblTempretureThreshold" runat="server" Text="<%# ((Section)Container.DataItem).TemperatureThreshold %>" /></dd>
                        <dt>Ideal Lighting:</dt>
                        <dd><asp:Label ID="lblIdealLighting" runat="server" Text="<%# ((Section)Container.DataItem).IdealLightIntensity %>" /></dd>
                        <dt>Lighting Threshold:</dt>
                        <dd><asp:Label ID="lblLightingThreshold" runat="server" Text="<%# ((Section)Container.DataItem).LightIntensityThreshold %>" /></dd>
                        <dt>Ideal Humidity:</dt>
                        <dd><asp:Label ID="lblIdealHumidity" runat="server" Text="<%# ((Section)Container.DataItem).IdealHumidity %>" /></dd>
                        <dt>Humidity Threshold:</dt>
                        <dd><asp:Label ID="lblHumanityThreshold" runat="server" Text="<%# ((Section)Container.DataItem).HumidityThreshold %>" /></dd>
                    </dl>
                </div>
            </li>
            <h4>Scheduler...Ugly but outputs stuff</h4>
            <asp:Label ID="Label1" runat="server" Text="Temperature Tasks" Font-Bold="true" Width="140px" /><asp:LinkButton ID="lbNewTemperatureTask" runat="server" Text="New Task" CommandArgument="Temperature" OnClick="lbNewlbNewTemperatureTask_OnClick" /><br />
            <asp:GridView ID="gvTempetureTasks" runat="server" AllowSorting="false" AllowPaging="false" AutoGenerateColumns="false" CellPadding="3" CellSpacing="3">
                <Columns>
                    <asp:BoundField HeaderText="Task" DataField="ID" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="250px" />
                    <asp:BoundField HeaderText="Start Time" DataField="StartTime" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300px" DataFormatString="{0:t}" HtmlEncode="false" />
                    <asp:BoundField HeaderText="End Time" DataField="EndTime" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300px" DataFormatString="{0:t}" HtmlEncode="false" />
                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
            
            <asp:Label ID="Label2" runat="server" Text="Light Intensity Tasks" Font-Bold="true" Width="140px" /><asp:LinkButton ID="lbNewLightIntensityTask" runat="server" Text="New Task" CommandArgument="LightIntensity" OnClick="lbNewLightIntensityTask_OnClick" /><br />
            <asp:GridView ID="gvLightIntensityTasks" runat="server" AllowSorting="false" AllowPaging="false" AutoGenerateColumns="false" CellPadding="3" CellSpacing="3">
                <Columns>
                    <asp:BoundField HeaderText="Task" DataField="ID" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="250px" />
                    <asp:BoundField HeaderText="Start Time" DataField="StartTime" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300px" DataFormatString="{0:t}" HtmlEncode="false" />
                    <asp:BoundField HeaderText="End Time" DataField="EndTime" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300px" DataFormatString="{0:t}" HtmlEncode="false" />
                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
            
            <asp:Label ID="Label3" runat="server" Text="Humidity Tasks" Font-Bold="true" Width="140px" /><asp:LinkButton ID="lbNewHumidityTask" runat="server" Text="New Task" CommandArgument="Humidity" OnClick="lbNewHumidityTask_OnClick" /><br />
            <asp:GridView ID="gvHumidityTasks" runat="server" AllowSorting="false" AllowPaging="false" AutoGenerateColumns="false" CellPadding="3" CellSpacing="3">
                <Columns>
                    <asp:BoundField HeaderText="Task" DataField="ID" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="250px" />
                    <asp:BoundField HeaderText="Start Time" DataField="StartTime" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300px" DataFormatString="{0:t}" HtmlEncode="false" />
                    <asp:BoundField HeaderText="End Time" DataField="EndTime" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300px" DataFormatString="{0:t}" HtmlEncode="false" />
                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
        </ItemTemplate>
        
        <EditItemTemplate>
            <div class="form">
                <asp:Literal ID="litUserID" runat="server" Visible="false" Text="<%# ((Section)Container.DataItem).UserID %>" />
                <asp:Literal ID="litSectionID" runat="server" Visible="false" Text="<%# ((Section)Container.DataItem).ID %>" />
                <fieldset>
                    <legend>Basic Settings</legend>
                    <ol>
                        <li>
                            <asp:TextBox ID="tbxName" runat="server" Text="<%# ((Section)Container.DataItem).Name %>" />
                        </li>
                        <li>
                            <label>Preset:</label>
                            <asp:DropDownList ID="ddlPreset" runat="server" AutoPostBack="true" />
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
                            <asp:TextBox ID="tbxIdealTemperature" runat="server" MaxLength="3" Text="<%# ((Section)Container.DataItem).IdealTemperature %>" />
                            <asp:RegularExpressionValidator ID="revIdealTemperature" runat="server" ErrorMessage="ERROR: Field must be a 1-3 digit, numeric value" ControlToValidate="tbxIdealTemperature" ValidationExpression="^[0-9]+$" />
                        </li>
                        <li>
                            <label>Temperature threshold:</label>
                            <asp:TextBox ID="tbxTemperatureTreshold" runat="server" MaxLength="3" Text="<%# ((Section)Container.DataItem).TemperatureTreshold %>" />
                            <asp:RegularExpressionValidator ID="revTemperatureTreshold" runat="server" ErrorMessage="ERROR: Field must be a 1-3 digit, numeric value" ControlToValidate="tbxTemperatureTreshold" ValidationExpression="^[0-9]+$" />
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
                            <asp:TextBox ID="tbxIdealLightIntensity" runat="server" MaxLength="3" Text="<%# ((Section)Container.DataItem).IdealLightIntensity %>" />
                            <asp:RegularExpressionValidator ID="revIdealLightIntensity" runat="server" ErrorMessage="ERROR: Field must be a 1-3 digit, numeric value" ControlToValidate="tbxIdealLightIntensity" ValidationExpression="^[0-9]+$" />
                        </li>
                        <li>
                            <label>Light intensity threshold:</label>
                            <asp:TextBox ID="tbxLightIntensityTreshold" runat="server" MaxLength="3" Text="<%# ((Section)Container.DataItem).LightIntensityTreshold %>" />
                            <asp:RegularExpressionValidator ID="revLightIntensityTreshold" runat="server" ErrorMessage="ERROR: Field must be a 1-3 digit, numeric value" ControlToValidate="tbxLightIntensityTreshold" ValidationExpression="^[0-9]+$" />
                        </li>
                    </ol>
                </fieldset>
                <fieldset>
                    <legend>Humidity</legend>
                    <ol>
                        <li>
                            <asp:CheckBox ID="cboIsHumidityActivated" runat="server" Checked="<%# ((Section)Container.DataItem).IsHumidityActivated %>" Text="Is Humidity Activated" />
                        </li>
                        <li>
                            <label>Ideal humidity:</label>
                            <asp:TextBox ID="tbxIdealHumidity" runat="server" MaxLength="3" Text="<%# ((Section)Container.DataItem).IdealHumidity %>" />
                            <asp:RegularExpressionValidator ID="revtbxIdealHumidity" runat="server" ErrorMessage="ERROR: Field must be a 1-3 digit, numeric value" ControlToValidate="tbxIdealHumidity" ValidationExpression="^[0-9]+$" />
                        </li>
                        <li>
                            <label>Humidity threshold:</label>
                            <asp:TextBox ID="tbxHumidityTreshold" runat="server" MaxLength="3" Text="<%# ((Section)Container.DataItem).HumidityTreshold %>" />
                            <asp:RegularExpressionValidator ID="revHumidityTreshold" runat="server" ErrorMessage="ERROR: Field must be a 1-3 digit, numeric value" ControlToValidate="tbxHumidityTreshold" ValidationExpression="^[0-9]+$" />
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
                            <asp:DropDownList ID="ddlPreset" runat="server" AutoPostBack="true" />
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
                            <asp:CheckBox ID="cboIsHumidityActivated" runat="server" Text="Is Humidity Activated" />
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
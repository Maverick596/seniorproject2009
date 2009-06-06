<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Greenhouses.Default" EnableEventValidation="false" %>
<%@ Import Namespace="DV_Enterprises.Web.Data.Domain"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="grid_16">
        <h2 class="title">
            Greenhouses
            <span><asp:LinkButton ID="lbNewGreenhouse" runat="server" Text="(add new)" onclick="lbNewGreenhouse_Click"/></span>
        </h2>
    </div>
    <asp:ListView ID="lvGreenhouses" runat="server" 
        onitemdatabound="lvGreenhouses_ItemDataBound"
        onitemediting="lvGreenhouses_ItemEditing"
        onitemcanceling="lvGreenhouses_ItemCanceling"
        onitemcommand="lvGreenhouses_ItemCommand"
        onitemdeleting="lvGreenhouses_ItemDeleting"
        onitemupdating="lvGreenhouses_ItemUpdating"
        OnItemInserting="lvGreenhouses_ItemInserting">
        
        <LayoutTemplate>
            <ul class="greenhouses">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
            </ul>
        </LayoutTemplate>
        
        <ItemTemplate>
            <li class="grid_4">
                <asp:Literal ID="litGreenhouseID" runat="server" Visible="false" Text="<%# ((Greenhouse)Container.DataItem).ID %>" />
                <asp:LinkButton ID="lbView" runat="server" OnClick="lbView_Click">
                    <asp:Image runat="server" ID="imageGreenHouse" ImageUrl="~/images/greenhouse.png" width="121px" height="147px" />
                </asp:LinkButton>
                <h3 class="title">
                    <asp:HyperLink ID="linkGreenhouseName" runat="server" Text='<%# ((Greenhouse)Container.DataItem).ToString() %>' />
                </h3>
                <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" Text="edit" />
                <asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete" Text="delete" />
            </li>
        </ItemTemplate>
        
        <EditItemTemplate>
            <div class="grid_16">
                <div class="form">
                    <fieldset>
                        <legend>Address</legend><ol>
                            <li>
                                <asp:Label ID="lblSteetAddress1" runat="server" Text="Street Address:" AssociatedControlID="tbxSteetAddress1" />
                                <asp:TextBox ID="tbxSteetAddress1" runat="server" Text="<%# ((Greenhouse)Container.DataItem).Address.StreetLine1 %>" /><br />
                                <asp:TextBox ID="tbxSteetAddress2" runat="server" Text="<%# ((Greenhouse)Container.DataItem).Address.StreetLine2 %>" />
                                <p class="inline-hints"></p>
                                <asp:RequiredFieldValidator ID="rfvSteetAddress1" runat="server" ErrorMessage="Address requires a street address" ControlToValidate="tbxSteetAddress1" Display="Dynamic" CssClass="inline-errors" ValidationGroup="update" />
                            </li>
                            <li>
                                <asp:Label ID="lblCity" runat="server" Text="City" AssociatedControlID="tbxCity" />
                                <asp:TextBox ID="tbxCity" runat="server" Text="<%# ((Greenhouse)Container.DataItem).Address.City %>" />
                                <p class="inline-hints"></p>
                                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Address requires a city." ControlToValidate="tbxCity" Display="Dynamic" CssClass="inline-errors" ValidationGroup="update" />
                        <asp:RegularExpressionValidator ID="revCity" runat="server" ErrorMessage="Address requires a valid city." ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ControlToValidate="tbxCity" Display="Dynamic" CssClass="inline-errors" ValidationGroup="update" />
                            </li>
                            <li>
                                <asp:Label ID="lblState" runat="server" Text="State:" AssociatedControlID="tbxState" />
                                <asp:TextBox ID="tbxState" runat="server" Text="<%# ((Greenhouse)Container.DataItem).Address.StateOrProvince %>" />
                                <p class="inline-hints"></p>
                                <asp:RequiredFieldValidator ID="rfvState" runat="server" ForeColor="Red" ErrorMessage="Address requires a state." ControlToValidate="tbxState" Display="Dynamic" CssClass="inline-errors" />
                        <asp:RegularExpressionValidator ID="revState" runat="server" ErrorMessage="Address requires a valid state." ValidationExpression="^[A-Z]{2}$" ControlToValidate="tbxState" Display="Dynamic" CssClass="inline-errors" ValidationGroup="update" />
                            </li>
                            <li>
                                <asp:Label ID="lblZipCode" runat="server" Text="Zip code:" AssociatedControlID="tbxZipCode" />
                                <asp:TextBox ID="tbxZipCode" runat="server" Text="<%# ((Greenhouse)Container.DataItem).Address.Zip %>" />
                                <p class="inline-hints"></p>
                                <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ForeColor="Red" ErrorMessage="Address requires zip code." ControlToValidate="tbxZipCode" Display="Dynamic" CssClass="inline-errors" ValidationGroup="update" />
                        <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="Address zip code Field must be a 5 digit number." ControlToValidate="tbxZipCode" ValidationExpression="^\d{5}$" Display="Dynamic" CssClass="inline-errors" ValidationGroup="update" />
                            </li>
                            <li>
                                <asp:Label ID="lblCountry" runat="server" Text="Country:" AssociatedControlID="tbxCountry" />
                                <asp:TextBox ID="tbxCountry" runat="server" MaxLength=3 Text="<%# ((Greenhouse)Container.DataItem).Address.Country %>" />
                                <p class="inline-hints"></p>
                                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="* Field Required" ControlToValidate="tbxCountry" Display="Dynamic" CssClass="inline-errors" ValidationGroup="update" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="ERROR: Field must be a valid country." ValidationExpression="^[A-Z]{3}$" ControlToValidate="tbxCountry" Display="Dynamic" CssClass="inline-errors" ValidationGroup="update" />
                            </li>
                            <li>
                                <asp:Label ID="lblIsDefault" runat="server" Text="Default:" AssociatedControlID="cboIsDefault" />
                                <asp:CheckBox ID="cboIsDefault" runat="server" Checked="<%# ((Greenhouse)Container.DataItem).Address.IsDefault %>" />
                                <p class="inline-hints"></p>
                            </li>
                        </ol>
                    </fieldset>
                    <fieldset class="buttons">
                        <ol>
                            <li><asp:Button ID="lbUpdate" CommandName="Insert" runat="server" Text="Save" ValidationGroup="update" /></li>
                            <li><asp:LinkButton ID="lbCancel" CommandName="Cancel" runat="server" Text="Cancel" CausesValidation="false" /></li>
                        </ol>
                    </fieldset>
                </div>
            </div>
        </EditItemTemplate>
             
        <InsertItemTemplate>
            <div class="grid_16">
                <div class="form">
                    <fieldset>
                        <legend>Address</legend><ol>
                            <li>
                                <asp:Label ID="lblSteetAddress1" runat="server" Text="Street Address:" AssociatedControlID="tbxSteetAddress1" />
                                <asp:TextBox ID="tbxSteetAddress1" runat="server" /><br />
                                <asp:TextBox ID="tbxSteetAddress2" runat="server" />
                                <p class="inline-hints"></p>
                                <asp:RequiredFieldValidator ID="rfvSteetAddress1" runat="server" ErrorMessage="Address requires a street address" ControlToValidate="tbxSteetAddress1" Display="Dynamic" CssClass="inline-errors" ValidationGroup="insert" />
                            </li>
                            <li>
                                <asp:Label ID="lblCity" runat="server" Text="City" AssociatedControlID="tbxCity" />
                                <asp:TextBox ID="tbxCity" runat="server" />
                                <p class="inline-hints"></p>
                                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Address requires a city." ControlToValidate="tbxCity" Display="Dynamic" CssClass="inline-errors" ValidationGroup="insert" />
                        <asp:RegularExpressionValidator ID="revCity" runat="server" ErrorMessage="Address requires a valid city." ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ControlToValidate="tbxCity" Display="Dynamic" CssClass="inline-errors" ValidationGroup="insert" />
                            </li>
                            <li>
                                <asp:Label ID="lblState" runat="server" Text="State:" AssociatedControlID="tbxState" />
                                <asp:TextBox ID="tbxState" runat="server" />
                                <p class="inline-hints"></p>
                                <asp:RequiredFieldValidator ID="rfvState" runat="server" ForeColor="Red" ErrorMessage="Address requires a state." ControlToValidate="tbxState" Display="Dynamic" CssClass="inline-errors" ValidationGroup="insert"  />
                        <asp:RegularExpressionValidator ID="revState" runat="server" ErrorMessage="Address requires a valid state." ValidationExpression="^[A-Z]{2}$" ControlToValidate="tbxState" Display="Dynamic" CssClass="inline-errors" ValidationGroup="insert" />
                            </li>
                            <li>
                                <asp:Label ID="lblZipCode" runat="server" Text="Zip code:" AssociatedControlID="tbxZipCode" />
                                <asp:TextBox ID="tbxZipCode" runat="server" />
                                <p class="inline-hints"></p>
                                <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ForeColor="Red" ErrorMessage="Address requires zip code." ControlToValidate="tbxZipCode" Display="Dynamic" CssClass="inline-errors" ValidationGroup="insert" />
                        <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="Address zip code Field must be a 5 digit number." ControlToValidate="tbxZipCode" ValidationExpression="^\d{5}$" Display="Dynamic" CssClass="inline-errors" ValidationGroup="insert" />
                            </li>
                            <li>
                                <asp:Label ID="lblCountry" runat="server" Text="Country:" AssociatedControlID="tbxCountry" />
                                <asp:TextBox ID="tbxCountry" runat="server" MaxLength=3 />
                                <p class="inline-hints"></p>
                                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="* Field Required" ControlToValidate="tbxCountry" Display="Dynamic" CssClass="inline-errors" ValidationGroup="insert" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="ERROR: Field must be a valid country." ValidationExpression="^[A-Z]{3}$" ControlToValidate="tbxCountry" Display="Dynamic" CssClass="inline-errors" ValidationGroup="insert" />
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
                            <li><asp:Button ID="lbUpdate" CommandName="Insert" runat="server" Text="Save" ValidationGroup="insert" /></li>
                            <li><asp:LinkButton ID="lbCancel" CommandName="Cancel" runat="server" Text="Cancel" CausesValidation="false" /></li>
                        </ol>
                    </fieldset>
                </div>
            </div>
        </InsertItemTemplate>
                
        <EmptyDataTemplate>
            <p>No greenhouses found.</p>
        </EmptyDataTemplate>
        
    </asp:ListView>
</asp:Content>
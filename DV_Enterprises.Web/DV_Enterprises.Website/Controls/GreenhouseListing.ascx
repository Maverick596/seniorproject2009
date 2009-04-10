<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GreenhouseListing.ascx.cs" Inherits="Controls_GreenhouseListing" %>

<asp:Literal ID="lblPageSizePicker" runat="server"><strong>Greenhoues per page:</strong></asp:Literal>
<asp:DropDownList ID="ddlGreenhousesPerPage" runat="server" 
    onselectedindexchanged="ddlGreenhousesPerPage_SelectedIndexChanged" 
    AutoPostBack="True">
    <asp:ListItem Value="5"></asp:ListItem>
    <asp:ListItem Value="10"></asp:ListItem>
    <asp:ListItem>25</asp:ListItem>
    <asp:ListItem>50</asp:ListItem>
    <asp:ListItem>100</asp:ListItem>
</asp:DropDownList>
<asp:GridView ID="gvwGreenhouses" runat="server" AllowPaging="True" 
    AutoGenerateColumns="False" DataSourceID="objGreenhouses">
    <Columns>
        <asp:BoundField DataField="GreenhouseId" HeaderText="GreenhouseId" SortExpression="GreenhouseId" />
        <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
        <asp:BoundField DataField="Height" HeaderText="Height" SortExpression="Height" />
        <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" />
        <asp:BoundField DataField="LocationId" HeaderText="LocationId" SortExpression="LocationId" />
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="objGreenhouses" runat="server" OldValuesParameterFormatString="original_{0}" 
    SelectMethod="GetGreenhouseByID" TypeName="DV_Enterprises.Web.BLL.Greenhouse" 
    DataObjectTypeName="DV_Enterprises.Web.BLL.Greenhouse" DeleteMethod="DeleteGreenhouse" 
    InsertMethod="InsertGreenhouse" UpdateMethod="UpdateGreenhouse">
    <SelectParameters>
        <asp:QueryStringParameter Name="greenhouseID" QueryStringField="ID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
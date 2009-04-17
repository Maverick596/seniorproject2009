<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="customers">
        <h3>Customers (This is really greenhouses now)</h3>
        <asp:GridView ID="gvCustomers" runat="server" DataSourceID="objCustomers" 
            AllowPaging="True" AutoGenerateColumns="False">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="GreenhouseId" HeaderText="GreenhouseId" 
                    SortExpression="GreenhouseId" />
                <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
                <asp:BoundField DataField="Height" HeaderText="Height" 
                    SortExpression="Height" />
                <asp:BoundField DataField="Length" HeaderText="Length" 
                    SortExpression="Length" />
                <asp:BoundField DataField="LocationId" HeaderText="LocationId" 
                    SortExpression="LocationId" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="objCustomers" runat="server" 
            DataObjectTypeName="DV_Enterprises.Web.BLL.Greenhouse" 
            DeleteMethod="DeleteGreenhouse" InsertMethod="InsertGreenhouse" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetGreenhouses" 
            TypeName="DV_Enterprises.Web.BLL.Greenhouse" UpdateMethod="UpdateGreenhouse"></asp:ObjectDataSource>
        <asp:Button ID="btnPurchase" runat="server" Text="New Purchase" 
            PostBackUrl="~/Admin/PurchaseForm.aspx" />
    </div>
    <div class="crops">   
        <h3>Crops</h3>
        <asp:GridView ID="gvCrops" runat="server" DataSourceID="objCrops" 
            AllowPaging="True" AutoGenerateColumns="False">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="CropId" HeaderText="CropId" 
                    SortExpression="CropId" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Length" HeaderText="Length" 
                    SortExpression="Length" />
                <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" />
                <asp:BoundField DataField="Height" HeaderText="Height" 
                    SortExpression="Height" />
                <asp:BoundField DataField="MinTemperature" HeaderText="MinTemperature" 
                    SortExpression="MinTemperature" />
                <asp:BoundField DataField="MaxTemperature" HeaderText="MaxTemperature" 
                    SortExpression="MaxTemperature" />
                <asp:BoundField DataField="MinHumidity" HeaderText="MinHumidity" 
                    SortExpression="MinHumidity" />
                <asp:BoundField DataField="MaxHumidity" HeaderText="MaxHumidity" 
                    SortExpression="MaxHumidity" />
                <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" 
                    SortExpression="DateCreated" />
                <asp:BoundField DataField="DateDeleted" HeaderText="DateDeleted" 
                    SortExpression="DateDeleted" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="objCrops" runat="server" 
            DataObjectTypeName="DV_Enterprises.Web.BLL.Crop" DeleteMethod="DeleteCrop" 
            InsertMethod="InsertCrop" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetCrops" TypeName="DV_Enterprises.Web.BLL.Crop" 
            UpdateMethod="UpdateCrop"></asp:ObjectDataSource>
    </div>
</asp:Content>
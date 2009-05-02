<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" Title="Smart GreenHouse Solutions Administration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="users">
        <h3>Users</h3>
        <div>
            <p>In order to display all users whose name begin with letter click on link letter</p>
            <asp:Repeater ID="rptAlphabet" runat="server" 
                onitemcommand="rptAlphabet_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="lbutLetter" runat="server" CommandArgument="<%# Container.DataItem %>"
                        Text="<%# Container.DataItem %>">
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        
        <div>
            <p>Use the following to search users by partial username or email:</p>
            <asp:DropDownList ID="ddlUserSearchTypes" runat="server">
                <asp:ListItem>UserName</asp:ListItem>
                <asp:ListItem>E-mail</asp:ListItem>
            </asp:DropDownList>
            contains
            <asp:TextBox ID="txtUserSearch" runat="server"></asp:TextBox>
            <asp:Button ID="btnUserSearch" runat="server" Text="Search" 
                onclick="btnUserSearch_Click" />
        </div>
    </div>
    
    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="User Name">
                <ItemTemplate>
                    <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Email" HeaderText="E-Mail" DataFormatString="&lt;a href=mailto:{0}&gt;{0}&lt;a&gt;" HtmlEncode="false" />
            <asp:TemplateField HeaderText="Address">
                <ItemTemplate>
                    Address
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Phone">
                <ItemTemplate>
                    Phone
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="lnkEdit" runat="server" Text="Details"
                        NavigateUrl='<%# Eval("UserName", "~/Admin/User.aspx?Id={0}") %>'>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No users found.
        </EmptyDataTemplate>
    </asp:GridView>
    
    
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
            DataObjectTypeName="DV_Enterprises.Web.Service.Crop" DeleteMethod="DeleteCrop" 
            InsertMethod="InsertCrop" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetCrops" TypeName="DV_Enterprises.Web.Service.Crop" 
            UpdateMethod="UpdateCrop"></asp:ObjectDataSource>
    </div>
</asp:Content>
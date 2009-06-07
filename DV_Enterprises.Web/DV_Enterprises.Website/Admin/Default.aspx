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
<%--    <div class="crops">   
        <h3>Crops</h3>
    </div>--%>
</asp:Content>
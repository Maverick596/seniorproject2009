<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="LoginPage" Title="Login &mdash; Smart Greenhouse Solutions Administration" %>

<%@ MasterType VirtualPath="~/Template.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title grid_10 prefix_3 suffix_3">Log In</h2>
    <asp:Login ID="Login" runat="server" onloggedin="Login_LoggedIn">
        <LayoutTemplate>
            <div class="form grid_10 prefix_3 suffix_3">
                <fieldset>
                    <ol>
                        <li>
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Text="User Name:" />
                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                ToolTip="User Name is required." ValidationGroup="Login" Text="*" Display="Dynamic" />
                        </li>
                        <li>
                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Text="Password:" />
                            <asp:TextBox ID="Password" runat="server" TextMode="Password" />
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                ControlToValidate="Password" ErrorMessage="Password is required." 
                                ToolTip="Password is required." ValidationGroup="Login" Text="*" Display="Dynamic" />
                        </li>
                        <li>
                            <asp:Label Id="lblRemeberMe" runat="server" Text="Remember me next time." AssociatedControlID="RememberMe" />
                            <asp:CheckBox ID="RememberMe" runat="server" />
                        </li>
                    </ol>
                </fieldset>
                <fieldset class="buttons">
                    <ol>
                        <li>
                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login" />
                        </li>
                        <li>
                            <asp:HyperLink ID="linkForgotPassword" runat="server" Text="Recover Password" NavigateUrl="~/PassRecovery.aspx" />
                        </li>
                    </ol>
                </fieldset>
            </div>
        </LayoutTemplate>
    </asp:Login>
    
    
    
</asp:Content>
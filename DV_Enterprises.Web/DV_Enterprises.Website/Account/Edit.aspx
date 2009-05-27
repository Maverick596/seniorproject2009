<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Account_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset>
        <div class = "grid_16"> 
            <h2 class = "title">  Personal Information </h2>        
            <h4 class="title">           
            <ol>
        
            <li>
            
                <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
                <asp:TextBox ID="txtFirstName" runat="server" ></asp:TextBox><br />
            
            </li>
        
            <li>
                <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox><br />
            </li>
            <li>
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox><br />
            </li>
            <li>
                <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox><br />
            </li>
        </ol>
         </h4>
         </div>
    </fieldset>
    <fieldset>
    <div class = "grid_16"> 
        <h2 class = "title">Address Information</h2>
        <h4 class="title">    
        <ol>
            <li>
                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox><br />
            </li>
            <li>
                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><br />
            </li>
            <li>
                <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                <asp:TextBox ID="txtState" runat="server"></asp:TextBox><br />
            </li>
            <li>
                <asp:Label ID="lblZipCode" runat="server" Text="Zip Code"></asp:Label>
                <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox><br />
            </li>
        </ol>
        </h4>
        </div>
    </fieldset>
      <div class = "grid_16">
    <fieldset class="buttons">
       
        
                <asp:Button ID="butUpdateProfile" runat="server" Text="Save Profile" onclick="butUpdateProfile_Click" />
           
       
    </fieldset>
    
    <h4 class="title">    
    <asp:ChangePassword ID="ChangePassword1" runat="server">
    </asp:ChangePassword>
    </h4>
  </div>
</asp:Content>


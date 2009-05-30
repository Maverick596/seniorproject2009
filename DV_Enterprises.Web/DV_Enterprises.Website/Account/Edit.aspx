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
                <asp:Label ID="lblFirstName" runat="server" Text="First Name" Width="80px" />
                <asp:TextBox ID="txtFirstName" runat="server" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="revFirstName" runat="server" ErrorMessage="ERROR: Field must be a valid name." ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ControlToValidate="txtFirstName" />
                <br />
            </li>
        
            <li>
                <asp:Label ID="lblLastName" runat="server" Text="Last Name" Width="80px" />
                <asp:TextBox ID="txtLastName" runat="server" />
                <asp:RegularExpressionValidator ID="revLastName" runat="server" ErrorMessage="ERROR: Field must be a valid name." ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ControlToValidate="txtLastName" />
                <br />
            </li>
            <li>
                <asp:Label ID="lblEmail" runat="server" Text="Email" Width="80px" />
                <asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox>
                <asp:RegularExpressionValidator id="valRegEx" runat="server" ControlToValidate="txtEmail" ValidationExpression="^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                    ErrorMessage="ERROR: Field must be a valid e-mail address." />
                <br />
            </li>
            <li>
                <asp:Label ID="lblPhone" runat="server" Text="Phone" Width="80px" />
                <asp:TextBox ID="txtPhone" runat="server" MaxLength="10" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="ERROR: Field must be a valid U.S. phone number." ControlToValidate="txtZipCode" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$" />
                <br />
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
                <asp:Label ID="lblAddress" runat="server" Text="Address" Width="80px" />
                <asp:TextBox ID="txtAddress" runat="server" />
                <br />
            </li>
            <li>
                <asp:Label ID="lblCity" runat="server" Text="City" Width="80px" />
                <asp:TextBox ID="txtCity" runat="server" />
                <br />
            </li>
            <li>
                <asp:Label ID="lblState" runat="server" Text="State" Width="80px" />
                <asp:TextBox ID="txtState" runat="server" MaxLength="2" /><br />
            </li>
            <li>
                <asp:Label ID="lblZipCode" runat="server" Text="Zip Code" Width="80px" />
                <asp:TextBox ID="txtZipCode" runat="server" MaxLength="5" />
                <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="ERROR: Field must be a 5 digit, numeric value" ControlToValidate="txtZipCode" ValidationExpression="^\d{5}$" />
                <br />
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


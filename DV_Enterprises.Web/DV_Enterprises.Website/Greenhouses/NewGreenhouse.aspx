<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewGreenhouse.aspx.cs" Inherits="Greenhouses_NewGreenhouse" Title="New Greenhouse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>New Greenhouse</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="content"><div class="inner">
    
    <table width="400px">
        <tr>
            <td colspan="3" align="center">
        Address:</h2>
            </td>
        </tr>
        <tr style="text-align:right">
            <td>
                <asp:Label ID="lblAddress1" runat="server" Text="Street Line 1:" Width="200px" />
            </td>
            
            <td>
                <asp:TextBox ID="txtAddress1" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" ForeColor="Red" ErrorMessage="* Field Required" ControlToValidate="txtAddress1" />
            
            </td>
        </tr>
        <tr style="text-align:right">
            <td>
                <asp:Label ID="lblAddress2" runat="server" Text="Street Line 2:" Width="200px" />
            </td>
            <td>
                <asp:TextBox ID="txtAddress2" runat="server" />
            </td>
            <td>
            </td>
        </tr>
        <tr style="text-align:right">
            <td>
                <asp:Label ID="lblCity" runat="server" Text="City" Width="200px" />
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" MaxLength="40" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ForeColor="Red" ErrorMessage="* Field Required" ControlToValidate="txtCity" />
                <asp:RegularExpressionValidator ID="revCity" runat="server" 
                ErrorMessage="ERROR: Field must be a valid string." ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ControlToValidate="txtCity" />
            </td>
        </tr>
        <tr style="text-align:right">
            <td>
                <asp:Label ID="lblState" runat="server" Text="State" Width="200px" />
            </td>
            <td>
                <asp:TextBox ID="txtState" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvState" runat="server" ForeColor="Red" ErrorMessage="* Field Required" ControlToValidate="txtState" />
                <asp:RegularExpressionValidator ID="revState" runat="server" ErrorMessage="ERROR: Field must be a valid state." ValidationExpression="^[A-Z]{2}$" ControlToValidate="txtState" />
            </td>
        </tr>
        <tr style="text-align:right">
            <td>
                <asp:Label ID="lblZipCode" runat="server" Text="Zip Code" Width="200px" />
            </td>
            <td>
                <asp:TextBox ID="txtZipCode" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ForeColor="Red" ErrorMessage="* Field Required" ControlToValidate="txtZipCode" />
                <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="ERROR: Field must be a 5 digit, numeric value" ControlToValidate="txtZipCode" ValidationExpression="^\d{5}$" />
            </td>
        </tr>
        <tr style="text-align:right">
            <td>
                <asp:Label ID="lblCountry" runat="server" Text="Country" Width="200px" />
            </td>
            <td>
                <asp:TextBox ID="txtCountry" runat="server" MaxLength="3" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ForeColor="Red" ErrorMessage="* Field Required" ControlToValidate="txtCountry" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="ERROR: Field must be a valid country." ValidationExpression="^[A-Z]{3}$" ControlToValidate="txtCountry" />
            </td>
        </tr>
        <tr style="text-align:right">
            <td>
                <asp:Label ID="lblIsDefault" runat="server" Text="Is Default? (Yes/No)" Width="200px" />
            </td>
            <td>
                <asp:Checkbox ID="chkDefault" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="self.close();" />
    
    </div></div>
    </form>
</body>
</html>
                
                

                
                

                
                
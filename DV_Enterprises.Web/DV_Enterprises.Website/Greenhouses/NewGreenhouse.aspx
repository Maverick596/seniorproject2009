<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewGreenhouse.aspx.cs" Inherits="Greenhouses_NewGreenhouse" Title="New Greenhouse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>New Greenhouse</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="content"><div class="inner">
    
    <table width="600px">
        <tr>
            <td colspan="2" align="center">
        <h2 class="title">Address:</h2>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">
                <asp:Label ID="lblAddress1" runat="server" Text="Street Line 1: " Width="100px" />
            </td>
            
            <td style="text-align:left">
                <asp:TextBox ID="txtAddress1" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" ForeColor="Red" ErrorMessage="* Field Required" ControlToValidate="txtAddress1" Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <td style="text-align:right">
                <asp:Label ID="lblAddress2" runat="server" Text="Street Line 2: " Width="100px" />
            </td>
            <td style="text-align:left">
                <asp:TextBox ID="txtAddress2" runat="server" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">
                <asp:Label ID="lblCity" runat="server" Text="City: " Width="100px" />
            </td>
            <td style="text-align:left">
                <asp:TextBox ID="txtCity" runat="server" MaxLength="40" />
            </td>
            <td >
                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ForeColor="Red" ErrorMessage="* Field Required" ControlToValidate="txtCity" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="revCity" runat="server" 
                ErrorMessage="ERROR: Field must be a valid string." ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ControlToValidate="txtCity" Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <td style="text-align:right">
                <asp:Label ID="lblState" runat="server" Text="State: " Width="100px" />
            </td>
            <td style="text-align:left">
                <asp:TextBox ID="txtState" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvState" runat="server" ForeColor="Red" ErrorMessage="* Field Required" ControlToValidate="txtState" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="revState" runat="server" ErrorMessage="ERROR: Field must be a valid state." ValidationExpression="^[A-Z]{2}$" ControlToValidate="txtState" Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <td style="text-align:right">
                <asp:Label ID="lblZipCode" runat="server" Text="Zip Code: " Width="100px" />
            </td>
            <td style="text-align:left">
                <asp:TextBox ID="txtZipCode" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ForeColor="Red" ErrorMessage="* Field Required" ControlToValidate="txtZipCode" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="ERROR: Field must be a 5 digit, numeric value" ControlToValidate="txtZipCode" ValidationExpression="^\d{5}$" Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <td style="text-align:right">
                <asp:Label ID="lblCountry" runat="server" Text="Country: " Width="100px" />
            </td>
            <td style="text-align:left">
                <asp:TextBox ID="txtCountry" runat="server" MaxLength="3" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ForeColor="Red" ErrorMessage="* Field Required" ControlToValidate="txtCountry" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="ERROR: Field must be a valid country." ValidationExpression="^[A-Z]{3}$" ControlToValidate="txtCountry" Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <td style="text-align:right">
                <asp:Label ID="lblIsDefault" runat="server" Text="Is Default? (Yes/No): " Width="100px" />
            </td>
            <td style="text-align:left">
                <asp:Checkbox ID="chkDefault" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <br />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="self.close();" />
            </td>
        </tr>
    </table>
    <br />
    
    
    </div></div>
    </form>
</body>
</html>
                
                

                
                

                
                
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewGreenhouse.aspx.cs" Inherits="Greenhouses_NewGreenhouse" Title="New Greenhouse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>New Greenhouse</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
    
    <br />
    <br />
    <br />
    <br />
    <br />
    <table>
        <tr>
            <td colspan="2" align="center">
            <h2 class="title">Address:</h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAddress1" runat="server" Text="Street Line 1:" />
            </td>
            <td>
                <asp:TextBox ID="txtAddress1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAddress2" runat="server" Text="Street Line 2:" />
            </td>
            <td>
                <asp:TextBox ID="txtAddress2" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCity" runat="server" Text="City" />
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblState" runat="server" Text="State" />
            </td>
            <td>
                <asp:TextBox ID="txtState" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblZipCode" runat="server" Text="Zip Code" />
            </td>
            <td>
                <asp:TextBox ID="txtZipCode" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCountry" runat="server" Text="Country" />
            </td>
            <td>
                <asp:TextBox ID="txtCountry" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblIsDefault" runat="server" Text="Is Default? (Yes/No)" />
            </td>
            <td>
                <asp:Checkbox ID="chkDefault" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
    </div>
    </form>
</body>
</html>


                
                

                
                

                
                
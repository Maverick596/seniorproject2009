<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="ManageGreenhouse.aspx.cs" Inherits="Greenhouses_ManageGreenhouse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manage Greenhouse</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
    <table width="400px">
        <tr>
            <td colspan="3" align="center">
            <h2 class="title">Address:</h2>
            </td>
        </tr>
        <tr style="text-align:right">
            <td>
                <asp:Label ID="lblAddress1" runat="server" Text="Street Line 1:" ForeColor="White" />
            </td>
            
            <td>
                <asp:TextBox ID="txtAddress1" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" ForeColor="Red" Font-Bold="true" ErrorMessage="* Field Required" ControlToValidate="txtAddress1" />
            
            </td>
        </tr>
        <tr style="text-align:right">
            <td>
                <asp:Label ID="lblAddress2" runat="server" Text="Street Line 2:" ForeColor="White" />
            </td>
            <td>
                <asp:TextBox ID="txtAddress2" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvAddress2" runat="server" ForeColor="Red" Font-Bold="true" ErrorMessage="* Field Required" ControlToValidate="txtAddress2" />
            </td>
        </tr>
        <tr style="text-align:right">
            <td>
                <asp:Label ID="lblCity" runat="server" Text="City" ForeColor="White" />
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ForeColor="Red" Font-Bold="true" ErrorMessage="* Field Required" ControlToValidate="txtCity" />
            </td>
        </tr>
        <tr style="text-align:right">
            <td>
                <asp:Label ID="lblState" runat="server" Text="State" ForeColor="White" />
            </td>
            <td>
                <asp:TextBox ID="txtState" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvState" runat="server" ForeColor="Red" Font-Bold="true" ErrorMessage="* Field Required" ControlToValidate="txtState" />
            </td>
        </tr>
        <tr style="text-align:right">
            <td>
                <asp:Label ID="lblZipCode" runat="server" Text="Zip Code" ForeColor="White" />
            </td>
            <td>
                <asp:TextBox ID="txtZipCode" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ForeColor="Red" Font-Bold="true" ErrorMessage="* Field Required" ControlToValidate="txtZipCode" />
            </td>
        </tr>
        <tr style="text-align:right">
            <td>
                <asp:Label ID="lblCountry" runat="server" Text="Country" ForeColor="White" />
            </td>
            <td>
                <asp:TextBox ID="txtCountry" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ForeColor="Red" Font-Bold="true" ErrorMessage="* Field Required" ControlToValidate="txtCountry" />
            </td>
        </tr>
        <tr style="text-align:center">
            <td>
                <asp:Label ID="lblIsDefault" runat="server" Text="Is Default? (Yes/No)" ForeColor="White" />
            </td>
            <td>
                <asp:Checkbox ID="chkDefault" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="self.close();" />
    

<%--    <h2 class="title">Select a Section:</h2>
    <asp:ListView ID="lvGreenhouses" runat="server">
        <LayoutTemplate>
            <ul class="greenhouses">
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
        </LayoutTemplate>
        
        <ItemTemplate>
            <li>
                <asp:Label ID="lblName" runat="server" Text='<%# ((DV_Enterprises.Web.Data.Domain.Greenhouse)Container.DataItem).Sections %>' />
            </li>
        </ItemTemplate>
        
        <EmptyDataTemplate>
        
        </EmptyDataTemplate>
    </asp:ListView>--%>
    </div>
    </form>
</body>
</html>


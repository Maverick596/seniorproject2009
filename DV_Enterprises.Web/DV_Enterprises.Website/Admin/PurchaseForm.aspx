<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="PurchaseForm.aspx.cs" Inherits="Admin_PurchaseForm" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
                        <table border="0">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="FirstNameLabel" runat="server" AssociatedControlID="FirstName" 
                                        Text="First Name:" />
                                </td>
                                <td>
                                    <asp:TextBox ID="FirstName" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstName"
                                        ErrorMessage="First Name is required." ToolTip="First Name is required." 
                                        >*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LastNameLabel" runat="server" AssociatedControlID="LastName" 
                                        Text="Last Name:" />
                                </td>
                                <td>
                                    <asp:TextBox ID="LastName" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastName"
                                        ErrorMessage="Last Name is required." ToolTip="Last Name is required." 
                                        >*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            
                            
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Address1Label" runat="server" AssociatedControlID="Address1" 
                                        Text="Address1:" />
                                </td>
                                <td>
                                    <asp:TextBox ID="Address1" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Address1"
                                        ErrorMessage="Address1 is required." ToolTip="Address1 is required." 
                                        >*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Address2Label" runat="server" AssociatedControlID="Address2" 
                                        Text="Address2:" />
                                </td>
                                <td>
                                    <asp:TextBox ID="Address2" runat="server" />
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right">
                                    <asp:Label ID="CityLabel" runat="server" AssociatedControlID="City" 
                                        Text="City:" />
                                </td>
                                <td>
                                    <asp:TextBox ID="City" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="City"
                                        ErrorMessage="City is required." ToolTip="City is required." 
                                        >*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right">
                                    <asp:Label ID="StateLabel" runat="server" AssociatedControlID="State" 
                                        Text="State:" />
                                </td>
                                <td>
                                    <asp:TextBox ID="State" runat="server" MaxLength="2" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="City"
                                        ErrorMessage="State is required." ToolTip="State is required." 
                                        >*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ZipLabel" runat="server" AssociatedControlID="Zip" Text="Zip:" />
                                </td>
                                <td>
                                    <asp:TextBox ID="Zip" runat="server" MaxLength="5" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="City"
                                        ErrorMessage="Zip Code is required." ToolTip="Zip Code is required." 
                                        >*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PhoneLabel" runat="server" AssociatedControlID="Phone" 
                                        Text="Phone:" />
                                </td>
                                <td>
                                    <asp:TextBox ID="Phone" runat="server" MaxLength="10" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Phone"
                                        ErrorMessage="Phone Number is required." 
                                        ToolTip="Phone Number is required." >*</asp:RequiredFieldValidator>
                                    
                                </td>
                            </tr>
      
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User 
                                    Name:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server" />
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="User Name is required." ToolTip="User Name is required." 
                                        >*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="Password is required." ToolTip="Password is required." 
                                        >*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                                        AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                        ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."
                                        >*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                        ErrorMessage="E-mail is required." ToolTip="E-mail is required." 
                                        >*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security 
                                    Question:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                        ErrorMessage="Security question is required." ToolTip="Security question is required."
                                        >*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security 
                                    Answer:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                        ErrorMessage="Security answer is required." ToolTip="Security answer is required.">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
                                        ContextTypeName="DV_Enterprises.Web.DAL.DataContext" EnableDelete="True" 
                                        EnableInsert="True" EnableUpdate="True" TableName="Customers">
                                    </asp:LinqDataSource>
                                </td>
                                <td>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:ASPNETDBConnectionString %>" 
                                        DeleteCommand="DeleteCustomer" DeleteCommandType="StoredProcedure" 
                                        InsertCommand="InsertCustomer" InsertCommandType="StoredProcedure" 
                                        SelectCommand="SelectCustomer" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:Parameter Name="CustomerId" Type="String" />
                                        </SelectParameters>
                                        <DeleteParameters>
                                            <asp:Parameter Name="original_CustomerId" Type="String" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="FirstName" Type="String" />
                                            <asp:Parameter Name="LastName" Type="String" />
                                            <asp:Parameter Name="Address1" Type="String" />
                                            <asp:Parameter Name="Address2" Type="String" />
                                            <asp:Parameter Name="Phone" Type="String" />
                                            <asp:Parameter Name="Email" Type="String" />
                                            <asp:Parameter Name="UserName" Type="String" />
                                            <asp:Parameter Name="Password" Type="String" />
                                            <asp:Parameter Name="AddedBy" Type="String" />
                                            <asp:Parameter Name="ModifiedBy" Type="String" />
                                            <asp:Parameter Name="DateAdded" Type="DateTime" />
                                            <asp:Parameter Name="DateModified" Type="DateTime" />
                                        </InsertParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="SubmitButton" runat="server" onclick="SubmitButton_Click" />
                    </asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div class="grid_16">
      <h4 class="title">
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
       >
        
        <LabelStyle HorizontalAlign="Center" Width="50%" />
        
        <SideBarTemplate>
            <table border="0" cellpadding="0" cellspacing="0" 
                style="height:100%;width:100%;border-collapse:collapse;">
                <tr>
                    <td style="height:100%;width:100%;">
                        <table border="0" style="height:100%;width:100%;">
                            <tr>
                                <td align="center" colspan="2">
                                    Sign Up for Your New Account</td>
                            </tr>
                            <tr>
                                <td align="center" style="width:100px;">
                                    <label for="CreateUserWizard1_CreateUserStepContainer_UserName">
                                    User Name:</label></td>
                                <td>
                                    <input ID="CreateUserWizard1_CreateUserStepContainer_UserName" 
                                        name="CreateUserWizard1$CreateUserStepContainer$UserName" type="text" /><span 
                                        ID="CreateUserWizard1_CreateUserStepContainer_UserNameRequired" 
                                        style="color:Red;" title="User Name is required.">*</span></td>
                            </tr>
                            <tr>
                                <td align="center" style="width:100px;">
                                    <label for="CreateUserWizard1_CreateUserStepContainer_Password">
                                    Password:</label></td>
                                <td>
                                    <input ID="CreateUserWizard1_CreateUserStepContainer_Password" 
                                        name="CreateUserWizard1$CreateUserStepContainer$Password" type="password" /><span 
                                        ID="CreateUserWizard1_CreateUserStepContainer_PasswordRequired" 
                                        style="color:Red;" title="Password is required.">*</span></td>
                            </tr>
                            <tr>
                                <td align="center" style="width:100px;">
                                    <label for="CreateUserWizard1_CreateUserStepContainer_ConfirmPassword">
                                    Confirm Password:</label></td>
                                <td>
                                    <input ID="CreateUserWizard1_CreateUserStepContainer_ConfirmPassword" 
                                        name="CreateUserWizard1$CreateUserStepContainer$ConfirmPassword" 
                                        type="password" /><span 
                                        ID="CreateUserWizard1_CreateUserStepContainer_ConfirmPasswordRequired" 
                                        style="color:Red;" title="Confirm Password is required.">*</span></td>
                            </tr>
                            <tr>
                                <td align="center" style="width:100px;">
                                    <label for="CreateUserWizard1_CreateUserStepContainer_Email">
                                    E-mail:</label></td>
                                <td>
                                    <input ID="CreateUserWizard1_CreateUserStepContainer_Email" 
                                        name="CreateUserWizard1$CreateUserStepContainer$Email" type="text" /><span 
                                        ID="CreateUserWizard1_CreateUserStepContainer_EmailRequired" style="color:Red;" 
                                        title="E-mail is required.">*</span></td>
                            </tr>
                            <tr>
                                <td align="center" style="width:100px;">
                                    <label for="CreateUserWizard1_CreateUserStepContainer_Question">
                                    Security Question:</label></td>
                                <td>
                                    <input ID="CreateUserWizard1_CreateUserStepContainer_Question" 
                                        name="CreateUserWizard1$CreateUserStepContainer$Question" type="text" /><span 
                                        ID="CreateUserWizard1_CreateUserStepContainer_QuestionRequired" 
                                        style="color:Red;" title="Security question is required.">*</span></td>
                            </tr>
                            <tr>
                                <td align="center" style="width:100px;">
                                    <label for="CreateUserWizard1_CreateUserStepContainer_Answer">
                                    Security Answer:</label></td>
                                <td>
                                    <input ID="CreateUserWizard1_CreateUserStepContainer_Answer" 
                                        name="CreateUserWizard1$CreateUserStepContainer$Answer" type="text" /><span 
                                        ID="CreateUserWizard1_CreateUserStepContainer_AnswerRequired" 
                                        style="color:Red;" title="Security answer is required.">*</span></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <span ID="CreateUserWizard1_CreateUserStepContainer_PasswordCompare" 
                                        style="color:Red;">The Password and Confirmation Password must match.</span></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </SideBarTemplate>
        
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" >
                <ContentTemplate>
                    <table border="0">
                        <tr>
                            <td align="center" colspan="2">
                                Sign Up for Your New Account</td>
                        </tr>
                        <tr>
                            <td align="center" style="width:200px;">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                    ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                    ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width:200px;">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                    ControlToValidate="Password" ErrorMessage="Password is required." 
                                    ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width:200px;">
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                                    AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                    ControlToValidate="ConfirmPassword" 
                                    ErrorMessage="Confirm Password is required." 
                                    ToolTip="Confirm Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width:200px;">
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                    ControlToValidate="Email" ErrorMessage="E-mail is required." 
                                    ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width:200px;">
                                <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security Question:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" 
                                    ControlToValidate="Question" ErrorMessage="Security question is required." 
                                    ToolTip="Security question is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="width:200px;">
                                <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security Answer:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                                    ControlToValidate="Answer" ErrorMessage="Security answer is required." 
                                    ToolTip="Security answer is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                    ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                    Display="Dynamic" 
                                    ErrorMessage="The Password and Confirmation Password must match." 
                                    ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color:Red;">
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep runat="server" />
        </WizardSteps>
        
    </asp:CreateUserWizard>
    </h4>
    </div>
   
    
</asp:Content>


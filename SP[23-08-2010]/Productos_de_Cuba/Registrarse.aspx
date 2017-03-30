<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registrarse.aspx.cs" Inherits="Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="App_Themes/MasterPage/LoginStyleSheet.css" rel="stylesheet" type="text/css" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="login">
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
        CancelButtonText="Cancelar" CancelButtonType="Link" 
        CreateUserButtonImageUrl="~/App_Themes/Store/Img/030.gif" 
        CreateUserButtonText="Crear usuario" CreateUserButtonType="Image" 
        DuplicateUserNameErrorMessage="Ya existe un usuario con ese login" 
        FinishCompleteButtonImageUrl="~/App_Themes/Store/Img/030.gif" 
        FinishCompleteButtonText="Fin" FinishCompleteButtonType="Image" 
        FinishDestinationPageUrl="~/Entrar.aspx" FinishPreviousButtonText="Anterior" 
        FinishPreviousButtonType="Link" RequireEmail="False" 
        StartNextButtonText="Próximo" StartNextButtonType="Link" 
        StepNextButtonText="Próximo" StepNextButtonType="Link" 
        StepPreviousButtonText="Anterior" StepPreviousButtonType="Link">
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" Title="Entre las credenciales">
                <ContentTemplate>
                    <table border="0" style="vertical-align: middle">
                        <tr>
                            <td align="center" colspan="2" height="21px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" height="30px" style="vertical-align: middle">
                                <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Nombre:</asp:Label>
                            </td>
                            <td style="vertical-align: middle">
                                <asp:TextBox ID="Answer" runat="server" Width="180px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="NombreRFValidator" runat="server" 
                                    ControlToValidate="Answer" ErrorMessage="Se requiere un nombre para el cliente" 
                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="30px" style="vertical-align: middle">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label>
                            </td>
                            <td style="vertical-align: middle">
                                <asp:TextBox ID="UserName" runat="server" Width="180px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                    ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                    ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="30px" style="vertical-align: middle">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                            </td>
                            <td style="vertical-align: middle">
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                    ControlToValidate="Password" ErrorMessage="Password is required." 
                                    ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="30px" style="vertical-align: middle">
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                                    AssociatedControlID="ConfirmPassword">Confirmar Contraseña:</asp:Label>
                            </td>
                            <td style="vertical-align: middle">
                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" 
                                    Width="180px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                    ControlToValidate="ConfirmPassword" 
                                    ErrorMessage="Confirm Password is required." 
                                    ToolTip="Confirm Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="vertical-align: bottom">
                                <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                    ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                    Display="Dynamic" ErrorMessage="Las dos contraseñas deben coincidir" 
                                    ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="vertical-align: bottom;">
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep runat="server" Title="Proceso completado">
                <ContentTemplate>
                    <table border="0">
                        <tr>
                            <td align="center" colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                El proceso de creación a cocluido con éxito.</td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:ImageButton ID="ContinueButton" runat="server" CommandName="Continue" 
                                    ImageUrl="~/App_Themes/Store/Img/030.gif" 
                                    PostBackUrl="~/Default.aspx" ValidationGroup="CreateUserWizard1" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
    </div>
</asp:Content>


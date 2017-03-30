<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Entrar.aspx.cs" Inherits="Entrar" Title="Entrar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entrar</title>
    
    <link href="App_Themes/MasterPage/LoginStyleSheet.css" rel="stylesheet" type="text/css" />   
</head>
<body>
    <form id="form1" runat="server">
    <div id="centrado">
        <div class="login_container">
            <div class="login">
                <div class="login_actions">
                    <div class="login_register_login">
                        <span class="links_separados">
                            <asp:LinkButton ID="LBEntrar" runat="server" Text="Inicio" OnClick="inicio_OnClick"></asp:LinkButton>
                        </span>
                        <span class="links_separados">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/App_Themes/MasterPage/Img/013.jpg" />
                        </span>
                        <asp:LinkButton ID="LBRegister" runat="server" Text="Registrarse" OnClick="register_OnClick"></asp:LinkButton>
                    </div>
                </div>
                <div class="login_logo">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/MasterPage/Img/logo.gif"/>
                </div>
                <div class="login_control">
                    <asp:Login ID="PC_Login" runat="server" FailureAction="RedirectToLoginPage" onloggedin="Login_LoggedIn" Width="100%">
                             <LayoutTemplate>
                                <table border="0" cellpadding="2" cellspacing="2" style="border-collapse:collapse">
                                    <tr>
                                        <td>
                                            <table border="0" cellpadding="0" style="width:200px">                                                
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="UserName" ErrorMessage="Se requiere un nombre de usuario." 
                                                            ToolTip="Se requiere un nombre de usuario." ValidationGroup="PC_Login">*</asp:RequiredFieldValidator>
                                                    </td>                                                    
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="UserName" runat="server" Width="195px"></asp:TextBox>
                                                        
                                                    </td>
                                                </tr>
                                                <tr style="height: 21px; vertical-align:bottom">
                                                    <td>
                                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                            ControlToValidate="Password" ErrorMessage="Se debe introducir una contraseña." 
                                                            ToolTip="Se debe introducir una contraseña." ValidationGroup="PC_Login">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="195px"></asp:TextBox>
                                                        
                                                    </td>
                                                </tr>
                                                <tr  style="height: 25px; vertical-align:bottom">
                                                    <td>
                                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Recordar la próxima vez." />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2" style="color:Red;">
                                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-top: 8px">
                                                        <asp:ImageButton ID="LoginButton" runat="server" CommandName="Login" 
                                                            onclick="LoginButton_Click" AlternateText="Entrar" ValidationGroup="PC_Login" ImageUrl="~/App_Themes/MasterPage/Img/029.gif"/>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                        </asp:Login>
                </div>
            </div>
        </div> 
    </div>
    </form>
</body>
</html>

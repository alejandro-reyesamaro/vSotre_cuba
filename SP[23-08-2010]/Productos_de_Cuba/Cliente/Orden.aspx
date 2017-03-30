<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Orden.aspx.cs" Inherits="Cliente_Orden" Title="Formulario de datos (Orden)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../App_Themes/Store/FormStyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container_form">
        <div class="row">
            <div class="column_left_form">
                Usuario:
            </div>
            <div class="column_rigth_form">
                <asp:Label runat="server" ID="LUsuario" ></asp:Label>
            </div>        
        </div>
        <div class="row">
            <div class="column_left_form">
                Destinatario:
            </div>
            <div class="column_rigth_form">
                <asp:TextBox runat="server" ID="TBDestinatario" CssClass="large_control"></asp:TextBox><asp:RequiredFieldValidator ID="DestinatarioRFValidator" runat="server" 
                ControlToValidate="TBDestinatario" 
                ErrorMessage="Se requiere llenar el campo destinatario" 
                ValidationGroup="V_Forms">*</asp:RequiredFieldValidator>
            </div>                
        </div>
        <div class="row">
            <div class="column_left_form">
                Dirección:
            </div>
            <div class="column_rigth_form">
                <asp:TextBox runat="server" ID="TBDireccion" TextMode="MultiLine" CssClass="extralarge_control"></asp:TextBox><asp:RequiredFieldValidator ID="DireccionRFValidator" runat="server" 
                ControlToValidate="TBDireccion" 
                ErrorMessage="Se requiere que intoduzca la dirección del destinatario" 
                ValidationGroup="V_Forms">*</asp:RequiredFieldValidator>
            </div>
        </div>  
        <div class="row">
            <div class="column_left_form">
                Municipio:
            </div>
            <div class="column_rigth_form">
                <asp:TextBox runat="server" ID="TBMunicipio" CssClass="large_control"></asp:TextBox><asp:RequiredFieldValidator ID="MunicipioRFValidator" runat="server" 
                ControlToValidate="TBMunicipio" 
                ErrorMessage="Es obligatorio especificar el Municipio de residencia del destinatario" 
                ValidationGroup="V_Forms">*</asp:RequiredFieldValidator>
            </div>
        </div> 
        <div class="row">
            <div class="column_left_form">
                Provincia:
            </div>
            <div class="column_rigth_form">
                <asp:DropDownList runat="server" ID="DDLProvincia" CssClass="large_control">
                    <asp:ListItem Value="1">Pinar del Río</asp:ListItem>
                    <asp:ListItem Value="2">Ciudad de La Habana</asp:ListItem>
                    <asp:ListItem Value="3">La Habana</asp:ListItem>
                    <asp:ListItem Value="4">Matanzas</asp:ListItem>
                    <asp:ListItem Value="5">Cienfuegos</asp:ListItem>
                    <asp:ListItem Value="6">Villa Clara</asp:ListItem>
                    <asp:ListItem Value="7">Sancti Spíritus</asp:ListItem>
                    <asp:ListItem Value="8">Ciego de Ávila</asp:ListItem>
                    <asp:ListItem Value="9">Camaguey</asp:ListItem>
                    <asp:ListItem Value="10">Las Tunas</asp:ListItem>
                    <asp:ListItem Value="11">Holguín</asp:ListItem>
                    <asp:ListItem Value="12">Granma</asp:ListItem>
                    <asp:ListItem Value="13">Santiago de Cuba</asp:ListItem>
                    <asp:ListItem Value="14">Guantánamo</asp:ListItem>
                    <asp:ListItem Value="15">Isla de la Juventud</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>      
        <div class="row">
            <div class="column_left_form">
                Teléfono:
            </div>
            <div class="column_rigth_form">
                <asp:TextBox runat="server" ID="TBTelefono" CssClass="large_control"></asp:TextBox>
            </div>
            <asp:RegularExpressionValidator ID="TelefonoREValidator" runat="server" 
                ControlToValidate="TBTelefono" 
                ErrorMessage="El formato de teléfono introducido es no válido. Si no tiene teléfono simplemente deje el campo en blanco" 
                ValidationExpression="(\(0\d{1,4}\) {0,4}- {0,2}|\(0\d{1,4}\) {0,2})?\d+(( {0,2}| {0,2}- {0,2})\d+)*" 
                ValidationGroup="V_Forms">*</asp:RegularExpressionValidator>
        </div>
        
        <div class="row">
            <div class="column_left_form">
                Email de notificación:
            </div>
            <div class="column_rigth_form">
                <asp:TextBox runat="server" ID="TBEmail" CssClass="large_control"></asp:TextBox>
            </div>
            <asp:RegularExpressionValidator ID="EmailREValidator" runat="server" 
                ControlToValidate="TBEmail" ErrorMessage="dirección de correo no válida" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ValidationGroup="V_Forms">*</asp:RegularExpressionValidator>
        </div>
        
        
        <div class="row">
            <div class="column_left_form">
                Tipo de entrega:
            </div>
            <div class="column_rigth_form">
                <asp:DropDownList runat="server" ID="DDLEntrega" CssClass="large_control"></asp:DropDownList>
            </div>
        </div> 
        
        <div class="row">
            <div class="column_left_form">
                Comentario:
            </div>
            <div class="column_rigth_form">
                <asp:TextBox runat="server" ID="TBComentario" TextMode="MultiLine" CssClass="extralarge_control"></asp:TextBox>
            </div>            
        </div> 
                
        <div class="row">
            <div class="column_left_form">
                
            </div>
            <div class="column_rigth_form">
                <asp:ImageButton ID="IBAceptar" runat="server" AlternateText="Aceptar" ImageUrl="~/App_Themes/Store/Img/030.gif" 
                    onclick="IBAceptar_Click" ValidationGroup="V_Forms"/>
            </div>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" 
                HeaderText="Errores en el completamiento del formulario" 
                ValidationGroup="V_Forms" />
        </div>
    </div>
</asp:Content>


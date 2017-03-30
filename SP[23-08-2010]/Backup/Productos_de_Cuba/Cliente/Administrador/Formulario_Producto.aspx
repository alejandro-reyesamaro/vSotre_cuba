<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Formulario_Producto.aspx.cs" Inherits="Cliente_Administrador_Formulario_Producto" Title="Formulario de datos (Productos)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../App_Themes/Store/FormStyleSheet.css" rel="stylesheet" type="text/css" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container_form">
        <div class="row">
            <div class="column_left_form"></div>
            <div class="column_rigth_form">
                <asp:Image ID="IFoto" runat="server" Width="112px" Height="128px" ImageUrl="~/App_Themes/Store/Img/022.gif" />
            </div>                
        </div>
        <div class="row">
            <div class="column_left_form">
                Código producto:
            </div>
            <div class="column_rigth_form">
                <asp:TextBox runat="server" ID="TBCodigo" CssClass="large_control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="CodigoRFValidator" runat="server" 
                    ControlToValidate="TBCodigo" ErrorMessage="Se requiere que introduzca un codigo de producto" 
                    ValidationGroup="V_Forms">*</asp:RequiredFieldValidator>
            </div>
                
        </div>
        
        <div class="row">
            <div class="column_left_form">
                Nombre del producto:
            </div>
            <div class="column_rigth_form">
                <asp:TextBox runat="server" ID="TBNombre" CssClass="large_control"></asp:TextBox>
            </div>   
            
            
            <asp:RequiredFieldValidator ID="NombreProductoRFValidator" runat="server" 
                ControlToValidate="TBNombre" 
                ErrorMessage="Se requiere que introduzca un nombre de producto" 
                ValidationGroup="V_Forms">*</asp:RequiredFieldValidator>
            
            
        </div>
        
        <div class="row">
            <div class="column_left_form">
                Marca:
            </div>
            <div class="column_rigth_form">
                <asp:TextBox runat="server" ID="TBMarca" CssClass="large_control"></asp:TextBox>
            </div>
        </div>
        
        <div class="row">
            <div class="column_left_form">
                Descripción:
            </div>
            <div class="column_rigth_form">
                <asp:TextBox runat="server" ID="TBDescripcion" TextMode="MultiLine" CssClass="extralarge_control"></asp:TextBox>
            </div>
        </div>
        
        <div class="row">
            <div class="column_left_form">
                Categoría:
            </div>
            <div class="column_rigth_form">
                <asp:DropDownList runat="server" ID="DDLCategoria" CssClass="large_control"></asp:DropDownList>
            </div>
        </div>
        
        <div class="row">
            <div class="column_left_form">
                Precio:
            </div>
            <div class="column_rigth_form">
                <asp:TextBox runat="server" ID="TBPrecio" CssClass="large_control"></asp:TextBox>
            </div>                        
            <asp:RegularExpressionValidator ID="PrecioREValidator" runat="server" 
                ControlToValidate="TBPrecio" 
                ErrorMessage="El precio debe tener un formato numérico" 
                ValidationExpression="(\d)+((.|,)\d{2})?" ValidationGroup="V_Forms">*</asp:RegularExpressionValidator>                
            <asp:RequiredFieldValidator ID="PrecioRFValidator" runat="server" 
                ControlToValidate="TBPrecio" 
                ErrorMessage="Necesita introducir el precio del producto" 
                ValidationGroup="V_Forms">*</asp:RequiredFieldValidator>
        </div>
        
        <div class="row">
            <div class="column_left_form">
                Existencia:
            </div>
            <div class="column_rigth_form">
                <asp:TextBox runat="server" ID="TBCantidad" CssClass="large_control"></asp:TextBox>
            </div>
            <asp:RegularExpressionValidator ID="ExistenciaREValidator" runat="server" 
                ControlToValidate="TBCantidad" 
                ErrorMessage="Debe escribir un numero natural como cantidad" 
                ValidationExpression="(\d)+" ValidationGroup="V_Forms">*</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="ExistenciaRFValidator" runat="server" 
                ControlToValidate="TBCantidad" 
                ErrorMessage="Necesita especificar la existencia de los productos en el almacén" 
                ValidationGroup="V_Forms">*</asp:RequiredFieldValidator>
        </div>
        
        <div class="row">
            <div class="column_left_form">
                Foto:
            </div>
            <div class="column_rigth_form">
                <input id="Browse" runat="server" class="large_control" type="file" accept="application/image"/>
            </div>
        </div>
        
        <div class="row">
            <div class="column_left_form">
                
            </div>
            <div class="column_rigth_form">
                <asp:ImageButton ID="IBAceptar" runat="server" AlternateText="Aceptar" ValidationGroup="V_Forms" onclick="IBAceptar_Click" />
            </div>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" 
                HeaderText="Errores en el completamiento del formulario" 
                ValidationGroup="V_Forms" />
        </div>
    </div>
</asp:Content>


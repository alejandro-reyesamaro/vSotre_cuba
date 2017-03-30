<%@ Page Title="Formulario de datos (Categoría)" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Formulario_Categoria.aspx.cs" Inherits="Cliente_Administrador_Formulario_Categoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../App_Themes/Store/FormStyleSheet.css" rel="stylesheet" type="text/css" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container_form">       
        
        <div class="row">
            <div class="column_left_form">
                Nombre de la categoría:
            </div>
            <div class="column_rigth_form">
                <asp:TextBox runat="server" ID="TBNombre" CssClass="large_control"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="NombreCategoriaRFValidator" runat="server" 
                ControlToValidate="TBNombre" 
                ErrorMessage="Es necesario entrar el nombre de la categoria" 
                ValidationGroup="V_Forms">*</asp:RequiredFieldValidator>
        </div>
        
        
        <div class="row">
            <div class="column_left_form">
                Descripción:
            </div>
            <div class="column_rigth_form">
                <asp:TextBox runat="server" ID="TBDescripcion" TextMode="MultiLine" CssClass="extralarge_control"></asp:TextBox>
            </div>
        </div>
        
        
        <%--<div class="row">
            <div class="column_left_form">
                Foto:
            </div>
            <div class="column_rigth_form">
                <input id="Browse" runat="server" class="large_control" type="file" accept="application/image"/>
            </div>
        </div>--%>
        
        <div class="row">
            <div class="column_left_form">
                
            </div>
            <div class="column_rigth_form">
                <asp:ImageButton ID="IBAceptar" runat="server" AlternateText="Aceptar" 
                    onclick="IBAceptar_Click" ValidationGroup="V_Forms" />
            </div>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" 
                HeaderText="Errores en el completamiento del formulario" 
                ValidationGroup="V_Forms" />
        </div>
    </div>
</asp:Content>
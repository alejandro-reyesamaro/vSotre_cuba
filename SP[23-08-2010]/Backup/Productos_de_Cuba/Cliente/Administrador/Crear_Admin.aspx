<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Crear_Admin.aspx.cs" Inherits="Cliente_Administrador_Crear_Admin" Title="Crear nuevo administrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="../../App_Themes/Store/FormStyleSheet.css" rel="stylesheet" type="text/css" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container_form">
               
        <div class="row">
            <div class="column_left_form">
                Nombre:
            </div>
            <div class="column_rigth_form">
                <asp:TextBox runat="server" ID="TBNombre" CssClass="large_control"></asp:TextBox>
            </div>
        </div>
        
        <div class="row">
            <div class="column_left_form">
                login:
            </div>
            <div class="column_rigth_form">
                <asp:TextBox runat="server" ID="TBLogin" CssClass="large_control"></asp:TextBox>
            </div>
        </div>
        
        <div class="row">
            <div class="column_left_form">
                password:
            </div>
            <div class="column_rigth_form">
                <asp:TextBox runat="server" ID="TBPassword"  CssClass="large_control"></asp:TextBox>
            </div>
        </div>  
     
        
        <div class="row">
            <div class="column_left_form">
                
            </div>
            <div class="column_rigth_form">
                <asp:ImageButton ID="IBAceptar" runat="server" AlternateText="Aceptar" ImageUrl="~/App_Themes/Store/Img/030.gif"
                    onclick="IBAceptar_Click" />
            </div>
        </div>
        
        <div class="row">
            <div class="column_left_form">
                
            </div>
            <div class="column_rigth_form">
                <asp:Label ID="LInfo" runat="server" Text="login no válido" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>


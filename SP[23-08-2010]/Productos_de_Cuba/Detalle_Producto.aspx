<%@ Page Title="Detalles del producto" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Detalle_Producto.aspx.cs" Inherits="Detalle_Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="App_Themes/Store/ProductoDetalleStyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="detalle_container">
    <div class="detalle_row">        
        <div class="img_2">
            <asp:Image ID="IFoto2" runat="server" Width="112px" Height="128px" ImageUrl="~/App_Themes/Store/Img/022.gif"/>
        </div>
    </div>
    <div class="detalle_row">
        <span class="detalle_nombre">
            <asp:LinkButton ID="LBNombre" runat="server">Nombre del producto</asp:LinkButton>
        </span>
        <span class="detalle_marca">
            <asp:Label ID="LMarca" runat="server">Marca del producto</asp:Label>
        </span>
    </div>
    <div class="detalle_row">
        <div class="detalle_precio">
            <asp:Label ID="LPrecio" runat="server" >$ 0.00</asp:Label>
        </div>
    </div>
    <div class="detalle_row">
        <div class="detalle_raya">
            
        </div>
    </div>
    <div class="detalle_row">
        <div class="detalle_descripcion">
            <asp:Label ID="LDescripcion" runat="server">Aqui iria la descripcion del producto, pero siempre ira completa, no truncada como en otros casos, o sea, en otras paginas, comprenden?</asp:Label>
        </div>
    </div>
    <div class="detalle_row">
        <div class="detalle_raya">
            
        </div>
    </div>
    <div class="detalle_row">
        <span class="detalle_existencia">
            Existencia: 
        </span>
        <asp:Label ID="LExistencia" runat="server">5</asp:Label>
    </div>
    <div class="detalle_row">
        <asp:ImageButton ID="IBAdd2Cart" runat="server" ImageUrl="~/App_Themes/Store/Img/023.gif" />
    </div>
</div>
</asp:Content>




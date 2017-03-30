<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Oferta.ascx.cs" Inherits="User_Controls_Oferta" %>
<div class="container_oferta">
    <div class="foto_oferta">
        <asp:Image ID="img_producto" runat="server" />
    </div>
    <div class="nombre_oferta">
        <asp:Label ID="LNombre_producto" runat="server" Text="Nombre del producto"></asp:Label>
    </div>
    <div class="raya">
        
    </div>
    <div class="descripcion_oferta">
        <asp:Label ID="LDescripcion" runat="server" Text="Descripcion de los productos en tres lineas como máximo"></asp:Label>
    </div>
    <div class="precio_oferta">
        <span class="span_precio">
            <asp:Label ID="LPrecio1" runat="server" Text="$134."></asp:Label>
            <span style="position:relative; top:-7px; left:-3px">
                <asp:Label ID="LPrecio2" Font-Size="10pt" runat="server" Text="50"></asp:Label>
            </span>
        </span>
    </div>
</div>
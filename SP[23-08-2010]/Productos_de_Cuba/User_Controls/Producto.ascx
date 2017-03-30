<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Producto.ascx.cs" Inherits="User_Controls_Producto" %>

<div class="container">
    <div class="row_container">
        <div class="foto">
            <asp:ImageButton runat="server" id="IBProduct" OnClick="Image_onClic" />
        </div>
        <div class="left">
            <div class="nombre_producto">
                <asp:LinkButton runat="server" ID="LBNombre" OnClick="nombre_onClick">Nombre</asp:LinkButton>
            </div>
            <div class="marca_producto">
                <asp:Label runat="server" ID="LMarca">Marca</asp:Label>
            </div>
            <div class="raya_producto">
            
            </div>
            <div class="descripcion_producto">
                <asp:Label runat="server" ID="LDescripcion">Descripcion del producto en tres líneas como máximo</asp:Label>
            </div>
            <div class="raya_producto"></div>
            <div class="precio_producto">
                <span>
                    <asp:Label ID="LPrecio1" runat="server" Text="$134."></asp:Label>
                    <span style="position:relative; top:-3px; left:-3px">
                        <asp:Label ID="LPrecio2" Font-Size="6pt" runat="server" Text="50"></asp:Label>
                    </span>
                </span>
            </div>
            
        </div>
    </div>
    <div class="row_container2">        
        <div class="cantidad_prod">        
            <asp:Label runat="server" ID="LDispo">Disponible</asp:Label>            
        </div>
    
        <div class="add2kart">
            <asp:ImageButton runat="server" ID="IBAdd2Kart" ImageUrl="~/App_Themes/Store/Img/025.gif" OnClick="add_onClick"></asp:ImageButton>
        </div>  
    </div>  
</div>

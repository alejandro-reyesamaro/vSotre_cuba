<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductItemList.ascx.cs" Inherits="User_Controls_ProductItemList" %>
<style type="text/css">
.listitem_container
{
	padding-left: 10px;
	width: 215px;
}
.li_marca
{
    font-family: Verdana;
    font-size: 8pt;
    font-weight: bold;	
}
.li_existencia
{
    font-family: Verdana;
    font-size: 8pt;
}
.li_precio
{
	color: #9ebf2f;
	font-family: Verdana;
    font-size: 12pt;
    font-weight: 900;
}
.li_descripcion
{
    font-family: Verdana;
    font-size: 7pt;
    color: #707070;
    font-weight:normal;
}
.il_row
{	
	padding: 0 0 6px 0;	
}
.il_rowD
{	
	padding-top: 6px;
}
.il_row a
{	
	font-size: 7pt;
}
.il_row a:hover
{ 
	color: Black;
    font-size: 7pt;
}
.celda_izquierda
{
	padding-right: 5px;	
}
.celda_derecha
{
	padding-right: 5px;	
}
</style>

<div class="listitem_container">
    <div class="il_row">
        <span class="celda_izquierda">
            <asp:LinkButton  runat="server" ID="LNombre" Font-Bold="true" 
            onclick="LNombre_Click"></asp:LinkButton>
        </span>
        <span class="celda_derecha">
            <asp:Label runat="server" ID="LMarca" CssClass="li_marca"></asp:Label>
        </span>
    </div>
    <div class="il_row">
        <span class="celda_izquierda">
            <asp:Label runat="server" ID="LPrecio" CssClass="li_precio"></asp:Label>
        </span>
        <span class="celda_derecha">
            <asp:Label runat="server" ID="LDispo" CssClass="li_existencia">Disponible </asp:Label>
        </span>
    </div>
    <div class="il_rowD">
        <span class="celda_izquierda">
            <asp:Label runat="server" ID="LDescripcion" CssClass="li_descripcion" ></asp:Label>
        </span>
    </div>
</div>
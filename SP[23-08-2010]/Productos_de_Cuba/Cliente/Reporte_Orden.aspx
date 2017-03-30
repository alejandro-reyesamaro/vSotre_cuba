<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Reporte_Orden.aspx.cs" Inherits="Cliente_Reporte_Orden" Title="Reporte de orden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../App_Themes/Store/FormStyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .list_cart_header_L
        {
	        background-color:#9ebf2f;
	        color: White;
	        font-family: Verdana;
	        font-size: 9pt;
	        font-weight:bold;
	        text-align: left;
        }
        .list_cart_header_R
        {
	        background-color:#9ebf2f;
	        color: White;
	        font-family: Verdana;
	        font-size: 9pt;
	        font-weight:bold;
	        text-align: right;
        }
        .list_cart_item
        {
	        color: #9ebf2f;
	        font-family: Verdana;
	        font-size: 10pt;
	        font-weight:bold;
        }
        .link_pequeno
        {
	        padding: 0 0 5px 12px;
	        font-size: 12pt;
	        font-family: Verdana;	    
        }
        .link_pequeno a
        {
	        font-size: 7pt;
        }
        .link_pequeno a:hover
        {
	        font-size: 7pt;
	        color:Black;
        }
        .cart_list_action
        {
    	    padding: 15px 25px 0 12px;	   
    	    width:auto; 
    	    height: 40px;
        }
        .cart_salvar
        {
	        float: left;
	        width: auto;
        }
        .cart_comprar
        {
	        float: right;
	        font-family: Verdana;
	        font-size: 10pt;
	        font-weight: bold;
	        width: auto;
        }
        .row p
        {
	        line-height: 15px;
        }
        .or_title
        {	        
	        font-weight:bold;
        }
        #or_comentario
        {
            padding-top: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container_form">
    <div class="row">
        <p><span class="or_title">Orden No. </span><asp:Label ID="LNoOrden" runat="server"></asp:Label> </p>
        <p><span class="or_title">Estado: </span><asp:Label ID="LEstado" runat="server"></asp:Label> </p>
        <p><span class="or_title">Proveedor: </span><asp:Label ID="LProveedor" runat="server"></asp:Label> </p>
        <p><span class="or_title">Distribuidor: </span><asp:Label ID="LDistribuidor" runat="server"></asp:Label> </p>
        <p><span class="or_title">Entrega: </span><asp:Label ID="LEntrega" runat="server"></asp:Label> </p>
        <p><span class="or_title">Fecha: </span><asp:Label ID="LFecha" runat="server"></asp:Label> </p>
        <p><span class="or_title">Destinatario: </span><asp:Label ID="LDestinatario" runat="server"></asp:Label> </p>
        <p><span class="or_title">Dirección: </span><asp:Label ID="LDireccion" runat="server"></asp:Label> </p>
        <p><span class="or_title">Teléfono: </span><asp:Label ID="LTelefono" runat="server"></asp:Label> </p>
    </div>
    <div class="row">
        <div id="li_grid_container" style="font-family: Verdana; padding-left: 12px;">
            <asp:GridView ID="GVProductos" runat="server" AutoGenerateColumns="False"
                    BorderWidth="0px" GridLines="None" PageSize="80" Width="550px" ShowHeader="True" 
                    OnRowDataBound="GridView_RowDataBound" ondatabound="GVProductos_DataBound">
                <Columns>              
                    <asp:TemplateField>
                        <HeaderStyle CssClass="list_cart_header_L" />
                        <ItemStyle Width="10px" />
                        <ItemTemplate>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Nombre">
                        <HeaderStyle CssClass="list_cart_header_L" />
                        <ItemStyle Width="150px" Font-Size="8pt" />
                        <ItemTemplate>
                            <asp:Label ID="LNombre" runat="server" >Producto</asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Marca">
                        <HeaderStyle CssClass="list_cart_header_L" />
                        <ItemStyle Width="150px" />
                        <ItemStyle Font-Names="Verdana" Font-Size="10pt" Font-Bold="true" />
                        <ItemTemplate>
                            <asp:Label ID="LMarca" runat="server">Marca</asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Precio">
                        <HeaderStyle CssClass="list_cart_header_L" />
                        <ItemStyle Width="80px" CssClass="list_cart_item"/>
                        <ItemTemplate>
                            <asp:Label ID="LPrecio" runat="server" Text="Label">0.00</asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="No. Artículos">
                        <HeaderStyle CssClass="list_cart_header_L" />
                        <ItemStyle Width="80px" />
                        <ItemTemplate>
                            <asp:Label ID="LCantidad" runat="server" Text="Label">0</asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Subtotal">
                        <HeaderStyle CssClass="list_cart_header_R" HorizontalAlign="Right"/>
                        <ItemStyle Width="70px" HorizontalAlign="Right" CssClass="list_cart_item"/>
                        <ItemTemplate>
                            <asp:Label ID="LSubtotal" runat="server" Text="Label">0.00</asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                            
                </Columns>    
            </asp:GridView>
    </div>
        <div class="cart_list_action">
            <div class="cart_salvar">            
            </div>
            <div class="cart_comprar">
                <p><span class="or_title">Total: $</span><asp:Label ID="LabelTotal" runat="server"></asp:Label> </p>
            </div>               
        </div> 
    </div>
    <div id="or_comentario" class="row">
        <p><span class="or_title">Comentario: </span><asp:Label ID="LComentario" runat="server"></asp:Label> </p>
    </div>
</div>
</asp:Content>


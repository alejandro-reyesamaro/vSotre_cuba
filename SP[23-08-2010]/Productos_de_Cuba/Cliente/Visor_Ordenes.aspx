﻿<%@ Page Title="Ordenes" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Visor_Ordenes.aspx.cs" Inherits="Cliente_Visor_Ordenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../App_Themes/Store/ListProductStyleSheet.css" rel="stylesheet" type="text/css" /> 
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="title_categoria" style="padding: 43px 0 15px 12px">
        <img src="../App_Themes/MasterPage/Img/024.gif" alt="img"/>
        <span style="padding-left: 5px; font: bold 10pt Verdana">
            <asp:Label ID="label" runat="server">Listado de Órdenes</asp:Label>    
        </span>
    </div>
    <div class="link_pequeno">
        <asp:LinkButton ID="LBEliminar" runat="server" OnClick="Eliminar_onClick">Eliminar seleccionados</asp:LinkButton>
        <span style="padding-left: 10px">
        <asp:LinkButton ID="LBRestaurar" runat="server" OnClick="Restaurar_onClick">Restaurar valores anteriores</asp:LinkButton>
        </span>
        <span style="padding-left: 10px">
        <asp:LinkButton ID="LBFiltrar" runat="server" OnClick="Filtrar_onClick">Filtrar</asp:LinkButton>
        </span>
        <asp:Label ID="LAnuncio" runat="server">No hay órdenes que mostrar</asp:Label>
    </div>        
    <div id="li_grid_container" style="font-family: Verdana; padding-left: 12px;">
    <asp:GridView ID="GVOrdenes" runat="server" AutoGenerateColumns="False"
            BorderWidth="0px" GridLines="None" PageSize="80" Width="550px" ShowHeader="True" 
            OnRowDataBound="GridView_RowDataBound" ondatabound="GVOrdenes_DataBound">
        <Columns>              
            <asp:TemplateField>
                <HeaderStyle CssClass="list_cart_header_L" />
                <ItemStyle Width="10px" />
                <ItemTemplate>
                    <asp:CheckBox ID="ChBEliminar" runat="server"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="No. Orden">
                <HeaderStyle CssClass="list_cart_header_L" />
                <ItemStyle Width="150px" />
                <ItemTemplate>
                    <asp:LinkButton ID="LBNoOrden" runat="server" OnClick="OrdenesLink_Click">No. Orden</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Fecha">
                <HeaderStyle CssClass="list_cart_header_L" />
                <ItemStyle Width="150px" />
                <ItemStyle Font-Names="Verdana" Font-Size="10pt" Font-Bold="true" />
                <ItemTemplate>
                    <asp:Label ID="LFecha" runat="server">Fecha</asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Estado">
                <HeaderStyle CssClass="list_cart_header_L" />
                <ItemStyle Width="80px" CssClass="list_cart_item"/>
                <ItemTemplate>
                    <asp:DropDownList runat="server" ID="DDLEstado"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
                                                    
        </Columns>    
    </asp:GridView>
    
    
    
    <div class="cart_list_action">
        <div class="cart_salvar">
            <asp:ImageButton runat="server" ID="IBSalvar" 
                ImageUrl="~/App_Themes/Store/Img/032.gif" onclick="IBSalvar_Click" />
        </div>
        
        <div style="clear:both"></div>       
    </div>          

</asp:Content>


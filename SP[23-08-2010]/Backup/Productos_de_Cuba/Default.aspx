<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Productos de Cuba" %>

<%@ Register src="User_Controls/Producto.ascx" tagname="Producto" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="App_Themes/Store/StoreStyleSheet.css" rel="stylesheet" type="text/css" />    
</asp:Content>

<asp:Content ID="Principal" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="padding-top:17px">
    <div class="row_ofertas">
        <div class="oferta_left">            
            <uc1:Producto ID="Producto1" runat="server" Visible="false" />            
        </div>    
        <div class="oferta_rigth">            
            <uc1:Producto ID="Producto2" runat="server" Visible="false"/>            
        </div>  
    </div> 
    <div class="row_ofertas">
        <div class="oferta_left">            
            <uc1:Producto ID="Producto3" runat="server" Visible="false"/>            
        </div>    
        <div class="oferta_rigth">            
            <uc1:Producto ID="Producto4" runat="server" Visible="false"/>            
        </div>    
    </div>
    </div>
</asp:Content>


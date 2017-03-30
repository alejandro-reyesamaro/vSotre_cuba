<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Carrito.ascx.cs" Inherits="User_Controls_Carrito" %>
<div class="kart_container">
    <div class="kart_rowdata">
        <div class="kart_cellleft_data">
            Productos:
        </div>
        <div class="kart_cellrigth_data">
            <asp:TextBox ID="TBCantidad" runat="server" CssClass="kart_control" ReadOnly="true" ForeColor="Black">0</asp:TextBox>
        </div>
    </div>
    <div class="kart_rowdata">
        <div class="kart_cellleft_data">
            Monto total: $
        </div>
        <div class="kart_cellrigth_data">
            <asp:TextBox ID="TBMonto" runat="server" CssClass="kart_control" ReadOnly="true" ForeColor="Black">0.00</asp:TextBox>
        </div>
    </div>
    <div class="kart_rowaction">
        <div class="kart_cellleft_action">
            <asp:LinkButton ID="LBOrdenar" runat="server" onClick ="Shopping_onClick">Comprar</asp:LinkButton>
        </div>
        <div class="kart_cellrigth_action">
            <asp:ImageButton ID="IBSeeKart" runat="server" 
                ImageUrl="~/App_Themes/MasterPage/Img/015.gif" ToolTip="Ver carro de compras" 
                onclick="IBSeeKart_Click"/>
        </div>
    </div>
</div>
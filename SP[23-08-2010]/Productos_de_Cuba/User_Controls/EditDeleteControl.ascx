<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditDeleteControl.ascx.cs" Inherits="User_Controls_EditDeleteControl" %>
<style type="text/css">
.ed_row
{ 
	width: 104px;
}
.ed_row a
{ 
	width: auto;
	font-size: 7pt;
}
.ed_row a:hover
{ 
	color: Black;
	font-size: 7pt;
}
.celda_img_separador
{
	margin: 0 56px 0 46;	
}
.celda_editar
{
	float:left;
	width: 40px;
	margin:0;
	padding-left: 5px;
	padding-top: 7px;
}
.celda_eliminar
{
	float: right;
	width: 50px;
	margin:0;
	padding-left: 5px;
	padding-top: 7px;
}
.ed_clear
{
	height: 1px;
	clear:both;
}
</style>

<div class="ed_row">
    <div class="celda_editar">
        <asp:LinkButton  runat="server" ID="LBEditar" OnClick="Edit_Click">Editar</asp:LinkButton>
    </div>
    <div class="celda_eliminar">
        <asp:LinkButton runat="server" ID="LBEliminar" OnClick="LBEliminar_Click">Eliminar</asp:LinkButton> <%--  OnClick="Delete_Click" --%>
    </div>  
    <div class="celda_img_separador">
        <asp:Image  runat="server" ID="Img" ImageUrl="~/App_Themes/MasterPage/Img/028.GIF" ></asp:Image>
    </div>    
</div>
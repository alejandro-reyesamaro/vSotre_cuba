<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Categorias.aspx.cs" Inherits="Cliente_Administrador_Categorias" Title="Categorías" %>
<%@ Register src="../../User_Controls/EditDeleteControl.ascx" tagname="EditDeleteControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
#link_pequeno
{
    padding: 0 0 5px 12px;
    font-size: 12pt;
    font-family: Verdana;	    
}
#link_pequeno a
{
    font-size: 7pt;
}
#link_pequeno a:hover
{
    font-size: 7pt;
    color:Black;
}
.lc_header
{
    background-color:#9ebf2f;
    color: White;
    font-family: Verdana;
    font-size: 9pt;
    font-weight:bold;
    text-align: left;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div id="title_categoria" style="padding: 43px 0 15px 12px">
        <img src="../../App_Themes/MasterPage/Img/024.gif" alt="img"/>
        <span style="padding-left: 5px; font: bold 10pt Verdana">
            <asp:Label ID="LCategoria" runat="server"> Categorías existentes</asp:Label>    
        </span>
    </div>  
    <div id="link_pequeno">
        <asp:LinkButton ID="LBInsertar_Nuevo" runat="server" OnClick="Insertar_onClick">Insertar nueva categoría</asp:LinkButton>        
        <span style="padding-left: 5px">
            <asp:LinkButton ID="LBEliminar" runat="server" OnClick="eliminar_onclick">Eliminar seleccionados</asp:LinkButton>
        </span>
    </div>         
    <div id="li_grid_container" style="font-family: Verdana; padding-left: 12px;">
        <asp:GridView ID="GVCategorias" runat="server" AutoGenerateColumns="False"
            BorderWidth="0px" GridLines="None" DataSourceID="CategoriasObjectDataSource"
            PageSize="80" Width="450px" ShowHeader="True" 
            OnRowDataBound="GridView_RowDataBound" ondatabound="GVCategorias_DataBound" >
            
            <Columns>   
                <asp:TemplateField >  
                    <HeaderStyle CssClass="lc_header" />
                    <ItemStyle Width="37px" VerticalAlign="Top" Font-Size="7pt"/>
                    <ItemTemplate> 
                        <asp:CheckBox ID="ChBEliminar" runat="server"></asp:CheckBox>
                    </ItemTemplate>                        
                </asp:TemplateField>             
                <asp:TemplateField HeaderText="Nombre"> 
                    <HeaderStyle CssClass="lc_header" /> 
                    <ItemStyle Width="165px" VerticalAlign="Top" />               
                    <ItemTemplate>                        
                        <asp:LinkButton ID="LBNombre" runat="server" OnClick="categoria_onclick">Nombre de la categoria</asp:linkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Descripcion">  
                    <HeaderStyle CssClass="lc_header" />
                    <ItemStyle Font-Size="8pt" />
                    <ItemStyle Width="243px" VerticalAlign="Top" />               
                    <ItemTemplate>
                        <asp:Label ID="LDescripcion" runat="server" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>                            
        </asp:GridView>       
        <asp:ObjectDataSource ID="CategoriasObjectDataSource" runat="server" SelectMethod="ObjectDataSourceAll"
                           TypeName="BLLayer.Categoria" DeleteMethod="Delete">
            <DeleteParameters>
                <asp:ControlParameter ControlID="LBInsertar_Nuevo" PropertyName="CommandName" Name="id_cat" Type="Int32" />
            </DeleteParameters>
    </asp:ObjectDataSource>
    </div> 
</asp:Content>


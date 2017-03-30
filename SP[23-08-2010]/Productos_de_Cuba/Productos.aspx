<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Productos.aspx.cs" Inherits="Productos" Title="Productos" %>
<%@ Register src="User_Controls/ProductItemList.ascx" tagname="ProductItemList" tagprefix="uc1" %>
<%@ Register src="User_Controls/EditDeleteControl.ascx" tagname="EditDeleteControl" tagprefix="uc2" %>
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
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="title_categoria" style="padding: 43px 0 15px 12px">
        <img src="App_Themes/MasterPage/Img/024.gif" alt="img"/>
        <span style="padding-left: 5px; font: bold 10pt Verdana">
            <asp:Label ID="LCategoria" runat="server"> Productos existentes</asp:Label>    
        </span>
    </div>  
    <div id="link_pequeno">
        <asp:LinkButton ID="LBInsertar_Nuevo" runat="server" OnClick="Insertar_onClick">Insertar nuevo producto</asp:LinkButton>        
    </div>         
    <div id="li_grid_container" style="font-family: Verdana; padding-left: 12px;">
        <asp:GridView ID="GVCategorias" runat="server" AutoGenerateColumns="False"
            BorderWidth="0px" GridLines="None" DataSourceID="ProductosCategoriasObjectDataSource"
            PageSize="80" Width="550px" ShowHeader="False" 
            OnRowDataBound="GridView_RowDataBound" ondatabound="GVCategorias_DataBound" >
            <RowStyle CssClass="row_list_separator" />
            <Columns>
                <asp:TemplateField>
                    <ItemStyle Width="93px" />                
                    <ItemTemplate>
                        <asp:ImageButton ID="IFoto" runat="server" OnClick="ProductoImage_Click" ImageUrl="~/App_Themes/Store/Img/022.gif" Width="93px" Height="107px"></asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >  
                    <ItemStyle Width="215px" VerticalAlign="Top" />               
                    <ItemTemplate>                        
                        <uc1:ProductItemList ID="Producto_LI" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >  
                    <ItemStyle Width="100px" VerticalAlign="Top" />               
                    <ItemTemplate>
                        <asp:ImageButton ID="IBAnnadir" runat="server" OnClick="Annadir_Click" ImageUrl="~/App_Themes/Store/Img/023.gif"></asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >  
                    <ItemStyle Width="137px" VerticalAlign="Top" />
                    <ItemTemplate> 
                        <uc2:EditDeleteControl ID="ED_Control" runat="server" OnEliminar_onClick="Eliminar_onClick" />
                    </ItemTemplate>                        
                </asp:TemplateField>
            </Columns>                            
        </asp:GridView>       
        <asp:ObjectDataSource ID="ProductosCategoriasObjectDataSource" runat="server" SelectMethod="ObjectDataSourceProductos"
                           TypeName="BLLayer.Productos_X_Categoria" DeleteMethod="Delete">
            <DeleteParameters>
                <asp:ControlParameter ControlID="LBInsertar_Nuevo" PropertyName="CommandName" Name="id_producto" Type="Int32" />
            </DeleteParameters>
    </asp:ObjectDataSource>
    </div> 
</asp:Content>


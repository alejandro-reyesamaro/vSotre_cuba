using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLayer;
using System.Data;

public partial class Productos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.LBInsertar_Nuevo.Visible = (Session["id_role"] != null && (int)Session["id_role"] == 1);
        if (Request.QueryString["mode"] != null && Request.QueryString["mode"] == "search")
        {
            this.ProductosCategoriasObjectDataSource.SelectMethod = "Buscar";
            this.ProductosCategoriasObjectDataSource.TypeName = "BLLayer.Productos_X_Categoria";
            Parameter p = new QueryStringParameter("p", TypeCode.String, "query");
            this.ProductosCategoriasObjectDataSource.SelectParameters.Add(p);
        }
    }
    
    protected void ProductoImage_Click(object sender, ImageClickEventArgs e)
    {
        string id = ((ImageButton)sender).CommandName;
        Response.Redirect("Detalle_Producto.aspx?id=" + id);
    }
    protected void Annadir_Click(object sender, ImageClickEventArgs e)
    {
        MyShoppingCart sc = (MyShoppingCart)Session["shopping_cart"];
        ImageButton addb = (ImageButton)sender;
        int id_producto = int.Parse(addb.CommandName);
        Producto p = new Producto();
        p.LoadByPrimaryKey(id_producto);
        sc.Adiciona_prod(id_producto, p.Precio);
        Response.Redirect("ShoppingCart.aspx?ReturnUrl=Productos.aspx");
    }

    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dataRow = (DataRowView)e.Row.DataItem;
            ImageButton foto = (ImageButton)e.Row.FindControl("IFoto");
            ImageButton addb = (ImageButton)e.Row.FindControl("IBAnnadir");
            if (dataRow["foto"].ToString() != "")
            {
                foto.ImageUrl = "Handlers/ImageHandler.ashx?id=" + dataRow["Id_producto"].ToString();
                foto.Width = 93;
                foto.Height = 107;
            }
            // Almacenando id y precio del producto
            addb.CommandName = dataRow["Id_producto"].ToString();
            addb.Enabled = (int)dataRow["Existencia"] > 0;
            foto.CommandName = dataRow["Id_producto"].ToString();
            // ************************************
            User_Controls_ProductItemList c = (User_Controls_ProductItemList)e.Row.FindControl("Producto_LI");
            User_Controls_EditDeleteControl ed_uc = (User_Controls_EditDeleteControl)e.Row.FindControl("ED_Control");
            c.SetIDProducto((int)dataRow["Id_producto"]);
            c.Nombre_producto = dataRow["Nombre_producto"].ToString();
            c.Marca_producto = dataRow["Marca"].ToString();
            c.Precio_producto = dataRow["Precio"].ToString();
            c.Dispobible = (int)dataRow["Existencia"] > 0;
            c.Descripcion_producto = "[" + dataRow["Nombre_categoria"].ToString() + "]";
            ed_uc.ID_Item = (int)dataRow["Id_producto"];  
            ed_uc.Eliminar_onClick += new User_Controls_EditDeleteControl.LinkClick_Delegate(Eliminar_onClick);
        }
    }
    protected void GVCategorias_DataBound(object sender, EventArgs e)
    {
        this.GVCategorias.Columns[3].Visible = (Session["id_usuario"] != null);
    }
    protected void Insertar_onClick(object sender, EventArgs e)
    {
        Response.Redirect("Cliente/Administrador/Formulario_Producto.aspx");
    }

    protected void Eliminar_onClick(object sender, EventArgs e)
    {
        this.LBInsertar_Nuevo.CommandName = ((LinkButton)sender).CommandName;
        this.ProductosCategoriasObjectDataSource.Delete();
    }
}

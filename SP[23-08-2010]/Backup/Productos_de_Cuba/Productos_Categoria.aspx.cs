using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLayer;
using System.Data;

public partial class Productos_Categoria : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.LBInsertar_Nuevo.Visible = (Session["id_role"] != null && (int)Session["id_role"] == 1);
        if (this.Request.QueryString["id"] != null)
        {
            int id_cat = int.Parse(this.Request.QueryString["id"]);
            Categoria c = new Categoria();
            c.LoadByPrimaryKey(id_cat);
            this.LCategoria.Text = c.Nombre_categoria;
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
        Response.Redirect("ShoppingCart.aspx?ReturnUrl=Productos_Categoria.aspx?id="+p.Id_categoria.ToString());
    }
    
    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dataRow = (DataRowView)e.Row.DataItem;
            ImageButton addb = (ImageButton)e.Row.FindControl("IBAnnadir");
            ImageButton foto = (ImageButton)e.Row.FindControl("IFoto");
            if (dataRow["foto"].ToString() != "")
            {
                ((ImageButton)e.Row.FindControl("IFoto")).ImageUrl = "Handlers/ImageHandler.ashx?id=" + dataRow["Id_producto"].ToString();
                ((ImageButton)e.Row.FindControl("IFoto")).Width = 93;
                ((ImageButton)e.Row.FindControl("IFoto")).Height = 107;
            }
            addb.CommandName = dataRow["Id_producto"].ToString();
            addb.Enabled = (int)dataRow["Existencia"] > 0;
            foto.CommandName = dataRow["Id_producto"].ToString();
            User_Controls_ProductItemList c = (User_Controls_ProductItemList)e.Row.FindControl("Producto_LI");
            User_Controls_EditDeleteControl ed_uc = (User_Controls_EditDeleteControl)e.Row.FindControl("ED_Control");
            //Control c_ = LoadControl("~/User_Controls/ProductItemList.ascx");
            //Control ed_uc_ = LoadControl("~/User_Controls/EditDeleteControl.ascx");
            //c = (User_Controls_ProductItemList)c_;
            //ed_uc = (User_Controls_EditDeleteControl)ed_uc_;
            //Control c = LoadControl("~/User_Controls/ProductItemList.ascx");
            //Control ed = LoadControl("~/User_Controls/EditDeleteControl.ascx");
            c.SetIDProducto((int)dataRow["Id_producto"]);
            c.Nombre_producto = dataRow["Nombre_producto"].ToString();
            c.Marca_producto = dataRow["Marca"].ToString();
            c.Precio_producto = dataRow["Precio"].ToString();
            c.Dispobible = (int)dataRow["Existencia"] > 0;
            c.Descripcion_producto = dataRow["Descripcion"].ToString();
            //((IControl_EditDelete)ed).ID_Item = (int)dataRow["Id_producto"];
            ed_uc.ID_Item = (int)dataRow["Id_producto"];            
            //e.Row.Cells[1].Controls.Add(c);
            //e.Row.Cells[3].Controls.Add(ed);
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

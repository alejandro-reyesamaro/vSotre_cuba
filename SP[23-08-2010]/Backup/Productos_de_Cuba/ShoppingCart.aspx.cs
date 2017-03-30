using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLayer;
using System.Data;

public partial class ShoppingCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["error_message"]!="")
            this.LError.Text=Request.QueryString["error_message"];
        MyShoppingCart sc = (MyShoppingCart)Session["shopping_cart"];
        bool m = (sc != null && sc.Total_productos > 0);
        this.LBEliminar.Visible = m;
        this.LBSeguir.Visible = m;
        this.LAnuncio.Visible = !m;
        this.IBComprar.Visible = m;
        this.IBSalvar.Visible = m;
        if (!IsPostBack)
            if (m)
            {
                GVProductos.DataSource = sc.DefaultView;
                GVProductos.DataBind();
                this.LabelTotal.Text = "Total a pagar: $ " + UsefullProc.FormatoPrecio(sc.Precio_total);
            }              
    }

    protected void ProductoLink_Click(object sender, EventArgs e)
    {
        string id = ((LinkButton)sender).CommandName;
        Response.Redirect("Detalle_Producto.aspx?id=" + id);
    }
    protected void Seguir_onClick(object sender, EventArgs e)
    {
        string url = Request.QueryString["ReturnUrl"];
        if(url != null)
        Response.Redirect(url);
    }
    
    protected void ProductoImage_Click(object sender, ImageClickEventArgs e)
    { }

    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dataRow = (DataRowView)e.Row.DataItem;
            LinkButton lb = (LinkButton)e.Row.FindControl("LBNombre");            
            lb.Text = dataRow["Nombre_producto"].ToString();
            lb.CommandName = dataRow["Id_producto"].ToString();
            lb.CommandArgument = dataRow["Existencia"].ToString();
            ((Label)e.Row.FindControl("LMarca")).Text = dataRow["Marca"].ToString();
            ((Label)e.Row.FindControl("LPrecio")).Text = UsefullProc.FormatoPrecio((decimal)dataRow["Precio"]);
            ((TextBox)e.Row.FindControl("TBCantidad")).Text = dataRow["Cantidad_comprada"].ToString();            
            ((Label)e.Row.FindControl("LSubtotal")).Text = UsefullProc.FormatoPrecio((decimal)dataRow["Monto_por_producto"]);
        }
    }
    protected void GVProductos_DataBound(object sender, EventArgs e)
    {

    }
    protected void Eiminar_onClick(object sender, EventArgs e)
    {
        int id_producto;
        decimal precio;
        CheckBox chb;
        MyShoppingCart shc = (MyShoppingCart)Session["shopping_cart"];
        DataView dv = (DataView)GVProductos.DataSource;
        for (int i = 0; i < GVProductos.Rows.Count; i++)
        {
            chb = (CheckBox)GVProductos.Rows[i].FindControl("ChBEliminar");
            if (chb.Checked)
            {
                id_producto = int.Parse(((LinkButton)GVProductos.Rows[i].FindControl("LBNombre")).CommandName);
                precio = decimal.Parse(((Label)GVProductos.Rows[i].FindControl("LPrecio")).Text);
                shc.Elimina_prod(id_producto, precio);
            }            
        }
        this.LabelTotal.Text = "Total a pagar: $ " + UsefullProc.FormatoPrecio(shc.Precio_total);
        Response.Redirect("ShoppingCart.aspx");
    }

    protected void IBComprar_Click(object sender, ImageClickEventArgs e)
    {
        string s = GuardarCarro();
        if (s == "")
            Response.Redirect("Cliente/Orden.aspx");
        else
            Response.Redirect("ShoppingCart.aspx?error_message=" + s);
    }
    public string GuardarCarro() 
    {
        int id_producto;
        int existencia;
        int cantidad_comprada;
        decimal precio;
        MyShoppingCart shc = (MyShoppingCart)Session["shopping_cart"];
        LinkButton lb;
        for (int i = 0; i < GVProductos.Rows.Count; i++)
        {
            lb = (LinkButton)GVProductos.Rows[i].FindControl("LBNombre");
            id_producto = int.Parse(lb.CommandName);
            existencia = int.Parse(lb.CommandArgument);
            try
            {
                cantidad_comprada = int.Parse(((TextBox)GVProductos.Rows[i].FindControl("TBCantidad")).Text);
            }
            catch (Exception)
            {
                return "Debe cersiorarse de que la cantidad del producto"+lb.Text+" introducida tenga un formato numérico";
            }
            if (existencia < cantidad_comprada)//Se controla que no se pidan mas productos que su existencia en el almacen
            {
                return "La cantidad de " + lb.Text + " comprada es mayor que la existencia del producto en el almacén";                
            }
            precio = decimal.Parse(((Label)GVProductos.Rows[i].FindControl("LPrecio")).Text);            
            shc.Modifica_cant(id_producto, cantidad_comprada, precio);            
            ((Label)GVProductos.Rows[i].FindControl("LSubtotal")).Text = UsefullProc.FormatoPrecio(cantidad_comprada * precio);           
           
        }
        
        this.LabelTotal.Text = "Total a pagar: $ " + UsefullProc.FormatoPrecio(shc.Precio_total);
        this.LError.Text = "";
        return "";
        
    }

    protected void IBSalvar_Click(object sender, ImageClickEventArgs e)
    {
        string s = GuardarCarro();
        if (s!="") Response.Redirect("ShoppingCart.aspx?error_message="+s);
    }
}

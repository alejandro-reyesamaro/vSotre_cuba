using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLLayer;

public partial class User_Controls_Producto : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void CargarProducto(Producto p)
    { 
        if(p.Foto == null)
            this.IBProduct.ImageUrl = "~/App_Themes/Store/Img/022.jpg";
        else
            this.IBProduct.ImageUrl = "~/Handlers/ImageHandler.ashx?id=" + p.Id_producto.ToString();
        this.IBProduct.Width = 112;
        this.IBProduct.Height = 128;
        // almacenando el id y el precio
        this.IBProduct.CommandName = p.Id_producto.ToString();
        this.LBNombre.CommandName = p.Id_producto.ToString();
        this.IBAdd2Kart.CommandName = p.Precio.ToString();
        this.IBAdd2Kart.Enabled = p.Existencia > 0;
        // *****************************

        this.LBNombre.Text = p.Nombre_producto;
        string d = p.Descripcion;
        if (d.Length > 80) d = d.Substring(0, 80) + "...";
        this.LDescripcion.Text = d;
        this.LMarca.Text = p.Marca;
        // <Precio>
        string precio1 = "$";
        precio1 += Math.Truncate(p.Precio).ToString() + ".";
        decimal cent = p.Precio - Math.Truncate(p.Precio);
        cent = cent * 100;
        string precio2 = Math.Truncate(cent).ToString();
        if (precio2 == "0") precio2 = "00";
        this.LPrecio1.Text = precio1;
        this.LPrecio2.Text = precio2;
        // </Precio>
        this.LDispo.Text = (p.Existencia > 0)? "Disponible" : "No disponible";
    }

    #region Delegados
    public delegate void onLoad_Delegate(object sender, EventArgs e);
    public event onLoad_Delegate OnLoad_Producto;
    protected void Producto_OnLoad(object sender, EventArgs e)
    {
        OnLoad_Producto(sender, e);
    }
    #endregion

    protected void Image_onClic(object sender, ImageClickEventArgs e)
    {
        redirect();
    }
    protected void nombre_onClick(object sender, EventArgs e)
    {
        redirect();
    }

    private void redirect()
    {
        string id = this.LBNombre.CommandName;
        Response.Redirect("Detalle_Producto.aspx?id=" + id);
    }
    protected void add_onClick(object sender, ImageClickEventArgs e)
    {
        MyShoppingCart sc = (MyShoppingCart)Session["shopping_cart"];
        int id_producto = int.Parse(this.IBProduct.CommandName);
        Producto p = new Producto();
        p.LoadByPrimaryKey(id_producto);        
        sc.Adiciona_prod(id_producto, p.Precio);
        Response.Redirect("ShoppingCart.aspx?ReturnUrl=Default.aspx");
    }
}

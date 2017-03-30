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

public partial class User_Controls_ProductItemList : System.Web.UI.UserControl, IControl_ProductItemList
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void SetIDProducto(int id_producto)
    {
        this.LNombre.CommandName = id_producto.ToString();
    }
    public string Nombre_producto 
    {
        get {return this.LNombre.Text;}
        set {this.LNombre.Text = value;}
    }
    public string Marca_producto
    {
        get{return this.LMarca.Text;}
        set{this.LMarca.Text = value;}
    }
    public string Precio_producto
    {
        get{return this.LPrecio.Text;}
        set
        {
            string p = value;
            decimal precio = decimal.Parse(p);
            string precio1 = "$ ";
            precio1 += Math.Truncate(precio).ToString() + ".";
            decimal cent = precio - Math.Truncate(precio);
            cent = cent * 100;
            string precio2 = Math.Truncate(cent).ToString();
            if (precio2 == "0") precio2 = "00";
            p = precio1 + precio2; 
            this.LPrecio.Text = p;
        }
    }
    public bool Dispobible
    {
        get
        {
            return this.LDispo.Text == "Disponible";
        }
        set
        {
            this.LDispo.Text = (value)? "Disponible" : "No disponible";
        }
    }
    public string Descripcion_producto
    {
        get{return this.LDescripcion.Text;}
        set
        {
            string d = value;
            if (d.Length > 90) d = d.Substring(0, 90) + "...";
            this.LDescripcion.Text = d;
        }
    }
    protected void LNombre_Click(object sender, EventArgs e)
    {
        string id = this.LNombre.CommandName;
        Response.Redirect("Detalle_Producto.aspx?id=" + id);
    }
}

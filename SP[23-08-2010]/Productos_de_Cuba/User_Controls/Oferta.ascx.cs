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

public partial class User_Controls_Oferta : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cargarOfertaDelDia();
    }

    public void cargarOfertaDelDia()
    {
        Producto p = new Producto();
        p.OrdenadosPorVentas();
        this.img_producto.ImageUrl = "~/Handlers/ImageHandler.ashx?id=-1";
        this.img_producto.Width = 158;
        this.img_producto.Height = 114;
        this.LNombre_producto.Text = p.Nombre_producto;
        string d = p.Descripcion;
        if (d.Length > 80) d = d.Substring(0, 80) + "...";
        this.LDescripcion.Text = d;
        string precio1 = "$";
        precio1 += Math.Truncate(p.Precio).ToString() + ".";
        decimal cent = p.Precio - Math.Truncate(p.Precio);
        cent = cent * 100;
        string precio2 = Math.Truncate(cent).ToString();
        if (precio2 == "0") precio2 = "00";
        this.LPrecio1.Text = precio1;
        this.LPrecio2.Text = precio2;
    }
}

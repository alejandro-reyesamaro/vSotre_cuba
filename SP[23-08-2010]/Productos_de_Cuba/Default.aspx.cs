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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CargarPortada();
    }

    private void CargarPortada()
    {
        BLLayer.Producto p = new BLLayer.Producto();
        p.Portada();
        if (p.RowCount > 1)
        {
            this.Producto1.CargarProducto(p);
            this.Producto1.Visible = true;
        }
        if (p.MoveNext())
        {
            this.Producto2.CargarProducto(p);
            this.Producto2.Visible = true;
        }
        if (p.MoveNext())
        {
            this.Producto3.CargarProducto(p);
            this.Producto3.Visible = true;
        }
        if (p.MoveNext())
        {
            this.Producto4.CargarProducto(p);
            this.Producto4.Visible = true;
        }
    }
}

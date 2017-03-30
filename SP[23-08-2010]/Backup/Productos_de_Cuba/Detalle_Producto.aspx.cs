using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Detalle_Producto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            int id_prod = int.Parse(Request.QueryString["id"]);
            CargarProducto(id_prod);
        }
    }

    private void CargarProducto(int id_prod)
    {
        BLLayer.Producto p = new BLLayer.Producto();
        p.LoadByPrimaryKey(id_prod);
        if (p.RowCount > 0)
        {
            this.LBNombre.Text = p.Nombre_producto;
            this.LMarca.Text = p.Marca;
            this.LPrecio.Text = "$ " + UsefullProc.FormatoPrecio(p.Precio);
            this.LExistencia.Text = p.Existencia.ToString();
            this.LDescripcion.Text = p.Descripcion;
            this.IFoto2.ImageUrl = "~/Handlers/ImageHandler.ashx?id=" + id_prod.ToString();
        }
    }
}

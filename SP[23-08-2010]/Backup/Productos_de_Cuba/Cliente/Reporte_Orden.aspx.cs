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

public partial class Cliente_Reporte_Orden : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            Orden o = new Orden();
            Orden_Productos_Carro opc = new Orden_Productos_Carro();
            int id_orden = int.Parse(Request.QueryString["id"]);
            opc.LoadByOrderId(id_orden);
            this.LabelTotal.Text = "0";
            this.LEstado.Text = opc.Nombre_estado;
            this.LDestinatario.Text = opc.Destinatario;
            this.LDistribuidor.Text = opc.Nombre_distribuidor;
            this.LProveedor.Text = opc.Nombre_proveedor;
            this.LDireccion.Text = opc.Direccion_entrega;
            this.LTelefono.Text = opc.Telefono;
            this.LEntrega.Text = opc.Nombre_envio;
            this.LFecha.Text = opc.Fecha.ToString();
            this.LNoOrden.Text = opc.No_orden + "";
            this.LComentario.Text = opc.Comentario;
            
            GVProductos.DataSource = opc.ObjectDataSourceProductos(id_orden);
            GVProductos.DataBind();
        }
    }
    protected void ProductoLink_Click(object sender, EventArgs e)
    {

    }
    protected void ProductoImage_Click(object sender, ImageClickEventArgs e)
    { }
    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dataRow = (DataRowView)e.Row.DataItem;
            Label lb = (Label)e.Row.FindControl("LNombre");
            lb.Text = dataRow["Nombre_producto"].ToString();            
            ((Label)e.Row.FindControl("LMarca")).Text = dataRow["Marca"].ToString();
            ((Label)e.Row.FindControl("LPrecio")).Text = UsefullProc.FormatoPrecio((decimal)dataRow["Precio"]);
            ((Label)e.Row.FindControl("LCantidad")).Text = dataRow["Cantidad"].ToString();
            ((Label)e.Row.FindControl("LSubtotal")).Text = UsefullProc.FormatoPrecio(((decimal)dataRow["Precio"])*((int)dataRow["Cantidad"]));
            Label l = (Label)e.Row.FindControl("L");
            decimal total = decimal.Parse(this.LabelTotal.Text);
            total += ((decimal)dataRow["Precio"]) * ((int)dataRow["Cantidad"]);
            this.LabelTotal.Text = UsefullProc.FormatoPrecio(total);
            

        }
    }
    protected void GVProductos_DataBound(object sender, EventArgs e)
    {

    }
}

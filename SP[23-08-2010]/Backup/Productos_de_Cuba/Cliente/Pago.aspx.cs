using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLayer;
using EMailTaskProvider;

public partial class Cliente_Pago : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void LBPagar_Click(object sender, EventArgs e)
    {        
        MyShoppingCart shc = (MyShoppingCart)Session["shopping_cart"];
        if (shc.Total_productos > 0)
        {
            //Aqui se efectua el pago con las credenciales de PayPal

            int id_usuario = 4;
            if (Session["id_usuario"] != null)
                id_usuario = (int)Session["id_usuario"];
            int id_tipo_entrega = int.Parse(Request.QueryString["id_entrega"]);
            string direccion = Request.QueryString["direccion"];
            string destinatario = Request.QueryString["destinatario"];
            string comentario = Request.QueryString["comentario"];
            string telefono = Request.QueryString["telefono"];
            string email = Request.QueryString["email"];
            decimal importe_total = 0;
            int no_orden = 0;

            Orden o = new Orden();
            Producto p = new Producto();
            Producto_Orden po = new Producto_Orden();
            if (shc.IsValidCart())
            {
                int id_orden = o.Insert(id_usuario, id_tipo_entrega, direccion, comentario, telefono, email, destinatario);
                no_orden = o.No_orden;
                foreach (MyCartItem item in shc.Items)
                {
                    p.ActualizaVenta(item.id_producto, item.cantidad);
                    p.RestaCantidad(item.id_producto, item.cantidad);
                    po.Insert(id_orden, item.id_producto, item.cantidad);
                    importe_total += item.cantidad * p.Precio;
                }
                shc.Reset();
                GeneracionDeCorreos(no_orden, "Por procesar", destinatario, importe_total, email);
                Response.Redirect("Reporte_Orden.aspx?id=" + id_orden.ToString());                                                                   
            }
            else
                Response.Redirect("../Error_Page.aspx?error_message=Durante el proceso de selección de productos alguno de los productos incluidos en su compra se agotó. Por favor, vaya a su carro de compras y verifique la existencia en el almacén de los productos seleccionados");                                                   
        }
    }

    private void GeneracionDeCorreos(int no_orden, string estado, string destinatario, decimal monto_total, string email)
    {
        string rp = "Productos_de_Cuba/App_Data/config.xml";
        EMailTaskProvider.EMialClient ec = new EMialClient(rp);        
        string subject = "Notificación de envío de factura de compra.";
        string body = " Notificación de envío de factura de compra. \n Estado: " + estado;
        body += "\n Destinatario: " + destinatario;
        body += "\n Monto total: $ " + monto_total.ToString();
        body += "\n\n Gracias por su preferencia.";

        ec.Body = body;
        ec.Subject = subject;
        ec.To.Add(email);
        ec.Name = "Productos de Cuba";
        //string msg = ec.Send();
    }
}

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

public partial class User_Controls_Carrito : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.TBMonto.Text = ((MyShoppingCart)Session["shopping_cart"]).Precio_total + "";
        this.TBCantidad.Text = ((MyShoppingCart)Session["shopping_cart"]).Total_productos + "";
    }
    protected void IBSeeKart_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/ShoppingCart.aspx");
    }
    protected void Shopping_onClick(object sender, EventArgs e)
    {
        Response.Redirect("~/Cliente/Orden.aspx");
    }
}

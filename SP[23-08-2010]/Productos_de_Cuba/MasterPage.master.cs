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

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MostrarMenu();
        MostrarInOut();
        if (Session["shopping_cart"] == null)
        {
            MyShoppingCart sc = new MyShoppingCart();
            Session["shopping_cart"] = sc;
        }
    }

    private void MostrarInOut()
    {
        this.LBLogin.Text = (Session["id_usuario"] != null) ? "Salir" : "Entrar";
    }

    private void MostrarMenu()
    {
        bool isuser = Session["id_usuario"] != null;
        bool isadmin = isuser && (int)Session["id_role"] == 1;
        this.LBOrdenes.Visible = isuser;
        this.LBCrearadmin.Visible = isadmin;
        this.LBCategorias.Visible = isadmin;
    }

    #region DataGrid
    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dataRow = (DataRowView)e.Row.DataItem;            
            LinkButton lb = (LinkButton)e.Row.FindControl("LBCategoria");
            lb.Text = dataRow["Nombre_categoria"].ToString();
            lb.CommandName = dataRow["Id_categoria"].ToString();
        }
    }
    protected void GridView_DataBound(object sender, EventArgs e)
    {
    }
    #endregion

    protected void CategoriasLink_Click(object sender, EventArgs e)
    {
        int id = int.Parse(((LinkButton)sender).CommandName);
        string nombre = ((LinkButton)sender).Text;
        click(id, nombre);
    }
    protected void CategoriasImage_Click(object sender, ImageClickEventArgs e)
    {
        int id = int.Parse(((ImageButton)sender).CommandName);
        string nombre = ((ImageButton)sender).AlternateText;
        click(id, nombre);
    }

    private void click(int id, string nombre)
    {
        Response.Redirect("~/Productos_Categoria.aspx?id=" + id.ToString());
    }

    protected void menu_OnClick(object sender,  EventArgs e)
    {
        string p = ((LinkButton)sender).CommandName;
        string direction = "~/" + p + ".aspx";
        Response.Redirect(direction);
       
    }    
    protected void register_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("~/Registrarse.aspx");
    }
    protected void buscar_OnClick(object sender, ImageClickEventArgs e)
    {
        //Producto p = new Producto();
        //p.Buscar(this.TBBuscar.Text);
        string s = this.TBBuscar.Text;
        Response.Redirect("~/Productos.aspx?mode=search&query=" + s);
    }
    protected void login_OnClick(object sender, EventArgs e)
    {
        string url = "~/Entrar.aspx";
        if (Session["id_usuario"] != null)
        {
            Session.Clear();
            FormsAuthentication.SignOut();            
        }
        else
            url+= "?ReturnUrl=" + Request.AppRelativeCurrentExecutionFilePath;
        Response.Redirect(url);
    }
}

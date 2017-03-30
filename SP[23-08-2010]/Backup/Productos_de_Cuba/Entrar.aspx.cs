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

public partial class Entrar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.PC_Login.Focus();
    }

    protected void LoginButton_Click(object sender, ImageClickEventArgs e)
    {
        Usuario objUsuario = new Usuario();
        objUsuario.LoadByLogin(this.PC_Login.UserName);
        if (objUsuario.RowCount > 0)
        {
            Session["name"] = objUsuario.Login;
            Session["usuario"] = objUsuario.Login;
            Session["id_usuario"] = objUsuario.Id_usuario;
            Session["id_role"] = objUsuario.Id_role;
        }
        else
            Session["id_usuario"] = -1;
    }
    protected void Login_LoggedIn(object sender, EventArgs e)
    {
        string user = (Session["name"] == null) ? "" : (string)Session["name"];
        //if (user != "")
        //    Response.Redirect("Default.aspx");
    }
    protected void register_OnClick(object sender, EventArgs e)
    {

    }
    protected void inicio_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}

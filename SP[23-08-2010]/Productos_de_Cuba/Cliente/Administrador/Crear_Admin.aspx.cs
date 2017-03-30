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

public partial class Cliente_Administrador_Crear_Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.LInfo.Visible = false;
    }
    protected void IBAceptar_Click(object sender, ImageClickEventArgs e)
    {
        string nombre = this.TBNombre.Text;
        string login = this.TBLogin.Text;
        string password = this.TBPassword.Text;
        Usuario u = new Usuario();
        if (!u.ExistsUser(login))
        {
            u.InsertAdmin(nombre, login, password);
            this.LInfo.Visible = true;
            this.LInfo.Text = "El usuario \"" + nombre + "\" ha sido insertado con éxito";
            this.TBNombre.Text = "";
            this.TBPassword.Text = "";
            this.TBLogin.Text = "";
        }
        else
        {
            this.LInfo.Visible = true;
            this.LInfo.Text = "Ya existe un usuario con el login \"" + login + " \", por favor inténtelo de nuevo";
            this.TBNombre.Text = "";
            this.TBPassword.Text = "";
            this.TBLogin.Text = "";
            this.LInfo.Visible = true; 
        }

        
        //p.Insert(codigo, nombre, descripcion, id_cat, precio, cant, this.Browse.PostedFile.FileName);
    }
}

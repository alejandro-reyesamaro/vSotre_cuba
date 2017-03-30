using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using BLLayer;

public partial class Cliente_Administrador_Formulario_Categoria : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.QueryString["mode"] != null && Request.QueryString["mode"] == "edit")
            {
                int id_cat = int.Parse(Request.QueryString["id"]);
                CargarCategoria(id_cat);
            }
            else this.IBAceptar.ImageUrl = "~/App_Themes/Store/Img/031.gif";
        }
    }

    private void CargarCategoria(int id_cat)
    {
        Categoria c = new Categoria();
        c.LoadByPrimaryKey(id_cat);
        this.TBNombre.Text = c.Nombre_categoria;
        this.TBDescripcion.Text = c.Descripcion;
        this.IBAceptar.ImageUrl = "~/App_Themes/Store/Img/032.gif";
    }

    protected void IBAceptar_Click(object sender, ImageClickEventArgs e)
    {

        string nombre = this.TBNombre.Text;
        string descripcion = this.TBDescripcion.Text;
        string foto_path = "";
        // Foto
        //string foto_path = this.Browse.PostedFile.FileName;
        //if (foto_path.Length > 4)
        //{
        //    int pos = foto_path.Length - 4;
        //    string extension = this.Browse.PostedFile.FileName.Substring(pos, 4);
        //    if (extension.ToLower() != ".jpg" && extension.ToLower() != ".gif")
        //    {
        //        foto_path = "";
        //    }
        //}
        //else
        //    foto_path = "";


        Categoria c = new Categoria();
        if (Request.QueryString["mode"] == "edit")
        {
            int id_cat = int.Parse(Request.QueryString["id"]);
            c.Update(id_cat, nombre, descripcion, foto_path);

        }
        else
        {
            c.Insert(nombre, descripcion, foto_path);
        }
        return;
    }

        
}

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

public partial class Cliente_Administrador_Formulario_Producto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Cargar_Combos();

            if (Request.QueryString["mode"] != null && Request.QueryString["mode"] == "edit")
            {
                int id_prod = int.Parse(Request.QueryString["id"]);
                Cargar_Producto(id_prod);
            }
            else this.IBAceptar.ImageUrl = "~/App_Themes/Store/Img/031.gif";
        }
    }

    private void Cargar_Producto(int id_prod)
    {
        Producto p = new Producto();
        p.LoadByPrimaryKey(id_prod);
        this.TBNombre.Text = p.Nombre_producto;
        this.TBPrecio.Text = UsefullProc.FormatoPrecio(p.Precio);
        this.TBMarca.Text = p.Marca;
        this.TBCantidad.Text = p.Existencia + "";
        this.TBDescripcion.Text = p.Descripcion;
        this.TBCodigo.Text = p.Codigo;
        int id_cat = p.Id_categoria;
        this.DDLCategoria.SelectedValue = id_cat.ToString();
        if (p.Foto != null)
            this.IFoto.ImageUrl = "~/Handlers/ImageHandler.ashx?id=" + id_prod;        
        this.IBAceptar.ImageUrl = "~/App_Themes/Store/Img/032.gif";
    }

    private void Cargar_Combos()
    {
        Categoria c = new Categoria();
        c.LoadAll();
        this.DDLCategoria.DataSource = c.DefaultView;
        this.DDLCategoria.DataTextField = Categoria.ColumnNames.Nombre_categoria;
        this.DDLCategoria.DataValueField = Categoria.ColumnNames.Id_categoria;
        this.DDLCategoria.DataBind();
    }

    protected void IBAceptar_Click(object sender, ImageClickEventArgs e)
    {
        string codigo = this.TBCodigo.Text;
        string nombre = this.TBNombre.Text;
        string descripcion = this.TBDescripcion.Text;
        int id_cat = -1;
        int.TryParse(this.DDLCategoria.SelectedValue, out id_cat);
        decimal precio = 0;
        decimal.TryParse(this.TBPrecio.Text, out precio);
        int cant = -1;
        int.TryParse(this.TBCantidad.Text, out cant);

        // Foto        
        string foto_path = this.Browse.Value;
        if (foto_path.Length > 4)
        {
            int pos = foto_path.Length - 4;
            string extension = this.Browse.PostedFile.FileName.Substring(pos, 4);
            if (extension.ToLower() != ".jpg" && extension.ToLower() != ".gif")
            {
                foto_path = "";
            }
        }
        else
            foto_path = "";             
               
        Producto p = new Producto();        
        if (Request.QueryString["mode"] == "edit")
        {
            int id_prod = int.Parse(Request.QueryString["id"]);
            p.Update(id_prod, codigo, nombre, descripcion, id_cat, precio, cant, foto_path);               
          
        }
        else
        {
            p.Insert(codigo, nombre, descripcion, id_cat, precio, cant, foto_path);
            Limpiar_Campos();
        }
        return;
    }

    private void Limpiar_Campos()
    {
        this.TBNombre.Text = "";
        this.TBPrecio.Text = "";
        this.TBMarca.Text = "";
        this.TBCantidad.Text = "";
        this.TBDescripcion.Text = "";
        this.TBCodigo.Text = "";
    }
}


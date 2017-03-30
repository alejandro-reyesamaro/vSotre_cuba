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

public partial class Cliente_Orden : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            Cargar_Combos();
            this.LUsuario.Text = (string)Session["name"];
        }
    }
    private void Cargar_Combos()
    {
        Envio e = new Envio();
        e.LoadAll();
        this.DDLEntrega.DataSource = e.DefaultView;
        this.DDLEntrega.DataTextField = Envio.ColumnNames.Nombre_envio;
        this.DDLEntrega.DataValueField = Envio.ColumnNames.Id_envio;
        this.DDLEntrega.DataBind();
    }
    protected void IBAceptar_Click(object sender, ImageClickEventArgs e)
    {
        string destinatario = TBDestinatario.Text;
        string direccion = TBDireccion.Text + ", " + TBMunicipio.Text + ", " + DDLProvincia.SelectedItem;
        string telefono = TBTelefono.Text;
        string email = TBEmail.Text;
        int id_entrega = -1;
        int.TryParse(this.DDLEntrega.SelectedValue, out id_entrega);
        string comentario = TBComentario.Text;

        // Aqui debe ir la validacion si no se incluyen los validators.

        Response.Redirect("Pago.aspx?destinatario=" + destinatario + "&direccion=" + direccion + "&telefono="+telefono
                                  + "&email=" + email + "&id_entrega=" + id_entrega + "&comentario="+comentario);

    }
}

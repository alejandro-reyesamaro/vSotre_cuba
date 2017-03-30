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

public partial class Cliente_Administrador_Categorias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dataRow = (DataRowView)e.Row.DataItem;
            LinkButton nombre = (LinkButton)e.Row.FindControl("LBNombre");
            //CheckBox eliminar = (CheckBox)e.Row.FindControl("ChBEliminar");
            Label descripcion = (Label)e.Row.FindControl("LDescripcion");
            // Almacenando id 
            nombre.CommandName = dataRow["Id_categoria"].ToString();
            // ************************************
            
            nombre.Text = dataRow["nombre_categoria"].ToString();
            descripcion.Text = dataRow["descripcion"].ToString();
        }
    }
    protected void GVCategorias_DataBound(object sender, EventArgs e)
    {
        
    }
    protected void Insertar_onClick(object sender, EventArgs e)
    {
        Response.Redirect("Formulario_Categoria.aspx");
    }
    protected void categoria_onclick(object sender, EventArgs e)
    {
        string id = ((LinkButton)sender).CommandName;
        Response.Redirect("Formulario_Categoria.aspx?mode=edit&id="+id);
    }
    protected void eliminar_onclick(object sender, EventArgs e)
    {
        int id_categoria;
        CheckBox chb;
        
        DataView dv = (DataView)GVCategorias.DataSource;
        for (int i = 0; i < GVCategorias.Rows.Count; i++)
        {
            chb = (CheckBox)GVCategorias.Rows[i].FindControl("ChBEliminar");
            if (chb.Checked)
            {
                Categoria c = new Categoria();
                id_categoria = int.Parse(((LinkButton)GVCategorias.Rows[i].FindControl("LBNombre")).CommandName);
                c.Delete(id_categoria);
            }
        }
        Response.Redirect("Categorias.aspx");
    }
}

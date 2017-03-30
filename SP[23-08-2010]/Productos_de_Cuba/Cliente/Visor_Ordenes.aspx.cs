using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLLayer;
public partial class Cliente_Visor_Ordenes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Orden o = new Orden();                        
            bool is_admin = (Session["id_role"] != null && (int)Session["id_role"] == 1);
            int id_usuario;
            if (is_admin)
            {
                if (Request.QueryString["mode"] != null && Request.QueryString["mode"] == "filtrar")
                {
                    int no_orden = int.Parse(Request.QueryString["no_orden"]);
                    int code = int.Parse(Request.QueryString["code"]);
                    string login = Request.QueryString["login"];
                    int id_estado = int.Parse(Request.QueryString["id_estado"]);
                    int da = int.Parse(Request.QueryString["dantes"]);
                    int ma = int.Parse(Request.QueryString["mantes"]);
                    int aa = int.Parse(Request.QueryString["aantes"]);
                    int dd = int.Parse(Request.QueryString["ddespues"]);
                    int md = int.Parse(Request.QueryString["mdespues"]);
                    int ad = int.Parse(Request.QueryString["adespues"]);
                    o.Filtrar(code, no_orden, login, id_estado, da, ma, aa, dd, md, ad);                    
                }
                else
                {
                    string s = Request.QueryString["id_usuario"];
                    if (s != null)
                    {
                        id_usuario = int.Parse(s);
                        o.LoadByUsuario(id_usuario);
                    }
                    else
                    {
                        o.LoadAll();
                    }
                }
            }
            else
            {
                if (Session["id_usuario"] == null)
                    Response.Redirect("../Error_Page.aspx?error_message=Acceso Denegado");
                id_usuario = (int)Session["id_usuario"];
                o.LoadByUsuario(id_usuario);
            }
            GVOrdenes.DataSource = o.DefaultView;
            GVOrdenes.DataBind();
                     
            this.LBEliminar.Visible = is_admin && (o.RowCount > 0);
            this.LBFiltrar.Visible = is_admin && (o.RowCount > 0);
            this.LBRestaurar.Visible = is_admin && (o.RowCount > 0);
            this.LAnuncio.Visible = o.RowCount == 0;
            this.IBSalvar.Visible = is_admin && (o.RowCount > 0);

        }
    }

    protected void OrdenesLink_Click(object sender, EventArgs e)
    {
        string id = ((LinkButton)sender).CommandName;
        Response.Redirect("Reporte_Orden.aspx?id=" + id);
    }
    protected void Restaurar_onClick(object sender, EventArgs e)
    {
        Response.Redirect("Visor_Ordenes.aspx");
    }
    protected void Filtrar_onClick(object sender, EventArgs e)
    {
        Response.Redirect("Administrador/FiltrarOrden.aspx");
    }

    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Orden o = new Orden();
            
            DataRowView dataRow = (DataRowView)e.Row.DataItem;
            LinkButton lb = (LinkButton)e.Row.FindControl("LBNoOrden");
            lb.Text = dataRow["No_orden"].ToString();
            lb.CommandName = dataRow["Id_orden"].ToString();            
            ((Label)e.Row.FindControl("LFecha")).Text = dataRow["Fecha"].ToString();
            int id_estado = (int)dataRow["Id_estado"];
            DropDownList ddl = (DropDownList)e.Row.FindControl("DDLEstado");
            CheckBox chb = (CheckBox)e.Row.FindControl("ChBEliminar");
            bool is_admin = (Session["id_role"] != null && (int)Session["id_role"] == 1);//Aqui se coge si es admin o no
            Estado_orden eo = new Estado_orden();
            if (is_admin)
            {                
                eo.LoadAll();
                chb.Visible = true;
            }
            else 
            {
                eo.LoadByPrimaryKey(id_estado);
                chb.Visible = false; 
            }
            ddl.DataSource = eo.DefaultView;
            ddl.DataTextField = Estado_orden.ColumnNames.Nombre_estado;
            ddl.DataValueField = Estado_orden.ColumnNames.Id_estado;
            ddl.DataBind();
            ddl.SelectedValue = id_estado.ToString();
        }
    }
    protected void GVOrdenes_DataBound(object sender, EventArgs e)
    {

    }
    protected void Eliminar_onClick(object sender, EventArgs e)
    {        
        int id_orden;
        CheckBox chb;
        string query="";
        Orden o = new Orden();
        for (int i = 0; i < GVOrdenes.Rows.Count; i++)
        {
            chb = (CheckBox)GVOrdenes.Rows[i].FindControl("ChBEliminar");
            if (chb.Checked)
            {
                id_orden = int.Parse(((LinkButton)GVOrdenes.Rows[i].FindControl("LBNoOrden")).CommandName);
                o.Delete(id_orden);
            }
        }
        if(Request.QueryString["id_usuario"]!=null)
            query = "?id_usuario=" + Request.QueryString["id_usuario"];
        Response.Redirect("Visor_Ordenes.aspx"+query);        
    }     

    protected void IBSalvar_Click(object sender, ImageClickEventArgs e)
    {
        int id_orden, id_estado;
        DropDownList ddl;
        string query = "";
        Orden o = new Orden();
        for (int i = 0; i < GVOrdenes.Rows.Count; i++)
        {
            ddl = (DropDownList)GVOrdenes.Rows[i].FindControl("DDLEstado");
            id_orden = int.Parse(((LinkButton)GVOrdenes.Rows[i].FindControl("LBNoOrden")).CommandName);
            id_estado = int.Parse(ddl.SelectedValue);
            o.ModificaEstado(id_orden, id_estado);
        }
        
        query = "?" + Request.QueryString.ToString();
        Response.Redirect("Visor_Ordenes.aspx" + query);                   
    }   

}

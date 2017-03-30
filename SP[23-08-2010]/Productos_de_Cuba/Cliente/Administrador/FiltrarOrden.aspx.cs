using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLayer;

public partial class Cliente_Administrador_FiltrarOrden : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            //En esta seccion se llena el ddl de estados
            Estado_orden eo = new Estado_orden();
            eo.LoadAll();
            DDLEstado.DataSource = eo.DefaultView;
            DDLEstado.DataTextField = Estado_orden.ColumnNames.Nombre_estado;
            DDLEstado.DataValueField = Estado_orden.ColumnNames.Id_estado;
            DDLEstado.DataBind();
            DDLEstado.Items.Insert(0, "Todas las órdenes");
            int dty = DateTime.Now.Year;

            //En esta seccion se llenan los ddl del anno de la fecha
            for (int i = 2010; i < DateTime.Now.Year+1; i++)
			{
                DDLFechaDAnno.Items.Add("" + i);
                DDLFechaAAnno.Items.Add("" + i);
			}           
            
        }
    }
    protected void Filtrar_onClick(object sender, EventArgs e) 
    {
        int code = 0;
        string id_estado="-1";
        string login="";
        string no_orden="-1";
        string da="1", ma="1", aa="2000", dd="1", md="1", ad="2000";

        if (DDLEstado.SelectedItem.Value != "Todas las órdenes")
        {
            id_estado = DDLEstado.SelectedItem.Value;
            code += 4;
        }        
        if (TBNoOrden.Text != "")
        {
            no_orden = TBNoOrden.Text;
            code += 16;
        }
        if (ChBFechaAntes.Checked) 
        {
            code += 2;
            da = DDLFechaADia.Text;
            ma = DDLFechaAMes.Text;
            aa = DDLFechaAAnno.Text;
        }
        if (ChBFechaDespues.Checked)
        {
            code += 1;
            dd = DDLFechaDDia.Text;
            md = DDLFechaDMes.Text;
            ad = DDLFechaDAnno.Text;
        }
        if (TBLogin.Text != "")
        {
            login = TBLogin.Text;
            code += 8;
        }
        Response.Redirect("../Visor_Ordenes.aspx?mode=filtrar&no_orden=" + no_orden + "&login=" + login + "&id_estado=" + id_estado + "&dantes=" + da + "&mantes=" + ma + "&aantes=" + aa + "&ddespues=" + dd + "&mdespues=" + md + "&adespues=" + ad + "&code=" + code);
    }
    protected void ChBFechaDespues_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBFechaDespues.Checked)
        {
            DDLFechaDAnno.Enabled = true;
            DDLFechaDDia.Enabled = true;
            DDLFechaDMes.Enabled = true;
        }
        else
        {
            DDLFechaDAnno.Enabled = false;
            DDLFechaDDia.Enabled = false;
            DDLFechaDMes.Enabled = false;           
        }
    }
    protected void ChbFechaAntes_CheckedChanged(object sender, EventArgs e)
    {
        if (ChBFechaAntes.Checked)
        {
            DDLFechaAAnno.Enabled = true;
            DDLFechaADia.Enabled = true;
            DDLFechaAMes.Enabled = true;
        }
        else
        {
            DDLFechaAAnno.Enabled = false;
            DDLFechaADia.Enabled = false;
            DDLFechaAMes.Enabled = false;
        }
    }
}

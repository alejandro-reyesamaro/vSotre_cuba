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



public partial class User_Controls_EditDeleteControl : System.Web.UI.UserControl, IControl_EditDelete
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Eventos y Delegados
    public delegate void LinkClick_Delegate(object sender, EventArgs e);
    public event LinkClick_Delegate Eliminar_onClick;
    protected void LBEliminar_Click(object sender, EventArgs e)
    {
        Eliminar_onClick(sender, e);
    }
    #endregion

    #region IControl_EditDelete Members

    public int ID_Item
    {
        get
        {
            return int.Parse(this.LBEditar.CommandName);
        }
        set
        {
            this.LBEditar.CommandName = value.ToString();
            this.LBEliminar.CommandName = value.ToString();
        }
    }

    #endregion

    protected void Delete_Click(object sender, EventArgs e)
    {
        int id_P = int.Parse(((LinkButton)sender).CommandName);
        Producto p = new Producto();
        p.Delete(id_P);
    }
    protected void Edit_Click(object sender, EventArgs e)
    {
        int id_P = int.Parse(((LinkButton)sender).CommandName);
        Response.Redirect("Cliente/Administrador/Formulario_Producto.aspx?mode=edit&id=" + id_P.ToString());
    }
       
}

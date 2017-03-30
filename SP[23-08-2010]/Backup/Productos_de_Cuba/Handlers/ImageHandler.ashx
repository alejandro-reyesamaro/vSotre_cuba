<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Web;
using BLLayer;

public class ImageHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        int id = -1;
        int.TryParse( context.Request.QueryString["id"], out id);
        Producto p = new Producto();
        if (id == -1 || id == 0)
            p.OrdenadosPorVentas();
        else
            p.LoadByPrimaryKey(id);
        if (p.Foto != null)
        {
            context.Response.ContentType = "application/image";
            context.Response.Buffer = true;
            context.Response.Charset = "";
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //context.Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["Name"].ToString());
            context.Response.BinaryWrite(p.Foto);
            context.Response.Flush();
            context.Response.End();
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
}
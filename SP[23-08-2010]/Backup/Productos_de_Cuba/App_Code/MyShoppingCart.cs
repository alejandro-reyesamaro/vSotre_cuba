using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLLayer;
using System.Data;

/// <summary>
/// Summary description for ShoppingCart
/// </summary>
public class MyShoppingCart
{
    public List<MyCartItem> items;
    public List<MyCartItem> Items
    {
        get { return this.items; }
    }
    private decimal precio_total;
    public decimal Precio_total
    {
        get { return this.precio_total; }
    }

    public int Total_productos
    {
        get { return this.items.Count; }
    }
    public MyShoppingCart()
    {
        Reset();
    }
    public MyShoppingCart(List<MyCartItem> cartItems, bool llena_campos)
    {
        this.items = cartItems;
        if (llena_campos)
            Llena_Campos();
    }
        public DataView ProductosCarrito()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id_producto", typeof(int));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Existencia", typeof(int));
            dt.Columns.Add("foto", typeof(byte[]));
            dt.Columns.Add("Nombre_producto", typeof(string));
            dt.Columns.Add("Marca", typeof(string));
            dt.Columns.Add("Id_categoria", typeof(int));
            dt.Columns.Add("Cantidad_comprada", typeof(int));
            dt.Columns.Add("Monto_por_producto", typeof(decimal));
            DataRow dr;
            Producto p = new Producto();
            for (int i = 0; i < items.Count; i++) 
            {
                p.LoadByPrimaryKey(items[i].id_producto);
                dr = dt.NewRow();
                dr["Id_producto"] = p.Id_producto;
                dr["Precio"] = p.Precio;
                dr["Existencia"] = p.Existencia;
                dr["foto"] = p.Foto;
                dr["Nombre_producto"] = p.Nombre_producto;
                dr["Marca"] = p.Marca;
                dr["Id_categoria"] = p.Id_categoria;
                dr["Cantidad_comprada"] = items[i].cantidad;
                dr["Monto_por_producto"] = items[i].cantidad * p.Precio;
                dt.Rows.Add(dr);
            }
            return new DataView(dt);       
        }
    public DataView DefaultView
    {
        get 
        {
            return ProductosCarrito();    
        }
    }
    public void Llena_Campos()
    {
        Producto p = new Producto();
        precio_total = 0;
        for (int i=0;i<items.Count;i++)
        {
            p.LoadByPrimaryKey(items[i].id_producto);
            precio_total += p.Precio * items[i].cantidad;
        }        
    }
    public void Adiciona_prod(int product_id, decimal precio)
    {
        if (!Contiene(product_id))
        {
            MyCartItem ic = new MyCartItem(product_id, 1);
            this.items.Add(ic);
            this.precio_total += precio;
        }
    }
    public bool Contiene(int product_id) 
    {
       foreach (MyCartItem ci in items)
        {
            if (ci.id_producto == product_id)
                return true;
        }
       return false;
    }
    public void Modifica_cant(int product_id, int cant, decimal precio) 
    {
        int index = ProductIndex(product_id);
        if (index > -1)
        {
            this.precio_total = this.precio_total - precio * (this.items[index].cantidad - cant) ;
            this.items[index].cantidad = cant;
        }
    }
    public void Elimina_prod(int product_id, decimal precio) 
    {
        int index = ProductIndex(product_id);
        if (index > -1)
        {
            this.precio_total -= this.items[index].cantidad * precio;
            this.items.RemoveAt(index);
        }
    }
    public int ProductIndex(int product_id)
    {
        for (int i = 0; i < this.Total_productos; i++) 
            if (items[i].id_producto == product_id)
                return i;
        return -1;
    }
    public void Reset() 
    {
        this.items = new List<MyCartItem>();
        this.precio_total = 0;
    }

    public bool IsValidCart()
    {
        Producto p = new Producto();
        foreach (MyCartItem cartitem in this.items)
        {
            p.LoadByPrimaryKey(cartitem.id_producto);
            if (p.Existencia < cartitem.cantidad)
                return false;
        }
        return true;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MyCartItem
/// </summary>
public class MyCartItem
{
    public int id_producto;
    public int cantidad;
    public MyCartItem(int id_producto, int cantidad)
    {
        this.id_producto = id_producto;
        this.cantidad = cantidad;
    }
}

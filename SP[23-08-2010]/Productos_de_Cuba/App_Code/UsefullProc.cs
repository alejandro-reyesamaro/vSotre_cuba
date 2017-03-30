using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UsefullProc
/// </summary>
public class UsefullProc
{
    public static string FormatoPrecio(string precio) 
    {
        int index = precio.LastIndexOf('.');
        if (index < 0||index+3>precio.Length)
            return precio;
        else
            return precio.Substring(0, index + 3);
    }
    public static string FormatoPrecio(decimal preciodec)
    {
        string precio = preciodec.ToString();
        int index = precio.LastIndexOf('.');
        if (index < 0 || index + 3 > precio.Length)
            return precio;
        else
            return precio.Substring(0, index + 3);
    }
}

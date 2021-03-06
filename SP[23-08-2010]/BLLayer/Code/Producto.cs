
// Generated by MyGeneration Version # (1.3.0.3)

using System;
using DALayer;
using System.IO;
using System.Data;
using MyGeneration.dOOdads;

namespace BLLayer
{
	public class Producto : _Producto
	{
		public Producto()
		{	 
            
		}               
     
        public void Insert(string codigo, string nombre, string descripcion, int id_categoria, decimal precio, int cantidad, string foto_path)
        {
            this.AddNew();
            this.Codigo = codigo; this.Nombre_producto = nombre;
            this.Descripcion = descripcion; this.Id_categoria = id_categoria;
            this.Precio = precio; this.Existencia = cantidad;
            this.Vitrina = false;
            try
            {
                if (foto_path != "")
                {
                    byte[] data = null;
                    FileInfo fInfo = new FileInfo(foto_path);
                    long numBytes = fInfo.Length;
                    FileStream fStream = new FileStream(foto_path, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);
                    data = br.ReadBytes((int)numBytes);
                    this.Foto = data;
                }
            }
            catch (Exception)
            { }
            this.Save();
        }
     
        public void Update(int id_prod, string codigo, string nombre, string descripcion, int id_categoria, decimal precio, int cantidad, string foto_path)
        {
            this.LoadByPrimaryKey(id_prod);
            this.Codigo = codigo; this.Nombre_producto = nombre;
            this.Descripcion = descripcion; this.Id_categoria = id_categoria;
            this.Precio = precio; this.Existencia = cantidad;
            try{
                if (foto_path != "")
                {
                    byte[] data = null;
                    FileInfo fInfo = new FileInfo(foto_path);
                    long numBytes = fInfo.Length;
                    FileStream fStream = new FileStream(foto_path, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);
                    data = br.ReadBytes((int)numBytes);
                    this.Foto = data;
                }
            }
            catch (Exception)
            { }
            this.Save();            
        }
        public bool Delete(int id_producto)
        {
            Producto_Orden po = new Producto_Orden();
            if(po.IsProductFree(id_producto))
            {
                this.LoadByPrimaryKey(id_producto);
                if (this.RowCount > 0)
                {
                    MarkAsDeleted();
                    Save();
                    return true;
                }
            }
            return false;
        }

        public void LoadByCode(string code)
        { 
            this.Where.WhereClauseReset();
            this.Where.Codigo.Value = code;
            this.Where.Codigo.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Equal;
            this.Query.Load();
            this.Rewind();
        }
        public void LoadByIdCat(int id_cat) 
        {
            this.Where.WhereClauseReset();
            this.Where.Id_categoria.Value = id_cat;
            this.Where.Id_categoria.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Equal;
            this.Query.Load();
            this.Rewind();
        }
        public bool IsCatFree(int id_cat) 
        {
            this.LoadByIdCat(id_cat);
            return (this.RowCount == 0);
        }
        public void RestaCantidad(int id_producto, int cantidad) 
        {
            this.LoadByPrimaryKey(id_producto);
            this.Existencia = this.Existencia - cantidad;
            this.Save();
        }
        public DataView ObjectDataSourceIDCategoria(int IDCategoria)
        {
            this.Where.WhereClauseReset();
            this.Where.Id_categoria.Value = IDCategoria;
            this.Where.Id_categoria.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Equal;
            //this.Query.AddResultColumn(Producto.ColumnNames.Codigo);
            //this.Query.AddResultColumn(Producto.ColumnNames.Marca);
            //this.Query.AddResultColumn(Producto.ColumnNames.Nombre_producto);
            //this.Query.AddResultColumn(Producto.ColumnNames.Precio);
            //this.Query.AddResultColumn(Producto.ColumnNames.Existencia);
            this.Query.Load();
            this.Rewind();
            return this.DefaultView;
        }
        public DataView ObjectDataSourceProductos()
        {
            this.LoadAllOrderCategoria();
            this.Rewind();
            return this.DefaultView;
        }
     
        private void LoadAllOrderCategoria()
        {
            this.Where.WhereClauseReset();
            this.Query.AddOrderBy(Producto.ColumnNames.Id_categoria, WhereParameter.Dir.ASC);
            this.Query.Load();
        }

        public void vitrina(int id_producto, bool estado)
        {
            this.LoadByPrimaryKey(id_producto);
            this.Vitrina = estado;            
            this.Save();
        }

        public void OrdenadosPorVentas()
        {
            //this.LoadByCode("8501110080439");
            this.Where.WhereClauseReset();
            this.Query.AddOrderBy(Producto.ColumnNames.Ventas, WhereParameter.Dir.DESC);
            this.Query.Load();
        }

        //ejemplos 8500002216840, 8500000159422, 8410220123601, 8500000076613

        public void Portada()//(int flag)
        {
            //switch (flag)
            //{
            //    case 1:
            //        this.LoadByCode("8500002216840");
            //        break;
            //    case 2:
            //        this.LoadByCode("8500000159422");
            //        break;
            //    case 3:
            //        this.LoadByCode("8410220123601");
            //        break;
            //    case 4:
            //        this.LoadByCode("8500000076613");
            //        break;
            //    default:
            //        LoadAll();
            //        break;
            //}
            //return this;
            this.OrdenadosPorVentas();
            MoveNext();
        }

        public void La_vitrina()
        {
            this.Where.WhereClauseReset();
            this.Where.Vitrina.Value = true;
            this.Where.Vitrina.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Equal;
            this.Query.Load();
            this.Rewind();
        }
        public void ActualizaVenta(int id_producto, int cantidad)
        {
            this.LoadByPrimaryKey(id_producto);
            this.Ventas += cantidad;
            this.Save();

        }
        
    }
}

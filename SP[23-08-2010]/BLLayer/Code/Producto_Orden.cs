
// Generated by MyGeneration Version # (1.3.0.3)

using System;
using DALayer;

namespace BLLayer
{
	public class Producto_Orden : _Producto_Orden
	{
		public Producto_Orden()
		{
		
		}
        public void Insert(int id_orden, int id_producto, int cantidad) 
        {
            Producto p = new Producto();//primero se disminuye la cantidad de ese prod en el almacen
            p.LoadByPrimaryKey(id_producto);
            this.AddNew();
            this.Id_orden = id_orden;
            this.Id_producto = id_producto;
            this.Cantidad = cantidad;
            this.Save();
        }
        public void LoadByOrder(int id_orden) 
        {
            this.Where.WhereClauseReset();
            this.Where.Id_orden.Value = id_orden;
            this.Where.Id_orden.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Equal;
            this.Query.Load();
            this.Rewind();
        }
        public void LoadByProduct(int id_product)
        {
            this.Where.WhereClauseReset();
            this.Where.Id_producto.Value = id_product;
            this.Where.Id_producto.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Equal;
            this.Query.Load();
            this.Rewind();
        }
        public bool IsProductFree(int id_product) 
        {
            LoadByProduct(id_product);
            return this.RowCount == 0;        
        }
        public void Delete(int id_orden) 
        {
            this.LoadByOrder(id_orden);
            do
            {
                this.MarkAsDeleted();
                this.Save();
            }
            while (this.MoveNext());
        }
	}
}

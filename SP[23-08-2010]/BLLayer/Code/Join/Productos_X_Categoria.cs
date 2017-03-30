using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using DALayer;
using MyGeneration.dOOdads;

namespace BLLayer
{
    public class Productos_X_Categoria : _Productos_X_Categoria
    {
        public DataView ObjectDataSourceProductos()
        {
            
            this.Where.WhereClauseReset();
            this.Query.AddOrderBy(_Productos_X_Categoria.ColumnNames.Nombre_categoria, WhereParameter.Dir.ASC);
            this.Query.Load();
            return this.DefaultView;
        }
        public void Delete(int id_producto)
        {
            Producto p = new Producto();
            p.Delete(id_producto);
        }
        public DataView Buscar(string p)
        {
            this.Where.WhereClauseReset();
            this.Where.Nombre_producto.Value = "%" + p + "%";
            this.Where.Nombre_producto.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like;
            this.Where.Descripcion.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.Or;
            this.Where.Descripcion.Value = "%" + p + "%";
            this.Where.Descripcion.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like;
            this.Where.Marca.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.Or;
            this.Where.Marca.Value = "%" + p + "%";
            this.Where.Marca.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like;
            this.Query.Load();
            this.Rewind();
            return this.DefaultView;
        }
    }
}

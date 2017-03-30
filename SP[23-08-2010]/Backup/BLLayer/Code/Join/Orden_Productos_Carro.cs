using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DALayer;
using MyGeneration.dOOdads;
using System.Data;

namespace BLLayer
{
    public class Orden_Productos_Carro : _Orden_Productos_Carro
    {
        public DataView ObjectDataSourceProductos(int id_orden)
        {
            LoadByOrderId(id_orden);
            return this.DefaultView;
        }
        public void LoadByOrderId(int id_orden)
        {
            this.Where.WhereClauseReset();
            this.Where.Id_orden.Value = id_orden;
            this.Where.Id_orden.Operator = WhereParameter.Operand.Equal;
            this.Query.AddOrderBy(_Orden_Productos_Carro.ColumnNames.Id_producto, WhereParameter.Dir.ASC);
            this.Query.Load();
        }
       
    }
}

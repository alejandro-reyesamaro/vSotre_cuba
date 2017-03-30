
// Generated by MyGeneration Version # (1.3.0.3)

using System;
using DALayer;
using System.Data;
using MyGeneration.dOOdads;
using System.IO;
namespace BLLayer
{
	public class Categoria : _Categoria
	{
		public Categoria()
		{
		
		}

        public void LoadByName(string name)
        {
            this.Where.WhereClauseReset();
            this.Where.Nombre_categoria.Value = name;
            this.Where.Nombre_categoria.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Equal;
            this.Query.Load();
            this.Rewind();
        }
        public void Insert(string nombre_cat, string descrip, string foto_path)
        {
            this.AddNew();
            this.Nombre_categoria = nombre_cat;
            this.Descripcion = descrip;
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
        public void Update(int id_cat, string nombre_cat, string descrip, string foto_path)
        {
            this.LoadByPrimaryKey(id_cat);
            this.Nombre_categoria = nombre_cat;
            this.Descripcion = descrip;
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
        public bool Delete(int id_cat) 
        {
            Producto p = new Producto();
            if (p.IsCatFree(id_cat))
            {
                this.LoadByPrimaryKey(id_cat);
                this.MarkAsDeleted();
                this.Save();
                return true;
            }
            return false;
        }

        public DataView ObjectDataSourceAll()
        {
            this.LoadAll();
            return this.DefaultView;
        }
	}
}


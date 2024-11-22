using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLProducto
    {
        DALProducto producto = new DALProducto();
        public DataTable GetCategorias()
        {
            DataTable dt = new DataTable();
            dt= producto.GetCateogiras();
            return dt;
        
        }

        public DataTable GetProdutos(int cod)
        {
            DataTable dt = new DataTable();
            dt = producto.GetProductos(cod);
            return dt;

        }


        public DataTable GetProdutosAll()
        {
            DataTable dt = new DataTable();
            dt = producto.GetProductosAll();
            return dt;

        }

    }
}

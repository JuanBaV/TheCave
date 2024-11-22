using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALProducto
    {
        SqlConnection Conection = new SqlConnection("Data Source=localhost;Initial Catalog=THECAVE;Integrated Security=True");

        public DataTable GetCateogiras()
        {
            Conection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Categorias", Conection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            Conection.Close();
            return dt;
        }

        public DataTable GetProductos(int cod)
        {
            Conection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Productos WHERE Categoria=@cod", Conection);
            cmd.Parameters.AddWithValue("@cod", cod);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            Conection.Close();
            return dt;
        }

        public DataTable GetProductosAll()
        {
            Conection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Productos", Conection);
            
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            Conection.Close();
            return dt;
        }



    }
}

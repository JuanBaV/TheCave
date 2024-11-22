using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DAL
{
    public class DALCambios
    {
        SqlConnection Conection = new SqlConnection("Data Source=localhost;Initial Catalog=THECAVE;Integrated Security=True");

        public DataTable GetCambios()
        {
            Conection.Open();
            DataTable Dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter("Select * from ProductosHistorico", Conection);
            Da.Fill(Dt);
            Conection.Close();
            return Dt;
        }


        public DataTable GetCambiosProducto(int cod)
        {
            Conection.Open();
            DataTable Dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from ProductosHistorico WHERE Cod_Producto=@cod", Conection);
            cmd.Parameters.AddWithValue("@cod", cod);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(Dt);
            Conection.Close();
            return Dt;
        }

        public DataTable GetCambiosFecha(DateTime fecha, DateTime fecha2)
        {
            Conection.Open();
            DataTable Dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from ProductosHistorico WHERE Fecha BETWEEN @fecha1 AND @fecha2", Conection);
            cmd.Parameters.AddWithValue("@fecha1", fecha);
            cmd.Parameters.AddWithValue("@fecha2", fecha2);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(Dt);
            Conection.Close();
            return Dt;
        }


        public void registrarCambio(int cod)
        {
            Conection.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from Productos WHERE Cod_Producto=@cod", Conection);
            cmd.Parameters.AddWithValue("@cod", cod);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            
            int stock = (int)dt.Rows[0]["Stock"];
            SqlCommand cmd1 = new SqlCommand("INSERT INTO ProductosHistorico (CoD_Producto, Fecha, Stock) VALUES (@cod, @fecha, @stock)", Conection);
            cmd1.Parameters.AddWithValue("@cod", cod);
            cmd1.Parameters.AddWithValue("@fecha", DateTime.Now);
            cmd1.Parameters.AddWithValue("@stock", stock);
            cmd1.ExecuteNonQuery();
            Conection.Close();
        }

        public void Restore(int cod, int stock)
        {

            Conection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Productos SET Stock=@stock WHERE Cod_Producto=@cod", Conection);
            cmd.Parameters.AddWithValue("@cod",cod);
            cmd.Parameters.AddWithValue("@stock",stock);
            cmd.ExecuteNonQuery();
            Conection.Close();
            

        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALAlquiler
    {

        SqlConnection Conection = new SqlConnection("Data Source=localhost;Initial Catalog=THECAVE;Integrated Security=True");


        public int storeAlquiler(int estacion, float precio, float tiempo, DateTime fecha)
        {
            Conection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO  Alquileres (Estacion, Precio, Tiempo, Fecha)VALUES(@estacion, @precio, @tiempo, @fecha)", Conection);
            cmd.Parameters.AddWithValue("@estacion", estacion);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.Parameters.AddWithValue("@tiempo", tiempo);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            int rowsAffected = cmd.ExecuteNonQuery();
            Conection.Close();
            return rowsAffected;
        }



        //public int storeAlquiler(int estacion, float precio, float tiempo, DateTime fecha)
        //{
        //    Conection.Open();
        //    SqlCommand cmd = new SqlCommand("INSERT INTO Alquileres (Estacion, Precio, Tiempo, Fecha) VALUES (@estacion, @precio, @tiempo. @fecha)")
        //}

        public DataTable getAlquileres()
        {
            Conection.Open();
            SqlCommand cmd = new SqlCommand("getAlquileres", Conection);
            cmd.CommandType= CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            Conection.Close();
            return dt;
        }

    }
}

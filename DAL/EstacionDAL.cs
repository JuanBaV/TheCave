using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EstacionDAL
    {
        SqlConnection Conection = new SqlConnection("Data Source=localhost;Initial Catalog=THECAVE;Integrated Security=True");
        public DataSet LeerEstaciones()
        {
            Conection.Open();
            DataSet Ds = new DataSet();
            SqlDataAdapter Da = new SqlDataAdapter("Select * from Estaciones", Conection);
            Da.Fill(Ds);
            Cerrar();
            return Ds;
        }

        public void Cerrar()
        {
            Conection.Close();
            Conection.Dispose();
            Conection = null;
            GC.Collect();
        }


        public int actualizarOcupacion(int ocupacion, int nro)
        {
            Conection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Estaciones SET Ocupacion=@ocupacion WHERE Nro=@Nro", Conection);
            cmd.Parameters.AddWithValue("@ocupacion", ocupacion);
            cmd.Parameters.AddWithValue("@Nro", nro);
            int rowsAffected = cmd.ExecuteNonQuery();
            Conection.Close();
            return rowsAffected;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALBitacora
    {

        SqlConnection Conection = new SqlConnection("Data Source=localhost;Initial Catalog=THECAVE;Integrated Security=True");


        public int storeBitacora(string usuario, string accion, DateTime hora, string modulo, int criticidad)
        {
            Conection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Bitacora (Usuario, Accion, Hora, Modulo, Criticidad) values (@usuario, @accion, @hora, @modulo, @criticidad)", Conection);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@accion", accion);
            cmd.Parameters.AddWithValue("@hora", hora);
            cmd.Parameters.AddWithValue("@modulo", modulo);
            cmd.Parameters.AddWithValue("@criticidad", criticidad);
            int rowsAffected = cmd.ExecuteNonQuery();
            Conection.Close();
            return rowsAffected;
        }

        public DataSet LeerBitacora()
        {
            Conection.Open();
            DataSet Ds = new DataSet();
            SqlDataAdapter Da = new SqlDataAdapter("Select * from Bitacora", Conection);
            Da.Fill(Ds);
            Conection.Close();
            return Ds;
        }

        public DataSet LeerBitacoraUser(string user)
        {
            Conection.Open();
            DataSet Ds = new DataSet();
            SqlCommand cmd = new SqlCommand("Select * from Bitacora Where Usuario=@user ", Conection);
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(Ds);
            Conection.Close();
            return Ds;
        }

        public DataSet LeerBitacoraAccion(string accion)
        {
            Conection.Open();
            DataSet Ds = new DataSet();
            SqlCommand cmd = new SqlCommand("Select * from Bitacora Where Accion=@accion", Conection);
            cmd.Parameters.AddWithValue("@accion", accion);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(Ds);
            Conection.Close();
            return Ds;
        }

        public DataSet LeerBitacoraFecha(DateTime fecha, DateTime fecha2)
        {
            Conection.Open();
            DataSet Ds = new DataSet();
            SqlCommand cmd = new SqlCommand("Select * from Bitacora WHERE Hora >= @fecha1 AND Hora <= @fecha2)", Conection);
            cmd.Parameters.AddWithValue("@fecha1", fecha);
            cmd.Parameters.AddWithValue("@fecha2", fecha2);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(Ds);
            Conection.Close();
            return Ds;
        }

        public DataSet LeerBitacoraModulo(string modulo)
        {
            Conection.Open();
            DataSet Ds = new DataSet();
            SqlCommand cmd = new SqlCommand("Select * from Bitacora Where Modulo=@modulo ", Conection);
            cmd.Parameters.AddWithValue("@modulo", modulo);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(Ds);
            Conection.Close();
            return Ds;
        }

        public DataSet LeerBitacoraCriticidad(int criticidad)
        {
            Conection.Open();
            DataSet Ds = new DataSet();
            SqlCommand cmd = new SqlCommand("Select * from Bitacora Where Criticidad=@criticidad ", Conection);
            cmd.Parameters.AddWithValue("@criticidad", criticidad);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(Ds);
            Conection.Close();
            return Ds;
        }
    }
}

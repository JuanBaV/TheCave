using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace DAL
{
    public class DALPErfil
    {
        SqlConnection Conection = new SqlConnection("Data Source=localhost;Initial Catalog=THECAVE;Integrated Security=True");

        public DataTable GetPermisos()
        {
            Conection.Open();
            SqlCommand cmd = new SqlCommand("Select * from Permiso", Conection);
            DataTable Dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter (cmd);
            Da.Fill(Dt);
            Conection.Close();
            return Dt;
        }

        public DataTable GetPerfiles()
        {
            Conection.Open();
            SqlCommand cmd = new SqlCommand("Select * from Perfiles", Conection);
            DataTable Dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(Dt);
            Conection.Close();
            return Dt;
        }

        public int addPerfil(string nombre, List<string> permisos)
        {
            Conection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Perfiles(Nombre) values(@Nombre)", Conection);
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            int rowsAffected = cmd.ExecuteNonQuery();
            int cod = GetSpecificProfile(nombre);
            for (int i = 0; i < permisos.Count; i++)
            {
                int codPermiso = GetSpecificPermit(permisos[i]);
                SqlCommand cmd2 = new SqlCommand("INSERT INTO PerfilPermiso(Cod_Perfil, Cod_Permiso) values(@Perfil, @Permiso)", Conection);
                cmd2.Parameters.AddWithValue("@Perfil", cod);
                cmd2.Parameters.AddWithValue("@Permiso", codPermiso);
                cmd2.ExecuteNonQuery();
                
            }
            Conection.Close();
            return rowsAffected;
        }

        public int GetSpecificProfile(string nombre)
        {
            
            SqlCommand cmd = new SqlCommand("Select Cod_Perfil from Perfiles where Nombre=@nombre", Conection);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            DataTable Dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter (cmd);
            Da.Fill(Dt);
            
            int a;
            a = (int)Dt.Rows[0]["Cod_Perfil"];
            return a;
        }

        public int GetSpecificPermit(string permiso)
        {
            
            SqlCommand cmd = new SqlCommand("Select Cod_Permiso from Permiso where Descripcion=@nombre", Conection);
            cmd.Parameters.AddWithValue("@nombre", permiso);
            DataTable Dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(Dt);
            
            int a;
            a = (int)Dt.Rows[0]["Cod_Permiso"];
            return a;
        }


        
    }
}

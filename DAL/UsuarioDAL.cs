using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class UsuarioDAL
    {
        SqlConnection Conection = new SqlConnection("Data Source=localhost;Initial Catalog=THECAVE;Integrated Security=True");

        public DataTable UserData(string username)
        {
            Conection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE Username=@username", Conection);
            cmd.Parameters.AddWithValue("@username", username);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt); 
            Conection.Close();
            return dt;
        }

        public int storeUser(string username, string password, string dni, string apellido, string nombre)
        {
            Conection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Usuarios(Username, Password, DNI, Apellido, Nombre) values(@Username, @Password, @dni, @apellido, @nombre)", Conection);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@DNI", dni);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            
            
            int rowsAffected= cmd.ExecuteNonQuery();
            Conection.Close();
            return rowsAffected;
        }

        public int UpdateUSer(string username, string password) {

            Conection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Usuarios SET Password=@Password WHERE Username=@Username", Conection);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            int rowsAffected = cmd.ExecuteNonQuery();
            Conection.Close();
            return rowsAffected;


        }


        public int updateProfile(string username, string profile)
        {
            Conection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Usuarios SET Cod_Perfil=@cod WHERE Username=@Username", Conection);
            cmd.Parameters.AddWithValue("@Username", username);
            DALPErfil perfil = new DALPErfil();
            int cod = perfil.GetSpecificProfile(profile);
            cmd.Parameters.AddWithValue("@cod", cod);
            int rowsAffected = cmd.ExecuteNonQuery();
            Conection.Close();
            return rowsAffected;
        }

        public int blockUser(string username)
        {

            Conection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Usuarios SET Block=@block WHERE Username=@username", Conection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@block", 1);
            int rowsAffected = cmd.ExecuteNonQuery();
            Conection.Close();
            return rowsAffected;

        }

      


        public DataSet LeerUsers()
        {
            Conection.Open();
            DataSet Ds = new DataSet();
            SqlDataAdapter Da = new SqlDataAdapter("Select * from Usuarios", Conection);
            Da.Fill(Ds);
            Conection.Close();
            return Ds;
        }

        public DataSet LeerUsersSinPerfil()
        {
            Conection.Open();
            DataSet Ds = new DataSet();
            SqlDataAdapter Da = new SqlDataAdapter("Select Username from Usuarios Where Cod_Perfil is null", Conection);
            Da.Fill(Ds);
            Conection.Close();
            return Ds;
        }

        public void CargarUsers(DataSet Ds)
        {
            Conection.Open();
            SqlDataAdapter Da = new SqlDataAdapter("Select * from Usuarios", Conection);
            SqlCommandBuilder Cb = new SqlCommandBuilder(Da);
            Da.UpdateCommand = Cb.GetUpdateCommand();
            Da.DeleteCommand = Cb.GetDeleteCommand();
            Da.InsertCommand = Cb.GetInsertCommand();
            Da.ContinueUpdateOnError = true;
            Da.Fill(Ds);
            Da.Update(Ds.Tables[0]);

        }



        public DataTable UserRole(int cod)
        {
            Conection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM PerfilPermiso WHERE Cod_Perfil=@cod and Cod_Permiso=1", Conection);
            cmd.Parameters.AddWithValue("@cod", cod);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            Conection.Close();
            return dt;
        }


        public int updateLanguage(string username, int language)
        {
            Conection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Usuarios SET Idioma=@idioma WHERE Username=@username", Conection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@idioma", language);
            int rowsAffected = cmd.ExecuteNonQuery();
            Conection.Close();
            return rowsAffected;
        }
        
        //public int updateActive(string username, int active)
        //{
        //    Conection.Open();
        //    SqlCommand cmd = new SqlCommand("UPDATE Usuarios SET Activo=@activo WHERE Username=@username", Conection);
        //    cmd.Parameters.AddWithValue("@username", username);
        //    cmd.Parameters.AddWithValue("@activo", active);
        //    int rowsAffected = cmd.ExecuteNonQuery();
        //    Conection.Close();
        //    return rowsAffected;
        //}


    }
}

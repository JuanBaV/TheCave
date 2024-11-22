using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using Security;

namespace BLL
{
    public class UsuarioBLL
    {
        //public string username
        //{ get; set; }
        //public string password { get; set; }

        public string hashedPass { get; set; }

        public string storedPass { get; set; }

        UsuarioDAL usuarioDAL = new UsuarioDAL();

        

        //public int CalcularDigitoVerificador(string contraseña)
        //{
        //    int suma = 0;

        //    foreach (char caracter in contraseña)
        //    {
        //        suma += (int)caracter;
        //    }

        //    int digitoVerificador = suma % 10;

        //    return digitoVerificador;
        //}


        public Boolean CheckUsername(string username)
        {
            DataTable dt = new DataTable();
            dt = usuarioDAL.UserData(username);
            if(dt.Rows.Count > 0) 
            {
                storedPass = dt.Rows[0]["Password"].ToString();
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Register(string username, string password, string dni, string apellido, string nombre)
        {
            if (CheckUsername(username))
            {
                System.Windows.Forms.MessageBox.Show("Username ocupado");
                return 0;
            }
            else
            {
                hashedPass=getPasswordHash(password);
                usuarioDAL.storeUser(username, hashedPass, dni, apellido, nombre);
                return 1;
            }



        }

        public int BlockUser(string username)
        {
            return usuarioDAL.blockUser(username);
        }


        public int CambiarContraseña(string username, string password, string newPass)
        {
            if (CheckUsername(username))
            {
                hashedPass = getPasswordHash(password);
                if (ComparePassword())
                {
                    hashedPass = getPasswordHash(newPass);
                    usuarioDAL.UpdateUSer(username, hashedPass);
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                throw new Exception("Error en la BD");
                
            }
        }


        private  bool ComparePassword()
        {
            if (hashedPass == storedPass)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       


      public int UpdateLanguage(string username, int language)
        {
            return usuarioDAL.updateLanguage(username, language);
        }



        private  string getPasswordHash(string password)
        {
            return CryptoManager.HashPassword(password);
        }


        public DataSet CargarUsers()
        {
            
            return usuarioDAL.LeerUsers();
        }

        public DataSet CargarUsersSinPerfil()
        {
            return usuarioDAL.LeerUsersSinPerfil();
        }

        public void AgregarUsers(DataSet ds)
        {
            usuarioDAL.CargarUsers(ds);
        }

        public int updateProfile(string username, string perfil)
        {
            return usuarioDAL.updateProfile(username, perfil);
        }

        public DataTable getRole(int cod)
        {
            return usuarioDAL.UserRole(cod);
        }
    }
}

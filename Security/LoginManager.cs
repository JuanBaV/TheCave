using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Security;
using DAL;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Resources;
using System.Windows.Forms;

namespace BLL
{
    public static class LoginManager
    {


        //private static string Username { get; set; }
        //private static string Password { get; set; }

        private static string storedUsername { get; set; }
        private static string storedPassword { get; set; }

        private static int userState { get; set; }

        private static string HashedPassword { get; set; }

        static SessionManager sessionManager = new SessionManager();
        //private static string currentLanguage = SessionManager.getProfile().idioma;
        public static string currentLanguage = "es-ES";
        private static List<IObserver> observers = new List<IObserver>();
        public static ResourceManager resourceManager;


        public static string CurrentLanguage
        {
            get { return currentLanguage; }
            set
            {
                currentLanguage = value;
                NotifyObservers();
            }
        }

        //public static void Attach(IObserver observer)
        //{
        //    observers.Add(observer);
        //}

        //public static void Detach(IObserver observer)
        //{
        //    observers.Remove(observer);
        //}

        private static void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.changeLanguage(currentLanguage);
            }
        }





        public static void ChangeControls(Control control)
        {

            control.Text = resourceManager.GetString(control.Text);


        }

        public static void changeControlsLoad(Form form)
        {
            if (currentLanguage == "en-US")
            {
                foreach (Control control in form.Controls)
                {
                    control.Text = resourceManager.GetString(control.Text);
                }
            }
        }
        public static void SetIdioma(Form form, string languaje)
        {
            currentLanguage = languaje;
            


            foreach (Control control in form.Controls)
            {
                ChangeControls(control);
            }
        }


        public static int Login(string username, string password)
        {
            getUser(username);
            if (storedUsername != "")
            {
                if (userState == 1)
                {

                    return 3;
                }
                else
                {
                    HashedPassword = getPasswordHash(password);
                    bool a = ComparePassword();


                    if (a == false)
                    {

                        return 2;
                    }
                    else
                    {

                        if (sessionManager.CheckSession == null)
                        {
                            sessionManager.CreateSession(username);
                            return 1;
                        }
                        else
                        {

                            return 0;
                        }
                    }

                }
            }
            else
            {
                return 2;
            }
        }

        public static void Logout()
        {
            if (sessionManager.CheckSession != null)
            {
                sessionManager.currentSession = null;
            }
            else
            {
                throw new Exception("Sesion no iniciada");
            }
        }





        private static bool ComparePassword()
        {
            if (HashedPassword == storedPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string getPasswordHash(string password)
        {
            return CryptoManager.HashPassword(password);
        }


        private static void getUser(string username)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            DataTable dt = new DataTable();
            dt = usuarioDAL.UserData(username);
            if (dt.Rows.Count > 0)
            {
                storedUsername = dt.Rows[0]["Username"].ToString();
                storedPassword = dt.Rows[0]["Password"].ToString();
                userState = (int)dt.Rows[0]["Block"];
                BEUsuario.Rol = (int)dt.Rows[0]["Cod_Perfil"];
                

                BEUsuario.idioma = (int)dt.Rows[0]["Idioma"];
                if(BEUsuario.idioma == 0)
                {
                    currentLanguage = "es-ES";
                }
                else
                {
                    currentLanguage= "en-US";
                }
            }
            else
            {

            }
        }


    }
}


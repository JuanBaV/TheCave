using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using BLL.Properties;

namespace BLL
{
    public static class LanguageManager
    {
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

        public static void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public static void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

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
            //if(idioma== "es-ES")
            //{

            //}
            //else
            //{

            //CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            //CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


            foreach (Control control in form.Controls)
            {
                ChangeControls(control);
            }
            }

        }

    }





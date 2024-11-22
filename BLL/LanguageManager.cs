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
using BLL.Properties;

namespace BLL
{
    public static class LanguageManager
    {

        public static ResourceManager resourceManager;
        public static string idioma { get; set; }

        public static void ChangeControls(Control control)
        {
            control.Text = resourceManager.GetString(control.Text);
        }

        public static void SetIdioma(Form form, CultureInfo cultureInfo)
        {
            idioma= cultureInfo.ToString();
            if(idioma== "es-ES")
            {
                
            }
            else
            {
                
                CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

              
                foreach (Control control in form.Controls)
                {
                    ChangeControls(control);
                }
            }
            
        }

    }
}



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using System.Resources;
using System.Globalization;
using System.Reflection.Emit;
using BE;

namespace TheCave
{
    public partial class Idioma : Form , ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        
        public Idioma()
        {
            InitializeComponent();

            
            LoginManager.resourceManager = new ResourceManager("TheCave.en-US", typeof(Idioma).Assembly);
          

        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        
        public void Notify(string language)
        {
            foreach (var observer in _observers)
            {
                observer.changeLanguage(language);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }




        private void buttonConfirmar_Click(object sender, EventArgs e)
        {

            
            LoginManager.SetIdioma(this, comboBoxIdioma.Text);
            Notify(LoginManager.CurrentLanguage);
            UsuarioBLL usuarios = new UsuarioBLL();
            if (LoginManager.currentLanguage == "es-ES")
            {
                usuarios.UpdateLanguage(BEUsuario.Username, 0);
            }
            else
            {
                usuarios.UpdateLanguage(BEUsuario.Username, 1);
            }


        }

        private void Idioma_Load(object sender, EventArgs e)
        {
            LoginManager.changeControlsLoad(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main frm = new Main();
            frm.ShowDialog();
        }
    }
}

using BE;
using BLL;
using Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheCave
{
    public partial class CreacionPerfiles : Form
    {
        ProfileManager profileManager = new ProfileManager();
        List<string> permisos = new List<string>();
        
        public CreacionPerfiles()
        {
            InitializeComponent();            
            LoginManager.resourceManager = new ResourceManager("TheCave.en-US", typeof(CreacionPerfiles).Assembly);           
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            listView1.Items.Add(comboBox1.Text);
            permisos.Add(comboBox1.Text);
        }

        private void CreacionPerfiles_Load(object sender, EventArgs e)
        {           
            LoginManager.changeControlsLoad(this);
            DataTable dt = new DataTable();
            dt = profileManager.GetPermisos();
            comboBox1.DataSource= dt;
            comboBox1.DisplayMember= "Descripcion";
            permisos.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            permisos.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            profileManager.AddPerfil(textBox1.Text, permisos);

            BEBitacora bEBitacora = new BEBitacora();
            BLLBitacora bitacora = new BLLBitacora();

            bEBitacora.Usuario = BEUsuario.Username;
            bEBitacora.Tipo = 1;
            bEBitacora.Accion = "Perfil creado";
            bEBitacora.Hora = DateTime.Now.Date;
            bEBitacora.identificador = 6;
            bEBitacora.Modulo = "Administracion";
            bEBitacora.Criticidad = 2;

            bitacora.storeBitacora(bEBitacora);
        }        
    }
}

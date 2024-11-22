using BE;
using BLL;
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
    public partial class AsignacionPerfiles : Form
    {
        ProfileManager profileManager = new ProfileManager();
        UsuarioBLL user = new UsuarioBLL();
        
        public AsignacionPerfiles()
        {
            InitializeComponent();
            LoginManager.resourceManager = new ResourceManager("TheCave.en-US", typeof(AsignacionPerfiles).Assembly);
        }

        private void AsignacionPerfiles_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            DataTable dt = new DataTable();
            dt = profileManager.GetPerfiles();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Nombre";
            dataGridView1.CellClick += DataGridView_Click;
            LoginManager.changeControlsLoad(this);
        }

        private void DataGridView_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridView dataGridView = sender as DataGridView;
                DataGridViewRow filaSeleccionada = dataGridView.Rows[e.RowIndex];
                textBox1.Text = filaSeleccionada.Cells[0].Value.ToString();
            }
        }

        public void CargarGrilla()
        {
            DataSet ds = new DataSet();
            dataGridView1.DataSource = null;   
            ds = user.CargarUsersSinPerfil();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {  
            string asignedUser = textBox1.Text;
            string perfil = comboBox1.Text;
            int a=user.updateProfile(asignedUser, perfil);

            if (a != -1)
            {
                MessageBox.Show("Perfil asignado correctamente");

                BEBitacora bEBitacora = new BEBitacora();
                BLLBitacora bitacora = new BLLBitacora();
                
                bEBitacora.Usuario = BEUsuario.Username;
                bEBitacora.Tipo = 1;
                bEBitacora.Accion = "Perfil asignado";
                bEBitacora.Hora = DateTime.Now.Date;
                bEBitacora.identificador = 2;
                bEBitacora.Modulo = "Administracion";
                bEBitacora.Criticidad = 2;
                bitacora.storeBitacora(bEBitacora);

                CargarGrilla();
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Error al asignar el perfil");
            }
        }        
    }
}

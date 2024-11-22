using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheCave
{
    public partial class Disponibilidad : Form
    {
      
        public Disponibilidad()
        {
            InitializeComponent();            
            LoginManager.resourceManager = new ResourceManager("TheCave.en-US", typeof(Disponibilidad).Assembly);           
        }

        private void Disponibilidad_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            dataGridView1.CellClick += DataGridView_Click; 
            LoginManager.changeControlsLoad(this);
        }

        private void DataGridView_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView dataGridView = sender as DataGridView;
                DataGridViewRow filaSeleccionada = dataGridView.Rows[e.RowIndex];
                GuardarValoresDeFila(filaSeleccionada);
                this.Hide();
                Alquiler frm = new Alquiler();
                frm.Show();
            }
        }

        DataSet ds = new DataSet();
        public void CargarGrilla()
        {
            dataGridView1.DataSource = null;
            EstacionBLL estacion = new EstacionBLL();
            ds = estacion.CargarEstaciones();
            dataGridView1.DataSource = ds.Tables[0];
        }

        public void GuardarValoresDeFila(DataGridViewRow fila)
        {        
            BEEstacion.Nro = (int)fila.Cells["Nro"].Value;
            BEEstacion.Tipo = fila.Cells["Tipo"].Value.ToString();
            BEEstacion.Ocupacion = (int)fila.Cells["Ocupacion"].Value;            
        }

        private void dataGridView1_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridView dataGridView = sender as DataGridView;
                DataGridViewRow filaSeleccionada = dataGridView.Rows[e.RowIndex];
                GuardarValoresDeFila(filaSeleccionada);
            }
        }
    }
}

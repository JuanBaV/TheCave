using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheCave
{
    public partial class Cambios : Form
    {
        public Cambios()
        {
            InitializeComponent();
        }

        BLLProducto producto= new BLLProducto();
        BLLCambios cambios= new BLLCambios();

        private void Cambios_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy/MM/dd";
            dataGridView1.DataSource= cambios.GetCambios();

            DataTable dt = new DataTable();
            dt=producto.GetProdutosAll();

            comboBoxIdioma.DataSource= dt;
            comboBoxIdioma.DisplayMember= "Cod_Producto";
            comboBoxIdioma.SelectedIndex=-1;
        }

        private void comboBoxIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxIdioma.Text != "")
            {               
                dataGridView1.DataSource = cambios.GetCambiosProducto(comboBoxIdioma.SelectedIndex);
            }
            else
            {
                dataGridView1.DataSource = cambios.GetCambios();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cambios.GetCambiosFecha(dateTimePicker1.Value, dateTimePicker2.Value);           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBoxIdioma.SelectedIndex = -1;
            dataGridView1.DataSource = cambios.GetCambios();
        }

        int cod;
        int stock;
        
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {           
            if (dataGridView1.SelectedRows.Count != 0)
            {
                cod = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                stock = (int)dataGridView1.SelectedRows[0].Cells[2].Value;
            }               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cambios.Restore(cod, stock);
            MessageBox.Show("RollBack exitoso");
        }
    }
}

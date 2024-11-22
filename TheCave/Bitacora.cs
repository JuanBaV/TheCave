using ADGV;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TheCave
{
    public partial class Bitacora : Form
    {
        public Bitacora()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();

        private void Bitacora_Load(object sender, EventArgs e)
        {
            
            
            CargarGrilla(0);
            
        }

        public void CargarGrilla(int num)
        {
            dataGridView1.DataSource = null;
            BLLBitacora bitacora = new BLLBitacora();


            switch (num)
            {
                case 0:
                    ds = bitacora.CargarBitacora();
                    break;
                case 1:
                    ds = bitacora.CargarBitacoraUser(textBox1.Text);
                    break;
                case 2:
                    ds = bitacora.CargarBitacoraAccion(comboBox1.Text);
                    break;
                case 3:
                    ds = bitacora.CargarBitacoraModulo(comboBox2.Text);
                    break;
                case 4:
                    ds = bitacora.CargarBitacoraCriticidad(comboBox3.SelectedIndex);
                    break;
                case 5:
                    ds = bitacora.CargarBitacoraFecha(dateTimePicker1.Value, dateTimePicker2.Value);
                    break;
            }

            dataGridView1.DataSource = ds.Tables[0];       
            
        }             

        
        
        private void button2_Click(object sender, EventArgs e)
        {

           
            XmlSerializer ser = new XmlSerializer(typeof(DataSet));
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {               
                string pathName = Path.Combine(dlg.SelectedPath, "ArchivoBitacora.xml");
                TextWriter writer = new StreamWriter(pathName);
                ser.Serialize(writer, ds);
                writer.Close();
                MessageBox.Show("Se creo el archivo");
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "XML Files|*.xml";            
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName= dlg.FileName;
                dataGridView1.DataSource = null;
                XmlSerializer ser = new XmlSerializer(typeof(DataSet));
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    ds = ser.Deserialize(fs) as DataSet;
                }
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource= dt;
                

            }            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CargarGrilla(1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrilla(2);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrilla(3);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrilla(4);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CargarGrilla(5);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            CargarGrilla(5);
        }
    }
}

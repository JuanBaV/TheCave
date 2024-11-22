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
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
        }

        BLLBackup bcp = new BLLBackup();

        private void buttonSeleccionar2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup files|*.bak";
            dlg.Title = "Database restore";

            if(dlg.ShowDialog() == DialogResult.OK) 
            {
                textBoxDireccion2.Text = dlg.FileName;
                buttonConfirmar2.Enabled= true;            
            }
        }

        private void buttonConfirmar2_Click(object sender, EventArgs e)
        {
            int a = bcp.Restauracion(textBoxDireccion2.Text);
            if (a == 1)
            {
                MessageBox.Show("RollBack exitoso");
                buttonConfirmar2.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dlg.SelectedPath;
                button1.Enabled= true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bcp.realizarBackup(textBox1.Text);
        }
    }
}

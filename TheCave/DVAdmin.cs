using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Security;

namespace TheCave
{
    public partial class DVAdmin : Form
    {
        public DVAdmin()
        {
            InitializeComponent();
        }

        private void buttonSeleccionar2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup files|*.bak";
            dlg.Title = "Database restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBoxDireccion2.Text = dlg.FileName;
                buttonConfirmar2.Enabled = true;
            }
        }

        private void buttonConfirmar2_Click(object sender, EventArgs e)
        {
            BLLBackup bcp= new BLLBackup();
            int a = bcp.Restauracion(textBoxDireccion2.Text);
            if (a == 1)
            {
                MessageBox.Show("Restauracion exitosa");
                buttonConfirmar2.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DVManagerSecurity dv = new DVManagerSecurity();
            dv.guardarTable(dv.HashTable("Usuarios"), "dvUsuarios");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Manual de usuario.pdf");
            System.Diagnostics.Process.Start(path);
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {

        }

        private void DVAdmin_Load(object sender, EventArgs e)
        {
            label5.Cursor = System.Windows.Forms.Cursors.Hand;
        }
    }
}

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
using BE;
using System.Resources;
using System.Globalization;
using System.IO;
using System.Reflection.Emit;

namespace TheCave
{
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();
           
        }




        
        private void Main_Load(object sender, EventArgs e)
        {
            label4.Cursor = System.Windows.Forms.Cursors.Hand;
            administracionToolStripMenuItem.Enabled = false;

            LoginManager.changeControlsLoad(this);
            

            BEBitacora bEBitacora = new BEBitacora();
            BLLBitacora bitacora = new BLLBitacora();

            bEBitacora.Usuario = BEUsuario.Username;
            bEBitacora.Tipo = 0;
            bEBitacora.Accion = "Inicio de sesion";
            bEBitacora.Hora = DateTime.Now.Date;
            bEBitacora.identificador = 10;
            bEBitacora.Modulo= "Usuario";
            bEBitacora.Criticidad= 0;
            bitacora.storeBitacora(bEBitacora);




            DataTable dt = new DataTable();
            UsuarioBLL user = new UsuarioBLL();
            dt = user.getRole(BEUsuario.Rol);

            if (dt.Rows.Count > 0)
            {

                administracionToolStripMenuItem.Enabled = true;
                

            }
        }

        

        private void gestionDeAlquileresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelLoad();
            Alquiler frm = new Alquiler()
            {
                TopLevel = false,
                TopMost = true
            };
            frm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(frm);
            frm.Show();
            
        }

        private void gestionDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelLoad();
            Venta frm = new Venta()
            {
                TopLevel = false,
                TopMost = true
            };
            frm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(frm);
            frm.Show();
        }

        private void cambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelLoad();
            Idioma frm = new Idioma()
            {
                TopLevel = false,
                TopMost = true
            };
            frm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(frm);
            frm.Show();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelLoad();
            Contraseña frm = new Contraseña()
            {
                TopLevel = false,
                TopMost = true
            };
            frm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(frm);
            frm.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que quiere cerrar la sesión?", "Confirmación de cierre de sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

               
                LoginManager.Logout();
                MessageBox.Show("La sesión ha sido cerrada correctamente.");


                BEBitacora bEBitacora = new BEBitacora();
                BLLBitacora bitacora = new BLLBitacora();

                bEBitacora.Usuario = BEUsuario.Username;
                bEBitacora.Tipo = 0;
                bEBitacora.Accion = "Sesion cerrada";
                bEBitacora.Hora = DateTime.Now.Date;
                bEBitacora.identificador = 9;
                bEBitacora.Modulo = "Usuario";
                bEBitacora.Criticidad = 0;
                bitacora.storeBitacora(bEBitacora);

                this.Hide();
                frmLogin frm = new frmLogin();
                frm.Show();
            }
            else
            {

                MessageBox.Show("El cierre de sesión ha sido cancelado.");
            }
        }

       

        private void modificarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelLoad();
            AdministrarUsers frm = new AdministrarUsers()
            {
                TopLevel = false,
                TopMost = true
            };
            frm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(frm);
            frm.Show();
        }

        private void registrarCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelLoad();
            frmRegistro frm = new frmRegistro()
            {
                TopLevel = false,
                TopMost = true
            };
            frm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(frm);
            frm.Show();
        }

        private void crearPerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelLoad();
            CreacionPerfiles frm = new CreacionPerfiles()
            {
                TopLevel = false,
                TopMost = true
            };
            frm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(frm);
            frm.Show();
        }

        private void asignarPerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelLoad();
            AsignacionPerfiles frm = new AsignacionPerfiles()
            {
                TopLevel = false,
                TopMost = true
            };
            frm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(frm);
            frm.Show();
        }

        private void gestionDeEventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelLoad();
            Bitacora frm = new Bitacora()
            {
                TopLevel = false,
                TopMost = true
            };
            frm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(frm);
            frm.Show();
            
        }

        private void gestionDeCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelLoad();
            Cambios frm = new Cambios()
            {
                TopLevel = false,
                TopMost = true
            };
            frm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(frm);
            frm.Show();
        }

        private void gestionDeRespaldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelLoad();
            Backup frm = new Backup()
            {
                TopLevel = false,
                TopMost = true
            };
            frm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(frm);
            frm.Show();
        }

        void panelLoad()
        {
            label2.Hide();
            label3.Hide();
            panel1.Controls.Clear();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panelLoad();
            Reportes frm = new Reportes()
            {
                TopLevel = false,
                TopMost = true
            };
            frm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(frm);
            frm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
           string path = Path.Combine(Directory.GetCurrentDirectory(), "Manual de usuario.pdf");
           System.Diagnostics.Process.Start(path);
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

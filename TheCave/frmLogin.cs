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
using Security;
using BE;
using System.Resources;
using System.Globalization;
using System.IO;

namespace TheCave
{
    public partial class frmLogin : Form
    {
        
        public frmLogin()
        {
            InitializeComponent();                        
            LoginManager.resourceManager = new ResourceManager("TheCave.en-US", typeof(frmLogin).Assembly);           
        } 

        UsuarioBLL usuarioBLL = new UsuarioBLL();
        int counter = 0;
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (counter == 3)
            {
                MessageBox.Show("Usuario bloqueado");
            }
            else
            {
                int a = LoginManager.Login(textBox1.Text, textBox2.Text);
                if (a == 0)
                {
                    MessageBox.Show("Inicio de sesion no autorizado");
                }
                else if (a == 1)
                {
                    DVManagerSecurity managerSecurity = new DVManagerSecurity();
                    bool IntegridadBBDD = true;
                    Dictionary<string, bool> tablas = managerSecurity.HashAndCompare();

                    foreach (var item in tablas)
                    {
                        if (item.Value != true)
                        {
                            IntegridadBBDD = false;
                            break;
                        }
                    }

                    if (!IntegridadBBDD)
                    {
                        MessageBox.Show("Error de integridad en la base de datos." + "por favor contactarse con un administrador");

                        if (BEUsuario.Rol == 1)
                        {
                            DVAdmin frm = new DVAdmin();
                            this.Hide();
                            frm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bienvendio");
                        BEUsuario.Username = textBox1.Text;

                        Main frm = new Main();
                        frm.Show();
                        this.Hide();
                    }
                }
                else if (a == 2)
                {
                    MessageBox.Show("Contraseña incorrecta");
                    counter++;
                    if (counter == 3)
                    {
                        MessageBox.Show("Usuario bloqueado");
                        usuarioBLL.BlockUser(textBox1.Text);

                        BEBitacora bEBitacora = new BEBitacora();
                        BLLBitacora bitacora = new BLLBitacora();

                        bEBitacora.Usuario = textBox1.Text;
                        bEBitacora.Tipo = 0;
                        bEBitacora.Accion = "Usuario bloqueado";
                        bEBitacora.Hora = DateTime.Now.Date;
                        bEBitacora.identificador = 7;
                        bEBitacora.Modulo = "Usuario";
                        bEBitacora.Criticidad = 3;

                        bitacora.storeBitacora(bEBitacora);
                    }
                }
                else if (a == 3)
                {
                    MessageBox.Show("Usuario bloqueado, contactese con un administrador para solucionarlo");
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            LoginManager.changeControlsLoad(this);
            label5.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Manual de usuario.pdf");
            System.Diagnostics.Process.Start(path);
        }
    }
}

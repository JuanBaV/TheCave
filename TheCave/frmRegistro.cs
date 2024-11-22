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
using BE;
using BLL;
using Security;

namespace TheCave
{
    public partial class frmRegistro : Form
    {
        
        public frmRegistro()
        {
            InitializeComponent();
            
                LoginManager.resourceManager = new ResourceManager("TheCave.en-US", typeof(frmRegistro).Assembly);

            
        }

        UsuarioBLL usuarioBLL= new UsuarioBLL();
        DVManagerSecurity dv = new DVManagerSecurity();
        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            
            //BEUsuario.verificacion = usuarioBLL.CalcularDigitoVerificador(textBox2.Text);
            int flag= usuarioBLL.Register(textBox1.Text,textBox2.Text, textBoxDNI.Text, textBoxApellido.Text, textBoxNombre.Text);
            if(flag == 1 )
            {
                MessageBox.Show("Usuario registrado exitosamente");

                BEBitacora bEBitacora = new BEBitacora();
                BLLBitacora bitacora = new BLLBitacora();
                string usuario = textBox1.Text;
                bEBitacora.Usuario = BEUsuario.Username;
                bEBitacora.Tipo = 1;
                bEBitacora.Accion = "Usuario registrado";
                bEBitacora.Hora = DateTime.Now.Date;
                bEBitacora.identificador = 8;
                bEBitacora.Modulo = "Administracion";
                bEBitacora.Criticidad = 3;
                bitacora.storeBitacora(bEBitacora);





                dv.guardarTable(dv.HashTable("Usuarios"), "dvUsuarios");





            }
            else
            {
                MessageBox.Show("Error al registrar el usuario");
            }

        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main frm = new Main();
            frm.Show();
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            
            LoginManager.changeControlsLoad(this);
        }
    }
}

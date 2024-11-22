using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using System.Resources;
using System.Globalization;
using System.IO;

namespace TheCave
{
    public partial class Contraseña : Form
    {
        
        public Contraseña()
        {
            InitializeComponent();          
            LoginManager.resourceManager = new ResourceManager("TheCave.en-US", typeof(Contraseña).Assembly);          
        }

        UsuarioBLL usuario = new UsuarioBLL();

        private void Contraseña_Load(object sender, EventArgs e)
        {
            labelUser.Text = BEUsuario.Username;      
            LoginManager.changeControlsLoad(this);
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            int flag= usuario.CambiarContraseña(labelUser.Text, textBox1.Text, textBox2.Text);
            if(flag == 1 )
            {
                MessageBox.Show("Contraseña actualizada con exito");

                BEBitacora bEBitacora = new BEBitacora();
                BLLBitacora bitacora = new BLLBitacora();
 
                bEBitacora.Usuario = BEUsuario.Username;
                bEBitacora.Tipo = 1;
                bEBitacora.Accion = "Contraseña actualizada";
                bEBitacora.Hora = DateTime.Now.Date;
                bEBitacora.identificador = 5;
                bEBitacora.Modulo = "Usuario";
                bEBitacora.Criticidad = 3;
                bitacora.storeBitacora(bEBitacora);
            }
            else if (flag == 2 ) 
            {
                MessageBox.Show("La contraseña actual es incorrecta");
            }
            else
            {
                MessageBox.Show("Error al actualizar la contraseña");
            }
        }
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TheCave
{
    public partial class AdministrarUsers : Form
    {
        
        public AdministrarUsers()
        {
            InitializeComponent();          
        }

        DataSet ds = new DataSet();

        private void AdministrarUsers_Load(object sender, EventArgs e)
        {            
            LoginManager.changeControlsLoad(this);
            dataGridView1.ReadOnly= false;
            CargarGrilla();
        }
    
        public void CargarGrilla()
        {
            dataGridView1.DataSource = null;
            UsuarioBLL user = new UsuarioBLL();
            ds = user.CargarUsers();
            dataGridView1.DataSource= ds.Tables[0];
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            UsuarioBLL user = new UsuarioBLL();
            user.AgregarUsers(ds);
            CargarGrilla();

            BEBitacora bEBitacora = new BEBitacora();
            BLLBitacora bitacora = new BLLBitacora();

            bEBitacora.Usuario = BEUsuario.Username;
            bEBitacora.Tipo = 1;
            bEBitacora.Accion = "Modificacion de usuarios";
            bEBitacora.Hora = DateTime.Now.Date;
           
            bEBitacora.Modulo = "Administracion";
            bEBitacora.Criticidad = 3;
            bitacora.storeBitacora(bEBitacora);
        } 
    }
}

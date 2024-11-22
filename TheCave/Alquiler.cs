using BE;
using BLL;
using Security;
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

namespace TheCave
{
    public partial class Alquiler : Form
    {
        
        public Alquiler()
        {
            InitializeComponent();
        }

        int counterMins = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            Cobro frm = new Cobro();
            frm.Show();
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Disponibilidad frm = new Disponibilidad();
            frm.Show();
        }

        private void Alquiler_Load(object sender, EventArgs e)
        {           
            LoginManager.changeControlsLoad(this);
            textBox2.Text = counterMins.ToString();
            if(BEEstacion.Nro == 0)
            {
                textBox1.Text = "";
            }
            else
            {
                textBox1.Text= BEEstacion.Nro.ToString();
            }
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            counterMins += 1;
            textBox2.Text = counterMins.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            counterMins -= 1;
            textBox2.Text = counterMins.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BEEstacion.Ocupacion != 1)
            {
                BEEstacion.Ocupacion = 1;
                int a = actualizarOcupacion();

                if (a == -1)
                {
                    MessageBox.Show("Error al habilitar la estacion");
                }
                else
                {
                    int precio = 100 * int.Parse(textBox2.Text);
                    BEAlquiler.precio = precio;    /*float.Parse(CryptoManager.Encriptar(precio, "ClaveDeEncriptacion123"));*/
                    BEAlquiler.estacion = BEEstacion.Nro;
                    BEAlquiler.fecha = DateTime.Now.Date;
                    BEAlquiler.tiempo = float.Parse(textBox2.Text);
                    BEUsuario.operacion = 0;

                    Cobro frm = new Cobro();
                    frm.Show();                   
                }
            }
            else
            {
                MessageBox.Show("Estacion ya ocupada");
            }
        }

         int actualizarOcupacion()
         {
            EstacionBLL estacion = new EstacionBLL();
            return estacion.ActualizarOcupacion(BEEstacion.Ocupacion, BEEstacion.Nro);           
         }
       
        private void button2_Click(object sender, EventArgs e)
        {
            if (BEEstacion.Ocupacion == 1)
            {               
                BEEstacion.Ocupacion = 0;
                int a= actualizarOcupacion();
                if (a != 1)
                {
                    MessageBox.Show("Error al deshabilitar la estacion");
                }
                else
                {
                    MessageBox.Show("Estacion deshabilitada con exito");

                    BEBitacora bEBitacora = new BEBitacora();
                    BLLBitacora bitacora = new BLLBitacora();

                    int estacion = BEEstacion.Nro;
                    
                    bEBitacora.Usuario = BEUsuario.Username;
                    bEBitacora.Tipo = 1;
                    bEBitacora.Accion = "Estacion deshabilitada";
                    bEBitacora.Hora = DateTime.Now.Date;
                    bEBitacora.identificador= 1;
                    bEBitacora.Modulo = "Negocio";
                    bEBitacora.Criticidad = 1;
                    bitacora.storeBitacora(bEBitacora);
                }
            }
            else
            {
                MessageBox.Show("Estacion no ocupada");
            }
        }               
    }
}

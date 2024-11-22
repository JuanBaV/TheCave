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


namespace TheCave
{
    public partial class Cobro : Form
    {
       
        public Cobro()
        {
            InitializeComponent();         
            LoginManager.resourceManager = new ResourceManager("TheCave.en-US", typeof(Cobro).Assembly);  
        }

        private void Cobro_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/yyyy";
            LoginManager.changeControlsLoad(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            MessageBox.Show("Cobro realizado con exito");
            if (BEUsuario.operacion == 0)
            {
                textBox7.Text = BEAlquiler.precio.ToString();
                MessageBox.Show("Estacion habilitada con exito");

                BEBitacora bEBitacora = new BEBitacora();
                BLLBitacora bitacora = new BLLBitacora();

                int estacion = BEEstacion.Nro;
                bEBitacora.Usuario = BEUsuario.Username;
                bEBitacora.Accion = "Estacion NRO habilitada";
                bEBitacora.Hora = DateTime.Now.Date;
                bEBitacora.identificador = 3;
                bEBitacora.Modulo = "Negocio";
                bEBitacora.Criticidad = 1;

                bitacora.storeBitacora(bEBitacora);
                int b = storeAlquiler();

                if (b == 1)
                {
                    MessageBox.Show("Alquiler registrado");
                    int Alquiler = BEAlquiler.codigo;

                    bEBitacora.Tipo = 0;
                    bEBitacora.Accion = "Alquiler cobrado";
                    bEBitacora.Hora = DateTime.Now.Date;
                    bEBitacora.identificador = 4;
                    bEBitacora.Modulo = "Negocio";
                    bEBitacora.Criticidad = 0;
                    bitacora.storeBitacora(bEBitacora);

                    this.Hide();             
                }
                else
                {
                    MessageBox.Show("Error al registrar el alquiler");
                }
            }
            else if (BEUsuario.operacion == 1)
            {
                textBox7.Text = Compra.precio.ToString();
                BLLCambios cambios = new BLLCambios();
                for (int i = 0; i < 100; i++)
                {
                    if (Compra.productos[i, 0] != 0)
                    {
                        cambios.registrarCambio(i);
                    }
                }
                BLLCompra compra = new BLLCompra();
                int b=compra.RegistrarCompra(DateTime.Now, Compra.precio, Compra.productos);                
                if (b == 1)
                {
                    MessageBox.Show("compra registrada");

                    BEBitacora bEBitacora = new BEBitacora();
                    BLLBitacora bitacora = new BLLBitacora();
                    bEBitacora.Usuario = BEUsuario.Username;
                    bEBitacora.Accion = "compra cobrada";
                    bEBitacora.Hora = DateTime.Now.Date;
                    bEBitacora.identificador = 20;
                    bEBitacora.Modulo = "Negocio";
                    bEBitacora.Criticidad = 1;
                    bitacora.storeBitacora(bEBitacora);

                    this.Hide();                   
                }
                else
                {
                    MessageBox.Show("Error al registrar la compra");
                }
            }           
        }

        int storeAlquiler()
        {
            BLLAlquiler AlquilerBLL = new BLLAlquiler();
            return AlquilerBLL.storeAlquiler(BEAlquiler.estacion, BEAlquiler.precio, BEAlquiler.tiempo, BEAlquiler.fecha);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}

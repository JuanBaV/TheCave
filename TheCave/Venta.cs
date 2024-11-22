using BE;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TheCave
{
    public partial class Venta : Form
    {
        public Venta()
        {
            InitializeComponent();
        }

        BLLProducto producto= new BLLProducto();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        
        private void Venta_Load(object sender, EventArgs e)
        {
            

           for(int i=0; i < 50; i++)
            {
                Compra.productos[i, 0] = 0;
            }

            listView1.Items.Clear();
            dt = producto.GetCategorias();
            //comboBoxCategoria.DataSource = dt;
            //comboBoxCategoria.DisplayMember= "Nombre";
            //comboBoxCategoria.Text = "";
            foreach (DataRow row in dt.Rows)
            {
                comboBoxCategoria.Items.Add(row["Nombre"].ToString());
            }

        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            //Buscar codigo de categoria seleccionada, lo explico pq me costo un huevo y no me quiero olvidar

            string nombreSeleccionado = comboBoxCategoria.SelectedItem.ToString();

            DataRow[] rows = dt.Select("Nombre = '" + nombreSeleccionado + "'");

            string codigo = rows[0]["Cod_Categoria"].ToString();
            dt2=producto.GetProdutos(int.Parse(codigo));

            foreach (DataRow row in dt2.Rows)
            {
                string stock = row["Stock"].ToString();
                if (int.Parse(stock)!=0)
                {
                    comboBox2.Items.Add(row["Nombre"].ToString());
                }
                
            }
           //comboBox2.DataSource= dt2;
            //comboBox2.DisplayMember= "Nombre";
        }

        private void buttonAñadir_Click(object sender, EventArgs e)
        {
            string nombreSeleccionado = comboBox2.SelectedItem.ToString();

            DataRow[] rows = dt2.Select("Nombre = '" + nombreSeleccionado + "'");

            string codigo = rows[0]["Cod_Producto"].ToString();
            string precio = rows[0]["Precio"].ToString();

            listView1.Items.Add(codigo + "----" + nombreSeleccionado);

            Compra.precio += int.Parse(precio);
            if (comboBox2.Text == "")
            {
            }
            else
            {
                Compra.productos[int.Parse(codigo), 0] += 1;

            }

        }

        private void buttonCobro_Click(object sender, EventArgs e)
        {
            BEUsuario.operacion = 1;
            
            Cobro frm = new Cobro();
            frm.Show();
            
        }
    }
}

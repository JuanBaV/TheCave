using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALCompra
    {

        SqlConnection Conection = new SqlConnection("Data Source=localhost;Initial Catalog=THECAVE;Integrated Security=True");


        public int RegistrarCompra(DateTime fecha, int precio, int[,] stock)
        {
            Conection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Ventas (Fecha, Precio) values (@fecha, @precio)", Conection);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            int rowsAffected = cmd.ExecuteNonQuery();
            
            for (int i = 0; i < 100; i++) {
                SqlCommand cmd1 = new SqlCommand("UPDATE Productos SET Stock=(STOCK-@stock) WHERE Cod_Producto=@cod", Conection);
                cmd1.Parameters.AddWithValue("@cod",i);
                cmd1.Parameters.AddWithValue("@stock", stock[i,0]);
                cmd1.ExecuteNonQuery();
            }
            Conection.Close();
            return rowsAffected;
        }


    }
}

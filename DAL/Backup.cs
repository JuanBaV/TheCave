using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALBackup
    {

        SqlConnection Conection = new SqlConnection("Data Source=localhost;Initial Catalog=THECAVE;Integrated Security=True");

        public int realizarBackup(string direccion)
        {
            string database = Conection.Database.ToString();
            string cmd = "BACKUP DATABASE [" + database + "] TO DISK= '" + direccion + "\\" + "database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH--mm--ss") + ".bak'";
            Conection.Open();
            SqlCommand command= new SqlCommand(cmd, Conection);
            command.ExecuteNonQuery(); 
            Conection.Close();
            return 1;
        }

        public int restauracion(string direccion)
        {
            string database = Conection.Database.ToString();
            Conection.Open();

            try
            {
                string str1 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd = new SqlCommand(str1, Conection);
                cmd.ExecuteNonQuery();

                string str2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + direccion + "' WITH REPLACE;";
                SqlCommand cmd2 = new SqlCommand(str2, Conection);
                cmd2.ExecuteNonQuery();

                string str3 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                SqlCommand cmd3 = new SqlCommand(str3, Conection);
                cmd3.ExecuteNonQuery();

                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

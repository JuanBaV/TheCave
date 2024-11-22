using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public class DVManagerSecurity
    {

    public DVManagerSecurity() { }

        DVManager dVManager = new DVManager();



        public bool CompareTables(DataTable table1, DataTable table2)
        {
            if (table1.Rows.Count != table2.Rows.Count)
            {
                return false; // Diferente número de filas
            }

            for (int i = 0; i < table1.Rows.Count; i++)
            {
                for (int j = 0; j < table1.Columns.Count; j++)
                {
                    if (!table1.Rows[i][j].Equals(table2.Rows[i][j]))
                    {
                        return false; // Los datos en la celda no son iguales
                    }
                }
            }

            return true;
        }

        public DataTable HashTable(string tabla_A_Concatenar)
        {

            //HACER LISTA de nombre de tablas PARA PASAR DINAMICAMENTE EL NOMBRE DE LAS TABLAS

            DataTable TableToHash = dVManager.ObtenerDatatableConcatenada(tabla_A_Concatenar);

            if (TableToHash.Rows.Count > 0 && TableToHash.Columns.Contains("COLUMNA"))
            {
                TableToHash.Columns["COLUMNA"].ColumnName = "HashValue";

                using (SHA256 sha256 = SHA256.Create())
                {
                    foreach (DataRow row in TableToHash.Rows)
                    {
                        string hashValue = row["HashValue"].ToString();

                        byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(hashValue));

                        string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                        row["HashValue"] = hashString;
                    }
                }
            }
            return TableToHash;
        }

        //public void HashAndSave(string tablaConcatenar, string tablaDigitoVerificador)
        //{
        //    dVManager.GuardarTable(HashTable(tablaConcatenar), tablaDigitoVerificador);
        //}

        public void guardarTable(DataTable table, string tablaDigitoVerificador) {


            dVManager.GuardarTable(table, tablaDigitoVerificador);
        }


        public Dictionary<string, bool> HashAndCompare()
        {
            List<Tuple<string, string>> TablaBBDD = new List<Tuple<string, string>>();

            //TODO: Se agregan tablas segun existan en la BBDD
            TablaBBDD.Add(new Tuple<string, string>("Usuarios", "dvUsuarios"));
            

            Dictionary<string, bool> tablas = new Dictionary<string, bool>();
            foreach (var tupla in TablaBBDD)
            {

                tablas.Add(tupla.Item1, this.CompareTables(HashTable(tupla.Item1), dVManager.ObtenerDatatable(tupla.Item2)));

            }
            return tablas;

        }


    }
}

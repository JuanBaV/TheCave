using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLLBackup
    {
        DALBackup bcp = new DALBackup();

        public int realizarBackup(string direccion)
        {

            return bcp.realizarBackup(direccion);
            

        }

        public int Restauracion(string direccion)
        {

            return bcp.restauracion(direccion);


        }
    }
}

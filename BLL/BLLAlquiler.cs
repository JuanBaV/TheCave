using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLAlquiler
    {


        DALAlquiler alquiler = new DALAlquiler();

        public int storeAlquiler(int estacion, float precio, float tiempo, DateTime fecha)
        {
            return alquiler.storeAlquiler(estacion, precio, tiempo, fecha);
        }

        public DataTable getAlquileres()
        {
            return alquiler.getAlquileres();
        }





    }
}

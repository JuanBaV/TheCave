using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EstacionBLL
    {
        EstacionDAL estacion = new EstacionDAL();
        public DataSet CargarEstaciones()
        {

            return estacion.LeerEstaciones();
        }

        public int ActualizarOcupacion(int ocupacion, int nro)
        {
            return estacion.actualizarOcupacion(ocupacion, nro);
        }


    }
}

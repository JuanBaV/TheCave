using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLBitacora
    {

        DALBitacora bitacora = new DALBitacora();

        public int storeBitacora(BEBitacora beBitacora)
        {
            return bitacora.storeBitacora(beBitacora.Usuario, beBitacora.Accion, beBitacora.Hora, beBitacora.Modulo, beBitacora.Criticidad);
        }

        public DataSet CargarBitacora()
        {

            return bitacora.LeerBitacora();
        }

        public DataSet CargarBitacoraUser(string user)
        {

            return bitacora.LeerBitacoraUser(user);
        }

        public DataSet CargarBitacoraAccion(string accion) { 

            return bitacora.LeerBitacoraAccion(accion);
        }

        public DataSet CargarBitacoraModulo(string Modulo)
        {

            return bitacora.LeerBitacoraModulo(Modulo);
        }

        public DataSet CargarBitacoraCriticidad(int criticidad)
        {

            return bitacora.LeerBitacoraCriticidad(criticidad);
        }

        public DataSet CargarBitacoraFecha(DateTime fecha, DateTime fecha2)
        {

            return bitacora.LeerBitacoraFecha(fecha, fecha2);
        }
    }
}

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
    public class BLLCambios
    {

       DALCambios cambios =  new DALCambios();

        public DataTable GetCambios()
        {
            return cambios.GetCambios();
        }

        public DataTable GetCambiosProducto(int cod)
        {
            return cambios.GetCambiosProducto(cod);
        }

        public DataTable GetCambiosFecha(DateTime fecha, DateTime fecha2)
        {
            return cambios.GetCambiosFecha(fecha, fecha2);
        }



        public void registrarCambio(int cod)
        {
            cambios.registrarCambio(cod);
        }

        public void Restore(int cod, int stock)
        {
            cambios.Restore(cod, stock);
        }




    }
}

using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCompra
    {

        DALCompra compra = new DALCompra();


        public int RegistrarCompra(DateTime fecha, int precion, int[,] stock)
        {
           return compra.RegistrarCompra(fecha, precion, stock);
            
        }
        

        


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEBitacora
    {
        public int Tipo { get; set; }
        public string Usuario { get; set; }

        public string Accion { get; set; }

        public int identificador { get; set; }

        public string Modulo { get; set; }

        public int Criticidad { get; set; }


        public DateTime Hora { get; set; }
    }
}

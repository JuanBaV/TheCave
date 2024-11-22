using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProfileManager
    {

        DALPErfil dALPErfil = new DALPErfil();

        public DataTable GetPermisos()
        {

            return dALPErfil.GetPermisos();
        }

        public int AddPerfil(string Nombre, List<string> permisos)
        {
            return dALPErfil.addPerfil(Nombre, permisos);   
        }

        public DataTable GetPerfiles()
        {

            return dALPErfil.GetPerfiles();
        }

    }
}

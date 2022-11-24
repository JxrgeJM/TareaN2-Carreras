using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramacionAvanzadaTareaN2.Entidades;
using ProgramacionAvanzadaTareaN2.Datos;

namespace ProgramacionAvanzadaTareaN2.LogicaNegocio
{
    public class AdministradorCorredor
    {
        public static List<Corredor> Listar()
        {
            return CorredorDAL.Listar();
        }

        public static void Agregar(Corredor pCorredor)
        {
            CorredorDAL.Agregar(pCorredor);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramacionAvanzadaTareaN2.Entidades;
using ProgramacionAvanzadaTareaN2.Datos;

namespace ProgramacionAvanzadaTareaN2.LogicaNegocio
{
    public class AdministradorCarrera
    {
        public static List<Carrera> Listar(int pNumCarrera)
        {
            return CarreraDAL.Listar(pNumCarrera);
        }

        public static void Agregar(Carrera pCarrera)
        {
            CarreraDAL.Agregar(pCarrera);
        }

        public static void Agregar(List<Carrera> pCarreras)
        {
            foreach (var item in pCarreras)
            {
                CarreraDAL.Agregar(item);
            }
        }
    }
}

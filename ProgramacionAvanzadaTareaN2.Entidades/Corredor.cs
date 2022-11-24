using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProgramacionAvanzadaTareaN2.Entidades
{
    public class Corredor
    {
        public Corredor()
        {
            Id = 0;
            Nombre = "";
        }

        public Corredor(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        [Display(Name = "Número corredor")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Requerido")]
        public string Nombre { get; set; }
    }
}

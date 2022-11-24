using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProgramacionAvanzadaTareaN2.Entidades
{
    public class Carrera
    {
        public Carrera()
        {
            Id = 0;
            NumCarrera = 0;
            Corredor = new Corredor();
            Minutos = 0;
            Segundos = 0;
        }

        public Carrera(int id, int numCarrera, Corredor corredor, int minutos, int segundos)
        {
            Id = id;
            NumCarrera = numCarrera;
            Corredor = corredor;
            Minutos = minutos;
            Segundos = segundos;
        }

        public int Id { get; set; }

        public int NumCarrera { get; set; }

        public Corredor Corredor { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [Range(typeof(int), "0", "9999", ErrorMessage = "Debe ser un número entre {1} y {2}.")]
        public int Minutos { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [Range(typeof(int), "0", "59", ErrorMessage = "Debe ser un número entre {1} y {2}.")]
        public int Segundos { get; set; }



        [Display(Name = "Tiempo (minutos, segundos)")]
        public string MinutosSegundos
        {
            get
            {
                return $"{this.Minutos.ToString().PadLeft(2, '0')}:{this.Segundos.ToString().PadLeft(2, '0')}";
            }
        }

        [Display(Name = "m/s")]
        public decimal MetrosPorSegundo
        {
            get 
            {
                int vSegundos = (this.Minutos > 0) ? (this.Minutos * 60) + this.Segundos : this.Segundos;
                return (vSegundos > 0) ? ((decimal)2000 / vSegundos) : 0; 
            }
        }


    }
}

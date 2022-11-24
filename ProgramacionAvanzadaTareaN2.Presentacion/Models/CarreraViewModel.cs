using System.ComponentModel.DataAnnotations;
using ProgramacionAvanzadaTareaN2.Entidades;

namespace ProgramacionAvanzadaTareaN2.Presentacion.Models
{
    public class CarreraViewModel
    {
        public CarreraViewModel()
        {
            Carreras = new List<Carrera>();
        }

        public CarreraViewModel(List<Carrera> carreras)
        {
            Carreras = carreras;
        }

        [Required(ErrorMessage = "Requerido")]
        public List<Carrera> Carreras { get; set; }



        [Display(Name = "Mejor velocidad (m/s)")]
        public decimal MejorVelocidad
        {
            get
            {
                Carrera ?vCarrera = this.Carreras.MaxBy(p => p.MetrosPorSegundo);
                return (vCarrera != null) ? vCarrera.MetrosPorSegundo : 0; 
            }
        }

        [Display(Name = "Peor velocidad (m/s)")]
        public decimal PeorVelocidad
        {
            get
            {
                Carrera? vCarrera = this.Carreras.MinBy(p => p.MetrosPorSegundo);
                return (vCarrera != null) ? vCarrera.MetrosPorSegundo : 0;
            }
        }

        [Display(Name = "Velocidad promedio (m/s)")]
        public decimal VelocidadPromedio
        {
            get
            {
                decimal vCarrera = this.Carreras.Average(p => p.MetrosPorSegundo);
                return vCarrera;
            }
        }
    }
}

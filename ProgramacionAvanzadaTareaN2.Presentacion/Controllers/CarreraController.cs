using Microsoft.AspNetCore.Mvc;
using ProgramacionAvanzadaTareaN2.Presentacion.Models;
using ProgramacionAvanzadaTareaN2.Entidades;
using ProgramacionAvanzadaTareaN2.LogicaNegocio;

namespace ProgramacionAvanzadaTareaN2.Presentacion.Controllers
{
    public class CarreraController : Controller
    {
        public IActionResult Index()
        {
            CarreraViewModel vModelo = new CarreraViewModel(AdministradorCarrera.Listar(0));
            return View(vModelo);
        }

        [HttpPost]
        public IActionResult Index(CarreraViewModel pModelo)
        {
            try
            {
                ViewBag.Resultado = "";
                if (ModelState.IsValid)
                {
                    AdministradorCarrera.Agregar(pModelo.Carreras);
                    ViewBag.Resultado = "Se registraton correctamente los tiempos.";
                }
            }
            catch (Exception)
            {
                ViewBag.Resultado = "Se generó un inconveniente al agregar los tiempos.";
            }
            return View(pModelo);
        }

        public IActionResult Resultados()
        {
            CarreraViewModel vModelo = new CarreraViewModel(AdministradorCarrera.Listar(0));
            return View(vModelo);
        }

    }
}

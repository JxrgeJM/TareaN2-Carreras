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
                ViewBag.Message = "";
                CarreraViewModel vModelo = new CarreraViewModel(AdministradorCarrera.Listar(0));
                if (ModelState.IsValid && vModelo.Carreras.Count > 0 && vModelo.Carreras[0].Id == 0)
                {
                    AdministradorCarrera.Agregar(pModelo.Carreras);
                    ViewBag.Message = "Se registraton correctamente.";
                }
                else
                    ViewBag.Message = "Ya se registraron los resultados.";
            }
            catch (Exception)
            {
                ViewBag.Message = "Se generó un inconveniente al agregar.";
            }
            return View(pModelo);
        }

        public IActionResult Resultados()
        {
            CarreraViewModel vModelo = new CarreraViewModel(AdministradorCarrera.Listar(0));
            if (vModelo.Carreras.Count > 0 && vModelo.Carreras[0].Id > 0)
                return View(vModelo);
            else
                return RedirectToAction("Index", "Home", new { pMensaje = "No hay tiempos registrados!" });
        }

    }
}

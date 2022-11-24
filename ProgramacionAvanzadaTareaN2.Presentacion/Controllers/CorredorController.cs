using Microsoft.AspNetCore.Mvc;
using ProgramacionAvanzadaTareaN2.Entidades;
using ProgramacionAvanzadaTareaN2.LogicaNegocio;

namespace ProgramacionAvanzadaTareaN2.Presentacion.Controllers
{
    public class CorredorController : Controller
    {
        public IActionResult Index()
        {
            List<Corredor> vDatos = AdministradorCorredor.Listar();
            return View(vDatos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Corredor Modelo)
        {
            AdministradorCorredor.Agregar(Modelo);
            return RedirectToAction("Index");
        }

    }
}

﻿using Microsoft.AspNetCore.Mvc;
using ProgramacionAvanzadaTareaN2.Presentacion.Models;
using System.Diagnostics;

namespace ProgramacionAvanzadaTareaN2.Presentacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string pMensaje = "")
        {
            ViewBag.Mensaje = pMensaje;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
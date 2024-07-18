using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PROGETTO_S1.Models;
using PROGETTO_S1.Service;
using System;
using System.Diagnostics;

namespace PROGETTO_S1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISpedizioniService _spedizioniService;

        public HomeController(ILogger<HomeController> logger, ISpedizioniService spedizioniService)
        {
            _logger = logger;
            _spedizioniService = spedizioniService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SpedizioniPerClientePrivato(string codiceFiscale)
        {
            try
            {
                var spedizioni = _spedizioniService.SpedizioniPerClientePrivato(codiceFiscale);
                return View("SpedizioniPerClientePrivato", spedizioni);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Si è verificato un errore durante il recupero delle spedizioni. Riprova più tardi.");
                _logger.LogError(ex, "Errore durante il recupero delle spedizioni per il cliente.");
                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

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
        public IActionResult CercaSpedizioni(string codiceFiscale, string partitaIVA)
        {
            try
            {
                if (!string.IsNullOrEmpty(codiceFiscale))
                {
                    var spedizioni = _spedizioniService.SpedizioniPerClientePrivato(codiceFiscale);
                    return View("SpedizioniPerClientePrivato", spedizioni);
                }
                else if (!string.IsNullOrEmpty(partitaIVA))
                {
                    var spedizioni = _spedizioniService.SpedizioniPerClienteAzienda(partitaIVA);
                    return View("SpedizioniPerClienteAzienda", spedizioni);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Inserisci un codice fiscale o una partita IVA valida.");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Si � verificato un errore durante la ricerca delle spedizioni. Riprova pi� tardi.");
                _logger.LogError(ex, "Errore durante la ricerca delle spedizioni.");
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

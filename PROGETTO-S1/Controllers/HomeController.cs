using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROGETTO_S1.Models;
using PROGETTO_S1.Service;
using System.Diagnostics;

namespace PROGETTO_S1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISpedizioniService _spedizioniService;
        public HomeController(ILogger<HomeController> logger, ISpedizioniService spedizioniService )
        {
            _logger = logger;
            _spedizioniService = spedizioniService;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SpedizioniPerClientePrivato(string codiceFiscale)
        {
            var spedizioni = _spedizioniService.SpedizioniPerClientePrivato(codiceFiscale);
            return View("SpedizioniPerCliente", spedizioni);
        }

       // public IActionResult SpedizioniPerClienteAzienda(string partitaIVA)
       // {
       //     var spedizioni = _spedizioniService.SpedizioniPerClienteAzienda(partitaIVA);
       //     return View("SpedizioniPerCliente", spedizioni);
       // }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

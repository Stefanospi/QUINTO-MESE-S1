using Microsoft.AspNetCore.Mvc;
using PROGETTO_G5.Models;
using PROGETTO_G5.Services;
using System.Diagnostics;

namespace PROGETTO_G5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnagraficaService _anagraficaService;
        private readonly IVerbaleService _verbaleService;
        private readonly IViolazioneService _violazioneService;

        public HomeController(ILogger<HomeController> logger,IAnagraficaService anagraficaService, IVerbaleService verbaleService, IViolazioneService violazioneService)
        {
            _logger = logger;
            _anagraficaService = anagraficaService;
            _verbaleService = verbaleService;
            _violazioneService = violazioneService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateAnagrafica()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAnagrafica(Anagrafica anagrafica)
        {
            if(ModelState.IsValid)
            {
                _anagraficaService.CreateAnagrafica(anagrafica);
                return RedirectToAction("Index");
            }
            return View(anagrafica);

        }
        public IActionResult CreateVerbali()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateVerbali(Verbale verbale)
        {
            if(ModelState.IsValid)
            {
                _verbaleService.CreateVerbale(verbale);
                return RedirectToAction("Index");
            }
            return View(verbale);
        }

        public IActionResult Violazioni()
        {
            var violazioni = _violazioneService.GetTipoViolazione();
            return View(violazioni);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

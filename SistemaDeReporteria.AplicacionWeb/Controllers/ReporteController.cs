using Microsoft.AspNetCore.Mvc;

namespace SistemaDeReporteria.AplicacionWeb.Controllers
{
    public class ReporteController : Controller
    {
        private readonly ILogger<ReporteController> _logger;

        public ReporteController(ILogger<ReporteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Proyecto()
        {
            return View();
        }

        public IActionResult Investigador()
        {
            return View();
        }

        public IActionResult InvestigadorXProyecto()
        {
            return View();
        }

        public IActionResult Reporte()
        {
            return View();
        }

    }
}
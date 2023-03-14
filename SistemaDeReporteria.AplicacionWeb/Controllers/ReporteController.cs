using Microsoft.AspNetCore.Mvc;
using SistemaDeReporteria.AplicacionWeb.Models;

namespace SistemaDeReporteria.AplicacionWeb.Controllers
{
    public class ReporteController : Controller
    {
        private readonly ILogger<ReporteController> _logger;

        public ReporteController(ILogger<ReporteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
            List<string> columnas = new List<string>() {"columna1", "columna2", "columna3" };
            List<int> datos = new List<int>() { 1, 2, 3 };

            return View( new Chart("graphic", "bar", columnas,"Columnas", datos));
        }

    }
}
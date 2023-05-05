using Microsoft.AspNetCore.Mvc;
using SistemaDeReporteria.AplicacionWeb.Models;
using System.Diagnostics;

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

        [HttpGet]
        public IActionResult ObtenerProyectos(VariablesProyecto variablesProyecto)
        {
            return View("Index");
        }

        public IActionResult Investigador()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ObtenerInvestigadores(VariablesInvestigador variablesInvestigador)
        {
            //string rutaArchivo = Path.Combine(Directory.GetCurrentDirectory(), "archivo.txt");
            //System.IO.File.WriteAllText(rutaArchivo, variablesInvestigador.ToString());

            return View("Index");
        }

        public IActionResult InvestigadorXProyecto()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ObtenerProyectosXInvestigador(VariablesInvestigadorXProyecto variablesInvestigadorXProyecto)
        {
            return View("Index");
        }

        public IActionResult Reporte()
        {
            List<string> columnas = new List<string>() {"columna1", "columna2", "columna3" };
            List<int> datos = new List<int>() { 1, 2, 3 };

            return View( new Chart("graphic", "bar", columnas,"Columnas", datos));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
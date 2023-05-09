using Microsoft.AspNetCore.Mvc;
using SistemaDeReporteria.AplicacionWeb.Models;
using SistemaDeReporteria.Modelos;
using System.Diagnostics;
using SistemaDeReporteria.LogicaDeNegocio;
using System.Text;

namespace SistemaDeReporteria.AplicacionWeb.Controllers
{
    public class ReporteController : Controller
    {
        private readonly ILogger<ReporteController> _logger;
        private ReporteManager _reporteManager;

        public ReporteController(ILogger<ReporteController> logger)
        {
            _logger = logger;
            _reporteManager = new ReporteManager();
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
            var viewModel = _reporteManager.obtenerViewModelDeProyectosPorVariablesDeProyecto(variablesProyecto);

            return View("Reporte", viewModel);
        }

        public IActionResult Investigador()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ObtenerInvestigadores(VariablesInvestigador variablesInvestigador)
        {
            var viewModel = _reporteManager.obtenerViewModelDeInvestigadoresPorVariablesDeInvestigador(variablesInvestigador);

            return View("Reporte", viewModel);
        }

        public IActionResult InvestigadorXProyecto()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ObtenerProyectosXInvestigador(VariablesInvestigadorXProyecto variablesInvestigadorXProyecto)
        {
            var viewModel = _reporteManager.obtenerViewModelDeProyectosPorVariablesDeInvestigadorXProyecto(variablesInvestigadorXProyecto);

            return View("Reporte", viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
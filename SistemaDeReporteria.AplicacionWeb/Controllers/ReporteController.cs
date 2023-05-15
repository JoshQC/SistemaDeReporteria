using Microsoft.AspNetCore.Mvc;
using SistemaDeReporteria.AplicacionWeb.Models;
using SistemaDeReporteria.Modelos;
using System.Diagnostics;
using SistemaDeReporteria.LogicaDeNegocio;
using System.Data.SqlClient;

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
            return View(new ProyectoViewModel());
        }

        [HttpGet]
        public IActionResult ObtenerProyectos(VariablesProyecto variablesProyecto)
        {
            var varProyViewModel = new ProyectoViewModel();
            var error = new List<string>();

            try
            {
                var viewModel = _reporteManager.obtenerViewModelDeProyectosPorVariablesDeProyecto(variablesProyecto);
                return View("Reporte", viewModel);
            }
            catch (ErrorValidacion err)
            {
                error = err.Errores;
            }
            catch (NoData err)
            {
                error.Add(err.Message);
            }
            catch (SqlException)
            {
                error.Add("Se produjo un error relacionado con la red o específico de la instancia al establecer una conexión con SQL Server. No se encontró el servidor o no se pudo acceder a él. Verifica que el nombre de la instancia sea correcto y que SQL Server esté configurado para permitir conexiones remotas.");
            }
            catch (TimeoutException)
            {
                error.Add("Tiempo de espera de ejecución expirado. El período de tiempo de espera transcurrió antes de que se completara la operación o el servidor no está respondiendo.");
            }
            catch (InvalidOperationException)
            {
                error.Add("Operación no válida en la base de datos.");
            }
            catch (ArgumentException)
            {
                error.Add("Argumento no válido en el contexto actual.");
            }

            varProyViewModel.Errores = error;
            return View("Proyecto", varProyViewModel);
        }

        public IActionResult Investigador()
        {
            return View(new InvestigadorViewModel());
        }

        [HttpGet]
        public IActionResult ObtenerInvestigadores(VariablesInvestigador variablesInvestigador)
        {
            var varInvViewModel = new InvestigadorViewModel();
            var error = new List<string>();

            try
            {
                var viewModel = _reporteManager.obtenerViewModelDeInvestigadoresPorVariablesDeInvestigador(variablesInvestigador);
                return View("Reporte", viewModel);
            }
            catch (ErrorValidacion err)
            {
                error = err.Errores;
            }
            catch (NoData err) 
            {
                error.Add(err.Message);
            }
            catch (SqlException)
            {
                error.Add("Se produjo un error relacionado con la red o específico de la instancia al establecer una conexión con SQL Server. No se encontró el servidor o no se pudo acceder a él. Verifica que el nombre de la instancia sea correcto y que SQL Server esté configurado para permitir conexiones remotas.");
            }
            catch (TimeoutException)
            {
                error.Add("Tiempo de espera de ejecución expirado. El período de tiempo de espera transcurrió antes de que se completara la operación o el servidor no está respondiendo.");
            }
            catch (InvalidOperationException)
            {
                error.Add("Operación no válida en la base de datos.");
            }
            catch (ArgumentException)
            {
                error.Add("Argumento no válido en el contexto actual.");
            }

            varInvViewModel.Errores = error;
            return View("Investigador", varInvViewModel);
        }

        public IActionResult InvestigadorXProyecto()
        {
            return View(new InvestigadorXProyectoViewModel());
        }

        [HttpGet]
        public IActionResult ObtenerProyectosXInvestigador(VariablesInvestigadorXProyecto variablesInvestigadorXProyecto)
        {
            var varInvXproyViewModel = new InvestigadorXProyectoViewModel();
            var error = new List<string>();

            try
            {
                var viewModel = _reporteManager.obtenerViewModelDeProyectosPorVariablesDeInvestigadorXProyecto(variablesInvestigadorXProyecto);
                return View("Reporte", viewModel);
            }
            catch (ErrorValidacion err)
            {
                error = err.Errores;
            }
            catch (NoData err)
            {
                error.Add(err.Message);
            }
            catch (SqlException)
            {
                error.Add("Se produjo un error relacionado con la red o específico de la instancia al establecer una conexión con SQL Server. No se encontró el servidor o no se pudo acceder a él. Verifica que el nombre de la instancia sea correcto y que SQL Server esté configurado para permitir conexiones remotas.");
            }
            catch (TimeoutException)
            {
                error.Add("Tiempo de espera de ejecución expirado. El período de tiempo de espera transcurrió antes de que se completara la operación o el servidor no está respondiendo.");
            }
            catch (InvalidOperationException)
            {
                error.Add("Operación no válida en la base de datos.");
            }
            catch (ArgumentException)
            {
                error.Add("Argumento no válido en el contexto actual.");
            }

            varInvXproyViewModel.Errores = error;
            return View("InvestigadorXProyecto", varInvXproyViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
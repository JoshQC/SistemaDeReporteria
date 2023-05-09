using SistemaDeReporteria.Datos;
using SistemaDeReporteria.Modelos;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace SistemaDeReporteria.LogicaDeNegocio
{
    public class ReporteManager
    {
        private IReporteRepository repositorio;

        public ReporteManager()
        {
            this.repositorio = new ReporteRepository();
        }

        public ReporteViewModel obtenerViewModelDeProyectosPorVariablesDeProyecto(VariablesProyecto variablesProyecto)
        {
            var proyectos = repositorio.getProyectosPorVariablesProyecto(variablesProyecto);
            var nombresDeColumnasDeTabla = ObtenerNombresDePropiedades(typeof(Proyecto));

            ReporteViewModel viewModel = new ReporteViewModel
            {
                Proyectos = proyectos,
                ColumnasTabla = nombresDeColumnasDeTabla,
                Chart = new Chart("graphic", "bar", new List<string>() { "Proyectos" }, "Cantidad De Proyectos", new List<int>() { proyectos.Count }),
                Investigadores = null
            };

            return viewModel;
        }

        public ReporteViewModel obtenerViewModelDeProyectosPorVariablesDeInvestigadorXProyecto(VariablesInvestigadorXProyecto variablesInvestigadorXProyecto)
        {
            var proyectos = repositorio.getProyectosPorVariablesInvestigadorXProyecto(variablesInvestigadorXProyecto);
            var nombresDeColumnasDeTabla = ObtenerNombresDePropiedades(typeof(Proyecto));

            ReporteViewModel viewModel = new ReporteViewModel
            {
                Proyectos = proyectos,
                ColumnasTabla = nombresDeColumnasDeTabla,
                Chart = new Chart("graphic", "bar", new List<string>() { "Proyectos" }, "Cantidad De Proyectos", new List<int>() { proyectos.Count }),
                Investigadores = null
            };

            return viewModel;
        }

        public ReporteViewModel obtenerViewModelDeInvestigadoresPorVariablesDeInvestigador(VariablesInvestigador variablesInvestigador)
        {
            var investigadores = repositorio.getInvestigadoresPorVariablesInvestigador(variablesInvestigador);
            var nombresDeColumnasDeTabla = ObtenerNombresDePropiedades(typeof(Investigador));

            ReporteViewModel viewModel = new ReporteViewModel
            {
                Proyectos = null,
                ColumnasTabla = nombresDeColumnasDeTabla,
                Chart = new Chart("graphic", "bar", new List<string>() { "Investigadores" }, "Cantidad De Investigadores", new List<int>() { investigadores.Count }),
                Investigadores = investigadores
            };

            return viewModel;
        }

        private List<string> ObtenerNombresDePropiedades(Type tipo) 
        {
            List<string> nombres = new List<string>();

            PropertyInfo[] propiedades = tipo.GetProperties();

            foreach (PropertyInfo propiedad in propiedades)
            {
                string[] palabras = Regex.Split(propiedad.Name, @"(?<!^)(?=[A-Z])");
                string nombrePropiedad = String.Join(" ", palabras);
                nombres.Add(nombrePropiedad);
            }

            return nombres;
        }
    }
}

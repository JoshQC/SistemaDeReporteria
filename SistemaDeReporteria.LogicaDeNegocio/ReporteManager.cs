﻿using SistemaDeReporteria.Datos;
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
            var validador = new Validador();

            if (!validador.EsValido(variablesProyecto)) throw new ErrorValidacion(validador.Errores);

            var proyectos = repositorio.getProyectosPorVariablesProyecto(variablesProyecto);

            if (proyectos.Count == 0) throw new NoData("No se encontraron coincidencias con los valores sugeridos");

            var nombresDeColumnasDeTabla = ObtenerNombresDePropiedades(typeof(Proyecto));
            List<string> propiedadesUsadas = PropiedadPoblada.ObtenerPropiedades(variablesProyecto);

            ReporteViewModel viewModel = new ReporteViewModel
            {
                Proyectos = proyectos,
                ColumnasTabla = nombresDeColumnasDeTabla,
                Chart = new Chart("graphic", "bar", new List<string>() { "Proyectos" }, "Cantidad De Proyectos", new List<int>() { proyectos.Count }),
                Investigadores = null,
                TituloVista = "Listar Proyectos por " + UnirElementosEnLista(propiedadesUsadas)
            };

            return viewModel;
        }

        public ReporteViewModel obtenerViewModelDeProyectosPorVariablesDeInvestigadorXProyecto(VariablesInvestigadorXProyecto variablesInvestigadorXProyecto)
        {
            var validador = new Validador();

            if (!validador.EsValido(variablesInvestigadorXProyecto)) throw new ErrorValidacion(validador.Errores);

            var proyectos = repositorio.getProyectosPorVariablesInvestigadorXProyecto(variablesInvestigadorXProyecto);

            if (proyectos.Count == 0) throw new NoData("No se encontraron coincidencias con los valores sugeridos");

            var nombresDeColumnasDeTabla = ObtenerNombresDePropiedades(typeof(Proyecto));
            List<string> propiedadesUsadas = PropiedadPoblada.ObtenerPropiedades(variablesInvestigadorXProyecto);

            ReporteViewModel viewModel = new ReporteViewModel
            {
                Proyectos = proyectos,
                ColumnasTabla = nombresDeColumnasDeTabla,
                Chart = new Chart("graphic", "bar", new List<string>() { "Proyectos" }, "Cantidad De Proyectos", new List<int>() { proyectos.Count }),
                Investigadores = null,
                TituloVista = "Listar Proyectos por " + UnirElementosEnLista(propiedadesUsadas)
            };

            return viewModel;
        }

        public ReporteViewModel obtenerViewModelDeInvestigadoresPorVariablesDeInvestigador(VariablesInvestigador variablesInvestigador)
        {
            var validador = new Validador();

            if (!validador.EsValido(variablesInvestigador)) throw new ErrorValidacion(validador.Errores);

            var investigadores = repositorio.getInvestigadoresPorVariablesInvestigador(variablesInvestigador);

            if (investigadores.Count == 0) throw new NoData("No se encontraron coincidencias con los valores sugeridos");

            var nombresDeColumnasDeTabla = ObtenerNombresDePropiedades(typeof(Investigador));
            List<string> propiedadesUsadas = PropiedadPoblada.ObtenerPropiedades(variablesInvestigador);

            ReporteViewModel viewModel = new ReporteViewModel
            {
                Proyectos = null,
                ColumnasTabla = nombresDeColumnasDeTabla,
                Chart = new Chart("graphic", "bar", new List<string>() { "Investigadores" }, "Cantidad De Investigadores", new List<int>() { investigadores.Count }),
                Investigadores = investigadores,
                TituloVista = "Listar Proyectos por " + UnirElementosEnLista(propiedadesUsadas)
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

        private string UnirElementosEnLista(List<string> elementos) 
        {
            int count = elementos.Count;

            string resultado = "";
            for (int i = 0; i < count; i++)
            {
                if (i < count - 2)
                {
                    resultado += elementos[i] + ", ";
                }
                else if (i == count - 2)
                {
                    resultado += elementos[i] + " y ";
                }
                else
                {
                    resultado += elementos[i];
                }
            }

            return resultado;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReporteria.Modelos
{
    public class ProyectoViewModel
    {
        public ProyectoViewModel(DatosSelect datos)
        {
            Estados = datos.Estados;

            Tipos = datos.Tipos;

            Regiones = datos.Regiones;

            AreaCientifica = datos.AreasConocimiento;

            ObjetivosSocioEconomicos = datos.ObjetivosSocioEconomicos;

            EjesDePlanes = datos.EjesDePlanes;

            ObjetivosDesarrolloSostenible = datos.ObjetivosDesarrolloSostenible;

            VariablesProyecto = new();
            Errores = new();
        }

        public VariablesProyecto VariablesProyecto { get; set; }
        public List<string>? Estados { get; set; }
        public List<string>? Tipos { get; set; }
        public List<string>? Regiones { get; set; }
        public List<string>? AreaCientifica { get; set; }
        public List<string>? ObjetivosSocioEconomicos { get; set; }
        public List<string>? EjesDePlanes { get; set; }
        public List<string>? ObjetivosDesarrolloSostenible { get; set; }
        public List<string> Errores { get; set; }
    }
}

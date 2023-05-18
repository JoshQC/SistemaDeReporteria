using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReporteria.Modelos
{
    public class ProyectoViewModel
    {
        public ProyectoViewModel()
        {
            Estados = DatosSelect.Estados;

            Tipos = DatosSelect.Tipos;

            Regiones = DatosSelect.Regiones;

            AreaCientifica = DatosSelect.AreasConocimiento;

            ObjetivosSocioEconomicos = DatosSelect.ObjetivosSocioEconomicos;

            EjesDePlanes = DatosSelect.EjesDePlanes;

            ObjetivosDesarrolloSostenible = DatosSelect.ObjetivosDesarrolloSostenible;

            VariablesProyecto = new();
            Errores = new();
        }

        public VariablesProyecto VariablesProyecto { get; set; }
        public List<string> Estados { get; set; }
        public List<string> Tipos { get; set; }
        public List<string> Regiones { get; set; }
        public List<string> AreaCientifica { get; set; }
        public List<string> ObjetivosSocioEconomicos { get; set; }
        public List<string> EjesDePlanes { get; set; }
        public List<string> ObjetivosDesarrolloSostenible { get; set; }
        public List<string> Errores { get; set; }
    }
}

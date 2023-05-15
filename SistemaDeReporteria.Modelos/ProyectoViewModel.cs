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
            Estados = new List<string>
            {
                "En Revisión",
                "Activo",
                "Finalizado",
                "Cancelado",
                "Inactivo",
                "Rechazado"
            };

            Tipos = new List<string>
            {
                "Investigación Básica",
                "Investigación Aplicada",
                "Desarrollo Tecnológico"
            };

            Regiones = new List<string>
            {
                "Central",
                "Brunca",
                "Chorotega",
                "Huetar Atlántica",
                "Huetar Norte",
                "Pacífico Central"
            };

            VariablesProyecto = new();
            Errores = new();
        }

        public VariablesProyecto VariablesProyecto { get; set; }
        public List<string> Estados { get; set; }
        public List<string> Tipos { get; set; }
        public List<string> Regiones { get; set; }
        public List<string> Errores { get; set; }
    }
}

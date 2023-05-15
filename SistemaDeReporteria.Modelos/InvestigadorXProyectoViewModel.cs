using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReporteria.Modelos
{
    public class InvestigadorXProyectoViewModel
    {
        public InvestigadorXProyectoViewModel() 
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

            VariablesInvestigadorXProyecto = new();
            Errores = new();
        }

        public VariablesInvestigadorXProyecto VariablesInvestigadorXProyecto { get; set; }
        public List<string> Estados { get; set; }
        public List<string> Errores { get; set; }
    }
}

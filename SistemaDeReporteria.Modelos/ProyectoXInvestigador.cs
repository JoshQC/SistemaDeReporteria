using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReporteria.Modelos
{
    public class ProyectoXInvestigador : Proyecto
    {
        public int? Edad { get; set; }
        public string? Investigador { get; set; }
    }
}

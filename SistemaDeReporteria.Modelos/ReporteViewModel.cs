using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReporteria.Modelos
{
    public class ReporteViewModel
    {
        public List<Proyecto>? Proyectos { get; set; }
        public List<ProyectoXInvestigador>? ProyectosXInvestigadores { get; set; }
        public List<Investigador>? Investigadores { get; set; }
        public List<string> ColumnasTabla { get; set; }
        public Chart Chart { get; set; }
        public string TituloVista { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReporteria.Modelos
{
    public interface IReporteRepository
    {
        List<Proyecto> getProyectosPorVariablesProyecto(VariablesProyecto variablesProyecto);
        List<Proyecto> getProyectosPorVariablesInvestigadorXProyecto(VariablesInvestigadorXProyecto variablesInvestigadorXProyecto);
        List<Investigador> getInvestigadoresPorVariablesInvestigador(VariablesInvestigador variablesInvestigador);
    }
}

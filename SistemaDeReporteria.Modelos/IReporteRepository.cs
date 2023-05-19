
namespace SistemaDeReporteria.Modelos
{
    public interface IReporteRepository
    {
        List<Proyecto> getProyectosPorVariablesProyecto(VariablesProyecto variablesProyecto);
        List<ProyectoXInvestigador> getProyectosPorVariablesInvestigadorXProyecto(VariablesInvestigadorXProyecto variablesInvestigadorXProyecto);
        List<Investigador> getInvestigadoresPorVariablesInvestigador(VariablesInvestigador variablesInvestigador);
        List<string> GetValoresSelect(string tabla);
    }
}

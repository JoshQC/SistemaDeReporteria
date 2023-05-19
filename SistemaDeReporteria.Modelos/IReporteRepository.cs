
namespace SistemaDeReporteria.Modelos
{
    public interface IReporteRepository
    {
        List<Proyecto> getProyectosPorVariablesProyecto(VariablesProyecto variablesProyecto);
        List<Proyecto> getProyectosPorVariablesInvestigadorXProyecto(VariablesInvestigadorXProyecto variablesInvestigadorXProyecto);
        List<Investigador> getInvestigadoresPorVariablesInvestigador(VariablesInvestigador variablesInvestigador);
        public List<string> GetValoresSelect(string tabla);
    }
}

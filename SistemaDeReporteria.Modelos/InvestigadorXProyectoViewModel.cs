

namespace SistemaDeReporteria.Modelos
{
    public class InvestigadorXProyectoViewModel
    {
        public InvestigadorXProyectoViewModel(DatosSelect datos) 
        {
            Estados = datos.Estados;

            AreaCientifica = datos.AreasConocimiento;

            VariablesInvestigadorXProyecto = new();
            Errores = new();
        }

        public VariablesInvestigadorXProyecto VariablesInvestigadorXProyecto { get; set; }
        public List<string>? Estados { get; set; }
        public List<string>? AreaCientifica { get; set; }
        public List<string> Errores { get; set; }
    }
}



namespace SistemaDeReporteria.Modelos
{
    public class InvestigadorViewModel
    {
        public InvestigadorViewModel(DatosSelect datos)
        {
            Sexos = new List<string>
            {
                "Masculino",
                "Femenino"
            };

            GradosAcademicos = datos.GradosAcademicos;

            VariablesInvestigador = new();
            Errores = new();
        }

       public VariablesInvestigador VariablesInvestigador { get; set; }
       public List<string> Sexos { get; set; }
       public List<string>? GradosAcademicos { get; set; }
       public List<string> Errores { get; set; }
    }
}

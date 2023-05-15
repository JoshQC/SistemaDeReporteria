using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReporteria.Modelos
{
    public class InvestigadorViewModel
    {
        public InvestigadorViewModel()
        {
            Sexos = new List<string>
            {
                "Masculino",
                "Femenino"
            };

            VariablesInvestigador = new();
            Errores = new();
        }

       public VariablesInvestigador VariablesInvestigador { get; set; }
       public List<string> Sexos { get; set; }
       public List<string> Errores { get; set; }
    }
}

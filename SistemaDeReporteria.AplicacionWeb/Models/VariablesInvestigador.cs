namespace SistemaDeReporteria.AplicacionWeb.Models
{
    public class VariablesInvestigador
    {
        public string Grado_Academico { get; set; }
        public int Edad_Minima { get; set; }
        public int Edad_Maxima { get; set; }
        public string Sexo { get; set; }
        public override string ToString()
        {
            return $"Grado_Academico: {Grado_Academico}, Edad_Minima: {Edad_Minima}, Edad_Maxima: {Edad_Maxima}, Sexo: {Sexo}";
        }
    }
}

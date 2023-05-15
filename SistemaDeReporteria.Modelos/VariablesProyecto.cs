
namespace SistemaDeReporteria.Modelos
{
    public class VariablesProyecto
    {
        public string Estado { get; set; }

        public string Tipo { get; set; }

        public string Area_Cientifica { get; set; }

        public string Objetivo_Socioeconomico { get; set; }

        public string Eje_De_Planes { get; set; }

        public string Unidad_De_Investigacion { get; set; }

        public string Fecha_Inicio_Estimada { get; set; }

        public string Fecha_Inicio_Real { get; set; }

        public string Fecha_Finalizacion_Estimada { get; set; }

        public string Fecha_Finalizacion_Real { get; set; }

        public string Canton { get; set; }

        public string Region { get; set; }

        public string Objetivo_De_Desarrollo_Sostenible { get; set; }

        public override string ToString()
        {
            return $"Estado: {Estado}\n" +
                   $"Tipo: {Tipo}\n" +
                   $"Área Científica: {Area_Cientifica}\n" +
                   $"Objetivo Socioeconómico: {Objetivo_Socioeconomico}\n" +
                   $"Eje de Planes: {Eje_De_Planes}\n" +
                   $"Unidad de Investigación: {Unidad_De_Investigacion}\n" +
                   $"Fecha de Inicio Estimada: {Fecha_Inicio_Estimada}\n" +
                   $"Fecha de Inicio Real: {Fecha_Inicio_Real}\n" +
                   $"Fecha de Finalización Estimada: {Fecha_Finalizacion_Estimada}\n" +
                   $"Fecha de Finalización Real: {Fecha_Finalizacion_Real}\n" +
                   $"Cantón: {Canton}\n" +
                   $"Región: {Region}\n" +
                   $"Objetivo de Desarrollo Sostenible: {Objetivo_De_Desarrollo_Sostenible}";
        }

    }
}

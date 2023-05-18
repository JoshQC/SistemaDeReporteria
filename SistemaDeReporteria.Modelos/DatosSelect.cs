
namespace SistemaDeReporteria.Modelos
{
    public class DatosSelect
    {
        public static List<string> Estados { get; } = new List<string>
        {
            "En Revisión",
            "Activo",
            "Finalizado",
            "Cancelado",
            "Inactivo",
            "Rechazado"
        };

        public static List<string> Tipos { get; } = new List<string>
        {
            "Investigación Básica",
            "Investigación Aplicada",
            "Desarrollo Tecnológico"
        };

        public static List<string> Regiones { get; } = new List<string>
        {
            "Central",
            "Brunca",
            "Chorotega",
            "Huetar Atlántica",
            "Huetar Norte",
            "Pacífico Central"
        };

        public static List<string> AreasConocimiento { get; } = new List<string>
        {
            "Ciencias Sociales",
            "Interdisciplinarios",
            "Ciencias Médicas",
            "Ciencias Exactas y Naturales",
            "Ingeniería y tecnologías",
            "Humanidadesl",
            "Ciencias Agrícolas"
        };

        public static List<string> ObjetivosSocioEconomicos { get; } = new List<string>
        {
            "No identificado",
            "Control y protección del medio ambiente.",
            "Estructura y relaciones sociales.",
            "Infraestructura y ordenamiento del territorio.",
            "Investigación no orientada.",
            "Producción y tecnología agrícola.",
            "Protección y mejora de la salud humana.",
            "Exploración y explotación de la tierra.",
            "Producción, distribución y utilización racional de la energía.",
            "Producción y tecnología industrial",
            "Exploración y explotación del espacio."
        };

        public static List<string> EjesDePlanes { get; } = new List<string>
        {
            "No indicado",
            "Pertinencia e impacto",
            "Acceso y equidad",
            "Aprendizaje",
            "Ciencia y tecnología",
            "Gestión",
            "2021-2025 Calidad y pertinencia",
            "2021-2025 Cobertura y equidad",
            "2021-2025 Regionalización",
            "2021-2025 Internacionalización",
            "2021-2025 Sostenibilidad"
        };

        public static List<string> ObjetivosDesarrolloSostenible { get; } = new List<string>
        {
            "Fin de la pobreza",
            "Hambre cero",
            "Salud y bienestar",
            "Educación de calidad",
            "Igualdad de género",
            "Agua limpia y saneamiento",
            "Energía asequible y no contaminante",
            "Trabajo decente y crecimiento económico",
            "Industria, innovación e infraestructura",
            "Reducción de las desigualdades",
            "Ciudades y comunidades sostenibles",
            "Producción y consumos responsables",
            "Acción por el clima",
            "Vida submarina",
            "Vida de ecosistemas terrestres",
            "Paz, justicia e instituciones sólidas",
            "Alianzas para lograr objetivos"
        };
    }
}

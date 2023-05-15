
namespace SistemaDeReporteria.Modelos
{
    public class ErrorValidacion : Exception
    {
        public List<string> Errores { get; } 

        public ErrorValidacion() : base() { }
        public ErrorValidacion(string mensaje) : base(mensaje) { }
        public ErrorValidacion(string mensaje, Exception innerException) : base(mensaje, innerException) { }
        public ErrorValidacion(List<string> errores)
        {
            Errores = errores ?? new List<string>(); 
        }
    }
}

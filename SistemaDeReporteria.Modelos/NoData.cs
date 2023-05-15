
namespace SistemaDeReporteria.Modelos
{
    public class NoData : Exception
    {
        public NoData() : base() { }
        public NoData(string mensaje) : base(mensaje) { }
        public NoData(string mensaje, Exception innerException) : base(mensaje, innerException) { }
    }
}

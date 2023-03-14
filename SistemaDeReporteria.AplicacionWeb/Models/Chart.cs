namespace SistemaDeReporteria.AplicacionWeb.Models
{
    public class Chart
    {
        public Chart(string id, string tipo, List<string> nombreColumnas, string titulo, List<int> datos) {
            this.Id = id;
            this.Tipo = tipo;
            this.NombreColumnas = nombreColumnas;
            this.Titulo = titulo;
            this.Datos = datos;
        }

        public string Id { get; private set; }
        public string Tipo { get; private set; }
        public List<string> NombreColumnas { get; private set; }
        public string Titulo { get; private set; }
        public List<int> Datos { get; private set; }
    }
}

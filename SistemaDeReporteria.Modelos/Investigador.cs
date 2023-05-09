using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReporteria.Modelos
{
	public class Investigador
	{
		public string? PrimerApellido { get; set; }
		public string? SegundoApellido { get; set; }
		public string? Nombre { get; set; }
		public string? Identificacion { get; set; }
		public string? CorreoPrincipal { get; set; }
		public string? GradoAcademico { get; set; }
		public int? Edad { get; set; }
		public int? Sexo { get; set; }
	}
}

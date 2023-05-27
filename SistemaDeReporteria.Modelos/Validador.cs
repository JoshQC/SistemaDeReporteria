using System.Reflection;
using System.Text.RegularExpressions;


namespace SistemaDeReporteria.Modelos
{
    public class Validador
    {
        public Validador() 
        { 
            Errores = new List<string>();
        }

        public List<string> Errores { get; set; }
        
        private PropiedadValidacion ObtenerPropiedadesDeValidacion(string nombreProp)
        {
            var propiedad = new PropiedadValidacion();

            switch (nombreProp)
            {
                case "Grado_Academico":
                case "Estado":
                case "Tipo":
                case "Area_Cientifica":
                case "Objetivo_Socioeconomico":
                case "Eje_De_Planes":
                case "Unidad_De_Investigacion":
                case "Canton":
                case "Region":
                case "Objetivo_De_Desarrollo_Sostenible":
                case "Nombre_Del_Investigador":
                case "Sexo":
                    nombreProp = nombreProp.Replace("_", " ");
                    propiedad.Patron = @"[a-zA-Z\s]";
                    propiedad.MensajeError = $"En {nombreProp} ingrese solamente caracteres";
                    break;
                case "Fecha_Inicio_Estimada":
                case "Fecha_Inicio_Real":
                case "Fecha_Finalizacion_Estimada":
                case "Fecha_Finalizacion_Real":
                case "Fecha_De_Inicio":
                    nombreProp = nombreProp.Replace("_", " ");
                    propiedad.Patron = @"^\d{4}-\d{2}-\d{2}$|^\d{4}$";
                    propiedad.MensajeError = $"En {nombreProp} debe seguir un formato de fecha año-mes-dia o solamente año";
                    break;
                case "Edad_Minima":
                case "Edad_Maxima":
                    nombreProp = nombreProp.Replace("_", " ");
                    propiedad.Patron = "^[0-9]+$";
                    propiedad.MensajeError = $"En {nombreProp} ingrese solamente numeros enteros";
                    break;
                default:
                    propiedad = null;
                    break;
            }

            return propiedad;
        }

        private void ValidarPropiedades(object instancia)
        {
            Type tipo = instancia.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();

            PropertyInfo edadMinimaPropiedad = propiedades.FirstOrDefault(p => p.Name == "Edad_Minima");
            PropertyInfo edadMaximaPropiedad = propiedades.FirstOrDefault(p => p.Name == "Edad_Maxima");

            if (edadMinimaPropiedad != null && edadMaximaPropiedad != null)
            {
                int edadMinima = (int)edadMinimaPropiedad.GetValue(instancia);
                int edadMaxima = (int)edadMaximaPropiedad.GetValue(instancia);

                if (edadMinima != 0 && edadMaxima != 0)
                {
                    if (edadMaxima <= edadMinima)
                    {
                        Errores.Add("La Edad Maxima debe ser mayor a Edad Minima");
                    }
                }

                if (edadMinima < 0 || edadMaxima < 0) 
                {
                    Errores.Add("Los campos de Edad no admiten valores negativos");
                }
            }

            bool todasPropiedadesNulas = propiedades.All(p => p.GetValue(instancia) == null || (p.GetValue(instancia) != null && p.GetValue(instancia).Equals(0)));

            if (todasPropiedadesNulas)
            {
                Errores.Add("Debe ingresar al menos una entrada con valor");
            }
            else 
            {
                foreach (PropertyInfo propiedad in propiedades)
                {
                    string nombrePropiedad = propiedad.Name;
                    string? valorPropiedad = propiedad.GetValue(instancia)?.ToString();

                    PropiedadValidacion propiedadValidacion = ObtenerPropiedadesDeValidacion(nombrePropiedad);

                    if (!string.IsNullOrEmpty(valorPropiedad) && propiedadValidacion != null)
                    {
                        Regex regex = new Regex(propiedadValidacion.Patron);
                        if (!regex.IsMatch(valorPropiedad))
                        {
                            Errores.Add(propiedadValidacion.MensajeError);
                        }
                    }
                }
            }
        }

        public bool EsValido(object instancia) 
        {
            ValidarPropiedades(instancia);
            return Errores.Count == 0;
        }
    }
}

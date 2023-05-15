using System;
using System.Collections.Generic;
using System.Reflection;

namespace SistemaDeReporteria.Modelos
{
    public class PropiedadPoblada
    {
        public static List<string> ObtenerPropiedades(object objeto)
        {
            List<string> nombresPropiedades = new List<string>();
            Type tipo = objeto.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();

            foreach (PropertyInfo propiedad in propiedades)
            {
                object valor = propiedad.GetValue(objeto);
                if (EsValorValido(valor))
                {
                    nombresPropiedades.Add(propiedad.Name.Replace("_"," "));
                }
            }

            return nombresPropiedades;
        }

        public static bool EsValorValido(object valor)
        {
            if (valor is string)
            {
                return !string.IsNullOrEmpty((string)valor);
            }
            else if (valor is IConvertible valorConvertible)
            {
                return Convert.ToDouble(valorConvertible) != 0;
            }
            else
            {
                return valor != null;
            }
        }
    }
}

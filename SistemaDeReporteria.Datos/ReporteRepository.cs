//using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SistemaDeReporteria.Modelos;

namespace SistemaDeReporteria.Datos
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public ReporteRepository() 
        {
            _configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
            connectionString = _configuration.GetConnectionString(name: "ConexionGestiona");
        }

        public List<Proyecto> getProyectosPorVariablesProyecto(VariablesProyecto variablesProyecto)
        {
            List<Proyecto> proyectos = new List<Proyecto>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_FiltrarProyectosDinamico", conn);
                command.CommandType = CommandType.StoredProcedure;

                if (!string.IsNullOrEmpty(variablesProyecto.Estado)) 
                {
                    command.Parameters.AddWithValue("@estado", variablesProyecto.Estado);
                }

                if (!string.IsNullOrEmpty(variablesProyecto.Tipo)) 
                {
                    command.Parameters.AddWithValue("@tipo", variablesProyecto.Tipo);
                }

                if (!string.IsNullOrEmpty(variablesProyecto.Area_Cientifica)) 
                {
                    command.Parameters.AddWithValue("@areaCientifica", variablesProyecto.Area_Cientifica);
                }

                if (!string.IsNullOrEmpty(variablesProyecto.Objetivo_Socioeconomico)) 
                {
                    command.Parameters.AddWithValue("@objSocioeconomico", variablesProyecto.Objetivo_Socioeconomico);
                }

                if (!string.IsNullOrEmpty(variablesProyecto.Eje_De_Planes)) 
                {
                    command.Parameters.AddWithValue("@ejePlanes", variablesProyecto.Eje_De_Planes);
                }

                if (!string.IsNullOrEmpty(variablesProyecto.Unidad_De_Investigacion)) 
                {
                    command.Parameters.AddWithValue("@unidadInvestigacion", variablesProyecto.Unidad_De_Investigacion);
                }

                if (!string.IsNullOrEmpty(variablesProyecto.Fecha_Inicio_Estimada)) 
                {
                    command.Parameters.AddWithValue("@fechaInicioEstimada", variablesProyecto.Fecha_Inicio_Estimada);
                }

                if (!string.IsNullOrEmpty(variablesProyecto.Fecha_Inicio_Real))
                {
                    command.Parameters.AddWithValue("@fechaInicioReal", variablesProyecto.Fecha_Inicio_Real);
                }

                if (!string.IsNullOrEmpty(variablesProyecto.Fecha_Finalizacion_Estimada))
                {
                    command.Parameters.AddWithValue("@fechaFinalEstimada", variablesProyecto.Fecha_Finalizacion_Estimada);
                }

                if (!string.IsNullOrEmpty(variablesProyecto.Fecha_Finalizacion_Real))
                {
                    command.Parameters.AddWithValue("@fechaFinalReal", variablesProyecto.Fecha_Finalizacion_Real);
                }

                if (!string.IsNullOrEmpty(variablesProyecto.Canton)) 
                {
                    command.Parameters.AddWithValue("@canton", variablesProyecto.Canton);
                }

                if (!string.IsNullOrEmpty(variablesProyecto.Region)) 
                {
                    command.Parameters.AddWithValue("@region", variablesProyecto.Region);
                }

                if (!string.IsNullOrEmpty(variablesProyecto.Objetivo_De_Desarrollo_Sostenible))
                {
                    command.Parameters.AddWithValue("@objDesarrolloSostenible", variablesProyecto.Objetivo_De_Desarrollo_Sostenible);
                }

                conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Proyecto proyecto = new Proyecto();

                        proyecto.Codigo = reader["Codigo"].ToString();
                        proyecto.Titulo = reader["Titulo"].ToString();
                        proyecto.Estado = reader["Estado"].ToString();
                        proyecto.Tipo = reader["Tipo"].ToString();
                        proyecto.AreaConocimiento = reader["AreaConocimiento"].ToString();
                        proyecto.ObjetivoSocioEconomico = reader["ObjetivoSocioEconomico"].ToString();
                        proyecto.EjeDePlanes = reader["EjeDePlanes"].ToString();
                        proyecto.UnidadInvestigacion = reader["UnidadInvestigacion"].ToString();
                        proyecto.FechaInicioEstimada = reader["FechaInicioEstimada"] == DBNull.Value ? null : ((DateTime)reader["FechaInicioEstimada"]).ToString("yyyy-MM-dd");
                        proyecto.FechaInicioReal = reader["FechaInicioReal"] == DBNull.Value ? null : ((DateTime)reader["FechaInicioReal"]).ToString("yyyy-MM-dd");
                        proyecto.FechaFinalizacionEstimada = reader["FechaFinalizacionEstimada"] == DBNull.Value ? null : ((DateTime)reader["FechaFinalizacionEstimada"]).ToString("yyyy-MM-dd");
                        proyecto.FechaFinalizacionReal = reader["FechaFinalizacionReal"] == DBNull.Value ? null : ((DateTime)reader["FechaFinalizacionReal"]).ToString("yyyy-MM-dd");

                        proyectos.Add(proyecto);
                    }
                }

                conn.Close();
            }

            return proyectos;
        }

        public List<ProyectoXInvestigador> getProyectosPorVariablesInvestigadorXProyecto(VariablesInvestigadorXProyecto variablesInvestigadorXProyecto) 
        {
            List<ProyectoXInvestigador> proyectos = new();

            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                SqlCommand command = new SqlCommand("sp_FiltrarProyectosXInvestigadorDinamico", conn);
                command.CommandType = CommandType.StoredProcedure;

                if (!string.IsNullOrEmpty(variablesInvestigadorXProyecto.Estado))
                {
                    command.Parameters.AddWithValue("@estado", variablesInvestigadorXProyecto.Estado);
                }

                if (!string.IsNullOrEmpty(variablesInvestigadorXProyecto.Area_Cientifica))
                {
                    command.Parameters.AddWithValue("@areaCientifica", variablesInvestigadorXProyecto.Area_Cientifica);
                }

                if (!string.IsNullOrEmpty(variablesInvestigadorXProyecto.Fecha_De_Inicio))
                {
                    command.Parameters.AddWithValue("@fechaInicioReal", variablesInvestigadorXProyecto.Fecha_De_Inicio);
                }

                if (!string.IsNullOrEmpty(variablesInvestigadorXProyecto.Nombre_Del_Investigador)) 
                {
                    command.Parameters.AddWithValue("@NombreCompleto", variablesInvestigadorXProyecto.Nombre_Del_Investigador);
                }

                if (variablesInvestigadorXProyecto.Edad_Minima > 0)
                {
                    command.Parameters.AddWithValue("@edadDesde", variablesInvestigadorXProyecto.Edad_Minima);
                }

                if (variablesInvestigadorXProyecto.Edad_Maxima > 0)
                {
                    command.Parameters.AddWithValue("@edadHasta", variablesInvestigadorXProyecto.Edad_Maxima);
                }

                conn.Open();

                using (SqlDataReader reader = command.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        ProyectoXInvestigador proyecto = new();

                        proyecto.Codigo = reader["Codigo"].ToString();
                        proyecto.Titulo = reader["Titulo"].ToString();
                        proyecto.Estado = reader["Estado"].ToString();
                        proyecto.Tipo = reader["Tipo"].ToString();
                        proyecto.AreaConocimiento = reader["AreaConocimiento"].ToString();
                        proyecto.ObjetivoSocioEconomico = reader["ObjetivoSocioEconomico"].ToString();
                        proyecto.EjeDePlanes = reader["EjeDePlanes"].ToString();
                        proyecto.UnidadInvestigacion = reader["UnidadInvestigacion"].ToString();
                        proyecto.FechaInicioEstimada = reader["FechaInicioEstimada"] == DBNull.Value ? null : ((DateTime)reader["FechaInicioEstimada"]).ToString("yyyy-MM-dd");
                        proyecto.FechaInicioReal = reader["FechaInicioReal"] == DBNull.Value ? null : ((DateTime)reader["FechaInicioReal"]).ToString("yyyy-MM-dd");
                        proyecto.FechaFinalizacionEstimada = reader["FechaFinalizacionEstimada"] == DBNull.Value ? null : ((DateTime)reader["FechaFinalizacionEstimada"]).ToString("yyyy-MM-dd");
                        proyecto.FechaFinalizacionReal = reader["FechaFinalizacionReal"] == DBNull.Value ? null : ((DateTime)reader["FechaFinalizacionReal"]).ToString("yyyy-MM-dd");
                        proyecto.Edad = reader["Edad"] != DBNull.Value ? Convert.ToInt32(reader["Edad"]) : (int?)null;
                        proyecto.Investigador = reader["Investigador"].ToString();

                        proyectos.Add(proyecto);
                    }
                }

                conn.Close();
            }

            return proyectos;
        }

        public List<Investigador> getInvestigadoresPorVariablesInvestigador(VariablesInvestigador variablesInvestigador)
        {
            List<Investigador> investigadores = new List<Investigador>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_FiltrarInvestigadoresDinamico", conn);
                command.CommandType = CommandType.StoredProcedure;

                if (!string.IsNullOrEmpty(variablesInvestigador.Grado_Academico))
                {
                    command.Parameters.AddWithValue("@gradoAcademico", variablesInvestigador.Grado_Academico);
                }

                if (variablesInvestigador.Edad_Minima > 0)
                {
                    command.Parameters.AddWithValue("@edadDesde", variablesInvestigador.Edad_Minima);
                }

                if (variablesInvestigador.Edad_Maxima > 0) 
                {
                    command.Parameters.AddWithValue("@edadHasta", variablesInvestigador.Edad_Maxima);
                }

                if (!string.IsNullOrEmpty(variablesInvestigador.Sexo))
                {
                    command.Parameters.AddWithValue("@sexo", variablesInvestigador.Sexo.ToLower().Equals("masculino")?1:0);
                }

                conn.Open();

                using (SqlDataReader reader = command.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        Investigador investigador = new Investigador();

                        investigador.PrimerApellido = reader["PrimerApellido"].ToString();
                        investigador.SegundoApellido = reader["SegundoApellido"].ToString();
                        investigador.Nombre = reader["Nombre"].ToString();
                        investigador.Identificacion = reader["Identificacion"].ToString();
                        investigador.CorreoPrincipal = reader["CorreoPrincipal"].ToString();
                        investigador.GradoAcademico = reader["GradoAcademico"].ToString();
                        investigador.Edad = reader["Edad"] != DBNull.Value ? Convert.ToInt32(reader["Edad"]) : (int?)null;
                        investigador.Sexo = reader["Sexo"] != DBNull.Value ? Convert.ToInt32(reader["Sexo"]) : (int?)null;

                        investigadores.Add(investigador);
                    }
                }

                conn.Close();
            }

            return investigadores;
        }

        public List<string> GetValoresSelect(string tabla)
        {
            List<string> lista = new List<string>();

            string query = $"SELECT Nombre FROM {tabla}";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int nombreOrdinal = reader.GetOrdinal("Nombre"); 

                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(nombreOrdinal)) 
                            {
                                string nombre = reader.GetString(nombreOrdinal);
                                lista.Add(nombre);
                            }
                        }
                    }

                    conn.Close();
                }
            }

            return lista;
        }

    }
}

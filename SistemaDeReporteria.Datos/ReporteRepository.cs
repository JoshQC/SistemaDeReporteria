using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SistemaDeReporteria.Datos
{
    public class ReporteRepository
    {
        public List<string> getReporte1()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionGestiona"].ConnectionString))
            {

                string query = "";

                SqlCommand command = new SqlCommand(query, conn);
                command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.AddWithValue("@param1",valor);
                //command.Parameters.AddRange();

                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) { }
                }
                conn.Close();

                return new List<string>();
            }
        }
    }
}

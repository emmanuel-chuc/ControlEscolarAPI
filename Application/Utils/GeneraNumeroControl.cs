using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Data;

namespace Application.Utils
{
    public class GeneraNumeroControl
    {
        /// <summary>
        /// Genera un número de control para el personal, basándose en el prefijo correspondiente al tipo de personal.
        /// </summary>
        /// <param name="cveTipoPersonal">El código del tipo de personal (por ejemplo, "D-" para Director, "H-" para Sub-Director, etc.).</param>
        /// <param name="ConexionString">La cadena de conexión a la base de datos.</param>
        /// <returns>Un número de control generado aleatoriamente para el personal.</returns>
        public static async Task<string?> GeneraNumeroControlPersonal(string idTipoPersonal, string ConexionString)
        {
            string numeroControl;

            using (var conexion = new SqlConnection(ConexionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@idTipoPersona", idTipoPersonal ?? string.Empty);
                parameters.Add("@NumeroControl", dbType: DbType.String, size: 20, direction: ParameterDirection.Output);

                await conexion.ExecuteAsync("spGeneraClaveControlPersonal", parameters, commandType: CommandType.StoredProcedure);
                numeroControl = parameters.Get<string>("@NumeroControl");

            }
            return numeroControl;
        }
        public static async Task<string?> GeneraNumeroControlAlumno( string ConexionString)
        {
            string numeroControl;

            using (var conexion = new SqlConnection(ConexionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@NumeroControl", dbType: DbType.String, size: 20, direction: ParameterDirection.Output);

                await conexion.ExecuteAsync("spGeneraClaveControlAlumno", parameters, commandType: CommandType.StoredProcedure);
                numeroControl = parameters.Get<string>("@NumeroControl");

            }
            return numeroControl;
        }
    }
}

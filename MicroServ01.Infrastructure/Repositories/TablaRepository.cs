using MicroServ01.Infrastructure.Common;
using MicroServ01.Domain.Models;
using MicroServ01.Application.Interfaces;
using Microsoft.Extensions.Configuration;

using MySqlConnector;
using Microsoft.Extensions.Logging;

namespace MicroServ01.Infrastructure.Repositories
{
    public class TablaRepository : ITablaRepository
    {
        private readonly string _connectionString;

        private readonly ILogger<TablaRepository> _logger;

        public TablaRepository(IConfiguration configuration, ILogger<TablaRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("dbMicro01") ?? "";
            _logger = logger;
        }

        public async Task<List<TablaResult>> Tabla_PS_Listado(TablaRequest request)
        {
            var listado = new List<TablaResult>();
            var rptaError = new TablaResult();

            try
            {
                using var connection = new MySqlConnection(_connectionString);

                await connection.OpenAsync();

                using var command = new MySqlCommand("call tabla_ps_listado(@P_SEXO, @P_CARRERA)", connection);

                command.Parameters.AddWithValue("@P_SEXO", request.Sexo);
                command.Parameters.AddWithValue("@P_CARRERA", request.Carrera);

                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var resultado = new TablaResult
                    {
                        
                        Id = Convert.ToInt32(reader["ID"]),
                        Semestre = reader["SEMESTRE"].ToString(),
                        Sexo = reader["SEXO"].ToString(),
                        FecNac = reader["NACIMIENTO"].ToString(),
                        Ubigeo = reader["UBIGEO"].ToString(),
                        Carrera = reader["ESCUELA_PROFESIONAL"].ToString(),
                        Ciclo = reader["CICLO"].ToString(),
                        FecIngreso = reader["FECHA_INGRESO"].ToString(),
                        Modalidad = reader["MODALIDAD"].ToString(),
                        CreditosAcum = Convert.ToInt32(reader["CREDITOS_ACUMULADOS"])
                    };

                    listado.Add(resultado);
                }
            }
            catch (MySqlException ex)
            {
                _logger.LogError(ex, "Error de conexión con la BD.");

                rptaError.Mensaje = ex.Message;

                listado.Add(rptaError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado.");

                rptaError.Mensaje = ex.Message;

                listado.Add(rptaError);
            }

            return listado;
        }
    }
}

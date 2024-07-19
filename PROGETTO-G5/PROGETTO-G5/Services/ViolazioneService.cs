using PROGETTO_G5.Models;
using System.Data.SqlClient;

namespace PROGETTO_G5.Services
{
    public class ViolazioneService : IViolazioneService
    {
        private readonly string _connectionString;
        private const string GET_TIPO_VIOLAZIONE = "SELECT IDViolazione, Descrizione FROM Tipo_Violazione";
        public ViolazioneService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Authdb");
        }

        public List<TipoViolazione> GetTipoViolazione()
        {
            var violazioni = new List<TipoViolazione>();
            try
            {
                using(var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using(var command = new SqlCommand(GET_TIPO_VIOLAZIONE, connection))
                    {
                        using(var reader = command.ExecuteReader())
                        {
                 
                           
                            while(reader.Read())
                            {
                                var violazione = new TipoViolazione
                                {
                                    IdViolazione = reader.GetInt32(0),
                                    Descrizione = reader.GetString(1)
                                };
                                violazioni.Add(violazione);

                            }
                          
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return violazioni;
        }
    }
}

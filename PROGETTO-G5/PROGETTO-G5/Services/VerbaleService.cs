using PROGETTO_G5.Models;
using System.Data.SqlClient;

namespace PROGETTO_G5.Services
{
    public class VerbaleService : IVerbaleService
    {
        private readonly string _connectionString;
        private const string CREATE_VERBALE_COMMAND = @"INSERT INTO Verbale
            (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti,IdAnagrafica,IdTipoViolazione)
            OUTPUT INSERTED.IdVerbale 
            VALUES (@DataViolazione, @IndirizzoViolazione, @NominativoAgente, @DataTrascrizioneVerbale, @Importo, @DecurtamentoPunti,@IdAnagrafica,@IdTipoViolazione)";
        public VerbaleService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Authdb");
        }
        public Verbale CreateVerbale(Verbale verbale)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(CREATE_VERBALE_COMMAND, connection))
                    {

                        command.Parameters.AddWithValue("@DataViolazione", verbale.DataViolazione);
                        command.Parameters.AddWithValue("@IndirizzoViolazione", verbale.IndirizzoViolazione);
                        command.Parameters.AddWithValue("@NominativoAgente", verbale.NominativoAgente);
                        command.Parameters.AddWithValue("@DataTrascrizioneVerbale", verbale.DataTrascrizioneVerbale);
                        command.Parameters.AddWithValue("@Importo", verbale.Importo);
                        command.Parameters.AddWithValue("@DecurtamentoPunti", verbale.DecurtamentoPunti);
                        command.Parameters.AddWithValue("@IdAnagrafica", verbale.IdAnagrafica);
                        command.Parameters.AddWithValue("@IdTipoViolazione", verbale.IdTipoViolazione);
                        verbale.IdVerbale = (int)command.ExecuteScalar();
                    }
                    return verbale;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using PROGETTO_G5.Models;
using System.Data.SqlClient;

namespace PROGETTO_G5.Services
{
    public class AnagraficaService : IAnagraficaService
    {
        private readonly string _connectionString;
        private const string CREATE_ANAGRAFICA_COMMAND = @"INSERT INTO Anagrafica
            (Nome, Cognome, Indirizzo, Citta, CAP, CodiceFiscale)
            OUTPUT INSERTED.IdAnagrafica 
            VALUES (@Cognome, @Nome, @Indirizzo, @Citta, @CAP, @CodiceFiscale)";
        public AnagraficaService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Authdb");
        }
        public Anagrafica CreateAnagrafica(Anagrafica anagrafica)
        {
            try
            {
                using(var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using(var command = new SqlCommand(CREATE_ANAGRAFICA_COMMAND, connection))
                    {
                      
                      command.Parameters.AddWithValue("@Cognome", anagrafica.Cognome);
                      command.Parameters.AddWithValue("@Nome", anagrafica.Nome);
                      command.Parameters.AddWithValue("@Indirizzo", anagrafica.Indirizzo);
                      command.Parameters.AddWithValue("@Citta", anagrafica.Citta);
                      command.Parameters.AddWithValue("@CAP", anagrafica.Cap);
                      command.Parameters.AddWithValue("@CodiceFiscale", anagrafica.CodiceFiscale);
                      anagrafica.IdAnagrafica = (int)command.ExecuteScalar();
                    }
                    return anagrafica;
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}

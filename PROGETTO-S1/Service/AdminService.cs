using PROGETTO_S1.Models;
using System.Data.SqlClient;

namespace PROGETTO_S1.Service
{
    public class AdminService : IAdminService
    {
        private readonly string _connectionString;
        private const string SPEDIZIONI_IN_CONSEGNA_COMMAND = "SELECT * FROM Spedizioni s JOIN StatoSpedizione st ON s.IdSpedizione = st.FK_IdSpedizione WHERE st.Stato = 'In Consegna' AND CONVERT(DATE, DataConsegnaPrev) = CAST(GETDATE() AS DATE);";
        private const string SPEDIZIONI_IN_ATTESA_COMMAND = "SELECT * FROM Spedizioni";
        private const string SPEDIZIONI_PER_CITTA_COMMAND = "SELECT * FROM Spedizioni";


        public AdminService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Authdb");
        }

        public List<Spedizione> Spedizioni()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(SPEDIZIONI_IN_CONSEGNA_COMMAND, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            var spedizioni = new List<Spedizione>();
                            while (reader.Read())
                            {

                            }
                            return spedizioni;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}

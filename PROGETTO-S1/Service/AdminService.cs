using PROGETTO_S1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace PROGETTO_S1.Service
{
    public class AdminService : IAdminService
    {
        private readonly string _connectionString;

        private const string SPEDIZIONI_IN_CONSEGNA_COMMAND = @"
            SELECT s.IdSpedizione, s.FK_ClienteAzienda, s.FK_ClientePrivato, s.NumId, s.DataSpedizione, 
                   s.Peso, s.CittaDestinatario, s.Indirizzo, s.NomeDestinatario, s.CostoSpedizione, 
                   s.DataConsegnaPrev
            FROM Spedizioni s
            JOIN StatoSpedizione st ON s.IdSpedizione = st.FK_IdSpedizione
            WHERE st.Stato = 'In Consegna'
            AND CONVERT(DATE, s.DataConsegnaPrev) = CAST(GETDATE() AS DATE);";

        private const string TOTALE_SPEDIZIONI_NON_CONSEGNATE_COMMAND = @"
        SELECT COUNT(*) FROM Spedizioni s
        JOIN StatoSpedizione st ON s.IdSpedizione = st.FK_IdSpedizione
        WHERE st.Stato != 'Consegnato';";

        public AdminService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Authdb");
        }

        public List<Spedizione> SpedizioniInConsegnaOggi()
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
                                var spedizione = new Spedizione
                                {
                                    IdSpedizione = reader.GetInt32(reader.GetOrdinal("IdSpedizione")),
                                    FK_ClienteAzienda = reader.IsDBNull(reader.GetOrdinal("FK_ClienteAzienda")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("FK_ClienteAzienda")),
                                    FK_ClientePrivato = reader.IsDBNull(reader.GetOrdinal("FK_ClientePrivato")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("FK_ClientePrivato")),
                                    NumId = reader.GetInt32(reader.GetOrdinal("NumId")),
                                    DataSpedizione = reader.GetDateTime(reader.GetOrdinal("DataSpedizione")),
                                    Peso = reader.GetDecimal(reader.GetOrdinal("Peso")),
                                    CittaDestinatario = reader.GetString(reader.GetOrdinal("CittaDestinatario")),
                                    Indirizzo = reader.GetString(reader.GetOrdinal("Indirizzo")),
                                    NomeDestinatario = reader.GetString(reader.GetOrdinal("NomeDestinatario")),
                                    CostoSpedizione = reader.GetDecimal(reader.GetOrdinal("CostoSpedizione")),
                                    DataConsegnaPrev = reader.GetDateTime(reader.GetOrdinal("DataConsegnaPrev"))
                                };
                                spedizioni.Add(spedizione);
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
        public List<Spedizione> TotSpedizioniNonConsegnate()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(TOTALE_SPEDIZIONI_NON_CONSEGNATE_COMMAND, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            var spedizioni = new List<Spedizione>();
                            while (reader.Read())
                            {
                                var spedizione = new Spedizione
                                {

                                };
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

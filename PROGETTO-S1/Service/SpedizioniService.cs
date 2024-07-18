using PROGETTO_S1.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

namespace PROGETTO_S1.Service
{
    public class SpedizioniService : ISpedizioniService
    {
        private readonly string _connectionString;

        public SpedizioniService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Authdb");
        }

        public List<Spedizione> SpedizioniPerClientePrivato(string codiceFiscale)
        {
            const string query = @"
        SELECT s.*
        FROM Spedizioni s
        JOIN ClientiPrivato cp ON s.FK_ClientePrivato = cp.IdClientePriv
        WHERE cp.CF = 'VRDLUC78B15H501N'";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Assicurati che il nome del parametro corrisponda esattamente alla query SQL
                        command.Parameters.AddWithValue("@VRDLUC78B15H501N", codiceFiscale);

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


    }
}

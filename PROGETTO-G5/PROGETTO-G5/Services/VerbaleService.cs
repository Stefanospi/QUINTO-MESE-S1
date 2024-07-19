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
        private const string VERBALE_CON_TRASGRESSORE_COMMAND = @"
            SELECT A.IdAnagrafica,a.Cognome,a.Nome, COUNT(v.IdVerbale) AS TotaleVerbali
            FROM Verbale v
            JOIN Anagrafica a ON v.IdAnagrafica = a.IdAnagrafica
            GROUP BY a.IdAnagrafica,a.Cognome,a.Nome
            ORDER BY TotaleVerbali DESC";
        private const string VERBALE_CON_PUNTI_DECURTATI_COMMAND = @"
            SELECT A.IdAnagrafica,a.Cognome,a.Nome, SUM(v.DecurtamentoPunti) AS PuntiDecurtati
            FROM Verbale v
            JOIN Anagrafica a ON v.IdAnagrafica = a.IdAnagrafica
            GROUP BY a.IdAnagrafica,a.Cognome,a.Nome
            ORDER BY PuntiDecurtati DESC";

        private const string VERBALE_CON_10PUNTI_DECURTATI_COMMAND = @"
            SELECT v.Importo,v.DataViolazione,v.DecurtamentoPunti,a.Cognome,a.Nome 
            FROM Verbale v
            JOIN Anagrafica a ON v.IdAnagrafica = a.IdAnagrafica
            WHERE v.DecurtamentoPunti > 10";
        private const string VERBALE_CON_IMPORTO_400_COMMAND = @"
            SELECT v.Importo,v.DataViolazione,v.DecurtamentoPunti ,a.Nome,a.Cognome
            FROM Verbale v
            JOIN Anagrafica a ON v.IdAnagrafica = a.IdAnagrafica
            WHERE v.Importo > 400";
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

        public List<VerbaleConTrasgressore> GetVerbaleConTrasgressore()
        {
            List<VerbaleConTrasgressore> verbaliConTrasgressore = new List<VerbaleConTrasgressore>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(VERBALE_CON_TRASGRESSORE_COMMAND, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VerbaleConTrasgressore verbaleConTrasgressore = new VerbaleConTrasgressore
                                {
                                    IdAnagrafica = reader.GetInt32(0),
                                    Cognome = reader.GetString(1),
                                    Nome = reader.GetString(2),
                                    TotaleVerbali = reader.GetInt32(3)
                                };
                                verbaliConTrasgressore.Add(verbaleConTrasgressore);
                            }
                        }
                    }
                }
                return verbaliConTrasgressore;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<VerbaliConPuntiDecurtati> GetVerbaliConPuntiDecurtati()
        {
            List<VerbaliConPuntiDecurtati> verbaliConPuntiDecurtati = new List<VerbaliConPuntiDecurtati>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(VERBALE_CON_PUNTI_DECURTATI_COMMAND, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VerbaliConPuntiDecurtati verbaleConPuntiDecurtati = new VerbaliConPuntiDecurtati
                                {
                                    IdAnagrafica = reader.GetInt32(0),
                                    Cognome = reader.GetString(1),
                                    Nome = reader.GetString(2),
                                    PuntiDecurtati = reader.GetInt32(3)
                                };
                                verbaliConPuntiDecurtati.Add(verbaleConPuntiDecurtati);
                            }
                        }
                    }
                }
                return verbaliConPuntiDecurtati;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<VerbaliConDecurtamento10Punti> GetVerbaliCon10PuntiDecurtati()
        {
            List<VerbaliConDecurtamento10Punti> verbaliConDecurtamento10Punti = new List<VerbaliConDecurtamento10Punti>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(VERBALE_CON_10PUNTI_DECURTATI_COMMAND, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VerbaliConDecurtamento10Punti verbaleConDecurtamento10Punti = new VerbaliConDecurtamento10Punti
                                {
                                    Importo = reader.GetDecimal(0),
                                    DataDiViolazione = reader.GetDateTime(1),
                                    DecurtamentoPunti = reader.GetInt32(2),
                                    Cognome = reader.GetString(3),
                                    Nome = reader.GetString(4)
                                };
                                verbaliConDecurtamento10Punti.Add(verbaleConDecurtamento10Punti);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return verbaliConDecurtamento10Punti;
        }

        public List<VerbaliConImporto400> GetVerbaliConImporto400()
        {
            try
            {
                List<VerbaliConImporto400> verbaliConImporto400 = new List<VerbaliConImporto400>();
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(VERBALE_CON_IMPORTO_400_COMMAND, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VerbaliConImporto400 verbaleConImporto400 = new VerbaliConImporto400
                                {
                                    Importo = reader.GetDecimal(0),
                                    Cognome = reader.GetString(1),
                                    Nome = reader.GetString(2),
                                    NominativoAgente = reader.GetString(3),
                                    DataDiViolazione = reader.GetDateTime(4),
                                    DecurtamentoPunti = reader.GetInt32(5)
                                };
                                verbaliConImporto400.Add(verbaleConImporto400);
                            }
                        }
                    }
                }
                return verbaliConImporto400;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}

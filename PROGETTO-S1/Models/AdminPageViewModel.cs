namespace PROGETTO_S1.Models
{
    public class AdminPageViewModel
    {
        public IEnumerable<Spedizione> Spedizioni { get; set; }
        public int TotSpedizioniNonConsegnate { get; set; }
        public IEnumerable<SpedizioniPerCittaResult> SpedizioniPerCitta { get; set; }
        public IEnumerable<Spedizione> GetAllSpedizioni { get; set; }
        public IEnumerable<ClienteAzienda> GetAllAzienda { get; set; }
        public IEnumerable<ClientePrivato> GetAllPrivati { get; set; }

    }
}

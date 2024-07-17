namespace PROGETTO_S1.Models
{
    public class AdminPageViewModel
    {
        public IEnumerable<Spedizione> Spedizioni { get; set; }
        public int TotSpedizioniNonConsegnate { get; set; }
    }
}

namespace PROGETTO_S1.Models
{
    public interface iStatoSpedizione
    {
        public int Id { get; set; }
        public int SpedizioneId { get; set; }
        public string Stato { get; set; }
        public string Luogo { get; set; }
        public string Descrizione { get; set; }
        public DateOnly DataOra { get; set; }
    }
}

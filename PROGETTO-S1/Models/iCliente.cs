namespace PROGETTO_S1.Models
{
    public interface iCliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CodiceFiscale { get; set; }
        public string PartitaIva { get; set; }
        public bool IsAzienda { get; set; }

    }
}

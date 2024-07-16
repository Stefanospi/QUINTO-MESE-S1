namespace PROGETTO_S1.Models
{
    public interface iSpedizioni
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int NumeroIdentificativo { get; set; }
        public DateOnly DataSpedizione { get; set; }
        public int Peso { get; set; }
        public string CittaDestinataria { get; set; }
        public string IndirizzoDestinatario { get; set; }
        public string NominativoDestinatario { get; set; }
        public decimal CostoSpedizione { get; set; }
        public DateOnly DataConsegnaPrevista { get; set; }
    }
}

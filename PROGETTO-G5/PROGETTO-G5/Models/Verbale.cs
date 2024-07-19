namespace PROGETTO_G5.Models
{
    public class Verbale
    {
        public int IdVerbale { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string NominativoAgente { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
        public int IdAnagrafica { get; set; }
        public int IdTipoViolazione { get; set; }


    }
}

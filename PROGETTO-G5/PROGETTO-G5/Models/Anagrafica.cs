using System.ComponentModel.DataAnnotations;

namespace PROGETTO_G5.Models
{
    public class Anagrafica
    {
        public int IdAnagrafica { get; set; }
        [Required]

        public string Cognome { get; set; }
        [Required]

        public string Nome { get; set; }
        [Required]

        public string Indirizzo { get; set; }
        [Required]

        public string Citta { get; set; }
        [Required]

        public int Cap { get; set; }
        [Required]

        public string CodiceFiscale { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace PROGETTO_S1.Models
{
    public class EmailViewModel
    {

        [Display(Name= "La tua mail")]
        public string ToEmail { get; set; }

        [Display(Name = "Oggetto")]
        public string Subject { get; set; }

        [Display(Name = "Il tuo messaggio")]
        public string Message { get; set; }
    }
}

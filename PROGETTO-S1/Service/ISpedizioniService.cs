using PROGETTO_S1.Models;

namespace PROGETTO_S1.Service
{
    public interface ISpedizioniService
    {
        List<Spedizione> SpedizioniPerClientePrivato(string codiceFiscale);
      //  List<Spedizione> SpedizioniPerClienteAzienda(string partitaIVA);
    }
}

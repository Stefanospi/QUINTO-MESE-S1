using PROGETTO_S1.Models;

namespace PROGETTO_S1.Service
{
    public interface IAdminService
    {
        public List<Spedizione> SpedizioniInConsegnaOggi();
        public int TotSpedizioniNonConsegnate();
        public List<Spedizione> SpedizioniPerCitta();
    }
}

using PROGETTO_S1.Models;

namespace PROGETTO_S1.Service
{
    public interface IAdminService
    {
        public List<Spedizione> SpedizioniInConsegnaOggi();
        public List<Spedizione> TotSpedizioniNonConsegnate();
    }
}

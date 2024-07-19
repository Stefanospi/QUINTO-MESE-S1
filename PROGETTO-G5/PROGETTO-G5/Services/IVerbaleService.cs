using PROGETTO_G5.Models;

namespace PROGETTO_G5.Services
{
    public interface IVerbaleService
    {
        public Verbale CreateVerbale(Verbale verbale);
        public List<VerbaleConTrasgressore> GetVerbaleConTrasgressore();
        public List<VerbaliConPuntiDecurtati> GetVerbaliConPuntiDecurtati();
        public List<VerbaliConDecurtamento10Punti> GetVerbaliCon10PuntiDecurtati();
        public List<VerbaliConImporto400> GetVerbaliConImporto400();
        
    }
}

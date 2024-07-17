namespace PROGETTO_S1.Models
{
    public class Users
    {
        public int id { get; set; }
        public required string username { get; set; }
        public required string password { get; set; }
        public List<string> roles { get; set; }
    }
}

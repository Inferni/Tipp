using TIPP.Shared;

namespace TIPP.Client.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Role Role { get; }
        public string Token { get; set; }
    }
}

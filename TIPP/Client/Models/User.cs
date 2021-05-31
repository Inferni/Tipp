using TIPP.Shared;

namespace TIPP.Client.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public Role Role { get; }
        public string Token { get; set; }
    }
}

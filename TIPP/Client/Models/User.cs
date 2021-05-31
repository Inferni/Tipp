using TIPP.Shared;

namespace TIPP.Client.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public Role Role { get; set; }
    }
}

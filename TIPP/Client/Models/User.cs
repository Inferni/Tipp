using System.ComponentModel.DataAnnotations;
using TIPP.Shared;

namespace TIPP.Client.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public Role Role { get; }
        public string Token { get; set; }
    }
}

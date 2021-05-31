using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIPP.Shared
{
    public class UserDTO
    {
        public int Id { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public UserDTO()
        {
        }

        public UserDTO(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Role = user.Role;
        }
    }
}

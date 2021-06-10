using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIPP.Shared
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public int ProjectID { get; set; }
        public UserDTO()
        {
        }

        public UserDTO(int id)
        {
            Id = id;
        }

        public UserDTO(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Role = user.Role;
        }
    }
}

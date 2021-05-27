using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIPP.Shared
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User()
        {
        }

        public User(UserDTO dto)
        {
            if(dto.Id!=null)
            {
                Id = dto.Id;

            }
            Username = dto.Username;
            Password = dto.Password;
        }

        public User(int id, string username, string password, string role)
        {
            Id = id;
            Username = username;
            Password = password;
            Role = role;
        }
    }
}

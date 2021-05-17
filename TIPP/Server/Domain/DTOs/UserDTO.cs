using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TIPP.Server.Domain.DTOs
{
    public class UserDTO
    {
        public int Id { get; }
        public string Username { get; }
        public string Password { get; }

        public UserDTO(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
        }
    }
}

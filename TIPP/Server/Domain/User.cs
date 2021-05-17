using System;
using System.Collections.Generic;
using TIPP.Server.Domain.DTOs;

#nullable disable

namespace TIPP.Server.Domain
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }


        public User(UserDTO dto)
        {
            Id = dto.Id;
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

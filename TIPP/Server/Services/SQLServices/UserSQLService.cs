using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Domain.DTOs;

namespace TIPP.Server.Services.SQLServices
{
    public class UserSQLService : IUserService
    {
        private tipp_DBContext context;

        public UserSQLService()
        {
            this.context = new tipp_DBContext() ;
        }

        public object GetUsers()
        {
            return new { Items = context.Users };
        }

        public bool CreateUser(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public bool DeleteUser(User user)
        {
            User userToDelete;
            try
            {
                userToDelete = context.Users.Where(x => x.Id.Equals(user.Id)).FirstOrDefault();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;
            }

            context.Users.Remove(userToDelete);
            return true;
        }

        public UserDTO ReadUser(User user)
        {
            User userRetrieved;

            try
            {
                userRetrieved = context.Users.Where(x => x.Id.Equals(user.Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return null;
            }
            UserDTO dto = new UserDTO(userRetrieved);
            return dto;
        }

        public bool UpdateUser(User user)
        {
            User userToUpdate;
            try
            {
                userToUpdate = context.Users.Where(x => x.Id.Equals(user.Id)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
                throw;
            }

            try
            {
                userToUpdate.Username = user.Username;
                userToUpdate.Password = user.Password;
                userToUpdate.Role = user.Role;
                context.Update(userToUpdate);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;
            }

            return true;
        }
    }
}

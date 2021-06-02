using System;
using System.Data;
using System.Linq;
using TIPP.Server.Domain;
using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{

    public class UserSQLService : IUserService
    {
        private tipp_DBContext context;

        public UserSQLService(tipp_DBContext context)
        {
            this.context = context;
        }

        public object GetUsers()
        {
            Console.WriteLine("Getting Users");
            return context.Users;
        }

   

        public User Authenticate(User user)
        {
            User authenticatedUser = context.Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);

            return authenticatedUser;
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

        public object GetUsersByProjectId(ProjectDTO dto)
        {
            object userIds = context.ProjectUsers.Where(x => x.Project.Equals(dto.Id));
            object users = context.Users.Where(x => x.Id.Equals(userIds));

            return users;
        }

        public User GetUserById(UserDTO dto)
        {
            return context.Users.Where(x => x.Id.Equals(dto.Id)).FirstOrDefault();
        }
    }
}

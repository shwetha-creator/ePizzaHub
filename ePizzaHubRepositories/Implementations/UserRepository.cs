using ePizzaHubEntities;
using ePizzaHubModels;
using ePizzaHubRepositories.Interfaces;
using BC = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHubRepositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        private AppDbContext context
        {
            get 
            {
                return _db as AppDbContext;
            }
        }
        public UserRepository(AppDbContext db) : base(db)
        {

        }
        public bool CreateUser(User user, string Role)
        {
            try
            {
                user.Password = BC.HashPassword(user.Password);
                Role role = context.Roles.Where(r => r.Name == Role).First();
                user.Roles.Add(role); // this line of code added data to UserRole
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public UserModel ValidateUser(string email, string password)
        {
          var user =  context.Users.Include(u => u.Roles).Where(u => u.Email == email).FirstOrDefault();
            if(user != null)
            {
                var isVerified = BC.Verify(password, user.Password);
                if(isVerified)
                {
                    UserModel model = new UserModel();
                    model.Id = user.Id;
                    model.Name = user.Name;
                    model.Email = user.Email;
                    model.PhoneNumber = user.PhoneNumber;
                    model.Roles = user.Roles.Select(r => r.Name).ToArray();
                    return model;
                }
            }
            return null;

        }
    }
}

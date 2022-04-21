using ePizzaHubEntities;
using ePizzaHubModels;
using ePizzaHubRepositories.Interfaces;
using ePizzaHubServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHubServices.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;

        public AuthService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public bool CreateUser(User user, string role)
        {
            return _userRepo.CreateUser(user, role);
        }

        public UserModel ValidateUser(string email, string password)
        {
            return _userRepo.ValidateUser(email, password);
        }
    }
}

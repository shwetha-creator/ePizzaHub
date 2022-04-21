using ePizzaHubEntities;
using ePizzaHubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHubRepositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        // UserModel is the Viewmodel created to combine the multiple entities ie., user and Role
       UserModel ValidateUser(string email, string password);
       bool CreateUser(User user, string role);
    }
}

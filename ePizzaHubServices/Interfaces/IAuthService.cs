using ePizzaHubEntities;
using ePizzaHubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHubServices.Interfaces
{
  public  interface IAuthService
    {
        UserModel ValidateUser(string email, string password);
        bool CreateUser(User user, string role);
    }
}

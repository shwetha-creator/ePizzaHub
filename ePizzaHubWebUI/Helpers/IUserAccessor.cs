using ePizzaHubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePizzaHubWebUI.Helpers
{
  public  interface IUserAccessor
    {
        UserModel GetUser();
    }
}

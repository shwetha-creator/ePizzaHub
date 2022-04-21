using ePizzaHubModels;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace ePizzaHubWebUI.Helpers
{
    public abstract class BaseViewPage<TModel> : RazorPage<TModel>
    {
        public UserModel CurrentUser
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    string userdata = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value;
                    UserModel user = JsonSerializer.Deserialize<UserModel>(userdata);
                    return user;

                }
                return null;
            }
        }
    }
}
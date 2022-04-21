using ePizzaHubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Text.Json;

namespace ePizzaHubWebUI.Helpers
{
    public class UserAccessor : IUserAccessor
    {
        IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public UserModel GetUser()
        {
            //User is the ClaimsPrincipal User property here we have to use HttpContext user to use this User property  
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                string userdata = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value;
                UserModel user = JsonSerializer.Deserialize<UserModel>(userdata);
                return user;

            }
            return null;
        }
    }
}

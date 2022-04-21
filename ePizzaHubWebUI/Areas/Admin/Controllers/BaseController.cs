using ePizzaHubModels;
using ePizzaHubWebUI.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace ePizzaHubWebUI.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles ="Admin")]
    [Area("Admin")]
    public class BaseController : Controller
    {
        //public UserModel CurrentUser
        //{
        //    get
        //    {
        //        if (User.Identity.IsAuthenticated)
        //        {
        //            string userdata = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData).Value;
        //            UserModel user = JsonSerializer.Deserialize<UserModel>(userdata);
        //            return user;

        //        }
        //        return null;
        //    }
        //}

    }
}

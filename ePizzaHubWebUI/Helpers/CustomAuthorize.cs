using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePizzaHubWebUI.Helpers
{
    public class CustomAuthorize : Attribute, IAuthorizationFilter // inherit from Attribute class
                                                                   // and IAuthorization filter
    {
        public string Roles { get; set; }
        // Implement the interface - OnAuthorization method 
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           //authentication
           if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                //authorization
                if(!context.HttpContext.User.IsInRole(Roles))
                {
                    context.Result = new RedirectToActionResult("UnAuthorize", "Account", new { area = "" });
                }               
            }
            else
            {
                context.Result = new RedirectToActionResult("Login", "Account", new { area = "" });
            }
        }
    }
}

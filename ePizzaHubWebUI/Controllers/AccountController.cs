using ePizzaHubEntities;
using ePizzaHubModels;
using ePizzaHubServices.Interfaces;
using ePizzaHubWebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace ePizzaHubWebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            UserModel user = _authService.ValidateUser(model.Email, model.Password);
            if (user != null)
            {
                GenerateTicket(user);
                if (user.Roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                if (user.Roles.Contains("User"))
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "User" });
                }
            }
            return View();
        }

        async void GenerateTicket(UserModel user)
        {
            string strData = JsonSerializer.Serialize(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.UserData, strData),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Roles.ToString()),
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                            new ClaimsPrincipal(identity),
                                            new AuthenticationProperties
                                            {
                                                AllowRefresh = true,
                                            });

        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    PhoneNumber = model.PhoneNumber,
                    CreatedDate = DateTime.Now

                };
                bool result = _authService.CreateUser(user, "Admin"); // from the public Page , we can create the user with the
                                                                     // role "User" not the "admin"
                if (result)
                {
                   return  RedirectToAction("Login");
                }
            }
            return View();           
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);// If the method is asynchrounous then use "await"
                                                                                              // and return type would be Async Task<>
            return RedirectToAction("Login","Account");
        }

        public IActionResult UnAuthorize()
        {
            return View();
        }
    }
}
        

        
    
                
    
  

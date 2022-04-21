using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ePizzaHubWebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Please Enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
    }
}

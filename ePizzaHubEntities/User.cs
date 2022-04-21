using System;
using System.Collections.Generic;

namespace ePizzaHubEntities
{
    public class User
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        
    }
}



using System.Collections.Generic;

namespace ePizzaHubEntities
{
   public class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual  ICollection<User> Users { get; set; }

        // Role and user has many to many relationship
        // ie., each user can have multiple roles and each role can be assigned to multiple users 

        // In code first approach ,if we want to add many to many relationship
        // , we need to add third entity  , we are adding the third entity . UserRole 

        // so another entity called UserRole is added and foreign key is defined there .

    }
}
